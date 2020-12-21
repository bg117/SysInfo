Public Class AboutSysInfo
    Public mouseLoc As Point

    Sub tooltip(sender As Object, e As EventArgs) Handles MyBase.Load
        Min.SetToolTip(minimize, "Minimize")
        Dim tooltipCls As New ToolTip
        tooltipCls.AutomaticDelay = 100
        tooltipCls.SetToolTip(CloseBut, "Close")
        If Environment.OSVersion.Version.Major = "10" And Environment.OSVersion.Version.Minor = "0" Then
            PictureBox3.Image = My.Resources.pclogo10x16
        Else
            PictureBox3.Image = My.Resources.pclogo16
        End If
    End Sub

    Private Sub CloseBut_MouseHover(sender As Object, e As EventArgs) Handles CloseBut.MouseHover
        Me.CloseBut.Image = Global.SysInfo.My.Resources.Resources.close___Copy
    End Sub

    Private Sub CloseBut_MouseLeave(sender As Object, e As EventArgs) Handles CloseBut.MouseLeave
        Me.CloseBut.Image = Global.SysInfo.My.Resources.Resources.close
    End Sub

    Private Sub CloseButtonControl_Click(sender As Object, e As EventArgs)
        MyBase.Close()
    End Sub

    Private Sub CloseClick(sender As Object, e As EventArgs) Handles close.Click
        MyBase.Close()
    End Sub

    Private Sub Form1_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        ControlPaint.DrawBorder(e.Graphics, Me.ClientRectangle, Color.FromArgb(0, 120, 215), ButtonBorderStyle.Solid)
    End Sub

    Private Sub githublink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles githublink.LinkClicked
        Dim website As String = "https://github.com/bg117/SysInfo"
        Process.Start(website)
    End Sub

    Private Sub minimize_Click(sender As Object, e As EventArgs) Handles minimize.Click
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub minimize_MouseHover(sender As Object, e As EventArgs) Handles minimize.MouseHover
        Me.minimize.Image = Global.SysInfo.My.Resources.Resources.minbutton
    End Sub

    Private Sub minimize_MouseLeave(sender As Object, e As EventArgs) Handles minimize.MouseLeave
        Me.minimize.Image = Global.SysInfo.My.Resources.Resources.minbutton___Copy
    End Sub

    Private Sub Panel7_MouseDown(sender As Object, e As MouseEventArgs) Handles TitleBarAbt.MouseDown
        mouseLoc = New Point(-e.X, -e.Y)
    End Sub

    Private Sub Panel7_MouseMove(sender As Object, e As MouseEventArgs) Handles TitleBarAbt.MouseMove
        If e.Button = MouseButtons.Left Then
            Dim mousePos As Point = MyBase.MousePosition
            mousePos.Offset(mouseLoc.X, mouseLoc.Y)
            Location = mousePos
        End If
    End Sub
    Private Sub CloseBut_Click(sender As Object, e As EventArgs) Handles CloseBut.Click
        MyBase.Close()
    End Sub
End Class