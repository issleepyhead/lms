Imports LMS.QueryType

Public Class YearLevelDialog
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

    Private Sub YearLevelDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CMBDEPARTMENT.DataSource = DBOperations.FetchAll(DEPARTMENT)
        If Not IsNothing(_data) Then
            TXTNAME.Text = _data.Item("year_level")
            CMBDEPARTMENT.SelectedValue = _data.Item("department_id")
        End If
    End Sub

    Private Sub BTNSAVE_Click(sender As Object, e As EventArgs) Handles BTNSAVE.Click
        Dim inputs As Object() = {TXTNAME}
        For Each item In inputs
            errProvider.SetError(item, String.Empty)
        Next

        ' TODO CHECK IF THERE'S DEPARTMENT SELECTED
        ' TODO FIXED THE INPUT IN THE YEAR LEVEL IT SHOULD BE 
        Dim data As New Dictionary(Of String, String) From {
                {"@name", TXTNAME.Text},
                {"@did", CMBDEPARTMENT.SelectedValue},
                {"@id", If(IsNothing(_data), 0, _data.Item("id").ToString)}
        }

        DBOperations.ACTION_PARAMS = New Dictionary(Of String, String) From {
            {"@sid", If(My.Settings.student_id > 0, My.Settings.student_id, String.Empty)},
            {"@fid", If(My.Settings.faculty_id > 0, My.Settings.faculty_id, String.Empty)}
        }

        If IsNothing(_data) Then
            DBOperations.ACTION_PARAMS.Add("@action", "Added a new year level " & TXTNAME.Text)
            DBOperations.ACTION_PARAMS.Add("@type", LOGTYPE.ADD)
        Else
            DBOperations.ACTION_PARAMS.Add("@action", "Updated a year level " & TXTNAME.Text)
            DBOperations.ACTION_PARAMS.Add("@type", LOGTYPE.UPDATE)
        End If

        If DBOperations.Exists(YEARLEVEL, data) Then
            errProvider.SetError(TXTNAME, "This year level already exists.")
            Exit Sub
        End If

        If IsNothing(_data) Then
            If DBOperations.Add(YEARLEVEL, data) Then
                MessageBox.Show("Year level has been added successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed adding the year level.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Else
            If DBOperations.Update(YEARLEVEL, data) Then
                MessageBox.Show("Year level has been updated successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed updating the year level.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If
        Close()
    End Sub
End Class
