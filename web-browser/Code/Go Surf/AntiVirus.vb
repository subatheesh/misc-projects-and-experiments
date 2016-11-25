Public Class AntiVirus

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If My.Computer.FileSystem.FileExists("C:\WINDOWS\system32\hid.exe") Then ListBox1.Items.Add("FILENAME")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ListBox1.Items.Clear()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim targetfile As String
        targetfile = "C:\WINDOWS\system32\cmd.exe"
        Kill("C:\WINDOWS\system32\hid.exe")
        Label1.Text = "Deleting selected file(s), please wait."
        Timer1.Start()

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim TheRandom As New Random
        Timer1.Interval = TheRandom.Next(100, 1000)
        On Error Resume Next
        If ProgressBar1.Value >= ProgressBar1.Maximum Then
            Label2.Text = "Deleted selected file(s)"
        Else : ProgressBar1.Value += TheRandom.Next(1, 3)

        End If

    End Sub
End Class