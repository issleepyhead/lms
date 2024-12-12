Imports MySql.Data.MySqlClient
Module TransactionConnection
    Private Transaction As MySqlTransaction
    Private Connection As MySqlConnection

    Private Function GetConnection() As MySqlConnection
        Try
            If IsNothing(Connection) Then
                Connection = New MySqlConnection(My.Settings.connection_string)
            End If

            If Connection.State <> ConnectionState.Open Then
                Connection.Open()
            End If
        Catch ex As Exception
            Logger.Logger(ex)
        End Try
        Return Connection
    End Function

    Private Function GetTransaction() As MySqlTransaction
        Try
            If IsNothing(Transaction) Then
                Transaction = Connection.BeginTransaction
            End If
        Catch ex As Exception
            Logger.Logger(ex)
        End Try
        Return Transaction
    End Function

    ''' <summary>
    ''' Only for executing update, delete, and create.
    ''' </summary>
    ''' <param name="query">A sql query.</param>
    ''' <param name="params">A collection of dictionary.</param>
    Public Function ExecNonQueryTransaction(query As String, Optional params As Dictionary(Of String, String) = Nothing) As Integer
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
    Public Function ExecScalarTransaction(query As String, Optional params As Dictionary(Of String, String) = Nothing) As Object
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
        If Not IsNothing(Transaction) Then
            Transaction.Commit()
        End If
    End Sub

    Public Sub RollbackTransaction()
        If Not IsNothing(Transaction) Then
            Transaction.Rollback()
        End If
    End Sub
End Module
