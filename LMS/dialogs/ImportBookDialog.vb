Imports System.Windows.Forms
Imports LMS.My

Public Class ImportBookDialog
    Private path As String
    Private data As Dictionary(Of String, DataTable)
    Private Sub BTNSELECTFILE_Click(sender As Object, e As EventArgs) Handles BTNSELECTFILE.Click
        Using dialog As New OpenFileDialog
            If dialog.ShowDialog = DialogResult.OK Then
                If Not IsValidSheets(dialog.FileName) Then
                    MessageBox.Show("Invalid excel file, this file doesn't contain the required sheets.", "Invalid Excel File", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                If Not IsColumnValid(dialog.FileName) Then
                    MessageBox.Show("Invalid sheet columns, this file doesn't contain the required columns of the sheet.", "Invalid Excel File", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                BTNPREVIEW.Enabled = True
                path = dialog.FileName
                TXTPATH.Text = path
                data = ReadData(path)
            End If
        End Using
    End Sub

    Private Sub BTNPREVIEW_Click(sender As Object, e As EventArgs) Handles BTNPREVIEW.Click
        DGBOOK.DataSource = data.Item("Books")
    End Sub

    Private Sub ImportBookDialog_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not String.IsNullOrEmpty(path) OrElse Not IsNothing(DGBOOK.DataSource) Then
            If MessageBox.Show("Are you sure you want to discard changes?", "Discard Changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                DashboardForm.DialogInstances.Remove("importbook")
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub DGBOOK_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGBOOK.CellFormatting
        ' Check if the value in the current cell is greater than 25
        If e.ColumnIndex = DGBOOK.Columns.Count - 1 Then

            e.CellStyle.ForeColor = Color.White
            e.CellStyle.SelectionForeColor = Color.White
            If e.Value = "Ready" Then
                e.CellStyle.BackColor = Color.DodgerBlue
                e.CellStyle.SelectionBackColor = Color.DodgerBlue
            Else e.Value = "Done"
                e.CellStyle.BackColor = Color.Green
                e.CellStyle.SelectionBackColor = Color.Green
            End If
        End If
    End Sub
End Class
