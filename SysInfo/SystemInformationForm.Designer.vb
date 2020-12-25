<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SystemInformationForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SystemInformationForm))
        Me.buildguid = New System.Windows.Forms.Label()
        Me.RegOrg = New System.Windows.Forms.Label()
        Me.RegOwner = New System.Windows.Forms.Label()
        Me.releaseid = New System.Windows.Forms.Label()
        Me.build = New System.Windows.Forms.Label()
        Me.edition = New System.Windows.Forms.Label()
        Me.ver = New System.Windows.Forms.Label()
        Me.Close = New System.Windows.Forms.Button()
        Me.cpu = New System.Windows.Forms.Label()
        Me.ram = New System.Windows.Forms.Label()
        Me.displayadapter = New System.Windows.Forms.Label()
        Me.Copy = New System.Windows.Forms.Button()
        Me.CopyLblTimer = New System.Windows.Forms.Timer(Me.components)
        Me.DriveType = New System.Windows.Forms.Label()
        Me.SystemRoot = New System.Windows.Forms.Label()
        Me.SaveInfoDialog = New System.Windows.Forms.SaveFileDialog()
        Me.AboutSysinfoTool = New System.Windows.Forms.ToolTip(Me.components)
        Me.Export = New System.Windows.Forms.ToolTip(Me.components)
        Me.Vista = New System.Windows.Forms.ToolTip(Me.components)
        Me.seven = New System.Windows.Forms.ToolTip(Me.components)
        Me.eight = New System.Windows.Forms.ToolTip(Me.components)
        Me.eightpoint1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ten = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.info = New System.Windows.Forms.PictureBox()
        Me.CloseBut = New System.Windows.Forms.PictureBox()
        Me.minimize = New System.Windows.Forms.PictureBox()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.SaveButton = New System.Windows.Forms.PictureBox()
        Me.TitleBar = New System.Windows.Forms.Label()
        Me.BasicSys = New System.Windows.Forms.CheckBox()
        Me.min = New System.Windows.Forms.ToolTip(Me.components)
        Me.CloseTool = New System.Windows.Forms.ToolTip(Me.components)
        Me.XpTool = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.XPVertool = New System.Windows.Forms.ToolTip(Me.components)
        Me.Xp = New System.Windows.Forms.PictureBox()
        Me.XpEnable = New System.Windows.Forms.PictureBox()
        Me.DisableXPStyle = New System.Windows.Forms.PictureBox()
        Me.Win7Vistalogo = New System.Windows.Forms.PictureBox()
        Me.Win810logo = New System.Windows.Forms.PictureBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.PerfClickRbn = New System.Windows.Forms.Label()
        Me.SysClickRbn = New System.Windows.Forms.Label()
        Me.FakeCheck = New System.Windows.Forms.Label()
        Me.PerfTab = New System.Windows.Forms.Panel()
        Me.slower = New System.Windows.Forms.Label()
        Me.faster = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.adjlbl = New System.Windows.Forms.Label()
        Me.TimerTrackbar = New System.Windows.Forms.TrackBar()
        Me.rammeter_ = New System.Windows.Forms.ProgressBar()
        Me.cpumeter_ = New System.Windows.Forms.ProgressBar()
        Me.cpuname = New System.Windows.Forms.Label()
        Me.rammeter = New System.Windows.Forms.Label()
        Me.cpumeter = New System.Windows.Forms.Label()
        Me.CPUMet = New System.Diagnostics.PerformanceCounter()
        Me.usagetimer = New System.Windows.Forms.Timer(Me.components)
        Me.Rammet = New System.Diagnostics.PerformanceCounter()
        Me.Panel7.SuspendLayout()
        CType(Me.info, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CloseBut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.minimize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SaveButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Xp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XpEnable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DisableXPStyle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Win7Vistalogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Win810logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.PerfTab.SuspendLayout()
        CType(Me.TimerTrackbar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CPUMet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Rammet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'buildguid
        '
        Me.buildguid.AutoSize = True
        Me.buildguid.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buildguid.Location = New System.Drawing.Point(12, 204)
        Me.buildguid.Name = "buildguid"
        Me.buildguid.Size = New System.Drawing.Size(58, 15)
        Me.buildguid.TabIndex = 13
        Me.buildguid.Text = "buildguid"
        '
        'RegOrg
        '
        Me.RegOrg.AutoSize = True
        Me.RegOrg.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RegOrg.Location = New System.Drawing.Point(12, 180)
        Me.RegOrg.Name = "RegOrg"
        Me.RegOrg.Size = New System.Drawing.Size(42, 15)
        Me.RegOrg.TabIndex = 12
        Me.RegOrg.Text = "regorg"
        '
        'RegOwner
        '
        Me.RegOwner.AutoSize = True
        Me.RegOwner.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RegOwner.Location = New System.Drawing.Point(12, 156)
        Me.RegOwner.Name = "RegOwner"
        Me.RegOwner.Size = New System.Drawing.Size(57, 15)
        Me.RegOwner.TabIndex = 11
        Me.RegOwner.Text = "regowner"
        '
        'releaseid
        '
        Me.releaseid.AutoSize = True
        Me.releaseid.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.releaseid.Location = New System.Drawing.Point(12, 84)
        Me.releaseid.Name = "releaseid"
        Me.releaseid.Size = New System.Drawing.Size(53, 15)
        Me.releaseid.TabIndex = 10
        Me.releaseid.Text = "releaseid"
        Me.releaseid.Visible = False
        '
        'build
        '
        Me.build.AutoSize = True
        Me.build.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.build.Location = New System.Drawing.Point(12, 108)
        Me.build.Name = "build"
        Me.build.Size = New System.Drawing.Size(34, 15)
        Me.build.TabIndex = 9
        Me.build.Text = "build"
        '
        'edition
        '
        Me.edition.AutoSize = True
        Me.edition.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.edition.Location = New System.Drawing.Point(12, 132)
        Me.edition.Name = "edition"
        Me.edition.Size = New System.Drawing.Size(44, 15)
        Me.edition.TabIndex = 8
        Me.edition.Text = "edition"
        '
        'ver
        '
        Me.ver.AutoSize = True
        Me.ver.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ver.Location = New System.Drawing.Point(13, 60)
        Me.ver.Name = "ver"
        Me.ver.Size = New System.Drawing.Size(23, 15)
        Me.ver.TabIndex = 7
        Me.ver.Text = "ver"
        '
        'Close
        '
        Me.Close.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Close.Location = New System.Drawing.Point(425, 313)
        Me.Close.Name = "Close"
        Me.Close.Size = New System.Drawing.Size(75, 23)
        Me.Close.TabIndex = 16
        Me.Close.Text = "Close"
        Me.Close.UseVisualStyleBackColor = True
        '
        'cpu
        '
        Me.cpu.AutoSize = True
        Me.cpu.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cpu.Location = New System.Drawing.Point(12, 228)
        Me.cpu.Name = "cpu"
        Me.cpu.Size = New System.Drawing.Size(27, 15)
        Me.cpu.TabIndex = 17
        Me.cpu.Text = "cpu"
        '
        'ram
        '
        Me.ram.AutoSize = True
        Me.ram.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ram.Location = New System.Drawing.Point(12, 252)
        Me.ram.Name = "ram"
        Me.ram.Size = New System.Drawing.Size(28, 15)
        Me.ram.TabIndex = 18
        Me.ram.Text = "ram"
        '
        'displayadapter
        '
        Me.displayadapter.AutoSize = True
        Me.displayadapter.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.displayadapter.Location = New System.Drawing.Point(12, 276)
        Me.displayadapter.Name = "displayadapter"
        Me.displayadapter.Size = New System.Drawing.Size(84, 15)
        Me.displayadapter.TabIndex = 19
        Me.displayadapter.Text = "displayadapter"
        '
        'Copy
        '
        Me.Copy.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Copy.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Copy.Location = New System.Drawing.Point(425, 283)
        Me.Copy.Name = "Copy"
        Me.Copy.Size = New System.Drawing.Size(75, 23)
        Me.Copy.TabIndex = 24
        Me.Copy.Text = "Copy"
        Me.Copy.UseVisualStyleBackColor = True
        '
        'CopyLblTimer
        '
        Me.CopyLblTimer.Enabled = True
        '
        'DriveType
        '
        Me.DriveType.AutoSize = True
        Me.DriveType.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DriveType.Location = New System.Drawing.Point(13, 324)
        Me.DriveType.Name = "DriveType"
        Me.DriveType.Size = New System.Drawing.Size(67, 15)
        Me.DriveType.TabIndex = 29
        Me.DriveType.Text = "hdd,ssd,etc"
        '
        'SystemRoot
        '
        Me.SystemRoot.AutoSize = True
        Me.SystemRoot.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SystemRoot.Location = New System.Drawing.Point(13, 300)
        Me.SystemRoot.Name = "SystemRoot"
        Me.SystemRoot.Size = New System.Drawing.Size(45, 15)
        Me.SystemRoot.TabIndex = 30
        Me.SystemRoot.Text = "sysroot"
        '
        'SaveInfoDialog
        '
        Me.SaveInfoDialog.AddExtension = False
        '
        'AboutSysinfoTool
        '
        Me.AboutSysinfoTool.AutomaticDelay = 100
        Me.AboutSysinfoTool.AutoPopDelay = 5000
        Me.AboutSysinfoTool.InitialDelay = 100
        Me.AboutSysinfoTool.ReshowDelay = 20
        '
        'Export
        '
        Me.Export.AutomaticDelay = 100
        Me.Export.AutoPopDelay = 5000
        Me.Export.InitialDelay = 100
        Me.Export.ReshowDelay = 20
        '
        'Vista
        '
        Me.Vista.AutomaticDelay = 100
        Me.Vista.AutoPopDelay = 5000
        Me.Vista.InitialDelay = 100
        Me.Vista.ReshowDelay = 20
        '
        'seven
        '
        Me.seven.AutomaticDelay = 100
        Me.seven.AutoPopDelay = 5000
        Me.seven.InitialDelay = 100
        Me.seven.ReshowDelay = 20
        '
        'eight
        '
        Me.eight.AutomaticDelay = 100
        Me.eight.AutoPopDelay = 5000
        Me.eight.InitialDelay = 100
        Me.eight.ReshowDelay = 20
        '
        'eightpoint1
        '
        Me.eightpoint1.AutomaticDelay = 10
        Me.eightpoint1.AutoPopDelay = 5000
        Me.eightpoint1.InitialDelay = 10
        Me.eightpoint1.ReshowDelay = 2
        '
        'ten
        '
        Me.ten.AutomaticDelay = 100
        Me.ten.AutoPopDelay = 5000
        Me.ten.InitialDelay = 100
        Me.ten.ReshowDelay = 20
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Panel7.Controls.Add(Me.info)
        Me.Panel7.Controls.Add(Me.CloseBut)
        Me.Panel7.Controls.Add(Me.minimize)
        Me.Panel7.Controls.Add(Me.Panel8)
        Me.Panel7.Controls.Add(Me.PictureBox3)
        Me.Panel7.Controls.Add(Me.SaveButton)
        Me.Panel7.Controls.Add(Me.TitleBar)
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(505, 26)
        Me.Panel7.TabIndex = 36
        '
        'info
        '
        Me.info.Image = Global.SysInfo.My.Resources.Resources.iconhelp
        Me.info.Location = New System.Drawing.Point(429, 0)
        Me.info.Name = "info"
        Me.info.Size = New System.Drawing.Size(26, 26)
        Me.info.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.info.TabIndex = 42
        Me.info.TabStop = False
        '
        'CloseBut
        '
        Me.CloseBut.Image = Global.SysInfo.My.Resources.Resources.clsbtn
        Me.CloseBut.Location = New System.Drawing.Point(479, 0)
        Me.CloseBut.Name = "CloseBut"
        Me.CloseBut.Size = New System.Drawing.Size(26, 26)
        Me.CloseBut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.CloseBut.TabIndex = 41
        Me.CloseBut.TabStop = False
        '
        'minimize
        '
        Me.minimize.Image = Global.SysInfo.My.Resources.Resources.minbutton
        Me.minimize.Location = New System.Drawing.Point(454, 0)
        Me.minimize.Name = "minimize"
        Me.minimize.Size = New System.Drawing.Size(26, 26)
        Me.minimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.minimize.TabIndex = 38
        Me.minimize.TabStop = False
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Panel8.Location = New System.Drawing.Point(0, 336)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(505, 5)
        Me.Panel8.TabIndex = 35
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.SysInfo.My.Resources.Resources.pclogo16
        Me.PictureBox3.Location = New System.Drawing.Point(7, 5)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 39
        Me.PictureBox3.TabStop = False
        '
        'SaveButton
        '
        Me.SaveButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SaveButton.Image = Global.SysInfo.My.Resources.Resources.save
        Me.SaveButton.Location = New System.Drawing.Point(27, 5)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(16, 16)
        Me.SaveButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.SaveButton.TabIndex = 31
        Me.SaveButton.TabStop = False
        '
        'TitleBar
        '
        Me.TitleBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TitleBar.Enabled = False
        Me.TitleBar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitleBar.ForeColor = System.Drawing.Color.Black
        Me.TitleBar.Location = New System.Drawing.Point(0, 0)
        Me.TitleBar.Name = "TitleBar"
        Me.TitleBar.Size = New System.Drawing.Size(505, 26)
        Me.TitleBar.TabIndex = 40
        Me.TitleBar.Text = "Basic System Information"
        Me.TitleBar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BasicSys
        '
        Me.BasicSys.AutoSize = True
        Me.BasicSys.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.BasicSys.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.BasicSys.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BasicSys.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BasicSys.ForeColor = System.Drawing.Color.Black
        Me.BasicSys.Location = New System.Drawing.Point(7, 2)
        Me.BasicSys.Name = "BasicSys"
        Me.BasicSys.Size = New System.Drawing.Size(32, 20)
        Me.BasicSys.TabIndex = 44
        Me.BasicSys.Text = "‎"
        Me.BasicSys.UseVisualStyleBackColor = False
        '
        'min
        '
        Me.min.AutomaticDelay = 100
        '
        'CloseTool
        '
        Me.CloseTool.AutomaticDelay = 100
        Me.CloseTool.AutoPopDelay = 5000
        Me.CloseTool.InitialDelay = 100
        Me.CloseTool.ReshowDelay = 20
        '
        'XpTool
        '
        Me.XpTool.AutomaticDelay = 100
        Me.XpTool.AutoPopDelay = 5000
        Me.XpTool.BackColor = System.Drawing.Color.White
        Me.XpTool.InitialDelay = 100
        Me.XpTool.ReshowDelay = 20
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 348)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(504, 1)
        Me.Panel1.TabIndex = 39
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Black
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(504, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1, 349)
        Me.Panel3.TabIndex = 40
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(505, 1)
        Me.Panel2.TabIndex = 41
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Black
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1, 348)
        Me.Panel4.TabIndex = 42
        '
        'XPVertool
        '
        Me.XPVertool.AutomaticDelay = 100
        Me.XPVertool.AutoPopDelay = 5000
        Me.XPVertool.BackColor = System.Drawing.Color.White
        Me.XPVertool.InitialDelay = 100
        Me.XPVertool.ReshowDelay = 20
        '
        'Xp
        '
        Me.Xp.Image = Global.SysInfo.My.Resources.Resources.mswinxp
        Me.Xp.Location = New System.Drawing.Point(428, 70)
        Me.Xp.Name = "Xp"
        Me.Xp.Size = New System.Drawing.Size(72, 72)
        Me.Xp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Xp.TabIndex = 43
        Me.Xp.TabStop = False
        Me.Xp.Visible = False
        '
        'XpEnable
        '
        Me.XpEnable.BackColor = System.Drawing.Color.White
        Me.XpEnable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.XpEnable.Cursor = System.Windows.Forms.Cursors.Hand
        Me.XpEnable.Image = CType(resources.GetObject("XpEnable.Image"), System.Drawing.Image)
        Me.XpEnable.Location = New System.Drawing.Point(351, 70)
        Me.XpEnable.Name = "XpEnable"
        Me.XpEnable.Size = New System.Drawing.Size(72, 72)
        Me.XpEnable.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.XpEnable.TabIndex = 38
        Me.XpEnable.TabStop = False
        '
        'DisableXPStyle
        '
        Me.DisableXPStyle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DisableXPStyle.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DisableXPStyle.Enabled = False
        Me.DisableXPStyle.Image = CType(resources.GetObject("DisableXPStyle.Image"), System.Drawing.Image)
        Me.DisableXPStyle.Location = New System.Drawing.Point(351, 70)
        Me.DisableXPStyle.Name = "DisableXPStyle"
        Me.DisableXPStyle.Size = New System.Drawing.Size(72, 72)
        Me.DisableXPStyle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.DisableXPStyle.TabIndex = 37
        Me.DisableXPStyle.TabStop = False
        Me.DisableXPStyle.Visible = False
        '
        'Win7Vistalogo
        '
        Me.Win7Vistalogo.Image = CType(resources.GetObject("Win7Vistalogo.Image"), System.Drawing.Image)
        Me.Win7Vistalogo.Location = New System.Drawing.Point(428, 70)
        Me.Win7Vistalogo.Name = "Win7Vistalogo"
        Me.Win7Vistalogo.Size = New System.Drawing.Size(72, 72)
        Me.Win7Vistalogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Win7Vistalogo.TabIndex = 27
        Me.Win7Vistalogo.TabStop = False
        Me.Win7Vistalogo.Visible = False
        '
        'Win810logo
        '
        Me.Win810logo.Image = CType(resources.GetObject("Win810logo.Image"), System.Drawing.Image)
        Me.Win810logo.Location = New System.Drawing.Point(428, 70)
        Me.Win810logo.Name = "Win810logo"
        Me.Win810logo.Size = New System.Drawing.Size(72, 72)
        Me.Win810logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Win810logo.TabIndex = 26
        Me.Win810logo.TabStop = False
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Panel5.Controls.Add(Me.PerfClickRbn)
        Me.Panel5.Controls.Add(Me.SysClickRbn)
        Me.Panel5.Controls.Add(Me.FakeCheck)
        Me.Panel5.Controls.Add(Me.BasicSys)
        Me.Panel5.Location = New System.Drawing.Point(0, 25)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(505, 26)
        Me.Panel5.TabIndex = 43
        '
        'PerfClickRbn
        '
        Me.PerfClickRbn.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PerfClickRbn.Location = New System.Drawing.Point(399, 0)
        Me.PerfClickRbn.Name = "PerfClickRbn"
        Me.PerfClickRbn.Size = New System.Drawing.Size(99, 26)
        Me.PerfClickRbn.TabIndex = 46
        Me.PerfClickRbn.Text = "Performance"
        Me.PerfClickRbn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SysClickRbn
        '
        Me.SysClickRbn.BackColor = System.Drawing.Color.White
        Me.SysClickRbn.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SysClickRbn.Location = New System.Drawing.Point(329, 0)
        Me.SysClickRbn.Name = "SysClickRbn"
        Me.SysClickRbn.Size = New System.Drawing.Size(67, 26)
        Me.SysClickRbn.TabIndex = 45
        Me.SysClickRbn.Text = "System"
        Me.SysClickRbn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FakeCheck
        '
        Me.FakeCheck.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FakeCheck.Enabled = False
        Me.FakeCheck.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FakeCheck.ForeColor = System.Drawing.Color.Black
        Me.FakeCheck.Location = New System.Drawing.Point(23, -1)
        Me.FakeCheck.Name = "FakeCheck"
        Me.FakeCheck.Size = New System.Drawing.Size(158, 24)
        Me.FakeCheck.TabIndex = 43
        Me.FakeCheck.Text = "Show Advanced Information"
        Me.FakeCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PerfTab
        '
        Me.PerfTab.Controls.Add(Me.slower)
        Me.PerfTab.Controls.Add(Me.faster)
        Me.PerfTab.Controls.Add(Me.Label4)
        Me.PerfTab.Controls.Add(Me.adjlbl)
        Me.PerfTab.Controls.Add(Me.TimerTrackbar)
        Me.PerfTab.Controls.Add(Me.rammeter_)
        Me.PerfTab.Controls.Add(Me.cpumeter_)
        Me.PerfTab.Controls.Add(Me.cpuname)
        Me.PerfTab.Controls.Add(Me.rammeter)
        Me.PerfTab.Controls.Add(Me.cpumeter)
        Me.PerfTab.Location = New System.Drawing.Point(0, 50)
        Me.PerfTab.Name = "PerfTab"
        Me.PerfTab.Size = New System.Drawing.Size(505, 299)
        Me.PerfTab.TabIndex = 44
        Me.PerfTab.Visible = False
        '
        'slower
        '
        Me.slower.AutoSize = True
        Me.slower.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.slower.Location = New System.Drawing.Point(414, 43)
        Me.slower.Name = "slower"
        Me.slower.Size = New System.Drawing.Size(59, 15)
        Me.slower.TabIndex = 9
        Me.slower.Text = "Slower   >"
        Me.slower.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'faster
        '
        Me.faster.AutoSize = True
        Me.faster.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.faster.Location = New System.Drawing.Point(303, 43)
        Me.faster.Name = "faster"
        Me.faster.Size = New System.Drawing.Size(55, 15)
        Me.faster.TabIndex = 8
        Me.faster.Text = "<   Faster"
        Me.faster.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 15)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "ramslots"
        '
        'adjlbl
        '
        Me.adjlbl.AutoSize = True
        Me.adjlbl.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.adjlbl.Location = New System.Drawing.Point(266, 95)
        Me.adjlbl.Name = "adjlbl"
        Me.adjlbl.Size = New System.Drawing.Size(234, 15)
        Me.adjlbl.TabIndex = 6
        Me.adjlbl.Text = "Adjust CPU and RAM meter refresh interval"
        Me.adjlbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TimerTrackbar
        '
        Me.TimerTrackbar.Location = New System.Drawing.Point(297, 61)
        Me.TimerTrackbar.Maximum = 12
        Me.TimerTrackbar.Minimum = 1
        Me.TimerTrackbar.Name = "TimerTrackbar"
        Me.TimerTrackbar.Size = New System.Drawing.Size(179, 45)
        Me.TimerTrackbar.TabIndex = 5
        Me.TimerTrackbar.Value = 6
        '
        'rammeter_
        '
        Me.rammeter_.Location = New System.Drawing.Point(138, 83)
        Me.rammeter_.Name = "rammeter_"
        Me.rammeter_.Size = New System.Drawing.Size(133, 8)
        Me.rammeter_.TabIndex = 4
        Me.rammeter_.Visible = False
        '
        'cpumeter_
        '
        Me.cpumeter_.Location = New System.Drawing.Point(138, 60)
        Me.cpumeter_.Name = "cpumeter_"
        Me.cpumeter_.Size = New System.Drawing.Size(133, 8)
        Me.cpumeter_.TabIndex = 3
        Me.cpumeter_.Visible = False
        '
        'cpuname
        '
        Me.cpuname.AutoSize = True
        Me.cpuname.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cpuname.Location = New System.Drawing.Point(12, 12)
        Me.cpuname.Name = "cpuname"
        Me.cpuname.Size = New System.Drawing.Size(77, 15)
        Me.cpuname.TabIndex = 2
        Me.cpuname.Text = "motherboard"
        '
        'rammeter
        '
        Me.rammeter.AutoSize = True
        Me.rammeter.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rammeter.Location = New System.Drawing.Point(12, 78)
        Me.rammeter.Name = "rammeter"
        Me.rammeter.Size = New System.Drawing.Size(41, 15)
        Me.rammeter.TabIndex = 1
        Me.rammeter.Text = "Label4"
        '
        'cpumeter
        '
        Me.cpumeter.AutoSize = True
        Me.cpumeter.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cpumeter.Location = New System.Drawing.Point(12, 56)
        Me.cpumeter.Name = "cpumeter"
        Me.cpumeter.Size = New System.Drawing.Size(41, 15)
        Me.cpumeter.TabIndex = 0
        Me.cpumeter.Text = "Label1"
        '
        'CPUMet
        '
        Me.CPUMet.CategoryName = "Processor"
        Me.CPUMet.CounterName = "% Processor Time"
        Me.CPUMet.InstanceName = "_Total"
        '
        'usagetimer
        '
        Me.usagetimer.Enabled = True
        Me.usagetimer.Interval = 1000
        '
        'Rammet
        '
        Me.Rammet.CategoryName = "Memory"
        Me.Rammet.CounterName = "% Committed Bytes In Use"
        '
        'SystemInformationForm
        '
        Me.AcceptButton = Me.Copy
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(505, 349)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.PerfTab)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Xp)
        Me.Controls.Add(Me.XpEnable)
        Me.Controls.Add(Me.DisableXPStyle)
        Me.Controls.Add(Me.SystemRoot)
        Me.Controls.Add(Me.DriveType)
        Me.Controls.Add(Me.Win7Vistalogo)
        Me.Controls.Add(Me.Win810logo)
        Me.Controls.Add(Me.Copy)
        Me.Controls.Add(Me.displayadapter)
        Me.Controls.Add(Me.ram)
        Me.Controls.Add(Me.cpu)
        Me.Controls.Add(Me.Close)
        Me.Controls.Add(Me.buildguid)
        Me.Controls.Add(Me.RegOrg)
        Me.Controls.Add(Me.RegOwner)
        Me.Controls.Add(Me.releaseid)
        Me.Controls.Add(Me.build)
        Me.Controls.Add(Me.edition)
        Me.Controls.Add(Me.ver)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Panel5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "SystemInformationForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Basic System Information"
        Me.Panel7.ResumeLayout(False)
        CType(Me.info, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CloseBut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.minimize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SaveButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Xp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XpEnable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DisableXPStyle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Win7Vistalogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Win810logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.PerfTab.ResumeLayout(False)
        Me.PerfTab.PerformLayout()
        CType(Me.TimerTrackbar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CPUMet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Rammet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents buildguid As System.Windows.Forms.Label
    Friend WithEvents RegOrg As System.Windows.Forms.Label
    Friend WithEvents RegOwner As System.Windows.Forms.Label
    Friend WithEvents releaseid As System.Windows.Forms.Label
    Friend WithEvents build As System.Windows.Forms.Label
    Friend WithEvents edition As System.Windows.Forms.Label
    Friend WithEvents ver As System.Windows.Forms.Label
    Friend WithEvents Close As System.Windows.Forms.Button
    Friend WithEvents cpu As System.Windows.Forms.Label
    Friend WithEvents ram As Label
    Friend WithEvents displayadapter As Label
    Friend WithEvents Copy As Button
    Friend WithEvents CopyLblTimer As Timer
    Friend WithEvents Win810logo As PictureBox
    Friend WithEvents Win7Vistalogo As PictureBox
    Friend WithEvents DriveType As Label
    Friend WithEvents SystemRoot As Label
    Friend WithEvents SaveButton As PictureBox
    Public WithEvents SaveInfoDialog As SaveFileDialog
    Friend WithEvents AboutSysinfoTool As ToolTip
    Friend WithEvents Export As ToolTip
    Friend WithEvents Vista As ToolTip
    Friend WithEvents seven As ToolTip
    Friend WithEvents eight As ToolTip
    Friend WithEvents eightpoint1 As ToolTip
    Friend WithEvents ten As ToolTip
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents minimize As PictureBox
    Friend WithEvents TitleBar As Label
    Friend WithEvents min As ToolTip
    Friend WithEvents CloseBut As PictureBox
    Friend WithEvents CloseTool As ToolTip
    Friend WithEvents DisableXPStyle As PictureBox
    Friend WithEvents XpEnable As PictureBox
    Friend WithEvents XpTool As ToolTip
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents info As PictureBox
    Friend WithEvents Xp As PictureBox
    Friend WithEvents XPVertool As ToolTip
    Friend WithEvents BasicSys As CheckBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents PerfClickRbn As Label
    Friend WithEvents SysClickRbn As Label
    Friend WithEvents FakeCheck As Label
    Friend WithEvents PerfTab As Panel
    Friend WithEvents cpumeter As Label
    Friend WithEvents rammeter As Label
    Friend WithEvents cpuname As Label
    Friend WithEvents CPUMet As PerformanceCounter
    Friend WithEvents usagetimer As Timer
    Friend WithEvents TimerTrackbar As TrackBar
    Friend WithEvents Rammet As PerformanceCounter
    Friend WithEvents rammeter_ As ProgressBar
    Friend WithEvents cpumeter_ As ProgressBar
    Friend WithEvents adjlbl As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents slower As Label
    Friend WithEvents faster As Label
End Class
