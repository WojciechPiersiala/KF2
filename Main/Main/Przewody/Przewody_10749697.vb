Imports TwinCAT.Ads
Imports System.IO

Public Class Przewody_10749697
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click       'zamknij
        Me.Close()
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click     'minimalizacja
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private tcClient As TcAdsClient                         'Klient ADS / Obiekt komunikacyjny ADS.
    Private hConnect() As Integer                           'uchwyt obslugi polaczenia
    Private dataStream As AdsStream                         'udestepnia dostep do podstawowego strumienia BinaryReader 
    Private binRead As BinaryReader                         'odczytuje zarówno podstawowe typy danych, jak i typy danych PLC jako wartości binarne.
    Private bIsReading As Boolean = False 'flaga procesu
    Private bHasRead As Boolean = False                     'powiadomienie o ukonczeniu pobierania
    Private iMaxValues As Integer = 25
    Private aPicBoxes(0 To iMaxValues) As PictureBox        'ikonki
    Private binReader As System.IO.BinaryReader


    Private hSwitchNotify As Integer
    Private hSwitchNotify2 As Integer
    Private hSwitchNotify3 As Integer
    Private hSwitchNotify4 As Integer
    Private hSwitchNotify5 As Integer
    Private hSwitchNotify6 As Integer
    Private hSwitchNotify7 As Integer
    Private hSwitchNotify8 As Integer
    Private hSwitchNotify9 As Integer
    Private hSwitchNotify10 As Integer
    Private hSwitchNotify11 As Integer
    Private hSwitchNotify12 As Integer
    Private hSwitchNotify13 As Integer
    Private hSwitchNotify14 As Integer
    Private hSwitchNotify15 As Integer
    Private hSwitchNotify16 As Integer
    Private hSwitchNotify17 As Integer
    Private hSwitchNotify18 As Integer
    Private hSwitchNotify19 As Integer
    Private hSwitchNotify20 As Integer
    Private hSwitchNotify21 As Integer
    Private hSwitchNotify22 As Integer
    Private hSwitchNotify23 As Integer
    Private hSwitchNotify24 As Integer
    Private hSwitchNotify25 As Integer
    Private hSwitchNotify26 As Integer

    Private wybor_kable As Integer
    Private Przewod_1_In_WIZ As Integer
    Private Przewod_2_In_WIZ As Integer
    Private Przewod_3_In_WIZ As Integer
    Private Przewod_4_In_WIZ As Integer
    Private Przewod_5_In_WIZ As Integer
    Private Przewod_6_In_WIZ As Integer
    Private Przewod_7_In_WIZ As Integer
    Private Przewod_8_In_WIZ As Integer
    Private Przewod_9_In_WIZ As Integer
    Private Przewod_10_In_WIZ As Integer
    Private Przewod_11_In_WIZ As Integer
    Private Przewod_12_In_WIZ As Integer
    Private Przewod_13_In_WIZ As Integer
    Private Przewod_14_In_WIZ As Integer
    Private Przewod_15_In_WIZ As Integer
    Private Przewod_16_In_WIZ As Integer
    Private Przewod_17_In_WIZ As Integer
    Private Przewod_18_In_WIZ As Integer
    Private Przewod_19_In_WIZ As Integer
    Private Przewod_20_In_WIZ As Integer
    Private Przewod_21_In_WIZ As Integer
    Private Przewod_22_In_WIZ As Integer
    Private Przewod_23_In_WIZ As Integer
    Private Przewod_24_In_WIZ As Integer
    Private Przewod_25_In_WIZ As Integer


    ''' <summary>
    ''' Placz sie z PLC (przycisk dziala jak SR)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Public Sub Przewody_7_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load      

        'wczytaj ikonki
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
        aPicBoxes(21) = PictureBox21
        aPicBoxes(22) = PictureBox22
        aPicBoxes(23) = PictureBox23
        aPicBoxes(24) = PictureBox24
        aPicBoxes(25) = PictureBox25

        If bIsReading Then                                                                          'wczytywanie
            Try
                tcClient.Dispose()
            Catch err As Exception
                MessageBox.Show(err.Message)
            End Try

            PictureBox1.Image = My.Resources.Image3                                                'zaladuj ikonki (wczytywanie)
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
            PictureBox21.Image = My.Resources.Image3
            PictureBox22.Image = My.Resources.Image3
            PictureBox23.Image = My.Resources.Image3
            PictureBox24.Image = My.Resources.Image3
            PictureBox25.Image = My.Resources.Image3

            Button3.Text = "Online"
            Button3.BackColor = Color.LightGreen
            bIsReading = False

        Else
            Dim dataStream As New AdsStream(31) 'Inicjuje nowe wystąpienie klasy AdsStream. Instancja ma pojemność rozszerzalną zainicjowaną na zero, Udostępnia dostęp do podstawowego strumienia BinaryReader.
            binRead = New BinaryReader(dataStream, System.Text.Encoding.ASCII)
            tcClient = New TwinCAT.Ads.TcAdsClient() 'Nawiązuje połączenie z urządzeniem ADS.
            tcClient.Connect(801)

            ReDim hConnect(25)



            Try
            ''' <summary>
            '''Łączy zmienną z klientem ADS. Klient ADS zostanie powiadomiony o zdarzeniu AdsNotification.
            ''' </summary>
            ''' <param name="variableName"></param>
            ''' <param name="dataStream"></param>
            ''' <param name="transMode"></param>
            ''' <param name="cycleTime"></param>
            ''' <param name="maxDelay"></param>
            ''' <param name="userData"></param>
            '''<returns>
            '''Zwraca usyskany uchwyt zmiennej ADS. (Uchwyt powiadomienia)
            '''</returns>
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
                hConnect(23) = tcClient.AddDeviceNotification(checkVariable(MaskedTextBox23.Text.ToString, MaskedTextBox23), dataStream, 22, 1, AdsTransMode.OnChange, 100, 0, Nothing)
                hConnect(24) = tcClient.AddDeviceNotification(checkVariable(MaskedTextBox24.Text.ToString, MaskedTextBox24), dataStream, 23, 1, AdsTransMode.OnChange, 100, 0, Nothing)
                hConnect(25) = tcClient.AddDeviceNotification(checkVariable(MaskedTextBox25.Text.ToString, MaskedTextBox25), dataStream, 24, 1, AdsTransMode.OnChange, 100, 0, Nothing)

                'Łączy zmienną z klientem ADS. Klient ADS zostanie powiadomiony o zdarzeniu AdsNotification.'''
                hSwitchNotify = tcClient.AddDeviceNotification(".wybor_kable", dataStream, 25, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                'Generuje unikalny uchwyt dla zmiennej ADS.
                wybor_kable = tcClient.CreateVariableHandle(".wybor_kable")

                hSwitchNotify2 = tcClient.AddDeviceNotification(".Przewod_1_In_WIZ", dataStream, 26, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Przewod_1_In_WIZ = tcClient.CreateVariableHandle(".Przewod_1_In_WIZ")

                hSwitchNotify3 = tcClient.AddDeviceNotification(".Przewod_2_In_WIZ", dataStream, 27, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Przewod_2_In_WIZ = tcClient.CreateVariableHandle(".Przewod_2_In_WIZ")

                hSwitchNotify4 = tcClient.AddDeviceNotification(".Przewod_3_In_WIZ", dataStream, 27, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Przewod_3_In_WIZ = tcClient.CreateVariableHandle(".Przewod_3_In_WIZ")

                hSwitchNotify5 = tcClient.AddDeviceNotification(".Przewod_4_In_WIZ", dataStream, 27, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Przewod_4_In_WIZ = tcClient.CreateVariableHandle(".Przewod_4_In_WIZ")

                hSwitchNotify6 = tcClient.AddDeviceNotification(".Przewod_5_In_WIZ", dataStream, 27, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Przewod_5_In_WIZ = tcClient.CreateVariableHandle(".Przewod_5_In_WIZ")

                hSwitchNotify7 = tcClient.AddDeviceNotification(".Przewod_6_In_WIZ", dataStream, 27, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Przewod_6_In_WIZ = tcClient.CreateVariableHandle(".Przewod_6_In_WIZ")

                hSwitchNotify8 = tcClient.AddDeviceNotification(".Przewod_7_In_WIZ", dataStream, 27, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Przewod_7_In_WIZ = tcClient.CreateVariableHandle(".Przewod_7_In_WIZ")

                hSwitchNotify9 = tcClient.AddDeviceNotification(".Przewod_8_In_WIZ", dataStream, 27, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Przewod_8_In_WIZ = tcClient.CreateVariableHandle(".Przewod_8_In_WIZ")

                hSwitchNotify10 = tcClient.AddDeviceNotification(".Przewod_9_In_WIZ", dataStream, 27, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Przewod_9_In_WIZ = tcClient.CreateVariableHandle(".Przewod_9_In_WIZ")

                hSwitchNotify11 = tcClient.AddDeviceNotification(".Przewod_10_In_WIZ", dataStream, 27, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Przewod_10_In_WIZ = tcClient.CreateVariableHandle(".Przewod_10_In_WIZ")

                hSwitchNotify12 = tcClient.AddDeviceNotification(".Przewod_11_In_WIZ", dataStream, 27, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Przewod_11_In_WIZ = tcClient.CreateVariableHandle(".Przewod_11_In_WIZ")

                hSwitchNotify13 = tcClient.AddDeviceNotification(".Przewod_12_In_WIZ", dataStream, 27, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Przewod_12_In_WIZ = tcClient.CreateVariableHandle(".Przewod_12_In_WIZ")

                hSwitchNotify14 = tcClient.AddDeviceNotification(".Przewod_13_In_WIZ", dataStream, 27, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Przewod_13_In_WIZ = tcClient.CreateVariableHandle(".Przewod_13_In_WIZ")

                hSwitchNotify15 = tcClient.AddDeviceNotification(".Przewod_14_In_WIZ", dataStream, 27, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Przewod_14_In_WIZ = tcClient.CreateVariableHandle(".Przewod_14_In_WIZ")

                hSwitchNotify16 = tcClient.AddDeviceNotification(".Przewod_15_In_WIZ", dataStream, 27, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Przewod_15_In_WIZ = tcClient.CreateVariableHandle(".Przewod_15_In_WIZ")

                hSwitchNotify17 = tcClient.AddDeviceNotification(".Przewod_16_In_WIZ", dataStream, 27, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Przewod_16_In_WIZ = tcClient.CreateVariableHandle(".Przewod_16_In_WIZ")

                hSwitchNotify18 = tcClient.AddDeviceNotification(".Przewod_17_In_WIZ", dataStream, 27, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Przewod_17_In_WIZ = tcClient.CreateVariableHandle(".Przewod_17_In_WIZ")

                hSwitchNotify19 = tcClient.AddDeviceNotification(".Przewod_18_In_WIZ", dataStream, 27, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Przewod_18_In_WIZ = tcClient.CreateVariableHandle(".Przewod_18_In_WIZ")

                hSwitchNotify20 = tcClient.AddDeviceNotification(".Przewod_19_In_WIZ", dataStream, 27, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Przewod_19_In_WIZ = tcClient.CreateVariableHandle(".Przewod_19_In_WIZ")

                hSwitchNotify21 = tcClient.AddDeviceNotification(".Przewod_20_In_WIZ", dataStream, 27, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Przewod_20_In_WIZ = tcClient.CreateVariableHandle(".Przewod_20_In_WIZ")

                hSwitchNotify22 = tcClient.AddDeviceNotification(".Przewod_21_In_WIZ", dataStream, 27, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Przewod_21_In_WIZ = tcClient.CreateVariableHandle(".Przewod_21_In_WIZ")

                hSwitchNotify23 = tcClient.AddDeviceNotification(".Przewod_22_In_WIZ", dataStream, 27, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Przewod_22_In_WIZ = tcClient.CreateVariableHandle(".Przewod_22_In_WIZ")

                hSwitchNotify24 = tcClient.AddDeviceNotification(".Przewod_23_In_WIZ", dataStream, 27, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Przewod_23_In_WIZ = tcClient.CreateVariableHandle(".Przewod_23_In_WIZ")

                hSwitchNotify25 = tcClient.AddDeviceNotification(".Przewod_24_In_WIZ", dataStream, 27, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Przewod_24_In_WIZ = tcClient.CreateVariableHandle(".Przewod_24_In_WIZ")

                hSwitchNotify26 = tcClient.AddDeviceNotification(".Przewod_25_In_WIZ", dataStream, 27, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Przewod_25_In_WIZ = tcClient.CreateVariableHandle(".Przewod_25_In_WIZ")

                AddHandler tcClient.AdsNotification, AddressOf OnNotification     'Przydziel obsluge zdarzenia  tcClient.AdsNotification do funkcji OnNotification
                Button3.Text = "Offline"
                Button3.BackColor = Color.Red
                bHasRead = True
                bIsReading = True

            Catch err As Exception
                MessageBox.Show(err.Message)
            End Try
        End If
    End Sub

    Public Sub OnNotification(ByVal sender As Object, ByVal e As AdsNotificationEventArgs)   'function handler do polaczenia ADS
        Try
            e.DataStream.Position = e.Offset

            Dim strValue As String = ""
            Dim i As Integer
            For i = 1 To iMaxValues
                If (e.NotificationHandle = hConnect(i)) Then
                    If binRead.ReadBoolean() Then
                        aPicBoxes(i).Image = My.Resources.Image2  'Ok
                    Else
                        aPicBoxes(i).Image = My.Resources.Image1  'No
                    End If
                End If
            Next i

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    ''' <summary>
    ''' Obsluga zdarzenia wywolane przez wykonanie polaczenia z PLC. ( wizualne potwierdzenie rozpoczecia procesu )
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Function checkVariable(sString As String, mtb As MaskedTextBox) As String 'sprawdz pozycje
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
            tcClient.WriteAny(wybor_kable, True)
            Button4.BackColor = Color.Green
            Button5.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            tcClient.WriteAny(wybor_kable, False)
            Button5.BackColor = Color.Red
            Button4.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub Przewod1_Down(sender As Object, e As EventArgs) Handles Button8.MouseDown
        Try
            tcClient.WriteAny(Przewod_1_In_WIZ, True)
            Button8.BackColor = Color.Green
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub Przewod1_UP(sender As Object, e As EventArgs) Handles Button8.MouseUp
        Try
            tcClient.WriteAny(Przewod_1_In_WIZ, False)
            Button8.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub Przewod2_Down(sender As Object, e As EventArgs) Handles Button9.MouseDown
        Try
            tcClient.WriteAny(Przewod_2_In_WIZ, True)
            Button9.BackColor = Color.Green
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub Przewod2_UP(sender As Object, e As EventArgs) Handles Button9.MouseUp
        Try
            tcClient.WriteAny(Przewod_2_In_WIZ, False)
            Button9.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub Przewod3_Down(sender As Object, e As EventArgs) Handles Button10.MouseDown
        Try
            tcClient.WriteAny(Przewod_3_In_WIZ, True)
            Button10.BackColor = Color.Green
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub Przewod3_UP(sender As Object, e As EventArgs) Handles Button10.MouseUp
        Try
            tcClient.WriteAny(Przewod_3_In_WIZ, False)
            Button10.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub Przewod4_Down(sender As Object, e As EventArgs) Handles Button11.MouseDown
        Try
            tcClient.WriteAny(Przewod_4_In_WIZ, True)
            Button11.BackColor = Color.Green
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub Przewod4_UP(sender As Object, e As EventArgs) Handles Button11.MouseUp
        Try
            tcClient.WriteAny(Przewod_4_In_WIZ, False)
            Button11.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub Przewod5_Down(sender As Object, e As EventArgs) Handles Button12.MouseDown
        Try
            tcClient.WriteAny(Przewod_5_In_WIZ, True)
            Button12.BackColor = Color.Green
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub Przewod5_UP(sender As Object, e As EventArgs) Handles Button12.MouseUp
        Try
            tcClient.WriteAny(Przewod_5_In_WIZ, False)
            Button12.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub Przewod6_Down(sender As Object, e As EventArgs) Handles Button13.MouseDown
        Try
            tcClient.WriteAny(Przewod_6_In_WIZ, True)
            Button13.BackColor = Color.Green
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub Przewod6_UP(sender As Object, e As EventArgs) Handles Button13.MouseUp
        Try
            tcClient.WriteAny(Przewod_6_In_WIZ, False)
            Button13.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub Przewod7_Down(sender As Object, e As EventArgs) Handles Button14.MouseDown
        Try
            tcClient.WriteAny(Przewod_7_In_WIZ, True)
            Button14.BackColor = Color.Green
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub Przewod7_UP(sender As Object, e As EventArgs) Handles Button14.MouseUp
        Try
            tcClient.WriteAny(Przewod_7_In_WIZ, False)
            Button14.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub Przewod8_Down(sender As Object, e As EventArgs) Handles Button15.MouseDown
        Try
            tcClient.WriteAny(Przewod_8_In_WIZ, True)
            Button15.BackColor = Color.Green
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub Przewod8_UP(sender As Object, e As EventArgs) Handles Button15.MouseUp
        Try
            tcClient.WriteAny(Przewod_8_In_WIZ, False)
            Button15.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub Przewod9_Down(sender As Object, e As EventArgs) Handles Button16.MouseDown
        Try
            tcClient.WriteAny(Przewod_9_In_WIZ, True)
            Button16.BackColor = Color.Green
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub Przewod9_UP(sender As Object, e As EventArgs) Handles Button16.MouseUp
        Try
            tcClient.WriteAny(Przewod_9_In_WIZ, False)
            Button16.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub Przewod10_Down(sender As Object, e As EventArgs) Handles Button17.MouseDown
        Try
            tcClient.WriteAny(Przewod_10_In_WIZ, True)
            Button17.BackColor = Color.Green
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub Przewod10_UP(sender As Object, e As EventArgs) Handles Button17.MouseUp
        Try
            tcClient.WriteAny(Przewod_10_In_WIZ, False)
            Button17.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub Przewod11_Down(sender As Object, e As EventArgs) Handles Button18.MouseDown
        Try
            tcClient.WriteAny(Przewod_11_In_WIZ, True)
            Button18.BackColor = Color.Green
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub Przewod11_UP(sender As Object, e As EventArgs) Handles Button18.MouseUp
        Try
            tcClient.WriteAny(Przewod_11_In_WIZ, False)
            Button18.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub Przewod12_Down(sender As Object, e As EventArgs) Handles Button19.MouseDown
        Try
            tcClient.WriteAny(Przewod_12_In_WIZ, True)
            Button19.BackColor = Color.Green
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub Przewod12_UP(sender As Object, e As EventArgs) Handles Button19.MouseUp
        Try
            tcClient.WriteAny(Przewod_12_In_WIZ, False)
            Button19.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub Przewod13_Down(sender As Object, e As EventArgs) Handles Button20.MouseDown
        Try
            tcClient.WriteAny(Przewod_13_In_WIZ, True)
            Button20.BackColor = Color.Green
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub Przewod13_UP(sender As Object, e As EventArgs) Handles Button20.MouseUp
        Try
            tcClient.WriteAny(Przewod_13_In_WIZ, False)
            Button20.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub Przewod14_Down2(sender As Object, e As EventArgs) Handles Button21.MouseDown
        Try
            tcClient.WriteAny(Przewod_14_In_WIZ, True)
            Button21.BackColor = Color.Green
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub Przewod14_UP(sender As Object, e As EventArgs) Handles Button21.MouseUp
        Try
            tcClient.WriteAny(Przewod_14_In_WIZ, False)
            Button21.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub Przewod15_Down(sender As Object, e As EventArgs) Handles Button22.MouseDown
        Try
            tcClient.WriteAny(Przewod_15_In_WIZ, True)
            Button22.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub Przewod15_UP(sender As Object, e As EventArgs) Handles Button22.MouseUp
        Try
            tcClient.WriteAny(Przewod_15_In_WIZ, False)
            Button22.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub Przewod16_Down(sender As Object, e As EventArgs) Handles Button23.MouseDown
        Try
            tcClient.WriteAny(Przewod_16_In_WIZ, True)
            Button23.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub Przewod16_UP(sender As Object, e As EventArgs) Handles Button23.MouseUp
        Try
            tcClient.WriteAny(Przewod_16_In_WIZ, False)
            Button23.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub Przewod17_Down(sender As Object, e As EventArgs) Handles Button24.MouseDown
        Try
            tcClient.WriteAny(Przewod_17_In_WIZ, True)
            Button24.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub Przewod17_UP(sender As Object, e As EventArgs) Handles Button24.MouseUp
        Try
            tcClient.WriteAny(Przewod_17_In_WIZ, False)
            Button24.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub Przewod18_Down(sender As Object, e As EventArgs) Handles Button25.MouseDown
        Try
            tcClient.WriteAny(Przewod_18_In_WIZ, True)
            Button25.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub Przewod18_UP(sender As Object, e As EventArgs) Handles Button25.MouseUp
        Try
            tcClient.WriteAny(Przewod_18_In_WIZ, False)
            Button25.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub Przewod19_Down(sender As Object, e As EventArgs) Handles Button26.MouseDown
        Try
            tcClient.WriteAny(Przewod_19_In_WIZ, True)
            Button26.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub Przewod19_UP(sender As Object, e As EventArgs) Handles Button26.MouseUp
        Try
            tcClient.WriteAny(Przewod_19_In_WIZ, False)
            Button26.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub Przewod20_Down(sender As Object, e As EventArgs) Handles Button27.MouseDown
        Try
            tcClient.WriteAny(Przewod_20_In_WIZ, True)
            Button27.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub Przewod20_UP(sender As Object, e As EventArgs) Handles Button27.MouseUp
        Try
            tcClient.WriteAny(Przewod_20_In_WIZ, False)
            Button27.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub Przewod21_Down(sender As Object, e As EventArgs) Handles Button28.MouseDown
        Try
            tcClient.WriteAny(Przewod_21_In_WIZ, True)
            Button28.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub Przewod21_UP(sender As Object, e As EventArgs) Handles Button28.MouseUp
        Try
            tcClient.WriteAny(Przewod_21_In_WIZ, False)
            Button28.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub Przewod22_Down(sender As Object, e As EventArgs) Handles Button29.MouseDown
        Try
            tcClient.WriteAny(Przewod_22_In_WIZ, True)
            Button29.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub Przewod22_UP(sender As Object, e As EventArgs) Handles Button29.MouseUp
        Try
            tcClient.WriteAny(Przewod_22_In_WIZ, False)
            Button29.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub Przewod23_Down(sender As Object, e As EventArgs) Handles Button30.MouseDown
        Try
            tcClient.WriteAny(Przewod_23_In_WIZ, True)
            Button30.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub Przewod23_UP(sender As Object, e As EventArgs) Handles Button30.MouseUp
        Try
            tcClient.WriteAny(Przewod_23_In_WIZ, False)
            Button30.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub Przewod14_Down(sender As Object, e As EventArgs) Handles Button31.MouseDown
        Try
            tcClient.WriteAny(Przewod_24_In_WIZ, True)
            Button31.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub Przewod24_UP(sender As Object, e As EventArgs) Handles Button31.MouseUp
        Try
            tcClient.WriteAny(Przewod_24_In_WIZ, False)
            Button31.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub Przewod25_Down(sender As Object, e As EventArgs) Handles Button32.MouseDown
        Try
            tcClient.WriteAny(Przewod_25_In_WIZ, True)
            Button32.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub Przewod25_UP(sender As Object, e As EventArgs) Handles Button32.MouseUp
        Try
            tcClient.WriteAny(Przewod_25_In_WIZ, False)
            Button32.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

End Class