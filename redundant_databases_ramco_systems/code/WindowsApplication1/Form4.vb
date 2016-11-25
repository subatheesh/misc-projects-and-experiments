Imports System.Data
Imports System.Data.SqlClient
Public Class dept

    Public Sub ClearTextBoxes(ByVal frm As Form)

        For Each Control In frm.Controls
            If TypeOf Control Is TextBox Or TypeOf Control Is RichTextBox Or TypeOf Control Is ComboBox Then
                Control.Text = ""
            End If
            If TypeOf Control Is RadioButton Then
                Control.Checked = False
            End If
        Next Control

    End Sub

    Public Dep As String
    Public GID As String

    Public Function ValidateO() As Integer

        If TextBox1.Text <> "" And TextBox2.Text <> "" And ComboBox1.SelectedItem <> "" Then
            Button1.Enabled = True
        Else
            Button1.Enabled = False
        End If
        Dep = ComboBox1.Text
        GID = TextBox1.Text
        Return 0

    End Function

    Public Function Check() As Integer

        Dim id As String = TextBox1.Text

        Dim pass As String = TextBox2.Text

        Dim sqlcmd As String = "Select ID from lp9823.db_A.dbo.TA where [Password]='" + pass + "' and ID= '" + id + "'"

        Using cn As New SqlConnection("Data Source=.;Initial Catalog=db_A;Integrated Security=True"),
              cmd As New SqlCommand(sqlcmd, cn)

            cn.Open()

            If cmd.ExecuteScalar() Then
                ValidateO()
                Call Form2.fresh()
                Me.Hide()
                Call Me.ClearTextBoxes(Form2)
                Form2.Show()
                Label4.Text = "."
            Else
                Label4.Text = "Invalid Login"
            End If

            cn.Close()
        End Using

        Return 0
    End Function


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If (ComboBox1.SelectedItem = "Government" And TextBox1.Text = "govt" And TextBox2.Text = "govt") Or (ComboBox1.SelectedItem = "RTO" And TextBox1.Text = "rto" And TextBox2.Text = "rto") Then
            ValidateO()
            Call Form2.fresh()
            Me.Hide()
            Call Me.ClearTextBoxes(Form2)
            Form2.Show()
            Label4.Text = "."
        ElseIf (ComboBox1.SelectedItem = "Public") Then
            Check()
        Else
            Label4.Text = "Invalid Login"
        End If


    End Sub

    Private Sub dept_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Button1.Enabled = False
    End Sub

    Private Sub TextBox2_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBox2.MouseClick
        ValidateO()
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        ValidateO()
    End Sub

    Private Sub TextBox1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBox1.MouseClick
        ValidateO()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        ValidateO()
    End Sub

    Private Sub ComboBox1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ComboBox1.MouseClick
        ValidateO()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        ValidateO()
    End Sub

End Class