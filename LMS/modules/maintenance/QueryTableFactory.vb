Module QueryTableFactory
    Public Function QueryTableFactory(type As QueryTableType) As MaintenanceQueries
        Select Case type

            Case QueryTableType.GENRE_QUERY_TABLE
                Return New MaintenanceQueries With {
                    .ADD_QUERY = "INSERT INTO tblgenres (name, description) VALUES (@name, @desc)",
                    .DELETE_QUERY = "DELETE FROM tblgenres WHERE id = @id",
                    .EXISTS_QUERY_WITH_ID = "SELECT COUNT(*) FROM tblgenres WHERE LOWER(name) = LOWER(@name) AND id != @id",
                    .EXISTS_QUERY_NO_ID = "SELECT COUNT(*) FROM tblgenres WHERE LOWER(name) = LOWER(@name)",
                    .FETCH_TOTAL_COUNT_QUERY = "SELECT COUNT(*) FROM tblgenres",
                    .FETCH_LIMIT_QUERY = "SELECT name, description, id FROM tblgenres ORDER BY name ASC LIMIT @page, 30;",
                    .FETCH_LIMIT_QUERY_SEARCH = "SELECT name, description, id FROM tblgenres WHERE name LIKE @search ORDER BY name ASC LIMIT @page, 30;",
                    .FETCH_TOTAL_COUNT_QUERY_SEARCH = "SELECT COUNT(*) FROM tblgenres WHERE name LIKE @search",
                    .UPDATE_QUERY = "UPDATE tblgenres SET name = @name, description = @desc WHERE id = @id"
                }

            Case QueryTableType.AUTHOR_QUERY_TABLE
                Return New MaintenanceQueries With {
                    .ADD_QUERY = "INSERT INTO tblauthors (first_name, last_name, gender) VALUES (@first_name, @last_name, @gender)",
                    .DELETE_QUERY = "DELETE FROM tblauthors WHERE id = @id",
                    .EXISTS_QUERY_WITH_ID = "SELECT COUNT(*) FROM tblauthors WHERE LOWER(first_name) = LOWER(@first_name) AND LOWER(last_name) = LOWER(@last_name) AND id != @id",
                    .EXISTS_QUERY_NO_ID = "SELECT COUNT(*) FROM tblauthors WHERE LOWER(first_name) = LOWER(@first_name) AND LOWER(last_name) = LOWER(@last_name)",
                    .FETCH_TOTAL_COUNT_QUERY = "SELECT COUNT(*) FROM tblauthors",
                    .FETCH_LIMIT_QUERY = "SELECT first_name, last_name, gender, id FROM tblauthors ORDER BY first_name ASC LIMIT @page, 30;",
                    .FETCH_LIMIT_QUERY_SEARCH = "SELECT first_name, last_name, gender, id FROM tblauthors WHERE first_name LIKE @search OR last_name LIKE @search ORDER BY first_name ASC LIMIT @page, 30;",
                    .FETCH_TOTAL_COUNT_QUERY_SEARCH = "SELECT COUNT(*) FROM tblauthors WHERE first_name LIKE @search OR last_name LIKE @search",
                    .UPDATE_QUERY = "UPDATE tblauthors SET first_name = @first_name, last_name = @last_name, gender = @gender WHERE id = @id"
                }
            Case QueryTableType.PUBLISHER_QUERY_TABLE
                Return New MaintenanceQueries With {
                    .ADD_QUERY = "INSERT INTO tblpublishers (publisher_name, address) VALUES (@name, @address)",
                    .DELETE_QUERY = "DELETE FROM tblpublishers WHERE id = @id",
                    .EXISTS_QUERY_WITH_ID = "SELECT COUNT(*) FROM tblpublishers WHERE LOWER(publisher_name) = LOWER(@name) AND LOWER(address) = LOWER(@address) AND id != @id",
                    .EXISTS_QUERY_NO_ID = "SELECT COUNT(*) FROM tblpublishers WHERE LOWER(publisher_name) = LOWER(@name) AND LOWER(address) = LOWER(@address)",
                    .FETCH_TOTAL_COUNT_QUERY = "SELECT COUNT(*) FROM tblpublishers",
                    .FETCH_LIMIT_QUERY = "SELECT id, publisher_name, address FROM tblpublishers ORDER BY publisher_name ASC LIMIT @page, 30;",
                    .FETCH_TOTAL_COUNT_QUERY_SEARCH = "SELECT COUNT(*) FROM tblpublishers WHERE publisher_name LIKE @search",
                    .FETCH_LIMIT_QUERY_SEARCH = "SELET id, publisher_name, address FROM tblpublishers WHEHRE publisher_name LIKE @search ORDER BY publisher_name ASC LIMIT @page, 30",
                    .UPDATE_QUERY = "UPDATE tblpublishers SET publisher_name = @name, address = @address WHERE id = @id"
                }
        End Select
        Return New MaintenanceQueries
    End Function
End Module
