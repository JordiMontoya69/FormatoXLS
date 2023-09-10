Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO

Public Class Form1
    Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
        Dim guardar As SaveFileDialog = New SaveFileDialog()
        Dim app As Excel.Application = New Excel.Application()
        Dim work As Excel.Workbook = app.Workbooks.Open(Path.GetFullPath("club nautico.xlsx"), Nothing, True)
        Dim sheet As Excel.Worksheet = work.Worksheets(1)
        Dim j As Integer = 2
        Dim n As Integer = dataGridView1.Rows.Count



        For i As Integer = 0 To n - 1
            sheet.Range("A" & j.ToString()).Value = j - 1
            sheet.Range("B" & j.ToString()).Value = dataGridView1.Rows(i).Cells(0).Value
            sheet.Range("C" & j.ToString()).Value2 = dataGridView1.Rows(i).Cells(1).Value
            sheet.Range("D" & j.ToString()).Value2 = dataGridView1.Rows(i).Cells(2).Value
            sheet.Range("E" & j.ToString()).Value2 = dataGridView1.Rows(i).Cells(3).Value
            sheet.Range("F" & j.ToString()).Value2 = dataGridView1.Rows(i).Cells(4).Value
            sheet.Range("G" & j.ToString()).Value2 = dataGridView1.Rows(i).Cells(5).Value
            sheet.Range("H" & j.ToString()).Value2 = dataGridView1.Rows(i).Cells(6).Value



            If i < n - 1 Then
                sheet.Range("A" & (j + 1).ToString()).EntireRow.Insert(Excel.XlDirection.xlDown, Excel.XlInsertFormatOrigin.xlFormatFromLeftOrAbove)
            End If



            j += 1
        Next



        app.Visible = True
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim conexion As SqlConnection = New SqlConnection("Server='localhost\SQLEXPRESS'; Database='club_nautico';Trusted_Connection=True;")
        conexion.Open()
        Dim query As SqlCommand = New SqlCommand("select * from barco", conexion)
        Dim datos As SqlDataReader = query.ExecuteReader()
        Dim ds As DataSet = New DataSet()
        ds.Load(datos, LoadOption.OverwriteChanges, "datos")
        dataGridView1.DataSource = ds.Tables("datos")
    End Sub
End Class
