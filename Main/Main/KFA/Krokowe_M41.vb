Imports TwinCAT.Ads
Imports System.IO

Public Class Krokowe_M41
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private tcClient As TcAdsClient
    Public hConnect() As Integer
    Private dataStream As AdsStream
    Private binRead As BinaryReader
    Private bIsReading As Boolean = False
    Private bHasRead As Boolean = False
    Private iMaxValues As Integer = 4
    Private aPicBoxes(0 To iMaxValues) As PictureBox
    Private binReader As System.IO.BinaryReader

    Public Z_Punkt_Ref_M41 As Double
    Public Z_Roznica1_M41 As Double
    Public Z_null_max_M41 As Double
    Public Z_null_min_41 As Double
    Public Z_lrActual_Position_M41 As Double
    Public Z_PozycjaMaxM41 As Double
    Public Z_PozycjaMinM41 As Double

    Private bEnable_M41_Notify As Integer
    Private bEnable_M41_Write As Integer

    Private bDisable_M41_Notify As Integer
    Private bDisable_M41_Write As Integer


    Private Reset_M41_Notify As Integer
    Private Reset_M41_Write As Integer
    Private bRef_M41_Notify As Integer
    Private bRef_M41_Write As Integer
    Private bPozycjaMinM41_button_Notify As Integer
    Private bPozycjaMinM41_button_Write As Integer
    Private bMoveRight_M41_Null_button_Notify As Integer
    Private bMoveRight_M41_Null_button_Write As Integer
    Private bMoveRight_M41_Null_potwierdz_button_Notify As Integer
    Private bMoveRight_M41_Null_potwierdz_button_Write As Integer
    Private bdomyslne_M41_Notify As Integer
    Private bdomyslne_M41_Write As Integer
    Private bMoveLeft_M41_Notify As Integer
    Private bMoveLeft_M41_Write As Integer
    Private bMoveRight_M41_Notify As Integer
    Private bMoveRight_M41_Write As Integer


    Public Sub Krokowe_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        aPicBoxes(1) = PictureBox1
        aPicBoxes(2) = PictureBox2
        aPicBoxes(3) = PictureBox3
        aPicBoxes(4) = PictureBox7

        If bIsReading Then
            Try
                tcClient.Dispose()
            Catch err As Exception
                MessageBox.Show(err.Message)
            End Try

            PictureBox1.Image = My.Resources.Image3
            PictureBox2.Image = My.Resources.Image3
            PictureBox3.Image = My.Resources.Image3

            Button3.Text = "Online"
            Button3.BackColor = Color.LightGreen
            bIsReading = False

        Else
            Dim dataStream As New AdsStream()
            binRead = New BinaryReader(dataStream, System.Text.Encoding.ASCII)
            tcClient = New TwinCAT.Ads.TcAdsClient()
            tcClient.Connect(801)

            ReDim hConnect(4)

            Try
                hConnect(1) = tcClient.AddDeviceNotification(checkVariable(MaskedTextBox1.Text.ToString, MaskedTextBox1), dataStream, 0, 1, AdsTransMode.OnChange, 100, 0, Nothing)
                hConnect(2) = tcClient.AddDeviceNotification(checkVariable(MaskedTextBox2.Text.ToString, MaskedTextBox2), dataStream, 1, 1, AdsTransMode.OnChange, 100, 0, Nothing)
                hConnect(3) = tcClient.AddDeviceNotification(checkVariable(MaskedTextBox3.Text.ToString, MaskedTextBox3), dataStream, 2, 1, AdsTransMode.OnChange, 100, 0, Nothing)
                hConnect(4) = tcClient.AddDeviceNotification(checkVariable(MaskedTextBox4.Text.ToString, MaskedTextBox4), dataStream, 9, 1, AdsTransMode.OnChange, 100, 0, Nothing)

                bEnable_M41_Notify = tcClient.AddDeviceNotification(".bEnable_M41_WIZ", dataStream, 3, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                bEnable_M41_Write = tcClient.CreateVariableHandle(".bEnable_M41_WIZ")
                bDisable_M41_Notify = tcClient.AddDeviceNotification(".bDisable_M41_WIZ", dataStream, 69, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                bDisable_M41_Write = tcClient.CreateVariableHandle(".bDisable_M41_WIZ")

                Reset_M41_Notify = tcClient.AddDeviceNotification(".bReset_Axis_M41", dataStream, 4, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Reset_M41_Write = tcClient.CreateVariableHandle(".bReset_Axis_M41")
                bRef_M41_Notify = tcClient.AddDeviceNotification(".bRef_M41", dataStream, 5, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                bRef_M41_Write = tcClient.CreateVariableHandle(".bRef_M41")

                bPozycjaMinM41_button_Notify = tcClient.AddDeviceNotification(".bPozycjaMinM41_button", dataStream, 9, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                bPozycjaMinM41_button_Write = tcClient.CreateVariableHandle(".bPozycjaMinM41_button")
                bMoveRight_M41_Null_button_Notify = tcClient.AddDeviceNotification(".bMoveRight_M41_Null_button", dataStream, 6, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                bMoveRight_M41_Null_button_Write = tcClient.CreateVariableHandle(".bMoveRight_M41_Null_button")
                bMoveRight_M41_Null_potwierdz_button_Notify = tcClient.AddDeviceNotification(".bMoveRight_M41_Null_potwierdz_button", dataStream, 7, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                bMoveRight_M41_Null_potwierdz_button_Write = tcClient.CreateVariableHandle(".bMoveRight_M41_Null_potwierdz_button")
                bdomyslne_M41_Notify = tcClient.AddDeviceNotification(".bdomyslne_M41", dataStream, 8, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                bdomyslne_M41_Write = tcClient.CreateVariableHandle(".bdomyslne_M41")
                bMoveLeft_M41_Notify = tcClient.AddDeviceNotification(".bMoveLeft_M41", dataStream, 10, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                bMoveLeft_M41_Write = tcClient.CreateVariableHandle(".bMoveLeft_M41")
                bMoveRight_M41_Notify = tcClient.AddDeviceNotification(".bMoveRight_M41", dataStream, 11, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                bMoveRight_M41_Write = tcClient.CreateVariableHandle(".bMoveRight_M41")

                Z_null_max_M41 = tcClient.AddDeviceNotification(".nullmax_M41", dataStream, 12, 8, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Z_null_min_41 = tcClient.AddDeviceNotification(".nullmin_M41", dataStream, 20, 8, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Z_Punkt_Ref_M41 = tcClient.AddDeviceNotification(".PunktRefM41", dataStream, 28, 8, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Z_Roznica1_M41 = tcClient.AddDeviceNotification(".roznica1_M41", dataStream, 36, 8, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Z_lrActual_Position_M41 = tcClient.AddDeviceNotification(".lrActual_Position_M41", dataStream, 44, 8, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Z_PozycjaMaxM41 = tcClient.AddDeviceNotification(".PozycjaMaxM41", dataStream, 52, 8, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Z_PozycjaMinM41 = tcClient.AddDeviceNotification(".PozycjaMinM41", dataStream, 60, 8, AdsTransMode.OnChange, 100, 0, DBNull.Value)

                AddHandler tcClient.AdsNotification, AddressOf OnNotification
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

            If (e.NotificationHandle = Z_Punkt_Ref_M41) Then
                Punkt_Ref_M41.Text = binRead.ReadDouble().ToString()
            End If

            If (e.NotificationHandle = Z_Roznica1_M41) Then
                Roznica1_M41.Text = binRead.ReadDouble().ToString()
            End If

            If (e.NotificationHandle = Z_null_max_M41) Then
                null_max_M41.Text = binRead.ReadDouble().ToString()
            End If

            If (e.NotificationHandle = Z_null_min_41) Then
                null_min_41.Text = binRead.ReadDouble().ToString()
            End If

            If (e.NotificationHandle = Z_lrActual_Position_M41) Then
                lrActual_Position_M41.Text = binRead.ReadDouble().ToString()
            End If

            If (e.NotificationHandle = Z_PozycjaMaxM41) Then
                PozycjaMaxM41.Text = binRead.ReadDouble().ToString()
            End If

            If (e.NotificationHandle = Z_PozycjaMinM41) Then
                PozycjaMinM41.Text = binRead.ReadDouble().ToString()
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


    Private Sub Power_M41_Click_Down(sender As Object, e As EventArgs) Handles Power_M41.MouseDown
        Try
            tcClient.WriteAny(bEnable_M41_Write, True)
            tcClient.WriteAny(bDisable_M41_Write, False)
            Power_M41.BackColor = Color.Red
            Button4.BackColor = Color.Green

        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub Button4_Click_Down(sender As Object, e As EventArgs) Handles Button4.MouseDown
        Try
            tcClient.WriteAny(bDisable_M41_Write, True)
            tcClient.WriteAny(bEnable_M41_Write, False)
            Button4.BackColor = Color.Red
            Power_M41.BackColor = Color.Green

        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub



    Private Sub X2_Lewo_Click_Down(sender As Object, e As EventArgs) Handles Reset_M41.MouseDown
        Try
            tcClient.WriteAny(Reset_M41_Write, True)
            Reset_M41.BackColor = Color.Green
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub X2_Lewo_Click_Up(sender As Object, e As EventArgs) Handles Reset_M41.MouseUp
        Try
            tcClient.WriteAny(Reset_M41_Write, False)
            Reset_M41.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub X3_Lewo_Click_Down(sender As Object, e As EventArgs) Handles Referencjal_M41.MouseDown
        Try
            tcClient.WriteAny(bRef_M41_Write, True)
            Referencjal_M41.BackColor = Color.Green
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub X3_Lewo_Click_Up(sender As Object, e As EventArgs) Handles Referencjal_M41.MouseUp
        Try
            tcClient.WriteAny(bRef_M41_Write, False)
            Referencjal_M41.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub X1_X2_Lewo_Click_Down(sender As Object, e As EventArgs) Handles Pozycja_Min_M41.MouseDown
        Try
            tcClient.WriteAny(bPozycjaMinM41_button_Write, True)
            Pozycja_Min_M41.BackColor = Color.Green
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub X1_X2_Lewo_Click_Up(sender As Object, e As EventArgs) Handles Pozycja_Min_M41.MouseUp
        Try
            tcClient.WriteAny(bPozycjaMinM41_button_Write, False)
            Pozycja_Min_M41.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub X1_Prawo_Click_Down(sender As Object, e As EventArgs) Handles Null_M41.MouseDown
        Try
            tcClient.WriteAny(bMoveRight_M41_Null_button_Write, True)
            Null_M41.BackColor = Color.Green
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub X1_Prawo_Click_Up(sender As Object, e As EventArgs) Handles Null_M41.MouseUp
        Try
            tcClient.WriteAny(bMoveRight_M41_Null_button_Write, False)
            Null_M41.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub X2_Prawo_Click_Down(sender As Object, e As EventArgs) Handles Null_potwierdz_M41.MouseDown
        Try
            tcClient.WriteAny(bMoveRight_M41_Null_potwierdz_button_Write, True)
            Null_potwierdz_M41.BackColor = Color.Green
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub X2_Prawo_Click_Up(sender As Object, e As EventArgs) Handles Null_potwierdz_M41.MouseUp
        Try
            tcClient.WriteAny(bMoveRight_M41_Null_potwierdz_button_Write, False)
            Null_potwierdz_M41.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub X3_Prawo_Click_Down(sender As Object, e As EventArgs) Handles domyslne_M41.MouseDown
        Try
            tcClient.WriteAny(bdomyslne_M41_Write, True)
            domyslne_M41.BackColor = Color.Green
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub X3_Prawo_Click_Up(sender As Object, e As EventArgs) Handles domyslne_M41.MouseUp
        Try
            tcClient.WriteAny(bdomyslne_M41_Write, False)
            domyslne_M41.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub X1_X2_Prawo_Click_Down(sender As Object, e As EventArgs) Handles Lewo_M41.MouseDown
        Try
            tcClient.WriteAny(bMoveLeft_M41_Write, True)
            Lewo_M41.BackColor = Color.Green
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub X1_X2_Prawo_Click_Up(sender As Object, e As EventArgs) Handles Lewo_M41.MouseUp
        Try
            tcClient.WriteAny(bMoveLeft_M41_Write, False)
            Lewo_M41.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub Automat_Click_Down(sender As Object, e As EventArgs) Handles Prawo_M41.MouseDown
        Try
            tcClient.WriteAny(bMoveRight_M41_Write, True)
            Prawo_M41.BackColor = Color.Green
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub Automat_Click_Up(sender As Object, e As EventArgs) Handles Prawo_M41.MouseUp
        Try
            tcClient.WriteAny(bMoveRight_M41_Write, False)
            Prawo_M41.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub Power_M41_Click_Down(sender As Object, e As MouseEventArgs) Handles Power_M41.MouseDown

    End Sub

    Private Sub Power_M41_Click_Up(sender As Object, e As MouseEventArgs) Handles Power_M41.MouseUp

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Serwo.Show()
        Me.Close()
    End Sub
End Class
