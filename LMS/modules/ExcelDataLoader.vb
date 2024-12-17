Imports MySql.Data.MySqlClient
Imports Spire.Xls

Public Class ExcelDataLoader
    Private _transInstance As MySqlTransaction
    Private _conn As MySqlConnection
    Private _data As Dictionary(Of String, DataTable)
    Private _path As String

    Sub New(path As String)
        _path = path
    End Sub

    ''' <summary>
    ''' Checks if the excel file contains all the required sheet names for the excel file.
    ''' </summary>
    ''' <param name="path">A string path of the excel file.</param>
    ''' <returns>Boolean true of the excel file contains all the sheets names otherwise false.</returns>
    Private Function IsValidSheets(path) As Boolean
        Dim sheetNames As String() = {"Genres", "Authors", "Publishers", "Classifications", "Languages", "Books"}
        Using workbook As New Workbook
            workbook.LoadFromFile(path)

            Dim wsheetNames As New List(Of String)
            For Each wsheet As Worksheet In workbook.Worksheets
                wsheetNames.Add(wsheet.Name.ToLower)
            Next

            Return sheetNames.All(Function(x) wsheetNames.Contains(x.ToLower))
        End Using
    End Function

    ''' <summary>
    ''' Checks if the sheets of the excel file contains all the required columns.
    ''' </summary>
    ''' <param name="path">A string path of the excel file.</param>
    ''' <returns>Boolean true of the excel file contains all the columns otherwise false.</returns>
    Private Function IsFileValid(path) As Boolean
        Dim requiredColumns As New Dictionary(Of String, String()) From {
            {"Genres", {"Name", "Description"}},
            {"Authors", {"First Name", "Last Name", "Gender"}},
            {"Publishers", {"Publisher Name"}},
            {"Classifications", {"Dewey Decimal", "Classification"}},
            {"Languages", {"Language", "Code"}},
            {"Books", {"Title", "ISBN", "Genre", "Publisher", "Language", "Author", "Classification", "Book Cover", "Reserve Copy"}}
        }


        Using workbook As New Workbook
            workbook.LoadFromFile(path)


            ' Ensure all required sheets are present
            Dim filesheetNames = workbook.Worksheets.Select(Function(s) s.Name.ToLower).ToList()
            If Not requiredColumns.Keys.All(Function(x) filesheetNames.Contains(x.ToLower)) Then
                Return False
            End If



            Return True
        End Using
    End Function

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

    Public Async Function ReadData() As Task(Of Dictionary(Of String, DataTable))
        Dim data As New Dictionary(Of String, DataTable)
        Await Task.Run(
            Sub()
                Using workbook As New Workbook
                    workbook.LoadFromFile(_path)

                    For Each worksheet As Worksheet In workbook.Worksheets
                        Dim dt As DataTable = worksheet.ExportDataTable()
                        dt.Columns.Add("Status")
                        For Each drow As DataRow In dt.Rows
                            drow.Item("Status") = "Ready"
                        Next
                        data.Add(worksheet.Name, dt)
                    Next
                End Using
            End Sub)
        Return data
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
End Class
