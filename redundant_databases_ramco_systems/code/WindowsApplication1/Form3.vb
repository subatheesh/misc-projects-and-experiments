Imports System.Data
Imports System.Data.SqlClient

Public Class Form3
    Public RandomId As Integer

    Public Function readid() As Integer
        RandomId = My.Computer.FileSystem.ReadAllText("C:\WindowsApplication1\Id.srb")
        Return 0

    End Function

    Public Function writeid() As Integer
        My.Computer.FileSystem.WriteAllText("C:\WindowsApplication1\Id.srb", RandomId, False)
        Return 0

    End Function


    Public Function Insert() As Integer

        RandomId = RandomId + 1

        Dim id As String = RandomId

        Dim owner As String = TextBox2.Text

        Dim reg As String = TextBox4.Text

        Dim lno As String = TextBox3.Text

        Dim pno As String = TextBox6.Text

        Dim add As String = RichTextBox1.Text

        Dim pass As String = TextBox7.Text

        Dim model As String = TextBox5.Text

        Dim sqlcmd1 As String = "insert into lp9823.db_A.dbo.TA values ('" + id + "','" + owner + "','" + reg + "','" + model + "','" + lno + "','" + pno + "','" + add + "','" + pass + "',getdate(),1)"

        Dim sqlcmd2 As String = " insert into lp9823.db_B.dbo.TB select * from lp9823.db_A.dbo.TA where Modify=1 "

        Dim sqlcmd3 As String = " update lp9823.db_A.dbo.TA set Modify=0 where Modify=1 "

        Dim sqlcmd4 As String = " update lp9823.db_B.dbo.TB set Modify=0 where Modify=1 "

        Using cn1 As New SqlConnection("Data Source=.;Initial Catalog=db_A;Integrated Security=True"),
            cn2 As New SqlConnection("Data Source=.;Initial Catalog=db_B;Integrated Security=True"),
              cmd1 As New SqlCommand(sqlcmd1, cn1),
              cmd2 As New SqlCommand(sqlcmd2, cn2),
              cmd3 As New SqlCommand(sqlcmd3, cn1),
              cmd4 As New SqlCommand(sqlcmd4, cn2)

            cn1.Open()
            cn2.Open()
            cmd1.ExecuteNonQuery()
            cmd2.ExecuteNonQuery()
            cmd3.ExecuteNonQuery()
            cmd4.ExecuteNonQuery()

            cn2.Close()
            cn1.Close()
        End Using

        Call writeid()
        Return 0
    End Function

    Private Sub submit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles submit.Click
        Insert()
        Call dept.ClearTextBoxes(Me)
        Me.Hide()
        Form6.form6load()
        Form6.Show()
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
        dept.ClearTextBoxes(dept)
        Label14.Text = "."
        dept.ClearTextBoxes(Me)
        dept.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
        dept.ClearTextBoxes(Form2)
        Label14.Text = "."
        dept.ClearTextBoxes(Me)
        Call Form2.fresh()
        Form2.Show()

    End Sub

End Class