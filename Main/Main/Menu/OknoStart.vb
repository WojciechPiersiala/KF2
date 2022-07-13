
Public Class OknoStart
    'Okno ladowania programu
    Dim second As Integer
    Dim i As Integer


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Interval = 200
        Timer1.Start() 'Timer starts functioning

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        second = second + 1
        i = i + 0.45
        CircularProgressBar1.Value = i
        CircularProgressBar1.Update()
        If second >= 4 Then
            Timer1.Stop() 'Timer stops functioning
            Main.Show()   'Po zaladowaniu pokaz menu
        End If
    End Sub
End Class