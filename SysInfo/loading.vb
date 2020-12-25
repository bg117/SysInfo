Imports SysInfo.My.Resources

Public Class loading
    Public osVer As Version = Environment.OSVersion.Version

    Sub ProgressBarProgress(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick
        ProgBar.Increment(10)
        If ProgBar.Value = 100 Then
            SystemInformationForm.Show()
            Hide()
        End If

    End Sub

    Private Sub loading_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim osVer As Version = Environment.OSVersion.Version
        If osVer.Major = "10" And osVer.Minor = "0" Then
            logo.Image = pclogo10
        Else
            logo.Image = pclogo
        End If
    End Sub

End Class