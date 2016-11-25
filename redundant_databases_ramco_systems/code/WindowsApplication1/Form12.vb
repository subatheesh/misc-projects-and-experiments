Imports System.Data
Imports System.Data.SqlClient

Public Class Form12
    Public i As Integer
    Public j As Integer
    Public clickid As Integer
    Public Function view() As Integer
        Dim sqlCM As String
        Dim dt As New DataTable
        sqlCM = "SELECT * FROM (SELECT ROW_NUMBER() OVER (ORDER BY ID) AS [S No], ID, [Owner Name], [Registration No],Model,[Lisence No],[Phone No],Address FROM TA) AS REG WHERE [S No] BETWEEN " + i.ToString() + " AND " + j.ToString()
        Using cn As New SqlConnection("Data Source=.;Initial Catalog=db_A;Integrated Security=True"),
              cmd As New SqlCommand(sqlCM, cn)
            cn.Open()
            dt.Load(cmd.ExecuteReader())
            DataGridView1.DataSource = dt
            cn.Close()
        End Using
        Return 0
    End Function
    Public Function form12load() As Integer

        i = 1
        j = i + 4
        Button1.Enabled = True
        Button2.Enabled = True
        If (j > Form11.Tempnum) Then
            j = Form11.Tempnum
        End If
        Button2.Enabled = False
        If (Form11.Tempnum <= 5) Then
            Button1.Enabled = False
        End If
        Call view()
        Return 0
    End Function

    Private Sub Form12_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TATableAdapter.Fill(Me.Db_ADataSet.TA)
        Call form12load()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If (Form11.Tempnum > j) Then
            i = i + 5
            j = i + 4
            If (j > Form11.Tempnum) Then
                j = Form11.Tempnum
            End If
            Call view()
            Button2.Enabled = True
        Else
            Button1.Enabled = False
        End If
        If (j >= Form11.Tempnum) Then
            Button1.Enabled = False
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If (i > 1) Then
            If (j >= Form11.Tempnum) Then
                j = i + 4
            End If
            i = i - 5
            j = j - 5
            Call view()
            Button1.Enabled = True
        Else
            Button2.Enabled = False
        End If
        If (i = 1) Then
            Button2.Enabled = False

        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Me.Hide()
        dept.ClearTextBoxes(dept)
        dept.ClearTextBoxes(Me)
        dept.Show()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Call dept.ClearTextBoxes(Form11)
        Me.Hide()
        Call Form11.form11load()
        Form11.Show()
    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        clickid = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        Form5.tempid = clickid
        Form13.Show()
    End Sub
End Class