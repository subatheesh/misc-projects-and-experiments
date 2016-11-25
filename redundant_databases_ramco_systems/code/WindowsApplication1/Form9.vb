Public Class Form9

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
        If (Form12.Visible = False) Then
            Call dept.ClearTextBoxes(dept)
            dept.Show()
        End If
    End Sub
End Class