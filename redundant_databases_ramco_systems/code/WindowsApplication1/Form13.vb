Public Class Form13
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
        Call dept.ClearTextBoxes(Form1)
        Form1.form1load()
        Form1.Display()
        Form1.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
        Call dept.ClearTextBoxes(Form8)
        Form8.form8load()
        Form8.Display()
        Form8.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Hide()
    End Sub
End Class