Public Class CleanHistory

    Private Sub CleanHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For Each item As String In My.Settings.history
            ComboBox1.Items.Add(item)
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ComboBox1.Items.Clear()
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        For Each item As String In My.Settings.history
            ComboBox1.Items.Add(item)
        Next
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "Clear All History" Then
            My.Settings.history.Clear()
        End If

        If ComboBox1.Text = "Clear All History" Then
            ComboBox1.Items.Clear()
        End If
    End Sub
End Class