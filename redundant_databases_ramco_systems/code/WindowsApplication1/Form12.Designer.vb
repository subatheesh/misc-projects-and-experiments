<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form12
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
        Me.components = New System.ComponentModel.Container()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.SNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OwnerNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RegistrationNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ModelDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LisenceNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PhoneNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AddressDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Db_ADataSet = New Intern_Project.db_ADataSet()
        Me.TATableAdapter = New Intern_Project.db_ADataSetTableAdapters.TATableAdapter()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Db_ADataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SNo, Me.IDDataGridViewTextBoxColumn, Me.OwnerNameDataGridViewTextBoxColumn, Me.RegistrationNoDataGridViewTextBoxColumn, Me.ModelDataGridViewTextBoxColumn, Me.LisenceNoDataGridViewTextBoxColumn, Me.PhoneNoDataGridViewTextBoxColumn, Me.AddressDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.TABindingSource
        Me.DataGridView1.Location = New System.Drawing.Point(18, 16)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(842, 206)
        Me.DataGridView1.TabIndex = 1
        '
        'SNo
        '
        Me.SNo.DataPropertyName = "S No"
        Me.SNo.HeaderText = "S No"
        Me.SNo.Name = "SNo"
        Me.SNo.ReadOnly = True
        '
        'IDDataGridViewTextBoxColumn
        '
        Me.IDDataGridViewTextBoxColumn.DataPropertyName = "ID"
        Me.IDDataGridViewTextBoxColumn.HeaderText = "ID"
        Me.IDDataGridViewTextBoxColumn.Name = "IDDataGridViewTextBoxColumn"
        Me.IDDataGridViewTextBoxColumn.ReadOnly = True
        '
        'OwnerNameDataGridViewTextBoxColumn
        '
        Me.OwnerNameDataGridViewTextBoxColumn.DataPropertyName = "Owner Name"
        Me.OwnerNameDataGridViewTextBoxColumn.HeaderText = "Owner Name"
        Me.OwnerNameDataGridViewTextBoxColumn.Name = "OwnerNameDataGridViewTextBoxColumn"
        Me.OwnerNameDataGridViewTextBoxColumn.ReadOnly = True
        '
        'RegistrationNoDataGridViewTextBoxColumn
        '
        Me.RegistrationNoDataGridViewTextBoxColumn.DataPropertyName = "Registration No"
        Me.RegistrationNoDataGridViewTextBoxColumn.HeaderText = "Registration No"
        Me.RegistrationNoDataGridViewTextBoxColumn.Name = "RegistrationNoDataGridViewTextBoxColumn"
        Me.RegistrationNoDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ModelDataGridViewTextBoxColumn
        '
        Me.ModelDataGridViewTextBoxColumn.DataPropertyName = "Model"
        Me.ModelDataGridViewTextBoxColumn.HeaderText = "Model"
        Me.ModelDataGridViewTextBoxColumn.Name = "ModelDataGridViewTextBoxColumn"
        Me.ModelDataGridViewTextBoxColumn.ReadOnly = True
        '
        'LisenceNoDataGridViewTextBoxColumn
        '
        Me.LisenceNoDataGridViewTextBoxColumn.DataPropertyName = "Lisence No"
        Me.LisenceNoDataGridViewTextBoxColumn.HeaderText = "Lisence No"
        Me.LisenceNoDataGridViewTextBoxColumn.Name = "LisenceNoDataGridViewTextBoxColumn"
        Me.LisenceNoDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PhoneNoDataGridViewTextBoxColumn
        '
        Me.PhoneNoDataGridViewTextBoxColumn.DataPropertyName = "Phone No"
        Me.PhoneNoDataGridViewTextBoxColumn.HeaderText = "Phone No"
        Me.PhoneNoDataGridViewTextBoxColumn.Name = "PhoneNoDataGridViewTextBoxColumn"
        Me.PhoneNoDataGridViewTextBoxColumn.ReadOnly = True
        '
        'AddressDataGridViewTextBoxColumn
        '
        Me.AddressDataGridViewTextBoxColumn.DataPropertyName = "Address"
        Me.AddressDataGridViewTextBoxColumn.HeaderText = "Address"
        Me.AddressDataGridViewTextBoxColumn.Name = "AddressDataGridViewTextBoxColumn"
        Me.AddressDataGridViewTextBoxColumn.ReadOnly = True
        '
        'TABindingSource
        '
        Me.TABindingSource.DataMember = "TA"
        Me.TABindingSource.DataSource = Me.Db_ADataSet
        '
        'Db_ADataSet
        '
        Me.Db_ADataSet.DataSetName = "db_ADataSet"
        Me.Db_ADataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TATableAdapter
        '
        Me.TATableAdapter.ClearBeforeFill = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(738, 243)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 38)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Next >>"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(612, 243)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 38)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "<< Back"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(19, 243)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 38)
        Me.Button3.TabIndex = 1
        Me.Button3.Text = "Cancel"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(138, 243)
        Me.Button4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 38)
        Me.Button4.TabIndex = 2
        Me.Button4.Text = "<<  Prev"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(305, 253)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(193, 19)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Double click to edit the record"
        '
        'Form12
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(880, 290)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Form12"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "All Records"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Db_ADataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Db_ADataSet As Intern_Project.db_ADataSet
    Friend WithEvents TABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TATableAdapter As Intern_Project.db_ADataSetTableAdapters.TATableAdapter
    Friend WithEvents SNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OwnerNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RegistrationNoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ModelDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LisenceNoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PhoneNoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AddressDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
