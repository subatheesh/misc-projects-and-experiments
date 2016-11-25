Public Class TicTacToe
    Dim a As Integer = 1
    Dim i As Integer
    Private Sub digit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b1.Click, b2.Click, b3.Click, b4.Click, b5.Click, b6.Click, b7.Click, b8.Click, b9.Click
        If i < 9 Then
            If a = 1 Then
                sender.Text = "X"
                a = 0
                sender.Enabled = False
                sender.BackColor = Color.NavajoWhite
            Else
                sender.Text = "0"
                a = 1
                sender.Enabled = False
                sender.BackColor = Color.LightYellow
            End If
            i = i + 1
        End If
        check()
    End Sub
    Private Function change() As Boolean
        b1.Enabled = True
        b2.Enabled = True
        b3.Enabled = True
        b4.Enabled = True
        b5.Enabled = True
        b6.Enabled = True
        b7.Enabled = True
        b8.Enabled = True
        b9.Enabled = True
    End Function
    Private Function check()
        If b1.Text = "X" And b2.Text = "X" And b3.Text = "X" Then
            MsgBox("Player 1 Win")
            clear()
        ElseIf b1.Text = "X" And b4.Text = "X" And b7.Text = "X" Then
            MsgBox("Player 1 Win")
            clear()
        ElseIf b1.Text = "X" And b5.Text = "X" And b9.Text = "X" Then
            MsgBox("Player 1 Win")
            clear()
        ElseIf b3.Text = "X" And b5.Text = "X" And b7.Text = "X" Then
            MsgBox("Player 1 Win")
            clear()
        ElseIf b3.Text = "X" And b6.Text = "X" And b9.Text = "X" Then
            MsgBox("Player 1 Win")
            clear()
        ElseIf b7.Text = "X" And b8.Text = "X" And b9.Text = "X" Then
            MsgBox("Player 1 Win")
            clear()
        ElseIf b2.Text = "X" And b5.Text = "X" And b8.Text = "X" Then
            MsgBox("Player 1 Win")
            clear()
        ElseIf b4.Text = "X" And b5.Text = "X" And b6.Text = "X" Then
            MsgBox("Player 1 Win")
            clear()
        End If

        If b1.Text = "0" And b2.Text = "0" And b3.Text = "0" Then
            MsgBox("Player 2 Win")
            clear()
        ElseIf b1.Text = "0" And b4.Text = "0" And b7.Text = "0" Then
            MsgBox("Player 2 Win")
            clear()
        ElseIf b1.Text = "0" And b5.Text = "0" And b9.Text = "0" Then
            MsgBox("Player 2 Win")
            clear()
        ElseIf b3.Text = "0" And b5.Text = "0" And b7.Text = "0" Then
            MsgBox("Player 2 Win")
            clear()
        ElseIf b3.Text = "0" And b6.Text = "0" And b9.Text = "0" Then
            MsgBox("Player 2 Win")
            clear()
        ElseIf b7.Text = "0" And b8.Text = "0" And b9.Text = "0" Then
            MsgBox("Player 2 Win")
            clear()
        ElseIf b2.Text = "0" And b5.Text = "0" And b8.Text = "0" Then
            MsgBox("Player 2 Win")
            clear()
        ElseIf b4.Text = "0" And b5.Text = "0" And b6.Text = "0" Then
            MsgBox("Player 2 Win")
            clear()
        End If
        If i = 9 Then
            MsgBox("Tie Has Been Created...!")
            clear()
        End If
        Return 0
    End Function
    Private Function clear()
        If MsgBox("Do You Want To Play Again?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            b1.Text = ""
            b2.Text = ""
            b3.Text = ""
            b4.Text = ""
            b5.Text = ""
            b6.Text = ""
            b7.Text = ""
            b8.Text = ""
            b9.Text = ""
            b1.BackColor = Color.White
            b2.BackColor = Color.White
            b3.BackColor = Color.White
            b4.BackColor = Color.White
            b5.BackColor = Color.White
            b6.BackColor = Color.White
            b7.BackColor = Color.White
            b8.BackColor = Color.White
            b9.BackColor = Color.White
            i = 0
            a = 1
            change()
        Else
            Me.Close()
        End If
        Return 0
    End Function
End Class