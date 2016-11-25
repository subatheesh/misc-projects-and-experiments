<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Calculator
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Calculator))
        Me.btnequals = New System.Windows.Forms.Button
        Me.btnclear = New System.Windows.Forms.Button
        Me.btnzero = New System.Windows.Forms.Button
        Me.btndecimal = New System.Windows.Forms.Button
        Me.btnaddminus = New System.Windows.Forms.Button
        Me.btnx = New System.Windows.Forms.Button
        Me.btn9 = New System.Windows.Forms.Button
        Me.btn8 = New System.Windows.Forms.Button
        Me.btn7 = New System.Windows.Forms.Button
        Me.btndivide = New System.Windows.Forms.Button
        Me.btnmultiply = New System.Windows.Forms.Button
        Me.btn6 = New System.Windows.Forms.Button
        Me.btn5 = New System.Windows.Forms.Button
        Me.btn4 = New System.Windows.Forms.Button
        Me.btnminus = New System.Windows.Forms.Button
        Me.btnadd = New System.Windows.Forms.Button
        Me.btn3 = New System.Windows.Forms.Button
        Me.btn2 = New System.Windows.Forms.Button
        Me.btn1 = New System.Windows.Forms.Button
        Me.txtsource = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'btnequals
        '
        Me.btnequals.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnequals.Location = New System.Drawing.Point(129, 210)
        Me.btnequals.Name = "btnequals"
        Me.btnequals.Size = New System.Drawing.Size(89, 46)
        Me.btnequals.TabIndex = 39
        Me.btnequals.Text = "="
        Me.btnequals.UseVisualStyleBackColor = True
        '
        'btnclear
        '
        Me.btnclear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnclear.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnclear.Location = New System.Drawing.Point(83, 210)
        Me.btnclear.Name = "btnclear"
        Me.btnclear.Size = New System.Drawing.Size(32, 46)
        Me.btnclear.TabIndex = 38
        Me.btnclear.Text = "C"
        Me.btnclear.UseVisualStyleBackColor = True
        '
        'btnzero
        '
        Me.btnzero.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnzero.Location = New System.Drawing.Point(45, 210)
        Me.btnzero.Name = "btnzero"
        Me.btnzero.Size = New System.Drawing.Size(32, 46)
        Me.btnzero.TabIndex = 37
        Me.btnzero.Text = "0"
        Me.btnzero.UseVisualStyleBackColor = True
        '
        'btndecimal
        '
        Me.btndecimal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btndecimal.Location = New System.Drawing.Point(6, 210)
        Me.btndecimal.Name = "btndecimal"
        Me.btndecimal.Size = New System.Drawing.Size(33, 46)
        Me.btndecimal.TabIndex = 36
        Me.btndecimal.Text = "."
        Me.btndecimal.UseVisualStyleBackColor = True
        '
        'btnaddminus
        '
        Me.btnaddminus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnaddminus.Location = New System.Drawing.Point(174, 158)
        Me.btnaddminus.Name = "btnaddminus"
        Me.btnaddminus.Size = New System.Drawing.Size(43, 46)
        Me.btnaddminus.TabIndex = 35
        Me.btnaddminus.Text = "+-"
        Me.btnaddminus.UseVisualStyleBackColor = True
        '
        'btnx
        '
        Me.btnx.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnx.Location = New System.Drawing.Point(128, 158)
        Me.btnx.Name = "btnx"
        Me.btnx.Size = New System.Drawing.Size(43, 46)
        Me.btnx.TabIndex = 34
        Me.btnx.Text = "1/x"
        Me.btnx.UseVisualStyleBackColor = True
        '
        'btn9
        '
        Me.btn9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn9.Location = New System.Drawing.Point(83, 158)
        Me.btn9.Name = "btn9"
        Me.btn9.Size = New System.Drawing.Size(32, 46)
        Me.btn9.TabIndex = 33
        Me.btn9.Text = "9"
        Me.btn9.UseVisualStyleBackColor = True
        '
        'btn8
        '
        Me.btn8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn8.Location = New System.Drawing.Point(45, 158)
        Me.btn8.Name = "btn8"
        Me.btn8.Size = New System.Drawing.Size(32, 46)
        Me.btn8.TabIndex = 32
        Me.btn8.Text = "8"
        Me.btn8.UseVisualStyleBackColor = True
        '
        'btn7
        '
        Me.btn7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn7.Location = New System.Drawing.Point(6, 158)
        Me.btn7.Name = "btn7"
        Me.btn7.Size = New System.Drawing.Size(33, 46)
        Me.btn7.TabIndex = 31
        Me.btn7.Text = "7"
        Me.btn7.UseVisualStyleBackColor = True
        '
        'btndivide
        '
        Me.btndivide.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btndivide.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btndivide.Location = New System.Drawing.Point(174, 106)
        Me.btndivide.Name = "btndivide"
        Me.btndivide.Size = New System.Drawing.Size(43, 46)
        Me.btndivide.TabIndex = 30
        Me.btndivide.Text = "/"
        Me.btndivide.UseVisualStyleBackColor = True
        '
        'btnmultiply
        '
        Me.btnmultiply.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnmultiply.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnmultiply.Location = New System.Drawing.Point(129, 106)
        Me.btnmultiply.Name = "btnmultiply"
        Me.btnmultiply.Size = New System.Drawing.Size(43, 46)
        Me.btnmultiply.TabIndex = 29
        Me.btnmultiply.Text = "*"
        Me.btnmultiply.UseVisualStyleBackColor = True
        '
        'btn6
        '
        Me.btn6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn6.Location = New System.Drawing.Point(80, 106)
        Me.btn6.Name = "btn6"
        Me.btn6.Size = New System.Drawing.Size(32, 46)
        Me.btn6.TabIndex = 28
        Me.btn6.Text = "6"
        Me.btn6.UseVisualStyleBackColor = True
        '
        'btn5
        '
        Me.btn5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn5.Location = New System.Drawing.Point(45, 106)
        Me.btn5.Name = "btn5"
        Me.btn5.Size = New System.Drawing.Size(32, 46)
        Me.btn5.TabIndex = 27
        Me.btn5.Text = "5"
        Me.btn5.UseVisualStyleBackColor = True
        '
        'btn4
        '
        Me.btn4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn4.Location = New System.Drawing.Point(6, 106)
        Me.btn4.Name = "btn4"
        Me.btn4.Size = New System.Drawing.Size(33, 46)
        Me.btn4.TabIndex = 26
        Me.btn4.Text = "4"
        Me.btn4.UseVisualStyleBackColor = True
        '
        'btnminus
        '
        Me.btnminus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnminus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnminus.Location = New System.Drawing.Point(174, 54)
        Me.btnminus.Name = "btnminus"
        Me.btnminus.Size = New System.Drawing.Size(43, 46)
        Me.btnminus.TabIndex = 25
        Me.btnminus.Text = "-"
        Me.btnminus.UseVisualStyleBackColor = True
        '
        'btnadd
        '
        Me.btnadd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnadd.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnadd.Location = New System.Drawing.Point(129, 54)
        Me.btnadd.Name = "btnadd"
        Me.btnadd.Size = New System.Drawing.Size(43, 46)
        Me.btnadd.TabIndex = 24
        Me.btnadd.Text = "+"
        Me.btnadd.UseVisualStyleBackColor = True
        '
        'btn3
        '
        Me.btn3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn3.Location = New System.Drawing.Point(83, 54)
        Me.btn3.Name = "btn3"
        Me.btn3.Size = New System.Drawing.Size(32, 46)
        Me.btn3.TabIndex = 23
        Me.btn3.Text = "3"
        Me.btn3.UseVisualStyleBackColor = True
        '
        'btn2
        '
        Me.btn2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn2.Location = New System.Drawing.Point(45, 54)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(32, 46)
        Me.btn2.TabIndex = 22
        Me.btn2.Text = "2"
        Me.btn2.UseVisualStyleBackColor = True
        '
        'btn1
        '
        Me.btn1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn1.Location = New System.Drawing.Point(6, 54)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(33, 46)
        Me.btn1.TabIndex = 21
        Me.btn1.Text = "1"
        Me.btn1.UseVisualStyleBackColor = True
        '
        'txtsource
        '
        Me.txtsource.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtsource.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsource.Location = New System.Drawing.Point(6, 2)
        Me.txtsource.Multiline = True
        Me.txtsource.Name = "txtsource"
        Me.txtsource.Size = New System.Drawing.Size(211, 46)
        Me.txtsource.TabIndex = 20
        Me.txtsource.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Calculator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(222, 258)
        Me.Controls.Add(Me.btnequals)
        Me.Controls.Add(Me.btnclear)
        Me.Controls.Add(Me.btnzero)
        Me.Controls.Add(Me.btndecimal)
        Me.Controls.Add(Me.btnaddminus)
        Me.Controls.Add(Me.btnx)
        Me.Controls.Add(Me.btn9)
        Me.Controls.Add(Me.btn8)
        Me.Controls.Add(Me.btn7)
        Me.Controls.Add(Me.btndivide)
        Me.Controls.Add(Me.btnmultiply)
        Me.Controls.Add(Me.btn6)
        Me.Controls.Add(Me.btn5)
        Me.Controls.Add(Me.btn4)
        Me.Controls.Add(Me.btnminus)
        Me.Controls.Add(Me.btnadd)
        Me.Controls.Add(Me.btn3)
        Me.Controls.Add(Me.btn2)
        Me.Controls.Add(Me.btn1)
        Me.Controls.Add(Me.txtsource)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Calculator"
        Me.Text = "Calculator"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnequals As System.Windows.Forms.Button
    Friend WithEvents btnclear As System.Windows.Forms.Button
    Friend WithEvents btnzero As System.Windows.Forms.Button
    Friend WithEvents btndecimal As System.Windows.Forms.Button
    Friend WithEvents btnaddminus As System.Windows.Forms.Button
    Friend WithEvents btnx As System.Windows.Forms.Button
    Friend WithEvents btn9 As System.Windows.Forms.Button
    Friend WithEvents btn8 As System.Windows.Forms.Button
    Friend WithEvents btn7 As System.Windows.Forms.Button
    Friend WithEvents btndivide As System.Windows.Forms.Button
    Friend WithEvents btnmultiply As System.Windows.Forms.Button
    Friend WithEvents btn6 As System.Windows.Forms.Button
    Friend WithEvents btn5 As System.Windows.Forms.Button
    Friend WithEvents btn4 As System.Windows.Forms.Button
    Friend WithEvents btnminus As System.Windows.Forms.Button
    Friend WithEvents btnadd As System.Windows.Forms.Button
    Friend WithEvents btn3 As System.Windows.Forms.Button
    Friend WithEvents btn2 As System.Windows.Forms.Button
    Friend WithEvents btn1 As System.Windows.Forms.Button
    Friend WithEvents txtsource As System.Windows.Forms.TextBox
End Class
