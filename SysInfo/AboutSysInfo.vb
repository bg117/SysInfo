Public Class AboutSysInfo
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim param As CreateParams = MyBase.CreateParams
            param.ClassStyle = param.ClassStyle Or &H200
            Return param
        End Get
    End Property
    Private Sub CloseClick(sender As Object, e As EventArgs) Handles close.Click
        MyBase.Close()
    End Sub

    Private Sub githublink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles githublink.LinkClicked
        Dim website As String = "https://github.com/bg117/SysInfo"
        Process.Start(website)
    End Sub
End Class