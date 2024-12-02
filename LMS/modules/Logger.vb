Imports System.IO

Module Logger

    Private ReadOnly LogFileLocation As String = "C:\Users\jomar\Documents"
    Public Enum LOGLEVEL
        INFO
        ERR
    End Enum

    Public Sub Logger(ex As Exception)
        LogWriter(CreateLogErrorInfo(ex))
    End Sub

    Public Function CreateLogErrorInfo(ex As Exception) As String
        Dim stackFrame As New StackTrace(ex, True)
        Return $"{Date.Now:dd/MM/yyyy - hh:mm:ss tt}" & vbLf &
               $"FUNCTION_NAME: {stackFrame.GetFrame(0).GetMethod()}" & vbLf &
               $"EXCEPTION_MESSAGE: {ex.Message}" & vbLf &
               $"LINE: {stackFrame.GetFrame(0).GetFileLineNumber()}" & vbLf &
               $"FILE: {stackFrame.GetFrame(0).GetFileName}" & vbLf
    End Function

    Public Sub LogWriter(message As String)
        Dim fileName As String = LogFileLocation & "\lms.log"
        Try
            If Directory.Exists(LogFileLocation) Then
                If Not File.Exists(fileName) Then
                    Using writer As New StreamWriter(File.Open(fileName, FileMode.OpenOrCreate))
                        writer.WriteLine(message)
                    End Using
                Else
                    Using writer As New StreamWriter(File.Open(fileName, FileMode.Append))
                        writer.WriteLine(message)
                    End Using
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Module
