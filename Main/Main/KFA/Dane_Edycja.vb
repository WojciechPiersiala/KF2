Imports System.Data
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Data.OleDb

Public Class Dane_Edycja

    Dim conn As OleDbConnection 'Reprezentuje otwarte połączenie ze źródłem danych.
    Dim da As OleDbDataAdapter  'Reprezentuje zestaw poleceń danych i połączenie bazy danych, które są używane do wypełniania DataSet i aktualizowania źródła danych.
    Dim ds As New DataSet
    Dim cmd As OleDbCommand     'Reprezentuje instrukcję SQL lub procedurę składowaną do wykonania względem źródła danych.

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button22_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    ''' <summary>
    ''' Zapisuje dane do skoroszytu Excel
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim xlApp As Microsoft.Office.Interop.Excel.Application      'Reprezentuje całą aplikację Microsoft Excel.
        Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook    'Reprezentuje skoroszyt                 
        Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet  'Reprezentuje arkusz
        Dim misValue As Object = System.Reflection.Missing.Value
        Dim i As Integer
        Dim j As Integer

        xlApp = New Excel.Application()           
        xlWorkBook = xlApp.Workbooks.Add(misValue)
        xlWorkSheet = xlWorkBook.Sheets("Arkusz1")

        'wypelnij arkusz danymi
        For i = 0 To DataGridView1.RowCount - 2
            For j = 0 To DataGridView1.ColumnCount - 1
                For k As Integer = 1 To DataGridView1.Columns.Count
                    xlWorkSheet.Cells(1, k) = DataGridView1.Columns(k - 1).HeaderText
                    xlWorkSheet.Cells(i + 2, j + 1) = DataGridView1(j, i).Value.ToString()
                Next
            Next
        Next
        'zapisz stworzony arkusz w:
        xlWorkSheet.SaveAs("C:\Users\tomczak\Desktop\testery\Stanowisko_KFA_wizualizacja\Testery.xlsx")

        'zakoncz polaczenie:
        xlWorkBook.Close()  
        xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)

        MsgBox("Zapisano do C:\Users\tomczak\Desktop\testery\Stanowisko_KFA_wizualizacja\Testery.xlsx")
    End Sub

    ''' <summary>
    ''' Wczytuje dane z Excel
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim MyConnection As System.Data.OleDb.OleDbConnection
        Dim DtSet As System.Data.DataSet
        Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
        'ciag polaczenie (zalezne od drivera na maszynie)
        MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data Source='C:\Users\tomczak\Desktop\testery\Stanowisko_KFA_wizualizacja\Testery.xlsx';Extended Properties=Excel 8.0;") 
        'uruchom zapytanie SQL
        MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [Arkusz1$]", MyConnection)   
        MyCommand.TableMappings.Add("Table", "Net-informations.com")
        DtSet = New System.Data.DataSet
        MyCommand.Fill(DtSet)
        DataGridView1.DataSource = DtSet.Tables(0)
        MyConnection.Close()

    End Sub

    ''' <summary>
    ''' Zakoncz polaczenie
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
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

End Class