Imports MySql.Data.MySqlClient
Imports Spire.Xls
Imports LMS.QueryTableType
Public Class ExcelDataLoader
    Private _transInstance As MySqlTransaction
    Private _conn As MySqlConnection
    Private _data As Dictionary(Of String, DataTable)

    ''' <summary>
    ''' Gets the connection instance.
    ''' </summary>
    ''' <returns>A MySqlConnection instance.</returns>
    Private Function GetConnection() As MySqlConnection
        Try
            If IsNothing(_conn) Then
                _conn = New MySqlConnection(My.Settings.connection_string)
            End If

            If _conn.State <> ConnectionState.Open Then
                _conn.Open()
            End If
        Catch ex As Exception
            Logger.Logger(ex)
        End Try
        Return _conn
    End Function

    ''' <summary>
    ''' Gets a MySqlTransaction instance.
    ''' </summary>
    ''' <returns>A MySqlTransaction instance.</returns>
    Private Function GetTransaction() As MySqlTransaction
        Try
            If IsNothing(_transInstance) Then
                _transInstance = _conn.BeginTransaction
            End If
        Catch ex As Exception
            Logger.Logger(ex)
        End Try
        Return _transInstance
    End Function

    ''' <summary>
    ''' Only for executing update, delete, and create.
    ''' </summary>
    ''' <param name="query">A sql query.</param>
    ''' <param name="params">A collection of dictionary.</param>
    Private Function ExecNonQuery(query As String, Optional params As Dictionary(Of String, String) = Nothing) As Integer
        Dim res As Integer = 0
        Try

            Using cmd As New MySqlCommand(query, GetConnection(), GetTransaction())
                If Not IsNothing(params) Then
                    For Each item In params
                        With cmd.Parameters
                            .AddWithValue(item.Key, If(String.IsNullOrEmpty(item.Value), DBNull.Value, item.Value))
                        End With
                    Next
                End If
                res = cmd.ExecuteNonQuery()
                If res = 0 Then
                    Throw New Exception("Parang nothing happens lang ah?")
                End If
            End Using
        Catch ex As Exception
            Logger.Logger(ex)
        End Try
        Return res
    End Function


    ''' <summary>
    ''' Only for executing scalar queries.
    ''' </summary>
    ''' <param name="query">A sql query.</param>
    ''' <param name="params">A sql query.</param>
    ''' <returns>An object of the result of the query.</returns>
    Private Function ExecScalar(query As String, Optional params As Dictionary(Of String, String) = Nothing) As Object
        Try
            Using cmd As New MySqlCommand(query, GetConnection, GetTransaction)
                If Not IsNothing(params) Then
                    For Each item In params
                        With cmd.Parameters
                            .AddWithValue(item.Key, If(String.IsNullOrEmpty(item.Value), DBNull.Value, item.Value))
                        End With
                    Next
                End If
                Return cmd.ExecuteScalar
            End Using
        Catch ex As Exception
            Logger.Logger(ex)
            Return 0
        End Try
    End Function

    Private Function _ExistsTransaction(query As MaintenanceQueries, params As Dictionary(Of String, String)) As Boolean
        Return CInt(Me.ExecScalar(query.EXISTS_QUERY_NO_ID, params)) > 0
    End Function

    Private Function _AddTransaction(query As MaintenanceQueries, params As Dictionary(Of String, String)) As Boolean
        Return Me.ExecNonQuery(query.ADD_QUERY, params) > 0
    End Function

    Public Function DataFactory(type As QueryTableType, drow As DataRow) As Dictionary(Of String, String)
        Dim typeField = GetType(QueryTableType).GetField(type.ToString())
        Dim sheetAttrib As SheetNameMapping = CType(Attribute.GetCustomAttribute(typeField, GetType(SheetNameMapping)), SheetNameMapping)
        Dim colAttrib As ColumnMapping = CType(Attribute.GetCustomAttribute(typeField, GetType(ColumnMapping)), ColumnMapping)
        Dim tempt As New Dictionary(Of String, String)

        Select Case type
            Case GENRE_QUERY_TABLE, AUTHOR_QUERY_TABLE, PUBLISHER_QUERY_TABLE, LANGUAGES_QUERY_TABLE, CLASSIFICATION_QUERY_TABLE

                For i As Integer = 0 To colAttrib.Columns.Length - 1
                    tempt.Add(colAttrib.Names(i), drow.Item(colAttrib.Columns(i)))
                Next
                Return tempt
            Case BOOK_QUERY_TABLE
                For i As Integer = 0 To colAttrib.Columns.Length - 1
                    tempt.Add(colAttrib.Names(i), drow.Item(colAttrib.Columns(i)))
                Next

                Dim ids As String() = {"@gid", "@pid", "@lid", "@cid", "@aid"}

                Dim genid As Integer = ExecScalar("SELECT id FROM tblgenres WHERE name = @name", New Dictionary(Of String, String) From {{"@name", drow.Item("Genre")}})
                Dim pid As Integer = ExecScalar("SELECT id FROM tblpublishers WHERE LOWER(publisher_name) = LOWER(@name)", New Dictionary(Of String, String) From {{"@name", drow.Item("Publisher")}})
                Dim lid As Integer = ExecScalar("SELECT id FROM tbllanguages WHERE language = @name", New Dictionary(Of String, String) From {{"@name", drow.Item("Language")}})
                Dim cid As Integer = ExecScalar("SELECT id FROM tblclassifications WHERE classification = @name", New Dictionary(Of String, String) From {{"@name", drow.Item("Classification")}})
                Dim aid As Integer = ExecScalar("SELECT id FROM tblauthors WHERE CONCAT(first_name, ' ', last_name) = @name", New Dictionary(Of String, String) From {{"@name", drow.Item("Author")}})

                'data.Add("@title", drow.Item("Title"))
                'data.Add("@isbn", drow.Item("ISBN"))
                'data.Add("@gid", genid.ToString)
                'data.Add("@pid", pid.ToString)
                'data.Add("@lid", lid)
                'data.Add("@cid", cid)
                'data.Add("@aid", aid)
                'data.Add("@rcopy", drow.Item("Reserve Copy"))
                'data.Add("@cover", drow.Item("Book Cover"))
                'data.Add("@fpenalty", 0)
                'data.Add("@spenalty", 0)
                Return tempt
        End Select
    End Function

    Public Sub CommitTransaction()
        If Not IsNothing(_transInstance) Then
            _transInstance.Commit()
            _transInstance.Dispose()
            _conn.Dispose()
        End If
    End Sub

    Public Sub RollbackTransaction()
        If Not IsNothing(_transInstance) Then
            _transInstance.Rollback()
            _transInstance.Dispose()
            _conn.Dispose()
        End If
    End Sub


    ''' <summary>
    ''' Checks if the file is valid.
    ''' </summary>
    ''' <param name="path">A string path of the excel file.</param>
    ''' <returns>Boolean true of the excel file contains all the columns otherwise false.</returns>
    Public Shared Function IsFileValid(path As String) As Boolean
        If String.IsNullOrEmpty(path) OrElse Not path.EndsWith(".xlsx") Then
            Return False
        End If

        Dim requiredFields As QueryTableType() = {GENRE_QUERY_TABLE, AUTHOR_QUERY_TABLE, PUBLISHER_QUERY_TABLE, CLASSIFICATION_QUERY_TABLE, LANGUAGES_QUERY_TABLE, BOOK_QUERY_TABLE}

        Using workbook As New Workbook
            Try
                workbook.LoadFromFile(path)

                Dim sheetNames As New List(Of String)
                For Each wsheet As Worksheet In workbook.Worksheets
                    sheetNames.Add(wsheet.Name.ToLower)
                Next

                Return requiredFields.All(Function(type)
                                              Dim typeField = GetType(QueryTableType).GetField(type.ToString())
                                              Dim sheetAttrib As SheetNameMapping = CType(Attribute.GetCustomAttribute(typeField, GetType(SheetNameMapping)), SheetNameMapping)
                                              Dim colAttrib As ColumnMapping = CType(Attribute.GetCustomAttribute(typeField, GetType(ColumnMapping)), ColumnMapping)

                                              If sheetNames.Contains(sheetAttrib.SheetName) Then
                                                  Dim dt As DataTable = workbook.Worksheets(sheetAttrib.SheetName).ExportDataTable
                                                  Return colAttrib.Columns.All(Function(x) dt.Columns.Contains(x))
                                              Else
                                                  Return False
                                              End If
                                          End Function)
            Catch ex As Exception
                Logger.Logger(ex)
            End Try
            Return True
        End Using
    End Function

    ''' <summary>
    ''' Loads all the data from the excel file.
    ''' </summary>
    ''' <param name="path">A file path of the excel file.</param>
    ''' <returns>A dictionary containing all the data of the excel</returns>
    Public Shared Async Function ReadData(path As String) As Task(Of Dictionary(Of String, DataTable))
        Dim data As New Dictionary(Of String, DataTable)
        Await Task.Run(Sub()
                           Using workbook As New Workbook
                               Try
                                   workbook.LoadFromFile(path)

                                   For Each worksheet As Worksheet In workbook.Worksheets
                                       Dim dt As DataTable = worksheet.ExportDataTable()
                                       dt.Columns.Add("Status")
                                       For Each drow As DataRow In dt.Rows
                                           drow.Item("Status") = "Ready"
                                       Next
                                       data.Add(worksheet.Name, dt)
                                   Next
                               Catch ex As Exception
                                   Logger.Logger(ex)
                               End Try
                           End Using
                       End Sub)
        Return data
    End Function
End Class
