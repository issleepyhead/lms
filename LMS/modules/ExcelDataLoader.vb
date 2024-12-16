Imports MySql.Data.MySqlClient

Public Class ExcelDataLoader
    Private _transInstance As MySqlTransaction
    Private _conn As MySqlConnection
    Private _data As Dictionary(Of String, DataTable)

    Sub New()

    End Sub

    Sub New(path As String)

    End Sub

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
