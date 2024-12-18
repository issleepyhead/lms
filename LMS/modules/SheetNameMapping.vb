<AttributeUsage(AttributeTargets.Field)>
Public Class SheetNameMapping
    Inherits Attribute

    Public Property SheetName As String

    Public Sub New(sheetName As String)
        Me.SheetName = sheetName
    End Sub
End Class
