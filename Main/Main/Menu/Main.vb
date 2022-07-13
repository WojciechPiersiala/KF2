Imports System.IO
Imports TwinCAT.Ads
Imports System.Deployment.Application

''' <summary>
''' Okno glownego menu
''' </summary>
Public Class Agregaty_Me
Public Class Main

    Public poziomdostepu As Boolean     'uzywane w Novimat
    Private version As String           'aktualna wersja programu 

    ''' <summary>
    '''Pokaz dostepne opcje w polu wyboru
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load  'counstructor
        Log_Out.Visible = False
        ComboBox1.Items.Add("KFA")
        ComboBox1.Items.Add("Novimat")
        ComboBox1.Items.Add("Przewody")
        ComboBox1.Items.Add("Tischauflage")
        ComboBox1.Items.Add("Admin")
        TextBox1.Visible = False

        If (ApplicationDeployment.IsNetworkDeployed) Then                                 'nowa wersia 
            Dim AD As ApplicationDeployment = ApplicationDeployment.CurrentDeployment     'wyswietl informacje o obecnej wersji
            Label1.Text = "v " & AD.CurrentVersion.ToString
        Else

            Label1.Text = "v " & My.Application.Info.Version.ToString
        End If

    End Sub
    'zaloguj sie w trybie admina
    Private Sub adminhaslo(sender As Object, e As EventArgs) Handles ComboBox1.SelectedValueChanged 'Textbox zeby wpisac haslo
        If ComboBox1.SelectedItem Is "Admin" Then
            TextBox1.Visible = True
        Else
            TextBox1.Visible = False
        End If
    End Sub
    
    ''' <summary>
    '''Przyciski aktywacji kolejnych oken
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button_Click(sender As Object, e As EventArgs) Handles Button1.Click, Button3.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button8.Click, Button9.Click, Button10.Click
        If sender.Equals(Button1) Then
            Application.Exit()   'wylacz aplikacje
        ElseIf sender.Equals(Button2) Then
            Me.WindowState = FormWindowState.Minimized   'minimalizowanie
        ElseIf sender.Equals(Button3) Then
            KFA_Main.Show()                              'KFA
        ElseIf sender.Equals(Button4) Then
            Dane_Edycja.Show()                           'Raporty KFA
        ElseIf sender.Equals(Button5) Then
            tisch.Show()                                 'Tischauflage
        ElseIf sender.Equals(Button6) Then
            Przewody_10749697.Show()                     'Przewody
        ElseIf sender.Equals(Button7) Then
            Przewody_10749699.Show()                     'Przewody
        ElseIf sender.Equals(Button8) Then
            Przewody_10749698.Show()                     'Przewody
            'ElseIf sender.Equals(Button10) Then         'symphonia nie ma
        ElseIf sender.Equals(Button10) Then
            Novimat_Menu.Show()                           'Otworz menu Novimat
        End If
    End Sub

    Public Sub Log_In_Click(sender As Object, e As EventArgs) Handles Log_In.Click
        If ComboBox1.SelectedItem IsNot "Novimat" Then
            Dim a As String = "C:\IMA\IcosOpen\Stanowisko do testow\Program do wizualizacji\log.txt"   'wpisz historie to logow
            If File.Exists(a) Then
                My.Computer.FileSystem.WriteAllText(a, " " & vbCrLf, True)
                My.Computer.FileSystem.WriteAllText(a, ComboBox1.SelectedItem, True)
                My.Computer.FileSystem.WriteAllText(a, " ", True)
                My.Computer.FileSystem.WriteAllText(a, DateAndTime.Today, True)
                My.Computer.FileSystem.WriteAllText(a, " ", True)
                My.Computer.FileSystem.WriteAllText(a, TimeString, True)
            End If
        End If

        If ComboBox1.SelectedItem Is "Admin" Then                                            'uprawnienia admina (dostep do wszystkiego)
            If TextBox1.Text = "1234" Then
                Call SwapButtons()          ' zamien przycisk zaloguj na wylogoj
                poziomdostepu = True

                Button3.Visible = True      ' wybierz czesc przyciskow
                Button4.Visible = True
                Button5.Visible = True
                Button6.Visible = True
                Button5.Visible = True
                Button6.Visible = True
                Button7.Visible = True
                Button8.Visible = True
                Button9.Visible = True
                Button10.Visible = True
            End If

        ElseIf ComboBox1.SelectedItem Is "KFA" Then
            Call SwapButtons()
            poziomdostepu = False

            Button3.Visible = True
            Button4.Visible = True
            Button5.Visible = False
            Button6.Visible = False
            Button5.Visible = False
            Button6.Visible = False
            Button7.Visible = False
            Button8.Visible = False
            Button9.Visible = False
            Button10.Visible = False

        ElseIf ComboBox1.SelectedItem Is "Novimat" Then
            Call SwapButtons()
            poziomdostepu = False

            Button3.Visible = False
            Button4.Visible = False
            Button5.Visible = False
            Button6.Visible = False
            Button5.Visible = False
            Button6.Visible = False
            Button7.Visible = False
            Button8.Visible = False
            Button9.Visible = False
            Button10.Visible = True

            ' Zamykanie niepotrzebnych okienek i otwieranie nowego menu

            Me.WindowState = FormWindowState.Minimized
            Novimat_Menu.Show()                                'otworz nowe menu
            OknoStart.WindowState = FormWindowState.Minimized

        ElseIf ComboBox1.SelectedItem Is "Przewody" Then
            Call SwapButtons()
            poziomdostepu = False

            Button3.Visible = False
            Button4.Visible = False
            Button5.Visible = False
            Button6.Visible = False
            Button5.Visible = False
            Button6.Visible = True
            Button7.Visible = True
            Button8.Visible = True
            Button9.Visible = False
            Button10.Visible = False

        ElseIf ComboBox1.SelectedItem Is "Tischauflage" Then
            Call SwapButtons()
            poziomdostepu = False

            Button3.Visible = False
            Button4.Visible = False
            Button5.Visible = False
            Button6.Visible = False
            Button5.Visible = True
            Button6.Visible = False
            Button7.Visible = False
            Button8.Visible = False
            Button9.Visible = True
            Button10.Visible = False

        Else
            MessageBox.Show(" :( ")            'Haslo niepoprawne
        End If
    End Sub
    Private Sub Log_Out_Click(sender As Object, e As EventArgs) Handles Log_Out.Click           'wyloguj sie, powrot do poprzedniego okna
        PictureBox1.Visible = True
        Log_In.Visible = True
        Log_Out.Visible = False
        ComboBox1.Visible = True
        TextBox1.Visible = False
        TextBox1.Text = ""
        poziomdostepu = False
    End Sub

    Private Sub SwapButtons()             'Zamien przyciski zaloguj i wyloguj
        PictureBox1.Visible = False
        Log_In.Visible = False
        Log_Out.Visible = True
        Log_Out.Location = New Point(428, 316)
        ComboBox1.Visible = False
        TextBox1.Visible = False
    End Sub
End Class