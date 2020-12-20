Imports System.Management
Imports My.Computer.FileSystem
Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic.ApplicationServices

Friend Class SystemInformationForm
    Public Enum Partitiontype
        boot
        system
    End Enum
    Public Function GetPartitionMediaType(ByVal Part As Partitiontype) As String
        Dim strScope As String = "\\.\root\microsoft\windows\storage"
        Dim PartType As String = ""
        Dim DiskID As String = ""
        Dim MediaType As String = ""
        Select Case Part
            Case Partitiontype.boot
                PartType = "IsBoot"
            Case Partitiontype.system
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
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim param As CreateParams = MyBase.CreateParams
            param.ClassStyle = param.ClassStyle Or &H200
            Return param
        End Get
    End Property
    Public Function GetOSVersion() As String Handles MyBase.Load
        Dim relID, CurMajorVerNum, CurMinorVerNum, CurBuild, UpdBuildRev, ProdName, RegOwnerStr, RegOrgStr, BuildGUIDStr, ProcessorName, SysRoot As String
        Dim regKey As Microsoft.Win32.RegistryKey
        Dim ProcessorKey As Microsoft.Win32.RegistryKey
        Dim ramAmount As Decimal = My.Computer.Info.TotalPhysicalMemory / 1073741824
        Dim ramAmount1 As Decimal = My.Computer.Info.AvailablePhysicalMemory / 1073741824
        Dim AvailRam As Decimal = Math.Round(ramAmount, 2, MidpointRounding.AwayFromZero)
        Dim RamInUse As Decimal = Math.Round(ramAmount1, 2, MidpointRounding.AwayFromZero)
        Dim osVer As Version = Environment.OSVersion.Version
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
        cpu.Text = "CPU: " & ProcessorName
        ram.Text = "Available RAM: " & AvailRam & " GB (" & AvailRam - RamInUse & " GB in use)"
        displayadapter.Text = "Display Adapter: " & GetDisplayAdapter()
        SystemRoot.Text = "Windows is installed in " & SysRoot
        DriveType.Text = "Drive type: " & GetPartitionMediaType(Partitiontype.boot)
        If osVer.Major = 10 And osVer.Minor = 0 Then
            Win810logo.Visible = True
        ElseIf osVer.Major = 6 And osVer.Minor = 1 Then
            Win7Vistalogo.Visible = True
        ElseIf osVer.Major = 6 And osVer.Minor = 0 Then
            Win7Vistalogo.Visible = True
        Else
            Win810logo.Visible = True
        End If
        buildguid.Visible = False
        cpu.Visible = False
        ram.Visible = False
        displayadapter.Visible = False
        DriveType.Visible = False
        SystemRoot.Visible = False
        Size = New Size(521, 215)
        Close.Location = New Point(418, 147)
        Copy.Location = New Point(335, 147)
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
    End Function
    Private Sub CloseClick(sender As Object, e As EventArgs) Handles Close.Click
        loading.Close()
        MyBase.Close()
    End Sub
    Private Sub InfoClick(sender As Object, e As EventArgs) Handles info.Click
        AboutSysInfo.Show()
    End Sub
    Private Sub CopyToClip(sender As Object, e As EventArgs) Handles Copy.Click
        My.Computer.Clipboard.SetText(ver.Text & vbCrLf & releaseid.Text & vbCrLf & build.Text & vbCrLf & edition.Text & vbCrLf & RegOwner.Text & vbCrLf & RegOrg.Text & vbCrLf & buildguid.Text & vbCrLf & cpu.Text & vbCrLf & ram.Text & vbCrLf & displayadapter.Text & vbCrLf & SystemRoot.Text & vbCrLf & DriveType.Text)
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
    Private Sub BasicSys_CheckedChanged(sender As Object, e As EventArgs) Handles BasicSys.CheckedChanged
        If BasicSys.Checked Then
            buildguid.Visible = False
            cpu.Visible = False
            ram.Visible = False
            displayadapter.Visible = False
            DriveType.Visible = False
            SystemRoot.Visible = False
            Size = New Size(521, 215)
            Close.Location = New Point(418, 147)
            Copy.Location = New Point(335, 147)
            Me.Text = "Basic System Information"
        Else
            Copy.Location = New Point(418, 259)
            Close.Location = New Point(418, 289)
            Size = New Size(521, 360)
            buildguid.Visible = True
            cpu.Visible = True
            ram.Visible = True
            displayadapter.Visible = True
            SystemRoot.Visible = True
            DriveType.Visible = True
            Me.Text = "Advanced System Information"
        End If
    End Sub
End Class