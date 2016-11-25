Imports System.Data
Imports System.Data.SqlClient

Public Class Form5
    Public tempid As String
    Public Function rel() As Integer

        If dept.Dep = "Public" Then
            TextBox1.Text = dept.GID
            TextBox1.Enabled = False
        Else
            TextBox1.Enabled = True
        End If

        Return 0
    End Function
    Public Function Find() As Integer

        Dim owner As String = TextBox3.Text

        Dim id As String = TextBox1.Text

        Dim lno As String = TextBox2.Text

        Dim sqlcmd As String = "Select ID from lp9823.db_A.dbo.TA where [Owner Name]='" + owner + "' and [Lisence No]='" + lno + "' and ID= '" + id + "'"

        Using cn As New SqlConnection("Data Source=.;Initial Catalog=db_A;Integrated Security=True"),
              cmd As New SqlCommand(sqlcmd, cn)

            cn.Open()

            If cmd.ExecuteScalar() Then
                tempid = cmd.ExecuteScalar.ToString()
            Else
                tempid = ""
            End If

            cn.Close()
        End Using

        Return 0
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call Find()

        If tempid = "" Then
            Label4.Text = "Data Not Found"

        ElseIf tempid Then

            Label4.Text = "."
            Call dept.ClearTextBoxes(Me)
            Me.Hide()

            If Form2.selecteditem = "Modify Record" Then
                Call dept.ClearTextBoxes(Form1)
                Form1.form1load()
                Form1.Display()
                Form1.Show()

            ElseIf Form2.selecteditem = "Display Record" Then
                Call dept.ClearTextBoxes(Form7)
                Form7.form7load()
                Form7.Display()
                Form7.Show()

            ElseIf Form2.selecteditem = "Delete Record" Then
                Call dept.ClearTextBoxes(Form8)
                Form8.form8load()
                Form8.Display()
                Form8.Show()

            End If
        End If
    End Sub

    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call rel()
    End Sub

   
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Me.Hide()
        dept.ClearTextBoxes(dept)
        Label4.Text = "."
        dept.ClearTextBoxes(Me)
        dept.Show()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Hide()
        dept.ClearTextBoxes(Form2)
        dept.ClearTextBoxes(Me)
        Call Form2.fresh()
        Form2.Show()
    End Sub
End Class