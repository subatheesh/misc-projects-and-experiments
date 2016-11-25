Imports System.Data
Imports System.Data.SqlClient
Public Class Form8
    Public TID As String

    Private Sub Form8_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        form8load()
    End Sub

    Public Function form8load() As Integer
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        RichTextBox1.Enabled = False
        TextBox3.Enabled = False
        TextBox5.Enabled = False
        TextBox4.Enabled = False
        TextBox6.Enabled = False
        TextBox7.Enabled = False
        TID = Form5.tempid
        TextBox1.Text = TID
        Display()

        If (Form12.Visible = True) Then
            Button1.Enabled = False
        End If

        Return 0
    End Function
    Public Function Display() As Integer

        Dim owner As String = "Select [Owner Name] from lp9823.db_A.dbo.TA where ID='" + TID + "'"

        Dim reg As String = "Select [Registration No] from lp9823.db_A.dbo.TA where ID='" + TID + "'"

        Dim lno As String = "Select [Lisence No] from lp9823.db_A.dbo.TA where ID='" + TID + "'"

        Dim pno As String = "Select [Phone No] from lp9823.db_A.dbo.TA where ID='" + TID + "'"

        Dim add As String = "Select [Address] from lp9823.db_A.dbo.TA where ID='" + TID + "'"

        Dim pass As String = "Select [Password] from lp9823.db_A.dbo.TA where ID='" + TID + "'"

        Dim model As String = "Select [Model] from lp9823.db_A.dbo.TA where ID='" + TID + "'"

        Using cn As New SqlConnection("Data Source=.;Initial Catalog=db_A;Integrated Security=True"),
              cmd_Owner As New SqlCommand(owner, cn),
              cmd_reg As New SqlCommand(reg, cn),
            cmd_lno As New SqlCommand(lno, cn),
            cmd_pno As New SqlCommand(pno, cn),
            cmd_add As New SqlCommand(add, cn),
            cmd_pass As New SqlCommand(pass, cn),
            cmd_model As New SqlCommand(pass, cn)

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
            If cmd_model.ExecuteScalar() IsNot Nothing Then
                TextBox5.Text = cmd_model.ExecuteScalar.ToString()
            End If


            cn.Close()
        End Using

        Return 0
    End Function

    Public Function Delete() As Integer

        Dim id As String = TextBox1.Text

        Dim sqlcmd1 As String = "Delete From lp9823.db_A.dbo.TA Where ID='" + id + "'"

        Dim sqlcmd2 As String = "Delete From lp9823.db_B.dbo.TB where ID='" + id + "'"

        Using cn1 As New SqlConnection("Data Source=.;Initial Catalog=db_A;Integrated Security=True"),
              cn2 As New SqlConnection("Data Source=.;Initial Catalog=db_B;Integrated Security=True"),
              cmd1 As New SqlCommand(sqlcmd1, cn1),
              cmd2 As New SqlCommand(sqlcmd2, cn2)

            cn1.Open()
            cn2.Open()

            cmd1.ExecuteNonQuery()
            cmd2.ExecuteNonQuery()

            cn2.Close()
            cn1.Close()
        End Using

        Return 0
    End Function

    Private Sub submit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles submit.Click
        Delete()
        Call dept.ClearTextBoxes(Me)
        Me.Hide()
        If (Form12.Visible = True) Then
            Form12.form12load()
        End If
        Form10.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call dept.ClearTextBoxes(Me)
        Me.Hide()
        Form5.rel()
        Form5.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
        dept.ClearTextBoxes(dept)
        dept.ClearTextBoxes(Me)
        dept.Show()
    End Sub
End Class