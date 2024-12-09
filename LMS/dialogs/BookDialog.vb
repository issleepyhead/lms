Imports System.Windows.Forms

Public Class BookDialog
    Private _data As DataRowView

    Sub New()
        InitializeComponent()
    End Sub

    Sub New(data As DataRowView)
        InitializeComponent()
        _data = data
    End Sub

    Private Sub BookDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CMBGENRE.DataSource = BaseMaintenance.FetchAll(QueryTableType.GENRE_QUERY_TABLE)
        CMBPUBLISHER.DataSource = BaseMaintenance.FetchAll(QueryTableType.PUBLISHER_QUERY_TABLE)
        CMBLANGUAGE.DataSource = BaseMaintenance.FetchAll(QueryTableType.LANGUAGES_QUERY_TABLE)
        CMBAUTHOR.DataSource = BaseMaintenance.FetchAll(QueryTableType.AUTHOR_QUERY_TABLE)
        CMBCLASSIFICATION.DataSource = BaseMaintenance.FetchAll(QueryTableType.CLASSIFICATION_QUERY_TABLE)

        If Not IsNothing(_data) Then
            TXTISBN.Text = _data.Item("isbn")
            TXTTITLE.Text = _data.Item("title")
            CMBGENRE.SelectedValue = _data.Item("genre_id")
            CMBPUBLISHER.SelectedValue = _data.Item("publisher_id")
            CMBLANGUAGE.SelectedValue = _data.Item("language_id")
            CMBAUTHOR.SelectedValue = _data.Item("author_id")
            CMBCLASSIFICATION.SelectedValue = _data.Item("classification_id")
        End If
    End Sub

    Private Sub BTNSAVE_Click(sender As Object, e As EventArgs) Handles BTNSAVE.Click
        Dim controls As Object() = {TXTISBN, TXTTITLE, CMBAUTHOR, CMBCLASSIFICATION, CMBGENRE, CMBLANGUAGE, CMBPUBLISHER}
        For Each cntrl In controls
            errProvider.SetError(cntrl, String.Empty)
        Next


        Dim data As New Dictionary(Of String, String) From {
                {"@title", TXTTITLE.Text},
                {"@isbn", TXTISBN.Text},
                {"@gid", CMBGENRE.SelectedValue},
                {"@aid", CMBAUTHOR.SelectedValue},
                {"@pid", CMBPUBLISHER.SelectedValue},
                {"@lid", CMBLANGUAGE.SelectedValue},
                {"@cid", CMBCLASSIFICATION.SelectedValue},
                {"@spenalty", NUMERICOVERDUESTUDENT.Value},
                {"@fpenalty", NUMERICOVERDUEFACULTY.Value},
                {"@rcopy", NUMERICCOPY.Value},
                {"@cover", CMBCOVER.Text},
                {"@id", If(IsNothing(_data), 0, _data.Item("id").ToString)}
        }

        If BaseMaintenance.Exists(QueryTableType.BOOK_QUERY_TABLE, data) Then
            errProvider.SetError(TXTISBN, "This book already exists.")
            Exit Sub
        End If

        If IsNothing(_data) Then
            If BaseMaintenance.Add(QueryTableType.BOOK_QUERY_TABLE, data) Then
                MessageBox.Show("Book has been added successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed adding the book.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Else
            If BaseMaintenance.Update(QueryTableType.BOOK_QUERY_TABLE, data) Then
                MessageBox.Show("Supplier has been updated successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed updating the supplier.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If
        Close()
    End Sub
End Class
