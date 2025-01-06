Imports Spire.Xls

Public MustInherit Class ExcelDataLoader

    Public DBHANDLER As ImportDBHandler
    Protected _requiredFields As QueryTableType()

    ''' <summary>
    ''' Loads all the data from the excel file.
    ''' </summary>
    ''' <param name="path">A file path of the excel file.</param>
    ''' <returns>A dictionary containing all the data of the excel</returns>
    Public Shared Async Function ReadData(path As String) As Task(Of Dictionary(Of String, DataTable))
        Dim data As New Dictionary(Of String, DataTable)
        Await Task.Run(Sub()
                           Using workbook As New Workbook
                               Try
                                   workbook.LoadFromFile(path)

                                   For Each worksheet As Worksheet In workbook.Worksheets
                                       Dim dt As DataTable = worksheet.ExportDataTable()
                                       dt.Columns.Add("Status")
                                       For Each drow As DataRow In dt.Rows
                                           drow.Item("Status") = "Ready"
                                       Next
                                       'If dt.Columns.IndexOf("Status") <> dt.Columns.Count - 1 Then
                                       '    dt.Columns("Status").SetOrdinal(dt.Columns.Count - 1)
                                       'End If
                                       data.Add(worksheet.Name, dt)
                                   Next

                               Catch ex As Exception
                                   Logger.Logger(ex)
                               End Try
                           End Using
                       End Sub)
        Return data
    End Function

    ''' <summary>
    ''' Checks if the file is valid excel file.
    ''' </summary>
    ''' <param name="path">Path to the excel file.</param>
    ''' <returns></returns>
    Public Function IsValid(path As String) As Boolean
        If String.IsNullOrEmpty(path) OrElse Not path.EndsWith(".xlsx") Then
            Return False
        End If

        Using workbook As New Workbook
            Try
                workbook.LoadFromFile(path)

                Dim sheetNames As New List(Of String)
                For Each wsheet As Worksheet In workbook.Worksheets
                    sheetNames.Add(wsheet.Name.ToLower)
                Next

                Return _requiredFields.All(Function(type)
                                               Dim typeField = GetType(QueryTableType).GetField(type.ToString())
                                               Dim sheetAttrib As SheetNameMapping = CType(Attribute.GetCustomAttribute(typeField, GetType(SheetNameMapping)), SheetNameMapping)
                                               Dim colAttrib As ColumnMapping = CType(Attribute.GetCustomAttribute(typeField, GetType(ColumnMapping)), ColumnMapping)

                                               If sheetNames.Contains(sheetAttrib.SheetName.ToLower) Then
                                                   Dim dt As DataTable = workbook.Worksheets(sheetAttrib.SheetName).ExportDataTable
                                                   Return colAttrib.Columns.All(Function(x) dt.Columns.Contains(x))
                                               Else
                                                   Return False
                                               End If
                                           End Function)
            Catch ex As Exception
                Logger.Logger(ex)
            End Try
        End Using
        Return False
    End Function

    Public MustOverride Function DataFactory(type As QueryTableType, drow As DataRow) As Dictionary(Of String, String)
End Class
