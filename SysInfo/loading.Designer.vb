<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class loading
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ProgBar = New System.Windows.Forms.ProgressBar()
        Me.Copyright = New System.Windows.Forms.Label()
        Me.logo = New System.Windows.Forms.PictureBox()
        CType(Me.logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(220, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Loading..."
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'ProgBar
        '
        Me.ProgBar.Location = New System.Drawing.Point(13, 55)
        Me.ProgBar.MarqueeAnimationSpeed = 25
        Me.ProgBar.Name = "ProgBar"
        Me.ProgBar.Size = New System.Drawing.Size(473, 23)
        Me.ProgBar.Step = 15
        Me.ProgBar.TabIndex = 1
        '
        'Copyright
        '
        Me.Copyright.AutoSize = True
        Me.Copyright.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Copyright.Location = New System.Drawing.Point(158, 85)
        Me.Copyright.Name = "Copyright"
        Me.Copyright.Size = New System.Drawing.Size(183, 15)
        Me.Copyright.TabIndex = 3
        Me.Copyright.Text = "Copyright © OpenCode Inc. 2020"
        '
        'logo
        '
        Me.logo.Image = Global.SysInfo.My.Resources.Resources.pclogo
        Me.logo.Location = New System.Drawing.Point(186, 8)
        Me.logo.Name = "logo"
        Me.logo.Size = New System.Drawing.Size(32, 32)
        Me.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.logo.TabIndex = 4
        Me.logo.TabStop = False
        '
        'loading
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(498, 106)
        Me.ControlBox = False
        Me.Controls.Add(Me.logo)
        Me.Controls.Add(Me.Copyright)
        Me.Controls.Add(Me.ProgBar)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "loading"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        CType(Me.logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents ProgBar As System.Windows.Forms.ProgressBar
    Friend WithEvents Copyright As Label
    Friend WithEvents logo As PictureBox
End Class
