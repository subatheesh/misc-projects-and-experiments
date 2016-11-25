Public Class MultimediaPlayer
    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub PlayToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlayToolStripMenuItem.Click
        AxWindowsMediaPlayer1.URL = (OpenFileDialog1.FileName)
    End Sub

    Private Sub PlayToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlayToolStripMenuItem.Click
        AxWindowsMediaPlayer1.Ctlcontrols.play()
    End Sub

    Private Sub PauseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PauseToolStripMenuItem.Click
        AxWindowsMediaPlayer1.Ctlcontrols.pause()
        PlayToolStripMenuItem.Visible = True
    End Sub

    Private Sub StopToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StopToolStripMenuItem.Click
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
    End Sub

    Private Sub MultimediaPlayer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PlayToolStripMenuItem.Visible = True
    End Sub
End Class