Imports LMS.TransactionConnection
Imports Spire.Xls
Imports Spire.Xls.Core

' TODO MAKE IT A CLASSS
Module ImportUtils

    ' TODO FIX THIS INTO ASYNC BECASUE THERE MIGHT BE A LOT OF BOOKS TO BE IMPORTED
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

    Public Function ImportRowData(type As QueryTableType, data As Dictionary(Of String, String)) As Boolean
        Dim queries As MaintenanceQueries = QueryTableFactory.QueryTableFactory(type)
        If Not _ExistsTransaction(queries, data) Then
            Return _AddTransaction(queries, data)
        End If
        Return True
    End Function

    Private Function _ExistsTransaction(query As MaintenanceQueries, params As Dictionary(Of String, String)) As Boolean
        Return CInt(ExecScalarTransaction(query.EXISTS_QUERY_NO_ID, params)) > 0
    End Function

    Private Function _AddTransaction(query As MaintenanceQueries, params As Dictionary(Of String, String)) As Boolean
        Return ExecNonQueryTransaction(query.ADD_QUERY, params) > 0
    End Function

    ' TODO FIX THIS WAY OF IMPORTING FOR NOW JUST IMPLEMENT IT
    Public Function DataFactory(type As QueryTableType, drow As DataRow) As Dictionary(Of String, String)
        Dim data As New Dictionary(Of String, String)
        Select Case type
            Case QueryTableType.GENRE_QUERY_TABLE
                data.Add("@name", drow.Item("Name"))
                data.Add("@desc", drow.Item("Description"))
            Case QueryTableType.AUTHOR_QUERY_TABLE
                data.Add("@first_name", drow.Item("First Name"))
                data.Add("@last_name", drow.Item("Last Name"))
                data.Add("@gender", drow.Item("Gender"))
            Case QueryTableType.PUBLISHER_QUERY_TABLE
                data.Add("@name", drow.Item("Publisher Name"))
            Case QueryTableType.LANGUAGES_QUERY_TABLE
                data.Add("@language", drow.Item("Language"))
                data.Add("@code", drow.Item("Code"))
            Case QueryTableType.CLASSIFICATION_QUERY_TABLE
                data.Add("@dewey_no", drow.Item("Dewey Decimal"))
                data.Add("@classification", drow.Item("Classification"))
            Case QueryTableType.BOOK_QUERY_TABLE
                'Dim bookColumns As String() = {"Title", "ISBN", "Genre", "Publisher", "Language", "Author", "Classification", "Book Cover", "Reserve Copy"}
                Dim genid As Integer = ExecScalarTransaction("SELECT id FROM tblgenres WHERE name = @name", New Dictionary(Of String, String) From {{"@name", drow.Item("Genre")}})
                Dim pid As Integer = ExecScalarTransaction("SELECT id FROM tblpublishers WHERE LOWER(publisher_name) = LOWER(@name)", New Dictionary(Of String, String) From {{"@name", drow.Item("Publisher")}})
                Dim lid As Integer = ExecScalarTransaction("SELECT id FROM tbllanguages WHERE language = @name", New Dictionary(Of String, String) From {{"@name", drow.Item("Language")}})
                Dim cid As Integer = ExecScalarTransaction("SELECT id FROM tblclassifications WHERE classification = @name", New Dictionary(Of String, String) From {{"@name", drow.Item("Classification")}})
                Dim aid As Integer = ExecScalarTransaction("SELECT id FROM tblauthors WHERE CONCAT(first_name, ' ', last_name) = @name", New Dictionary(Of String, String) From {{"@name", drow.Item("Author")}})

                data.Add("@title", drow.Item("Title"))
                data.Add("@isbn", drow.Item("ISBN"))
                data.Add("@gid", genid.ToString)
                data.Add("@pid", pid.ToString)
                data.Add("@lid", lid)
                data.Add("@cid", cid)
                data.Add("@aid", aid)
                data.Add("@rcopy", drow.Item("Reserve Copy"))
                data.Add("@cover", drow.Item("Book Cover"))
                data.Add("@fpenalty", 0)
                data.Add("@spenalty", 0)
        End Select
        Return data
    End Function
    ''' <summary>
    ''' Checks if the excel file contains all the required sheet names for the excel file.
    ''' </summary>
    ''' <param name="path">A string path of the excel file.</param>
    ''' <returns>Boolean true of the excel file contains all the sheets names otherwise false.</returns>
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

    ''' <summary>
    ''' Checks if the sheets of the excel file contains all the required columns.
    ''' </summary>
    ''' <param name="path">A string path of the excel file.</param>
    ''' <returns>Boolean true of the excel file contains all the columns otherwise false.</returns>
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
