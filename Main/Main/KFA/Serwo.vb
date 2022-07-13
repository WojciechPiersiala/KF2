Imports TwinCAT.Ads
Imports System.IO

Public Class Serwo


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
    Private iMaxValues As Integer = 10
    Private aPicBoxes(0 To iMaxValues) As PictureBox
    Private binReader As System.IO.BinaryReader
    Private hCount As Integer

    Private X1_Lewo_Notify As Integer
    Private X1_Lewo_Write As Integer
    Private X2_Lewo_Notify As Integer
    Private X2_Lewo_Write As Integer
    Private X3_Lewo_Notify As Integer
    Private X3_Lewo_Write As Integer
    Private X1_X2_Lewo_Notify As Integer
    Private X1_X2_Lewo_Write As Integer

    Private X1_Prawo_Notify As Integer
    Private X1_Prawo_Write As Integer
    Private X2_Prawo_Notify As Integer
    Private X2_Prawo_Write As Integer
    Private X3_Prawo_Notify As Integer
    Private X3_Prawo_Write As Integer
    Private X1_X2_Prawo_Notify As Integer
    Private X1_X2_Prawo_Write As Integer

    Private Serwo_Enable_Notify As Integer
    Private Serwo_Enable_Write As Integer

    Private Automat_Notify As Integer
    Private Automat_Write As Integer
    Private AutomatOFF_Notify As Integer
    Private AutomatOFF_Write As Integer

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


        Else
            Dim dataStream As New AdsStream(31)
            binRead = New BinaryReader(dataStream, System.Text.Encoding.ASCII)
            tcClient = New TwinCAT.Ads.TcAdsClient()
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

                X1_Lewo_Notify = tcClient.AddDeviceNotification(".Input_X1_Lewo", dataStream, 10, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                X1_Lewo_Write = tcClient.CreateVariableHandle(".Input_X1_Lewo")
                X2_Lewo_Notify = tcClient.AddDeviceNotification(".Input_X2_Lewo", dataStream, 11, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                X2_Lewo_Write = tcClient.CreateVariableHandle(".Input_X2_Lewo")
                X3_Lewo_Notify = tcClient.AddDeviceNotification(".Input_X3_Lewo", dataStream, 12, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                X3_Lewo_Write = tcClient.CreateVariableHandle(".Input_X3_Lewo")
                X1_X2_Lewo_Notify = tcClient.AddDeviceNotification(".Input_X1_X2_Lewo", dataStream, 13, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                X1_X2_Lewo_Write = tcClient.CreateVariableHandle(".Input_X1_X2_Lewo")

                X1_Prawo_Notify = tcClient.AddDeviceNotification(".Input_X1_Prawo", dataStream, 14, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                X1_Prawo_Write = tcClient.CreateVariableHandle(".Input_X1_Prawo")
                X2_Prawo_Notify = tcClient.AddDeviceNotification(".Input_X2_Prawo", dataStream, 15, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                X2_Prawo_Write = tcClient.CreateVariableHandle(".Input_X2_Prawo")
                X3_Prawo_Notify = tcClient.AddDeviceNotification(".Input_X3_Prawo", dataStream, 16, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                X3_Prawo_Write = tcClient.CreateVariableHandle(".Input_X3_Prawo")
                X1_X2_Prawo_Notify = tcClient.AddDeviceNotification(".Input_X1_X2_prawo", dataStream, 17, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                X1_X2_Prawo_Write = tcClient.CreateVariableHandle(".Input_X1_X2_prawo")

                Automat_Notify = tcClient.AddDeviceNotification(".Rysuj_przycisk_vis", dataStream, 18, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Automat_Write = tcClient.CreateVariableHandle(".Rysuj_przycisk_vis")

                AutomatOFF_Notify = tcClient.AddDeviceNotification(".Serwo_Enable_Automat_Przycisk", dataStream, 19, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                AutomatOFF_Write = tcClient.CreateVariableHandle(".Serwo_Enable_Automat_Przycisk")

                Serwo_Enable_Notify = tcClient.AddDeviceNotification(".Serwo_Enable_Przycisk", dataStream, 20, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Serwo_Enable_Write = tcClient.CreateVariableHandle(".Serwo_Enable_Przycisk")

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


    Private Sub X1_Lewo_Click_Down(sender As Object, e As EventArgs) Handles X1_Lewo.MouseDown
        Try
            tcClient.WriteAny(X1_Lewo_Write, True)
            X1_Lewo.BackColor = Color.Green
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub X1_Lewo_Click_Up(sender As Object, e As EventArgs) Handles X1_Lewo.MouseUp
        Try
            tcClient.WriteAny(X1_Lewo_Write, False)
            X1_Lewo.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub X2_Lewo_Click_Down(sender As Object, e As EventArgs) Handles X2_Lewo.MouseDown
        Try
            tcClient.WriteAny(X2_Lewo_Write, True)
            X2_Lewo.BackColor = Color.Green
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub X2_Lewo_Click_Up(sender As Object, e As EventArgs) Handles X2_Lewo.MouseUp
        Try
            tcClient.WriteAny(X2_Lewo_Write, False)
            X2_Lewo.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub X3_Lewo_Click_Down(sender As Object, e As EventArgs) Handles X3_Lewo.MouseDown
        Try
            tcClient.WriteAny(X3_Lewo_Write, True)
            X3_Lewo.BackColor = Color.Green
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub X3_Lewo_Click_Up(sender As Object, e As EventArgs) Handles X3_Lewo.MouseUp
        Try
            tcClient.WriteAny(X3_Lewo_Write, False)
            X3_Lewo.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub X1_X2_Lewo_Click_Down(sender As Object, e As EventArgs) Handles X1_X2_Lewo.MouseDown
        Try
            tcClient.WriteAny(X1_X2_Lewo_Write, True)
            X1_X2_Lewo.BackColor = Color.Green
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub X1_X2_Lewo_Click_Up(sender As Object, e As EventArgs) Handles X1_X2_Lewo.MouseUp
        Try
            tcClient.WriteAny(X1_X2_Lewo_Write, False)
            X1_X2_Lewo.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub X1_Prawo_Click_Down(sender As Object, e As EventArgs) Handles X1_Prawo.MouseDown
        Try
            tcClient.WriteAny(X1_Prawo_Write, True)
            X1_Prawo.BackColor = Color.Green
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub X1_Prawo_Click_Up(sender As Object, e As EventArgs) Handles X1_Prawo.MouseUp
        Try
            tcClient.WriteAny(X1_Prawo_Write, False)
            X1_Prawo.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub X2_Prawo_Click_Down(sender As Object, e As EventArgs) Handles X2_Prawo.MouseDown
        Try
            tcClient.WriteAny(X2_Prawo_Write, True)
            X2_Prawo.BackColor = Color.Green
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub X2_Prawo_Click_Up(sender As Object, e As EventArgs) Handles X2_Prawo.MouseUp
        Try
            tcClient.WriteAny(X2_Prawo_Write, False)
            X2_Prawo.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub X3_Prawo_Click_Down(sender As Object, e As EventArgs) Handles X3_Prawo.MouseDown
        Try
            tcClient.WriteAny(X3_Prawo_Write, True)
            X3_Prawo.BackColor = Color.Green
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub X3_Prawo_Click_Up(sender As Object, e As EventArgs) Handles X3_Prawo.MouseUp
        Try
            tcClient.WriteAny(X3_Prawo_Write, False)
            X3_Prawo.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub X1_X2_Prawo_Click_Down(sender As Object, e As EventArgs) Handles X1_X2_Prawo.MouseDown
        Try
            tcClient.WriteAny(X1_X2_Prawo_Write, True)
            X1_X2_Prawo.BackColor = Color.Green
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub X1_X2_Prawo_Click_Up(sender As Object, e As EventArgs) Handles X1_X2_Prawo.MouseUp
        Try
            tcClient.WriteAny(X1_X2_Prawo_Write, False)
            X1_X2_Prawo.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub Automat_Click_Down(sender As Object, e As EventArgs) Handles Automat.MouseDown
        Try
            tcClient.WriteAny(Automat_Write, True)
            Automat.BackColor = Color.Green
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub Automat_Click_Up(sender As Object, e As EventArgs) Handles Automat.MouseUp
        Try
            tcClient.WriteAny(Automat_Write, False)
            Automat.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub AutomatOFF_Click_Down(sender As Object, e As EventArgs) Handles AutomatOFF.MouseDown
        Try
            tcClient.WriteAny(AutomatOFF_Write, True)
            AutomatOFF.BackColor = Color.Green
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub AutomatOFF_Click_Up(sender As Object, e As EventArgs) Handles AutomatOFF.MouseUp
        Try
            tcClient.WriteAny(AutomatOFF_Write, False)
            AutomatOFF.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub



    Private Sub Serwo_Enable_Click_Down(sender As Object, e As EventArgs) Handles Serwo_Enable.MouseDown
        Try
            tcClient.WriteAny(Serwo_Enable_Write, True)
            AutomatOFF.BackColor = Color.Green
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub Serwo_Enable_Click_Up(sender As Object, e As EventArgs) Handles Serwo_Enable.MouseUp
        Try
            tcClient.WriteAny(Serwo_Enable_Write, False)
            AutomatOFF.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub




    Private Sub Automat_Click_Down(sender As Object, e As MouseEventArgs) Handles Automat.MouseDown

    End Sub
    Private Sub Automat_Click_Up(sender As Object, e As MouseEventArgs) Handles Automat.MouseUp

    End Sub
    Private Sub AutomatOFF_Click_Down(sender As Object, e As MouseEventArgs) Handles AutomatOFF.MouseDown

    End Sub
    Private Sub AutomatOFF_Click_Up(sender As Object, e As MouseEventArgs) Handles AutomatOFF.MouseUp

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Raport.Show()
        Me.Close()
    End Sub
End Class