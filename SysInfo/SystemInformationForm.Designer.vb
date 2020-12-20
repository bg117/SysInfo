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
        Me.SaveButton = New System.Windows.Forms.PictureBox()
        Me.info = New System.Windows.Forms.PictureBox()
        Me.Win7Vistalogo = New System.Windows.Forms.PictureBox()
        Me.Win810logo = New System.Windows.Forms.PictureBox()
        Me.SaveInfoDialog = New System.Windows.Forms.SaveFileDialog()
        Me.AboutSysinfoTool = New System.Windows.Forms.ToolTip(Me.components)
        Me.Export = New System.Windows.Forms.ToolTip(Me.components)
        Me.BasicSys = New System.Windows.Forms.RadioButton()
        Me.AdvSys = New System.Windows.Forms.RadioButton()
        Me.Vista = New System.Windows.Forms.ToolTip(Me.components)
        Me.seven = New System.Windows.Forms.ToolTip(Me.components)
        Me.eight = New System.Windows.Forms.ToolTip(Me.components)
        Me.eightpoint1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ten = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.SaveButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.info, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Win7Vistalogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Win810logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'buildguid
        '
        Me.buildguid.AutoSize = True
        Me.buildguid.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buildguid.Location = New System.Drawing.Point(12, 177)
        Me.buildguid.Name = "buildguid"
        Me.buildguid.Size = New System.Drawing.Size(58, 15)
        Me.buildguid.TabIndex = 13
        Me.buildguid.Text = "buildguid"
        '
        'RegOrg
        '
        Me.RegOrg.AutoSize = True
        Me.RegOrg.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RegOrg.Location = New System.Drawing.Point(12, 153)
        Me.RegOrg.Name = "RegOrg"
        Me.RegOrg.Size = New System.Drawing.Size(42, 15)
        Me.RegOrg.TabIndex = 12
        Me.RegOrg.Text = "regorg"
        '
        'RegOwner
        '
        Me.RegOwner.AutoSize = True
        Me.RegOwner.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RegOwner.Location = New System.Drawing.Point(12, 129)
        Me.RegOwner.Name = "RegOwner"
        Me.RegOwner.Size = New System.Drawing.Size(57, 15)
        Me.RegOwner.TabIndex = 11
        Me.RegOwner.Text = "regowner"
        '
        'releaseid
        '
        Me.releaseid.AutoSize = True
        Me.releaseid.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.releaseid.Location = New System.Drawing.Point(12, 57)
        Me.releaseid.Name = "releaseid"
        Me.releaseid.Size = New System.Drawing.Size(53, 15)
        Me.releaseid.TabIndex = 10
        Me.releaseid.Text = "releaseid"
        '
        'build
        '
        Me.build.AutoSize = True
        Me.build.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.build.Location = New System.Drawing.Point(12, 81)
        Me.build.Name = "build"
        Me.build.Size = New System.Drawing.Size(34, 15)
        Me.build.TabIndex = 9
        Me.build.Text = "build"
        '
        'edition
        '
        Me.edition.AutoSize = True
        Me.edition.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.edition.Location = New System.Drawing.Point(12, 105)
        Me.edition.Name = "edition"
        Me.edition.Size = New System.Drawing.Size(44, 15)
        Me.edition.TabIndex = 8
        Me.edition.Text = "edition"
        '
        'ver
        '
        Me.ver.AutoSize = True
        Me.ver.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ver.Location = New System.Drawing.Point(13, 33)
        Me.ver.Name = "ver"
        Me.ver.Size = New System.Drawing.Size(23, 15)
        Me.ver.TabIndex = 7
        Me.ver.Text = "ver"
        '
        'Close
        '
        Me.Close.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Close.Location = New System.Drawing.Point(418, 289)
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
        Me.cpu.Location = New System.Drawing.Point(12, 201)
        Me.cpu.Name = "cpu"
        Me.cpu.Size = New System.Drawing.Size(27, 15)
        Me.cpu.TabIndex = 17
        Me.cpu.Text = "cpu"
        '
        'ram
        '
        Me.ram.AutoSize = True
        Me.ram.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ram.Location = New System.Drawing.Point(12, 225)
        Me.ram.Name = "ram"
        Me.ram.Size = New System.Drawing.Size(28, 15)
        Me.ram.TabIndex = 18
        Me.ram.Text = "ram"
        '
        'displayadapter
        '
        Me.displayadapter.AutoSize = True
        Me.displayadapter.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.displayadapter.Location = New System.Drawing.Point(12, 249)
        Me.displayadapter.Name = "displayadapter"
        Me.displayadapter.Size = New System.Drawing.Size(84, 15)
        Me.displayadapter.TabIndex = 19
        Me.displayadapter.Text = "displayadapter"
        '
        'Copy
        '
        Me.Copy.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Copy.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Copy.Location = New System.Drawing.Point(418, 259)
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
        Me.DriveType.Location = New System.Drawing.Point(13, 297)
        Me.DriveType.Name = "DriveType"
        Me.DriveType.Size = New System.Drawing.Size(67, 15)
        Me.DriveType.TabIndex = 29
        Me.DriveType.Text = "hdd,ssd,etc"
        '
        'SystemRoot
        '
        Me.SystemRoot.AutoSize = True
        Me.SystemRoot.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SystemRoot.Location = New System.Drawing.Point(13, 273)
        Me.SystemRoot.Name = "SystemRoot"
        Me.SystemRoot.Size = New System.Drawing.Size(45, 15)
        Me.SystemRoot.TabIndex = 30
        Me.SystemRoot.Text = "sysroot"
        '
        'SaveButton
        '
        Me.SaveButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SaveButton.Image = Global.SysInfo.My.Resources.Resources.save
        Me.SaveButton.Location = New System.Drawing.Point(468, 5)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(32, 32)
        Me.SaveButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.SaveButton.TabIndex = 31
        Me.SaveButton.TabStop = False
        '
        'info
        '
        Me.info.Cursor = System.Windows.Forms.Cursors.Hand
        Me.info.Image = Global.SysInfo.My.Resources.Resources.info
        Me.info.Location = New System.Drawing.Point(429, 5)
        Me.info.Name = "info"
        Me.info.Size = New System.Drawing.Size(32, 32)
        Me.info.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.info.TabIndex = 28
        Me.info.TabStop = False
        '
        'Win7Vistalogo
        '
        Me.Win7Vistalogo.Image = Global.SysInfo.My.Resources.Resources.redmond7
        Me.Win7Vistalogo.Location = New System.Drawing.Point(402, 43)
        Me.Win7Vistalogo.Name = "Win7Vistalogo"
        Me.Win7Vistalogo.Size = New System.Drawing.Size(96, 96)
        Me.Win7Vistalogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Win7Vistalogo.TabIndex = 27
        Me.Win7Vistalogo.TabStop = False
        Me.Win7Vistalogo.Visible = False
        '
        'Win810logo
        '
        Me.Win810logo.Image = Global.SysInfo.My.Resources.Resources.redmond10
        Me.Win810logo.Location = New System.Drawing.Point(402, 43)
        Me.Win810logo.Name = "Win810logo"
        Me.Win810logo.Size = New System.Drawing.Size(96, 96)
        Me.Win810logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Win810logo.TabIndex = 26
        Me.Win810logo.TabStop = False
        '
        'SaveInfoDialog
        '
        Me.SaveInfoDialog.AddExtension = False
        '
        'BasicSys
        '
        Me.BasicSys.AutoSize = True
        Me.BasicSys.Checked = True
        Me.BasicSys.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BasicSys.Location = New System.Drawing.Point(12, 5)
        Me.BasicSys.Name = "BasicSys"
        Me.BasicSys.Size = New System.Drawing.Size(158, 19)
        Me.BasicSys.TabIndex = 32
        Me.BasicSys.TabStop = True
        Me.BasicSys.Text = "Basic system information"
        Me.BasicSys.UseVisualStyleBackColor = True
        '
        'AdvSys
        '
        Me.AdvSys.AutoSize = True
        Me.AdvSys.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AdvSys.Location = New System.Drawing.Point(171, 5)
        Me.AdvSys.Name = "AdvSys"
        Me.AdvSys.Size = New System.Drawing.Size(184, 19)
        Me.AdvSys.TabIndex = 33
        Me.AdvSys.Text = "Advanced system information"
        Me.AdvSys.UseVisualStyleBackColor = True
        '
        'SystemInformationForm
        '
        Me.AcceptButton = Me.Copy
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(505, 321)
        Me.Controls.Add(Me.AdvSys)
        Me.Controls.Add(Me.BasicSys)
        Me.Controls.Add(Me.SaveButton)
        Me.Controls.Add(Me.SystemRoot)
        Me.Controls.Add(Me.DriveType)
        Me.Controls.Add(Me.info)
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
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "SystemInformationForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Basic System Information"
        CType(Me.SaveButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.info, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Win7Vistalogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Win810logo, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents info As PictureBox
    Friend WithEvents DriveType As Label
    Friend WithEvents SystemRoot As Label
    Friend WithEvents SaveButton As PictureBox
    Public WithEvents SaveInfoDialog As SaveFileDialog
    Friend WithEvents AboutSysinfoTool As ToolTip
    Friend WithEvents Export As ToolTip
    Friend WithEvents BasicSys As RadioButton
    Friend WithEvents AdvSys As RadioButton
    Friend WithEvents Vista As ToolTip
    Friend WithEvents seven As ToolTip
    Friend WithEvents eight As ToolTip
    Friend WithEvents eightpoint1 As ToolTip
    Friend WithEvents ten As ToolTip
End Class
