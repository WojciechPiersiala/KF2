Imports System.IO
Imports TwinCAT.Ads
Imports System.Deployment.Application



Public Class Main

    Private tcClient As TwinCAT.Ads.TcAdsClient
    Private dataStream As TwinCAT.Ads.AdsStream
    Private binReader As System.IO.BinaryReader

    Private bHasRead As Boolean = False
    Private bIsReading As Boolean = False

    Private hSwitchNotify As Integer
    Private hSwitchWrite As Integer

    Private version As String

    ' Private Sub frmMachine_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    Private Sub ButStart_Click(sender As Object, e As EventArgs) Handles ButStart.Click

        If bIsReading Then
            'Auslesen beenden
            Try
                tcClient.Dispose()
            Catch err As Exception
                MessageBox.Show(err.Message)
            End Try

            ButStart.Text = "START"
            ButStart.BackColor = Color.LightGreen
            bIsReading = False
        Else
            Try
                dataStream = New AdsStream(31)
                binReader = New BinaryReader(dataStream)
                tcClient = New TwinCAT.Ads.TcAdsClient()
                tcClient.Connect(MTextBoxAmsNetId.Text.ToString, MTextBoxPort.Text.ToString)

            Catch ex As Exception
                MessageBox.Show("Fehler beim Laden")
            End Try
        End If
    End Sub

    Private Function checkVariable(sString As String, mtb As MaskedTextBox) As String
        Dim stelle As Integer
        stelle = InStr(sString, ".")
        Debug.Print("Stelle: " & stelle)
        If stelle <> 1 Then
            sString = "." & sString
            mtb.Text = sString
        End If
        checkVariable = sString
    End Function

    Private Sub Main_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bHasRead Then
            Try
                tcClient.Dispose()
            Catch err As Exception
                MessageBox.Show(err.Message)
            End Try
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Application.Exit()
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '  version = Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString()
        '  Label1.Text = version

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        KFA_Main.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dane_Edycja.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Przewody_10749697.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Przewody_10749699.Show()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Przewody_10749698.Show()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Novimat.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        tisch.Show()
    End Sub
End Class