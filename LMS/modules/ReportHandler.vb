
Imports MySql.Data.MySqlClient

Module ReportHandler
    Public Function FillBookReport() As DataTable
        Return ExecFetch("SELECT b.title, g.name genre, c.classification, COUNT(bbc.copy_id) borrowed_count
                            FROM tblbooks b
                            JOIN tblgenres g ON b.genre_id = g.id
                            JOIN tblclassifications c ON b.classification_id = c.id
                            LEFT JOIN tblbookcopies bc ON b.id = bc.book_id
                            LEFT JOIN tblborrowedcopies bbc ON bc.id = bbc.copy_id
                            GROUP BY b.title, g.name, c.classification
                            ORDER BY b.title")
    End Function

    Public Function FillExpenditureReport() As DataTable
        Return ExecFetch("SELECT b.title, COUNT(b.id) total_copies, SUM(bc.price) total_price
                                                FROM tblbooks b
                                                JOIN tblbookcopies bc ON b.id = bc.book_id
                                                GROUP BY b.title")
    End Function

    Public Function FillPenaltyReport() As DataTable
        Return ExecFetch("SELECT bh.circulation_no,
	               CASE WHEN bh.student_id IS NULL THEN f.full_name ELSE s.full_name END AS full_name,
                   bh.borrow_date,
                   bh.overdue_date,
                   @odays := DATEDIFF(NOW(), DATE_ADD(bh.overdue_date, INTERVAL 1 DAY)) overdue_days,
                   @penalty := CASE WHEN (SELECT gpenalty FROM tblappsettings LIMIT 1) = 1 THEN (CASE WHEN bh.student_id IS NULL THEN (SELECT fpenalty FROM tblappsettings) ELSE (SELECT spenalty FROM tblappsettings) END) ELSE (CASE WHEN bh.student_id IS NULL THEN b.fpenalty ELSE b.spenalty END) END AS penalty,
                   @odays * @penalty total_penalty
            FROM tblborrowheaders bh
            LEFT JOIN tblstudents s ON bh.student_id = s.id
            LEFT JOIN tblfaculties f ON bh.faculty_id = s.id
            JOIN tblborrowedcopies bbc ON bh.id = bbc.header_id
            JOIN tblbookcopies bc ON bbc.copy_id = bc.id 
            JOIN tblbooks b ON bc.book_id = b.id
            HAVING DATEDIFF(NOW(), DATE_ADD(bh.overdue_date, INTERVAL 1 DAY)) > 0
            ")
    End Function
End Module
