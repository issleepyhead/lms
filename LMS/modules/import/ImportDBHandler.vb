Imports MySql.Data.MySqlClient

Public Class ImportDBHandler
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

    ''' <summary>
    ''' Check if the data is existing.
    ''' </summary>
    ''' <param name="query"></param>
    ''' <param name="params"></param>
    ''' <returns></returns>
    Public Function ExistsData(query As MaintenanceQueries, params As Dictionary(Of String, String)) As Boolean
        Return CInt(Me.ExecScalar(query.EXISTS_QUERY_NO_ID, params)) > 0
    End Function

    ''' <summary>
    ''' Adds the data to the datatabase.
    ''' </summary>
    ''' <param name="query"></param>
    ''' <param name="params"></param>
    ''' <returns></returns>
    Public Function AddData(query As MaintenanceQueries, params As Dictionary(Of String, String)) As Boolean
        Return Me.ExecNonQuery(query.ADD_QUERY, params) > 0
    End Function

    ''' <summary>
    ''' Updates the data in the database if it exists.
    ''' </summary>
    ''' <param name="query"></param>
    ''' <param name="params"></param>
    ''' <returns></returns>
    Public Function UpdateData(query As MaintenanceQueries, params As Dictionary(Of String, String)) As Boolean
        Return Me.ExecNonQuery(query.ADD_QUERY, params) > 0
    End Function

    ''' <summary>
    ''' Commit the transaction.
    ''' </summary>
    Public Sub CommitTransaction()
        If Not IsNothing(_transInstance) Then
            _transInstance.Commit()
            _transInstance.Dispose()
            _conn.Dispose()
        End If
    End Sub

    ''' <summary>
    ''' Rollback if the transaction.
    ''' </summary>
    Public Sub RollbackTransaction()
        If Not IsNothing(_transInstance) Then
            _transInstance.Rollback()
            _transInstance.Dispose()
            _conn.Dispose()
        End If
    End Sub
End Class
