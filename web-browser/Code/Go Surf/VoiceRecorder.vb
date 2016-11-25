Public Class VoiceRecorder

    Private Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" (ByVal lpstrCommand As String, ByVal lpstrReturnString As String, ByVal uReturnLength As Integer, ByVal hwndCallback As Integer) As Integer
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Button1.Enabled = False
        Button2.Enabled = True
        mciSendString("open new Type waveaudio Alias recsound", "", 0, 0)
        mciSendString("record recsound", "", 0, 0)
        Label1.Text = "Recording..."
        Label1.Visible = True
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = True
        mciSendString("save recsound C:\Project\Extras\Sound\recsound.wav", "", 0, 0)
        mciSendString("close recsound", "", 0, 0)
        MsgBox("File Created: C:\Project\Extras\Sound\recsound.wav")
        Label1.Text = "Stopped..."
        Label1.Visible = False
        My.Computer.Audio.Stop()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Label1.Text = "Playing..."
        Label1.Visible = True
        My.Computer.Audio.Play("C:\Project\Extras\Sound\recsound.wav", AudioPlayMode.Background)
    End Sub

    Private Sub Form13_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub
End Class