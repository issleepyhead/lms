<AttributeUsage(AttributeTargets.Field, AllowMultiple:=True)>
Public Class ColumnMapping
    Inherits Attribute

    Public ReadOnly Property ColumnName As String
    Public ReadOnly Property Length As String
    Public ReadOnly Property CallBackValidator As Func(Of String)
    Public Sub New(colName As String, length As Integer, ByRef Optional validator As Func(Of String) = Nothing)
        Me.ColumnName = colName
        Me.Length = length
        Me.CallBackValidator = validator
    End Sub
End Class
