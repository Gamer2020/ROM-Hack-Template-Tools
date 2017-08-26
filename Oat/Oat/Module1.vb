Imports System.IO
Imports System.Drawing
Imports VB = Microsoft.VisualBasic
Module Module1

    Private FrontPalette As Color() = New Color(&H11 - 1) {}
    Private BackPalette As Color() = New Color(&H11 - 1) {}

    Private FrontSprite As Byte()
    Private BackSprite As Byte()

    Private AnimationNormalPalette As Color() = New Color(&H11 - 1) {}
    Private AnimationShinyPalette As Color() = New Color(&H11 - 1) {}

    Private AnimationNormalSprite As Byte()
    Private AnimationShinySprite As Byte()

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

                        outputstring = outputstring & "0x" & Hex(convertedimage(loopvar)) & ","

                        loopvar = loopvar + 2
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

            Dim mainbitmap As New Bitmap(ImgFile)

            If mainbitmap.Height = 128 And mainbitmap.Width = 256 Then

            Else

                Console.WriteLine("Input image must be 128 by 256.")
                End

            End If

            FrontSprite = New Byte(2048) {}
            BackSprite = New Byte(2048) {}

            Dim ONormalBackBitmap As Bitmap = New Bitmap(&H40, &H40)
            Dim ONormalFrontBitmap As Bitmap = New Bitmap(&H40, &H40)
            Dim OShinyBackBitmap As Bitmap = New Bitmap(&H40, &H40)
            Dim OShinyFrontBitmap As Bitmap = New Bitmap(&H40, &H40)

            Dim LoadAnimationFlag As Boolean = True

            Dim ONormalBackBitmapAnimation As Bitmap = New Bitmap(&H40, &H40)
            Dim ONormalFrontBitmapAnimation As Bitmap = New Bitmap(&H40, &H80)
            Dim OShinyBackBitmapAnimation As Bitmap = New Bitmap(&H40, &H40)
            Dim OShinyFrontBitmapAnimation As Bitmap = New Bitmap(&H40, &H80)


            AnimationNormalSprite = New Byte(4096) {}
            AnimationShinySprite = New Byte(4096) {}

            BitmapBLT(mainbitmap, ONormalFrontBitmap, 0, 0, 0, 0, &H40, &H40, Color.FromArgb(&HFF, 200, 200, &HA8))
            BitmapBLT(mainbitmap, OShinyFrontBitmap, 0, 0, &H40, 0, &H40, &H40, Color.FromArgb(&HFF, 200, 200, &HA8))
            BitmapBLT(mainbitmap, ONormalBackBitmap, 0, 0, &H80, 0, &H40, &H40, Color.FromArgb(&HFF, 200, 200, &HA8))
            BitmapBLT(mainbitmap, OShinyBackBitmap, 0, 0, &HC0, 0, &H40, &H40, Color.FromArgb(&HFF, 200, 200, &HA8))

            If LoadAnimationFlag = True Then
                BitmapBLT(mainbitmap, ONormalFrontBitmapAnimation, 0, 0, 0, 0, &H40, &H80, Color.FromArgb(&HFF, 200, 200, &HA8))
                BitmapBLT(mainbitmap, OShinyFrontBitmapAnimation, 0, 0, &H40, 0, &H40, &H80, Color.FromArgb(&HFF, 200, 200, &HA8))
                BitmapBLT(mainbitmap, ONormalBackBitmapAnimation, 0, 0, &H80, 0, &H40, &H40, Color.FromArgb(&HFF, 200, 200, &HA8))
                BitmapBLT(mainbitmap, OShinyBackBitmapAnimation, 0, 0, &HC0, 0, &H40, &H40, Color.FromArgb(&HFF, 200, 200, &HA8))

            End If

            'synchpals

            Dim num As Byte
            Dim palcolor As Color
            Dim flag As Boolean = False

            Array.Clear(FrontPalette, 0, &H10 - 1)
            Array.Clear(BackPalette, 0, &H10 - 1)

            If LoadAnimationFlag = True Then
                Array.Clear(AnimationNormalPalette, 0, &H10 - 1)
                Array.Clear(AnimationShinyPalette, 0, &H10 - 1)

            End If

            Dim num11 As Integer = ((1 * &H40) - 1)
            Dim ivar As UInteger = 0
            Do While (ivar <= num11)
                Dim num3 As UInteger = 0
                Do
                    palcolor = GetQuantizedPixel(ONormalFrontBitmap, num3, ivar)
                    If Not Enumerable.Contains(Of Color)(FrontPalette, palcolor) Then
                        FrontPalette(num) = palcolor
                        BackPalette(num) = GetQuantizedPixel(OShinyFrontBitmap, num3, ivar)
                        num = ((num + 1))
                        If (num > 15) Then
                            flag = True
                            Exit Do
                        End If
                    End If
                    num3 += 1
                Loop While (num3 <= &H3F)
                If flag Then
                    Exit Do
                End If
                ivar += 1
            Loop

            Dim num12 As Integer = ((1 * &H40) - 1)
            Dim j As UInteger = 0
            Do While (j <= num12)
                Dim num5 As UInteger = 0
                Do
                    palcolor = GetQuantizedPixel(ONormalBackBitmap, num5, j)
                    If Not Enumerable.Contains(Of Color)(FrontPalette, palcolor) Then
                        FrontPalette(num) = palcolor
                        BackPalette(num) = GetQuantizedPixel(OShinyBackBitmap, num5, j)
                        num = ((num + 1))
                        If (num > 15) Then
                            flag = True
                            Exit Do
                        End If
                    End If
                    num5 += 1
                Loop While (num5 <= &H3F)
                If flag Then
                    Exit Do
                End If
                j += 1
            Loop

            Dim num13 As Integer = ((1 * &H40) - 1)
            Dim k As UInteger = 0
            Do While (k <= num13)
                Dim num7 As UInteger = 0
                Do
                    palcolor = GetQuantizedPixel(OShinyFrontBitmap, num7, k)
                    If Not Enumerable.Contains(Of Color)(BackPalette, palcolor) Then
                        BackPalette(num) = palcolor
                        FrontPalette(num) = GetQuantizedPixel(ONormalFrontBitmap, num7, k)
                        num = CByte((num + 1))
                        If (num > 15) Then
                            flag = True
                            Exit Do
                        End If
                    End If
                    num7 += 1
                Loop While (num7 <= &H3F)
                If flag Then
                    Exit Do
                End If
                k += 1
            Loop

            Dim num14 As Integer = ((1 * &H40) - 1)
            Dim m As UInteger = 0
            Do While (m <= num14)
                Dim num9 As UInteger = 0
                Do
                    palcolor = GetQuantizedPixel(OShinyBackBitmap, num9, m)
                    If Not Enumerable.Contains(Of Color)(BackPalette, palcolor) Then
                        BackPalette(num) = palcolor
                        FrontPalette(num) = GetQuantizedPixel(ONormalBackBitmap, num9, m)
                        num = CByte((num + 1))
                        If (num > 15) Then
                            flag = True
                            Exit Do
                        End If
                    End If
                    num9 += 1
                Loop While (num9 <= &H3F)
                If flag Then
                    Exit Do
                End If
                m += 1
            Loop

            Dim n As Integer = num
            Do While (n <= 15)
                FrontPalette(n) = Color.Black
                BackPalette(n) = Color.Black
                n += 1
            Loop

            If LoadAnimationFlag = True Then
                AnimationNormalPalette = FrontPalette
                AnimationShinyPalette = BackPalette
            End If

            ConvertBitmapToPalette(ONormalFrontBitmap, FrontPalette, True)
            ConvertBitmapToPalette(OShinyFrontBitmap, BackPalette, True)
            ConvertBitmapToPalette(ONormalBackBitmap, FrontPalette, True)
            ConvertBitmapToPalette(OShinyBackBitmap, BackPalette, True)

            If LoadAnimationFlag = True Then
                ConvertBitmapToPalette(ONormalFrontBitmapAnimation, AnimationNormalPalette, True)
                ConvertBitmapToPalette(OShinyFrontBitmapAnimation, AnimationShinyPalette, True)
                ConvertBitmapToPalette(ONormalBackBitmapAnimation, AnimationNormalPalette, True)
                ConvertBitmapToPalette(OShinyBackBitmapAnimation, AnimationShinyPalette, True)
            End If

            SynchSprite(FrontSprite, ONormalFrontBitmap, OShinyFrontBitmap)
            SynchSprite(BackSprite, ONormalBackBitmap, OShinyBackBitmap)

            If LoadAnimationFlag = True Then
                SynchSprite2(AnimationNormalSprite, ONormalFrontBitmapAnimation, OShinyFrontBitmapAnimation)
            End If

            'mainbitmap.Dispose()

            Dim convertedimage1 As Byte()
            Dim convertedpal1 As Byte()
            Dim convertedimage2 As Byte()
            Dim convertedpal2 As Byte()

            BitmapBLT(mainbitmap, ONormalFrontBitmapAnimation, 0, 0, 0, 0, &H40, &H80, Color.FromArgb(&HFF, 200, 200, &HA8))
            BitmapBLT(mainbitmap, OShinyBackBitmap, 0, 0, &HC0, 0, &H40, &H40, Color.FromArgb(&HFF, 200, 200, &HA8))

            convertedimage1 = CompressBytes(AnimationNormalSprite)
            convertedimage2 = CompressBytes(BackSprite)

            convertedpal1 = (CompressBytes(HexStringToByteArray(ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(AnimationNormalPalette(0))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(AnimationNormalPalette(1))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(AnimationNormalPalette(2))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(AnimationNormalPalette(3))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(AnimationNormalPalette(4))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(AnimationNormalPalette(5))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(AnimationNormalPalette(6))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(AnimationNormalPalette(7))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(AnimationNormalPalette(8))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(AnimationNormalPalette(9))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(AnimationNormalPalette(10))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(AnimationNormalPalette(11))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(AnimationNormalPalette(12))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(AnimationNormalPalette(13))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(AnimationNormalPalette(14))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(AnimationNormalPalette(15))), 4)))))
            convertedpal2 = (CompressBytes(HexStringToByteArray(ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(BackPalette(0))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(BackPalette(1))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(BackPalette(2))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(BackPalette(3))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(BackPalette(4))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(BackPalette(5))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(BackPalette(6))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(BackPalette(7))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(BackPalette(8))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(BackPalette(9))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(BackPalette(10))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(BackPalette(11))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(BackPalette(12))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(BackPalette(13))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(BackPalette(14))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(BackPalette(15))), 4)))))

            If strArg.Count > 2 Then

                If strArg(2).ToLower = "-c" Then

                    'Dim loopvar As Integer = 0
                    'Dim outputstring As String = ""


                    'outputstring = outputstring & "#define " & Path.GetFileName(ImgFile).Replace(".png", "") & "IMGLen " & convertedimage.Count & vbCrLf

                    'outputstring = outputstring & "const char " & Path.GetFileName(ImgFile).Replace(".png", "") & "IMG[" & convertedimage.Count & "]=" & vbCrLf

                    'outputstring = outputstring & "{" & vbCrLf

                    'While loopvar < convertedimage.Count

                    '    outputstring = outputstring & "0x" & Hex(convertedimage(loopvar)) & ","

                    '    loopvar = loopvar + 1
                    'End While

                    'outputstring = outputstring & vbCrLf & "};" & vbCrLf

                    'outputstring = outputstring & vbCrLf

                    'loopvar = 0

                    'outputstring = outputstring & "#define " & Path.GetFileName(ImgFile).Replace(".png", "") & "PALLen " & convertedpal.Count & vbCrLf

                    'outputstring = outputstring & "const char " & Path.GetFileName(ImgFile).Replace(".png", "") & "PAL[" & convertedpal.Count & "]=" & vbCrLf

                    'outputstring = outputstring & "{" & vbCrLf

                    'While loopvar < convertedpal.Count

                    '    outputstring = outputstring & "0x" & Hex(convertedimage(loopvar)) & ","

                    '    loopvar = loopvar + 2
                    'End While

                    'outputstring = outputstring & vbCrLf & "};" & vbCrLf

                    'File.WriteAllText(Path.ChangeExtension(ImgFile, "c"), outputstring)

                Else

                    GoTo writefiles2

                End If

            Else
writefiles2:
                File.WriteAllBytes(ImgFile.Replace(".png", "_Animation.bin"), convertedimage1)
                File.WriteAllBytes(ImgFile.Replace(".png", "_Normal.pal"), convertedpal1)
                File.WriteAllBytes(ImgFile.Replace(".png", "_Back.bin"), convertedimage2)
                File.WriteAllBytes(ImgFile.Replace(".png", "_Shiny.pal"), convertedpal2)

            End If


        End If

    End Sub

    Private Sub SynchSprite(ByRef SpriteArray As Byte(), ByRef NormalSprite As Bitmap, ByRef ShinySprite As Bitmap)
        Dim num11 As Double = ((CDbl(SpriteArray.Length) / 256) - 1)
        Dim i As Double = 0
        Do While (i <= num11)
            Dim num8 As Integer = 0
            Do
                Dim num9 As Integer = 0
                Do
                    Dim num10 As Integer = 0
                    Do
                        Dim num3 As Byte
                        Dim num4 As UInt32
                        Dim index As Byte = CByte(Array.IndexOf(Of Color)(FrontPalette, NormalSprite.GetPixel(((num8 * 8) + (num10 * 2)), CInt(Math.Round(CDbl(((i * 8) + num9)))))))
                        Dim num2 As Byte = CByte(Array.IndexOf(Of Color)(FrontPalette, NormalSprite.GetPixel((((num8 * 8) + (num10 * 2)) + 1), CInt(Math.Round(CDbl(((i * 8) + num9)))))))
                        Dim num5 As Byte = CByte(Array.IndexOf(Of Color)(BackPalette, ShinySprite.GetPixel(((num8 * 8) + (num10 * 2)), CInt(Math.Round(CDbl(((i * 8) + num9)))))))
                        Dim num6 As Byte = CByte(Array.IndexOf(Of Color)(BackPalette, ShinySprite.GetPixel((((num8 * 8) + (num10 * 2)) + 1), CInt(Math.Round(CDbl(((i * 8) + num9)))))))
                        If (num5 > index) Then
                            num3 = num5
                        Else
                            num3 = index
                        End If
                        If (num6 > num2) Then
                            num3 = CByte((num3 Or CByte((num6 << 4))))
                        Else
                            num3 = CByte((num3 Or CByte((num2 << 4))))
                        End If
                        SpriteArray(num4) = num3
                        Dim addvar As UInteger = 1
                        num4 = (num4 + addvar)
                        num10 += 1
                    Loop While (num10 <= 3)
                    num9 += 1
                Loop While (num9 <= 7)
                num8 += 1
            Loop While (num8 <= 7)
            i += 1
        Loop
    End Sub

    Private Sub SynchSprite2(ByRef SpriteArray As Byte(), ByRef NormalSprite As Bitmap, ByRef ShinySprite As Bitmap)
        Dim num11 As Double = ((CDbl(SpriteArray.Length) / 256) - 1)
        Dim i As Double = 0
        Do While (i <= num11)
            Dim num8 As Integer = 0
            Do
                Dim num9 As Integer = 0
                Do
                    Dim num10 As Integer = 0
                    Do
                        Dim num3 As Byte
                        Dim num4 As UInt32
                        Dim index As Byte = CByte(Array.IndexOf(Of Color)(AnimationNormalPalette, NormalSprite.GetPixel(((num8 * 8) + (num10 * 2)), CInt(Math.Round(CDbl(((i * 8) + num9)))))))
                        Dim num2 As Byte = CByte(Array.IndexOf(Of Color)(AnimationNormalPalette, NormalSprite.GetPixel((((num8 * 8) + (num10 * 2)) + 1), CInt(Math.Round(CDbl(((i * 8) + num9)))))))
                        Dim num5 As Byte = CByte(Array.IndexOf(Of Color)(AnimationShinyPalette, ShinySprite.GetPixel(((num8 * 8) + (num10 * 2)), CInt(Math.Round(CDbl(((i * 8) + num9)))))))
                        Dim num6 As Byte = CByte(Array.IndexOf(Of Color)(AnimationShinyPalette, ShinySprite.GetPixel((((num8 * 8) + (num10 * 2)) + 1), CInt(Math.Round(CDbl(((i * 8) + num9)))))))
                        If (num5 > index) Then
                            num3 = num5
                        Else
                            num3 = index
                        End If
                        If (num6 > num2) Then
                            num3 = CByte((num3 Or CByte((num6 << 4))))
                        Else
                            num3 = CByte((num3 Or CByte((num2 << 4))))
                        End If
                        SpriteArray(num4) = num3
                        Dim addvar As UInteger = 1
                        num4 = (num4 + addvar)
                        num10 += 1
                    Loop While (num10 <= 3)
                    num9 += 1
                Loop While (num9 <= 7)
                num8 += 1
            Loop While (num8 <= 7)
            i += 1
        Loop
    End Sub

End Module
