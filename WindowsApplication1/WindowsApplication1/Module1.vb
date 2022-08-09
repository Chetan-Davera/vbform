Imports System.Data.OleDb

Module Module1
    Public con As New OleDbConnection
    Public cust_id As String

    Public Sub conn()
        If con.State = ConnectionState.Open Then con.Close()
        Dim path As String
        path = Application.StartupPath & "\Database1.accdb"

        con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\India\Desktop\ab\Database1.accdb"
        con.Open()
    End Sub
End Module
