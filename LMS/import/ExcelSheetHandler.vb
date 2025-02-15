Imports Spire.Xls

Public Class ExcelSheetHandler
    Private _workSheet As Worksheet
    Private _type As QueryType
    Private _columns As New List(Of String)
    Private _validators As New Dictionary(Of String, ColumnMapping)
    Private attributes As Attribute()

    Public Sub New(workSheet As Worksheet, type As QueryType)
        Try
            _workSheet = workSheet
            _type = type

            attributes = _type.GetType.GetField(_type.ToString).GetCustomAttributes(GetType(ColumnMapping), False)
            For Each attr As Object In attributes
                If TypeOf (attr) Is ColumnMapping Then
                    Dim colData As ColumnMapping = CType(attr, ColumnMapping)
                    _validators.Add(colData.ColumnName, colData)
                End If
            Next

            Dim dataColumnns As DataColumnCollection = _workSheet.ExportDataTable().Columns
            For Each datacol As DataColumn In dataColumnns
                _columns.Add(datacol.ColumnName.ToLower)
            Next
        Catch ex As Exception
            Logger.Logger(ex)
        End Try
    End Sub

    Public Function IsValidColumns() As Boolean

        Dim columnAttribs As New List(Of String)
        For Each attr As Object In attributes
            If TypeOf (attr) Is ColumnMapping Then
                Dim colData As ColumnMapping = CType(attr, ColumnMapping)
                columnAttribs.Add(colData.ColumnName.ToLower)
            End If
        Next

        Return _columns.All(Function(col As String)
                                Return columnAttribs.Contains(col)
                            End Function)
    End Function

    Public Function ReadData() As DataTable
        Dim dt As DataTable = _workSheet.ExportDataTable()

        ' Get all the column field so we can use its validator
        Dim colMapping As New Dictionary(Of String, ColumnMapping)
        For Each attr As Object In attributes
            If TypeOf (attr) Is ColumnMapping Then
                Dim colData As ColumnMapping = CType(attr, ColumnMapping)
                colMapping.Add(colData.ColumnName, colData)
            End If
        Next

        'Process all the data and remove all the invalid rows
        Dim newdt As DataTable = dt.Clone()
        Dim colList As DataColumnCollection = dt.Columns
        For Each row As DataRow In dt.Rows
            Dim isValid As Boolean = True
            For Each col As DataColumn In colList
                Dim datacol As Object = row.Item(col.ColumnName)
                If IsDBNull(datacol) OrElse String.IsNullOrEmpty(datacol) OrElse Not colMapping.Item(col.ColumnName).Validate(datacol) Then
                    isValid = False
                    Exit For
                End If
            Next
            If isValid Then
                newdt.Rows.Add(row.ItemArray)
            End If
        Next

        newdt.Columns.Add("Status")
        For Each row As DataRow In newdt.Rows
            row.Item("Status") = "Ready"
        Next

        Return newdt
    End Function
End Class
