Public Class Videoconverter

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Selectvid.ShowDialog()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim type As String = ComboBox1.Text
        If ComboBox1.Text = "" Then
            MsgBox("No file type selected")
        Else
        End If
        MsgBox(TextBox1.Text + " shall be converted into a " + type + " file.")
        Dim oldFile As String = Mid(TextBox1.Text, 1, Len(TextBox1.Text) - 4)
        FileCopy(TextBox1.Text, oldFile + type)
    End Sub

    Private Sub Selectvid_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Selectvid.FileOk

        Dim file As String = Selectvid.FileName
        TextBox1.Text = file
    End Sub
End Class