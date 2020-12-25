Option Explicit On

Imports System.Management

Friend Class SystemInformationForm

    Public Enum PartitionType
        Boot
        Sys
    End Enum

    Sub CallGetOSVer() Handles MyBase.Load

        GetOSVersion()
        usagetimer.Start()
    End Sub

    Public Overloads Shared Function Main() As String

        Try
            Dim searcher As New ManagementObjectSearcher(
                    "root\CIMV2",
                    "SELECT * FROM Win32_PhysicalMemoryArray")
            Dim totalDimmSlots As Integer = 0
            For Each queryObj As ManagementObject In searcher.Get()

                totalDimmSlots = queryObj("MemoryDevices")
                Main = totalDimmSlots
            Next
        Catch err As ManagementException
            MessageBox.Show("An error occurred while querying for WMI data: " & err.Message)
        End Try
    End Function

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
        Try
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
            ElseIf osVer.Major = "5" And osVer.Minor = "2" Then
                ver.Text = "Windows Version: Windows NT 5.2 (Windows XP x64 Edition)"
            ElseIf osVer.Major = "5" And osVer.Major = "1" Then
                ver.Text = "Windows Version: Windows NT 5.2 (Windows XP)"
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
            ElseIf osVer.Major = "5" And osVer.Minor = "2" Or osVer.Major = "5" And osVer.Minor = "1" Then
                Xp.Visible = True
            Else
                Win7Vistalogo.Visible = True
            End If
            buildguid.Visible = False
            cpu.Visible = False
            ram.Visible = False
            displayadapter.Visible = False
            DriveType.Visible = False
            SystemRoot.Visible = False
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
            ElseIf osVer.Major = "5" And osVer.Minor = "2" Or osVer.Major = "5" And osVer.Minor = "1" Then
                XPVertool.SetToolTip(Xp, "Windows XP")
            End If
            min.AutoPopDelay = 5000
            min.SetToolTip(minimize, "Minimize")
            CloseTool.AutoPopDelay = 5000
            CloseTool.SetToolTip(CloseBut,
                "Close")
            If Not osVer.Major = "10" And osVer.Minor = "0" Then

            End If
            Me.Size = New Size(505, 205)
            Close.Location = New Point(425, 175)
            Copy.Location = New Point(425, 145)

            If osVer.Major = "10" And osVer.Minor = "0" Then
                SaveButton.Image = My.Resources.save10
                PictureBox3.Image = My.Resources.pclogo10x16
            Else
                SaveButton.Image = My.Resources.save
                PictureBox3.Image = My.Resources.pclogo16
            End If
            If osVer.Major = "10" And osVer.Minor = "0" Then
                releaseid.Visible = True
            Else
                build.Location = New Point(12, 84)
                edition.Location = New Point(12, 108)
                RegOwner.Location = New Point(12, 132)
                RegOrg.Location = New Point(12, 156)
                buildguid.Location = New Point(12, 180)
                cpu.Location = New Point(12, 204)
                ram.Location = New Point(12, 228)
                displayadapter.Location = New Point(12, 252)
                SystemRoot.Location = New Point(12, 276)
                DriveType.Location = New Point(12, 300)
            End If
            cpuname.Text = "CPU: " & ProcessorName
        Catch ex As Exception
            Dim err As String = MsgBox("An unhandled exception has occurred. You might be using an older version of Windows. Ignore and continue?", vbYesNo, "ERROR: .NET Framework unhandled exception")
            If err = vbYes Then
                Show()
            Else
                Application.Exit()
            End If

        End Try

    End Function

    Public Function GetPartitionMediaType(ByVal Part As PartitionType) As String
        Try
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
        Catch exception As Exception
            Dim er As String = MsgBox("An unhandled exception has occurred. You might be using an older version of Windows. Ignore and continue?", vbYesNo, "ERROR: .NET Framework unhandled exception")
            If er = vbYes Then
                Show()
            Else
                Application.Exit()
            End If
        End Try
    End Function

    Private Sub BasicSys_CheckedChanged(sender As Object, e As EventArgs) Handles BasicSys.CheckedChanged
        'Checkbox
        If Not BasicSys.Checked Then
            BasicSys.Text = "Show Advanced Information"
            buildguid.Visible = False
            cpu.Visible = False
            ram.Visible = False
            displayadapter.Visible = False
            DriveType.Visible = False
            SystemRoot.Visible = False
            TitleBar.Text = "Basic System Information"
            Me.Size = New Size(505, 205)
            Copy.Location = New Point(425, 145)
            Close.Location = New Point(425, 175)
        Else
            buildguid.Visible = True
            cpu.Visible = True
            ram.Visible = True
            displayadapter.Visible = True
            SystemRoot.Visible = True
            DriveType.Visible = True
            TitleBar.Text = "Advanced System Information"
            Me.Size = New Size(505, 349)
            Close.Location = New Point(425, 313)
            Copy.Location = New Point(425, 283)
        End If
        XpTool.SetToolTip(XpEnable, "Disable XP Visual Styles")
    End Sub

    Private Sub CloseBut_MouseHover(sender As Object, e As EventArgs) Handles CloseBut.MouseEnter
        Me.CloseBut.Image = Global.SysInfo.My.Resources.Resources.clsbtnhover
    End Sub

    Private Sub CloseBut_MouseLeave(sender As Object, e As EventArgs) Handles CloseBut.MouseLeave
        Me.CloseBut.Image = Global.SysInfo.My.Resources.Resources.clsbtn
    End Sub

    Private Sub CloseClick(sender As Object, e As EventArgs) Handles Close.Click
        Application.Exit()
    End Sub

    Private Sub CopyToClip(sender As Object, e As EventArgs) Handles Copy.Click
        My.Computer.Clipboard.SetText(ver.Text & vbCrLf & releaseid.Text & vbCrLf & build.Text & vbCrLf & edition.Text & vbCrLf & RegOwner.Text & vbCrLf & RegOrg.Text & vbCrLf & buildguid.Text & vbCrLf & cpu.Text & vbCrLf & ram.Text & vbCrLf & displayadapter.Text & vbCrLf & SystemRoot.Text & vbCrLf & DriveType.Text)
    End Sub

    Private Sub InfoClick(sender As Object, e As EventArgs)
        AboutSysInfo.Show()
        If AboutSysInfo.WindowState = FormWindowState.Minimized Then
            AboutSysInfo.WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub minimize_MouseHover(sender As Object, e As EventArgs) Handles minimize.MouseEnter
        Me.minimize.Image = Global.SysInfo.My.Resources.Resources.minbuttonhover
    End Sub

    Private Sub minimize_MouseLeave(sender As Object, e As EventArgs) Handles minimize.MouseLeave
        Me.minimize.Image = Global.SysInfo.My.Resources.Resources.minbutton
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
        Application.Exit()
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

    Private Sub info_Click(sender As Object, e As EventArgs) Handles info.Click
        AboutSysInfo.Show()
    End Sub

    Private Sub info_MouseEnter(sender As Object, e As EventArgs) Handles info.MouseEnter
        info.Image = My.Resources.iconhelpblue
    End Sub

    Private Sub info_MouseLeave(sender As Object, e As EventArgs) Handles info.MouseLeave
        info.Image = My.Resources.iconhelp
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles PerfClickRbn.Click
        'When clicking Perf tab
        PerfClickRbn.Font = New Font(PerfClickRbn.Font, FontStyle.Bold)
        PerfClickRbn.BackColor = Color.White
        SysClickRbn.Font = New Font(SysClickRbn.Font, FontStyle.Regular)
        SysClickRbn.BackColor = Color.FromArgb(214, 219, 233)
        BasicSys.Visible = False
        FakeCheck.Visible = False
        PerfTab.Visible = True
        Size = New Size(505, 172)
        TitleBar.Text = "Computer Performance"
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles SysClickRbn.Click
        'When clicking System tab
        SysClickRbn.Font = New Font(SysClickRbn.Font, FontStyle.Bold)
        SysClickRbn.BackColor = Color.White
        PerfClickRbn.Font = New Font(PerfClickRbn.Font, FontStyle.Regular)
        PerfClickRbn.BackColor = Color.FromArgb(214, 219, 233)
        BasicSys.Visible = True
        FakeCheck.Visible = True
        PerfTab.Visible = False
        If BasicSys.Checked = True Then
            Size = New Size(505, 349)
            TitleBar.Text = "Advanced System Information"
        Else
            Size = New Size(505, 205)
            TitleBar.Text = "Basic System Information"
        End If
    End Sub

    Private Sub Label3_MouseEnter(sender As Object, e As EventArgs) Handles PerfClickRbn.MouseEnter
        'hovering over perf tab
        PerfClickRbn.Font = New Font(PerfClickRbn.Font, FontStyle.Bold)
    End Sub

    Private Sub Label3_MouseLeave(sender As Object, e As EventArgs) Handles PerfClickRbn.MouseLeave
        'mouse leave on perf tab
        If PerfClickRbn.BackColor = Color.White Then
        Else
            PerfClickRbn.Font = New Font(PerfClickRbn.Font, FontStyle.Regular)
        End If

    End Sub

    Private Sub Label2_MouseHover(sender As Object, e As EventArgs) Handles SysClickRbn.MouseEnter
        SysClickRbn.Font = New Font(SysClickRbn.Font, FontStyle.Bold)
    End Sub

    Private Sub Label2_MouseLeave(Sender As Object, e As EventArgs) Handles SysClickRbn.MouseLeave
        If SysClickRbn.BackColor = Color.White Then
        Else
            SysClickRbn.Font = New Font(SysClickRbn.Font, FontStyle.Regular)
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles usagetimer.Tick
        Label4.Text = "(Configured) Total DIMM slots: " & Main()
        cpumeter_.Value = CPUMet.NextValue
        rammeter_.Value = Rammet.NextValue
        cpumeter.Text = "CPU Usage: " & cpumeter_.Value & "%"
        rammeter.Text = "RAM Usage: " & rammeter_.Value & "%"

    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TimerTrackbar.Scroll
        If TimerTrackbar.Value = 1 Then
            usagetimer.Interval = 167
        ElseIf TimerTrackbar.Value = 2 Then
            usagetimer.Interval = 333
        ElseIf TimerTrackbar.Value = 3 Then
            usagetimer.Interval = 500
        ElseIf TimerTrackbar.Value = 4 Then
            usagetimer.Interval = 667
        ElseIf TimerTrackbar.Value = 5 Then
            usagetimer.Interval = 833
        ElseIf TimerTrackbar.Value = 6 Then
            usagetimer.Interval = 1000
        ElseIf TimerTrackbar.Value = 7 Then
            usagetimer.Interval = 1167
        ElseIf TimerTrackbar.Value = 8 Then
            usagetimer.Interval = 1333
        ElseIf TimerTrackbar.Value = 9 Then
            usagetimer.Interval = 1500
        ElseIf TimerTrackbar.Value = 10 Then
            usagetimer.Interval = 1667
        ElseIf TimerTrackbar.Value = 11 Then
            usagetimer.Interval = 1833
        ElseIf TimerTrackbar.Value = 12 Then
            usagetimer.Interval = 2000
        End If
    End Sub

End Class