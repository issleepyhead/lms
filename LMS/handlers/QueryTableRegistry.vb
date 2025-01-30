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
            .FETCH_ALL_QUERY = "SELECT name, description, id FROM tblgenres ORDER BY name ASC",
            .UPDATE_QUERY = "UPDATE tblgenres SET name = @name, description = @desc WHERE id = @id"
        }},
        {AUTHOR, New QueryTable With {
            .ADD_QUERY = "INSERT INTO tblauthors (first_name, last_name, gender) VALUES (@first_name, @last_name, @gender)",
            .DELETE_QUERY = "DELETE FROM tblauthors WHERE id = @id",
            .EXISTS_ADD_QUERY = "SELECT COUNT(*) FROM tblauthors WHERE LOWER(first_name) = LOWER(@first_name) AND LOWER(last_name) = LOWER(@last_name)",
            .EXISTS_UPDATE_QUERY = "SELECT COUNT(*) FROM tblauthors WHERE LOWER(first_name) = LOWER(@first_name) AND LOWER(last_name) = LOWER(@last_name) AND id != @id",
            .SEARCH_COUNT_QUERY = "SELECT COUNT(*) FROM tblauthors WHERE first_name LIKE @search OR last_name LIKE @search",
            .SEARCH_RESULT_QUERY = "SELECT first_name, last_name, gender, id FROM tblauthors WHERE first_name LIKE @search OR last_name LIKE @search ORDER BY first_name ASC LIMIT @page, 30;",
            .FETCH_ALL_QUERY = "SELECT id, CONCAT(first_name, ' ', last_name) AS name FROM tblauthors ORDER BY first_name ASC",
            .UPDATE_QUERY = "UPDATE tblauthors SET first_name = @first_name, last_name = @last_name, gender = @gender WHERE id = @id"
        }},
        {PUBLISHER, New QueryTable With {
            .ADD_QUERY = "INSERT INTO tblpublishers (publisher_name) VALUES (@name)",
            .DELETE_QUERY = "DELETE FROM tblpublishers WHERE id = @id",
            .EXISTS_ADD_QUERY = "SELECT COUNT(*) FROM tblpublishers WHERE LOWER(publisher_name) = LOWER(@name)",
            .EXISTS_UPDATE_QUERY = "SELECT COUNT(*) FROM tblpublishers WHERE LOWER(publisher_name) = LOWER(@name) AND id != @id",
            .SEARCH_COUNT_QUERY = "SELECT COUNT(*) FROM tblpublishers WHERE publisher_name LIKE @search",
            .SEARCH_RESULT_QUERY = "SELECT id, publisher_name FROM tblpublishers WHERE publisher_name LIKE @search ORDER BY publisher_name ASC LIMIT @page, 30",
            .FETCH_ALL_QUERY = "SELECT id, publisher_name FROM tblpublishers ORDER BY publisher_name ASC",
            .UPDATE_QUERY = "UPDATE tblpublishers SET publisher_name = @name WHERE id = @id"
        }},
        {CLASSIFICATION, New QueryTable With {
            .ADD_QUERY = "INSERT INTO tblclassifications (dewey_decimal, classification) VALUES (@dewey_no, @classification)",
            .DELETE_QUERY = "DELETE FROM tblclassifications WHERE id = @id",
            .EXISTS_ADD_QUERY = "SELECT COUNT(*) FROM tblclassifications WHERE LOWER(classification) = LOWER(@classification) AND LOWER(dewey_decimal) = LOWER(@dewey_no)",
            .EXISTS_UPDATE_QUERY = "SELECT COUNT(*) FROM tblclassifications WHERE (LOWER(classification) = LOWER(@classification) OR LOWER(dewey_decimal) = LOWER(@dewey_no)) AND id != @id",
            .SEARCH_COUNT_QUERY = "SELECT COUNT(*) FROM tblclassifications WHERE dewey_decimal LIKE @search OR classification LIKE @search",
            .SEARCH_RESULT_QUERY = "SELECT id, classification, dewey_decimal FROM tblclassifications WHERE dewey_decimal LIKE @search OR classification LIKE @search ORDER BY dewey_decimal ASC LIMIT @page, 30",
            .FETCH_ALL_QUERY = "SELECT id, classification FROM tblclassifications ORDER BY classification ASC",
            .UPDATE_QUERY = "UPDATE tblclassifications SET classification = @classification, dewey_decimal = @dewey_no WHERE id = @id"
        }},
        {DONATOR, New QueryTable With {
            .ADD_QUERY = "INSERT INTO tbldonators (name, address) VALUES (@name, @address)",
            .DELETE_QUERY = "DELETE FROM tbldonators WHERE id = @id",
            .EXISTS_ADD_QUERY = "SELECT COUNT(*) FROM tbldonators WHERE LOWER(name) = LOWER(@name) AND LOWER(address) = LOWER(@address)",
            .EXISTS_UPDATE_QUERY = "SELECT COUNT(*) FROM tbldonators WHERE LOWER(name) = LOWER(@name) AND LOWER(address) = LOWER(@address) AND id != @id",
            .SEARCH_COUNT_QUERY = "SELECT COUNT(*) FROM tbldonators WHERE name LIKE @search",
            .SEARCH_RESULT_QUERY = "SELECT id, name, address FROM tbldonators WHERE name LIKE @search ORDER BY name ASC LIMIT @page, 30",
            .FETCH_ALL_QUERY = "SELECT id, name, address FROM tbldonators ORDER BY name ASC",
            .UPDATE_QUERY = "UPDATE tbldonators SET name = @name, address = @address WHERE id = @id"
        }},
        {SUPPLIER, New QueryTable With {
            .ADD_QUERY = "INSERT INTO tblsuppliers (name, address) VALUES (@name, @address)",
            .DELETE_QUERY = "DELETE FROM tblsuppliers WHERE id = @id",
            .EXISTS_ADD_QUERY = "SELECT COUNT(*) FROM tblsuppliers WHERE LOWER(name) = LOWER(@name) AND LOWER(address) = LOWER(@address)",
            .EXISTS_UPDATE_QUERY = "SELECT COUNT(*) FROM tblsuppliers WHERE LOWER(name) = LOWER(@name) OR LOWER(address) = LOWER(@address) AND id != @id",
            .SEARCH_COUNT_QUERY = "SELECT COUNT(*) FROM tblsuppliers WHERE name LIKE @search",
            .SEARCH_RESULT_QUERY = "SELECT id, name, address FROM tblsuppliers WHERE name LIKE @search ORDER BY name ASC LIMIT @page, 30",
            .FETCH_ALL_QUERY = "SELECT id, name, address FROM tblsuppliers ORDER BY name ASC",
            .UPDATE_QUERY = "UPDATE tblsuppliers SET name = @name, address = @address WHERE id = @id"
        }},
        {LANGUAGES, New QueryTable With {
            .ADD_QUERY = "INSERT INTO tbllanguages (language, code) VALUES (@language, @code)",
            .DELETE_QUERY = "DELETE FROM tbllanguages WHERE id = @id",
            .EXISTS_ADD_QUERY = "SELECT COUNT(*) FROM tbllanguages WHERE LOWER(language) = LOWER(@language)",
            .EXISTS_UPDATE_QUERY = "SELECT COUNT(*) FROM tbllanguages WHERE LOWER(language) = LOWER(@language) AND id != @id",
            .SEARCH_COUNT_QUERY = "SELECT COUNT(*) FROM tbllanguages WHERE language LIKE @search OR code LIKE @search ORDER BY language ASC",
            .SEARCH_RESULT_QUERY = "SELECT language, code, id FROM tbllanguages WHERE language LIKE @search OR code LIKE @search ORDER BY language ASC LIMIT @page, 30;",
            .FETCH_ALL_QUERY = "SELECT language, code, id FROM tbllanguages ORDER BY language ASC",
            .UPDATE_QUERY = "UPDATE tbllanguages SET language = @language, code = @code WHERE id = @id"
        }},
        {BOOK, New QueryTable With {
            .ADD_QUERY = "INSERT INTO tblbooks (isbn, title, book_cover, genre_id, author_id, publisher_id, language_id, classification_id, reserve_copy, spenalty, fpenalty) VALUES (@isbn, @title, @cover, @gid, @aid, @pid, @lid, @cid, @rcopy, @spenalty, @fpenalty)",
            .DELETE_QUERY = "DELETE FROM tblbooks WHERE id = @id",
            .EXISTS_ADD_QUERY = "SELECT COUNT(*) FROM tblbooks WHERE LOWER(isbn) = LOWER(@isbn)",
            .EXISTS_UPDATE_QUERY = "SELECT COUNT(*) FROM tblbooks WHERE LOWER(isbn) = LOWER(@isbn) AND id != @id",
            .SEARCH_COUNT_QUERY = "SELECT COUNT(*) FROM tblbooks b JOIN tblgenres g ON genre_id = g.id JOIN tblauthors a ON author_id = a.id WHERE status = 1 AND (title LIKE @search OR isbn LIKE @search OR g.name LIKE @search OR a.first_name LIKE @search OR a.last_name) LIKE @search ORDER BY title ASC",
            .SEARCH_RESULT_QUERY = "SELECT b.id, b.title, b.isbn, b.book_cover, b.fpenalty, b.spenalty, b.publisher_id, b.genre_id, b.language_id, b.author_id,
                                    b.classification_id, b.reserve_copy, g.name genre_name, concat(a.first_name, ' ', a.last_name) name
                                    FROM tblbooks b
                                    JOIN tblgenres g ON genre_id = g.id
                                    JOIN tblauthors a ON author_id = a.id WHERE status = 1 AND (title LIKE @search OR isbn LIKE @search OR g.name LIKE @search OR a.first_name LIKE @search OR a.last_name LIKE @search) ORDER BY title ASC LIMIT @page, 30;",
            .FETCH_ALL_QUERY = "SELECT language, code, id FROM tbllanguages ORDER BY language ASC",
            .UPDATE_QUERY = "UPDATE tblbooks SET isbn = @isbn, title = @title, book_cover = @cover, genre_id = @gid, author_id = @aid, publisher_id = @pid, language_id = @lid, classification_id = @cid, reserve_copy = @rcopy, spenalty = @spenalty, fpenalty = @fpenalty, status = 1 WHERE id = @id",
            .ARCHIVE_SEARCH_COUNT_QUERY = "SELECT COUNT(*) FROM tblbooks b JOIN tblgenres g ON genre_id = g.id JOIN tblauthors a ON author_id = a.id WHERE status = 0 AND (title LIKE @search OR isbn LIKE @search OR g.name LIKE @search OR a.first_name LIKE @search OR a.last_name LIKE @search) ORDER BY title ASC",
            .ARCHIVE_SEARCH_RESULT_QUERY = "SELECT b.id, b.title, b.isbn, b.book_cover, b.fpenalty, b.spenalty, b.publisher_id, b.genre_id, b.language_id, b.author_id,
                                                b.classification_id, b.reserve_copy, g.name genre_name, concat(a.first_name, ' ', a.last_name) name
                                                FROM tblbooks b
                                                JOIN tblgenres g ON genre_id = g.id
                                                JOIN tblauthors a ON author_id = a.id WHERE status = 0 AND (title LIKE @search OR isbn LIKE @search OR g.name LIKE @search OR a.first_name LIKE @search OR a.last_name LIKE @search) ORDER BY title ASC LIMIT @page, 30;"
        }},
        {SECTION, New QueryTable With {
            .ADD_QUERY = "INSERT INTO tblsections (name, year_id) VALUES (@name, @yid)",
            .DELETE_QUERY = "DELETE FROM tblsections WHERE id = @id",
            .EXISTS_ADD_QUERY = "SELECT COUNT(*) FROM tblsections WHERE LOWER(name) = LOWER(@name)",
            .EXISTS_UPDATE_QUERY = "SELECT COUNT(*) FROM tblsections WHERE LOWER(name) = LOWER(@name) AND id != @id",
            .SEARCH_COUNT_QUERY = "SELECT COUNT(*) FROM tblsections WHERE name LIKE @search",
            .SEARCH_RESULT_QUERY = "SELECT s.id, s.name, s.year_id, y.year_level, y.department_id FROM tblsections s JOIN tblyearlevels y ON s.year_id = y.id WHERE name LIKE @search ORDER BY name ASC LIMIT @page, 30",
            .FETCH_ALL_QUERY = "SELECT id, `name` FROM tblsections WHERE year_id = @yid ORDER BY `name`",
            .UPDATE_QUERY = "UPDATE tblsections SET name = @name, year_id = @yid WHERE id = @id"
        }},
        {YEARLEVEL, New QueryTable With {
            .ADD_QUERY = "INSERT INTO tblyearlevels (year_level, department_id) VALUES (@name, @did)",
            .DELETE_QUERY = "DELETE FROM tblyearlevels WHERE id = @id",
            .EXISTS_ADD_QUERY = "SELECT COUNT(*) FROM tblyearlevels WHERE LOWER(year_level) = LOWER(@name)",
            .EXISTS_UPDATE_QUERY = "SELECT COUNT(*) FROM tblyearlevels WHERE LOWER(yearl_level) = LOWER(@name) AND id != @id",
            .SEARCH_COUNT_QUERY = "SELECT COUNT(*) FROM tblyearlevels WHERE year_level LIKE @search",
            .SEARCH_RESULT_QUERY = "SELECT y.id, y.year_level, d.department_name, y.department_id FROM tblyearlevels y JOIN tbldepartments d ON y.department_id = d.id WHERE year_level LIKE @search ORDER BY year_level ASC LIMIT @page, 30",
            .FETCH_ALL_QUERY = "SELECT id, year_level FROM tblyearlevels ORDER BY year_level",
            .UPDATE_QUERY = "UPDATE tblyearlevels SET year_level = @name, department_id = @did WHERE id = @id"
        }},
        {DEPARTMENT, New QueryTable With {
            .ADD_QUERY = "INSERT INTO tbldepartments (department_name) VALUES (@name)",
            .DELETE_QUERY = "DELETE FROM tbldepartments WHERE id = @id",
            .EXISTS_ADD_QUERY = "SELECT COUNT(*) FROM tbldepartments WHERE LOWER(department_name) = LOWER(@name)",
            .EXISTS_UPDATE_QUERY = "SELECT COUNT(*) FROM tbldepartments WHERE LOWER(department_name) = LOWER(@name) AND id != @id",
            .SEARCH_COUNT_QUERY = "SELECT COUNT(*) FROM tbldepartments WHERE department_name LIKE @search",
            .SEARCH_RESULT_QUERY = "SELECT id, department_name FROM tbldepartments WHERE department_name LIKE @search ORDER BY department_name ASC LIMIT @page, 30",
            .FETCH_ALL_QUERY = "SELECT id, department_name FROM tbldepartments ORDER BY department_name",
            .UPDATE_QUERY = "UPDATE tbldepartments SET department_name = @name WHERE id = @id"
        }},
        {STUDENT, New QueryTable With {
            .ADD_QUERY = "INSERT INTO tblstudents (lrn, full_name, gender, address, phone, email, section_id, password) VALUES (@lrn, @full_name, @gender, @address, @phone, @email, @sid, @passwd)",
            .DELETE_QUERY = "DELETE FROM tblstudents WHERE id = @id",
            .EXISTS_UPDATE_QUERY = "SELECT COUNT(*) FROM tblstudents WHERE lrn = @lrn AND id != @id",
            .EXISTS_ADD_QUERY = "SELECT COUNT(*) FROM tblstudents WHERE lrn = @lrn",
            .SEARCH_COUNT_QUERY = "SELECT COUNT(*) FROM tblstudents WHERE status = 1 AND (lrn LIKE @search OR email LIKE @search OR full_name LIKE @search)",
            .SEARCH_RESULT_QUERY = "SELECT st.id, lrn, full_name, gender, address, phone, email, section_id, s.name section, s.year_id, y.year_level FROM tblstudents st JOIN tblsections s ON st.section_id = s.id JOIN tblyearlevels y ON s.year_id = y.id WHERE status = 1 AND (lrn LIKE @search OR email LIKE @search OR full_name LIKE @search) ORDER BY full_name ASC LIMIT @page, 30",
            .UPDATE_QUERY = "UPDATE tblstudents SET lrn = @lrn, full_name = @full_name, gender = @gender, address = @address, email = @email, section_id = @sid, status = 1 WHERE id = @id"
        }},
        {FACULTY, New QueryTable With {
            .ADD_QUERY = "INSERT INTO tblfaculties (full_name, gender, address, phone, email, department_id, password, username) VALUES (@full_name, @gender, @address, @phone, @email, @did, @passwd, @username)",
            .DELETE_QUERY = "DELETE FROM tblfaculties WHERE id = @id",
            .EXISTS_ADD_QUERY = "SELECT COUNT(*) FROM tblfaculties WHERE username = @username",
            .EXISTS_UPDATE_QUERY = "SELECT COUNT(*) FROM tblfaculties WHERE username = @username AND id != @id",
            .SEARCH_COUNT_QUERY = "SELECT COUNT(*) FROM tblfaculties WHERE status = 1 AND (email LIKE @search OR full_name LIKE @search)",
            .SEARCH_RESULT_QUERY = "SELECT st.id, st.username, full_name, gender, address, phone, email, department_id, d.department_name FROM tblfaculties st JOIN tbldepartments d ON st.department_id = d.id WHERE status = 1 AND (email LIKE @search OR full_name LIKE @search) ORDER BY full_name ASC LIMIT @page, 30",
            .FETCH_ALL_QUERY = "SELECT id, department_name FROM tblfaculties ORDER BY department_name",
            .ARCHIVE_SEARCH_COUNT_QUERY = "SELECT COUNT(*) FROM tblfaculties WHERE status = 0 AND (email LIKE @search OR full_name LIKE @search)",
            .ARCHIVE_SEARCH_RESULT_QUERY = "SELECT st.id, st.username, full_name, gender, address, phone, email, department_id, d.department_name FROM tblfaculties st JOIN tbldepartments d ON st.department_id = d.id WHERE status = 0 AND (email LIKE @search OR full_name LIKE @search) ORDER BY full_name ASC LIMIT @page, 30",
            .UPDATE_QUERY = "UPDATE tblfaculties SET full_name = @full_name, gender = @gender, address = @address, email = @email, department_id = @did, status = 1 WHERE id = @id"
        }},
        {ADMIN, New QueryTable With {
            .ADD_QUERY = "INSERT INTO tbladmins (student_id, faculty_id) VALUES (@sid, @fid)",
            .DELETE_QUERY = "DELETE FROM tbladmins WHERE id = @id",
            .SEARCH_RESULT_QUERY = "SELECT a.id, full_name, CASE WHEN `role` = 0 THEN 'Super Admin' ELSE 'Assistant Librarian' END AS `role` FROM tbladmins a JOIN tblstudents s ON a.student_id = s.id UNION SELECT a.id, full_name, CASE WHEN `role` = 0 THEN 'Super Admin' ELSE 'Assistant Librarian' END AS `role` FROM tbladmins a JOIN tblfaculties f ON a.faculty_id = f.id WHERE full_name LIKE @search OR phone LIKE @search OR email LIKE @search ORDER BY full_name LIMIT @page, 30;",
            .SEARCH_COUNT_QUERY = "SELECT COUNT(*) FROM tbladmins a LEFT JOIN tblfaculties f ON a.faculty_id = f.id LEFT JOIN tblstudents s ON a.student_id = s.id WHERE full_name LIKE @search OR phone LIKE @search OR email LIKE @search"
        }},
        {BOOKCOPIES, New QueryTable With {
            .SEARCH_COUNT_QUERY = "SELECT COUNT(DISTINCT b.title) FROM tblbookcopies bc JOIN tblbooks b ON bc.book_id = b.id WHERE b.title LIKE @search OR b.isbn LIKE @search GROUP BY b.title, b.isbn ORDER BY b.title",
            .SEARCH_RESULT_QUERY = "SELECT 
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
                                        ORDER BY b.title LIMIT @page, 30;"
        }},
        {BOOKINVENTORY, New QueryTable With {
            .SEARCH_COUNT_QUERY = "SELECT COUNT(*) FROM tblbookcopies bc JOIN tblbooks b ON bc.book_id = b.id LEFT JOIN tbldonators d ON bc.donator_id = d.id LEFT JOIN tblsuppliers s ON bc.supplier_id = s.id WHERE b.title LIKE @search OR b.isbn LIKE @search ORDER BY b.title",
            .SEARCH_RESULT_QUERY = "SELECT bc.id, b.title, b.isbn, bc.accession_no, d.name donator_name, s.name supplier_name, price FROM tblbookcopies bc JOIN tblbooks b ON bc.book_id = b.id LEFT JOIN tbldonators d ON bc.donator_id = d.id LEFT JOIN tblsuppliers s ON bc.supplier_id = s.id WHERE b.title LIKE @search OR b.isbn LIKE @search ORDER BY b.title ASC LIMIT @page, 30;",
            .UPDATE_QUERY = "UPDATE tblbookcopies SET price = @price WHERE id = @id"
        }},
        {TRANSACTION, New QueryTable},
        {BOOKLOSTDAMAGE, New QueryTable With {
            .SEARCH_COUNT_QUERY = "SELECT COUNT(*)
                                    FROM tblborrowheaders bh
                                    JOIN tblborrowedcopies bc ON bh.id = bc.header_id
                                    JOIN tblbookcopies c ON bc.copy_id = c.id
                                    JOIN tblbooks b ON c.book_id = b.id
                                    LEFT JOIN tblstudents s ON bh.student_id = s.id
                                    LEFT JOIN tblfaculties f ON bh.faculty_id = f.id
                                    WHERE bc.returned_condition = 2 OR bc.returned_condition = 1;",
            .SEARCH_RESULT_QUERY = "SELECT c.accession_no, bh.circulation_no , b.title,
                                    CASE WHEN bc.borrowed_condition = 0 THEN 'Good' ELSE (CASE WHEN bc.borrowed_condition = 1 THEN 'Damaged' ELSE 'Lost' END) END AS borrowed_condition,
                                    CASE WHEN bc.returned_condition = 0 THEN 'Good' ELSE (CASE WHEN bc.returned_condition = 1 THEN 'Damaged' ELSE 'Lost' END) END AS returned_condition,
                                    CASE WHEN bh.student_id IS NULL THEN f.full_name ELSE s.full_name END AS borrower_name
                                    FROM tblborrowheaders bh
                                    JOIN tblborrowedcopies bc ON bh.id = bc.header_id
                                    JOIN tblbookcopies c ON bc.copy_id = c.id
                                    JOIN tblbooks b ON c.book_id = b.id
                                    LEFT JOIN tblstudents s ON bh.student_id = s.id
                                    LEFT JOIN tblfaculties f ON bh.faculty_id = f.id
                                    WHERE bc.returned_condition = 2 OR bc.returned_condition = 1;"
        }}
    }

    Public Function CreateQueryTable(type As QueryType) As QueryTable
        Return Registry.Item(type)
    End Function
End Module
