Imports System.IO
Imports System.IO.Compression



Module mMain

    Public AppPath As String = System.AppDomain.CurrentDomain.BaseDirectory() & IIf(Right(System.AppDomain.CurrentDomain.BaseDirectory(), 1) = "\", "", "\")
    Public LoadedROM As String
    Public LastROMLocal As String
    Public LastINILocal As String

    Public Sub DownloadFile(ByVal _URL As String, ByVal _SaveAs As String)
        Try
            Dim _WebClient As New System.Net.WebClient()
            ' Downloads the resource with the specified URI to a local file.
            _WebClient.DownloadFile(_URL, _SaveAs)
        Catch _Exception As Exception
            ' Error

            ' Console.WriteLine("Exception caught in process: {0}", _Exception.ToString())
        End Try
    End Sub

    Public Sub Unzipfile(zipPath As String, extractPath As String)

        ZipFile.ExtractToDirectory(zipPath, extractPath)

    End Sub

    Public Function MakeEvenIfNot(b As Integer) As Integer

        Dim result As Integer = 1

        Dim ca As Integer

        'Debug.Print(b)

        ca = b Mod 2

        If ca = 0 Then
            '  Debug.Print("Even")
            result = b
        Else
            ' Debug.Print("Odd")
            result = b + 1
        End If

        MakeEvenIfNot = result
    End Function

End Module
