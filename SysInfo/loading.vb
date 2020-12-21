Public Class loading
    Friend osVer As Version = Environment.OSVersion.Version
    Sub ProgressBarProgress(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim Min As Integer = 1, Max As Integer = 18, RandNum As Integer
        Dim Generator As System.Random = New System.Random()
        RandNum = Generator.Next(Min, Max)
        ProgBar.Increment(RandNum)
        If ProgBar.Value = "100" Then
            Hide()
            SystemInformationForm.Show()
        End If
        If osVer.Major = "10" And osVer.Minor = "0" Then
            logo.Image = My.Resources.pclogo10
        Else
            logo.Image = My.Resources.pclogo
        End If
    End Sub

End Class