Imports System.Text.RegularExpressions

Module Validator

    Const NUMBER_PATTERN As String = "^[\d]*$"
    Const DECI_NUMBER_PATTERN As String = "^\d+(\.\d+)?$"
    Const PHONE_PATTERN As String = "^(09[0-9]{2}[- ]?[0-9]{{3}[- ]?[0-9]{4})$|^(\63[0-9]{3}[- ]?[0-9]{3}[- ]?[0-9]{4})$"
    Const EMAIL_PATTERN As String = "^[a-zA-Z0-9]._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"
    Const CHARCTERS_PATTERN As String = "^[a-zA-Z]*$"
    Const ALPHANUMERIC_PATTERN As String = "^[a-zA-Z0-9]*$"
    Const CHARACTERS_AND_SYMBOLS_PATTERN As String = "^[a-zA-Z\{P}"


    Public Enum VALIDATORTYPE
        PHONE
        ALL
        EMAIL
        DECI_NUMBER
        NUMBER
    End Enum

    ''' <summary>
    ''' Accepts only the allowed pattern in a control.
    ''' </summary>
    ''' <param name="sender">A control.</param>
    ''' <param name="allowed_pattern">Regex pattern of allowed characters</param>
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
