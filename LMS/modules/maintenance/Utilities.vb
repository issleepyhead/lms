
Imports MySql.Data.MySqlClient

Module Utilities
    Public Function GenerateAccession() As String
        Dim highestAccession As Integer = ExecScalar("SELECT CAST(accession_no AS SIGNED) accession FROM tblbookcopies ORDER BY accession_no DESC LIMIT 1")
        If highestAccession = 0 Then
            highestAccession += 1
        End If
        Return highestAccession.ToString().PadLeft(10, "0")
    End Function

    Public Function GenerateCirculation() As String
        Dim highestCirculation As Integer = ExecScalar("SELECT CAST(circulation_no AS SIGNED) circulation_no FROM tblborrowheaders ORDER BY CAST(circulation_no AS SIGNED) DESC LIMIT 1")
        highestCirculation += 1
        Return highestCirculation.ToString().PadLeft(10, "0")
    End Function

    Public Function AddCopies(numOfCopies As Integer, isbn As String, price As Decimal, Optional donator_id As Integer = Nothing, Optional supplier_id As Integer = Nothing) As Boolean
        Dim book_id As Integer = ExecScalar("SELECT id FROM tblbooks WHERE isbn = @isbn", New Dictionary(Of String, String) From {{"@isbn", isbn}})
        Return ExecProcedure("AddBookCopies", New Dictionary(Of String, String) From {
            {"bid", book_id},
            {"number_of_copies", numOfCopies},
            {"pr", price},
            {"did", If(IsNothing(donator_id) OrElse donator_id = 0, "0", donator_id)},
            {"sid", If(IsNothing(supplier_id) OrElse supplier_id = 0, "0", supplier_id)}
        })
    End Function

    Public Function AddAssistantLibrarian(collection As List(Of Dictionary(Of String, String))) As Boolean
        ' TODO FIX THIS LATURRR
        Dim transac As MySqlTransaction = Nothing
        Try
            Using conn As New MySqlConnection(My.Settings.connection_string)
                conn.Open()
                transac = conn.BeginTransaction

                For Each item As Dictionary(Of String, String) In collection
                    Dim cmd As New MySqlCommand("SELECT COUNT(*) FROM tbladmins WHERE student_id = @id OR faculty_id = @id", conn, transac)
                    cmd.Parameters.AddWithValue("@id", If(String.IsNullOrEmpty(item.Item("@sid")), item.Item("@fid"), item.Item("@sid")))
                    If cmd.ExecuteScalar() = 0 Then
                        cmd.CommandText = ADD_ADMIN_QUERY
                        With cmd.Parameters
                            For Each kv In item
                                .AddWithValue(kv.Key, If(String.IsNullOrEmpty(kv.Value), DBNull.Value, kv.Value))
                            Next
                        End With
                        cmd.ExecuteNonQuery()
                    End If
                Next
                transac.Commit()
                Return True
            End Using
        Catch ex As Exception
            Logger.Logger(ex)
            transac.Rollback()
            Return False
        End Try
    End Function

    Public Function FetchStudentBorrower() As DataTable
        Dim dt As New DataTable
        Try
            Dim adapter As MySqlDataAdapter
            Using conn As New MySqlConnection(My.Settings.connection_string)
                conn.Open()
                Dim cmd As New MySqlCommand("SELECT st.id, student_no `Student No.`, lrn `LRN`, full_name `Full Name`
                                                FROM tblstudents st
                                                LEFT JOIN tblborrowheaders bh ON st.id = bh.student_id
                                                LEFT JOIN tblborrowedcopies bc ON bh.id = bc.header_id
                                                GROUP BY student_no, lrn, full_name, st.id
                                                HAVING COUNT(bc.copy_id) < 5", conn)
                adapter = New MySqlDataAdapter(cmd)
                adapter.Fill(dt)
                Return dt
            End Using
        Catch ex As Exception
            Return New DataTable
        End Try
    End Function

    Public Function FetchFacultyBorrower() As DataTable
        ' TODO Change the limit
        Dim dt As New DataTable
        Try
            Dim adapter As MySqlDataAdapter
            Using conn As New MySqlConnection(My.Settings.connection_string)
                conn.Open()
                Dim cmd As New MySqlCommand("SELECT st.id, full_name `Full Name`, dp.department_name `Department`
                                                FROM tblfaculties st
                                                LEFT JOIN tbldepartments dp ON st.department_id = dp.id
                                                LEFT JOIN tblborrowheaders bh ON st.id = bh.faculty_id
                                                LEFT JOIN tblborrowedcopies bc ON bh.id = bc.header_id
                                                WHERE st.status = 1
                                                GROUP BY full_name, dp.department_name, st.id
                                                HAVING COUNT(bc.copy_id) < 5", conn)
                adapter = New MySqlDataAdapter(cmd)
                adapter.Fill(dt)
                Return dt
            End Using
        Catch ex As Exception
            Return New DataTable
        End Try
    End Function

    Public Function CheckStudent(query As String) As Integer
        Try
            Using conn As New MySqlConnection(My.Settings.connection_string)
                conn.Open()
                Dim cmd As New MySqlCommand("SELECT st.id
                                            FROM tblstudents st
                                            LEFT JOIN tblborrowheaders bh ON st.id = bh.student_id
                                            LEFT JOIN tblborrowedcopies bc ON bh.id = bc.header_id
                                            WHERE (student_no = @query OR lrn = @query) AND st.status = 1
                                            GROUP BY st.id
                                            HAVING COUNT(bc.copy_id) < 5", conn)
                cmd.Parameters.AddWithValue("@query", query)
                Return cmd.ExecuteScalar()
            End Using
        Catch ex As Exception
            Logger.Logger(ex)
            Return 0
        End Try
    End Function

    Public Function InsertBorrow(header As Dictionary(Of String, String), copies As List(Of Dictionary(Of String, String))) As Boolean
        Dim trans As MySqlTransaction = Nothing
        Try
            Using conn As New MySqlConnection(My.Settings.connection_string)
                conn.Open()
                trans = conn.BeginTransaction

                Dim cmd As New MySqlCommand("INSERT INTO tblborrowheaders (student_id, faculty_id, circulation_no, issued_by, overdue_date, borrow_date)
                                               VALUES (@sid, @fid, @cno, @isby, CAST(@odate AS DATETIME), CAST(@bdate AS DATETIME))", conn, trans)
                With cmd.Parameters
                    For Each kv In header
                        .AddWithValue(kv.Key, If(String.IsNullOrEmpty(kv.Value), DBNull.Value, kv.Value))
                    Next
                    cmd.Parameters.Item("@odate").DbType = DbType.DateTime
                    cmd.Parameters.Item("@bdate").DbType = DbType.DateTime
                End With
                Dim id As Integer = 0
                If cmd.ExecuteNonQuery() > 0 Then
                    cmd.CommandText = "SELECT last_insert_id() FROM tblborrowheaders"
                    cmd.Parameters.Clear()
                    id = cmd.ExecuteScalar()
                    For Each item In copies
                        cmd.Parameters.Clear()
                        item.Add("@id", id)
                        cmd.CommandText = "INSERT INTO tblborrowedcopies (header_id, copy_id, borrowed_condition) VALUES (@id, @cid, (SELECT `condition` FROM tblbookcopies WHERE id = @cid LIMIT 1))"

                        With cmd.Parameters
                            For Each kv In item
                                .AddWithValue(kv.Key, If(String.IsNullOrEmpty(kv.Value), DBNull.Value, kv.Value))
                            Next
                        End With
                        cmd.ExecuteNonQuery()
                    Next
                    trans.Commit()
                End If
            End Using
            Return True
        Catch ex As Exception
            Logger.Logger(ex)
            trans.Rollback()
            Return False
        End Try
    End Function

    Public Function SearchBooksCopies(query As String) As DataTable
        Dim dt As New DataTable
        Try
            Using conn As New MySqlConnection(My.Settings.connection_string)
                conn.Open()
                Dim cmd As New MySqlCommand("SELECT bc.id, accession_no ,title FROM tblbookcopies bc JOIN tblbooks b ON bc.book_id = b.id LEFT JOIN tbldonators d ON bc.donator_id = d.id LEFT JOIN tblsuppliers s ON bc.supplier_id = s.id WHERE bc.status = 1 AND (isbn LIKE @query OR accession_no LIKE @query OR title LIKE @query) ORDER BY b.title, accession_no", conn)
                cmd.Parameters.AddWithValue("@query", "%" & query & "%")
                Dim adapter As New MySqlDataAdapter(cmd)
                adapter.Fill(dt)
                Return dt
            End Using
        Catch ex As Exception
            Return dt
        End Try
    End Function
End Module
