Imports MySql.Data.MySqlClient

Module Connection
    Private Connection As MySqlConnection = Nothing
    Private ReadOnly str As String = $"Server={My.Settings.server_name};User={My.Settings.server_username};Database={My.Settings.server_database};Port={My.Settings.server_port};Password={My.Settings.server_password};"
    Private Const MAX_PAGINATION As Integer = 30

    Public Function GetConnectionInstance() As MySqlConnection
        Try
            ' Check if there's already a connection
            If IsNothing(Connection) Then
                Connection = New MySqlConnection(My.Settings.connection_string)
            End If

            ' Open the connection
            If Not IsNothing(Connection) AndAlso Connection.State <> ConnectionState.Open Then
                Connection.Open()
            End If

        Catch ex As Exception
            Connection = Nothing
            Logger.Logger(ex)
        End Try
        Return Connection
    End Function

    Public Function TestConnectionString() As String
        Try
            Using conn As New MySqlConnection(str)
                conn.Open()
            End Using
            Return str
        Catch ex As Exception
            Logger.Logger(ex)
            Return ""
        End Try
    End Function

    ''' <summary>
    ''' Only for executing update, delete, and create.
    ''' </summary>
    ''' <param name="query">A sql query.</param>
    ''' <param name="params">A collection of dictionary.</param>
    Public Function ExecNonQuery(query As String, Optional params As Dictionary(Of String, String) = Nothing) As Integer
        Dim res As Integer = 0
        Try

            Using cmd As New MySqlCommand(query, GetConnectionInstance())
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

    Public Function ExecNonQueryTrans(query As String, Optional params As List(Of Dictionary(Of String, String)) = Nothing) As Boolean
        Dim trans As MySqlTransaction = Nothing
        Try
            GetConnectionInstance()
            If Not IsNothing(Connection) AndAlso IsNothing(trans) Then
                trans = Connection.BeginTransaction
            Else
                Return False
            End If

            Using cmd As New MySqlCommand(query, Connection, trans)
                If Not IsNothing(params) Then
                    For Each param As Dictionary(Of String, String) In params
                        cmd.Parameters.Clear()
                        With cmd.Parameters
                            For Each kv As KeyValuePair(Of String, String) In param
                                .AddWithValue(kv.Key, If(String.IsNullOrEmpty(kv.Value), DBNull.Value, kv.Value))
                            Next
                        End With
                        cmd.ExecuteNonQuery()
                    Next
                End If
            End Using
            trans.Commit()
            Return True
        Catch ex As Exception
            trans.Rollback()
        End Try
        Return False
    End Function

    Public Function ExecProcedure(query As String, Optional params As Dictionary(Of String, String) = Nothing) As Boolean
        Dim res As Integer = 0
        Try

            Using cmd As New MySqlCommand(query, GetConnectionInstance())
                If Not IsNothing(params) Then
                    For Each item In params
                        With cmd.Parameters
                            .AddWithValue(item.Key, If(String.IsNullOrEmpty(item.Value), DBNull.Value, item.Value))
                        End With
                    Next
                End If
                cmd.CommandType = CommandType.StoredProcedure
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
    Public Function ExecScalar(query As String, Optional params As Dictionary(Of String, String) = Nothing) As Object
        Try
            Using cmd As New MySqlCommand(query, GetConnectionInstance)
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

    Public Function ExecFetch(query As String, Optional params As Dictionary(Of String, String) = Nothing, Optional paginate As Integer = 0, Optional isPaginate As Boolean = False) As DataTable
        Dim dt As New DataTable
        Try
            Using cmd As New MySqlCommand(query, GetConnectionInstance)
                If Not IsNothing(params) Then
                    For Each item In params
                        With cmd.Parameters
                            .AddWithValue(item.Key, If(String.IsNullOrEmpty(item.Value), DBNull.Value, item.Value))
                        End With
                    Next
                End If

                If isPaginate Then
                    cmd.Parameters.AddWithValue("@page", If(paginate < 0, 0, paginate) * MAX_PAGINATION)
                End If
                Dim adapter As New MySqlDataAdapter(cmd)
                adapter.Fill(dt)
                Return dt
            End Using
        Catch ex As Exception
            Logger.Logger(ex)
        End Try
        Return dt
    End Function
End Module
