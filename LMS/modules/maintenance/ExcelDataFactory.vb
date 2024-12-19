Imports LMS.QueryTableType
Module ExcelDataFactory
    Public Function DataFactory(type As QueryTableType, drow As DataRow) As Dictionary(Of String, String)
        Dim data As New Dictionary(Of String, String)
        Select Case type
            Case GENRE_QUERY_TABLE
                data.Add("@name", drow.Item("Name"))
                data.Add("@desc", drow.Item("Description"))
            Case AUTHOR_QUERY_TABLE
                data.Add("@first_name", drow.Item("First Name"))
                data.Add("@last_name", drow.Item("Last Name"))
                data.Add("@gender", drow.Item("Gender"))
            Case PUBLISHER_QUERY_TABLE
                data.Add("@name", drow.Item("Publisher Name"))
            Case LANGUAGES_QUERY_TABLE
                data.Add("@language", drow.Item("Language"))
                data.Add("@code", drow.Item("Code"))
            Case CLASSIFICATION_QUERY_TABLE
                data.Add("@dewey_no", drow.Item("Dewey Decimal"))
                data.Add("@classification", drow.Item("Classification"))
            Case BOOK_QUERY_TABLE
                'Dim bookColumns As String() = {"Title", "ISBN", "Genre", "Publisher", "Language", "Author", "Classification", "Book Cover", "Reserve Copy"}
                'Dim genid As Integer = ExecScalarTransaction("SELECT id FROM tblgenres WHERE name = @name", New Dictionary(Of String, String) From {{"@name", drow.Item("Genre")}})
                'Dim pid As Integer = ExecScalarTransaction("SELECT id FROM tblpublishers WHERE LOWER(publisher_name) = LOWER(@name)", New Dictionary(Of String, String) From {{"@name", drow.Item("Publisher")}})
                'Dim lid As Integer = ExecScalarTransaction("SELECT id FROM tbllanguages WHERE language = @name", New Dictionary(Of String, String) From {{"@name", drow.Item("Language")}})
                'Dim cid As Integer = ExecScalarTransaction("SELECT id FROM tblclassifications WHERE classification = @name", New Dictionary(Of String, String) From {{"@name", drow.Item("Classification")}})
                'Dim aid As Integer = ExecScalarTransaction("SELECT id FROM tblauthors WHERE CONCAT(first_name, ' ', last_name) = @name", New Dictionary(Of String, String) From {{"@name", drow.Item("Author")}})

                'data.Add("@title", drow.Item("Title"))
                'data.Add("@isbn", drow.Item("ISBN"))
                'data.Add("@gid", genid.ToString)
                'data.Add("@pid", pid.ToString)
                'data.Add("@lid", lid)
                'data.Add("@cid", cid)
                'data.Add("@aid", aid)
                'data.Add("@rcopy", drow.Item("Reserve Copy"))
                'data.Add("@cover", drow.Item("Book Cover"))
                'data.Add("@fpenalty", 0)
                'data.Add("@spenalty", 0)
        End Select
        Return data
    End Function
End Module
