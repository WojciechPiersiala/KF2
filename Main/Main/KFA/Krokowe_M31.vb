Imports TwinCAT.Ads
Imports System.IO

Public Class Krokowe_M31
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

    Public Z_Punkt_Ref_M31 As Double
    Public Z_Roznica1_M31 As Double
    Public Z_null_max_M31 As Double
    Public Z_null_min_31 As Double
    Public Z_lrActual_Position_M31 As Double
    Public Z_PozycjaMaxM31 As Double
    Public Z_PozycjaMinM31 As Double

    Private bEnable_M31_Notify As Integer
    Private bEnable_M31_Write As Integer

    Private bDisable_M31_Notify As Integer
    Private bDisable_M31_Write As Integer

    Private Reset_M31_Notify As Integer
    Private Reset_M31_Write As Integer
    Private bRef_M31_Notify As Integer
    Private bRef_M31_Write As Integer
    Private bPozycjaMinM31_button_Notify As Integer
    Private bPozycjaMinM31_button_Write As Integer
    Private bMoveRight_M31_Null_button_Notify As Integer
    Private bMoveRight_M31_Null_button_Write As Integer
    Private bMoveRight_M31_Null_potwierdz_button_Notify As Integer
    Private bMoveRight_M31_Null_potwierdz_button_Write As Integer
    Private bdomyslne_M31_Notify As Integer
    Private bdomyslne_M31_Write As Integer
    Private bMoveLeft_M31_Notify As Integer
    Private bMoveLeft_M31_Write As Integer
    Private bMoveRight_M31_Notify As Integer
    Private bMoveRight_M31_Write As Integer


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
            PictureBox7.Image = My.Resources.Image3

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

                bEnable_M31_Notify = tcClient.AddDeviceNotification(".bEnable_M31_WIZ", dataStream, 3, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                bEnable_M31_Write = tcClient.CreateVariableHandle(".bEnable_M31_WIZ")
                bDisable_M31_Notify = tcClient.AddDeviceNotification(".bDisable_M31_WIZ", dataStream, 69, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                bDisable_M31_Write = tcClient.CreateVariableHandle(".bDisable_M31_WIZ")

                Reset_M31_Notify = tcClient.AddDeviceNotification(".bReset_Axis_M31", dataStream, 4, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Reset_M31_Write = tcClient.CreateVariableHandle(".bReset_Axis_M31")
                bRef_M31_Notify = tcClient.AddDeviceNotification(".bRef_M31", dataStream, 5, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                bRef_M31_Write = tcClient.CreateVariableHandle(".bRef_M31")
                bPozycjaMinM31_button_Notify = tcClient.AddDeviceNotification(".bPozycjaMinM31_button", dataStream, 9, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                bPozycjaMinM31_button_Write = tcClient.CreateVariableHandle(".bPozycjaMinM31_button")
                bMoveRight_M31_Null_button_Notify = tcClient.AddDeviceNotification(".bMoveRight_M31_Null_button", dataStream, 6, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                bMoveRight_M31_Null_button_Write = tcClient.CreateVariableHandle(".bMoveRight_M31_Null_button")
                bMoveRight_M31_Null_potwierdz_button_Notify = tcClient.AddDeviceNotification(".bMoveRight_M31_Null_potwierdz_button", dataStream, 7, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                bMoveRight_M31_Null_potwierdz_button_Write = tcClient.CreateVariableHandle(".bMoveRight_M31_Null_potwierdz_button")
                bdomyslne_M31_Notify = tcClient.AddDeviceNotification(".bdomyslne_M31", dataStream, 8, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                bdomyslne_M31_Write = tcClient.CreateVariableHandle(".bdomyslne_M31")
                bMoveLeft_M31_Notify = tcClient.AddDeviceNotification(".bMoveLeft_M31", dataStream, 10, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                bMoveLeft_M31_Write = tcClient.CreateVariableHandle(".bMoveLeft_M31")
                bMoveRight_M31_Notify = tcClient.AddDeviceNotification(".bMoveRight_M31", dataStream, 11, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                bMoveRight_M31_Write = tcClient.CreateVariableHandle(".bMoveRight_M31")

                Z_null_max_M31 = tcClient.AddDeviceNotification(".nullmax_M31", dataStream, 12, 8, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Z_null_min_31 = tcClient.AddDeviceNotification(".nullmin_M31", dataStream, 20, 8, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Z_Punkt_Ref_M31 = tcClient.AddDeviceNotification(".PunktRefM31", dataStream, 28, 8, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Z_Roznica1_M31 = tcClient.AddDeviceNotification(".roznica1_M31", dataStream, 36, 8, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Z_lrActual_Position_M31 = tcClient.AddDeviceNotification(".lrActual_Position_M31", dataStream, 44, 8, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Z_PozycjaMaxM31 = tcClient.AddDeviceNotification(".PozycjaMaxM31", dataStream, 52, 8, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Z_PozycjaMinM31 = tcClient.AddDeviceNotification(".PozycjaMinM31", dataStream, 60, 8, AdsTransMode.OnChange, 100, 0, DBNull.Value)

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

            If (e.NotificationHandle = Z_Punkt_Ref_M31) Then
                Punkt_Ref_M31.Text = binRead.ReadDouble().ToString()
            End If

            If (e.NotificationHandle = Z_Roznica1_M31) Then
                Roznica1_M31.Text = binRead.ReadDouble().ToString()
            End If

            If (e.NotificationHandle = Z_null_max_M31) Then
                null_max_M31.Text = binRead.ReadDouble().ToString()
            End If

            If (e.NotificationHandle = Z_null_min_31) Then
                null_min_31.Text = binRead.ReadDouble().ToString()
            End If

            If (e.NotificationHandle = Z_lrActual_Position_M31) Then
                lrActual_Position_M31.Text = binRead.ReadDouble().ToString()
            End If

            If (e.NotificationHandle = Z_PozycjaMaxM31) Then
                PozycjaMaxM31.Text = binRead.ReadDouble().ToString()
            End If

            If (e.NotificationHandle = Z_PozycjaMinM31) Then
                PozycjaMinM31.Text = binRead.ReadDouble().ToString()
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



    Private Sub Power_M31_Click_Down(sender As Object, e As EventArgs) Handles Power_M31.MouseDown
        Try
            tcClient.WriteAny(bEnable_M31_Write, True)
            tcClient.WriteAny(bDisable_M31_Write, False)
            Power_M31.BackColor = Color.Red
            Button4.BackColor = Color.Green

        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub Button4_Click_Down(sender As Object, e As EventArgs) Handles Button4.MouseDown
        Try
            tcClient.WriteAny(bDisable_M31_Write, True)
            tcClient.WriteAny(bEnable_M31_Write, False)
            Button4.BackColor = Color.Red
            Power_M31.BackColor = Color.Green

        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub




    Private Sub X2_Lewo_Click_Down(sender As Object, e As EventArgs) Handles Reset_M31.MouseDown
        Try
            tcClient.WriteAny(Reset_M31_Write, True)
            Reset_M31.BackColor = Color.Green
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub X2_Lewo_Click_Up(sender As Object, e As EventArgs) Handles Reset_M31.MouseUp
        Try
            tcClient.WriteAny(Reset_M31_Write, False)
            Reset_M31.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub X3_Lewo_Click_Down(sender As Object, e As EventArgs) Handles Referencjal_M31.MouseDown
        Try
            tcClient.WriteAny(bRef_M31_Write, True)
            Referencjal_M31.BackColor = Color.Green
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub X3_Lewo_Click_Up(sender As Object, e As EventArgs) Handles Referencjal_M31.MouseUp
        Try
            tcClient.WriteAny(bRef_M31_Write, False)
            Referencjal_M31.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub X1_X2_Lewo_Click_Down(sender As Object, e As EventArgs) Handles Pozycja_Min_M31.MouseDown
        Try
            tcClient.WriteAny(bPozycjaMinM31_button_Write, True)
            Pozycja_Min_M31.BackColor = Color.Green
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub X1_X2_Lewo_Click_Up(sender As Object, e As EventArgs) Handles Pozycja_Min_M31.MouseUp
        Try
            tcClient.WriteAny(bPozycjaMinM31_button_Write, False)
            Pozycja_Min_M31.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub X1_Prawo_Click_Down(sender As Object, e As EventArgs) Handles Null_M31.MouseDown
        Try
            tcClient.WriteAny(bMoveRight_M31_Null_button_Write, True)
            Null_M31.BackColor = Color.Green
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub X1_Prawo_Click_Up(sender As Object, e As EventArgs) Handles Null_M31.MouseUp
        Try
            tcClient.WriteAny(bMoveRight_M31_Null_button_Write, False)
            Null_M31.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub X2_Prawo_Click_Down(sender As Object, e As EventArgs) Handles Null_potwierdz_M31.MouseDown
        Try
            tcClient.WriteAny(bMoveRight_M31_Null_potwierdz_button_Write, True)
            Null_potwierdz_M31.BackColor = Color.Green
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub X2_Prawo_Click_Up(sender As Object, e As EventArgs) Handles Null_potwierdz_M31.MouseUp
        Try
            tcClient.WriteAny(bMoveRight_M31_Null_potwierdz_button_Write, False)
            Null_potwierdz_M31.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub X3_Prawo_Click_Down(sender As Object, e As EventArgs) Handles domyslne_M31.MouseDown
        Try
            tcClient.WriteAny(bdomyslne_M31_Write, True)
            domyslne_M31.BackColor = Color.Green
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub X3_Prawo_Click_Up(sender As Object, e As EventArgs) Handles domyslne_M31.MouseUp
        Try
            tcClient.WriteAny(bdomyslne_M31_Write, False)
            domyslne_M31.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub X1_X2_Prawo_Click_Down(sender As Object, e As EventArgs) Handles Lewo_M31.MouseDown
        Try
            tcClient.WriteAny(bMoveLeft_M31_Write, True)
            Lewo_M31.BackColor = Color.Green
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub X1_X2_Prawo_Click_Up(sender As Object, e As EventArgs) Handles Lewo_M31.MouseUp
        Try
            tcClient.WriteAny(bMoveLeft_M31_Write, False)
            Lewo_M31.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub Automat_Click_Down(sender As Object, e As EventArgs) Handles Prawo_M31.MouseDown
        Try
            tcClient.WriteAny(bMoveRight_M31_Write, True)
            Prawo_M31.BackColor = Color.Green
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub Automat_Click_Up(sender As Object, e As EventArgs) Handles Prawo_M31.MouseUp
        Try
            tcClient.WriteAny(bMoveRight_M31_Write, False)
            Prawo_M31.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub Power_M31_Click_Down(sender As Object, e As MouseEventArgs) Handles Power_M31.MouseDown

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Krokowe_M41.Show()
        Me.Close()
    End Sub
End Class