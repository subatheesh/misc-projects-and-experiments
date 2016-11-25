Public Class CustomTheme

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form1.Button1.BackColor = Color.White
        Form1.Button2.BackColor = Color.White
        Form1.Button3.BackColor = Color.White
        Form1.Button4.BackColor = Color.White
        Form1.Button5.BackColor = Color.White
        Form1.Button6.BackColor = Color.White
        Form1.Button7.BackColor = Color.White
        Form1.BackColor = Color.Empty
        Form1.ForeColor = Color.Empty
        Form1.RadioButton1.BackColor = Color.Transparent
        Form1.RadioButton2.BackColor = Color.Transparent
        Form1.RadioButton3.BackColor = Color.Transparent
        Form1.RadioButton1.ForeColor = Color.Black
        Form1.RadioButton2.ForeColor = Color.Black
        Form1.RadioButton3.ForeColor = Color.Black
        Form1.ComboBox1.BackColor = Color.White
        Form1.ComboBox2.BackColor = Color.White
        Form1.ComboBox1.ForeColor = Color.Black
        Form1.ComboBox2.ForeColor = Color.Black
        Form1.StatusStrip1.BackColor = Color.Empty
        Form1.MenuStrip1.BackColor = Color.White
        Form1.ToolStripStatusLabel1.ForeColor = Color.Black
        Form1.BackgroundImage = Image.FromFile(TextBox1.Text)
        Form1.MenuStrip1.BackgroundImage = Image.FromFile(TextBox1.Text)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim dlg As OpenFileDialog = New OpenFileDialog
            dlg.Title = "Open"
            dlg.Filter = "Images (*.jpg)|*.jpg"
            If dlg.ShowDialog() = DialogResult.OK Then
                TextBox1.Text = dlg.FileName
            End If
        Catch ex As Exception : End Try
    End Sub

    Private Sub CustomTheme_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class