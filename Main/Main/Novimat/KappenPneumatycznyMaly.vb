Imports TwinCAT.Ads
Imports System.IO

Public Class KappenPneumatycznyMaly
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
    Private iMaxValues As Integer = 3
    Private aPicBoxes(0 To iMaxValues) As PictureBox
    Private binReader As System.IO.BinaryReader

    Private Zmienna1_Not As Integer
    Private Zmienna2_Not As Integer
    Private Zmienna3_Not As Integer
    Private Zmienna4_Not As Integer
    Private Zmienna5_Not As Integer
    Private Zmienna6_Not As Integer
    Private Zmienna7_Not As Integer

    Private Zmienna1_Write As Integer
    Private Zmienna2_Write As Integer
    Private Zmienna3_Write As Integer
    Private Zmienna4_Write As Integer
    Private Zmienna5_Write As Integer
    Private Zmienna6_Write As Integer
    Private Zmienna7_Write As Integer

    Public Sub KappenPneumatycznyMaly_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        aPicBoxes(1) = PictureBox1
        aPicBoxes(2) = PictureBox2
        aPicBoxes(3) = PictureBox3
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click

        If bIsReading Then
            Try
                tcClient.Dispose()
            Catch err As Exception
                MessageBox.Show(err.Message)
            End Try

            PictureBox1.Image = My.Resources.Image3
            PictureBox2.Image = My.Resources.Image3
            PictureBox3.Image = My.Resources.Image3

            Button20.Text = "Online"
            Button20.BackColor = Color.Red
            bIsReading = False

        Else
            Dim dataStream As New AdsStream(31)
            binRead = New BinaryReader(dataStream, System.Text.Encoding.ASCII)
            tcClient = New TwinCAT.Ads.TcAdsClient()
            tcClient.Connect(801)

            ReDim hConnect(3)
            Try
                Zmienna1_Not = tcClient.AddDeviceNotification(".bQPF1KappenVKWink2", dataStream, 0, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Zmienna1_Write = tcClient.CreateVariableHandle(".bQPF1KappenVKWink2")

                Zmienna2_Not = tcClient.AddDeviceNotification(".bQPF1KappenHKWink2", dataStream, 1, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Zmienna2_Write = tcClient.CreateVariableHandle(".bQPF1KappenHKWink2")

                Zmienna3_Not = tcClient.AddDeviceNotification(".bQPF1KappenHKAusfSaege", dataStream, 2, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Zmienna3_Write = tcClient.CreateVariableHandle(".bQPF1KappenHKAusfSaege")

                Zmienna4_Not = tcClient.AddDeviceNotification(".bQPF1KappenVKStart", dataStream, 3, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Zmienna4_Write = tcClient.CreateVariableHandle(".bQPF1KappenVKStart")

                Zmienna5_Not = tcClient.AddDeviceNotification(".bQPF1KappenHKStart", dataStream, 4, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Zmienna5_Write = tcClient.CreateVariableHandle(".bQPF1KappenHKStart")

                Zmienna6_Not = tcClient.AddDeviceNotification(".bQPF1KappenVKBeschl", dataStream, 5, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Zmienna6_Write = tcClient.CreateVariableHandle(".bQPF1KappenVKBeschl")

                Zmienna7_Not = tcClient.AddDeviceNotification(".bQPF1KappenVKVorbeschl", dataStream, 6, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Zmienna7_Write = tcClient.CreateVariableHandle(".bQPF1KappenVKVorbeschl")

                hConnect(1) = tcClient.AddDeviceNotification(checkVariable(MaskedTextBox1.Text.ToString, MaskedTextBox1), dataStream, 7, 1, AdsTransMode.OnChange, 100, 0, Nothing)
                hConnect(2) = tcClient.AddDeviceNotification(checkVariable(MaskedTextBox2.Text.ToString, MaskedTextBox2), dataStream, 8, 1, AdsTransMode.OnChange, 100, 0, Nothing)
                hConnect(3) = tcClient.AddDeviceNotification(checkVariable(MaskedTextBox3.Text.ToString, MaskedTextBox3), dataStream, 9, 1, AdsTransMode.OnChange, 100, 0, Nothing)

                AddHandler tcClient.AdsNotification, AddressOf OnNotification
                Button20.Text = "STOP"
                Button20.BackColor = Color.LightGreen
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
    ' Zmienna 1
    Private Sub Button4_OnClick(sender As Object, e As EventArgs) Handles Button4.MouseDown
        Try
            tcClient.WriteAny(Zmienna1_Write, True)
            Button4.BackColor = Color.Green
            Button5.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub Button5_OffClick(sender As Object, e As EventArgs) Handles Button5.MouseUp
        Try
            tcClient.WriteAny(Zmienna1_Write, False)
            Button5.BackColor = Color.Red
            Button4.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    ' Zmienna 2
    Private Sub Button8_OnClick(sender As Object, e As EventArgs) Handles Button8.Click
        Try
            tcClient.WriteAny(Zmienna2_Write, True)
            Button8.BackColor = Color.Green
            Button9.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub Button8_OffClick(sender As Object, e As EventArgs) Handles Button9.Click
        Try
            tcClient.WriteAny(Zmienna2_Write, False)
            Button9.BackColor = Color.Red
            Button8.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    ' Zmienna 3
    Private Sub Button10_OnClick(sender As Object, e As EventArgs) Handles Button10.Click
        Try
            tcClient.WriteAny(Zmienna3_Write, True)
            Button10.BackColor = Color.Green
            Button11.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub Button11_OffClick(sender As Object, e As EventArgs) Handles Button11.Click
        Try
            tcClient.WriteAny(Zmienna3_Write, False)
            Button11.BackColor = Color.Red
            Button10.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    ' Zmienna 4
    Private Sub Button12_OnClick(sender As Object, e As EventArgs) Handles Button12.Click
        Try
            tcClient.WriteAny(Zmienna4_Write, True)
            Button12.BackColor = Color.Green
            Button13.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub Button13_OffClick(sender As Object, e As EventArgs) Handles Button13.Click
        Try
            tcClient.WriteAny(Zmienna4_Write, False)
            Button13.BackColor = Color.Red
            Button12.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    ' Zmienna 5
    Private Sub Button14_OnClick(sender As Object, e As EventArgs) Handles Button14.Click
        Try
            tcClient.WriteAny(Zmienna5_Write, True)
            Button14.BackColor = Color.Green
            Button15.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub Button15_OffClick(sender As Object, e As EventArgs) Handles Button15.Click
        Try
            tcClient.WriteAny(Zmienna5_Write, False)
            Button15.BackColor = Color.Red
            Button14.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    ' Zmienna 6
    Private Sub Button16_OnClick(sender As Object, e As EventArgs) Handles Button16.Click
        Try
            tcClient.WriteAny(Zmienna6_Write, True)
            Button16.BackColor = Color.Green
            Button17.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub Button17_OffClick(sender As Object, e As EventArgs) Handles Button17.Click
        Try
            tcClient.WriteAny(Zmienna6_Write, False)
            Button17.BackColor = Color.Red
            Button16.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    ' Zmienna 7
    Private Sub Button18_OnClick(sender As Object, e As EventArgs) Handles Button18.Click
        Try
            tcClient.WriteAny(Zmienna7_Write, True)
            Button18.BackColor = Color.Green
            Button19.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
    Private Sub Button19_OffClick(sender As Object, e As EventArgs) Handles Button19.Click
        Try
            tcClient.WriteAny(Zmienna7_Write, False)
            Button19.BackColor = Color.Red
            Button18.BackColor = Color.White
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub


    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Agregaty_Menu.Show()
        Me.Close()
    End Sub

End Class