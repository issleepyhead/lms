Imports System.Text.RegularExpressions

Module Validator

    Const NUMBER_PATTERN As String = "^[\d]*$"
    Const DECI_NUMBER As String = "^\d+(\.\d+)?$"
    Const PHONE As String = ""

    Public Enum VALIDATORTYPE
        PHONE
        NAME
        EMAIL
        DECI_NUMBER
        NUMBER
    End Enum

    Public Sub NotAllowed(sender As Object, allowed_pattern As String)
        Try
            If String.IsNullOrEmpty(sender.Text) Then
                sender.Clear()
                Exit Sub
            End If

            Dim inputValue As String = sender.Text

            If Not Regex.IsMatch(inputValue, allowed_pattern) Then
                sender.Text = inputValue.Substring(0, inputValue.Length - 1)
                sender.SelectionStart = sender.Text.Length
            End If
        Catch ex As Exception
            Logger.Logger(ex)
        End Try
    End Sub


End Module
