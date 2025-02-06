Imports LMS.QueryType

Public Class DonatorDialog
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
        Dim inputs As Object() = {TXTADDRESS, TXTNAME}
        For Each item In inputs
            errProvider.SetError(item, String.Empty)
        Next

        Dim data As New Dictionary(Of String, String) From {
                {"@name", TXTNAME.Text},
                {"@address", TXTADDRESS.Text},
                {"@id", If(IsNothing(_data), 0, _data.Item("id").ToString)}
        }

        DBOperations.ACTION_PARAMS = New Dictionary(Of String, String) From {
            {"@sid", If(My.Settings.student_id > 0, My.Settings.student_id, String.Empty)},
            {"@fid", If(My.Settings.faculty_id > 0, My.Settings.faculty_id, String.Empty)}
        }

        If IsNothing(_data) Then
            DBOperations.ACTION_PARAMS.Add("@action", "Added a new donator " & TXTNAME.Text)
            DBOperations.ACTION_PARAMS.Add("@type", LOGTYPE.ADD)
        Else
            DBOperations.ACTION_PARAMS.Add("@action", "Updated a donator " & TXTNAME.Text)
            DBOperations.ACTION_PARAMS.Add("@type", LOGTYPE.UPDATE)
        End If

        If DBOperations.Exists(DONATOR, data) Then
            errProvider.SetError(TXTNAME, "This donator already exits.")
            Exit Sub
        End If

        If IsNothing(_data) Then
            If DBOperations.Add(DONATOR, data) Then
                MessageBox.Show("Donator has been added successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed adding the donator.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Else
            If DBOperations.Update(DONATOR, data) Then
                MessageBox.Show("Donator has been updated successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed updating the donator.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If
        Close()
    End Sub

    Private Sub GenreDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not IsNothing(_data) Then
            TXTNAME.Text = _data.Item("name")
            TXTADDRESS.Text = If(IsDBNull(_data.Item("address")), Nothing, _data.Item("address"))
        End If
    End Sub
End Class
