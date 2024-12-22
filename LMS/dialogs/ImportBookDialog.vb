Imports System.Windows.Forms
Imports LMS.My

Public Class ImportBookDialog
    Private path As String
    Private data As Dictionary(Of String, DataTable)
    Private _isHiding = False
    Private _importHandler As ExcelDataLoader

    Private Async Sub BTNSELECTFILE_Click(sender As Object, e As EventArgs) Handles BTNSELECTFILE.Click
        Using dialog As New OpenFileDialog
            If dialog.ShowDialog = DialogResult.OK Then
                If ExcelDataLoader.IsFileValid(dialog.FileName) Then
                    MessageBox.Show("Invalid excel file, this file doesn't contain the required sheets or columns.", "Invalid Excel File", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                BTNPREVIEW.Enabled = True
                path = dialog.FileName
                TXTPATH.Text = path
                data = Await ExcelDataLoader.ReadData(path)
            End If
        End Using
    End Sub

    Private Sub BTNPREVIEW_Click(sender As Object, e As EventArgs) Handles BTNPREVIEW.Click
        DGBOOK.DataSource = data.Item("Books")
    End Sub

    Private Sub ImportBookDialog_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not _isHiding Then
            If Not String.IsNullOrEmpty(path) OrElse Not IsNothing(DGBOOK.DataSource) Then
                If MessageBox.Show("Are you sure you want to discard changes?", "Discard Changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    DashboardForm.DialogInstances.Remove("importbook")
                Else
                    e.Cancel = True
                End If
            End If
        End If
        _isHiding = False
    End Sub

    Private Sub DGBOOK_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGBOOK.CellFormatting
        ' Check if the value in the current cell is greater than 25
        If e.ColumnIndex = DGBOOK.Columns.Count - 1 Then

            e.CellStyle.ForeColor = Color.White
            e.CellStyle.SelectionForeColor = Color.White
            If e.Value = "Ready" Then
                e.CellStyle.BackColor = Color.DodgerBlue
                e.CellStyle.SelectionBackColor = Color.DodgerBlue
            ElseIf e.Value = "Done" Then
                e.CellStyle.BackColor = Color.Green
                e.CellStyle.SelectionBackColor = Color.Green
            Else
                e.CellStyle.BackColor = Color.Red
                e.CellStyle.SelectionBackColor = Color.Red
            End If
        End If
    End Sub

    Private Sub BTNCANCEL_Click(sender As Object, e As EventArgs) Handles BTNCANCEL.Click
        If Not IsNothing(_importHandler) Then
            _importHandler.RollbackTransaction()
        End If
    End Sub

    Private Sub BTNHIDE_Click(sender As Object, e As EventArgs) Handles BTNHIDE.Click
        _isHiding = True
        Hide()
    End Sub

    Private Sub BTNIMPORT_Click(sender As Object, e As EventArgs) Handles BTNIMPORT.Click
        _importHandler = New ExcelDataLoader()
    End Sub
End Class
