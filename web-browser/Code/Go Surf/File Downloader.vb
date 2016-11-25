Imports System.Net
Public Class FileDownloader
    Private WithEvents httpclient As WebClient
    Private Sub FileDownloader_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        httpclient = New WebClient
        Dim sourceURL = TextBox1.Text
        Dim filedir = TextBox2.Text
        ProgressBar1.Value = 0
        ProgressBar1.Maximum = 100
        Try
            httpclient.DownloadFileAsync(New Uri(sourceURL), (filedir))
        Catch ex As Exception
            MsgBox("failed" + ErrorToString(), MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim save As New SaveFileDialog
        save.Title = "save directory"
        save.ShowDialog()
        TextBox2.Text = save.FileName
    End Sub
    Private Sub httpclient_DownloadProgressChanged(ByVal sender As Object, ByVal e As System.Net.DownloadProgressChangedEventArgs) Handles httpclient.DownloadProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Hide()
    End Sub
End Class