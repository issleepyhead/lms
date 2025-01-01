Module Utilities
    Public Function GenerateAccession() As String
        Dim highestAccession As Integer = ExecScalar("SELECT CAST(accession_no AS SIGNED) accession FROM tblbookcopies ORDER BY accession_no DESC LIMIT 1")
        If highestAccession = 0 Then
            highestAccession += 1
        End If
        Return highestAccession.ToString().PadLeft(10, "0")
    End Function
End Module
