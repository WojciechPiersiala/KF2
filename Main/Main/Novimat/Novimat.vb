Imports TwinCAT.Ads
Imports System.IO
Public Class Novimat
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private tcClient As TcAdsClient
    Private hConnect() As Integer
    Private dataStream As AdsStream
    Private binRead As BinaryReader
    Private bIsReading As Boolean = False
    Private bHasRead As Boolean = False
    Private iMaxValues As Integer = 22
    Private aPicBoxes(0 To iMaxValues) As PictureBox
    Private binReader As System.IO.BinaryReader

    Public Sub Novimat_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        aPicBoxes(11) = PictureBox11
        aPicBoxes(12) = PictureBox12
        aPicBoxes(13) = PictureBox13
        aPicBoxes(14) = PictureBox14
        aPicBoxes(15) = PictureBox15
        aPicBoxes(16) = PictureBox16
        aPicBoxes(17) = PictureBox17
        aPicBoxes(18) = PictureBox18
        aPicBoxes(19) = PictureBox19
        aPicBoxes(20) = PictureBox20
        aPicBoxes(21) = PictureBox24
        aPicBoxes(22) = PictureBox25
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If bIsReading Then
            Try
                tcClient.Dispose()
            Catch err As Exception
                MessageBox.Show(err.Message)
            End Try
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
            PictureBox11.Image = My.Resources.Image3
            PictureBox12.Image = My.Resources.Image3
            PictureBox13.Image = My.Resources.Image3
            PictureBox14.Image = My.Resources.Image3
            PictureBox15.Image = My.Resources.Image3
            PictureBox16.Image = My.Resources.Image3
            PictureBox17.Image = My.Resources.Image3
            PictureBox18.Image = My.Resources.Image3
            PictureBox19.Image = My.Resources.Image3
            PictureBox20.Image = My.Resources.Image3
            PictureBox24.Image = My.Resources.Image3
            PictureBox25.Image = My.Resources.Image3

            Button4.Text = "START"
            Button4.BackColor = Color.Red
            bIsReading = False

        Else
            Dim dataStream As New AdsStream(31)
            binRead = New BinaryReader(dataStream, System.Text.Encoding.ASCII)
            tcClient = New TwinCAT.Ads.TcAdsClient()
            tcClient.Connect(801)

            ReDim hConnect(22)

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
                hConnect(11) = tcClient.AddDeviceNotification(checkVariable(MaskedTextBox11.Text.ToString, MaskedTextBox11), dataStream, 10, 1, AdsTransMode.OnChange, 100, 0, Nothing)
                hConnect(12) = tcClient.AddDeviceNotification(checkVariable(MaskedTextBox12.Text.ToString, MaskedTextBox12), dataStream, 11, 1, AdsTransMode.OnChange, 100, 0, Nothing)
                hConnect(13) = tcClient.AddDeviceNotification(checkVariable(MaskedTextBox13.Text.ToString, MaskedTextBox13), dataStream, 12, 1, AdsTransMode.OnChange, 100, 0, Nothing)
                hConnect(14) = tcClient.AddDeviceNotification(checkVariable(MaskedTextBox14.Text.ToString, MaskedTextBox14), dataStream, 13, 1, AdsTransMode.OnChange, 100, 0, Nothing)
                hConnect(15) = tcClient.AddDeviceNotification(checkVariable(MaskedTextBox15.Text.ToString, MaskedTextBox15), dataStream, 14, 1, AdsTransMode.OnChange, 100, 0, Nothing)
                hConnect(16) = tcClient.AddDeviceNotification(checkVariable(MaskedTextBox16.Text.ToString, MaskedTextBox16), dataStream, 15, 1, AdsTransMode.OnChange, 100, 0, Nothing)
                hConnect(17) = tcClient.AddDeviceNotification(checkVariable(MaskedTextBox17.Text.ToString, MaskedTextBox17), dataStream, 16, 1, AdsTransMode.OnChange, 100, 0, Nothing)
                hConnect(18) = tcClient.AddDeviceNotification(checkVariable(MaskedTextBox18.Text.ToString, MaskedTextBox18), dataStream, 17, 1, AdsTransMode.OnChange, 100, 0, Nothing)
                hConnect(19) = tcClient.AddDeviceNotification(checkVariable(MaskedTextBox19.Text.ToString, MaskedTextBox19), dataStream, 18, 1, AdsTransMode.OnChange, 100, 0, Nothing)
                hConnect(20) = tcClient.AddDeviceNotification(checkVariable(MaskedTextBox20.Text.ToString, MaskedTextBox20), dataStream, 19, 1, AdsTransMode.OnChange, 100, 0, Nothing)
                hConnect(21) = tcClient.AddDeviceNotification(checkVariable(MaskedTextBox21.Text.ToString, MaskedTextBox21), dataStream, 20, 1, AdsTransMode.OnChange, 100, 0, Nothing)
                hConnect(22) = tcClient.AddDeviceNotification(checkVariable(MaskedTextBox22.Text.ToString, MaskedTextBox22), dataStream, 21, 1, AdsTransMode.OnChange, 100, 0, Nothing)

                AddHandler tcClient.AdsNotification, AddressOf OnNotification
                Button4.Text = "STOP"
                Button4.BackColor = Color.LightGreen
                bHasRead = True
                bIsReading = True

            Catch err As Exception
                MessageBox.Show(err.Message)
            End Try
        End If

        If Main.poziomdostepu = True Then
            MaskedTextBox1.Visible = True
            MaskedTextBox2.Visible = True
            MaskedTextBox3.Visible = True
            MaskedTextBox4.Visible = True
            MaskedTextBox5.Visible = True
            MaskedTextBox6.Visible = True
            MaskedTextBox7.Visible = True
            MaskedTextBox8.Visible = True
            MaskedTextBox9.Visible = True
            MaskedTextBox10.Visible = True
            MaskedTextBox11.Visible = True
            MaskedTextBox12.Visible = True
            MaskedTextBox13.Visible = True
            MaskedTextBox14.Visible = True
            MaskedTextBox15.Visible = True
            MaskedTextBox16.Visible = True
            MaskedTextBox17.Visible = True
            MaskedTextBox18.Visible = True
            MaskedTextBox19.Visible = True
            MaskedTextBox20.Visible = True
            MaskedTextBox21.Visible = True
            MaskedTextBox22.Visible = True
        Else
            MaskedTextBox1.Visible = False
            MaskedTextBox2.Visible = False
            MaskedTextBox3.Visible = False
            MaskedTextBox4.Visible = False
            MaskedTextBox5.Visible = True
            MaskedTextBox6.Visible = False
            MaskedTextBox7.Visible = False
            MaskedTextBox8.Visible = False
            MaskedTextBox9.Visible = False
            MaskedTextBox10.Visible = False
            MaskedTextBox11.Visible = False
            MaskedTextBox12.Visible = True
            MaskedTextBox13.Visible = True
            MaskedTextBox14.Visible = False
            MaskedTextBox15.Visible = False
            MaskedTextBox16.Visible = False
            MaskedTextBox17.Visible = False
            MaskedTextBox18.Visible = False
            MaskedTextBox19.Visible = False
            MaskedTextBox20.Visible = False
            MaskedTextBox21.Visible = False
            MaskedTextBox22.Visible = False
        End If
    End Sub
    Public Sub OnNotification(ByVal sender As Object, ByVal e As AdsNotificationEventArgs)
        Try
            e.DataStream.Position = e.Offset

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

    Private Sub Agregaty_Click(sender As Object, e As EventArgs) 
        Agregaty_Menu.Show()
    End Sub

End Class