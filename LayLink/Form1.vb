Imports System.Text.RegularExpressions
Imports System.Net
Imports System.Text
Imports System.IO


Public Class Form1


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim sourceString As String = New System.Net.WebClient().DownloadString(txtUrl.Text)

        'Dim webClient As New System.Net.WebClient
        '  Dim result As String = webClient.DownloadString(txtUrl.Text)

        Control.CheckForIllegalCrossThreadCalls = False
    End Sub

    Private Function GetSource(ByVal tcLink As String) As String

        Dim r As String
        Dim oEnc As System.Text.Encoding = System.Text.Encoding.UTF8

        Using oWeb As New WebClient()
            oWeb.Encoding = oEnc
            Dim oBytes() As Byte = oWeb.DownloadData(tcLink)
            r = oEnc.GetString(oBytes)
        End Using

        Return r
    End Function



    Private Sub wb_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles wb.DocumentCompleted
        If (wb.ReadyState = WebBrowserReadyState.Complete) Then
            For Each ClientControl As HtmlElement In wb.Document.Links
                ListBox2.Items.Add(ClientControl.GetAttribute("href"))
            Next
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        wb.Navigate(txtUrl.Text)
        rtxtResult.Text = GetSource(txtUrl.Text)

        rtxtResult.Text = Regex.Match(rtxtResult.Text, "<title>.*</title>").ToString()


        rtxtResult.Text = Replace(rtxtResult.Text, "<title>", "")
        rtxtResult.Text = Replace(rtxtResult.Text, "</title>", "")
        TextBox2.Text = rtxtResult.Text
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try

            ListBox1.SelectedIndex = ListBox1.SelectedIndex + 1
            Label1.Text = ListBox1.Items.Count

            If InStr(ListBox1.Text, "http://") > 0 Then
                txtUrl.Text = ListBox1.Text
            Else
                txtUrl.Text = "http://" + ListBox1.Text
            End If
            Timer2.Enabled = True
            Timer1.Enabled = False

        Catch

            ListBox1.Items.Clear()
            Dim client As WebClient = New WebClient()
            Dim reader As New StreamReader(client.OpenRead("http://luutru360.com/php/data.txt"))
            Dim StringGiven As String = reader.ReadToEnd
            Dim lines As String() = StringGiven.Split("|")
            Dim i As Integer = 0
            For Each line As String In lines
                ListBox1.Items.Add(line)
                i = i + 1
            Next
            Dim i1, j As Long
            For i1 = 0 To ListBox1.Items.Count - 1
                For j = ListBox1.Items.Count - 1 To (i1 + 1) Step -1
                    If ListBox1.Items(i1) = ListBox1.Items(j) Then
                        ListBox1.Items.Remove(ListBox1.Items(j))
                    End If
                Next
            Next
            Dim sourceString As String = New System.Net.WebClient().DownloadString("http://luutru360.com/php/kill.php")
            Label5.Text = "Đã hoàn thành!"
            Label3.Text = "0"
            Label1.Text = "0"
            Timer1.Enabled = True



        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


        Dim sourceString As String = New System.Net.WebClient().DownloadString("http://xemphim.luutru360.com/add.php?title=" & rtxtResult.Text & "&url=" & txtUrl.Text & "&keywords=" & rtxtResult.Text & "," & tukhoa.Text & TextBox2.Text & TextBox3.Text)
        ' Dim sourceString As String = New System.Net.WebClient().DownloadString("http://xemphim.luutru360.com/add.php?title=" & rtxtResult.Text  ")
        Label2.Text = rtxtResult.Text

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        rtxtResult.Text = GetSource(txtUrl.Text)

        rtxtResult.Text = Regex.Match(rtxtResult.Text, "<title>.*</title>").ToString()


        rtxtResult.Text = Replace(rtxtResult.Text, "<title>", "")
        rtxtResult.Text = Replace(rtxtResult.Text, "</title>", "")
        TextBox2.Text = rtxtResult.Text
    End Sub

    Private Sub txtUrl_Click(sender As Object, e As EventArgs) Handles txtUrl.Click
        txtUrl.Text = ""
    End Sub

    Private Sub txtUrl_TextChanged(sender As Object, e As EventArgs) Handles txtUrl.TextChanged

        Try
            ' Dim sourceString2 As String = New System.Net.WebClient().DownloadString(txtUrl.Text)
            'rtxtResult.Text = sourceString2
            'rtxtResult.Text = Regex.Match(rtxtResult.Text, "<title>.*</title>").ToString()
            rtxtResult.Text = GetSource(txtUrl.Text)

            rtxtResult.Text = Regex.Match(rtxtResult.Text, "<title>.*</title>").ToString()


            rtxtResult.Text = Replace(rtxtResult.Text, "<title>", "")
            rtxtResult.Text = Replace(rtxtResult.Text, "</title>", "")
            Label5.Text = rtxtResult.Text


            tukhoa.Text = StrConv(rtxtResult.Text, 2)
            tukhoa.Text = Replace(tukhoa.Text, "á", "a")
            tukhoa.Text = Replace(tukhoa.Text, "à", "a")
            tukhoa.Text = Replace(tukhoa.Text, "â", "a")
            tukhoa.Text = Replace(tukhoa.Text, "ă", "a")
            tukhoa.Text = Replace(tukhoa.Text, "ấ", "a")
            tukhoa.Text = Replace(tukhoa.Text, "ầ", "a")
            tukhoa.Text = Replace(tukhoa.Text, "ằ", "a")
            tukhoa.Text = Replace(tukhoa.Text, "ắ", "a")
            tukhoa.Text = Replace(tukhoa.Text, "ã", "a")
            tukhoa.Text = Replace(tukhoa.Text, "ả", "a")
            tukhoa.Text = Replace(tukhoa.Text, "ạ", "a")
            tukhoa.Text = Replace(tukhoa.Text, "ẫ", "a")
            tukhoa.Text = Replace(tukhoa.Text, "ẩ", "a")
            tukhoa.Text = Replace(tukhoa.Text, "ẵ", "a")
            tukhoa.Text = Replace(tukhoa.Text, "ẳ", "a")
            tukhoa.Text = Replace(tukhoa.Text, "ậ", "a")
            tukhoa.Text = Replace(tukhoa.Text, "ặ", "a")
            tukhoa.Text = Replace(tukhoa.Text, "é", "e")
            tukhoa.Text = Replace(tukhoa.Text, "è", "e")
            tukhoa.Text = Replace(tukhoa.Text, "ẻ", "e")
            tukhoa.Text = Replace(tukhoa.Text, "ẽ", "e")
            tukhoa.Text = Replace(tukhoa.Text, "ẹ", "e")
            tukhoa.Text = Replace(tukhoa.Text, "ê", "e")
            tukhoa.Text = Replace(tukhoa.Text, "ế", "e")
            tukhoa.Text = Replace(tukhoa.Text, "ề", "e")
            tukhoa.Text = Replace(tukhoa.Text, "ể", "e")
            tukhoa.Text = Replace(tukhoa.Text, "ễ", "e")
            tukhoa.Text = Replace(tukhoa.Text, "ệ", "e")
            tukhoa.Text = Replace(tukhoa.Text, "ó", "o")
            tukhoa.Text = Replace(tukhoa.Text, "ò", "o")
            tukhoa.Text = Replace(tukhoa.Text, "ỏ", "o")
            tukhoa.Text = Replace(tukhoa.Text, "õ", "o")
            tukhoa.Text = Replace(tukhoa.Text, "ọ", "o")
            tukhoa.Text = Replace(tukhoa.Text, "ố", "o")
            tukhoa.Text = Replace(tukhoa.Text, "ồ", "o")
            tukhoa.Text = Replace(tukhoa.Text, "ổ", "o")
            tukhoa.Text = Replace(tukhoa.Text, "ỗ", "o")
            tukhoa.Text = Replace(tukhoa.Text, "ộ", "o")
            tukhoa.Text = Replace(tukhoa.Text, "ô", "o")
            tukhoa.Text = Replace(tukhoa.Text, "ơ", "o")
            tukhoa.Text = Replace(tukhoa.Text, "ờ", "o")
            tukhoa.Text = Replace(tukhoa.Text, "ớ", "o")
            tukhoa.Text = Replace(tukhoa.Text, "ở", "o")
            tukhoa.Text = Replace(tukhoa.Text, "ỡ", "o")
            tukhoa.Text = Replace(tukhoa.Text, "ợ", "o")
            tukhoa.Text = Replace(tukhoa.Text, "ú", "u")
            tukhoa.Text = Replace(tukhoa.Text, "ù", "u")
            tukhoa.Text = Replace(tukhoa.Text, "ủ", "u")
            tukhoa.Text = Replace(tukhoa.Text, "ũ", "u")
            tukhoa.Text = Replace(tukhoa.Text, "ụ", "u")
            tukhoa.Text = Replace(tukhoa.Text, "ư", "u")
            tukhoa.Text = Replace(tukhoa.Text, "ứ", "u")
            tukhoa.Text = Replace(tukhoa.Text, "ừ", "u")
            tukhoa.Text = Replace(tukhoa.Text, "ử", "u")
            tukhoa.Text = Replace(tukhoa.Text, "ữ", "u")
            tukhoa.Text = Replace(tukhoa.Text, "ự", "u")
            tukhoa.Text = Replace(tukhoa.Text, "í", "i")
            tukhoa.Text = Replace(tukhoa.Text, "ì", "i")
            tukhoa.Text = Replace(tukhoa.Text, "ỉ", "i")
            tukhoa.Text = Replace(tukhoa.Text, "ĩ", "i")
            tukhoa.Text = Replace(tukhoa.Text, "ị", "i")
            tukhoa.Text = Replace(tukhoa.Text, "đ", "d")
            tukhoa.Text = Replace(tukhoa.Text, "ý", "y")
            tukhoa.Text = Replace(tukhoa.Text, "ỳ", "y")
            tukhoa.Text = Replace(tukhoa.Text, "ỷ", "y")
            tukhoa.Text = Replace(tukhoa.Text, "ỹ", "y")
            tukhoa.Text = Replace(tukhoa.Text, "ỵ", "y")
            tukhoa.Text = Replace(tukhoa.Text, "|", ",")
            TextBox2.Text = rtxtResult.Text + tukhoa.Text
            TextBox2.Text = Replace(TextBox2.Text, " ", ",")
            TextBox3.Text = rtxtResult.Text + "," + StrConv(rtxtResult.Text, 2) + "," + TextBox2.Text
        Catch

        End Try

    End Sub

    Private Sub ListBox1_Click(sender As Object, e As EventArgs) Handles ListBox1.Click
        Label1.Text = ListBox1.Items.Count
        txtUrl.Text = ListBox1.Text
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ListBox1.SelectedIndex = ListBox1.SelectedIndex + 1
        Label1.Text = ListBox1.Items.Count
        txtUrl.Text = ListBox1.Text
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        txtUrl.Text = ""
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        TextBox1.Text = ""
        Label3.Text = "0"
        Label1.Text = "0"
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Timer1.Enabled = False
        Timer2.Enabled = False
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick


        Dim sourceString2 As String = New System.Net.WebClient().DownloadString("http://xemphim.luutru360.com/add.php?title=" & rtxtResult.Text & "&url=" & txtUrl.Text & "&keywords=" & rtxtResult.Text & "," & tukhoa.Text & TextBox2.Text & TextBox3.Text)
        Dim sourceString As String = New System.Net.WebClient().DownloadString("http://luutru360.com/php/t.php?u=" & txtUrl.Text)
        Label2.Text = rtxtResult.Text
        Label3.Text = Label3.Text + 1
        Timer2.Enabled = False
        Timer1.Enabled = True
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Timer1.Enabled = True
    End Sub





    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        TextBox1.Lines = ListBox2.Items.Cast(Of String).ToArray
        Dim i% : Dim x$() : x = Split(TextBox1.Text, vbNewLine)
        For i = 0 To UBound(x)
            If InStr(1, x(i), "phim3s.net/phim-le/") > 0 Or InStr(1, x(i), "phim3s.net/phim-bo/") > 0 Or InStr(1, x(i), "phim3svn.net/phim/") > 0 Or InStr(1, x(i), "phim.hayhd.vn/phim-bo/") > 0 Or InStr(1, x(i), "phim.hayhd.vn/phim-le/") > 0 Or InStr(1, x(i), "phimvon.com/phim-bo/") > 0 Or InStr(1, x(i), "phimvon.com/phim-le/") > 0 Or InStr(1, x(i), "www.hayhaytv.vn/xem-phim/") > 0 Or InStr(1, x(i), "clip.vn/info/") > 0 Or InStr(1, x(i), "phim14.net/phim/") > 0 Then ListBox1.Items.Add(x(i))
        Next
    End Sub



    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Try
            For Each ClientControl As HtmlElement In wb.Document.Links
                ListBox1.Items.Add(ClientControl.GetAttribute("href"))
            Next
        Catch

        End Try
    End Sub



    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        '  wb.Navigate("http://hayhaytv.vn/")
        '  WebBrowser1.Navigate("http://phim14.net/")
        '  WebBrowser2.Navigate("http://phim3s.net/")
        ' WebBrowser3.Navigate("http://phim.hayhd.vn/")
        ' WebBrowser4.Navigate("http://phim.clip.vn/")
        ' WebBrowser5.Navigate("http://phimvon.com/")
        ' WebBrowser6.Navigate("http://phim3svn.net")
    End Sub


    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        Try

            ListBox1.SelectedIndex = ListBox1.SelectedIndex + 1
            Label1.Text = ListBox1.Items.Count
            txtUrl.Text = ListBox1.Text
            Timer4.Enabled = True
            Timer3.Enabled = False

        Catch
            Label5.Text = "Đã hoàn thành!"
            Label3.Text = "0"
            Timer4.Enabled = False

            Timer3.Enabled = False
        End Try
    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick


        Dim sourceString As String = New System.Net.WebClient().DownloadString("http://xemphim.luutru360.com/add.php?title=" & rtxtResult.Text & "&url=" & txtUrl.Text & "&keywords=" & rtxtResult.Text & "," & tukhoa.Text & TextBox2.Text & TextBox3.Text)

        Label2.Text = rtxtResult.Text
        Label3.Text = Label3.Text + 1
        Timer4.Enabled = False
        Timer3.Enabled = True
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Me.Text = "Waiting..."
        Control.CheckForIllegalCrossThreadCalls = False
        Dim client As WebClient = New WebClient()
        Dim reader As New StreamReader(client.OpenRead("http://luutru360.com/php/data.txt"))
        Dim StringGiven As String = reader.ReadToEnd
        Dim lines As String() = StringGiven.Split("|")
        Dim i As Integer = 0
        For Each line As String In lines
            ListBox2.Items.Add(line)
            i = i + 1
        Next
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Timer3.Enabled = True
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Dim i, j As Long
        For i = 0 To ListBox1.Items.Count - 1
            For j = ListBox1.Items.Count - 1 To (i + 1) Step -1
                If ListBox1.Items(i) = ListBox1.Items(j) Then
                    ListBox1.Items.Remove(ListBox1.Items(j))
                End If
            Next
        Next
    End Sub

    Private Sub rtxtResult_TextChanged(sender As Object, e As EventArgs) Handles rtxtResult.TextChanged

    End Sub
End Class
