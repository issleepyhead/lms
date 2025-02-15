<AttributeUsage(AttributeTargets.Field, AllowMultiple:=True)>
Public Class ColumnMapping
    Inherits Attribute

    Public ReadOnly Property ColumnName As String
    Public ReadOnly Property Length As String

    Private ReadOnly CallBackValidator As Func(Of String, Boolean)

    Public Sub New(colName As String, length As Integer, vtype As VALIDATORTYPE)
        Me.ColumnName = colName
        Me.Length = length
        Me.CallBackValidator = GetValidatorType(vtype)
    End Sub

    Public Function Validate(input As String) As Boolean
        Return Not String.IsNullOrEmpty(input) AndAlso CallBackValidator.Invoke(input)
    End Function
End Class
