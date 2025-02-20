﻿Imports LMS.QueryType

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
        CMBGENRE.DataSource = DBOperations.FetchAll(GENRE)
        CMBPUBLISHER.DataSource = DBOperations.FetchAll(PUBLISHER)
        CMBLANGUAGE.DataSource = DBOperations.FetchAll(LANGUAGES)
        CMBAUTHOR.DataSource = DBOperations.FetchAll(AUTHOR)
        CMBCLASSIFICATION.DataSource = DBOperations.FetchAll(CLASSIFICATION)

        If Not IsNothing(_data) Then
            TXTISBN.Text = _data.Item("isbn")
            TXTTITLE.Text = _data.Item("title")
            CMBGENRE.SelectedValue = _data.Item("genre_id")
            CMBPUBLISHER.SelectedValue = _data.Item("publisher_id")
            CMBLANGUAGE.SelectedValue = _data.Item("language_id")
            CMBAUTHOR.SelectedValue = _data.Item("author_id")
            CMBCLASSIFICATION.SelectedValue = _data.Item("classification_id")
            NUMERICCOPY.Value = _data.Item("reserve_copy")
            NUMERICOVERDUEFACULTY.Value = _data.Item("fpenalty")
            NUMERICOVERDUESTUDENT.Value = _data.Item("spenalty")
            CMBCOVER.Text = _data.Item("book_cover")
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

        DBOperations.ACTION_PARAMS = New Dictionary(Of String, String) From {
            {"@sid", If(My.Settings.student_id > 0, My.Settings.student_id, String.Empty)},
            {"@fid", If(My.Settings.faculty_id > 0, My.Settings.faculty_id, String.Empty)}
        }

        If IsNothing(_data) Then
            DBOperations.ACTION_PARAMS.Add("@action", "Added a new book " & TXTTITLE.Text)
            DBOperations.ACTION_PARAMS.Add("@type", LOGTYPE.ADD)
        Else
            DBOperations.ACTION_PARAMS.Add("@action", "Updated a book " & TXTTITLE.Text)
            DBOperations.ACTION_PARAMS.Add("@type", LOGTYPE.UPDATE)
        End If

        If DBOperations.Exists(BOOK, data) Then
            errProvider.SetError(TXTISBN, "This book already exists.")
            Exit Sub
        End If

        If IsNothing(_data) Then
            If DBOperations.Add(BOOK, data) Then
                MessageBox.Show("Book has been added successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed adding the book.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Else
            If DBOperations.Update(BOOK, data) Then
                MessageBox.Show("Book has been updated successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed updating the book.", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If
        Close()
    End Sub

    Private Sub CHCKBOXNOISBN_CheckedChanged(sender As Object, e As EventArgs) Handles CHCKBOXNOISBN.CheckedChanged
        If CHCKBOXNOISBN.Checked Then
            TXTISBN.Text = GenerateISBN()
            TXTISBN.Enabled = False
        Else
            TXTISBN.Text = String.Empty
            TXTISBN.Enabled = True
        End If
    End Sub
End Class
