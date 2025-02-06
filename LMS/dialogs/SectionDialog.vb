Imports LMS.QueryType

Public Class SectionDialog
    Private _data As DataRowView

    Sub New()
        InitializeComponent()
    End Sub

    Sub New(data As DataRowView)
        InitializeComponent()
        _data = data
        BTNSAVE.Text = "Update"
    End Sub

    Private Sub BTNSAVE_Click(sender As Object, e As EventArgs) Handles BTNSAVE.Click
        Dim inputs As Object() = {TXTSECTIONNAME, CMBYEARLEVEL}
        For Each item In inputs
            errProvider.SetError(item, String.Empty)
        Next

        Dim data As New Dictionary(Of String, String) From {
                {"@name", TXTSECTIONNAME.Text},
                {"@yid", CMBYEARLEVEL.SelectedValue},
                {"@id", If(IsNothing(_data), 0, _data.Item("id").ToString)}
        }

        DBOperations.ACTION_PARAMS = New Dictionary(Of String, String) From {
            {"@sid", If(My.Settings.student_id > 0, My.Settings.student_id, String.Empty)},
            {"@fid", If(My.Settings.faculty_id > 0, My.Settings.faculty_id, String.Empty)}
        }

        If IsNothing(_data) Then
            DBOperations.ACTION_PARAMS.Add("@action", "Added a new section " & TXTSECTIONNAME.Text)
            DBOperations.ACTION_PARAMS.Add("@type", LOGTYPE.ADD)
        Else
            DBOperations.ACTION_PARAMS.Add("@action", "Updated a section " & TXTSECTIONNAME.Text)
            DBOperations.ACTION_PARAMS.Add("@type", LOGTYPE.UPDATE)
        End If

        If DBOperations.Exists(SECTION, data) Then
            errProvider.SetError(TXTSECTIONNAME, "This section already exists.")
            Exit Sub
        End If

        If IsNothing(_data) Then
            If DBOperations.Add(SECTION, data) Then
                MessageBox.Show("Section has been added successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed adding the section.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Else
            If DBOperations.Update(SECTION, data) Then
                MessageBox.Show("Section has been updated successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed updating the section.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If
        Close()
    End Sub

    Private Sub SectionDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CMBYEARLEVEL.DataSource = DBOperations.FetchAll(YEARLEVEL)
        If Not IsNothing(_data) Then
            TXTSECTIONNAME.Text = _data.Item("name")
            CMBYEARLEVEL.SelectedValue = _data.Item("year_id")
        End If
    End Sub
End Class
