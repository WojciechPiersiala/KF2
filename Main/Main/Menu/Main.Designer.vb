<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ButStart = New System.Windows.Forms.Button()
        Me.MTextBoxPort = New System.Windows.Forms.MaskedTextBox()
        Me.MTextBoxAmsNetId = New System.Windows.Forms.MaskedTextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Log_In = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Log_Out = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.MenuBar
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(611, 48)
        Me.Panel1.TabIndex = 0
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold)
        Me.Button2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button2.Location = New System.Drawing.Point(512, 4)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(41, 36)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "_"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold)
        Me.Button1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button1.Location = New System.Drawing.Point(561, 4)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(41, 36)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "X"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'ButStart
        '
        Me.ButStart.BackColor = System.Drawing.Color.White
        Me.ButStart.FlatAppearance.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ButStart.FlatAppearance.BorderSize = 0
        Me.ButStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray
        Me.ButStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.ButStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.ButStart.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ButStart.Location = New System.Drawing.Point(428, 344)
        Me.ButStart.Margin = New System.Windows.Forms.Padding(4)
        Me.ButStart.Name = "ButStart"
        Me.ButStart.Size = New System.Drawing.Size(164, 54)
        Me.ButStart.TabIndex = 86
        Me.ButStart.Text = "START"
        Me.ButStart.UseVisualStyleBackColor = False
        Me.ButStart.Visible = False
        '
        'MTextBoxPort
        '
        Me.MTextBoxPort.Location = New System.Drawing.Point(428, 316)
        Me.MTextBoxPort.Margin = New System.Windows.Forms.Padding(4)
        Me.MTextBoxPort.Name = "MTextBoxPort"
        Me.MTextBoxPort.Size = New System.Drawing.Size(56, 20)
        Me.MTextBoxPort.TabIndex = 89
        Me.MTextBoxPort.Text = "801"
        Me.MTextBoxPort.Visible = False
        '
        'MTextBoxAmsNetId
        '
        Me.MTextBoxAmsNetId.Location = New System.Drawing.Point(428, 293)
        Me.MTextBoxAmsNetId.Margin = New System.Windows.Forms.Padding(4)
        Me.MTextBoxAmsNetId.Name = "MTextBoxAmsNetId"
        Me.MTextBoxAmsNetId.Size = New System.Drawing.Size(131, 20)
        Me.MTextBoxAmsNetId.TabIndex = 88
        Me.MTextBoxAmsNetId.Text = "172.25.184.65.1.1"
        Me.MTextBoxAmsNetId.Visible = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.White
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray
        Me.Button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold)
        Me.Button3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button3.Location = New System.Drawing.Point(30, 75)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(174, 82)
        Me.Button3.TabIndex = 90
        Me.Button3.Text = "KFA"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.White
        Me.Button4.FlatAppearance.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray
        Me.Button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold)
        Me.Button4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button4.Location = New System.Drawing.Point(30, 193)
        Me.Button4.Margin = New System.Windows.Forms.Padding(4)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(174, 82)
        Me.Button4.TabIndex = 91
        Me.Button4.Text = "Raporty KFA"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.White
        Me.Button5.FlatAppearance.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.Button5.FlatAppearance.BorderSize = 0
        Me.Button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray
        Me.Button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold)
        Me.Button5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button5.Location = New System.Drawing.Point(428, 193)
        Me.Button5.Margin = New System.Windows.Forms.Padding(4)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(174, 82)
        Me.Button5.TabIndex = 92
        Me.Button5.Text = "Tischauflage"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.White
        Me.Button6.FlatAppearance.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.Button6.FlatAppearance.BorderSize = 0
        Me.Button6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray
        Me.Button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold)
        Me.Button6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button6.Location = New System.Drawing.Point(230, 75)
        Me.Button6.Margin = New System.Windows.Forms.Padding(4)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(174, 82)
        Me.Button6.TabIndex = 93
        Me.Button6.Text = " Przewody 10749697"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.White
        Me.Button7.FlatAppearance.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.Button7.FlatAppearance.BorderSize = 0
        Me.Button7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray
        Me.Button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold)
        Me.Button7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button7.Location = New System.Drawing.Point(230, 316)
        Me.Button7.Margin = New System.Windows.Forms.Padding(4)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(174, 82)
        Me.Button7.TabIndex = 94
        Me.Button7.Text = " Przewody 10749699"
        Me.Button7.UseVisualStyleBackColor = False
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.White
        Me.Button8.FlatAppearance.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.Button8.FlatAppearance.BorderSize = 0
        Me.Button8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray
        Me.Button8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold)
        Me.Button8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button8.Location = New System.Drawing.Point(230, 193)
        Me.Button8.Margin = New System.Windows.Forms.Padding(4)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(174, 82)
        Me.Button8.TabIndex = 95
        Me.Button8.Text = " Przewody 10749698"
        Me.Button8.UseVisualStyleBackColor = False
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.White
        Me.Button9.FlatAppearance.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.Button9.FlatAppearance.BorderSize = 0
        Me.Button9.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray
        Me.Button9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold)
        Me.Button9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button9.Location = New System.Drawing.Point(428, 75)
        Me.Button9.Margin = New System.Windows.Forms.Padding(4)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(174, 82)
        Me.Button9.TabIndex = 96
        Me.Button9.Text = "Symphonia"
        Me.Button9.UseVisualStyleBackColor = False
        '
        'Button10
        '
        Me.Button10.BackColor = System.Drawing.Color.White
        Me.Button10.FlatAppearance.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.Button10.FlatAppearance.BorderSize = 0
        Me.Button10.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray
        Me.Button10.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.Button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button10.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold)
        Me.Button10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button10.Location = New System.Drawing.Point(30, 316)
        Me.Button10.Margin = New System.Windows.Forms.Padding(4)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(174, 82)
        Me.Button10.TabIndex = 97
        Me.Button10.Text = "Novimat"
        Me.Button10.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'Log_In
        '
        Me.Log_In.BackColor = System.Drawing.Color.White
        Me.Log_In.FlatAppearance.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.Log_In.FlatAppearance.BorderSize = 0
        Me.Log_In.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray
        Me.Log_In.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.Log_In.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Log_In.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.Log_In.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Log_In.Location = New System.Drawing.Point(291, 121)
        Me.Log_In.Margin = New System.Windows.Forms.Padding(4)
        Me.Log_In.Name = "Log_In"
        Me.Log_In.Size = New System.Drawing.Size(174, 82)
        Me.Log_In.TabIndex = 90
        Me.Log_In.Text = "Zaloguj"
        Me.Log_In.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(-37, 405)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(611, 368)
        Me.PictureBox1.TabIndex = 99
        Me.PictureBox1.TabStop = False
        '
        'Log_Out
        '
        Me.Log_Out.BackColor = System.Drawing.Color.White
        Me.Log_Out.FlatAppearance.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.Log_Out.FlatAppearance.BorderSize = 0
        Me.Log_Out.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray
        Me.Log_Out.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.Log_Out.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Log_Out.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.Log_Out.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Log_Out.Location = New System.Drawing.Point(291, 234)
        Me.Log_Out.Margin = New System.Windows.Forms.Padding(4)
        Me.Log_Out.Name = "Log_Out"
        Me.Log_Out.Size = New System.Drawing.Size(174, 82)
        Me.Log_Out.TabIndex = 90
        Me.Log_Out.Text = "Wyloguj"
        Me.Log_Out.UseVisualStyleBackColor = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(131, 157)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(139, 20)
        Me.TextBox1.TabIndex = 101
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(131, 125)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(139, 21)
        Me.ComboBox1.TabIndex = 103
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 381)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 104
        Me.Label1.Text = "Label1"
        '
        'Main
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.ClientSize = New System.Drawing.Size(611, 415)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Log_Out)
        Me.Controls.Add(Me.Log_In)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.MTextBoxPort)
        Me.Controls.Add(Me.MTextBoxAmsNetId)
        Me.Controls.Add(Me.ButStart)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(300, 400)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu"
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents ButStart As Button
    Friend WithEvents MTextBoxPort As MaskedTextBox
    Friend WithEvents MTextBoxAmsNetId As MaskedTextBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents Button10 As Button
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents Log_In As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Log_Out As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label1 As Label
End Class
