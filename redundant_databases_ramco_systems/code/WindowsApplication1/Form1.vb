Imports System.Data
Imports System.Data.SqlClient

Public Class Form1
    Public TID As String
    Public Function form1load() As Integer

        Label2.Text = dept.Dep

        TextBox2.Enabled = False
        RichTextBox1.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox6.Enabled = False
        TextBox7.Enabled = False

        If dept.Dep = "Public" Then
            TextBox1.Text = dept.GID
            TextBox1.Enabled = False
            TID = dept.GID
            TextBox6.Enabled = True
            TextBox7.Enabled = True

        ElseIf dept.Dep = "RTO" Then
            TID = Form5.tempid
            TextBox1.Text = TID
            TextBox1.Enabled = False
            TextBox3.Enabled = True
            TextBox4.Enabled = True
            TextBox6.Enabled = True

        ElseIf dept.Dep = "Government" Then
            TID = Form5.tempid
            TextBox1.Text = TID
            TextBox1.Enabled = False
            TextBox2.Enabled = True
            RichTextBox1.Enabled = True
            TextBox3.Enabled = True
            TextBox4.Enabled = True
            TextBox6.Enabled = True

        End If

        If (Form12.Visible = True) Then
            Button1.Enabled = False
        End If

        Display()

        Return 0
    End Function
    Public Function Display() As Integer

        Dim owner As String = "Select [Owner Name] from lp9823.db_A.dbo.TA where ID='" + TID + "'"

        Dim reg As String = "Select [Registration No] from lp9823.db_A.dbo.TA where ID='" + TID + "'"

        Dim lno As String = "Select [Lisence No] from lp9823.db_A.dbo.TA where ID='" + TID + "'"

        Dim pno As String = "Select [Phone No] from lp9823.db_A.dbo.TA where ID='" + TID + "'"

        Dim add As String = "Select [Address] from lp9823.db_A.dbo.TA where ID='" + TID + "'"

        Dim pass As String = "Select [Password] from lp9823.db_A.dbo.TA where ID='" + TID + "'"

        Using cn As New SqlConnection("Data Source=.;Initial Catalog=db_A;Integrated Security=True"),
            cmd_Owner As New SqlCommand(owner, cn),
            cmd_reg As New SqlCommand(reg, cn),
            cmd_lno As New SqlCommand(lno, cn),
            cmd_pno As New SqlCommand(pno, cn),
            cmd_add As New SqlCommand(add, cn),
            cmd_pass As New SqlCommand(pass, cn)

            cn.Open()

            If cmd_Owner.ExecuteScalar() IsNot Nothing Then
                TextBox2.Text = cmd_Owner.ExecuteScalar.ToString()
            End If

            If cmd_add.ExecuteScalar() IsNot Nothing Then
                RichTextBox1.Text = cmd_add.ExecuteScalar.ToString()
            End If

            If cmd_lno.ExecuteScalar() IsNot Nothing Then
                TextBox3.Text = cmd_lno.ExecuteScalar.ToString()
            End If

            If cmd_reg.ExecuteScalar() IsNot Nothing Then
                TextBox4.Text = cmd_reg.ExecuteScalar.ToString()
            End If

            If cmd_pno.ExecuteScalar() IsNot Nothing Then
                TextBox6.Text = cmd_pno.ExecuteScalar.ToString()
            End If

            If cmd_pass.ExecuteScalar() IsNot Nothing Then
                TextBox7.Text = cmd_pass.ExecuteScalar.ToString()
            End If

            cn.Close()
        End Using

        Return 0
    End Function
    Public Function Modify() As Integer
        Dim owner As String = TextBox2.Text

        Dim reg As String = TextBox4.Text

        Dim lno As String = TextBox3.Text

        Dim pno As String = TextBox6.Text

        Dim add As String = RichTextBox1.Text

        Dim pass As String = TextBox7.Text

        Dim sqlcmd1 As String = "Update lp9823.db_A.dbo.TA set [Owner Name]='" + owner + "',[Registration No]='" + reg + "',[Lisence No]='" + lno + "',Address='" + add + "',[Phone No]=" + pno + ",Password='" + pass + "',Modify=1 where ID= '" + TID + "'"

        Dim sqlcmd2 As String = " insert into lp9823.db_B.dbo.TB select * from lp9823.db_A.dbo.TA where Modify=1 "

        Dim sqlcmd3 As String = " update lp9823.db_A.dbo.TA set Modify=0 where Modify=1 "

        Dim sqlcmd4 As String = "delete from lp9823.db_B.dbo.TB where ID in (select ID from lp9823.db_B.dbo.TB where Modify=1) and Modify=0"

        Dim sqlcmd5 As String = " update lp9823.db_B.dbo.TB set Modify=0 where Modify=1"

        Using cn1 As New SqlConnection("Data Source=.;Initial Catalog=db_A;Integrated Security=True"),
              cn2 As New SqlConnection("Data Source=.;Initial Catalog=db_B;Integrated Security=True"),
              cmd1 As New SqlCommand(sqlcmd1, cn1),
              cmd2 As New SqlCommand(sqlcmd2, cn2),
              cmd3 As New SqlCommand(sqlcmd3, cn1),
              cmd4 As New SqlCommand(sqlcmd4, cn2),
              cmd5 As New SqlCommand(sqlcmd5, cn2)

            cn1.Open()
            cn2.Open()

            cmd1.ExecuteNonQuery()
            cmd2.ExecuteNonQuery()
            cmd3.ExecuteNonQuery()
            cmd4.ExecuteNonQuery()
            cmd5.ExecuteNonQuery()

            cn2.Close()
            cn1.Close()
        End Using

        Return 0
    End Function

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        form1load()
    End Sub

    Private Sub submit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles submit.Click
        If RichTextBox1.Text <> "" And TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" And TextBox4.Text <> "" And TextBox6.Text <> "" And TextBox7.Text <> "" Then
            Label14.Text = "."
            Modify()

        Else
            Label14.Text = "Some Fields Missing !!"
        End If

        Call dept.ClearTextBoxes(Me)
        Me.Hide()
        If (Form12.Visible = True) Then
            Form12.form12load()
        End If
        Form9.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call dept.ClearTextBoxes(Me)
        Me.Hide()
        Form5.rel()
        Form5.Show()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
        Form12.Hide()
        dept.ClearTextBoxes(dept)
        Label4.Text = "."
        dept.ClearTextBoxes(Me)
        dept.Show()
    End Sub
End Class