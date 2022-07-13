Imports TwinCAT.Ads
Imports System.IO

Public Class Frez_08055

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

    Private Zmienna1_Write As Integer
    Private Zmienna2_Write As Integer
    Private Zmienna3_Write As Integer
    Private Zmienna4_Write As Integer

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click

        If bIsReading Then
            Try
                tcClient.Dispose()
            Catch err As Exception
                MessageBox.Show(err.Message)
            End Try

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
                Zmienna1_Not = tcClient.AddDeviceNotification(".bQPF2FraesenY", dataStream, 0, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Zmienna1_Write = tcClient.CreateVariableHandle(".bQPF2FraesenY")

                Zmienna2_Not = tcClient.AddDeviceNotification(".bQPF2FraesenUntFPZ", dataStream, 1, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Zmienna2_Write = tcClient.CreateVariableHandle(".bQPF2FraesenUntFPZ")

                Zmienna3_Not = tcClient.AddDeviceNotification(".bQPF2FraesenObFPZ", dataStream, 2, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Zmienna3_Write = tcClient.CreateVariableHandle(".bQPF2FraesenObFPZ")

                Zmienna4_Not = tcClient.AddDeviceNotification(".bQPF2FestpunktVerstell", dataStream, 3, 1, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Zmienna4_Write = tcClient.CreateVariableHandle(".bQPF2FestpunktVerstell")

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

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Agregaty_Menu.Show()
        Me.Close()
    End Sub

End Class
