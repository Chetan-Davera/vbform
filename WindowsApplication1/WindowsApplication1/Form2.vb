Imports System.Data.OleDb

Public Class Form2

    Dim da As OleDbDataAdapter
    Dim ds As DataSet
    Dim dt As DataTable

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call conn()
        If Val(cust_id) > 0 Then
            Call load_data()
        End If
    End Sub

    Public Sub load_data()

        Dim query As String
        query = "select * from ab where id=" & Val(cust_id) & ""
        da = New OleDbDataAdapter(query, con)
        ds = New DataSet()

        da.Fill(ds)
        dt = ds.Tables(0)

        If dt.Rows.Count > 0 Then
            TextBox1.Text = ds.Tables(0).Rows(0).Item("partname").ToString
            TextBox2.Text = ds.Tables(0).Rows(0).Item("partadd").ToString
            TextBox3.Text = ds.Tables(0).Rows(0).Item("partcity").ToString
            TextBox4.Text = ds.Tables(0).Rows(0).Item("partcontact").ToString
            TextBox5.Text = ds.Tables(0).Rows(0).Item("partno").ToString

        End If









    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Call conn()
        If TextBox1.Text = "" Then
            MsgBox("Please Enter Name ", MsgBoxStyle.Critical)
            TextBox1.Focus()
            Exit Sub
        End If
        Dim query As String
        query = "update  ab set partname='" & TextBox1.Text & "', partadd='" & TextBox2.Text & "',partcity='" & TextBox3.Text & "',partcontact='" & TextBox4.Text & "',partno='" & TextBox5.Text & "' where id=" & Val(cust_id) & ""

        Dim cmd As OleDbCommand = New OleDbCommand(query, con)

        cmd.ExecuteNonQuery()

        Call Form1.FETCH_GRID()

        MsgBox("update Data")

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox1.Focus()
        cust_id = 0
        Me.Close()










    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call conn()

        If TextBox1.Text = "" Then
            MsgBox("Please Enter Name of Party", MsgBoxStyle.Critical)
            TextBox1.Focus()
            Exit Sub
        End If
        Dim query As String
        query = "insert into ab (partname,partadd,partcity,partcontact,partno)values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "')"
        Dim cmd As OleDbCommand = New OleDbCommand(query, con)
        cmd.ExecuteNonQuery()
        Call Form1.FETCH_GRID()

        MsgBox("Save Data")



        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox1.Focus()


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        cust_id = 0
        Me.Hide()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox1.Focus()


    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Call conn()
        If TextBox1.Text = "" Then
            MsgBox("Please Enter Name AND DELETE ", MsgBoxStyle.Critical)
            TextBox1.Focus()
            Exit Sub
        End If
        Dim query As String
        query = "delete from ab  where id=" & Val(cust_id) & ""

        Dim cmd As OleDbCommand = New OleDbCommand(query, con)

        cmd.ExecuteNonQuery()

        Call Form1.FETCH_GRID()

        MsgBox("DELETE ")
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox1.Focus()
        Me.Close()
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown, TextBox2.KeyDown, TextBox3.KeyDown, TextBox4.KeyDown, TextBox5.KeyDown

        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        Else
            Exit Sub

        End If
        e.SuppressKeyPress = True




    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class