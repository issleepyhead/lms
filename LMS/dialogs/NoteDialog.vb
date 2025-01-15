Imports System.Windows.Forms

Public Class NoteDialog
    Private id As Integer
    Sub New()
        InitializeComponent()
    End Sub

    Sub New(dialog As ReturnDialog)
        InitializeComponent()
        id = dialog._id
    End Sub



    Private Sub BTNSAVE_Click(sender As Object, e As EventArgs) Handles BTNSAVE.Click
        If ExecNonQuery("UPDATE tblborrowheaders SET note = @note WHERE id = @id", New Dictionary(Of String, String) From {{"@note", TXTNOTE.Text}, {"@id", id}}) > 0 Then
            MessageBox.Show("Note added successfully", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Close()
        End If
    End Sub

    Private Sub NoteDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim note As Object = ExecScalar("SELECT note FROM tblborrowheaders WHERE id = @id", New Dictionary(Of String, String) From {{"@id", id}})
        If Not IsDBNull(note) Then
            TXTNOTE.Text = note
        End If
    End Sub
End Class
