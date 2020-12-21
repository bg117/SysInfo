Option Explicit On

Imports System.Management

Friend Class SystemInformationForm

    Public Enum PartitionType
        Boot
        Sys
    End Enum

    Sub CallGetOSVer() Handles MyBase.Load
        GetOSVersion()
    End Sub

    Public Function GetDisplayAdapter() As String
        On Error GoTo AtErrorDetect
        Dim objWMIService As Object
        Dim colDevices As Object
        Dim objDevice As Object
        objWMIService = GetObject("winmgmts:\\.\root\cimv2")
        colDevices = objWMIService.ExecQuery("Select Name From Win32_VideoController")
        For Each objDevice In colDevices
            GetDisplayAdapter = objDevice.Name
        Next objDevice
AtErrorDetect:
        colDevices = Nothing
        objWMIService = Nothing
    End Function

    Public AvailRam As Decimal = Math.Round(My.Computer.Info.TotalPhysicalMemory / 1073741824, 2, MidpointRounding.AwayFromZero)
    Public mouseLoc As Point
    Friend osVer As Version = Environment.OSVersion.Version

    Public Function GetOSVersion() As String
        Dim relID, CurMajorVerNum, CurMinorVerNum, CurBuild, UpdBuildRev, ProdName, RegOwnerStr, RegOrgStr, BuildGUIDStr, ProcessorName, SysRoot As String
        Dim regKey As Microsoft.Win32.RegistryKey
        Dim ProcessorKey As Microsoft.Win32.RegistryKey

        ProcessorKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("HARDWARE\DESCRIPTION\System\CentralProcessor\0")
        ProcessorName = ProcessorKey.GetValue("ProcessorNameString")
        regKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows NT\CurrentVersion")
        relID = regKey.GetValue("ReleaseID")
        CurMajorVerNum = regKey.GetValue("CurrentMajorVersionNumber")
        CurMinorVerNum = regKey.GetValue("CurrentMinorVersionNumber")
        CurBuild = regKey.GetValue("CurrentBuild")
        UpdBuildRev = regKey.GetValue("UBR")
        ProdName = regKey.GetValue("ProductName")
        RegOwnerStr = regKey.GetValue("RegisteredOwner")
        RegOrgStr = regKey.GetValue("RegisteredOrganization")
        BuildGUIDStr = regKey.GetValue("BuildGUID")
        SysRoot = regKey.GetValue("SystemRoot")
        If osVer.Major = "10" And osVer.Minor = "0" Then
            ver.Text = "Windows Version: Windows NT 10.0 (Windows 10)"
        ElseIf osVer.Major = "6" And osVer.Minor = "3" Then
            ver.Text = "Windows Version: Windows NT 6.3 (Windows 8.1)"
        ElseIf osVer.Major = "6" And osVer.Minor = "2" Then
            ver.Text = "Windows Version: Windows NT 6.2 (Windows 8)"
        ElseIf osVer.Major = "6" And osVer.Minor = "1" Then
            ver.Text = "Windows Version: Windows NT 6.1 (Windows 7)"
        ElseIf osVer.Major = "6" And osVer.Minor = "0" Then
            ver.Text = "Windows Version: Windows NT 6.0 (Vista)"
        End If
        releaseid.Text = "Release ID: " & relID
        If osVer.Major = "10" And osVer.Minor = "0" Then
            build.Text = "Build: " & CurBuild & " (" & UpdBuildRev & ")"
        Else
            build.Text = "Build: " & CurBuild
        End If
        edition.Text = "Edition: " & ProdName
        RegOwner.Text = "Registered Owner: " & RegOwnerStr
        RegOrg.Text = "Registered Organization: " & RegOrgStr
        buildguid.Text = "Build GUID: " & BuildGUIDStr
        ram.Text = "Usable RAM: " & AvailRam & " GB"
        cpu.Text = "CPU: " & ProcessorName
        displayadapter.Text = "Display Adapter: " & GetDisplayAdapter()
        SystemRoot.Text = "Windows is installed in " & SysRoot
        DriveType.Text = "Drive type: " & GetPartitionMediaType(PartitionType.Boot)
        If osVer.Major = 10 And osVer.Minor = 0 Or osVer.Major = "6" And osVer.Minor = "3" Or osVer.Major = "6" And osVer.Minor = "2" Then
            Win810logo.Visible = True
        Else
            Win7Vistalogo.Visible = True
        End If
        buildguid.Visible = False
        cpu.Visible = False
        ram.Visible = False
        displayadapter.Visible = False
        DriveType.Visible = False
        SystemRoot.Visible = False
        Me.Size = New Size(505, 206)
        Close.Location = New Point(425, 175)
        Copy.Location = New Point(425, 145)
        Export.SetToolTip(SaveButton, "Export system information")
        AboutSysinfoTool.SetToolTip(info, "About SysInfo")
        If osVer.Major = "10" And osVer.Minor = "0" Then
            ten.SetToolTip(Win810logo, "Windows 10")
        ElseIf osVer.Major = "6" And osVer.Minor = "3" Then
            eightpoint1.SetToolTip(Win810logo, "Windows 8.1")
        ElseIf osVer.Major = "6" And osVer.Minor = "2" Then
            eight.SetToolTip(Win810logo, "Windows 8")
        ElseIf osVer.Major = "6" And osVer.Minor = "1" Then
            seven.SetToolTip(Win7Vistalogo, "Windows 7")
        ElseIf osVer.Major = "6" And osVer.Minor = "0" Then
            Vista.SetToolTip(Win7Vistalogo, "Windows Vista")
        End If
        min.AutoPopDelay = 5000
        min.SetToolTip(minimize, "Minimize")
        CloseTool.AutoPopDelay = 5000
        CloseTool.SetToolTip(CloseBut,
            "Close")
        If osVer.Major = "10" And osVer.Minor = "0" Then
            info.Image = My.Resources.info2
            SaveButton.Image = My.Resources.save2
            PictureBox3.Image = My.Resources.pclogo10x16
        Else
            info.Image = My.Resources.info
            SaveButton.Image = My.Resources.save
            PictureBox3.Image = My.Resources.pclogo16
        End If
    End Function

    Public Function GetPartitionMediaType(ByVal Part As PartitionType) As String
        Dim strScope As String = "\\.\root\microsoft\windows\storage"
        Dim PartType As String = ""
        Dim DiskID As String = ""
        Dim MediaType As String = ""
        Select Case Part
            Case PartitionType.Boot
                PartType = "IsBoot"
            Case PartitionType.Sys
                PartType = "IsSystem"
        End Select
        Dim searcher = New ManagementObjectSearcher(strScope, "SELECT * FROM MSFT_Partition WHERE " & PartType & "=TRUE")
        For Each queryObj As ManagementObject In searcher.Get()
            DiskID = queryObj("DiskNumber")
        Next
        searcher = New ManagementObjectSearcher(strScope, "SELECT * FROM MSFT_PhysicalDisk WHERE DeviceID = " & DiskID)
        For Each queryObj As ManagementObject In searcher.Get()
            Select Case queryObj("MediaType")
                Case 1
                    MediaType = "Unspecified"
                Case 3
                    MediaType = "HDD"
                Case 4
                    MediaType = "SSD"
                Case 5
                    MediaType = "SCM"
                Case Else
                    MediaType = "Unspecified"
            End Select
        Next
        GetPartitionMediaType = MediaType
    End Function

    Private Sub BasicSys_CheckedChanged(sender As Object, e As EventArgs) Handles BasicSys.CheckedChanged
        If BasicSys.Checked Then
            Me.Size = New Size(505, 206)
            Close.Location = New Point(425, 175)
            Copy.Location = New Point(425, 145)
            buildguid.Visible = False
            cpu.Visible = False
            ram.Visible = False
            displayadapter.Visible = False
            DriveType.Visible = False
            SystemRoot.Visible = False
            TitleBar.Text = "Basic System Information"
            Me.Invalidate()
        Else
            Me.Size = New Size(505, 348)
            Close.Location = New Point(425, 313)
            Copy.Location = New Point(425, 283)
            buildguid.Visible = True
            cpu.Visible = True
            ram.Visible = True
            displayadapter.Visible = True
            SystemRoot.Visible = True
            DriveType.Visible = True
            TitleBar.Text = "Advanced System Information"
            Me.Invalidate()
        End If
        XpTool.SetToolTip(XpEnable, "Disable XP Visual Styles")
    End Sub

    Private Sub CloseBut_MouseHover(sender As Object, e As EventArgs) Handles CloseBut.MouseHover
        Me.CloseBut.Image = Global.SysInfo.My.Resources.Resources.close___Copy
    End Sub

    Private Sub CloseBut_MouseLeave(sender As Object, e As EventArgs) Handles CloseBut.MouseLeave
        Me.CloseBut.Image = Global.SysInfo.My.Resources.Resources.close
    End Sub

    Private Sub CloseClick(sender As Object, e As EventArgs) Handles Close.Click
        loading.Close()
        MyBase.Close()
    End Sub

    Private Sub CopyToClip(sender As Object, e As EventArgs) Handles Copy.Click
        My.Computer.Clipboard.SetText(ver.Text & vbCrLf & releaseid.Text & vbCrLf & build.Text & vbCrLf & edition.Text & vbCrLf & RegOwner.Text & vbCrLf & RegOrg.Text & vbCrLf & buildguid.Text & vbCrLf & cpu.Text & vbCrLf & ram.Text & vbCrLf & displayadapter.Text & vbCrLf & SystemRoot.Text & vbCrLf & DriveType.Text)
    End Sub

    Private Sub Form1_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        ControlPaint.DrawBorder(e.Graphics, Me.ClientRectangle, Color.FromArgb(0, 120, 215), ButtonBorderStyle.Solid)
    End Sub

    Private Sub InfoClick(sender As Object, e As EventArgs) Handles info.Click
        AboutSysInfo.Show()
        If AboutSysInfo.WindowState = FormWindowState.Minimized Then
            AboutSysInfo.WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub minimize_MouseHover(sender As Object, e As EventArgs) Handles minimize.MouseHover
        Me.minimize.Image = Global.SysInfo.My.Resources.Resources.minbutton
    End Sub

    Private Sub minimize_MouseLeave(sender As Object, e As EventArgs) Handles minimize.MouseLeave
        Me.minimize.Image = Global.SysInfo.My.Resources.Resources.minbutton___Copy
    End Sub

    Private Sub Panel7_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel7.MouseDown
        mouseLoc = New Point(-e.X, -e.Y)
    End Sub

    Private Sub Panel7_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel7.MouseMove
        If e.Button = MouseButtons.Left Then
            Dim mousePos As Point = MyBase.MousePosition
            mousePos.Offset(mouseLoc.X, mouseLoc.Y)
            Location = mousePos
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles CloseBut.Click
        loading.Close()
        MyBase.Close()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles minimize.Click
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub SaveToFile(sender As Object, e As EventArgs) Handles SaveButton.Click
        SaveInfoDialog.Title = "Export system information"
        SaveInfoDialog.DefaultExt = "snfo"
        SaveInfoDialog.Filter = "Exported system information file |*.snfo"
        If SaveInfoDialog.ShowDialog = DialogResult.OK _
            Then
            My.Computer.FileSystem.WriteAllText _
                (SaveInfoDialog.FileName, ver.Text & vbCrLf & releaseid.Text & vbCrLf & build.Text & vbCrLf & edition.Text & vbCrLf & RegOwner.Text & vbCrLf & RegOrg.Text & vbCrLf & buildguid.Text & vbCrLf & cpu.Text & vbCrLf & ram.Text & vbCrLf & displayadapter.Text & vbCrLf & SystemRoot.Text & vbCrLf & DriveType.Text, True)
        End If

    End Sub

    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs) Handles XpEnable.Click
        Application.VisualStyleState = VisualStyles.VisualStyleState.NoneEnabled
        Me.Invalidate(True)
        DisableXPStyle.Enabled = True
        DisableXPStyle.Visible = True
        XpEnable.Visible = False
        XpEnable.Enabled = False
        XpTool.SetToolTip(DisableXPStyle, "Enable XP Visual Styles")
    End Sub

    Private Sub XpEnable_Click(sender As Object, e As EventArgs) Handles DisableXPStyle.Click
        Application.VisualStyleState = VisualStyles.VisualStyleState.ClientAndNonClientAreasEnabled
        Me.Invalidate(True)
        DisableXPStyle.Enabled = False
        DisableXPStyle.Visible = False
        XpEnable.Visible = True
        XpEnable.Enabled = True
        XpTool.SetToolTip(XpEnable, "Disable XP Visual Styles")
    End Sub

End Class