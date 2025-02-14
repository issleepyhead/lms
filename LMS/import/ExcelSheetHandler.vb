Imports Spire.Xls

Public Class ExcelSheetHandler
    Private _workSheet As Worksheet
    Private _type As QueryType
    Private _columns As New List(Of String)
    Private _validators As Dictionary(Of String, ColumnMapping)

    Public Sub New(workSheet As Worksheet, type As QueryType)
        Try
            _workSheet = workSheet
            _type = type

            Dim attributes As Attribute() = GetType(QueryType).GetField(_type).GetCustomAttributes(GetType(ColumnMapping), False)
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

    Public Function ValidateColumns() As Boolean
        Dim attributes As Attribute() = GetType(QueryType).GetField(_type).GetCustomAttributes(GetType(ColumnMapping), False)

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


        Return New DataTable
    End Function
End Class
