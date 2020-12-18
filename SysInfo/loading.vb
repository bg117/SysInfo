Public Class loading


    Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        ProgressBar1.Increment(5)
        If ProgressBar1.Value = "100" Then
            Hide()
            about.Show()
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) 

    End Sub
End Class