
Public Class IPviewer

    Private Sub IPviewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = AxWinsock1.LocalIP

    End Sub
End Class