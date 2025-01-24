Imports LMS.QueryType
Module QueryTableRegistry
    Public Registry As New Dictionary(Of QueryType, QueryTable) From {
        {GENRE, New QueryTable With {
            .ADD_QUERY = "INSERT INTO tblgenres (name, description) VALUES (@name, @desc)",
            .DELETE_QUERY = "DELETE FROM tblgenres WHERE id = @id",
            .EXISTS_ADD_QUERY = "SELECT COUNT(*) FROM tblgenres WHERE LOWER(name) = LOWER(@name)",
            .EXISTS_UPDATE_QUERY = "SELECT COUNT(*) FROM tblgenres WHERE LOWER(name) = LOWER(@name) AND id != @id",
            .SEARCH_COUNT_QUERY = "SELECT COUNT(*) FROM tblgenres WHERE name LIKE @search",
            .SEARCH_RESULT_QUERY = "SELECT name, description, id FROM tblgenres WHERE name LIKE @search ORDER BY name ASC LIMIT @page, 30;",
            .FETCH_ALL_QUERY = "UPDATE tblgenres SET name = @name, description = @desc WHERE id = @id",
            .UPDATE_QUERY = "SELECT name, description, id FROM tblgenres ORDER BY name ASC"
        }}
    }

    Public Function CreateQueryTable(type As QueryType) As QueryTable
        Return Registry.Item(type)
    End Function
End Module
