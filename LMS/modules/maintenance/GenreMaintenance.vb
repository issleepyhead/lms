Module GenreMaintenance

    Public PPrev As Integer = 1
    Public PMAX As Integer = 0


    Public Function Exists(params As Dictionary(Of String, String)) As Boolean
        If CInt(params.Item("@id")) > 0 Then
            Return CInt(ExecScalar("SELECT COUNT(*) FROM tblgenres WHERE LOWER(name) = LOWER(@name) AND id != @id", params)) > 0
        Else
            Return CInt(ExecScalar("SELECT COUNT(*) FROM tblgenres WHERE LOWER(name) = LOWER(@name)", params)) > 0
        End If
    End Function

    Public Function Add(params As Dictionary(Of String, String)) As Boolean
        Return ExecNonQuery("INSERT INTO tblgenres (name, description) VALUES (@name, @desc)", params) > 0
    End Function

    Public Function Fetch() As DataTable
        PMAX = ExecScalar("SELECT COUNT(*) FROM tblgenres")
        If PMAX Mod 30 <> 0 Then
            PMAX = (PMAX \ 30) + 1
        Else
            PMAX \= 30
        End If
        Return ExecFetch("SELECT name, description, id FROM tblgenres ORDER BY name ASC LIMIT @page, 30;", paginate:=PPrev - 1, isPaginate:=True)
    End Function

    Public Function Search(query As String) As DataTable
        Dim searchQuery As New Dictionary(Of String, String) From {
            {"@search", "%" & query & "%"}
        }
        PPrev = 1
        PMAX = ExecScalar("SELECT COUNT(*) FROM tblgenres WHERE name LIKE @search", searchQuery)
        If PMAX Mod 30 <> 0 Then
            PMAX = (PMAX \ 30) + 1
        Else
            PMAX \= 30
        End If
        Return ExecFetch("SELECT name, description, id FROM tblgenres WHERE name LIKE @search ORDER BY name ASC LIMIT @page, 30;", params:=searchQuery, paginate:=PPrev - 1, isPaginate:=True)
    End Function

    Public Function Update(params As Dictionary(Of String, String)) As Boolean
        Return CInt(ExecNonQuery("UPDATE tblgenres SET name = @name, description = @desc WHERE id = @id", params)) > 0
    End Function

    Public Function Delete(params As List(Of Dictionary(Of String, String))) As Boolean
        Return ExecNonQueryTrans("DELETE FROM tblgenres WHERE id = @id", params)
    End Function
End Module
