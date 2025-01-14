Imports System.Collections.ObjectModel
Imports System.Windows.Forms

Public Class ReturnDialog
    Private _id As Integer
    Private Class ConditionType
        Public Property id As Integer
        Public Property name As String
    End Class
    Sub New()
        InitializeComponent()
    End Sub

    Sub New(id As Integer)
        InitializeComponent()
        _id = id
    End Sub

    Private Sub ReturnDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim bc As New ObservableCollection(Of ConditionType) From {
            New ConditionType With {.id = BOOKCONDITIONTYPE.GOOD, .name = "Good"},
            New ConditionType With {.id = BOOKCONDITIONTYPE.DAMAGED, .name = "Damaged"},
            New ConditionType With {.id = BOOKCONDITIONTYPE.LOST, .name = "Lost"}
        }

        Dim cmb As New DataGridViewComboBoxColumn With {
            .DisplayMember = NameOf(ConditionType.name),
            .ValueMember = NameOf(ConditionType.id),
            .HeaderText = "Return Condition",
            .Name = "ColumnReturnCondition"
        }




        Dim dt As DataTable = ExecFetch("SELECT bi.id, bc.accession_no, b.title, b.isbn, bi.borrowed_condition, bi.returned_condition
                                            FROM tblborrowheaders bh
                                            LEFT JOIN tblborrowedcopies bi ON bh.id = bi.header_id
                                            LEFT JOIN tblbookcopies bc ON bi.copy_id = bc.id
                                            LEFT JOIN tblbooks b ON bc.book_id = b.id
                                            ORDER BY bc.accession_no, b.title")
        DGBORROWEDCOPIES.DataSource = dt
        DGBORROWEDCOPIES.Columns.Add(cmb)
        DGBORROWEDCOPIES.Columns(NameOf(ColumnBtnReturn)).DisplayIndex = DGBORROWEDCOPIES.Columns.Count - 1
        DGBORROWEDCOPIES.Columns(NameOf(ColumnBorrowedCondition)).DisplayIndex = DGBORROWEDCOPIES.Columns.Count - 3
        DGBORROWEDCOPIES.Columns(cmb.Name).DisplayIndex = DGBORROWEDCOPIES.Columns.Count - 2
    End Sub

    Private Sub DGBORROWEDCOPIES_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGBORROWEDCOPIES.CellFormatting
        If e.ColumnIndex = ColumnBorrowedCond.Index Then
            If DGBORROWEDCOPIES.Rows(e.RowIndex).Cells(NameOf(ColumnBorrowedCond)).Value = BOOKCONDITIONTYPE.GOOD Then
                DGBORROWEDCOPIES.Rows(e.RowIndex).Cells(NameOf(ColumnBorrowedCondition)).Value = "Good"
            ElseIf DGBORROWEDCOPIES.Rows(e.RowIndex).Cells(NameOf(ColumnBorrowedCond)).Value = BOOKCONDITIONTYPE.DAMAGED Then
                DGBORROWEDCOPIES.Rows(e.RowIndex).Cells(NameOf(ColumnBorrowedCondition)).Value = "Damaged"
            Else
                DGBORROWEDCOPIES.Rows(e.RowIndex).Cells(NameOf(ColumnBorrowedCondition)).Value = "Lost"
            End If
        End If
    End Sub
End Class
