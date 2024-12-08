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
    End Sub
End Class
