Imports LMS.QueryType

Module DBOperations
    Private QueryType As QueryType
    Private QueryTable As QueryTable

    Public PREV_PAGE_NUMBER As Integer = 1
    Public NEXT_PAGE_NUMBER As Integer = 0
    Public QUERY_SEARCH As String = String.Empty

    ' For advance search
    Public ADVANCE_SEARCH_QUERIES As Dictionary(Of String, String)


    Private Sub SetQueryType(type As QueryType)
        ' The previous query executed no longer match the new query to be executed
        ' Reset the PREV_PAGE_NUMBER and NEXT_PAGE_NUMBER because we are no longer in the same tab.
        If QueryType <> type Then
            QueryType = type
            QUERY_SEARCH = String.Empty
            PREV_PAGE_NUMBER = 1
        End If
        QueryTable = QueryTableRegistry.CreateQueryTable(type)
    End Sub

    Public Function Exists(type As QueryType, params As Dictionary(Of String, String)) As Boolean
        SetQueryType(type)
        Try
            If CInt(params.Item("@id")) > 0 Then
                Return CInt(ExecScalar(QueryTable.EXISTS_UPDATE_QUERY, params)) > 0
            Else
                Return CInt(ExecScalar(QueryTable.EXISTS_ADD_QUERY, params)) > 0
            End If
        Catch ex As Exception
            Logger.Logger(ex)
            Return False
        End Try
    End Function

    Public Function Add(type As QueryType, params As Dictionary(Of String, String)) As Boolean
        SetQueryType(type)
        Return ExecNonQuery(QueryTable.ADD_QUERY, params) > 0
    End Function

    Public Function FetchAll(type As QueryType, Optional params As Dictionary(Of String, String) = Nothing) As DataTable
        SetQueryType(type)
        Return ExecFetch(QueryTable.FETCH_ALL_QUERY, params)
    End Function

    Public Function Search(type As QueryType) As DataTable
        SetQueryType(type)
        Dim searchQuery As New Dictionary(Of String, String) From {
            {"@search", "%" & QUERY_SEARCH & "%"}
        }

        If Not IsNothing(ADVANCE_SEARCH_QUERIES) Then
            ' Add the advance queries to search queries then clear it so the next call we will check the query again.
            For Each kv As KeyValuePair(Of String, String) In ADVANCE_SEARCH_QUERIES
                searchQuery.Add(kv.Key, If(String.IsNullOrEmpty(kv.Value), DBNull.Value, kv.Value))
            Next
            ADVANCE_SEARCH_QUERIES = Nothing
        End If

        NEXT_PAGE_NUMBER = ExecScalar(QueryTable.SEARCH_COUNT_QUERY, searchQuery)
        If NEXT_PAGE_NUMBER Mod 30 <> 0 Then
            NEXT_PAGE_NUMBER = (NEXT_PAGE_NUMBER \ 30) + 1
        Else
            NEXT_PAGE_NUMBER \= 30
        End If
        Return ExecFetch(QueryTable.SEARCH_RESULT_QUERY, params:=searchQuery, paginate:=PREV_PAGE_NUMBER - 1, isPaginate:=True)
    End Function

    Public Function AdvanceSearch(type As QueryType) As DataTable
        SetQueryType(type)
        Dim searchQuery As New Dictionary(Of String, String) From {
            {"@search", "%" & QUERY_SEARCH & "%"}
        }

        If Not IsNothing(ADVANCE_SEARCH_QUERIES) Then
            ' Collect the advance queries to search queries then clear it so the next call we will check the query again.
            For Each kv As KeyValuePair(Of String, String) In ADVANCE_SEARCH_QUERIES
                searchQuery.Add(kv.Key, If(String.IsNullOrEmpty(kv.Value), DBNull.Value, kv.Value))
            Next
            ADVANCE_SEARCH_QUERIES = Nothing
        End If

        NEXT_PAGE_NUMBER = ExecScalar(QueryTable.ADVANCE_SEARCH_COUNT_QUERY, searchQuery)
        If NEXT_PAGE_NUMBER Mod 30 <> 0 Then
            NEXT_PAGE_NUMBER = (NEXT_PAGE_NUMBER \ 30) + 1
        Else
            NEXT_PAGE_NUMBER \= 30
        End If
        Return ExecFetch(QueryTable.ADVANCE_SEARCH_RESULT_QUERY, params:=searchQuery, paginate:=PREV_PAGE_NUMBER - 1, isPaginate:=True)
    End Function

    Public Function Update(type As QueryType, params As Dictionary(Of String, String)) As Boolean
        SetQueryType(type)
        Return CInt(ExecNonQuery(QueryTable.UPDATE_QUERY, params)) > 0
    End Function

    Public Function Delete(type As QueryType, params As List(Of Dictionary(Of String, String))) As Boolean
        SetQueryType(type)
        Return ExecNonQueryTrans(QueryTable.DELETE_QUERY, params)
    End Function

    Public Function SearchArchive(type As QueryType) As DataTable
        SetQueryType(type)
        Dim searchQuery As New Dictionary(Of String, String) From {
            {"@search", "%" & QUERY_SEARCH & "%"}
        }
        NEXT_PAGE_NUMBER = ExecScalar(QueryTable.ARCHIVE_SEARCH_COUNT_QUERY, searchQuery)
        If NEXT_PAGE_NUMBER Mod 30 <> 0 Then
            NEXT_PAGE_NUMBER = (NEXT_PAGE_NUMBER \ 30) + 1
        Else
            NEXT_PAGE_NUMBER \= 30
        End If
        Return ExecFetch(QueryTable.ARCHIVE_SEARCH_RESULT_QUERY, params:=searchQuery, paginate:=PREV_PAGE_NUMBER - 1, isPaginate:=True)
    End Function
End Module
