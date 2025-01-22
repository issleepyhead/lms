Module QueryTableFactory

#Region "Maintenanc Queries"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="type"></param>
    ''' <returns></returns>
    Public Function QueryTableFactory(type As QueryTableType) As MaintenanceQueries
        Select Case type
#Region "Maintenance Queries"
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

            Case QueryTableType.LANGUAGES_QUERY_TABLE
                Return New MaintenanceQueries With {
                    .ADD_QUERY = "INSERT INTO tbllanguages (language, code) VALUES (@language, @code)",
                    .DELETE_QUERY = "DELETE FROM tbllanguages WHERE id = @id",
                    .EXISTS_QUERY_WITH_ID = "SELECT COUNT(*) FROM tbllanguages WHERE LOWER(language) = LOWER(@language) AND code = @code AND id != @id",
                    .EXISTS_QUERY_NO_ID = "SELECT COUNT(*) FROM tbllanguages WHERE LOWER(language) = LOWER(@language) AND code = @code",
                    .FETCH_TOTAL_COUNT_QUERY = "SELECT COUNT(*) FROM tbllanguages",
                    .FETCH_LIMIT_QUERY = "SELECT language, code, id FROM tbllanguages ORDER BY language ASC LIMIT @page, 30;",
                    .FETCH_LIMIT_QUERY_SEARCH = "SELECT language, code, id FROM tbllanguages WHERE language LIKE @search OR code LIKE @search ORDER BY language ASC LIMIT @page, 30;",
                    .FETCH_TOTAL_COUNT_QUERY_SEARCH = "SELECT COUNT(*) FROM tbllanguages WHERE language LIKE @search OR code LIKE @search ORDER BY language ASC",
                    .UPDATE_QUERY = "UPDATE tbllanguages SET language = @language, code = @code WHERE id = @id",
                    .FETCH_ALL_QUERY = "SELECT language, code, id FROM tbllanguages ORDER BY language ASC"
                }

            ' TODO FETCH ONLY THE ACTIVE
            Case QueryTableType.BOOK_QUERY_TABLE
                Return New MaintenanceQueries With {
                    .ADD_QUERY = "INSERT INTO tblbooks (isbn, title, book_cover, genre_id, author_id, publisher_id, language_id, classification_id, reserve_copy, spenalty, fpenalty)
                                    VALUES (@isbn, @title, @cover, @gid, @aid, @pid, @lid, @cid, @rcopy, @spenalty, @fpenalty)",
                    .DELETE_QUERY = "DELETE FROM tblbooks WHERE id = @id",
                    .EXISTS_QUERY_WITH_ID = "SELECT COUNT(*) FROM tblbooks WHERE LOWER(isbn) = LOWER(@isbn) AND id != @id",
                    .EXISTS_QUERY_NO_ID = "SELECT COUNT(*) FROM tblbooks WHERE LOWER(isbn) = LOWER(@isbn)",
                    .FETCH_TOTAL_COUNT_QUERY = "SELECT COUNT(*) FROM tblbooks WHERE status = 1",
                    .FETCH_LIMIT_QUERY = "SELECT b.id, b.title, b.isbn, b.book_cover, b.fpenalty, b.spenalty, b.publisher_id, b.genre_id, b.language_id, b.author_id,
                                                 b.classification_id, b.reserve_copy, g.name genre_name, concat(a.first_name, ' ', a.last_name) name
                                            FROM tblbooks b
                                            JOIN tblgenres g ON genre_id = g.id
                                            JOIN tblauthors a ON author_id = a.id WHERE status = 1 ORDER BY title ASC LIMIT @page, 30;",
                    .FETCH_LIMIT_QUERY_SEARCH = "SELECT b.id, b.title, b.isbn, b.book_cover, b.fpenalty, b.spenalty, b.publisher_id, b.genre_id, b.language_id, b.author_id,
                                                 b.classification_id, b.reserve_copy, g.name genre_name, concat(a.first_name, ' ', a.last_name) name
                                                    FROM tblbooks b
                                                    JOIN tblgenres g ON genre_id = g.id
                                                    JOIN tblauthors a ON author_id = a.id WHERE status = 1 AND title LIKE @search OR isbn LIKE @search OR g.name LIKE @search OR a.first_name LIKE @search OR a.last_name LIKE @search ORDER BY title ASC LIMIT @page, 30;",
                    .FETCH_TOTAL_COUNT_QUERY_SEARCH = "SELECT COUNT(*)
                                                    FROM tblbooks b
                                                    JOIN tblgenres g ON genre_id = g.id
                                                    JOIN tblauthors a ON author_id = a.id WHERE status = 1 AND title LIKE @search OR isbn LIKE @search OR g.name LIKE @search OR a.first_name LIKE @search OR a.last_name LIKE @search ORDER BY title ASC",
                    .UPDATE_QUERY = "UPDATE tblbooks SET isbn = @isbn, title = @title, book_cover = @cover, genre_id = @gid, author_id = @aid, publisher_id = @pid, language_id = @lid, classification_id = @cid, reserve_copy = @rcopy, spenalty = @spenalty, fpenalty = @fpenalty, status = 1 WHERE id = @id",
                    .FETCH_ARCHIVE_TOTAL_COUNT = "SELECT COUNT(*) FROM tblbooks WHERE status = 0",
                    .FETCH_ARCHIVE_SEARCH_TOTAL_COUNT = "SELECT COUNT(*)
                                                    FROM tblbooks b
                                                    JOIN tblgenres g ON genre_id = g.id
                                                    JOIN tblauthors a ON author_id = a.id WHERE status = 0 AND (title LIKE @search OR isbn LIKE @search OR g.name LIKE @search OR a.first_name LIKE @search OR a.last_name LIKE @search) ORDER BY title ASC",
                    .FETCH_ARCHIVE_LIMIT = "SELECT b.id, b.title, b.isbn, b.book_cover, b.fpenalty, b.spenalty, b.publisher_id, b.genre_id, b.language_id, b.author_id,
                                                 b.classification_id, b.reserve_copy, g.name genre_name, concat(a.first_name, ' ', a.last_name) name
                                            FROM tblbooks b
                                            JOIN tblgenres g ON genre_id = g.id
                                            JOIN tblauthors a ON author_id = a.id WHERE status = 0 ORDER BY title ASC LIMIT @page, 30;",
                    .FETCH_ARCHIVE_LIMIT_SEARCH = "SELECT b.id, b.title, b.isbn, b.book_cover, b.fpenalty, b.spenalty, b.publisher_id, b.genre_id, b.language_id, b.author_id,
                                                 b.classification_id, b.reserve_copy, g.name genre_name, concat(a.first_name, ' ', a.last_name) name
                                                    FROM tblbooks b
                                                    JOIN tblgenres g ON genre_id = g.id
                                                    JOIN tblauthors a ON author_id = a.id WHERE status = 0 AND (title LIKE @search OR isbn LIKE @search OR g.name LIKE @search OR a.first_name LIKE @search OR a.last_name LIKE @search) ORDER BY title ASC LIMIT @page, 30;"
                }
#End Region

#Region "Accounts Queries"
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
                    .FETCH_ALL_QUERY = "SELECT id, `name` FROM tblsections WHERE year_id = @yid ORDER BY `name`"
                }

            Case QueryTableType.YEARLEVEL_QUERY_TABLE
                Return New MaintenanceQueries With {
                    .ADD_QUERY = "INSERT INTO tblyearlevels (year_level, department_id) VALUES (@name, @did)",
                    .DELETE_QUERY = "DELETE FROM tblyearlevels WHERE id = @id",
                    .EXISTS_QUERY_WITH_ID = "SELECT COUNT(*) FROM tblyearlevels WHERE LOWER(yearl_level) = LOWER(@name) AND id != @id",
                    .EXISTS_QUERY_NO_ID = "SELECT COUNT(*) FROM tblyearlevels WHERE LOWER(year_level) = LOWER(@name)",
                    .FETCH_TOTAL_COUNT_QUERY = "SELECT COUNT(*) FROM tblyearlevels",
                    .FETCH_LIMIT_QUERY = "SELECT y.id, y.year_level, d.department_name, y.department_id FROM tblyearlevels y JOIN tbldepartments d ON y.department_id = d.id ORDER BY year_level ASC LIMIT @page, 30;",
                    .FETCH_TOTAL_COUNT_QUERY_SEARCH = "SELECT COUNT(*) FROM tblyearlevels WHERE year_level LIKE @search",
                    .FETCH_LIMIT_QUERY_SEARCH = "SELECT y.id, y.year_level, d.department_name, y.department_id FROM tblyearlevels y JOIN tbldepartments d ON y.department_id = d.id WHERE year_level LIKE @search ORDER BY year_level ASC LIMIT @page, 30",
                    .UPDATE_QUERY = "UPDATE tblyearlevels SET year_level = @name, department_id = @did WHERE id = @id",
                    .FETCH_ALL_QUERY = "SELECT id, year_level FROM tblyearlevels ORDER BY year_level"
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

            ' TODO PUT A SEARCH FOR SECTION
            ' TODO FETCH ONLY THE ACTIVE
            Case QueryTableType.STUDENT_QUERY_TABLE
                Return New MaintenanceQueries With {
                    .ADD_QUERY = "INSERT INTO tblstudents (lrn, full_name, gender, address, phone, email, section_id, password) VALUES (@lrn, @full_name, @gender, @address, @phone, @email, @sid, @passwd)",
                    .DELETE_QUERY = "DELETE FROM tblstudents WHERE id = @id",
                    .EXISTS_QUERY_WITH_ID = "SELECT COUNT(*) FROM tblstudents WHERE lrn = @lrn AND id != @id",
                    .EXISTS_QUERY_NO_ID = "SELECT COUNT(*) FROM tblstudents WHERE lrn = @lrn",
                    .FETCH_TOTAL_COUNT_QUERY = "SELECT COUNT(*) FROM tblstudents WHERE status = 1",
                    .FETCH_LIMIT_QUERY = "SELECT st.id, lrn, full_name, gender, address, phone, email, section_id, s.name section, s.year_id, y.year_level FROM tblstudents st JOIN tblsections s ON st.section_id = s.id JOIN tblyearlevels y ON s.year_id = y.id WHERE status = 1 ORDER BY full_name ASC LIMIT @page, 30;",
                    .FETCH_TOTAL_COUNT_QUERY_SEARCH = "SELECT COUNT(*) FROM tblstudents WHERE status = 1 AND (lrn LIKE @search OR email LIKE @search OR full_name LIKE @search)",
                    .FETCH_LIMIT_QUERY_SEARCH = "SELECT st.id, lrn, full_name, gender, address, phone, email, section_id, s.name section, s.year_id, y.year_level FROM tblstudents st JOIN tblsections s ON st.section_id = s.id JOIN tblyearlevels y ON s.year_id = y.id WHERE status = 1 AND (lrn LIKE @search OR email LIKE @search OR full_name LIKE @search) ORDER BY full_name ASC LIMIT @page, 30",
                    .UPDATE_QUERY = "UPDATE tblstudents SET lrn = @lrn, full_name = @full_name, gender = @gender, address = @address, email = @email, section_id = @sid, status = 1 WHERE id = @id",
                    .FETCH_ALL_QUERY = "SELECT id, department_name FROM tblstudents ORDER BY department_name",
                    .FETCH_ARCHIVE_LIMIT = "SELECT st.id, lrn, full_name, gender, address, phone, email, section_id, s.name section, s.year_id, y.year_level FROM tblstudents st JOIN tblsections s ON st.section_id = s.id JOIN tblyearlevels y ON s.year_id = y.id WHERE status = 0 ORDER BY full_name ASC LIMIT @page, 30;",
                    .FETCH_ARCHIVE_LIMIT_SEARCH = "SELECT st.id, lrn, full_name, gender, address, phone, email, section_id, s.name section, s.year_id, y.year_level FROM tblstudents st JOIN tblsections s ON st.section_id = s.id JOIN tblyearlevels y ON s.year_id = y.id WHERE status = 0 AND (lrn LIKE @search OR email LIKE @search OR full_name LIKE @search) ORDER BY full_name ASC LIMIT @page, 30",
                    .FETCH_ARCHIVE_SEARCH_TOTAL_COUNT = "SELECT COUNT(*) FROM tblstudents WHERE status = 0 AND (lrn LIKE @search OR email LIKE @search OR full_name LIKE @search)",
                    .FETCH_ARCHIVE_TOTAL_COUNT = "SELECT COUNT(*) FROM tblstudents WHERE status = 0"
                }

                ' TODO FETCH ONLY THE ACTIVE
            Case QueryTableType.FACULTY_QUERY_TABLE
                Return New MaintenanceQueries With {
                    .ADD_QUERY = "INSERT INTO tblfaculties (full_name, gender, address, phone, email, department_id, password, username) VALUES (@full_name, @gender, @address, @phone, @email, @did, @passwd, @username)",
                    .DELETE_QUERY = "DELETE FROM tblfaculties WHERE id = @id",
                    .EXISTS_QUERY_WITH_ID = "SELECT COUNT(*) FROM tblfaculties WHERE username = @username AND id != @id",
                    .EXISTS_QUERY_NO_ID = "SELECT COUNT(*) FROM tblfaculties WHERE username = @username",
                    .FETCH_TOTAL_COUNT_QUERY = "SELECT COUNT(*) FROM tblfaculties WHERE status = 1",
                    .FETCH_LIMIT_QUERY = "SELECT st.id, st.username, full_name, gender, address, phone, email, department_id, d.department_name FROM tblfaculties st JOIN tbldepartments d ON st.department_id = d.id WHERE status = 1 ORDER BY full_name ASC LIMIT @page, 30;",
                    .FETCH_TOTAL_COUNT_QUERY_SEARCH = "SELECT COUNT(*) FROM tblfaculties WHERE status = 1 AND (email LIKE @search OR full_name LIKE @search)",
                    .FETCH_LIMIT_QUERY_SEARCH = "SELECT st.id, st.username, full_name, gender, address, phone, email, department_id, d.department_name FROM tblfaculties st JOIN tbldepartments d ON st.department_id = d.id WHERE status = 1 AND (email LIKE @search OR full_name LIKE @search) ORDER BY full_name ASC LIMIT @page, 30",
                    .UPDATE_QUERY = "UPDATE tblfaculties SET full_name = @full_name, gender = @gender, address = @address, email = @email, department_id = @did, status = 1 WHERE id = @id",
                    .FETCH_ALL_QUERY = "SELECT id, department_name FROM tblfaculties ORDER BY department_name",
                    .FETCH_ARCHIVE_SEARCH_TOTAL_COUNT = "SELECT COUNT(*) FROM tblfaculties WHERE status = 0 AND (email LIKE @search OR full_name LIKE @search)",
                    .FETCH_ARCHIVE_LIMIT_SEARCH = "SELECT st.id, st.username, full_name, gender, address, phone, email, department_id, d.department_name FROM tblfaculties st JOIN tbldepartments d ON st.department_id = d.id WHERE status = 0 AND (email LIKE @search OR full_name LIKE @search) ORDER BY full_name ASC LIMIT @page, 30"
                }
#End Region

            ' TODO SELECT THE ACTIVE ONLY
            Case QueryTableType.BOOKCOPIES_QUERY_TABLE
                Return New MaintenanceQueries With {
                    .UPDATE_QUERY = "UPDATE tblbookcopies SET status = 1;",
                    .DELETE_QUERY = "UPDATE tblbookcopies SET status = 0",
                    .FETCH_LIMIT_QUERY = "SELECT 
                                            b.title,
	                                        b.isbn,
                                            COUNT(CASE WHEN bc.condition = 0 THEN 1 END) good,
                                            COUNT(CASE WHEN bc.condition = 1 THEN 1 END) damaged,
                                            COUNT(CASE WHEN bc.condition = 2 THEN 1 END) lost,
                                            COUNT(CASE WHEN bc.status = 0 THEN 1 END) borrowed,
                                            COUNT(CASE WHEN bc.status = 1 THEN 1 END) available,
	                                        COUNT(book_id) total
                                        FROM
                                            tblbookcopies bc
                                                JOIN
                                            tblbooks b ON bc.book_id = b.id
                                        GROUP BY b.title, b.isbn
                                        ORDER BY b.title LIMIT @page, 30;",
                    .FETCH_TOTAL_COUNT_QUERY = "SELECT COUNT(DISTINCT b.title) FROM tblbookcopies bc JOIN tblbooks b ON bc.book_id = b.id GROUP BY b.title, b.isbn ORDER BY b.title",
                    .FETCH_LIMIT_QUERY_SEARCH = "SELECT 
                                            b.title,
	                                        b.isbn,
                                            COUNT(CASE WHEN bc.condition = 0 THEN 1 END) good,
                                            COUNT(CASE WHEN bc.condition = 1 THEN 1 END) damaged,
                                            COUNT(CASE WHEN bc.condition = 2 THEN 1 END) lost,
                                            COUNT(CASE WHEN bc.status = 0 THEN 1 END) borrowed,
                                            COUNT(CASE WHEN bc.status = 1 THEN 1 END) available,
	                                        COUNT(book_id) total
                                        FROM
                                            tblbookcopies bc
                                                JOIN
                                            tblbooks b ON bc.book_id = b.id
                                        WHERE b.title LIKE @search OR b.isbn LIKE @search
                                        GROUP BY b.title, b.isbn
                                        ORDER BY b.title LIMIT @page, 30;",
                    .FETCH_TOTAL_COUNT_QUERY_SEARCH = "SELECT COUNT(DISTINCT b.title) FROM tblbookcopies bc JOIN tblbooks b ON bc.book_id = b.id WHERE b.title LIKE @search OR b.isbn LIKE @search GROUP BY b.title, b.isbn ORDER BY b.title"
                }
            Case QueryTableType.BOOKINVENTORY_QUERY_TABLE
                Return New MaintenanceQueries With {
                    .DELETE_QUERY = "DELETE FROM tblbookcopies WHERE id = @id",
                    .FETCH_TOTAL_COUNT_QUERY = "SELECT COUNT(*) FROM tblbookcopies",
                    .FETCH_LIMIT_QUERY = "SELECT bc.id, b.title, b.isbn, bc.accession_no, d.name donator_name, s.name supplier_name, price FROM tblbookcopies bc JOIN tblbooks b ON bc.book_id = b.id LEFT JOIN tbldonators d ON bc.donator_id = d.id LEFT JOIN tblsuppliers s ON bc.supplier_id = s.id ORDER BY b.title LIMIT @page, 30;",
                    .FETCH_LIMIT_QUERY_SEARCH = "SELECT bc.id, b.title, b.isbn, bc.accession_no, d.name donator_name, s.name supplier_name, price FROM tblbookcopies bc JOIN tblbooks b ON bc.book_id = b.id LEFT JOIN tbldonators d ON bc.donator_id = d.id LEFT JOIN tblsuppliers s ON bc.supplier_id = s.id WHERE b.title LIKE @search OR b.isbn LIKE @search ORDER BY b.title ASC LIMIT @page, 30;",
                    .FETCH_TOTAL_COUNT_QUERY_SEARCH = "SELECT COUNT(*) FROM tblbookcopies bc JOIN tblbooks b ON bc.book_id = b.id LEFT JOIN tbldonators d ON bc.donator_id = d.id LEFT JOIN tblsuppliers s ON bc.supplier_id = s.id WHERE b.title LIKE @search OR b.isbn LIKE @search ORDER BY b.title",
                    .UPDATE_QUERY = "UPDATE tblbookcopies SET price = @price WHERE id = @id"
                }

            Case QueryTableType.ADMIN_QUERY_TABLE
                Return New MaintenanceQueries With {
                    .ADD_QUERY = "INSERT INTO tbladmins (student_id, faculty_id) VALUES (@sid, @fid)",
                    .DELETE_QUERY = "DELETE FROM tbladmins WHERE id = @id",
                    .FETCH_LIMIT_QUERY = "SELECT a.id, full_name, CASE WHEN `role` = 0 THEN 'Super Admin' ELSE 'Assistant Librarian' END AS `role` FROM tbladmins a JOIN tblstudents s ON a.student_id = s.id UNION SELECT a.id, full_name, CASE WHEN `role` = 0 THEN 'Super Admin' ELSE 'Assistant Librarian' END AS `role` FROM tbladmins a JOIN tblfaculties f ON a.faculty_id = f.id ORDER BY full_name LIMIT @page, 30;",
                    .FETCH_LIMIT_QUERY_SEARCH = "SELECT a.id, full_name, CASE WHEN `role` = 0 THEN 'Super Admin' ELSE 'Assistant Librarian' END AS `role` FROM tbladmins a JOIN tblstudents s ON a.student_id = s.id UNION SELECT a.id, full_name, CASE WHEN `role` = 0 THEN 'Super Admin' ELSE 'Assistant Librarian' END AS `role` FROM tbladmins a JOIN tblfaculties f ON a.faculty_id = f.id WHERE full_name LIKE @search OR phone LIKE @search OR email LIKE @search ORDER BY full_name LIMIT @page, 30;",
                    .FETCH_TOTAL_COUNT_QUERY = "SELECT COUNT(*) FROM tbladmins a LEFT JOIN tblfaculties f ON a.faculty_id = f.id LEFT JOIN tblstudents s ON a.student_id = s.id",
                    .FETCH_TOTAL_COUNT_QUERY_SEARCH = "SELECT COUNT(*) FROM tbladmins a LEFT JOIN tblfaculties f ON a.faculty_id = f.id LEFT JOIN tblstudents s ON a.student_id = s.id WHERE full_name LIKE @search OR phone LIKE @search OR email LIKE @search"
                }

            Case QueryTableType.BORROWED_BOOKS_REPORT
                Return New MaintenanceQueries With {
                    .FETCH_LIMIT_QUERY = "SELECT b.title, g.name genre, c.classification, COUNT(bbc.copy_id) borrowed_count
                            FROM tblbooks b
                            JOIN tblgenres g ON b.genre_id = g.id
                            JOIN tblclassifications c ON b.classification_id = c.id
                            LEFT JOIN tblbookcopies bc ON b.id = bc.book_id
                            LEFT JOIN tblborrowedcopies bbc ON bc.id = bbc.copy_id
                            GROUP BY b.title, g.name, c.classification
                            ORDER BY b.title LIMIT @page, 30;",
                    .FETCH_TOTAL_COUNT_QUERY = "SELECT COUNT(DISTINCT b.title)
                            FROM tblbooks b
                            JOIN tblgenres g ON b.genre_id = g.id
                            JOIN tblclassifications c ON b.classification_id = c.id
                            LEFT JOIN tblbookcopies bc ON b.id = bc.book_id
                            LEFT JOIN tblborrowedcopies bbc ON bc.id = bbc.copy_id
                            ORDER BY b.title",
                    .FETCH_TOTAL_COUNT_QUERY_SEARCH = "SELECT COUNT(DISTINCT b.title)
                            FROM tblbooks b
                            JOIN tblgenres g ON b.genre_id = g.id
                            JOIN tblclassifications c ON b.classification_id = c.id
                            LEFT JOIN tblbookcopies bc ON b.id = bc.book_id
                            LEFT JOIN tblborrowedcopies bbc ON bc.id = bbc.copy_id
                            WHERE b.title LIKE @search OR g.name LIKE @search OR c.classification LIKE @search
                            ORDER BY b.title",
                    .FETCH_LIMIT_QUERY_SEARCH = "SELECT b.title, g.name genre, c.classification, COUNT(bbc.copy_id) borrowed_count
                            FROM tblbooks b
                            JOIN tblgenres g ON b.genre_id = g.id
                            JOIN tblclassifications c ON b.classification_id = c.id
                            LEFT JOIN tblbookcopies bc ON b.id = bc.book_id
                            LEFT JOIN tblborrowedcopies bbc ON bc.id = bbc.copy_id
                            WHERE b.title LIKE @search OR g.name LIKE @search OR c.classification LIKE @search
                            GROUP BY b.title, g.name, c.classification
                            ORDER BY b.title LIMIT @page, 30;"
                }
            Case QueryTableType.EXPENDITURE_REPORT
                Return New MaintenanceQueries With {
                    .FETCH_LIMIT_QUERY = "SELECT b.title, COUNT(b.id) total_copies, SUM(bc.price) total_price
                                                FROM tblbooks b
                                                JOIN tblbookcopies bc ON b.id = bc.book_id
                                                GROUP BY b.title LIMIT @page, 30;",
                    .FETCH_TOTAL_COUNT_QUERY = "SELECT COUNT(DISTINCT b.title)
                                                FROM tblbooks b
                                                JOIN tblbookcopies bc ON b.id = bc.book_id
                                                GROUP BY b.title",
                    .FETCH_LIMIT_QUERY_SEARCH = "SELECT b.title, COUNT(b.id) total_copies, SUM(bc.price) total_price
                                                FROM tblbooks b
                                                JOIN tblbookcopies bc ON b.id = bc.book_id
                                                WHERE b.title LIKE @search
                                                GROUP BY b.title LIMIT @page, 30;",
                    .FETCH_TOTAL_COUNT_QUERY_SEARCH = "SELECT COUNT(DISTINCT b.title)
                                                FROM tblbooks b
                                                JOIN tblbookcopies bc ON b.id = bc.book_id
                                                WHERE b.title LIKE @search
                                                GROUP BY b.title"
                }
            Case QueryTableType.FINES_REPORT
                Return New MaintenanceQueries With {
                    .FETCH_LIMIT_QUERY = "SELECT bc.accession_no,
	                                               CASE WHEN bh.student_id IS NULL THEN f.full_name ELSE s.full_name END AS full_name,
                                                   bh.borrow_date,
                                                   bh.overdue_date,
                                                   DATEDIFF(NOW(), DATE_ADD(bh.overdue_date, INTERVAL 1 DAY)) overdue_days,
                                                   CASE WHEN (SELECT gpenalty FROM tblappsettings LIMIT 1) = 1 THEN (CASE WHEN bh.student_id IS NULL THEN (SELECT fpenalty FROM tblappsettings) ELSE (SELECT spenalty FROM tblappsettings) END) ELSE (CASE WHEN bh.student_id IS NULL THEN b.fpenalty ELSE b.spenalty END) END AS penalty,
                                                   DATEDIFF(NOW(), DATE_ADD(bh.overdue_date, INTERVAL 1 DAY)) * CASE WHEN (SELECT gpenalty FROM tblappsettings LIMIT 1) = 1 THEN (CASE WHEN bh.student_id IS NULL THEN (SELECT fpenalty FROM tblappsettings) ELSE (SELECT spenalty FROM tblappsettings) END) ELSE (CASE WHEN bh.student_id IS NULL THEN b.fpenalty ELSE b.spenalty END) END total_penalty
                                            FROM tblborrowheaders bh
                                            LEFT JOIN tblstudents s ON bh.student_id = s.id
                                            LEFT JOIN tblfaculties f ON bh.faculty_id = s.id
                                            JOIN tblborrowedcopies bbc ON bh.id = bbc.header_id
                                            JOIN tblbookcopies bc ON bbc.copy_id = bc.id 
                                            JOIN tblbooks b ON bc.book_id = b.id
                                            HAVING DATEDIFF(NOW(), DATE_ADD(bh.overdue_date, INTERVAL 1 DAY)) > 0 LIMIT @page, 30;",
                    .FETCH_TOTAL_COUNT_QUERY = "SELECT COUNT(*)
                                                FROM tblborrowheaders bh
                                                LEFT JOIN tblstudents s ON bh.student_id = s.id
                                                LEFT JOIN tblfaculties f ON bh.faculty_id = s.id
                                                JOIN tblborrowedcopies bbc ON bh.id = bbc.header_id
                                                JOIN tblbookcopies bc ON bbc.copy_id = bc.id 
                                                JOIN tblbooks b ON bc.book_id = b.id
                                                HAVING DATEDIFF(NOW(), DATE_ADD(bh.overdue_date, INTERVAL 1 DAY)) > 0",
                    .FETCH_LIMIT_QUERY_SEARCH = "SELECT bc.accession_no,
	                                                CASE WHEN bh.student_id IS NULL THEN f.full_name ELSE s.full_name END AS full_name,
                                                    bh.borrow_date,
                                                    bh.overdue_date,
                                                    DATEDIFF(NOW(), DATE_ADD(bh.overdue_date, INTERVAL 1 DAY)) overdue_days,
                                                    CASE WHEN (SELECT gpenalty FROM tblappsettings LIMIT 1) = 1 THEN (CASE WHEN bh.student_id IS NULL THEN (SELECT fpenalty FROM tblappsettings) ELSE (SELECT spenalty FROM tblappsettings) END) ELSE (CASE WHEN bh.student_id IS NULL THEN b.fpenalty ELSE b.spenalty END) END AS penalty,
                                                    DATEDIFF(NOW(), DATE_ADD(bh.overdue_date, INTERVAL 1 DAY)) * CASE WHEN (SELECT gpenalty FROM tblappsettings LIMIT 1) = 1 THEN (CASE WHEN bh.student_id IS NULL THEN (SELECT fpenalty FROM tblappsettings) ELSE (SELECT spenalty FROM tblappsettings) END) ELSE (CASE WHEN bh.student_id IS NULL THEN b.fpenalty ELSE b.spenalty END) END total_penalty
                                            FROM tblborrowheaders bh
                                            LEFT JOIN tblstudents s ON bh.student_id = s.id
                                            LEFT JOIN tblfaculties f ON bh.faculty_id = s.id
                                            JOIN tblborrowedcopies bbc ON bh.id = bbc.header_id
                                            JOIN tblbookcopies bc ON bbc.copy_id = bc.id 
                                            JOIN tblbooks b ON bc.book_id = b.id
                                            WHERE f.full_name LIKE @search OR s.full_name LIKE @search
                                            HAVING DATEDIFF(NOW(), DATE_ADD(bh.overdue_date, INTERVAL 1 DAY)) > 0 LIMIT @page, 30;",
                    .FETCH_TOTAL_COUNT_QUERY_SEARCH = "SELECT COUNT(*)
                                                    FROM tblborrowheaders bh
                                                    LEFT JOIN tblstudents s ON bh.student_id = s.id
                                                    LEFT JOIN tblfaculties f ON bh.faculty_id = s.id
                                                    JOIN tblborrowedcopies bbc ON bh.id = bbc.header_id
                                                    JOIN tblbookcopies bc ON bbc.copy_id = bc.id 
                                                    JOIN tblbooks b ON bc.book_id = b.id
                                                    WHERE f.full_name LIKE @search OR s.full_name LIKE @search
                                                    HAVING DATEDIFF(NOW(), DATE_ADD(bh.overdue_date, INTERVAL 1 DAY)) > 0"
                }
        End Select
        Return New MaintenanceQueries
    End Function
#End Region

    'Public ADD_ASSISTANT_STUDENT_QUERY As String = "INSERT INTO tbladmins (student_id) VALUES (@sid)"
    'Public ADD_ASSISTANT_FACULTY_QUERY As String = "INSERT INTO tbladmins (faculty_id) VALUES (@fid)"
    'Public REMOVE_ASSISTANT_QUERY As String = "DELETE FROM tbladmins WHERE id = @id"
    Public STUDENT_ADMIN_EXISTS_QUERY As String = "SELECT COUNT(*) FROM tbladmins WHERE student_id = @id"
    Public FACULTY_ADMIN_EXISTS_QUERY As String = "SELECT COUNT(*) FROM tbladmins WHERE faculty_id = @id"

    Public ADD_ADMIN_QUERY As String = "INSERT INTO tbladmins (student_id, faculty_id) VALUES (@sid, @fid)"
    Public ADD_SUPERADMIN_QUERY As String = "INSERT INTO tbladmins (faculty_id, role) VALUES (@fid, 0)"
    Public PROMOTE_SUPERADMIN_QUERY As String = "UPDATE tbladmins SET role = 0 WHERE faculty_id = @fid"
    Public DEMOTE_SUPERADMIN_QUERY As String = "UPDATE tbladmins SET role = 1 WHERE role = 0"
    'Public UPDATE_ROLE_QUERY As String = "UPDATE tbladmins SET role = @role"

    Public ARCHIVE_BOOKS_QUERY As String = "UPDATE tblbooks SET status = 0 WHERE id = @id"
    Public UNARCHIVE_BOOKS_QUERY As String = "UPDATE tblbooks SET status = 1 WHERE id = @id"

    Public ARCHIVE_STUDENT_QUERY As String = "UPDATE tblstudents SET status = 0 WHERE id = @id"
    Public UNARCHIVE_STUDENT_QUERY As String = "UPDATE tblstudents SET status = 1 WHERE id = @id"

    Public ARCHIVE_FACULTY_QUERY As String = "UPDATE tblfaculties SET status = 0 WHERE id = @id"
    Public UNARCHIVE_FACULTY_QUERY As String = "UPDATE tblfaculties SET status = 1 WHERE id = @id"
End Module
