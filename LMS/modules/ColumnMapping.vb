<AttributeUsage(AttributeTargets.Field)>
Public Class ColumnMapping
    Inherits Attribute

    Public Columns As String()
    Public Sub New(columns As String())
        Me.Columns = columns
    End Sub
End Class
