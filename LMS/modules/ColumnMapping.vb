<AttributeUsage(AttributeTargets.Field)>
Public Class ColumnMapping
    Inherits Attribute

    Public ReadOnly Property Columns As String()
    Public ReadOnly Property Names As String()
    Public Sub New(columns As String(), names As String())
        Me.Columns = columns
        Me.Names = names
    End Sub
End Class
