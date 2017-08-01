Imports System.IO
Imports System.Drawing
Imports VB = Microsoft.VisualBasic
Module Module1

    Sub Main()
        Dim strArg() As String
        strArg = Command().Split(" ")
        ' strArg(0) is first argument and so on
        '
        '
        If strArg(0) = "" Then
            Console.WriteLine("Write help...")
            End
        End If


        Dim ImgFile As String = strArg(0)

        If strArg(1).ToLower = "-lz77" Then

            Dim SpritePAl() As Color
            Dim importimg As New Bitmap(ImgFile)
            Dim Loadedimg As Bitmap = New Bitmap(importimg.Width, importimg.Height)

            Dim convertedimage As Byte()
            Dim convertedpal As Byte()

            BitmapBLT(importimg, Loadedimg, 0, 0, 0, 0, &H40, &H40, Color.FromArgb(&HFF, 200, 200, &HA8))

            SpritePAl = GetBitmapPalette(Loadedimg)

            ConvertBitmapToPalette(Loadedimg, SpritePAl, True)

            convertedimage = (CompressBytes(SaveBitmapToArray(importimg, SpritePAl)))

            convertedpal = (CompressBytes(HexStringToByteArray(ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(SpritePAl(0))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(SpritePAl(1))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(SpritePAl(2))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(SpritePAl(3))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(SpritePAl(4))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(SpritePAl(5))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(SpritePAl(6))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(SpritePAl(7))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(SpritePAl(8))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(SpritePAl(9))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(SpritePAl(10))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(SpritePAl(11))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(SpritePAl(12))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(SpritePAl(13))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(SpritePAl(14))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(SpritePAl(15))), 4)))))

            If File.Exists(Path.ChangeExtension(ImgFile, "bin")) Then

                File.Delete(Path.ChangeExtension(ImgFile, "bin"))

            End If

            If strArg.Count > 2 Then

                If strArg(2).ToLower = "-c" Then

                    Dim loopvar As Integer = 0
                    Dim outputstring As String = ""


                    outputstring = outputstring & "#define " & Path.GetFileName(ImgFile).Replace(".png", "") & "IMGLen " & convertedimage.Count & vbCrLf

                    outputstring = outputstring & "const char " & Path.GetFileName(ImgFile).Replace(".png", "") & "IMG[" & convertedimage.Count & "]=" & vbCrLf

                    outputstring = outputstring & "{" & vbCrLf

                    While loopvar < convertedimage.Count

                        outputstring = outputstring & "0x" & Hex(convertedimage(loopvar)) & ","

                        loopvar = loopvar + 1
                    End While

                    outputstring = outputstring & vbCrLf & "};" & vbCrLf

                    outputstring = outputstring & vbCrLf

                    loopvar = 0

                    outputstring = outputstring & "#define " & Path.GetFileName(ImgFile).Replace(".png", "") & "PALLen " & convertedpal.Count & vbCrLf

                    outputstring = outputstring & "const char " & Path.GetFileName(ImgFile).Replace(".png", "") & "PAL[" & convertedpal.Count & "]=" & vbCrLf

                    outputstring = outputstring & "{" & vbCrLf

                    While loopvar < convertedpal.Count

                        outputstring = outputstring & "0x" & Hex(convertedpal(loopvar)) & ","

                        loopvar = loopvar + 1
                    End While

                    outputstring = outputstring & vbCrLf & "};" & vbCrLf

                    File.WriteAllText(Path.ChangeExtension(ImgFile, "c"), outputstring)

                Else

                    GoTo writefiles

                End If

            Else
writefiles:
                File.WriteAllBytes(Path.ChangeExtension(ImgFile, "bin"), convertedimage)
                File.WriteAllBytes(Path.ChangeExtension(ImgFile, "pal"), convertedpal)

            End If

        ElseIf strArg(1).ToLower = "-aseries" Then

            End If

    End Sub

End Module
