Imports LMS.QueryType

Public Class DepartmentDialog
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
        Dim inputs As Object() = {TXTNAME}
        For Each item In inputs
            errProvider.SetError(item, String.Empty)
        Next

        Dim data As New Dictionary(Of String, String) From {
                {"@name", TXTNAME.Text},
                {"@id", If(IsNothing(_data), 0, _data.Item("id").ToString)}
        }

        If DBOperations.Exists(DEPARTMENT, data) Then
            errProvider.SetError(TXTNAME, "This department already exists.")
            Exit Sub
        End If

        If IsNothing(_data) Then
            If DBOperations.Add(DEPARTMENT, data) Then
                MessageBox.Show("Department has been added successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed adding the department.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Else
            If DBOperations.Update(DEPARTMENT, data) Then
                MessageBox.Show("Department has been updated successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed updating the department.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If
        Close()
    End Sub

    Private Sub DepartmentDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not IsNothing(_data) Then
            TXTNAME.Text = _data.Item("department_name")
        End If
    End Sub

End Class
