Module Utilities
    Public Function GenerateAccession() As String
        Dim highestAccession As Integer = ExecScalar("SELECT CAST(accession_no AS SIGNED) accession FROM tblbookcopies ORDER BY accession_no DESC LIMIT 1")
        If highestAccession = 0 Then
            highestAccession += 1
        End If
        Return highestAccession.ToString().PadLeft(10, "0")
    End Function

    Public Function AddCopies(numOfCopies As Integer, isbn As String, price As Decimal, Optional donator_id As Integer = Nothing, Optional supplier_id As Integer = Nothing) As Boolean
        Dim book_id As Integer = ExecScalar("SELECT id FROM tblbooks WHERE isbn = @isbn", New Dictionary(Of String, String) From {{"@isbn", isbn}})
        Return ExecProcedure("AddBookCopies", New Dictionary(Of String, String) From {
            {"bid", book_id},
            {"number_of_copies", numOfCopies},
            {"pr", price},
            {"did", If(IsNothing(donator_id) OrElse donator_id = 0, String.Empty, donator_id)},
            {"sid", If(IsNothing(supplier_id) OrElse supplier_id = 0, String.Empty, supplier_id)}
        })
    End Function
End Module
