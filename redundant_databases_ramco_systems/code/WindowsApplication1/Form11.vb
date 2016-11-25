Imports System.Data
Imports System.Data.SqlClient
Public Class Form11
    Public Tempnum As Integer

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
        dept.ClearTextBoxes(Form2)
        dept.ClearTextBoxes(Me)
        Call Form2.fresh()
        Form2.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Hide()
        dept.ClearTextBoxes(dept)
        dept.ClearTextBoxes(Me)
        dept.Show()
    End Sub

    Public Function rnum() As Integer
        Dim rno As Integer
        Dim sqlcmd1 As String = "select count(*) from lp9823.db_A.dbo.TA"

        Using cn1 As New SqlConnection("Data Source=.;Initial Catalog=db_A;Integrated Security=True"),
              cmd1 As New SqlCommand(sqlcmd1, cn1)

            cn1.Open()
            rno = cmd1.ExecuteScalar.ToString()
            cn1.Close()
        End Using

        Return rno
    End Function

    Public Function form11load() As Integer
        Label2.Text = "Max number of records is " + rnum.ToString()
        Return 0
    End Function
    Private Sub Form11_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        form11load()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Tempnum = TextBox1.Text
        If (Tempnum > rnum()) Then
            Label2.ForeColor = Color.Red
        Else
            Label2.ForeColor = Color.Black
            Me.Hide()
            dept.ClearTextBoxes(Me)
            Form12.form12load()
            Form12.view()
            Form12.Show()
        End If
    End Sub
End Class