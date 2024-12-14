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
                    .UPDATE_QUERY = "UPDATE tblgenres SET name = @name, description = @desc WHERE id = @id",
                    .FETCH_ALL_QUERY = "SELECT name, description, id FROM tblgenres ORDER BY name ASC"
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
                    .UPDATE_QUERY = "UPDATE tblauthors SET first_name = @first_name, last_name = @last_name, gender = @gender WHERE id = @id",
                    .FETCH_ALL_QUERY = "SELECT id, CONCAT(first_name, ' ', last_name) AS name FROM tblauthors ORDER BY first_name ASC"
                }

            Case QueryTableType.PUBLISHER_QUERY_TABLE
                Return New MaintenanceQueries With {
                    .ADD_QUERY = "INSERT INTO tblpublishers (publisher_name) VALUES (@name)",
                    .DELETE_QUERY = "DELETE FROM tblpublishers WHERE id = @id",
                    .EXISTS_QUERY_WITH_ID = "SELECT COUNT(*) FROM tblpublishers WHERE LOWER(publisher_name) = LOWER(@name) AND id != @id",
                    .EXISTS_QUERY_NO_ID = "SELECT COUNT(*) FROM tblpublishers WHERE LOWER(publisher_name) = LOWER(@name)",
                    .FETCH_TOTAL_COUNT_QUERY = "SELECT COUNT(*) FROM tblpublishers",
                    .FETCH_LIMIT_QUERY = "SELECT id, publisher_name FROM tblpublishers ORDER BY publisher_name ASC LIMIT @page, 30;",
                    .FETCH_TOTAL_COUNT_QUERY_SEARCH = "SELECT COUNT(*) FROM tblpublishers WHERE publisher_name LIKE @search",
                    .FETCH_LIMIT_QUERY_SEARCH = "SELECT id, publisher_name FROM tblpublishers WHERE publisher_name LIKE @search ORDER BY publisher_name ASC LIMIT @page, 30",
                    .UPDATE_QUERY = "UPDATE tblpublishers SET publisher_name = @name WHERE id = @id",
                    .FETCH_ALL_QUERY = "SELECT id, publisher_name FROM tblpublishers ORDER BY publisher_name ASC"
                }

            Case QueryTableType.CLASSIFICATION_QUERY_TABLE
                Return New MaintenanceQueries With {
                    .ADD_QUERY = "INSERT INTO tblclassifications (dewey_decimal, classification) VALUES (@dewey_no, @classification)",
                    .DELETE_QUERY = "DELETE FROM tblclassifications WHERE id = @id",
                    .EXISTS_QUERY_WITH_ID = "SELECT COUNT(*) FROM tblclassifications WHERE (LOWER(classification) = LOWER(@classification) OR LOWER(dewey_decimal) = LOWER(@dewey_no)) AND id != @id",
                    .EXISTS_QUERY_NO_ID = "SELECT COUNT(*) FROM tblclassifications WHERE LOWER(classification) = LOWER(@classification) AND LOWER(dewey_decimal) = LOWER(@dewey_no)",
                    .FETCH_TOTAL_COUNT_QUERY = "SELECT COUNT(*) FROM tblclassifications",
                    .FETCH_LIMIT_QUERY = "SELECT id, classification, dewey_decimal FROM tblclassifications ORDER BY dewey_decimal ASC LIMIT @page, 30;",
                    .FETCH_TOTAL_COUNT_QUERY_SEARCH = "SELECT COUNT(*) FROM tblclassifications WHERE dewey_decimal LIKE @search OR classification LIKE @search",
                    .FETCH_LIMIT_QUERY_SEARCH = "SELECT id, classification, dewey_decimal FROM tblclassifications WHERE dewey_decimal LIKE @search OR classification LIKE @search ORDER BY dewey_decimal ASC LIMIT @page, 30",
                    .UPDATE_QUERY = "UPDATE tblclassifications SET classification = @classification, dewey_decimal = @dewey_no WHERE id = @id",
                    .FETCH_ALL_QUERY = "SELECT id, classification FROM tblclassifications ORDER BY classification ASC"
                }
            Case QueryTableType.DONATOR_QUERY_TABLE
                Return New MaintenanceQueries With {
                    .ADD_QUERY = "INSERT INTO tbldonators (name, address) VALUES (@name, @address)",
                    .DELETE_QUERY = "DELETE FROM tbldonators WHERE id = @id",
                    .EXISTS_QUERY_WITH_ID = "SELECT COUNT(*) FROM tbldonators WHERE LOWER(name) = LOWER(@name) AND LOWER(address) = LOWER(@address) AND id != @id",
                    .EXISTS_QUERY_NO_ID = "SELECT COUNT(*) FROM tbldonators WHERE LOWER(name) = LOWER(@name) AND LOWER(address) = LOWER(@address)",
                    .FETCH_TOTAL_COUNT_QUERY = "SELECT COUNT(*) FROM tbldonators",
                    .FETCH_LIMIT_QUERY = "SELECT id, name, address FROM tbldonators ORDER BY name ASC LIMIT @page, 30;",
                    .FETCH_TOTAL_COUNT_QUERY_SEARCH = "SELECT COUNT(*) FROM tbldonators WHERE name LIKE @search",
                    .FETCH_LIMIT_QUERY_SEARCH = "SELECT id, name, address FROM tbldonators WHERE name LIKE @search ORDER BY name ASC LIMIT @page, 30",
                    .UPDATE_QUERY = "UPDATE tbldonators SET name = @name, address = @address WHERE id = @id",
                    .FETCH_ALL_QUERY = "SELECT id, name, address FROM tbldonators ORDER BY name ASC"
                }
            Case QueryTableType.SUPPLIER_QUERY_TABLE
                Return New MaintenanceQueries With {
                    .ADD_QUERY = "INSERT INTO tblsuppliers (name, address) VALUES (@name, @address)",
                    .DELETE_QUERY = "DELETE FROM tblsuppliers WHERE id = @id",
                    .EXISTS_QUERY_WITH_ID = "SELECT COUNT(*) FROM tblsuppliers WHERE LOWER(name) = LOWER(@name) OR LOWER(address) = LOWER(@address) AND id != @id",
                    .EXISTS_QUERY_NO_ID = "SELECT COUNT(*) FROM tblsuppliers WHERE LOWER(name) = LOWER(@name) AND LOWER(address) = LOWER(@address)",
                    .FETCH_TOTAL_COUNT_QUERY = "SELECT COUNT(*) FROM tblsuppliers",
                    .FETCH_LIMIT_QUERY = "SELECT id, name, address FROM tblsuppliers ORDER BY name ASC LIMIT @page, 30;",
                    .FETCH_TOTAL_COUNT_QUERY_SEARCH = "SELECT COUNT(*) FROM tblsuppliers WHERE name LIKE @search",
                    .FETCH_LIMIT_QUERY_SEARCH = "SELECT id, name, address FROM tblsuppliers WHERE name LIKE @search ORDER BY name ASC LIMIT @page, 30",
                    .UPDATE_QUERY = "UPDATE tblsuppliers SET name = @name, address = @address WHERE id = @id",
                    .FETCH_ALL_QUERY = "SELECT id, name, address FROM tblsuppliers ORDER BY name ASC"
                }
            Case QueryTableType.DEPARTMENT_QUERY_TABLE
                Return New MaintenanceQueries With {
                    .ADD_QUERY = "INSERT INTO tbldepartments (department_name) VALUES (@name)",
                    .DELETE_QUERY = "DELETE FROM tbldepartments WHERE id = @id",
                    .EXISTS_QUERY_WITH_ID = "SELECT COUNT(*) FROM tbldepartments WHERE LOWER(department_name) = LOWER(@name) AND id != @id",
                    .EXISTS_QUERY_NO_ID = "SELECT COUNT(*) FROM tbldepartments WHERE LOWER(department_name) = LOWER(@name)",
                    .FETCH_TOTAL_COUNT_QUERY = "SELECT COUNT(*) FROM tbldepartments",
                    .FETCH_LIMIT_QUERY = "SELECT id, department_name FROM tbldepartments ORDER BY department_name ASC LIMIT @page, 30;",
                    .FETCH_TOTAL_COUNT_QUERY_SEARCH = "SELECT COUNT(*) FROM tbldepartments WHERE department_name LIKE @search",
                    .FETCH_LIMIT_QUERY_SEARCH = "SELECT id, department_name FROM tbldepartments WHERE department_name LIKE @search ORDER BY department_name ASC LIMIT @page, 30",
                    .UPDATE_QUERY = "UPDATE tbldepartments SET department_name = @name WHERE id = @id",
                    .FETCH_ALL_QUERY = "SELECT id, department_name FROM tbldepartments ORDER BY department_name"
                }
            Case QueryTableType.SECTION_QUERY_TABLE
                Return New MaintenanceQueries With {
                    .ADD_QUERY = "INSERT INTO tblsections (name, year_id) VALUES (@name, @yid)",
                    .DELETE_QUERY = "DELETE FROM tblsections WHERE id = @id",
                    .EXISTS_QUERY_WITH_ID = "SELECT COUNT(*) FROM tblsections WHERE LOWER(name) = LOWER(@name) AND id != @id",
                    .EXISTS_QUERY_NO_ID = "SELECT COUNT(*) FROM tblsections WHERE LOWER(name) = LOWER(@name)",
                    .FETCH_TOTAL_COUNT_QUERY = "SELECT COUNT(*) FROM tblsections",
                    .FETCH_LIMIT_QUERY = "SELECT s.id, s.name, s.year_id, y.year_level, y.department_id FROM tblsections s JOIN tblyearlevels y ON s.year_id = y.id ORDER BY name ASC LIMIT @page, 30;",
                    .FETCH_TOTAL_COUNT_QUERY_SEARCH = "SELECT COUNT(*) FROM tblsections WHERE name LIKE @search",
                    .FETCH_LIMIT_QUERY_SEARCH = "SELECT s.id, s.name, s.year_id, y.year_level, y.department_id FROM tblsections s JOIN tblyearlevels y ON s.year_id = y.id WHERE name LIKE @search ORDER BY name ASC LIMIT @page, 30",
                    .UPDATE_QUERY = "UPDATE tblsections SET name = @name, year_id = @yid WHERE id = @id",
                    .FETCH_ALL_QUERY = "SELECT s.id, s.name, s.year_id, y.year_level FROM tblsections s JOIN tblyearlevel y ON s.year_id = y.id WHERE year_id = @yid ORDER BY s.name"
                }
            Case QueryTableType.YEARLEVEL_QUERY_TABLE
                Return New MaintenanceQueries With {
                    .ADD_QUERY = "INSERT INTO tblyearlevels (year_level, department_id) VALUES (@name, @did)",
                    .DELETE_QUERY = "DELETE FROM tblyearlevels WHERE id = @id",
                    .EXISTS_QUERY_WITH_ID = "SELECT COUNT(*) FROM tblyearlevels WHERE LOWER(yearl_level) = LOWER(@name) AND id != @id",
                    .EXISTS_QUERY_NO_ID = "SELECT COUNT(*) FROM tblyearlevels WHERE LOWER(year_level) = LOWER(@name)",
                    .FETCH_TOTAL_COUNT_QUERY = "SELECT COUNT(*) FROM tblyearlevels",
                    .FETCH_LIMIT_QUERY = "SELECT y.id, y.year_level, d.department_name FROM tblyearlevels y JOIN tbldepartments d ON y.department_id = d.id ORDER BY year_level ASC LIMIT @page, 30;",
                    .FETCH_TOTAL_COUNT_QUERY_SEARCH = "SELECT COUNT(*) FROM tblyearlevels WHERE year_level LIKE @search",
                    .FETCH_LIMIT_QUERY_SEARCH = "SELECT y.id, y.year_level, d.department_name FROM tblyearlevels y JOIN tbldepartments d ON y.department_id = d.id WHERE year_level LIKE @search ORDER BY year_level ASC LIMIT @page, 30",
                    .UPDATE_QUERY = "UPDATE tblyearlevels SET year_level = @name, department_id = @did WHERE id = @id",
                    .FETCH_ALL_QUERY = "SELECT id, year_level FROM tblyearlevels WHERE department_id = @did ORDER BY year_level"
                }
            Case QueryTableType.LANGUAGES_QUERY_TABLE
                Return New MaintenanceQueries With {
                    .ADD_QUERY = "INSERT INTO tbllanguages (language, code) VALUES (@language, @code)",
                    .DELETE_QUERY = "DELETE FROM tbllanguages WHERE id = @id",
                    .EXISTS_QUERY_WITH_ID = "SELECT COUNT(*) FROM tbllanguages WHERE LOWER(language) = LOWER(@language) AND code = @code AND id != @id",
                    .EXISTS_QUERY_NO_ID = "SELECT COUNT(*) FROM tbllanguages WHERE LOWER(language) = LOWER(@language) AND code = @code",
                    .FETCH_TOTAL_COUNT_QUERY = "SELECT COUNT(*) FROM tbllanguages",
                    .FETCH_LIMIT_QUERY = "SELECT language, code, id FROM tbllanguages ORDER BY language ASC LIMIT @page, 30;",
                    .FETCH_LIMIT_QUERY_SEARCH = "SELECT language, code, id FROM tbllanguages WHERE language LIKE @search OR code LIKE @search ORDER BY name ASC LIMIT @page, 30;",
                    .FETCH_TOTAL_COUNT_QUERY_SEARCH = "SELECT COUNT(*) FROM tbllanguages WHERE language LIKE @search OR code LIKE @search ORDER BY language ASC",
                    .UPDATE_QUERY = "UPDATE tbllanguages SET language = @language, code = @code WHERE id = @id",
                    .FETCH_ALL_QUERY = "SELECT language, code, id FROM tbllanguages ORDER BY language ASC"
                }

            Case QueryTableType.BOOK_QUERY_TABLE
                Return New MaintenanceQueries With {
                    .ADD_QUERY = "INSERT INTO tblbooks (isbn, title, book_cover, genre_id, author_id, publisher_id, language_id, classification_id, reserve_copy, spenalty, fpenalty)
                                    VALUES (@isbn, @title, @cover, @gid, @aid, @pid, @lid, @cid, @rcopy, @spenalty, @fpenalty)",
                    .DELETE_QUERY = "DELETE FROM tblbooks WHERE id = @id",
                    .EXISTS_QUERY_WITH_ID = "SELECT COUNT(*) FROM tblbooks WHERE LOWER(isbn) = LOWER(@isbn) AND id != @id",
                    .EXISTS_QUERY_NO_ID = "SELECT COUNT(*) FROM tblbooks WHERE LOWER(isbn) = LOWER(@isbn)",
                    .FETCH_TOTAL_COUNT_QUERY = "SELECT COUNT(*) FROM tblbooks",
                    .FETCH_LIMIT_QUERY = "SELECT b.*, g.name genre_name, concat(a.first_name, ' ', a.last_name) name
                                            FROM tblbooks b
                                            JOIN tblgenres g ON genre_id = g.id
                                            JOIN tblauthors a ON author_id = a.id ORDER BY title ASC LIMIT @page, 30;",
                    .FETCH_LIMIT_QUERY_SEARCH = "SELECT b.*, g.name genre_name, concat(a.first_name, ' ', a.last_name) name
                                                    FROM tblbooks b
                                                    JOIN tblgenres g ON genre_id = g.id
                                                    JOIN tblauthors a ON author_id = a.id WHERE title LIKE @search OR isbn LIKE @search OR g.name LIKE @search OR a.first_name LIKE @search OR a.last_name LIKE @search ORDER BY title ASC LIMIT @page, 30;",
                    .FETCH_TOTAL_COUNT_QUERY_SEARCH = "SELECT COUNT(*)
                                                    FROM tblbooks b
                                                    JOIN tblgenres g ON genre_id = g.id
                                                    JOIN tblauthors a ON author_id = a.id WHERE title LIKE @search OR isbn LIKE @search OR g.name LIKE @search OR a.first_name LIKE @search OR a.last_name LIKE @search ORDER BY title ASC",
                    .UPDATE_QUERY = "UPDATE tblbooks SET isbn = @isbn, title = @title, book_cover = @cover, genre_id = @gid, author_id = @aid, publisher_id = @pid, language_id = @lid, classification_id = @cid, reserve_copy = @rcopy, spenalty = @spenalty, fpenalty = @fpenalty WHERE id = @id",
                    .FETCH_ALL_QUERY = "SELECT language, code, id FROM tbllanguages ORDER BY language ASC"
                }
        End Select
        Return New MaintenanceQueries
    End Function
End Module
