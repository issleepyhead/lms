Imports System.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine

Public Class ReportDialog
    Private _type As Integer
    Private _data As DataTable

    Sub New()
        InitializeComponent()
    End Sub

    Sub New(type As Integer, Optional data As DataTable = Nothing)
        InitializeComponent()
        _type = type
        _data = data
    End Sub

    Private Sub AccountDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Select Case _type
                Case 1

                    Dim rpt As New BorrowedBookReport()
                    rpt.SetDataSource(FillBookReport())
                    RPViewer.ReportSource = rpt
                    RPViewer.Refresh()
            End Select
        Catch ex As Exception

        End Try
    End Sub
End Class
