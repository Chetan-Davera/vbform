Imports System.Data.OleDb
Public Class Form1
    Dim da As OleDbDataAdapter
    Dim ds As DataSet
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call conn()

        Call FETCH_GRID()




    End Sub

    Public Sub FETCH_GRID()
        Dim a As String = "select * from ab ORDER BY partname ASC"
        da = New OleDbDataAdapter(a, con)
        ds = New DataSet()
        da.Fill(ds)
        DataGridView1.RowHeadersWidth = 60

        If ds.Tables(0).Rows.Count > 0 Then
            With DataGridView1
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .DataSource = ds.Tables(0)
              

                .Columns(0).HeaderText = "No"
                .Columns(1).HeaderText = "partname"
                .Columns(2).HeaderText = "partadd"
                .Columns(3).HeaderText = "partcity"
                .Columns(4).HeaderText = "partcontact"
                .Columns(5).HeaderText = "partno"

               
            End With
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        cust_id = 0

        Form2.Show()


    End Sub

   

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        


    End Sub

   
    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick

        If DataGridView1.Rows.Count = 0 Then
            MsgBox("No Party Selected", MsgBoxStyle.Critical)

            DataGridView1.Focus()
            Exit Sub
        End If

        If DataGridView1.SelectedRows(0).Cells(1).Value = "" Then
            MsgBox("No Party Selected", MsgBoxStyle.Critical)
            DataGridView1.Focus()
            Exit Sub
        End If

        cust_id = DataGridView1.SelectedRows(0).Cells(0).Value
      
        Form2.Show()

      



    End Sub

    Private Sub Panel3_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel3.Paint

    End Sub
End Class
