
Public NotInheritable Class SplashScreen1
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Me.ProgressBar1.Value = Me.ProgressBar1.Maximum Then
            Me.Hide()
            dept.Show()
            Timer1.Enabled = False
        Else
            Me.ProgressBar1.Value += 1
        End If
    End Sub
End Class
