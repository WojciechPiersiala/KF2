Public Class Novimat_Menu

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Agregaty_Click(sender As Object, e As EventArgs) Handles Agregaty.Click
        Agregaty_Menu.Show()
    End Sub


    Private Sub Novimat_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Novimat.Show()
    End Sub

End Class