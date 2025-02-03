Imports System.Net.Mail

Public Class NotificationHandler
    Private _receipt As String = Nothing
    Private _type As Integer = Nothing
    Private _message As String = Nothing
    Private _data As Dictionary(Of String, String) = Nothing


    Sub New(receipt As String, notificationType As Integer, data As Dictionary(Of String, String))
        _receipt = receipt
        _type = notificationType
        _data = data
    End Sub

    Private Sub ParseMessage()
        For Each kv As KeyValuePair(Of String, String) In _data
            _message = _message.Replace(kv.Key, kv.Value)
        Next
    End Sub

    Public Function Send() As Boolean
        ParseMessage()

        If My.Computer.Network.IsAvailable AndAlso Not String.IsNullOrEmpty(_receipt) Then
            Try
                Dim smtp As New SmtpClient With {
                    .UseDefaultCredentials = False,
                    .Credentials = New Net.NetworkCredential(My.Settings.email, My.Settings.email_pass),
                    .Port = 587,
                    .EnableSsl = True,
                    .Host = "smtp.gmail.com"
                }

                Dim e_mail = New MailMessage With {
                    .From = New MailAddress(My.Settings.email),
                    .Subject = "Library Management System",
                    .IsBodyHtml = False,
                    .Body = _message
                }
                e_mail.To.Add(_receipt)
                smtp.Send(e_mail)
                Return True
            Catch ex As Exception
                Logger.Logger(ex)
            End Try
        End If
        Return False
    End Function

End Class
