Public MustInherit Class BaseImportHandler
    Protected _required_field As QueryType
    Protected _optional_field As QueryType()
    Public DBHANDLER As New ImportDBHandler()

    Public MustOverride Function ImportData(data As Dictionary(Of String, DataTable))
End Class
