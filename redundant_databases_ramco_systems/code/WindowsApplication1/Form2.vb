Public Class Form2
    Public selecteditem As String

    Public Function fresh() As Integer

        Button2.Enabled = False
        Button3.Enabled = False
        RadioButton1.Enabled = True
        RadioButton3.Enabled = True
        RadioButton5.Enabled = True
        Label2.Text = dept.Dep

        If Label2.Text = "RTO" Or Label2.Text = "Public" Then
            RadioButton1.Enabled = False
            RadioButton3.Enabled = False
            RadioButton5.Enabled = False
        End If

        Return 0
    End Function

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call fresh()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Me.Hide()
        dept.ClearTextBoxes(dept)
        dept.Show()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If RadioButton1.Checked Then
            Me.Hide()
            Call Form3.readid()
            Form3.Show()

        ElseIf RadioButton2.Checked Then
            selecteditem = RadioButton2.Text
            Me.Hide()
            Form5.rel()
            Form5.Show()

        ElseIf RadioButton3.Checked Then
            selecteditem = RadioButton3.Text
            Me.Hide()
            Form5.rel()
            Form5.Show()

        ElseIf RadioButton4.Checked Then
            selecteditem = RadioButton4.Text
            Me.Hide()
            Form5.rel()
            Form5.Show()
        ElseIf RadioButton5.Checked Then
            Me.Hide()
            Form11.Show()
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        Button3.Enabled = True
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        Button3.Enabled = True
    End Sub

    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        Button3.Enabled = True
    End Sub

    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        Button3.Enabled = True
    End Sub
    Private Sub RadioButton5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton5.CheckedChanged
        Button3.Enabled = True
    End Sub
End Class