Imports LMS.TransactionConnection
Imports Spire.Xls
Imports Spire.Xls.Core

Module ImportUtils

    Public Function ReadData(path) As Dictionary(Of String, DataTable)
        Dim data As New Dictionary(Of String, DataTable)
        Using workbook As New Workbook
            workbook.LoadFromFile(path)

            For Each worksheet As Worksheet In workbook.Worksheets
                Dim dt As DataTable = worksheet.ExportDataTable()
                dt.Columns.Add("Status")
                For Each drow As DataRow In dt.Rows
                    drow.Item("Status") = "Ready"
                Next
                data.Add(worksheet.Name, dt)
            Next
        End Using
        Return data
    End Function

    Public Function IsValidSheets(path) As Boolean
        Dim sheetNames As String() = {"Genres", "Authors", "Publishers", "Classifications", "Languages", "Books"}
        Using workbook As New Workbook
            workbook.LoadFromFile(path)

            Dim wsheetNames As New List(Of String)
            For Each wsheet As Worksheet In workbook.Worksheets
                wsheetNames.Add(wsheet.Name.ToLower)
            Next

            Return sheetNames.All(Function(x) wsheetNames.Contains(x.ToLower))
        End Using
    End Function

    Public Function IsColumnValid(path) As Boolean
        Dim genreColumns As String() = {"Name", "Description"}
        Dim authorColumns As String() = {"First Name", "Last Name", "Gender"}
        Dim publisherColumns As String() = {"Publisher Name"}
        Dim classificationColumns As String() = {"Dewey Decimal", "Classification"}
        Dim languageColumns As String() = {"Language", "Code"}
        Dim bookColumns As String() = {"Title", "ISBN", "Genre", "Publisher", "Language", "Author", "Classification", "Book Cover", "Reserve Copy"}

        Dim sheetNames As String() = {"Genres", "Authors", "Publishers", "Classifications", "Languages", "Books"}
        Using workbook As New Workbook
            workbook.LoadFromFile(path)

            For Each sheetName As String In sheetNames
                Dim workSheet As Worksheet = workbook.Worksheets.Item(sheetName)
                Dim dt As DataTable = workSheet.ExportDataTable()
                Select Case sheetName
                    Case "Genres"
                        If Not genreColumns.All(Function(x) dt.Columns.Contains(x)) Then
                            Return False
                        End If
                    Case "Authors"
                        If Not authorColumns.All(Function(x) dt.Columns.Contains(x)) Then
                            Return False
                        End If
                    Case "Publishers"
                        If Not publisherColumns.All(Function(x) dt.Columns.Contains(x)) Then
                            Return False
                        End If
                    Case "Classifications"
                        If Not classificationColumns.All(Function(x) dt.Columns.Contains(x)) Then
                            Return False
                        End If
                    Case "Languages"
                        If Not languageColumns.All(Function(x) dt.Columns.Contains(x)) Then
                            Return False
                        End If
                    Case "Books"
                        If Not bookColumns.All(Function(x) dt.Columns.Contains(x)) Then
                            Return False
                        End If
                End Select
            Next
            Return True
        End Using

    End Function
End Module
