Imports System.Reflection
Imports Spire.Xls

Module ExcelFileHandler
    Public Function IsExtensionValid(path As String) As Boolean
        Return path.EndsWith(".xlsx")
    End Function

    Public Async Function ReadExcelFile(path As String) As Task(Of Dictionary(Of String, DataTable))
        Dim data As New Dictionary(Of String, DataTable)
        Dim fields As FieldInfo() = GetType(QueryType).GetFields()
        Try
            Await Task.Run(Sub()
                               Using workbook As New Workbook
                                   Try
                                       workbook.LoadFromFile(path)

                                       For Each worksheet As Worksheet In workbook.Worksheets
                                           For Each field As FieldInfo In fields
                                               If field.IsLiteral Then
                                                   Dim sheetName As SheetNameMapping = CType(Attribute.GetCustomAttribute(field, GetType(SheetNameMapping)), SheetNameMapping)
                                                   If Not IsNothing(sheetName) AndAlso worksheet.Name = sheetName.SheetName Then
                                                       Dim esheet As New ExcelSheetHandler(worksheet, DirectCast([Enum].Parse(GetType(QueryType), field.Name), QueryType))
                                                       If esheet.IsValidColumns() Then
                                                           data.Add(sheetName.SheetName, esheet.ReadData)
                                                           Exit For
                                                       End If
                                                   End If
                                               End If
                                           Next
                                       Next
                                   Catch ex As Exception
                                       Logger.Logger(ex)
                                   End Try
                               End Using
                           End Sub)
        Catch ex As Exception
            Logger.Logger(ex)
        End Try
        Return data
    End Function
End Module
