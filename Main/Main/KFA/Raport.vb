Imports TwinCAT.Ads
Imports System.IO
Imports System.Data
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Data.OleDb


Public Class Raport

    Dim conn As OleDbConnection
    Dim da As OleDbDataAdapter
    Dim ds As New DataSet
    Dim cmd As OleDbCommand

    Dim regDate As Date = Date.Now()
    Dim strDate As String = regDate.ToString("dd.MM.yyyy")

    Private tcClient As TcAdsClient
    Private hConnect() As Integer
    Private dataStream As AdsStream
    Private binRead As BinaryReader
    Private bIsReading As Boolean = False
    Private bHasRead As Boolean = False
    Private iMaxValues As Integer = 4
    Private aPicBoxes(0 To iMaxValues) As PictureBox
    Private zmienna(0 To iMaxValues) As String

    Private binReader As System.IO.BinaryReader
    Private hCount As Integer

    Public Z_Punkt_Ref_M31 As Double
    Public Z_Roznica1_M31 As Double
    Public Z_null_max_M31 As Double
    Public Z_null_min_31 As Double
    Public Z_lrActual_Position_M31 As Double
    Public Z_PozycjaMaxM31 As Double
    Public Z_PozycjaMinM31 As Double

    Public R_Punkt_Ref_M31 As String = "-"
    Public R_Roznica1_M31 As String = "-"
    Public R_null_max_M31 As String = "-"
    Public R_null_min_31 As String = "-"
    Public R_lrActual_Position_M31 As String = "-"
    Public R_PozycjaMaxM31 As String = "-"
    Public R_PozycjaMinM31 As String = "-"

    Public Z_Punkt_Ref_M41 As Double
    Public Z_Roznica1_M41 As Double
    Public Z_null_max_M41 As Double
    Public Z_null_min_41 As Double
    Public Z_lrActual_Position_M41 As Double
    Public Z_PozycjaMaxM41 As Double
    Public Z_PozycjaMinM41 As Double

    Public R_Punkt_Ref_M41 As String = "-"
    Public R_Roznica1_M41 As String = "-"
    Public R_null_max_M41 As String = "-"
    Public R_null_min_41 As String = "-"
    Public R_lrActual_Position_M41 As String = "-"
    Public R_PozycjaMaxM41 As String = "-"
    Public R_PozycjaMinM41 As String = "-"


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Public Sub Raport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        zmienna(1) = "Blad"
        zmienna(2) = "Blad"
        zmienna(3) = "Blad"
        zmienna(4) = "Blad"

        DataGridView1.Columns.Add("col1", "nr")
        DataGridView1.Columns.Add("col2", "Data")
        DataGridView1.Columns.Add("col3", "Nazwisko")
        DataGridView1.Columns.Add("col4", "Agregat")
        DataGridView1.Columns.Add("col5", "Wynik Serwo")
        DataGridView1.Columns.Add("col6", "Wynik Czujniki")
        DataGridView1.Columns.Add("col7", "Uwagi")

        DataGridView1.Columns.Add("col8", "Ref M31")
        DataGridView1.Columns.Add("col9", "Roznica M31")
        '  DataGridView1.Columns.Add("col10", "null max M31")
        '  DataGridView1.Columns.Add("col11", "null min M31")
        DataGridView1.Columns.Add("col12", "poz max M31")
        DataGridView1.Columns.Add("col13", "poz min M31")
        ' DataGridView1.Columns.Add("col14", "roznica M31 ok")

        DataGridView1.Columns.Add("col15", "Ref M41")
        DataGridView1.Columns.Add("col16", "Roznica M41")
        '  DataGridView1.Columns.Add("col17", "null max M41")
        '  DataGridView1.Columns.Add("col18", "null min M41")
        DataGridView1.Columns.Add("col19", "poz max M41")
        DataGridView1.Columns.Add("col20", "poz min M41")
        '   DataGridView1.Columns.Add("col21", "roznica M41 ok")

        DataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False

        aPicBoxes(1) = PictureBox1
        aPicBoxes(2) = PictureBox2
        aPicBoxes(3) = PictureBox3
        aPicBoxes(4) = PictureBox4

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

        Else
            Dim dataStream As New AdsStream(31)
            binRead = New BinaryReader(dataStream, System.Text.Encoding.ASCII)
            tcClient = New TwinCAT.Ads.TcAdsClient()
            tcClient.Connect(801)

            ReDim hConnect(100)
            Try
                hConnect(1) = tcClient.AddDeviceNotification(checkVariable(MaskedTextBox1.Text.ToString, MaskedTextBox1), dataStream, 0, 1, AdsTransMode.OnChange, 100, 0, Nothing)
                hConnect(2) = tcClient.AddDeviceNotification(checkVariable(MaskedTextBox2.Text.ToString, MaskedTextBox2), dataStream, 1, 1, AdsTransMode.OnChange, 100, 0, Nothing)
                hConnect(3) = tcClient.AddDeviceNotification(checkVariable(MaskedTextBox3.Text.ToString, MaskedTextBox3), dataStream, 2, 1, AdsTransMode.OnChange, 100, 0, Nothing)
                hConnect(4) = tcClient.AddDeviceNotification(checkVariable(MaskedTextBox4.Text.ToString, MaskedTextBox4), dataStream, 3, 1, AdsTransMode.OnChange, 100, 0, Nothing)

                Z_PozycjaMinM31 = tcClient.AddDeviceNotification(".PozycjaMinM31", dataStream, 4, 8, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Z_null_max_M31 = tcClient.AddDeviceNotification(".nullmax_M31", dataStream, 4, 8, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Z_null_min_31 = tcClient.AddDeviceNotification(".nullmin_M31", dataStream, 4, 8, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Z_Roznica1_M31 = tcClient.AddDeviceNotification(".roznica1_M31", dataStream, 4, 8, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Z_lrActual_Position_M31 = tcClient.AddDeviceNotification(".lrActual_Position", dataStream, 4, 8, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Z_PozycjaMaxM31 = tcClient.AddDeviceNotification(".PozycjaMaxM31", dataStream, 4, 8, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Z_Punkt_Ref_M31 = tcClient.AddDeviceNotification(".PunktRefM31", dataStream, 4, 8, AdsTransMode.OnChange, 100, 0, DBNull.Value)

                Z_PozycjaMinM41 = tcClient.AddDeviceNotification(".PozycjaMinM41", dataStream, 4, 8, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Z_null_max_M41 = tcClient.AddDeviceNotification(".nullmax_M41", dataStream, 4, 8, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Z_null_min_41 = tcClient.AddDeviceNotification(".nullmin_M41", dataStream, 4, 8, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Z_Roznica1_M41 = tcClient.AddDeviceNotification(".roznica1_M41", dataStream, 4, 8, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Z_lrActual_Position_M41 = tcClient.AddDeviceNotification(".lrActual_Position", dataStream, 4, 8, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Z_PozycjaMaxM41 = tcClient.AddDeviceNotification(".PozycjaMaxM41", dataStream, 4, 8, AdsTransMode.OnChange, 100, 0, DBNull.Value)
                Z_Punkt_Ref_M41 = tcClient.AddDeviceNotification(".PunktRefM41", dataStream, 4, 8, AdsTransMode.OnChange, 100, 0, DBNull.Value)

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
                R_Punkt_Ref_M31 = binRead.ReadDouble().ToString()
            End If

            If (e.NotificationHandle = Z_Roznica1_M31) Then
                R_Roznica1_M31 = binRead.ReadDouble().ToString()
            End If

            If (e.NotificationHandle = Z_null_max_M31) Then
                R_null_max_M31 = binRead.ReadDouble().ToString()
            End If

            If (e.NotificationHandle = Z_null_min_31) Then
                R_null_min_31 = binRead.ReadDouble().ToString()
            End If

            If (e.NotificationHandle = Z_lrActual_Position_M31) Then
                R_lrActual_Position_M31 = binRead.ReadDouble().ToString()
            End If

            If (e.NotificationHandle = Z_PozycjaMaxM31) Then
                R_PozycjaMaxM31 = binRead.ReadDouble().ToString()
            End If

            If (e.NotificationHandle = Z_PozycjaMinM31) Then
                R_PozycjaMinM31 = binRead.ReadDouble().ToString()
            End If

            If (e.NotificationHandle = Z_Punkt_Ref_M41) Then
                R_Punkt_Ref_M41 = binRead.ReadDouble().ToString()
            End If

            If (e.NotificationHandle = Z_Roznica1_M41) Then
                R_Roznica1_M41 = binRead.ReadDouble().ToString()
            End If

            If (e.NotificationHandle = Z_null_max_M41) Then
                R_null_max_M41 = binRead.ReadDouble().ToString()
            End If

            If (e.NotificationHandle = Z_null_min_41) Then
                R_null_min_41 = binRead.ReadDouble().ToString()
            End If

            If (e.NotificationHandle = Z_lrActual_Position_M41) Then
                R_lrActual_Position_M41 = binRead.ReadDouble().ToString()
            End If

            If (e.NotificationHandle = Z_PozycjaMaxM41) Then
                R_PozycjaMaxM41 = binRead.ReadDouble().ToString()
            End If

            If (e.NotificationHandle = Z_PozycjaMinM41) Then
                R_PozycjaMinM41 = binRead.ReadDouble().ToString()
            End If

            Dim strValue As String = ""
            Dim i As Integer
            For i = 1 To iMaxValues
                If (e.NotificationHandle = hConnect(i)) Then
                    If binRead.ReadBoolean() Then
                        zmienna(i) = "OK"
                        aPicBoxes(i).Image = My.Resources.Image2
                    Else
                        zmienna(i) = "Blad"
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

    Private Sub Generuj_Click(sender As Object, e As EventArgs) Handles Generuj.Click
        DataGridView1.Rows.Add(1)
        DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells("col1").Value = DataGridView1.Rows.Count
        DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells("col2").Value = strDate
        DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells("col3").Value = TextBox1.Text
        DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells("col4").Value = TextBox2.Text
        DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells("col5").Value = zmienna(1)
        DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells("col6").Value = zmienna(2)
        DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells("col7").Value = TextBox3.Text

        DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells("col8").Value = R_Punkt_Ref_M31
        DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells("col9").Value = R_Roznica1_M31
        '    DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells("col10").Value = R_null_max_M31
        '    DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells("col11").Value = R_null_min_31
        DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells("col12").Value = R_PozycjaMaxM31
        DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells("col13").Value = R_PozycjaMinM31
        '    DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells("col14").Value = zmienna(3)

        DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells("col15").Value = R_Punkt_Ref_M41
        DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells("col16").Value = R_Roznica1_M41
        '   DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells("col17").Value = R_null_max_M41
        '   DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells("col18").Value = R_null_min_41
        DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells("col19").Value = R_PozycjaMaxM41
        DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells("col20").Value = R_PozycjaMinM41
        '  DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells("col21").Value = zmienna(4)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        Dim xlApp As Microsoft.Office.Interop.Excel.Application
        Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
        Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet

        Dim misValue As Object = System.Reflection.Missing.Value
        Dim i As Integer
        Dim j As Integer

        xlApp = New Excel.Application()
        xlWorkBook = xlApp.Workbooks.Add(misValue)

        xlWorkSheet = xlWorkBook.Sheets.Add
        xlWorkSheet.Name = strDate


        For k As Integer = 1 To DataGridView1.Columns.Count
            xlWorkSheet.Cells(1, k) = DataGridView1.Columns(k - 1).HeaderText
        Next

        For i = 0 To DataGridView1.RowCount - 1
            For j = 0 To DataGridView1.ColumnCount - 1
                xlWorkSheet.Cells(i + 2, j + 1) = DataGridView1(j, i).Value.ToString()
            Next
        Next

        xlWorkSheet.SaveAs("C:\Users\tomczak\Desktop\testery\Stanowisko_KFA_wizualizacja\Testery.xlsx")
        xlWorkBook.Close()
        xlApp.Quit()

        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)

        MsgBox("Zapisano do C:\Users\tomczak\Desktop\testery\Stanowisko_KFA_wizualizacja\Testery.xlsx")

    End Sub

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Structure pageDetails
        Dim columns As Integer
        Dim rows As Integer
        Dim startCol As Integer
        Dim startRow As Integer
    End Structure

    Private pages As Dictionary(Of Integer, pageDetails)
    Dim maxPagesWide As Integer
    Dim maxPagesTall As Integer

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim ppd As New PrintPreviewDialog
        ppd.Document = PrintDocument1
        ppd.WindowState = FormWindowState.Maximized
        ppd.ShowDialog()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
        PrintDocument1.Print()
    End Sub

    Private Sub PrintDocument1_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintDocument1.BeginPrint
        ''this removes the printed page margins
        PrintDocument1.OriginAtMargins = True
        PrintDocument1.DefaultPageSettings.Landscape = True
        PrintDocument1.DefaultPageSettings.Margins = New Drawing.Printing.Margins(0, 0, 0, 0)

        pages = New Dictionary(Of Integer, pageDetails)

        Dim maxWidth As Integer = CInt(PrintDocument1.DefaultPageSettings.PrintableArea.Width) + 250
        Dim maxHeight As Integer = CInt(PrintDocument1.DefaultPageSettings.PrintableArea.Height) - 40 + Label1.Height

        Dim pageCounter As Integer = 0
        pages.Add(pageCounter, New pageDetails)

        Dim columnCounter As Integer = 0

        Dim columnSum As Integer = DataGridView1.RowHeadersWidth

        For c As Integer = 0 To DataGridView1.Columns.Count - 1
            If columnSum + DataGridView1.Columns(c).Width < maxWidth Then
                columnSum += DataGridView1.Columns(c).Width
                columnCounter += 1
            Else
                pages(pageCounter) = New pageDetails With {.columns = columnCounter, .rows = 0, .startCol = pages(pageCounter).startCol}
                columnSum = DataGridView1.RowHeadersWidth + DataGridView1.Columns(c).Width
                columnCounter = 1
                pageCounter += 1
                pages.Add(pageCounter, New pageDetails With {.startCol = c})
            End If
            If c = DataGridView1.Columns.Count - 1 Then
                If pages(pageCounter).columns = 0 Then
                    pages(pageCounter) = New pageDetails With {.columns = columnCounter, .rows = 0, .startCol = pages(pageCounter).startCol}
                End If
            End If
        Next

        maxPagesWide = pages.Keys.Max + 1

        pageCounter = 0

        Dim rowCounter As Integer = 0

        Dim rowSum As Integer = DataGridView1.ColumnHeadersHeight

        For r As Integer = 0 To DataGridView1.Rows.Count - 2
            If rowSum + DataGridView1.Rows(r).Height < maxHeight Then
                rowSum += DataGridView1.Rows(r).Height
                rowCounter += 1
            Else
                pages(pageCounter) = New pageDetails With {.columns = pages(pageCounter).columns, .rows = rowCounter, .startCol = pages(pageCounter).startCol, .startRow = pages(pageCounter).startRow}
                For x As Integer = 1 To maxPagesWide - 1
                    pages(pageCounter + x) = New pageDetails With {.columns = pages(pageCounter + x).columns, .rows = rowCounter, .startCol = pages(pageCounter + x).startCol, .startRow = pages(pageCounter).startRow}
                Next

                pageCounter += maxPagesWide
                For x As Integer = 0 To maxPagesWide - 1
                    pages.Add(pageCounter + x, New pageDetails With {.columns = pages(x).columns, .rows = 0, .startCol = pages(x).startCol, .startRow = r})
                Next

                rowSum = DataGridView1.ColumnHeadersHeight + DataGridView1.Rows(r).Height
                rowCounter = 1
            End If
            If r = DataGridView1.Rows.Count - 2 Then
                For x As Integer = 0 To maxPagesWide - 1
                    If pages(pageCounter + x).rows = 0 Then
                        pages(pageCounter + x) = New pageDetails With {.columns = pages(pageCounter + x).columns, .rows = rowCounter, .startCol = pages(pageCounter + x).startCol, .startRow = pages(pageCounter + x).startRow}
                    End If
                Next
            End If
        Next

        maxPagesTall = pages.Count \ maxPagesWide

    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim rect As New Rectangle(20, 20, CInt(PrintDocument1.DefaultPageSettings.PrintableArea.Width), Label1.Height)
        Dim sf As New StringFormat
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center

        e.Graphics.DrawString(Label1.Text, Label1.Font, Brushes.Black, rect, sf)

        sf.Alignment = StringAlignment.Near

        Dim startX As Integer = 50
        Dim startY As Integer = rect.Bottom

        Static startPage As Integer = 0

        For p As Integer = startPage To pages.Count - 1
            Dim cell As New Rectangle(startX, startY, DataGridView1.RowHeadersWidth, DataGridView1.ColumnHeadersHeight)
            e.Graphics.FillRectangle(New SolidBrush(SystemColors.ControlLight), cell)
            e.Graphics.DrawRectangle(Pens.Black, cell)

            startY += DataGridView1.ColumnHeadersHeight

            For r As Integer = pages(p).startRow To pages(p).startRow + pages(p).rows - 1
                cell = New Rectangle(startX, startY, DataGridView1.RowHeadersWidth, DataGridView1.Rows(r).Height)
                e.Graphics.FillRectangle(New SolidBrush(SystemColors.ControlLight), cell)
                e.Graphics.DrawRectangle(Pens.Black, cell)
                startY += DataGridView1.Rows(r).Height
            Next

            startX += cell.Width
            startY = rect.Bottom

            For c As Integer = pages(p).startCol To pages(p).startCol + pages(p).columns - 1
                cell = New Rectangle(startX, startY, DataGridView1.Columns(c).Width, DataGridView1.ColumnHeadersHeight)
                e.Graphics.FillRectangle(New SolidBrush(SystemColors.ControlLight), cell)
                e.Graphics.DrawRectangle(Pens.Black, cell)
                e.Graphics.DrawString(DataGridView1.Columns(c).HeaderCell.Value.ToString, DataGridView1.Font, Brushes.Black, cell, sf)
                startX += DataGridView1.Columns(c).Width
            Next

            startY = rect.Bottom + DataGridView1.ColumnHeadersHeight

            For r As Integer = pages(p).startRow To pages(p).startRow + pages(p).rows - 1
                startX = 50 + DataGridView1.RowHeadersWidth
                For c As Integer = pages(p).startCol To pages(p).startCol + pages(p).columns - 1
                    cell = New Rectangle(startX, startY, DataGridView1.Columns(c).Width, DataGridView1.Rows(r).Height)
                    e.Graphics.DrawRectangle(Pens.Black, cell)
                    e.Graphics.DrawString(DataGridView1(c, r).Value.ToString, DataGridView1.Font, Brushes.Black, cell, sf)
                    startX += DataGridView1.Columns(c).Width
                Next
                startY += DataGridView1.Rows(r).Height
            Next

            If p <> pages.Count - 1 Then
                startPage = p + 1
                e.HasMorePages = True
                Return
            Else
                startPage = 0
            End If
        Next
    End Sub
End Class