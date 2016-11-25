Public Class ChangeHomePage

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        My.Settings.Homepage = TextBox1.Text
    End Sub

    Private Sub Change_Home_Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = My.Settings.Homepage
    End Sub
End Class