Imports System.Text.RegularExpressions

Module Validator

    Public Const NUMBER_PATTERN As String = "^[\d]*$"
    Public Const DECI_NUMBER_PATTERN As String = "^\d+(\.\d+)?$"
    Public Const PHONE_PATTERN As String = "^(09[0-9]{2}[- ]?[0-9]{{3}[- ]?[0-9]{4})$|^(\63[0-9]{3}[- ]?[0-9]{3}[- ]?[0-9]{4})$"
    Public Const EMAIL_PATTERN As String = "^[a-zA-Z0-9]._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"

    Public Const NAME_PATTERN As String = "^[a-zA-Z][a-zA-Z-'\s]*$"
    Public Const CHARCTERS_PATTERN As String = "^[a-zA-Z\s]*$"
    Public Const ALPHANUMERIC_PATTERN As String = "^[a-zA-Z][a-zA-Z0-9\s]*$"
    Public Const CHARACTERS_AND_SYMBOLS_PATTERN As String = "^[a-zA-Z][a-zA-Z\p{P}\s]*$"
    Public Const ALL_CHARACTERS_PATTERN As String = "^[a-zA-Z][a-zA-Z0-9\p{P}\s]*$"


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

    ''' <summary>
    ''' Check if the pattern matches the input.
    ''' </summary>
    ''' <param name="input">Input string to match against</param>
    ''' <param name="pattern">Pattern to check if match</param>
    ''' <returns>True if input matches the pattern false otherwise.</returns>
    Public Function MatchPattern(input As String, pattern As String) As Boolean
        Try
            Return Regex.IsMatch(input, pattern)
        Catch ex As Exception
            Logger.Logger(ex)
        End Try
        Return False
    End Function

    Public Function RemoveSpaces(input As String) As String
        If Not String.IsNullOrEmpty(input) Then
            Dim sanitized As String = Regex.Replace(input.Trim(), "\s{2,}", " ")
            Return Char.ToUpper(sanitized(0)) & sanitized.Substring(1)
        Else
            Return input
        End If
    End Function
End Module
