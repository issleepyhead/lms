Imports LMS.QueryType

Public Class StudentDialog
    Private _data As DataRowView

    Sub New()
        InitializeComponent()
    End Sub

    Sub New(data As DataRowView)
        InitializeComponent()
        _data = data
    End Sub

    Private Sub StudentDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CMBYEARLEVEL.DataSource = DBOperations.FetchAll(YEARLEVEL)
        If Not IsNothing(_data) Then
            TXTLRN.Text = _data.Row("lrn")
            TXTFULLNAME.Text = _data.Row("full_name")
            CMBGENDER.SelectedText = _data.Row("gender")
            TXTADDRESS.Text = If(IsDBNull(_data.Row("address")), Nothing, _data.Row("address"))
            TXTPHONE.Text = If(IsDBNull(_data.Row("phone")), Nothing, _data.Row("phone"))
            CMBYEARLEVEL.SelectedValue = _data.Item("year_id")
            TXTEMAIL.Text = If(IsDBNull(_data.Row("email")), Nothing, _data.Row("email"))
            CMBSECTION.SelectedValue = _data.Item("section_id")
        End If
    End Sub

    Private Sub CMBYEARLEVEL_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMBYEARLEVEL.SelectedIndexChanged
        If CMBYEARLEVEL.SelectedIndex <> -1 Then
            CMBSECTION.DataSource = DBOperations.FetchAll(SECTION, New Dictionary(Of String, String) From {{"@yid", CMBYEARLEVEL.SelectedValue.ToString}})
        End If
    End Sub

    Private Sub BTNSAVE_Click(sender As Object, e As EventArgs) Handles BTNSAVE.Click
        Dim inputs As Object() = {TXTLRN, TXTFULLNAME, TXTEMAIL}
        For Each item In inputs
            errProvider.SetError(item, String.Empty)
        Next

        Dim year As String = Date.Now.Year.ToString
        Dim firstLetterName As String = TXTFULLNAME.Text.ToUpper().Substring(0, 1)
        Dim namearray As String() = TXTFULLNAME.Text.Split(" "c)
        Dim lastName As String = namearray(namearray.Length - 1)

        Dim data As New Dictionary(Of String, String) From {
                {"@id", If(IsNothing(_data), 0, _data.Item("id").ToString)},
                {"@lrn", TXTLRN.Text},
                {"@full_name", TXTFULLNAME.Text},
                {"@gender", CMBGENDER.Text},
                {"@address", TXTADDRESS.Text},
                {"@phone", TXTPHONE.Text},
                {"@email", TXTEMAIL.Text},
                {"@sid", CMBSECTION.SelectedValue},
                {"@passwd", BCrypt.Net.BCrypt.HashPassword(firstLetterName & lastName & year)}
        }

        If DBOperations.Exists(STUDENT, data) Then
            errProvider.SetError(TXTLRN, "This LRN already exists.")
            Exit Sub
        End If

        If IsNothing(_data) Then
            If DBOperations.Add(STUDENT, data) Then
                MessageBox.Show("Student has been added successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed adding the student.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Else
            If DBOperations.Update(STUDENT, data) Then
                MessageBox.Show("Student has been updated successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed updating the student.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If
        Close()
    End Sub
End Class
