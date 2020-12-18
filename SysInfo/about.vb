Class about



    Public Function GetDisplayAdapter() As String
        On Error GoTo Error_Handler
        Dim objWMIService As Object
        Dim colDevices As Object
        Dim objDevice As Object
        objWMIService = GetObject("winmgmts:\\.\root\cimv2")
        colDevices = objWMIService.ExecQuery("Select Name From Win32_VideoController")
        For Each objDevice In colDevices
            GetDisplayAdapter = objDevice.Name
        Next objDevice
Error_Handler:
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
        Dim strBuild0, strBuild1, strBuild2, strBuild3, strBuild4, strProdName, strRegOwner, strRegOrg, strGUID, ProcessorName As String
        Dim regKey As Microsoft.Win32.RegistryKey
        Dim ProcessorKey As Microsoft.Win32.RegistryKey
        Dim ramAmount As ULong = My.Computer.Info.TotalPhysicalMemory
        Dim ramAmount1 As ULong = My.Computer.Info.AvailablePhysicalMemory
        ProcessorKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("HARDWARE\DESCRIPTION\System\CentralProcessor\0")
        ProcessorName = ProcessorKey.GetValue("ProcessorNameString")
        regKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows NT\CurrentVersion")
        strBuild0 = regKey.GetValue("ReleaseId")
        strBuild1 = regKey.GetValue("CurrentMajorVersionNumber")
        strBuild2 = regKey.GetValue("CurrentMinorVersionNumber")
        strBuild3 = regKey.GetValue("CurrentBuild")
        strBuild4 = regKey.GetValue("UBR")
        strProdName = regKey.GetValue("ProductName")
        strRegOwner = regKey.GetValue("RegisteredOwner")
        strRegOrg = regKey.GetValue("RegisteredOrganization")
        strGUID = regKey.GetValue("BuildGUID")
        Dim osVer As Version = Environment.OSVersion.Version
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
        build.Text = "Release ID: " & strBuild0
        If osVer.Major = "10" And osVer.Minor = "0" Then
            Label2.Text = "Build: " & strBuild3 & " (" & strBuild4 & ")"
        Else
            Label2.Text = "Build: " & strBuild3
        End If
        Label1.Text = "Edition: " & strProdName
        Label3.Text = "Registered Owner: " & strRegOwner
        Label4.Text = "Registered Organization: " & strRegOrg
        Label5.Text = "Build GUID: " & strGUID
        Label6.Text = "CPU: " & ProcessorName
        Label7.Text = "RAM: " & ramAmount & " MB (" & ramAmount - ramAmount1 & " MB in use)"
        Label8.Text = "Display Adapter: " & GetDisplayAdapter()

        If osVer.Major = 10 And osVer.Minor = 0 Then
            PictureBox1.Visible = True
        ElseIf osVer.Major = 6 And osVer.Minor = 1 Then
            PictureBox2.Visible = True
        ElseIf osVer.Major = 6 And osVer.Minor = 0 Then
            PictureBox2.Visible = True
        Else
            PictureBox1.Visible = True
        End If
        Label5.Visible = False
        Label6.Visible = False
        Label7.Visible = False
        Label8.Visible = False
        Size = New Size(521, 215)
        Button1.Location = New Point(418, 147)
        Button2.Location = New Point(418, 118)
        Label10.Location = New Point(275, 122)


    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        loading.Close()
        Close()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub



    Public Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles Basic.CheckedChanged
        If Basic.CheckState.Checked Then
            Label10.Location = New Point(361, 195)
            Button2.Location = New Point(418, 218)
            Label5.Visible = True
            Label6.Visible = True
            Label7.Visible = True
            Label8.Visible = True
            Size = New Size(521, 315)
            Button1.Location = New Point(418, 247)
            Basic.Visible = False
            Label9.Visible = True
            Button2.Visible = True
            Me.Text = "Advanced System Information"
        End If

    End Sub

    Private Sub PictureBox3_Click_1(sender As Object, e As EventArgs) Handles PictureBox3.Click
        abt.Show()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        My.Computer.Clipboard.SetText(ver.Text & vbCrLf & build.Text & vbCrLf & Label2.Text & vbCrLf & Label1.Text & vbCrLf & Label3.Text & vbCrLf & Label4.Text & vbCrLf & Label5.Text & vbCrLf & Label6.Text & vbCrLf & Label7.Text & vbCrLf & Label8.Text)
        Label10.Visible = True
        Timer2.Interval = 2000
        Timer2.Start()
    End Sub
    Private Sub Timer2_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer2.Tick
        Label10.Visible = False
        Timer2.Stop()
    End Sub
End Class