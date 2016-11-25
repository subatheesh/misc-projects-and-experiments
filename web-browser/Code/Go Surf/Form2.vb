Public Class Form2

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form1.Show()
        CType(Form1.TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Navigate("http://www.youtube.com")
    End Sub
End Class