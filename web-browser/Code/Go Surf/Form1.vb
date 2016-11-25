Public Class Form1
    Dim int As Integer = 0
    Private Sub Loading(ByVal sender As Object, ByVal e As Windows.Forms.WebBrowserProgressChangedEventArgs)
        ToolStripProgressBar1.Maximum = e.MaximumProgress
        ToolStripProgressBar1.Value = e.CurrentProgress
    End Sub
    Private Sub Done(ByVal sender As Object, ByVal e As Windows.Forms.WebBrowserDocumentCompletedEventArgs)
        TabControl1.SelectedTab.Text = CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).DocumentTitle
        ComboBox1.Text = CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Url.ToString
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Browser As New WebBrowser
        TabControl1.TabPages.Add("New Page")
        Browser.Name = "Go Surf"
        Browser.Dock = DockStyle.Fill
        TabControl1.SelectedTab.Controls.Add(Browser)
        AddHandler Browser.ProgressChanged, AddressOf Loading
        AddHandler Browser.DocumentCompleted, AddressOf Done
        int = int + 1
        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).GoHome()
    End Sub

    Private Sub AddTabToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddTabToolStripMenuItem.Click
        Dim Browser As New WebBrowser
        TabControl1.TabPages.Add("New Page")
        TabControl1.SelectTab(int)
        Browser.Name = "Go Surf"
        Browser.Dock = DockStyle.Fill
        TabControl1.SelectedTab.Controls.Add(Browser)
        AddHandler Browser.ProgressChanged, AddressOf Loading
        AddHandler Browser.DocumentCompleted, AddressOf Done
        int = int + 1
        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).GoHome()
    End Sub

    Private Sub CloseCurrentTabToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveTabToolStripMenuItem.Click
        If Not TabControl1.TabPages.Count = 1 Then
            TabControl1.TabPages.RemoveAt(TabControl1.SelectedIndex)
            TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
            int = int - 1
        End If
    End Sub

    Private Sub WebsitePropertiesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WebsitePropertiesToolStripMenuItem.Click
        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).ShowPropertiesDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).GoBack()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).GoForward()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Refresh()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Stop()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Navigate(My.Settings.Homepage)
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Navigate(ComboBox1.Text)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ToolStripStatusLabel1.Text = CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).StatusText
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).ShowPrintDialog()
    End Sub

    Private Sub PrintPreviewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPreviewToolStripMenuItem.Click
        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).ShowPrintPreviewDialog()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If RadioButton1.Checked Then
            CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Navigate("http://www.google.com/search?hl=en&q=" & ComboBox2.Text & "&btnG=Google+Search&meta=")
        End If
        If RadioButton2.Checked Then
            CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Navigate("http://search.yahoo.com/search?p=" & ComboBox2.Text & "&fr=yfp-t-501&toggle=1&cop=mss&ei=UTF-8&fp_ip=IN&vc=")
        End If
        If RadioButton3.Checked Then
            CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Navigate("http://www.youtube.com/results?search_query=" & ComboBox2.Text & "&search_type=&aq=-1&oq=")
        End If
    End Sub

    Private Sub SavePageAsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveFileAsToolStripMenuItem.Click
        Try
            Dim SaveFileDialog1 As New SaveFileDialog
            SaveFileDialog1.Title = "Save Page"
            SaveFileDialog1.Filter = "Internet Page (*.html)|*.htm|All Files|*.*"
            SaveFileDialog1.ShowDialog()
            If SaveFileDialog1.FileName <> "" Then
                FileOpen(1, SaveFileDialog1.FileName, OpenMode.Output)
                PrintLine(1, CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).DocumentText)
                FileClose(1)
            End If
        Catch ex As Exception
            'Show an error
            MessageBox.Show("Error - Could not open the save file dialog.", Me.Text, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub NewWindowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewWindowToolStripMenuItem.Click
        Try : Shell("GoSurf 1.0.exe")
        Catch ex As IO.FileNotFoundException : MessageBox.Show("Error - File missing from directory!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception : End Try
    End Sub

    Private Sub CloseCurrentWindowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseCurrentWindowToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub BlackandWhiteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BlackWhiteToolStripMenuItem.Click
        Me.Button1.BackColor = Color.White
        Me.Button2.BackColor = Color.White
        Me.Button3.BackColor = Color.White
        Me.Button4.BackColor = Color.White
        Me.Button5.BackColor = Color.White
        Me.Button6.BackColor = Color.White
        Me.Button7.BackColor = Color.White
        Me.BackColor = Color.Black
        Me.BackColor = Color.Black
        Me.ComboBox1.BackColor = Color.White
        Me.ComboBox2.BackColor = Color.White
        Me.ComboBox1.ForeColor = Color.Black
        Me.ComboBox2.ForeColor = Color.Black
        Me.RadioButton1.ForeColor = Color.White
        Me.RadioButton2.ForeColor = Color.White
        Me.RadioButton3.ForeColor = Color.White
        Me.StatusStrip1.BackColor = Color.Black
        Me.MenuStrip1.BackColor = Color.WhiteSmoke
        Me.ToolStripStatusLabel1.ForeColor = Color.White
    End Sub

    Private Sub RegularToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegularToolStripMenuItem.Click
        Me.Button1.BackColor = Color.White
        Me.Button2.BackColor = Color.White
        Me.Button3.BackColor = Color.White
        Me.Button4.BackColor = Color.White
        Me.Button5.BackColor = Color.White
        Me.Button6.BackColor = Color.White
        Me.Button7.BackColor = Color.White
        Me.BackColor = Color.Empty
        Me.ForeColor = Color.Empty
        Me.RadioButton1.ForeColor = Color.Black
        Me.RadioButton2.ForeColor = Color.Black
        Me.RadioButton3.ForeColor = Color.Black
        Me.ComboBox1.BackColor = Color.White
        Me.ComboBox2.BackColor = Color.White
        Me.ComboBox1.ForeColor = Color.Black
        Me.ComboBox2.ForeColor = Color.Black
        Me.StatusStrip1.BackColor = Color.Empty
        Me.MenuStrip1.BackColor = Color.Empty
        Me.ToolStripStatusLabel1.ForeColor = Color.Black
    End Sub

    Private Sub LivingColoursToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LivingColoursToolStripMenuItem.Click
        Me.Button1.BackColor = Color.Empty
        Me.Button2.BackColor = Color.Empty
        Me.Button3.BackColor = Color.Empty
        Me.Button4.BackColor = Color.Empty
        Me.Button5.BackColor = Color.Empty
        Me.Button6.BackColor = Color.Empty
        Me.Button7.BackColor = Color.Empty
        Me.BackColor = Color.GreenYellow
        Me.ForeColor = Color.Black
        Me.RadioButton1.ForeColor = Color.IndianRed
        Me.RadioButton2.ForeColor = Color.IndianRed
        Me.RadioButton3.ForeColor = Color.IndianRed
        Me.ComboBox1.BackColor = Color.SkyBlue
        Me.ComboBox2.BackColor = Color.SkyBlue
        Me.ComboBox1.ForeColor = Color.Black
        Me.ComboBox2.ForeColor = Color.Gold
        Me.StatusStrip1.BackColor = Color.GreenYellow
        Me.MenuStrip1.BackColor = Color.Aquamarine
        Me.ToolStripStatusLabel1.ForeColor = Color.Red
    End Sub

    Private Sub GoldToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GoldToolStripMenuItem.Click
        Me.Button1.BackColor = Color.Empty
        Me.Button2.BackColor = Color.Empty
        Me.Button3.BackColor = Color.Empty
        Me.Button4.BackColor = Color.Empty
        Me.Button5.BackColor = Color.Empty
        Me.Button6.BackColor = Color.Empty
        Me.Button7.BackColor = Color.Empty
        Me.BackColor = Color.Gold
        Me.ForeColor = Color.Black
        Me.RadioButton1.ForeColor = Color.Goldenrod
        Me.RadioButton2.ForeColor = Color.Goldenrod
        Me.RadioButton3.ForeColor = Color.Goldenrod
        Me.ComboBox1.BackColor = Color.Yellow
        Me.ComboBox2.BackColor = Color.Yellow
        Me.ComboBox1.ForeColor = Color.Black
        Me.ComboBox2.ForeColor = Color.Black
        Me.StatusStrip1.BackColor = Color.Goldenrod
        Me.MenuStrip1.BackColor = Color.Goldenrod
        Me.ToolStripStatusLabel1.ForeColor = Color.Black
    End Sub

    Private Sub ChangeHomePageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeHomePageToolStripMenuItem.Click
        ChangeHomePage.show()
    End Sub

    Private Sub CustomThemesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomThemesToolStripMenuItem.Click
        CustomTheme.Show()
    End Sub

    Private Sub FileDownloaderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileDownloaderToolStripMenuItem.Click
        FileDownloader.Show()
    End Sub

    Private Sub ScreenCaptureToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScreenCaptureToolStripMenuItem.Click
        ScreenCapture.show()
    End Sub

    Private Sub EMailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EMailToolStripMenuItem.Click
        EMail.show()
    End Sub

    Private Sub KeyLoggerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KeyLoggerToolStripMenuItem.Click
        KeyLogger.Show()
    End Sub

    Private Sub IPAddressfinderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IPAddressViewerToolStripMenuItem.Click
        IPviewer.Show()
    End Sub

    Private Sub AboutGoSurfToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutGoSurfToolStripMenuItem.Click
        About_Go_Surf.Show()
    End Sub

    Private Sub CalculatorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalculatorToolStripMenuItem.Click
        Calculator.show()
    End Sub

    Private Sub AlarmClockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AlarmClockToolStripMenuItem.Click
        AlarmClock.show()
    End Sub

    Private Sub VideoFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VideoFileToolStripMenuItem.Click
        Videoconverter.show()
    End Sub

    Private Sub ImageFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImageFilleToolStripMenuItem.Click
        Imageconverter.Show()
    End Sub

    Private Sub NotePadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotePadToolStripMenuItem.Click
        NotePad.Show()
    End Sub

    Private Sub MultimediaPlayerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MultimediaPlayerToolStripMenuItem.Click
        MultimediaPlayer.show()
    End Sub

    Private Sub CleanHistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CleanHistoryToolStripMenuItem.Click
        CleanHistory.Show()
    End Sub

    Private Sub PaintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaintToolStripMenuItem.Click
        PaintForm.Show()
    End Sub

    Private Sub VoiceReToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VoiceReToolStripMenuItem.Click
        VoiceRecorder.Show()

    End Sub

    Private Sub AntiVirusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AntiVirusToolStripMenuItem.Click
        AntiVirus.show()
    End Sub

    Private Sub TicTacToeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TicTacToeToolStripMenuItem.Click
        TicTacToe.show()
    End Sub

    Private Sub PacmanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PacmanToolStripMenuItem.Click
        RockPaperScissors.Show()
    End Sub

    
End Class
