Imports TwinCAT.Ads
Imports System.IO

Public Class KFA_Czujniki
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click 'zamknij okno
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private tcClient As TcAdsClient
    Private hConnect() As Integer
    Private dataStream As AdsStream
    Private binRead As BinaryReader
    Private bIsReading As Boolean = False
    Private bHasRead As Boolean = False
    Private iMaxValues As Integer = 10
    Private aPicBoxes(0 To iMaxValues) As PictureBox 'deklaracja tablicy z ikonkami dla przyciskow
    Private binReader As System.IO.BinaryReader
    Private hCount As Integer

    Private hSwitchNotify As Integer
    Private hSwitchNotify2 As Integer

    Private hSwitchWrite As Integer
    Private hSwitchWrite2 As Integer

    Public Sub KFA_Czujniki_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load


        aPicBoxes(1) = PictureBox1
        aPicBoxes(2) = PictureBox2
        aPicBoxes(3) = PictureBox3
        aPicBoxes(4) = PictureBox4
        aPicBoxes(5) = PictureBox5
        aPicBoxes(6) = PictureBox6
        aPicBoxes(7) = PictureBox7
        aPicBoxes(8) = PictureBox8
        aPicBoxes(9) = PictureBox9
        aPicBoxes(10) = PictureBox10

        If bIsReading Then
            Try
                tcClient.Dispose()
            Catch err As Exception
                MessageBox.Show(err.Message)
            End Try

            'zaladuj ikonki do przyciskow
            PictureBox1.Image = My.Resources.Image3
            PictureBox2.Image = My.Resources.Image3
            PictureBox3.Image = My.Resources.Image3
            PictureBox4.Image = My.Resources.Image3
            PictureBox5.Image = My.Resources.Image3
            PictureBox6.Image = My.Resources.Image3
            PictureBox7.Image = My.Resources.Image3
            PictureBox8.Image = My.Resources.Image3
            PictureBox9.Image = My.Resources.Image3
            PictureBox10.Image = My.Resources.Image3

            Button3.Text = "Online"
            Button3.BackColor = Color.LightGreen
            bIsReading = False

        Else
            Dim dataStream As New AdsStream(31) 'deklaracja polaczenia ADS
            binRead = New BinaryReader(dataStream, System.Text.Encoding.ASCII) 'czytnik binarny
            tcClient = New TwinCAT.Ads.TcAdsClient() 'komunikacja ADS
            tcClient.Connect(801)

            ReDim hConnect(10)

            Try
                hConnect(1) = tcClient.AddDeviceNotification(checkVariable(MaskedTextBox1.Text.ToString, MaskedTextBox1), dataStream, 0, 1, AdsTransMode.OnChange, 100, 0, Nothing)
                hConnect(2) = tcClient.AddDeviceNotification(checkVariable(MaskedTextBox2.Text.ToString, MaskedTextBox2), dataStream, 1, 1, AdsTransMode.OnChange, 100, 0, Nothing)
                hConnect(3) = tcClient.AddDeviceNotification(checkVariable(MaskedTextBox3.Text.ToString, MaskedTextBox3), dataStream, 2, 1, AdsTransMode.OnChange, 100, 0, Nothing)
                hConnect(4) = tcClient.AddDeviceNotification(checkVariable(MaskedTextBox4.Text.ToString, MaskedTextBox4), dataStream, 3, 1, AdsTransMode.OnChange, 100, 0, Nothing)
                hConnect(5) = tcClient.AddDeviceNotification(checkVariable(MaskedTextBox5.Text.ToString, MaskedTextBox5), dataStream, 4, 1, AdsTransMode.OnChange, 100, 0, Nothing)
                hConnect(6) = tcClient.AddDeviceNotification(checkVariable(MaskedTextBox6.Text.ToString, MaskedTextBox6), dataStream, 5, 1, AdsTransMode.OnChange, 100, 0, Nothing)
                hConnect(7) = tcClient.AddDeviceNotification(checkVariable(MaskedTextBox7.Text.ToString, MaskedTextBox7), dataStream, 6, 1, AdsTransMode.OnChange, 100, 0, Nothing)
                hConnect(8) = tcClient.AddDeviceNotification(checkVariable(MaskedTextBox8.Text.ToString, MaskedTextBox8), dataStream, 7, 1, AdsTransMode.OnChange, 100, 0, Nothing)
                hConnect(9) = tcClient.AddDeviceNotification(checkVariable(MaskedTextBox9.Text.ToString, MaskedTextBox9), dataStream, 8, 1, AdsTransMode.OnChange, 100, 0, Nothing)
                hConnect(10) = tcClient.AddDeviceNotification(checkVariable(MaskedTextBox10.Text.ToString, MaskedTextBox10), dataStream, 9, 1, AdsTransMode.OnChange, 100, 0, Nothing)

                hSwitchNotify = tcClient.AddDeviceNotification(".Zawor_OUT", dataStream, 10, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                hSwitchWrite = tcClient.CreateVariableHandle(".Zawor_OUT")

                hSwitchNotify2 = tcClient.AddDeviceNotification(".RaportCzujnikiReset", dataStream, 11, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                hSwitchWrite2 = tcClient.CreateVariableHandle(".RaportCzujnikiReset")

                hCount = tcClient.AddDeviceNotification(".TastungWykres_INT", dataStream, 12, 4, AdsTransMode.OnChange, 100, 0, DBNull.Value)

                AddHandler tcClient.AdsNotification, AddressOf OnNotification

                Button3.Text = "Offline"
                Button3.BackColor = Color.Red
                bHasRead = True
                bIsReading = True

            Catch err As Exception
                MessageBox.Show(err.Message)
            End Try
        End If
    End Sub
    Public Sub OnNotification(ByVal sender As Object, ByVal e As AdsNotificationEventArgs)
        Try
            e.DataStream.Position = e.Offset
            If (e.NotificationHandle = hCount) Then
                lblCount.Text = binRead.ReadInt32().ToString()
                CircularProgressBar.Value = lblCount.Text
                CircularProgressBar.Refresh()
            End If

            Dim strValue As String = ""
            Dim i As Integer
            For i = 1 To iMaxValues
                If (e.NotificationHandle = hConnect(i)) Then
                    If binRead.ReadBoolean() Then
                        aPicBoxes(i).Image = My.Resources.Image2
                    Else
                        aPicBoxes(i).Image = My.Resources.Image1
                    End If
                End If
            Next i

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
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
    Private Sub Button4_OnClick(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            tcClient.WriteAny(hSwitchWrite, True)
            Button4.BackColor = Color.Green
            Button5.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub Button5_OffClick(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            tcClient.WriteAny(hSwitchWrite, False)
            Button5.BackColor = Color.Red
            Button4.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub Button7_OnClick(sender As Object, e As EventArgs) Handles Button7.MouseDown
        Try
            tcClient.WriteAny(hSwitchWrite2, True)
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub Button7_OffClick(sender As Object, e As EventArgs) Handles Button7.MouseUp
        Try
            tcClient.WriteAny(hSwitchWrite2, False)
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Krokowe_M31.Show()
        Me.Close()
    End Sub
End Class