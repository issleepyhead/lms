Imports System.Collections.ObjectModel
Imports System.Windows.Forms

Public Class ReturnDialog
    Public _id As Integer
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
                                                CASE WHEN a.student_id IS NULL THEN af.full_name ELSE ad.full_name END AS issued_by, CAST(now() AS DATE) - CAST(overdue_date AS DATE) overdue_days,
                                                bt.status, CASE WHEN CAST(now() AS DATE) - CAST(overdue_date AS DATE) < 1 THEN 0 ELSE CAST(now() AS DATE) - CAST(overdue_date AS DATE) * (SELECT CASE WHEN bt.student_id IS NULL THEN fpenalty ELSE spenalty END AS penalty FROM tblappsettings) END AS penalty
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

                Dim stat As Integer = .Item("status")
                If stat = 1 Then
                    LBLSTATUS.Text = "Active"
                ElseIf stat = 2 Then
                    LBLSTATUS.Text = "Overdue"
                Else
                    LBLSTATUS.Text = "Returned"
                End If

                Dim overdue_days As Integer = .Item("overdue_days")
                If overdue_days < 1 Then
                    LBLOVERDUEDAYS.Text = "None"
                Else
                    LBLOVERDUEDAYS.Text = overdue_days & " Day(s)"
                End If

                LBLPENALTY.Text = "₱ " & .Item("penalty")
            End With
        End If


        Dim dt As DataTable = ExecFetch("SELECT bi.id, bi.copy_id, bc.accession_no, b.title, b.isbn, bi.borrowed_condition, bi.returned_condition, bi.date_returned
                                            FROM tblborrowheaders bh
                                            LEFT JOIN tblborrowedcopies bi ON bh.id = bi.header_id
                                            LEFT JOIN tblbookcopies bc ON bi.copy_id = bc.id
                                            LEFT JOIN tblbooks b ON bc.book_id = b.id
                                            WHERE bi.header_id = @id
                                            ORDER BY bc.accession_no, b.title", New Dictionary(Of String, String) From {{"@id", _id}})
        DGBORROWEDCOPIES.DataSource = dt
        DGBORROWEDCOPIES.Columns.Add(cmb)
        DGBORROWEDCOPIES.Columns(NameOf(ColumnDateReturned)).DisplayIndex = DGBORROWEDCOPIES.Columns.Count - 2
        DGBORROWEDCOPIES.Columns(NameOf(ColumnBorrowedCondition)).DisplayIndex = DGBORROWEDCOPIES.Columns.Count - 3
        DGBORROWEDCOPIES.Columns(cmb.Name).DisplayIndex = DGBORROWEDCOPIES.Columns.Count - 1

        For Each row As DataGridViewRow In DGBORROWEDCOPIES.Rows
            Dim bound As DataRowView = TryCast(row.DataBoundItem, DataRowView)
            'row.Cells.Item("cmbCondition").Value = bound.Row.Item("return_condition")
            If Not IsDBNull(bound.Item("returned_condition")) Then
                row.Cells.Item(cmb.Name).Value = CInt(bound.Item("returned_condition"))
                row.Cells.Item(cmb.Name).ReadOnly = True
                row.Cells(NameOf(chckBoxBorrowCopies)).ReadOnly = True
            End If
        Next
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

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        For Each row As DataGridViewRow In DGBORROWEDCOPIES.Rows
            row.Cells(NameOf(chckBoxBorrowCopies)).Value = True
        Next
        DGBORROWEDCOPIES.EndEdit()
    End Sub

    Private Sub UnselectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnselectAllToolStripMenuItem.Click
        For Each row As DataGridViewRow In DGBORROWEDCOPIES.Rows
            row.Cells(NameOf(chckBoxBorrowCopies)).Value = False
        Next
        DGBORROWEDCOPIES.EndEdit()
    End Sub

    Private Sub ReturnAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnAllToolStripMenuItem.Click
        DGBORROWEDCOPIES.EndEdit()
        Dim collection As New List(Of Dictionary(Of String, String))
        For Each dt As DataGridViewRow In DGBORROWEDCOPIES.Rows
            If CBool(dt.Cells(NameOf(chckBoxBorrowCopies)).Value) Then
                If IsDBNull(dt.Cells(NameOf(ColumnReturnCond)).Value) AndAlso Not IsNothing(dt.Cells("ColumnReturnCondition").Value) Then
                    collection.Add(New Dictionary(Of String, String) From {{"@rcond", dt.Cells("ColumnReturnCondition").Value}, {"@id", dt.Cells("ColumnID").Value}, {"@cid", dt.Cells("ColumnCopyID").Value}})
                End If

                If IsDBNull(dt.Cells(NameOf(ColumnReturnCond)).Value) AndAlso IsNothing(dt.Cells("ColumnReturnCondition").Value) Then
                    MessageBox.Show("Please fill all the return condition first before returning.", "Return Condition Empty!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                    Exit Sub
                End If
            End If
        Next

        If ReturnBooks(_id, collection) Then
            MessageBox.Show("The books borrowed have been returned successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        Using dialog As New NoteDialog(Me)
            dialog.ShowDialog()
        End Using
    End Sub

    Private Sub ViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewToolStripMenuItem.Click
        Using dialog As New NoteDialog(Me)
            dialog.ShowDialog()
        End Using
    End Sub

    Private Sub BTNSAVE_Click(sender As Object, e As EventArgs) Handles BTNSAVE.Click
        DGBORROWEDCOPIES.EndEdit()
        Dim collection As New List(Of Dictionary(Of String, String))
        For Each dt As DataGridViewRow In DGBORROWEDCOPIES.Rows
            If IsDBNull(dt.Cells(NameOf(ColumnReturnCond)).Value) AndAlso Not IsNothing(dt.Cells("ColumnReturnCondition").Value) Then
                collection.Add(New Dictionary(Of String, String) From {{"@rcond", dt.Cells("ColumnReturnCondition").Value}, {"@id", dt.Cells("ColumnID").Value}, {"@cid", dt.Cells("ColumnCopyID").Value}})
            End If

            If IsDBNull(dt.Cells(NameOf(ColumnReturnCond)).Value) AndAlso IsNothing(dt.Cells("ColumnReturnCondition").Value) Then
                MessageBox.Show("Please fill all the return condition first before returning.", "Return Condition Empty!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Exit Sub
            End If
        Next

        If ReturnBooks(_id, collection) Then
            MessageBox.Show("The books borrowed have been returned successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            For Each row As DataGridViewRow In DGBORROWEDCOPIES.Rows
                row.Cells.Item("ColumnReturnCondition").ReadOnly = True
                row.Cells(NameOf(chckBoxBorrowCopies)).ReadOnly = True
            Next
        End If
    End Sub
End Class
