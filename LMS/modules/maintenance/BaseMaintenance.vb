Imports LMS.QueryTableType
Module BaseMaintenance
    Private QueryTable As MaintenanceQueries
    Private QueryType As QueryTableType
    Public PPrev As Integer = 1
    Public PMAX As Integer = 0

    Public Sub SetQueryTable(query_type As QueryTableType)
        ' The previous query executed no longer match the new query to be executed
        ' Reset the PPREV and PMAX because we are no longer in the same tab.
        If QueryType <> query_type Then
            PPrev = 1
            QueryType = query_type
        End If
        QueryTable = QueryTableFactory.QueryTableFactory(query_type)
    End Sub

    Private Function _Exists(params As Dictionary(Of String, String)) As Boolean
        If CInt(params.Item("@id")) > 0 Then
            Return CInt(ExecScalar(QueryTable.EXISTS_QUERY_WITH_ID, params)) > 0
        Else
            Return CInt(ExecScalar(QueryTable.EXISTS_QUERY_WITH_ID, params)) > 0
        End If
    End Function

    Public Function Exists(type As QueryTableType, param As Dictionary(Of String, String)) As Boolean
        SetQueryTable(type)
        Return _Exists(param)
    End Function
    Private Function _Add(params As Dictionary(Of String, String)) As Boolean
        Return ExecNonQuery(QueryTable.ADD_QUERY, params) > 0
    End Function

    Public Function Add(type As QueryTableType, param As Dictionary(Of String, String)) As Boolean
        SetQueryTable(type)
        Return _Add(param)
    End Function

    Private Function _Fetch() As DataTable
        PMAX = ExecScalar(QueryTable.FETCH_TOTAL_COUNT_QUERY)
        If PMAX Mod 30 <> 0 Then
            PMAX = (PMAX \ 30) + 1
        Else
            PMAX \= 30
        End If
        Return ExecFetch(QueryTable.FETCH_LIMIT_QUERY, paginate:=PPrev - 1, isPaginate:=True)
    End Function

    Public Function Fetch(type As QueryTableType) As DataTable
        SetQueryTable(type)
        Return _Fetch()
    End Function

    Private Function _Search(query As String) As DataTable
        Dim searchQuery As New Dictionary(Of String, String) From {
            {"@search", "%" & query & "%"}
        }
        PPrev = 1
        PMAX = ExecScalar(QueryTable.FETCH_TOTAL_COUNT_QUERY_SEARCH, searchQuery)
        If PMAX Mod 30 <> 0 Then
            PMAX = (PMAX \ 30) + 1
        Else
            PMAX \= 30
        End If
        Return ExecFetch(QueryTable.FETCH_LIMIT_QUERY_SEARCH, params:=searchQuery, paginate:=PPrev - 1, isPaginate:=True)
    End Function

    Public Function Search(type As QueryTableType, query As String) As DataTable
        SetQueryTable(type)
        Return _Search(query)
    End Function

    Private Function _Update(params As Dictionary(Of String, String)) As Boolean
        Return CInt(ExecNonQuery(QueryTable.UPDATE_QUERY, params)) > 0
    End Function

    Public Function Update(type As QueryTableType, params As Dictionary(Of String, String)) As Boolean
        SetQueryTable(type)
        Return _Update(params)
    End Function

    Private Function _Delete(params As List(Of Dictionary(Of String, String))) As Boolean
        Return ExecNonQueryTrans(QueryTable.DELETE_QUERY, params)
    End Function

    Public Function Delete(type As QueryTableType, params As List(Of Dictionary(Of String, String))) As Boolean
        SetQueryTable(type)
        Return _Delete(params)
    End Function

    Private Function _FetchAll(type As QueryTableType, Optional params As Dictionary(Of String, String) = Nothing) As DataTable
        Return ExecFetch(QueryTable.FETCH_ALL_QUERY, params)
    End Function

    Public Function FetchAll(type As QueryTableType, Optional params As Dictionary(Of String, String) = Nothing) As DataTable
        SetQueryTable(type)
        Return _FetchAll(type, params)
    End Function
End Module
