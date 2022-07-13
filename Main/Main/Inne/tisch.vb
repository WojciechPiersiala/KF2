Imports TwinCAT.Ads
Imports System.IO

Public Class tisch
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close() 'zamknij
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Minimized 'minimalizuj
    End Sub

    Private tcClient As TcAdsClient 'Klient ADS / Obiekt komunikacyjny ADS.
    Private hConnect() As Integer   'uchwyt obslugi polaczenia
    Private dataStream As AdsStream 'udestepnia dostep do podstawowego strumienia BinaryReader 
    Private binRead As BinaryReader 'odczytuje zarówno podstawowe typy danych, jak i typy danych PLC jako wartości binarne.
    Private bIsReading As Boolean = False 'flaga procesu
    Private bHasRead As Boolean = False   'powiadomienie o ukonczeniu pobierania
    Private iMaxValues As Integer = 4
    Private aPicBoxes(0 To iMaxValues) As PictureBox 'ikonki
    Private binReader As System.IO.BinaryReader

    Private hSwitchNotify1 As Integer 'uchwyty powiadomienia przelaczenia
    Private hSwitchNotify2 As Integer
    Private hSwitchNotify3 As Integer
    Private hSwitchNotify4 As Integer
    Private hSwitchNotify5 As Integer

    Private Y38 As Integer    'Zmienne w PLC
    Private X32 As Integer
    Private X31_1 As Integer
    Private X32_1 As Integer
    Private X31_1a As Integer



    ''' <summary>
    ''' Placz sie z PLC (przycisk dziala jak SR)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Public Sub Przewody_8_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'deklaracja ikonek
        aPicBoxes(1) = PictureBox1
        aPicBoxes(2) = PictureBox3
        aPicBoxes(3) = PictureBox5
        aPicBoxes(4) = PictureBox7

        If bIsReading Then   'jezeli dane sa zczytywane
            Try
                tcClient.Dispose() 'zakoncz polaczenie
            Catch err As Exception
                MessageBox.Show(err.Message)
            End Try

            'zaladuj ikonki
            PictureBox1.Image = My.Resources.Image3
            PictureBox3.Image = My.Resources.Image3
            PictureBox5.Image = My.Resources.Image3
            PictureBox7.Image = My.Resources.Image3

            Button3.Text = "Online"
            Button3.BackColor = Color.LightGreen
            bIsReading = False

        Else
            Dim dataStream As New AdsStream(31) 'Inicjuje nowe wystąpienie klasy AdsStream. Instancja ma pojemność rozszerzalną zainicjowaną na zero, Udostępnia dostęp do podstawowego strumienia BinaryReader.
            binRead = New BinaryReader(dataStream, System.Text.Encoding.ASCII)
            tcClient = New TwinCAT.Ads.TcAdsClient() 'Nawiązuje połączenie z urządzeniem ADS.
            tcClient.Connect(801)

            ReDim hConnect(4)

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

                'Łączy zmienną z klientem ADS. Klient ADS zostanie powiadomiony o zdarzeniu AdsNotification.'''
                hSwitchNotify1 = tcClient.AddDeviceNotification(".V38", dataStream, 26, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value) 'Łączy zmienną z klientem ADS. Klient ADS zostanie powiadomiony o zdarzeniu AdsNotification.'''
                Y38 = tcClient.CreateVariableHandle(".V38") 'Generuje unikalny uchwyt dla zmiennej ADS.

                hSwitchNotify2 = tcClient.AddDeviceNotification(".X32", dataStream, 27, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                X32 = tcClient.CreateVariableHandle(".X32")

                hSwitchNotify3 = tcClient.AddDeviceNotification(".X31_1", dataStream, 27, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                X31_1 = tcClient.CreateVariableHandle(".X31_1")

                hSwitchNotify4 = tcClient.AddDeviceNotification(".X32_1", dataStream, 27, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                X32_1 = tcClient.CreateVariableHandle(".X32_1")

                hSwitchNotify5 = tcClient.AddDeviceNotification(".X31_1a", dataStream, 27, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                X31_1a = tcClient.CreateVariableHandle(".X31_1a")


                AddHandler tcClient.AdsNotification, AddressOf OnNotification  'Przydziel obsluge zdarzenia  tcClient.AdsNotification do funkcji OnNotification
                Button3.Text = "Offline"
                Button3.BackColor = Color.Red
                bHasRead = True
                bIsReading = True

            Catch err As Exception
                MessageBox.Show(err.Message)
            End Try
        End If
    End Sub

    ''' <summary>
    ''' Obsluga zdarzenia wywolane przez wykonanie polaczenia z PLC. ( wizualne potwierdzenie rozpoczecia procesu )
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Public Sub OnNotification(ByVal sender As Object, ByVal e As AdsNotificationEventArgs)
        Try
            e.DataStream.Position = e.Offset

            Dim strValue As String = ""
            Dim i As Integer
            For i = 1 To iMaxValues
                If (e.NotificationHandle = hConnect(i)) Then
                    If binRead.ReadBoolean() Then
                        aPicBoxes(i).Image = My.Resources.Image2   'zmien ikonke w zaleznosci od statusu procesu
                    Else
                        aPicBoxes(i).Image = My.Resources.Image1
                    End If
                End If
            Next i

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Sprawdz zmienna, 
    ''' </summary>
    ''' <param name="sString"></param>
    ''' <param name="mtb"></param>
    ''' <returns></returns>
    Private Function checkVariable(sString As String, mtb As MaskedTextBox) As String
        Dim stelle As Integer
        stelle = InStr(sString, ".") ' pozycja "." w nazwie zmiennej
        Debug.Print("Stelle: " & stelle)
        If stelle <> 1 Then
            sString = "." & sString
            mtb.Text = sString
        End If
        checkVariable = sString
    End Function

    ''' <summary>
    ''' publikacja danych do PLC, w zaleznosci od przycisku, wyslij odpowiednie dane, modyfikacja zmiennej w PLC. 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Przewod1_Down(sender As Object, e As EventArgs) Handles Button8.MouseDown
        Try
            tcClient.WriteAny(Y38, True)
            Button8.BackColor = Color.Green
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub Przewod1_UP(sender As Object, e As EventArgs) Handles Button8.MouseUp
        Try
            tcClient.WriteAny(Y38, False)
            Button8.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub Przewod2_Down(sender As Object, e As EventArgs) Handles Button9.MouseDown
        Try
            tcClient.WriteAny(X32, True)
            Button9.BackColor = Color.Green
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub Przewod2_UP(sender As Object, e As EventArgs) Handles Button9.MouseUp
        Try
            tcClient.WriteAny(X32, False)
            Button9.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub Przewod3_Down(sender As Object, e As EventArgs) Handles Button10.MouseDown
        Try
            tcClient.WriteAny(X31_1, True)
            Button10.BackColor = Color.Green
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub Przewod3_UP(sender As Object, e As EventArgs) Handles Button10.MouseUp
        Try
            tcClient.WriteAny(X31_1, False)
            Button10.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub Przewod4_Down(sender As Object, e As EventArgs) Handles Button11.MouseDown
        Try
            tcClient.WriteAny(X32_1, True)
            Button11.BackColor = Color.Green
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub Przewod4_UP(sender As Object, e As EventArgs) Handles Button11.MouseUp
        Try
            tcClient.WriteAny(X32_1, False)
            Button11.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub Przewod5_Down(sender As Object, e As EventArgs) Handles Button12.MouseDown
        Try
            tcClient.WriteAny(X31_1a, True)
            Button12.BackColor = Color.Green
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub Przewod5_UP(sender As Object, e As EventArgs) Handles Button12.MouseUp
        Try
            tcClient.WriteAny(X31_1a, False)
            Button12.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

End Class