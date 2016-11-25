Public Class ScreenCapture

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim bounds As Rectangle
        Dim screenshot As System.Drawing.Bitmap
        Dim graph As Graphics
        bounds = Screen.PrimaryScreen.Bounds
        screenshot = New System.Drawing.Bitmap(bounds.Width, bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
        graph = Graphics.FromImage(screenshot)
        graph.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy)
        PictureBox1.Image = screenshot
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim savefiledialog1 As New SaveFileDialog
        Try
            savefiledialog1.Title = "Save File"
            savefiledialog1.FileName = "*.bmp"
            savefiledialog1.Filter = "Bitmap |*.bmp"
            If savefiledialog1.ShowDialog() = DialogResult.OK Then
                PictureBox1.Image.Save(savefiledialog1.FileName, System.Drawing.Imaging.ImageFormat.Bmp)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Hide()
    End Sub
End Class