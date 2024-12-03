Imports System.Windows.Forms

Public Class AuthorDialog
    Private _data As DataRowView
    Private _id As Integer

    Sub New()
        InitializeComponent()
    End Sub

    Sub New(data As DataRowView)
        InitializeComponent()
        _data = data
        BTNSAVE.Text = "Update"
    End Sub

    Private Sub BTNSAVE_Click(sender As Object, e As EventArgs) Handles BTNSAVE.Click
        Dim inputs As Object() = {TXTFIRSTNAME, TXTLASTNAME, CMBGENDER}
        For Each item In inputs
            errProvider.SetError(item, String.Empty)
        Next

        Dim data As New Dictionary(Of String, String) From {
                {"@first_name", TXTFIRSTNAME.Text},
                {"@last_name", TXTLASTNAME.Text},
                {"@gender", CMBGENDER.Text},
                {"@id", If(IsNothing(_data), 0, _data.Item("id").ToString)}
        }

        If AuthorMaintenance.Exists(data) Then
            errProvider.SetError(TXTFIRSTNAME, "This author already exits.")
            errProvider.SetError(TXTLASTNAME, "This author already exits.")
            Exit Sub
        End If

        If IsNothing(_data) Then
            If AuthorMaintenance.Add(data) Then
                MessageBox.Show("Author has been added successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed adding the author.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Else
            If AuthorMaintenance.Update(data) Then
                MessageBox.Show("Author has been updated successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed updating the author.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If
        Close()
    End Sub

    Private Sub AuthorDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not IsNothing(_data) Then
            TXTFIRSTNAME.Text = _data.Item("first_name")
            TXTLASTNAME.Text = _data.Item("last_name")
            CMBGENDER.Text = _data.Item("gender")
        End If
    End Sub
End Class
