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
            .Name = "ColumnReturnCondition",
            .DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox,
            .FlatStyle = FlatStyle.System,
            .DataSource = bc
        }


        Dim header As DataTable = ExecFetch("SELECT bt.id, CASE WHEN bt.student_id IS NULL THEN ft.full_name ELSE st.full_name END AS full_name, circulation_no, overdue_date, borrow_date,
                            CASE WHEN a.student_id IS NULL THEN af.full_name ELSE ad.full_name END AS issued_by
                            FROM tblborrowheaders bt
                            LEFT JOIN tblstudents st ON bt.student_id = st.id
                            LEFT JOIN tblfaculties ft ON bt.faculty_id = ft.id
                            LEFT JOIN tbladmins a ON bt.issued_by = a.id
                            LEFT JOIN tblstudents ad ON a.student_id = ad.id
                            LEFT JOIN tblfaculties af ON a.faculty_id = af.id
                            WHERE bt.id = @id", New Dictionary(Of String, String) From {{"@id", _id}})

        If header.Rows.Count > 0 Then
            With header.Rows(0)
                LBLCIRCULATION.Text = .Item("circulation_no")
                LBLBORROWER.Text = .Item("full_name")
                LBLBORROWDATE.Text = .Item("borrow_date")
                LBLDUEDATE.Text = .Item("overdue_date")
                LBLISSUEDBY.Text = .Item("issued_by")
            End With
        End If


        Dim dt As DataTable = ExecFetch("SELECT bi.id, bc.accession_no, b.title, b.isbn, bi.borrowed_condition, bi.returned_condition
                                            FROM tblborrowheaders bh
                                            LEFT JOIN tblborrowedcopies bi ON bh.id = bi.header_id
                                            LEFT JOIN tblbookcopies bc ON bi.copy_id = bc.id
                                            LEFT JOIN tblbooks b ON bc.book_id = b.id
                                            WHERE bi.header_id = @id
                                            ORDER BY bc.accession_no, b.title", New Dictionary(Of String, String) From {{"@id", _id}})
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

    'Private Sub DGBORROWEDCOPIES_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs)
    '    Dim cmb As ComboBox = DirectCast(e.Control, ComboBox)
    '    cmb.IntegralHeight = False
    '    cmb.ItemHeight = 40
    '    cmb.DropDownHeight = 280
    'End Sub
End Class
