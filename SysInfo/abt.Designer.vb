<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class abt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(abt))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.desc = New System.Windows.Forms.Label()
        Me.versionabtpc = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Copyright = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 30)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SysInfo"
        '
        'desc
        '
        Me.desc.AutoSize = True
        Me.desc.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.desc.Location = New System.Drawing.Point(13, 40)
        Me.desc.Name = "desc"
        Me.desc.Size = New System.Drawing.Size(401, 15)
        Me.desc.TabIndex = 1
        Me.desc.Text = "This is a simple application designed to display information about your PC."
        '
        'versionabtpc
        '
        Me.versionabtpc.AutoSize = True
        Me.versionabtpc.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.versionabtpc.Location = New System.Drawing.Point(13, 63)
        Me.versionabtpc.Name = "versionabtpc"
        Me.versionabtpc.Size = New System.Drawing.Size(170, 15)
        Me.versionabtpc.TabIndex = 2
        Me.versionabtpc.Text = "SysInfo version 1.0.0.0a (Alpha)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(135, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Assembly version 0.0.0.1"
        '
        'Copyright
        '
        Me.Copyright.AutoSize = True
        Me.Copyright.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Copyright.Location = New System.Drawing.Point(13, 109)
        Me.Copyright.Name = "Copyright"
        Me.Copyright.Size = New System.Drawing.Size(161, 15)
        Me.Copyright.TabIndex = 4
        Me.Copyright.Text = "Copyright © OpenCode 2020"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(344, 107)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 17
        Me.Button1.Text = "Close"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'abt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(431, 139)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Copyright)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.versionabtpc)
        Me.Controls.Add(Me.desc)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "abt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About SysInfo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents desc As Label
    Friend WithEvents versionabtpc As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Copyright As Label
    Friend WithEvents Button1 As Button
End Class
