Public Class Form6

    Public Function form6load() As Integer
        Label3.Text = Form3.RandomId
        Return 0
    End Function
    Private Sub Form6_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label3.Text = Form3.RandomId

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
        Call dept.ClearTextBoxes(dept)
        dept.Show()
    End Sub
End Class