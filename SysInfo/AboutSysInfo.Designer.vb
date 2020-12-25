<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AboutSysInfo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AboutSysInfo))
        Me.title = New System.Windows.Forms.Label()
        Me.desc = New System.Windows.Forms.Label()
        Me.versionabtpc = New System.Windows.Forms.Label()
        Me.assemver = New System.Windows.Forms.Label()
        Me.Copyright = New System.Windows.Forms.Label()
        Me.close = New System.Windows.Forms.Button()
        Me.githublink = New System.Windows.Forms.LinkLabel()
        Me.TitleBarAbt = New System.Windows.Forms.Panel()
        Me.CloseBut = New System.Windows.Forms.PictureBox()
        Me.minimize = New System.Windows.Forms.PictureBox()
        Me.TitleBar = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Min = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.TitleBarAbt.SuspendLayout()
        CType(Me.CloseBut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.minimize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'title
        '
        Me.title.AutoSize = True
        Me.title.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title.Location = New System.Drawing.Point(13, 30)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(79, 30)
        Me.title.TabIndex = 0
        Me.title.Text = "SysInfo"
        '
        'desc
        '
        Me.desc.AutoSize = True
        Me.desc.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.desc.Location = New System.Drawing.Point(14, 65)
        Me.desc.Name = "desc"
        Me.desc.Size = New System.Drawing.Size(401, 30)
        Me.desc.TabIndex = 1
        Me.desc.Text = "This is a simple application designed to display information about your PC." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "This" &
    " project is open-source. It can be found on"
        '
        'versionabtpc
        '
        Me.versionabtpc.AutoSize = True
        Me.versionabtpc.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.versionabtpc.Location = New System.Drawing.Point(14, 100)
        Me.versionabtpc.Name = "versionabtpc"
        Me.versionabtpc.Size = New System.Drawing.Size(163, 15)
        Me.versionabtpc.TabIndex = 2
        Me.versionabtpc.Text = "SysInfo version 1.0.0.2b (Beta)"
        '
        'assemver
        '
        Me.assemver.AutoSize = True
        Me.assemver.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.assemver.Location = New System.Drawing.Point(14, 120)
        Me.assemver.Name = "assemver"
        Me.assemver.Size = New System.Drawing.Size(135, 15)
        Me.assemver.TabIndex = 3
        Me.assemver.Text = "Assembly version 0.0.0.1"
        '
        'Copyright
        '
        Me.Copyright.AutoSize = True
        Me.Copyright.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Copyright.Location = New System.Drawing.Point(14, 140)
        Me.Copyright.Name = "Copyright"
        Me.Copyright.Size = New System.Drawing.Size(161, 15)
        Me.Copyright.TabIndex = 4
        Me.Copyright.Text = "Copyright © OpenCode 2020"
        '
        'close
        '
        Me.close.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.close.Location = New System.Drawing.Point(344, 160)
        Me.close.Name = "close"
        Me.close.Size = New System.Drawing.Size(75, 23)
        Me.close.TabIndex = 17
        Me.close.Text = "Close"
        Me.close.UseVisualStyleBackColor = True
        '
        'githublink
        '
        Me.githublink.AutoSize = True
        Me.githublink.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.githublink.Location = New System.Drawing.Point(261, 80)
        Me.githublink.Name = "githublink"
        Me.githublink.Size = New System.Drawing.Size(152, 15)
        Me.githublink.TabIndex = 18
        Me.githublink.TabStop = True
        Me.githublink.Text = "github.com/bg117/SysInfo."
        '
        'TitleBarAbt
        '
        Me.TitleBarAbt.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.TitleBarAbt.Controls.Add(Me.CloseBut)
        Me.TitleBarAbt.Controls.Add(Me.minimize)
        Me.TitleBarAbt.Controls.Add(Me.TitleBar)
        Me.TitleBarAbt.Controls.Add(Me.PictureBox3)
        Me.TitleBarAbt.Controls.Add(Me.Panel8)
        Me.TitleBarAbt.Location = New System.Drawing.Point(0, 0)
        Me.TitleBarAbt.Name = "TitleBarAbt"
        Me.TitleBarAbt.Size = New System.Drawing.Size(431, 26)
        Me.TitleBarAbt.TabIndex = 38
        '
        'CloseBut
        '
        Me.CloseBut.Image = Global.SysInfo.My.Resources.Resources.clsbtn
        Me.CloseBut.Location = New System.Drawing.Point(405, 0)
        Me.CloseBut.Name = "CloseBut"
        Me.CloseBut.Size = New System.Drawing.Size(26, 26)
        Me.CloseBut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.CloseBut.TabIndex = 44
        Me.CloseBut.TabStop = False
        '
        'minimize
        '
        Me.minimize.Image = Global.SysInfo.My.Resources.Resources.minbutton
        Me.minimize.Location = New System.Drawing.Point(380, 0)
        Me.minimize.Name = "minimize"
        Me.minimize.Size = New System.Drawing.Size(26, 26)
        Me.minimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.minimize.TabIndex = 43
        Me.minimize.TabStop = False
        '
        'TitleBar
        '
        Me.TitleBar.AutoSize = True
        Me.TitleBar.Enabled = False
        Me.TitleBar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitleBar.ForeColor = System.Drawing.Color.Black
        Me.TitleBar.Location = New System.Drawing.Point(175, 6)
        Me.TitleBar.Name = "TitleBar"
        Me.TitleBar.Size = New System.Drawing.Size(81, 15)
        Me.TitleBar.TabIndex = 42
        Me.TitleBar.Text = "About SysInfo"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.SysInfo.My.Resources.Resources.pclogo16
        Me.PictureBox3.Location = New System.Drawing.Point(7, 5)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 41
        Me.PictureBox3.TabStop = False
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Panel8.Location = New System.Drawing.Point(0, 336)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(505, 5)
        Me.Panel8.TabIndex = 35
        '
        'Min
        '
        Me.Min.AutomaticDelay = 100
        Me.Min.AutoPopDelay = 5000
        Me.Min.InitialDelay = 100
        Me.Min.ReshowDelay = 20
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(431, 1)
        Me.Panel2.TabIndex = 42
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1, 192)
        Me.Panel1.TabIndex = 43
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Black
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(430, 1)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1, 192)
        Me.Panel3.TabIndex = 44
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Black
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(1, 192)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(429, 1)
        Me.Panel4.TabIndex = 45
        '
        'AboutSysInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(431, 193)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.TitleBarAbt)
        Me.Controls.Add(Me.githublink)
        Me.Controls.Add(Me.close)
        Me.Controls.Add(Me.Copyright)
        Me.Controls.Add(Me.assemver)
        Me.Controls.Add(Me.versionabtpc)
        Me.Controls.Add(Me.desc)
        Me.Controls.Add(Me.title)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AboutSysInfo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About SysInfo"
        Me.TitleBarAbt.ResumeLayout(False)
        Me.TitleBarAbt.PerformLayout()
        CType(Me.CloseBut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.minimize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents title As Label
    Friend WithEvents desc As Label
    Friend WithEvents versionabtpc As Label
    Friend WithEvents assemver As Label
    Friend WithEvents Copyright As Label
    Friend WithEvents close As Button
    Friend WithEvents githublink As LinkLabel
    Friend WithEvents TitleBarAbt As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents TitleBar As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Min As ToolTip
    Friend WithEvents minimize As PictureBox
    Friend WithEvents CloseBut As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
End Class
