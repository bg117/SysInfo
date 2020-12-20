Public Class loading
    Sub ProgressBarProgress(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim Min As Integer = 1, Max As Integer = 18, RandNum As Integer
        Dim Generator As System.Random = New System.Random()
        RandNum = Generator.Next(Min, Max)
        ProgBar.Increment(RandNum)
        If ProgBar.Value = "100" Then
            Hide()
            SystemInformationForm.Show()
        End If
    End Sub
End Class