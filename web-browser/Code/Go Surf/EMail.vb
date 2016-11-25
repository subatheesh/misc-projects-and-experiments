Public Class EMail

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ProgressBar1.Value = 5
        Dim message As System.Net.Mail.MailMessage
        ProgressBar1.Value = 10
        Dim smtp As New System.Net.Mail.SmtpClient(TextBox3.Text, 587)
        ProgressBar1.Value = 24
        message = New System.Net.Mail.MailMessage(TextBox1.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text)
        ProgressBar1.Value = 43
        smtp.EnableSsl = True
        ProgressBar1.Value = 59
        smtp.Credentials = New System.Net.NetworkCredential(TextBox1.Text, TextBox2.Text)
        ProgressBar1.Value = 70
        ProgressBar1.Value = 80
        Try
            smtp.Send(message)
            ProgressBar1.Value = 100
            MessageBox.Show("Message Sent Successfully", " Sent", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ProgressBar1.Value = 0
        Catch exc As Net.Mail.SmtpException
            MessageBox.Show("An Error Occured Please try again", " Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MessageBox.Show("Try Entering your password again or maybe your not connected to the internet", " Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        If CheckBox1.Checked = True Then
            My.Settings.Username = TextBox1.Text
            My.Settings.Save()
            My.Settings.Reload()
        End If
        If CheckBox2.Checked = True Then
            My.Settings.Password = TextBox2.Text
            My.Settings.Save()
            My.Settings.Reload()
        End If
 
    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        My.Settings.Password = ""
        My.Settings.Username = ""
        My.Settings.Save()
        My.Settings.Reload()
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub EMail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = My.Settings.Username
        TextBox2.Text = My.Settings.Password
    End Sub
End Class