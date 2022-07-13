''' <summary>
''' Wybierz kategorie, zalezne od menu glownego
''' </summary>
Public Class Agregaty_Menu

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close() 'wylacz
    End Sub
    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Minimized ' minimalizacja
    End Sub

    Private Sub KappenPneumatycznyMaly_Click(sender As Object, e As EventArgs) Handles Kappen_Pneumatyczny_Maly.Click
        KappenPneumatycznyMaly.Show()
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Frez_08055.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Frez_08379.Show()
    End Sub

End Class