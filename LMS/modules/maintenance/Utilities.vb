
Imports MySql.Data.MySqlClient

Module Utilities
    Public Function GenerateAccession() As String
        Dim highestAccession As Integer = ExecScalar("SELECT CAST(accession_no AS SIGNED) accession FROM tblbookcopies ORDER BY accession_no DESC LIMIT 1")
        If highestAccession = 0 Then
            highestAccession += 1
        End If
        Return highestAccession.ToString().PadLeft(10, "0")
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

End Module
