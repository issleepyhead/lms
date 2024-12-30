Imports LMS.QueryTableType
Imports Spire.Xls

Public Class BookImport
    Inherits ExcelDataLoader

    Sub New()
        DBHANDLER = New ImportDBHandler()
        _requiredFields = {GENRE_QUERY_TABLE, AUTHOR_QUERY_TABLE, PUBLISHER_QUERY_TABLE, CLASSIFICATION_QUERY_TABLE, LANGUAGES_QUERY_TABLE, BOOK_QUERY_TABLE}
    End Sub

    Public Overrides Function DataFactory(type As QueryTableType, drow As DataRow) As Dictionary(Of String, String)
        Dim typeField = GetType(QueryTableType).GetField(type.ToString())
        Dim sheetAttrib As SheetNameMapping = CType(Attribute.GetCustomAttribute(typeField, GetType(SheetNameMapping)), SheetNameMapping)
        Dim colAttrib As ColumnMapping = CType(Attribute.GetCustomAttribute(typeField, GetType(ColumnMapping)), ColumnMapping)
        Dim tempt As New Dictionary(Of String, String)

        Try
            Select Case type
                Case GENRE_QUERY_TABLE, AUTHOR_QUERY_TABLE, PUBLISHER_QUERY_TABLE, LANGUAGES_QUERY_TABLE, CLASSIFICATION_QUERY_TABLE

                    For i As Integer = 0 To colAttrib.Columns.Length - 1
                        tempt.Add(colAttrib.Names(i), drow.Item(colAttrib.Columns(i)))
                    Next
                    Return tempt
                Case BOOK_QUERY_TABLE
                    For i As Integer = 0 To colAttrib.Columns.Length - 1
                        tempt.Add(colAttrib.Names(i), drow.Item(colAttrib.Columns(i)))
                    Next

                    Dim genid As Integer = ExecScalar("SELECT id FROM tblgenres WHERE name = @name", New Dictionary(Of String, String) From {{"@name", drow.Item("Genre")}})
                    Dim pid As Integer = ExecScalar("SELECT id FROM tblpublishers WHERE LOWER(publisher_name) = LOWER(@name)", New Dictionary(Of String, String) From {{"@name", drow.Item("Publisher")}})
                    Dim lid As Integer = ExecScalar("SELECT id FROM tbllanguages WHERE language = @name", New Dictionary(Of String, String) From {{"@name", drow.Item("Language")}})
                    Dim cid As Integer = ExecScalar("SELECT id FROM tblclassifications WHERE classification = @name", New Dictionary(Of String, String) From {{"@name", drow.Item("Classification")}})
                    Dim aid As Integer = ExecScalar("SELECT id FROM tblauthors WHERE CONCAT(first_name, ' ', last_name) = @name", New Dictionary(Of String, String) From {{"@name", drow.Item("Author")}})

                    tempt.Item("@gid") = genid
                    tempt.Item("@pid") = pid
                    tempt.Item("@lid") = lid
                    tempt.Item("@cid") = cid
                    tempt.Item("@aid") = aid

                    tempt.Add("@spenalty", "0")
                    tempt.Add("@fpenalty", "0")
            End Select
        Catch ex As Exception
            Logger.Logger(ex)
        End Try

        Return tempt
    End Function
End Class
