Imports LMS.QueryTableType

Public Class AccountImport
    Inherits ExcelDataLoader

    Sub New(acctype As QueryTableType)
        DBHANDLER = New ImportDBHandler()
        _requiredFields = {DEPARTMENT_QUERY_TABLE, YEARLEVEL_QUERY_TABLE, SECTION_QUERY_TABLE, acctype}
    End Sub

    Public Overrides Function DataFactory(type As QueryTableType, drow As DataRow) As Dictionary(Of String, String)
        Throw New NotImplementedException()
    End Function
End Class
