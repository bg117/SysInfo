<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AboutSysInfo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AboutSysInfo))
        Me.title = New System.Windows.Forms.Label()
        Me.desc = New System.Windows.Forms.Label()
        Me.versionabtpc = New System.Windows.Forms.Label()
        Me.assemver = New System.Windows.Forms.Label()
        Me.Copyright = New System.Windows.Forms.Label()
        Me.close = New System.Windows.Forms.Button()
        Me.githublink = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'title
        '
        Me.title.AutoSize = True
        Me.title.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title.Location = New System.Drawing.Point(13, 2)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(79, 30)
        Me.title.TabIndex = 0
        Me.title.Text = "SysInfo"
        '
        'desc
        '
        Me.desc.AutoSize = True
        Me.desc.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.desc.Location = New System.Drawing.Point(14, 40)
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
        Me.versionabtpc.Location = New System.Drawing.Point(14, 76)
        Me.versionabtpc.Name = "versionabtpc"
        Me.versionabtpc.Size = New System.Drawing.Size(163, 15)
        Me.versionabtpc.TabIndex = 2
        Me.versionabtpc.Text = "SysInfo version 1.0.0.0b (Beta)"
        '
        'assemver
        '
        Me.assemver.AutoSize = True
        Me.assemver.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.assemver.Location = New System.Drawing.Point(14, 97)
        Me.assemver.Name = "assemver"
        Me.assemver.Size = New System.Drawing.Size(135, 15)
        Me.assemver.TabIndex = 3
        Me.assemver.Text = "Assembly version 0.0.0.1"
        '
        'Copyright
        '
        Me.Copyright.AutoSize = True
        Me.Copyright.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Copyright.Location = New System.Drawing.Point(14, 118)
        Me.Copyright.Name = "Copyright"
        Me.Copyright.Size = New System.Drawing.Size(161, 15)
        Me.Copyright.TabIndex = 4
        Me.Copyright.Text = "Copyright © OpenCode 2020"
        '
        'close
        '
        Me.close.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.close.Location = New System.Drawing.Point(344, 135)
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
        Me.githublink.Location = New System.Drawing.Point(261, 55)
        Me.githublink.Name = "githublink"
        Me.githublink.Size = New System.Drawing.Size(152, 15)
        Me.githublink.TabIndex = 18
        Me.githublink.TabStop = True
        Me.githublink.Text = "github.com/bg117/SysInfo."
        '
        'AboutSysInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(431, 170)
        Me.Controls.Add(Me.githublink)
        Me.Controls.Add(Me.close)
        Me.Controls.Add(Me.Copyright)
        Me.Controls.Add(Me.assemver)
        Me.Controls.Add(Me.versionabtpc)
        Me.Controls.Add(Me.desc)
        Me.Controls.Add(Me.title)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AboutSysInfo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About SysInfo"
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
End Class
