Imports LMS.QueryType

Public Class BookImportHandler
    Inherits BaseImportHandler

    Public Sub New()
        _required_field = BOOK
        _optional_field = {GENRE, AUTHOR, PUBLISHER, CLASSIFICATION, LANGUAGES}
    End Sub

    Public Overrides Function ImportData(data As Dictionary(Of String, DataTable)) As Object

    End Function
End Class
