﻿Imports System
Imports System.IO
Imports VB = Microsoft.VisualBasic
Imports System.Drawing

Module GetImageFunctions

    Public TilePals(12)() As Color
    Public TileSet1Image(&HFFFF) As Byte
    Public TileSet2Image(&HFFFF) As Byte
    Public BlocksImage As Bitmap
    Public MapTilesArray() As String
    Public MapPermsArray() As String
    Public MapWithPermissions As Bitmap
    Public BorderTilesArray() As String
    Public BorderPermsArray() As String
    Public BorderWithPermissions As Bitmap


    Public SelectedTileImgInBlockEditor As Integer
    Public SelectedTileImgInBlockEditorPal As Integer
    Public SelectedTileImgInBlockEditorX As Integer
    Public SelectedTileImgInBlockEditorY As Integer
    Public SelectedBlockInBlockEditor As Integer

    Public SelectedBlockPals(7) As Integer
    Public SelectedBlockY(7) As Integer
    Public SelectedBlockX(7) As Integer
    Public SelectedBlockTile(7) As Integer

    Public SelectedBlockInMapEditor As Integer
    Public SelectedBlockInBorderEditor As Integer

    Public SelectedPermInPermEditor As Integer



    Public Function DrawBlockToTile(ByVal Destination As Bitmap, ByVal Source As Bitmap, ByVal BlockNum As Integer, ByVal yflip As Integer, ByVal xflip As Integer, ByVal Tile As Integer, ByVal section As Integer) As Bitmap
        Dim Output As Bitmap = Destination
        Dim PixelColor As Color

        Dim HeightLoop As Integer
        Dim HeightCounter As Integer

        Dim TileAgain As Integer

        Dim xdes As Integer
        Dim ydes As Integer
        Dim xsrc As Integer
        Dim ysrc As Integer
        Dim x As Integer
        Dim y As Integer

        'For destination


        HeightLoop = Tile
        HeightCounter = 0

        While HeightLoop > 7

            HeightLoop = HeightLoop - 8
            HeightCounter = HeightCounter + 1

        End While

        ydes = (HeightCounter * 16) '+ (section * 8)

        xdes = ((Tile - (HeightCounter * 8)) * 16) '+ (section * 8)

        If section = 1 Then
            xdes = xdes + 8
        ElseIf section = 2 Then
            ydes = ydes + 8
        ElseIf section = 3 Then
            xdes = xdes + 8
            ydes = ydes + 8
        End If

        'For the source
        If BlockNum < 512 Then

            TileAgain = BlockNum

        Else

            TileAgain = BlockNum - 512

        End If

        HeightLoop = TileAgain
        HeightCounter = 0

        While HeightLoop > 15

            HeightLoop = HeightLoop - 16
            HeightCounter = HeightCounter + 1

        End While

        ysrc = HeightCounter * 8

        xsrc = (TileAgain - (HeightCounter * 16)) * 8


        If xflip = 0 And yflip = 0 Then

            For x = 0 To 7
                For y = 0 To 7
                    PixelColor = Source.GetPixel((xsrc) + x, (ysrc) + y)

                    Output.SetPixel((xdes) + x, (ydes) + y, PixelColor)

                Next y

            Next x
        End If

        If xflip = 1 And yflip = 0 Then

            For x = 0 To 7
                For y = 0 To 7
                    PixelColor = Source.GetPixel((xsrc) + x, (ysrc) + y)

                    Output.SetPixel((xdes + 7) - x, (ydes) + y, PixelColor)

                Next y

            Next x
        End If

        If xflip = 0 And yflip = 1 Then

            For x = 0 To 7
                For y = 0 To 7
                    PixelColor = Source.GetPixel((xsrc) + x, (ysrc) + y)

                    Output.SetPixel((xdes) + x, (ydes + 7) - y, PixelColor)

                Next y

            Next x
        End If

        If xflip = 1 And yflip = 1 Then

            For x = 0 To 7
                For y = 0 To 7
                    PixelColor = Source.GetPixel((xsrc) + x, (ysrc) + y)

                    Output.SetPixel((xdes + 7) - x, (ydes + 7) - y, PixelColor)

                Next y

            Next x
        End If
        DrawBlockToTile = Output
    End Function

    Public Sub GetAndDrawItemPic(ByVal picBox As PictureBox, ByVal index As Integer)
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "ItemIMGData", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8)
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "ItemIMGData", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) + 4
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Image)

                ReDim Temp(&HFFF)
                fs.Position = pOffset
                pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Palette15)
            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 24, 24, GetString(AppPath & "GBAPGESettings.ini", "Settings", "TransparentImages", "0"))
        picBox.Image = bSprite
        picBox.Refresh()

    End Sub

    Public Sub GetAndDrawFrontPokemonPic(ByVal picBox As PictureBox, ByVal index As Integer)
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonFrontSprites", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon front sprites, + 8 = Bulbasaur.
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonNormalPal", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon normal palettes, + 8 = Bulbasaur.
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Image)

                ReDim Temp(&HFFF)
                fs.Position = pOffset
                pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Palette15)
            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 64, 64, GetString(AppPath & "GBAPGESettings.ini", "Settings", "TransparentImages", "0"))
        picBox.Image = bSprite
        picBox.Refresh()

    End Sub

    Public Function GetFrontPokemonPicToBitmap(ByVal index As Integer, Optional ShowBackcolor As Boolean = True) As Bitmap
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonFrontSprites", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon front sprites, + 8 = Bulbasaur.
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonNormalPal", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon normal palettes, + 8 = Bulbasaur.
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Image)

                ReDim Temp(&HFFF)
                fs.Position = pOffset
                pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Palette15)
            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 64, 64, ShowBackcolor)
        GetFrontPokemonPicToBitmap = bSprite

    End Function

    Public Function GetShinyFrontPokemonPicToBitmap(ByVal index As Integer, Optional ShowBackcolor As Boolean = True) As Bitmap
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonFrontSprites", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon front sprites, + 8 = Bulbasaur.
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonShinyPal", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon normal palettes, + 8 = Bulbasaur.
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Image)

                ReDim Temp(&HFFF)
                fs.Position = pOffset
                pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Palette15)
            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 64, 64, ShowBackcolor)
        GetShinyFrontPokemonPicToBitmap = bSprite

    End Function

    Public Function GetFrontPokemonPicToByteArray(ByVal index As Integer) As Byte()
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonFrontSprites", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon front sprites, + 8 = Bulbasaur.
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonNormalPal", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon normal palettes, + 8 = Bulbasaur.
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Image)

                ReDim Temp(&HFFF)
                fs.Position = pOffset
                pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Palette15)
            End Using
        End Using
        bSprite = LoadSprite(Image, Palette32, 64, 64, 0)
        LoadBitmapFromArray(Image, Palette32, bSprite, 64, 64)
        'bSprite = LoadSprite(Image, Palette32, 64, 64, 0)
        GetFrontPokemonPicToByteArray = SaveBitmapToArray(bSprite, Palette32)

    End Function

    Public Sub GetAndDrawFrontPokemonPicBLACK(ByVal picBox As PictureBox, ByVal index As Integer)
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonFrontSprites", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon front sprites, + 8 = Bulbasaur.
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonNormalPal", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon normal palettes, + 8 = Bulbasaur.
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Image)

                ReDim Temp(&HFFF)
                fs.Position = pOffset
                pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Palette15)
                Palette32(1) = Color.Black
                Palette32(2) = Color.Black
                Palette32(3) = Color.Black
                Palette32(4) = Color.Black
                Palette32(5) = Color.Black
                Palette32(6) = Color.Black
                Palette32(7) = Color.Black
                Palette32(8) = Color.Black
                Palette32(9) = Color.Black
                Palette32(10) = Color.Black
                Palette32(11) = Color.Black
                Palette32(12) = Color.Black
                Palette32(13) = Color.Black
                Palette32(14) = Color.Black
                Palette32(15) = Color.Black
            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 64, 64, GetString(AppPath & "GBAPGESettings.ini", "Settings", "TransparentImages", "0"))
        picBox.Image = bSprite
        picBox.Refresh()

    End Sub

    Public Sub GetAndDrawFrontPokemonPicShiny(ByVal picBox As PictureBox, ByVal index As Integer)
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonFrontSprites", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon front sprites, + 8 = Bulbasaur.
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonShinyPal", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon normal palettes, + 8 = Bulbasaur.
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Image)

                ReDim Temp(&HFFF)
                fs.Position = pOffset
                pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Palette15)
            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 64, 64, GetString(AppPath & "GBAPGESettings.ini", "Settings", "TransparentImages", "0"))
        picBox.Image = bSprite
        picBox.Refresh()

    End Sub

    Public Sub GetAndDrawBackPokemonPic(ByVal picBox As PictureBox, ByVal index As Integer)
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonBackSprites", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon front sprites, + 8 = Bulbasaur.
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonShinyPal", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon normal palettes, + 8 = Bulbasaur.
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Image)

                ReDim Temp(&HFFF)
                fs.Position = pOffset
                pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Palette15)
            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 64, 64, GetString(AppPath & "GBAPGESettings.ini", "Settings", "TransparentImages", "0"))
        picBox.Image = bSprite
        picBox.Refresh()

    End Sub

    Public Function GetBackPokemonPicToBitmap(ByVal index As Integer, Optional ShowBackcolor As Boolean = True) As Bitmap
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonBackSprites", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon front sprites, + 8 = Bulbasaur.
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonShinyPal", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon normal palettes, + 8 = Bulbasaur.
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Image)

                ReDim Temp(&HFFF)
                fs.Position = pOffset
                pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Palette15)
            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 64, 64, ShowBackcolor)
        GetBackPokemonPicToBitmap = bSprite

    End Function

    Public Function GetNormalBackPokemonPicToBitmap(ByVal index As Integer, Optional ShowBackcolor As Boolean = True) As Bitmap
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonBackSprites", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon front sprites, + 8 = Bulbasaur.
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonNormalPal", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon normal palettes, + 8 = Bulbasaur.
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Image)

                ReDim Temp(&HFFF)
                fs.Position = pOffset
                pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Palette15)
            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 64, 64, ShowBackcolor)
        GetNormalBackPokemonPicToBitmap = bSprite

    End Function

    Public Sub GetAndDrawBackPokemonPicNormal(ByVal picBox As PictureBox, ByVal index As Integer)
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonBackSprites", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon front sprites, + 8 = Bulbasaur.
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonNormalPal", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon normal palettes, + 8 = Bulbasaur.
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Image)

                ReDim Temp(&HFFF)
                fs.Position = pOffset
                pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Palette15)
            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 64, 64, GetString(AppPath & "GBAPGESettings.ini", "Settings", "TransparentImages", "0"))
        picBox.Image = bSprite
        picBox.Refresh()

    End Sub

    Public Sub GetAndDrawAnimationPokemonPic(ByVal picBox As PictureBox, ByVal index As Integer)
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonAnimations", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon front sprites, + 8 = Bulbasaur.
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonNormalPal", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon normal palettes, + 8 = Bulbasaur.
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Image)

                ReDim Temp(&HFFF)
                fs.Position = pOffset
                pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Palette15)
            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 64, 128, GetString(AppPath & "GBAPGESettings.ini", "Settings", "TransparentImages", "0"))
        picBox.Image = bSprite
        picBox.Refresh()

    End Sub

    Public Function GetNormalAnimationPokemonPicToBitmap(ByVal index As Integer, Optional ShowBackcolor As Boolean = True) As Bitmap
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonAnimations", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon front sprites, + 8 = Bulbasaur.
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonNormalPal", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon normal palettes, + 8 = Bulbasaur.
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Image)

                ReDim Temp(&HFFF)
                fs.Position = pOffset
                pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Palette15)
            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 64, 128, ShowBackcolor)
        GetNormalAnimationPokemonPicToBitmap = bSprite

    End Function

    Public Function GetShinyAnimationPokemonPicToBitmap(ByVal index As Integer, Optional ShowBackcolor As Boolean = True) As Bitmap
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonAnimations", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon front sprites, + 8 = Bulbasaur.
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonShinyPal", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon normal palettes, + 8 = Bulbasaur.
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Image)

                ReDim Temp(&HFFF)
                fs.Position = pOffset
                pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Palette15)
            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 64, 128, ShowBackcolor)
        GetShinyAnimationPokemonPicToBitmap = bSprite

    End Function

    Public Function GetAnimationPicToByteArray(ByVal index As Integer) As Byte()
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonAnimations", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon front sprites, + 8 = Bulbasaur.
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonNormalPal", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon normal palettes, + 8 = Bulbasaur.
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Image)

                ReDim Temp(&HFFF)
                fs.Position = pOffset
                pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Palette15)
            End Using
        End Using
        bSprite = LoadSprite(Image, Palette32, 64, 128, 0)
        LoadBitmapFromArray(Image, Palette32, bSprite, 64, 128)
        'bSprite = LoadSprite(Image, Palette32, 64, 64, 0)
        GetAnimationPicToByteArray = SaveBitmapToArray(bSprite, Palette32)

    End Function

    Public Sub GetAndDrawAnimationPokemonPicShiny(ByVal picBox As PictureBox, ByVal index As Integer)
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonAnimations", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon front sprites, + 8 = Bulbasaur.
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonShinyPal", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon normal palettes, + 8 = Bulbasaur.
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Image)

                ReDim Temp(&HFFF)
                fs.Position = pOffset
                pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Palette15)
            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 64, 128, GetString(AppPath & "GBAPGESettings.ini", "Settings", "TransparentImages", "0"))
        picBox.Image = bSprite
        picBox.Refresh()

    End Sub

    Public Sub GetAndDrawShadowAnimationPokemonPic(ByVal picBox As PictureBox, ByVal index As Integer)
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "ShadowFronts", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon front sprites, + 8 = Bulbasaur.
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "ShadowPals", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon normal palettes, + 8 = Bulbasaur.
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Image)

                ReDim Temp(&HFFF)
                fs.Position = pOffset
                pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Palette15)
            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 64, 128, GetString(AppPath & "GBAPGESettings.ini", "Settings", "TransparentImages", "0"))
        picBox.Image = bSprite
        picBox.Refresh()

    End Sub

    Public Sub GetAndDrawBackShadowPokemonPic(ByVal picBox As PictureBox, ByVal index As Integer)
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "ShadowBacks", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon front sprites, + 8 = Bulbasaur.
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "ShadowPals", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon normal palettes, + 8 = Bulbasaur.
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Image)

                ReDim Temp(&HFFF)
                fs.Position = pOffset
                pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Palette15)
            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 64, 64, GetString(AppPath & "GBAPGESettings.ini", "Settings", "TransparentImages", "0"))
        picBox.Image = bSprite
        picBox.Refresh()

    End Sub

    Public Sub GetAndDrawShadowFrontPokemonPic(ByVal picBox As PictureBox, ByVal index As Integer)
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "ShadowFronts", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon front sprites, + 8 = Bulbasaur.
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "ShadowPals", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon normal palettes, + 8 = Bulbasaur.
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Image)

                ReDim Temp(&HFFF)
                fs.Position = pOffset
                pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Palette15)
            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 64, 64, GetString(AppPath & "GBAPGESettings.ini", "Settings", "TransparentImages", "0"))
        picBox.Image = bSprite
        picBox.Refresh()

    End Sub

    Public Function LoadPalette(ByVal Bits() As Byte) As Color()
        Dim Temp As UShort
        Dim Colors(15) As Color
        Dim C1 As Byte
        Dim C2 As Byte
        Dim R As UShort, G As UShort, B As UShort
        Dim i As Byte

        For i = 0 To &H1F Step 2
            C1 = Bits(i)
            C2 = Bits(i + 1)
            Temp = C2 * &H100 + C1

            R = (Temp And &H1F) * &H8
            G = (Temp And &H3E0) / &H4
            B = (Temp And &H7C00) / &H80

            Colors(i / 2) = Color.FromArgb(&HFF, R, G, B)
        Next

        LoadPalette = Colors
    End Function

    Public Function LoadSprite(ByRef Bits() As Byte, ByVal Palette() As Color, Optional ByVal Width As Integer = 64, Optional ByVal Height As Integer = 64, Optional ByVal ShowBackColor As Boolean = True) As Bitmap
        On Error GoTo ErrorHandle
        Dim x1 As Integer, y1 As Integer
        Dim x2 As Integer, y2 As Integer
        Dim bmpTiles As New Bitmap(Width, Height)
        Dim Temp As Byte
        Dim i As Integer

        For y1 = 0 To Height - 8 Step 8
            For x1 = 0 To Width - 8 Step 8
                For y2 = 0 To 7
                    For x2 = 0 To 7 Step 2
                        Temp = Bits(i)
                        If ShowBackColor = True Then
                            bmpTiles.SetPixel(x1 + x2 + 1, y1 + y2, Palette((Temp And &HF0) / &H10))
                            bmpTiles.SetPixel(x1 + x2, y1 + y2, Palette(Temp And &HF))
                        Else

                            ' If Temp And &HF0 <> 0 Then
                            If Palette((Temp And &HF0) / &H10) <> Palette(0) Then


                                'MsgBox(Temp And &HF0)
                                ' MsgBox("hit")
                                bmpTiles.SetPixel(x1 + x2 + 1, y1 + y2, Palette((Temp And &HF0) / &H10))

                            End If
                            If Palette((Temp And &HF)) <> Palette(0) Then
                                ' If Temp And &HF <> 0 Then
                                '  MsgBox("hit")

                                bmpTiles.SetPixel(x1 + x2, y1 + y2, Palette((Temp And &HF)))

                            End If
                        End If
                        i = i + 1
                    Next
                Next
            Next
        Next

        LoadSprite = bmpTiles
ErrorHandle:
    End Function

    Public Sub GetAndDrawPokemonIconPic(ByVal picBox As PictureBox, ByVal index As Integer, ByVal palindex As Integer)
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "IconPointerTable", ""), System.Globalization.NumberStyles.HexNumber) + ((index * 4))
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "IconPals", ""), System.Globalization.NumberStyles.HexNumber) + (palindex * 32)
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                'LZ77UnComp(Temp, Image)
                Image = Temp

                ReDim Temp(&HFFF)
                'fs.Position = pOffset
                'pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                'LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Temp)
            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 32, 64, GetString(AppPath & "GBAPGESettings.ini", "Settings", "TransparentImages", "0"))
        picBox.Image = bSprite
        picBox.Refresh()

    End Sub

    Public Function GetAndDrawPokemonIconToBitmap(ByVal index As Integer, ByVal palindex As Integer, Optional ShowBackColor As Boolean = False) As Bitmap

        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "IconPointerTable", ""), System.Globalization.NumberStyles.HexNumber) + ((index * 4))
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "IconPals", ""), System.Globalization.NumberStyles.HexNumber) + (palindex * 32)
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                'LZ77UnComp(Temp, Image)
                Image = Temp

                ReDim Temp(&HFFF)
                'fs.Position = pOffset
                'pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                'LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Temp)
            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 32, 64, ShowBackColor)
        GetAndDrawPokemonIconToBitmap = bSprite

    End Function

    Public Function Load2BPSprite16By16(ByRef Bits() As Byte, ByVal Palette() As Color) As Bitmap

        Dim bmpTiles As New Bitmap(16, 16)

        Dim sideways As Integer = 0
        Dim updown As Integer = 0
        Dim bittrack As Integer = 0
        Dim bytetrack As Integer = 0
        Dim curbit As String
        Dim bitsarray As BitArray
        Dim CurSquare As Integer = 0

        While updown < 16
            While sideways < 8

                bitsarray = New BitArray({Bits(bytetrack)})

                curbit = bitsarray(bittrack)

                If curbit = "False" Then

                    If CurSquare = 0 Then

                        bmpTiles.SetPixel(sideways, updown, Palette(0))

                    End If

                    If CurSquare = 1 Then

                        bmpTiles.SetPixel((CurSquare * 8) + sideways, updown - (CurSquare * 8), Palette(0))

                    End If

                    If CurSquare = 2 Then

                        bmpTiles.SetPixel(sideways, updown + (8), Palette(0))

                    End If

                    If CurSquare = 3 Then

                        bmpTiles.SetPixel((8) + sideways, updown, Palette(0))

                    End If

                ElseIf curbit = "True"

                    If CurSquare = 0 Then

                        bmpTiles.SetPixel(sideways, updown, Palette(1))

                    End If

                    If CurSquare = 1 Then

                        bmpTiles.SetPixel((CurSquare * 8) + sideways, updown - (CurSquare * 8), Palette(1))

                    End If

                    If CurSquare = 2 Then

                        bmpTiles.SetPixel(sideways, updown + (8), Palette(1))

                    End If

                    If CurSquare = 3 Then

                        bmpTiles.SetPixel((8) + sideways, updown, Palette(1))

                    End If

                End If
                bittrack = bittrack + 1
                If bittrack = 8 Then
                    bittrack = 0
                    bytetrack = bytetrack + 1
                End If

                sideways = sideways + 1
            End While
            sideways = 0

            If updown = 7 And CurSquare = 0 Then
                CurSquare = CurSquare + 1
            End If

            If updown = 15 And CurSquare = 1 Then
                CurSquare = CurSquare + 1
                updown = -1
            End If

            If updown = 7 And CurSquare = 2 Then
                CurSquare = CurSquare + 1

            End If

            If updown = 15 And CurSquare = 3 Then
                CurSquare = CurSquare + 1
            End If

            updown = updown + 1

        End While

        Load2BPSprite16By16 = bmpTiles
ErrorHandle:
    End Function

    Public Sub GetAndDrawPokemonFootPrint(ByVal picBox As PictureBox, ByVal index As Integer)
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "FootPrintTable", ""), System.Globalization.NumberStyles.HexNumber) + ((index * 4))
        Dim Temp(&HFF) As Byte
        Dim Image(&HFF) As Byte
        Dim Palette32(1) As Color
        Dim bSprite As Bitmap

        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFF)
                Image = Temp
            End Using
        End Using

        Palette32(0) = Color.Transparent
        Palette32(1) = Color.Black

        bSprite = Load2BPSprite16By16(Image, Palette32)
        picBox.Image = bSprite
        picBox.Refresh()

    End Sub

    Public Function GetPokemonFootPrintToBitmap(ByVal index As Integer) As Bitmap
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "FootPrintTable", ""), System.Globalization.NumberStyles.HexNumber) + ((index * 4))
        Dim Temp(&HFF) As Byte
        Dim Image(&HFF) As Byte
        Dim Palette32(1) As Color
        Dim bSprite As Bitmap

        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFF)
                Image = Temp
            End Using
        End Using

        Palette32(0) = Color.Transparent
        Palette32(1) = Color.Black

        bSprite = Load2BPSprite16By16(Image, Palette32)
        GetPokemonFootPrintToBitmap = bSprite

    End Function

    Public Sub GetAndDrawTrainerPicBLACK(ByVal picBox As PictureBox, ByVal index As Integer)
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "TrainerImageTable", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8)
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "TrainerPaletteTable", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8)
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Image)

                ReDim Temp(&HFFF)
                fs.Position = pOffset
                pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Palette15)
                Palette32(1) = Color.Black
                Palette32(2) = Color.Black
                Palette32(3) = Color.Black
                Palette32(4) = Color.Black
                Palette32(5) = Color.Black
                Palette32(6) = Color.Black
                Palette32(7) = Color.Black
                Palette32(8) = Color.Black
                Palette32(9) = Color.Black
                Palette32(10) = Color.Black
                Palette32(11) = Color.Black
                Palette32(12) = Color.Black
                Palette32(13) = Color.Black
                Palette32(14) = Color.Black
                Palette32(15) = Color.Black
            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 64, 64, GetString(AppPath & "GBAPGESettings.ini", "Settings", "TransparentImages", "0"))
        picBox.Image = bSprite
        picBox.Refresh()

    End Sub

    Public Sub GetAndDrawTrainerPic(ByVal picBox As PictureBox, ByVal index As Integer)
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "TrainerImageTable", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8)
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "TrainerPaletteTable", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8)
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Image)

                ReDim Temp(&HFFF)
                fs.Position = pOffset
                pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Palette15)

            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 64, 64, GetString(AppPath & "GBAPGESettings.ini", "Settings", "TransparentImages", "0"))
        picBox.Image = bSprite
        picBox.Refresh()

    End Sub

    Public Function GetAndDrawTrainerSpriteToBitmap(ByVal index As Integer, ByVal palindex As Integer, Optional ShowBackColor As Boolean = False) As Bitmap

        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "TrainerImageTable", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8)
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "TrainerPaletteTable", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8)
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Image)

                ReDim Temp(&HFFF)
                fs.Position = pOffset
                pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Palette15)

            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 64, 64, ShowBackColor)
        GetAndDrawTrainerSpriteToBitmap = bSprite

    End Function

    Public Function MapTilesCompressedtoHexString(ByVal ImageOffset As Integer, ByVal PalOffset As Integer) As String



        Dim sOffset As Integer = ImageOffset
        Dim pOffset As Integer = PalOffset
        Dim Temp(&HFFFF) As Byte
        Dim Image(&H4000) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFFF)
                LZ77UnComp(Temp, Image)

                ReDim Temp(&HFFFF)
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFFF)
                'LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Temp)
            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 128, 256, True)



        MapTilesCompressedtoHexString = ByteArrayToHexString(CompressBytes(Image))

    End Function

    Public Function MapTilesCompressedtoHexStringFRPrim(ByVal ImageOffset As Integer, ByVal PalOffset As Integer) As String



        Dim sOffset As Integer = ImageOffset
        Dim pOffset As Integer = PalOffset
        Dim Temp(&HFFFF) As Byte
        Dim Image(&H5000) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFFF)
                LZ77UnComp(Temp, Image)

                ReDim Temp(&HFFFF)
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFFF)
                'LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Temp)
            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 128, 320, True)


        MapTilesCompressedtoHexStringFRPrim = ByteArrayToHexString(CompressBytes(Image))

    End Function

    Public Function MapTilesCompressedtoHexStringFRSec(ByVal ImageOffset As Integer, ByVal PalOffset As Integer) As String



        Dim sOffset As Integer = ImageOffset
        Dim pOffset As Integer = PalOffset
        Dim Temp(&HFFFF) As Byte
        Dim Image(&H3000) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFFF)
                LZ77UnComp(Temp, Image)

                ReDim Temp(&HFFFF)
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFFF)
                'LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Temp)
            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 128, 192, True)


        MapTilesCompressedtoHexStringFRSec = ByteArrayToHexString(CompressBytes(Image))

    End Function

    Public Function MapTilesCompressedtoHexStringFRPrim2(ByVal ImageOffset As Integer, ByVal PalOffset As Integer, ByVal tilefile As String, ByVal palfile As String) As String



        Dim sOffset As Integer = ImageOffset
        Dim pOffset As Integer = PalOffset
        Dim Temp(&HFFFF) As Byte
        Dim Image(&H5000 - 1) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(tilefile, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFFF)
                LZ77UnComp(Temp, Image)

            End Using
        End Using

        Using fs As New FileStream(palfile, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)

                ReDim Temp(&HFFFF)
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFFF)
                'LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Temp)
            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 128, 320, True)



        MapTilesCompressedtoHexStringFRPrim2 = ByteArrayToHexString(Image)

    End Function

    Public Function MapTilesCompressedtoHexStringFRSec2(ByVal ImageOffset As Integer, ByVal PalOffset As Integer, ByVal tilefile As String, ByVal palfile As String) As String


        Dim sOffset As Integer = ImageOffset
        Dim pOffset As Integer = PalOffset
        Dim Temp(&HFFFF) As Byte
        Dim Image(&H3000 - 1) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(tilefile, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFFF)
                LZ77UnComp(Temp, Image)

            End Using
        End Using

        Using fs As New FileStream(palfile, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)


                ReDim Temp(&HFFFF)
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFFF)
                'LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Temp)
            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 128, 192, True)


        MapTilesCompressedtoHexStringFRSec2 = ByteArrayToHexString(Image)

    End Function

    Public Function LoadTilesToBitmap(ImgFile As String, Palette32() As Color, IsCompressed As Boolean, ShowBackColor As Boolean) As Bitmap

        Dim sOffset As Integer = 0
        Dim pOffset As Integer = 0
        Dim Temp(&HFFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim bSprite As Bitmap

        Using fs As New FileStream(ImgFile, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFFF)

                If IsCompressed = True Then
                    LZ77UnComp(Temp, Image)
                Else
                    Image = Temp
                End If

            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 128, 256, ShowBackColor)

        LoadTilesToBitmap = bSprite

    End Function

    Public Function LoadSingleTileToBitmap(ImgFile As String, TileNum As Integer, Palette32() As Color, IsCompressed As Boolean, ShowBackColor As Boolean, FlipXY As RotateFlipType) As Bitmap

        Dim sOffset As Integer = 0
        Dim pOffset As Integer = 0
        Dim Temp(&HFFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim bSprite As Bitmap

        Dim TileImg(31) As Byte

        Using fs As New FileStream(ImgFile, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFFF)

                If IsCompressed = True Then
                    LZ77UnComp(Temp, Image)
                Else
                    Image = Temp
                End If

                Array.Copy(Image, TileNum * 32, TileImg, 0, 32)

            End Using
        End Using


        bSprite = LoadSprite(TileImg, Palette32, 8, 8, ShowBackColor)

        bSprite.RotateFlip(FlipXY)

        LoadSingleTileToBitmap = bSprite

    End Function

    Public Function LoadSingleTileToBitmap2(Image() As Byte, TileNum As Integer, Palette32() As Color, ShowBackColor As Boolean, FlipXY As RotateFlipType) As Bitmap

        Dim sOffset As Integer = 0
        Dim pOffset As Integer = 0
        Dim Temp(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim bSprite As Bitmap

        Dim TileImg(31) As Byte

        Array.Copy(Image, TileNum * 32, TileImg, 0, 32)

        bSprite = LoadSprite(TileImg, Palette32, 8, 8, ShowBackColor)

        bSprite.RotateFlip(FlipXY)

        LoadSingleTileToBitmap2 = bSprite

    End Function

    Public Function BufferTileImages(ImgFile1 As String, ImgFile2 As String, IsCompressed As Boolean, IsCompressed2 As Boolean)

        Dim sOffset As Integer = 0
        Dim pOffset As Integer = 0
        Dim Temp(&HFFFF) As Byte

        Using fs As New FileStream(ImgFile1, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFFF)

                If IsCompressed = True Then
                    LZ77UnComp(Temp, TileSet1Image)
                Else
                    TileSet1Image = Temp
                End If

            End Using
        End Using

        Using fs As New FileStream(ImgFile2, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFFF)

                If IsCompressed = True Then
                    LZ77UnComp(Temp, TileSet2Image)
                Else
                    TileSet2Image = Temp
                End If


            End Using
        End Using

        Return 1

    End Function

    Public Function BlockToBitmap(BlockSet As String, Image1 As String, Image2 As String, BlockNum As Integer) As Bitmap

        Dim output As New Bitmap(16, 16)

        Dim loopvar As Integer = 0

        Dim tileimage As String = ""

        Dim tilenum As Integer = 0
        Dim palnum As Integer = 0
        Dim Yflip As Integer
        Dim Xflip As Integer
        Dim Curbytesbin As String = ""
        Dim Flips As RotateFlipType


        While loopvar < 8

            If BlockNum < 512 Then

                Curbytesbin = VB.Right("0000000000000000" & Convert.ToString(Int32.Parse(ReverseHEX(ReadHEX(BlockSet, BlockNum * 16 + (loopvar * 2), 2)), System.Globalization.NumberStyles.HexNumber), 2), 16)

            Else

                Curbytesbin = VB.Right("0000000000000000" & Convert.ToString(Int32.Parse(ReverseHEX(ReadHEX(BlockSet, (BlockNum - 512) * 16 + (loopvar * 2), 2)), System.Globalization.NumberStyles.HexNumber), 2), 16)

            End If

            tilenum = Convert.ToInt32(Curbytesbin.Remove(0, 6), 2)
            palnum = Convert.ToInt32(Curbytesbin.Substring(0, 4), 2)
            Yflip = Convert.ToInt32(Curbytesbin.Substring(4, 1), 2)
            Xflip = Convert.ToInt32(Curbytesbin.Substring(5, 1), 2)

            If palnum > 12 Then
                palnum = 12
            End If

            If Yflip = 0 And Xflip = 0 Then

                Flips = RotateFlipType.RotateNoneFlipNone

            ElseIf Yflip = 0 And Xflip = 1 Then

                Flips = RotateFlipType.RotateNoneFlipX

            ElseIf Yflip = 1 And Xflip = 0 Then

                Flips = RotateFlipType.RotateNoneFlipY

            ElseIf Yflip = 1 And Xflip = 1 Then

                Flips = RotateFlipType.RotateNoneFlipXY

            End If


            If tilenum < 512 Then

                If loopvar = 0 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet1Image, tilenum, TilePals(palnum), True, Flips), output, 0, 0, 0, 0, 8, 8)

                ElseIf loopvar = 1 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet1Image, tilenum, TilePals(palnum), True, Flips), output, 8, 0, 0, 0, 8, 8)

                ElseIf loopvar = 2 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet1Image, tilenum, TilePals(palnum), True, Flips), output, 0, 8, 0, 0, 8, 8)

                ElseIf loopvar = 3 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet1Image, tilenum, TilePals(palnum), True, Flips), output, 8, 8, 0, 0, 8, 8)

                ElseIf loopvar = 4 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet1Image, tilenum, TilePals(palnum), False, Flips), output, 0, 0, 0, 0, 8, 8)

                ElseIf loopvar = 5 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet1Image, tilenum, TilePals(palnum), False, Flips), output, 8, 0, 0, 0, 8, 8)

                ElseIf loopvar = 6 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet1Image, tilenum, TilePals(palnum), False, Flips), output, 0, 8, 0, 0, 8, 8)

                ElseIf loopvar = 7 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet1Image, tilenum, TilePals(palnum), False, Flips), output, 8, 8, 0, 0, 8, 8)

                End If


            Else

                tileimage = Image2


                If loopvar = 0 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet2Image, tilenum - 512, TilePals(palnum), True, Flips), output, 0, 0, 0, 0, 8, 8)

                ElseIf loopvar = 1 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet2Image, tilenum - 512, TilePals(palnum), True, Flips), output, 8, 0, 0, 0, 8, 8)

                ElseIf loopvar = 2 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet2Image, tilenum - 512, TilePals(palnum), True, Flips), output, 0, 8, 0, 0, 8, 8)

                ElseIf loopvar = 3 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet2Image, tilenum - 512, TilePals(palnum), True, Flips), output, 8, 8, 0, 0, 8, 8)

                ElseIf loopvar = 4 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet2Image, tilenum - 512, TilePals(palnum), False, Flips), output, 0, 0, 0, 0, 8, 8)

                ElseIf loopvar = 5 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet2Image, tilenum - 512, TilePals(palnum), False, Flips), output, 8, 0, 0, 0, 8, 8)

                ElseIf loopvar = 6 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet2Image, tilenum - 512, TilePals(palnum), False, Flips), output, 0, 8, 0, 0, 8, 8)

                ElseIf loopvar = 7 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet2Image, tilenum - 512, TilePals(palnum), False, Flips), output, 8, 8, 0, 0, 8, 8)

                End If

            End If



            loopvar = loopvar + 1
        End While

        BlockToBitmap = output

    End Function

    Public Function BlockBottomToBitmap(BlockSet As String, Image1 As String, Image2 As String, BlockNum As Integer) As Bitmap

        Dim output As New Bitmap(16, 16)

        Dim loopvar As Integer = 0

        Dim tileimage As String = ""

        Dim tilenum As Integer = 0
        Dim palnum As Integer = 0
        Dim Yflip As Integer
        Dim Xflip As Integer
        Dim Curbytesbin As String = ""
        Dim Flips As RotateFlipType


        While loopvar < 4

            If BlockNum < 512 Then

                Curbytesbin = VB.Right("0000000000000000" & Convert.ToString(Int32.Parse(ReverseHEX(ReadHEX(BlockSet, BlockNum * 16 + (loopvar * 2), 2)), System.Globalization.NumberStyles.HexNumber), 2), 16)

            Else

                Curbytesbin = VB.Right("0000000000000000" & Convert.ToString(Int32.Parse(ReverseHEX(ReadHEX(BlockSet, (BlockNum - 512) * 16 + (loopvar * 2), 2)), System.Globalization.NumberStyles.HexNumber), 2), 16)

            End If

            tilenum = Convert.ToInt32(Curbytesbin.Remove(0, 6), 2)
            palnum = Convert.ToInt32(Curbytesbin.Substring(0, 4), 2)
            Yflip = Convert.ToInt32(Curbytesbin.Substring(4, 1), 2)
            Xflip = Convert.ToInt32(Curbytesbin.Substring(5, 1), 2)

            If palnum > 12 Then
                palnum = 12
            End If

            If Yflip = 0 And Xflip = 0 Then

                Flips = RotateFlipType.RotateNoneFlipNone

            ElseIf Yflip = 0 And Xflip = 1 Then

                Flips = RotateFlipType.RotateNoneFlipX

            ElseIf Yflip = 1 And Xflip = 0 Then

                Flips = RotateFlipType.RotateNoneFlipY

            ElseIf Yflip = 1 And Xflip = 1 Then

                Flips = RotateFlipType.RotateNoneFlipXY

            End If


            If tilenum < 512 Then

                If loopvar = 0 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet1Image, tilenum, TilePals(palnum), True, Flips), output, 0, 0, 0, 0, 8, 8)

                ElseIf loopvar = 1 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet1Image, tilenum, TilePals(palnum), True, Flips), output, 8, 0, 0, 0, 8, 8)

                ElseIf loopvar = 2 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet1Image, tilenum, TilePals(palnum), True, Flips), output, 0, 8, 0, 0, 8, 8)

                ElseIf loopvar = 3 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet1Image, tilenum, TilePals(palnum), True, Flips), output, 8, 8, 0, 0, 8, 8)

                ElseIf loopvar = 4 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet1Image, tilenum, TilePals(palnum), False, Flips), output, 0, 0, 0, 0, 8, 8)

                ElseIf loopvar = 5 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet1Image, tilenum, TilePals(palnum), False, Flips), output, 8, 0, 0, 0, 8, 8)

                ElseIf loopvar = 6 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet1Image, tilenum, TilePals(palnum), False, Flips), output, 0, 8, 0, 0, 8, 8)

                ElseIf loopvar = 7 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet1Image, tilenum, TilePals(palnum), False, Flips), output, 8, 8, 0, 0, 8, 8)

                End If


            Else

                tileimage = Image2


                If loopvar = 0 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet2Image, tilenum - 512, TilePals(palnum), True, Flips), output, 0, 0, 0, 0, 8, 8)

                ElseIf loopvar = 1 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet2Image, tilenum - 512, TilePals(palnum), True, Flips), output, 8, 0, 0, 0, 8, 8)

                ElseIf loopvar = 2 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet2Image, tilenum - 512, TilePals(palnum), True, Flips), output, 0, 8, 0, 0, 8, 8)

                ElseIf loopvar = 3 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet2Image, tilenum - 512, TilePals(palnum), True, Flips), output, 8, 8, 0, 0, 8, 8)

                ElseIf loopvar = 4 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet2Image, tilenum - 512, TilePals(palnum), False, Flips), output, 0, 0, 0, 0, 8, 8)

                ElseIf loopvar = 5 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet2Image, tilenum - 512, TilePals(palnum), False, Flips), output, 8, 0, 0, 0, 8, 8)

                ElseIf loopvar = 6 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet2Image, tilenum - 512, TilePals(palnum), False, Flips), output, 0, 8, 0, 0, 8, 8)

                ElseIf loopvar = 7 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet2Image, tilenum - 512, TilePals(palnum), False, Flips), output, 8, 8, 0, 0, 8, 8)

                End If

            End If



            loopvar = loopvar + 1
        End While

        BlockBottomToBitmap = output

    End Function

    Public Function BlockTopToBitmap(BlockSet As String, Image1 As String, Image2 As String, BlockNum As Integer) As Bitmap

        Dim output As New Bitmap(16, 16)

        Dim loopvar As Integer = 4

        Dim tileimage As String = ""

        Dim tilenum As Integer = 0
        Dim palnum As Integer = 0
        Dim Yflip As Integer
        Dim Xflip As Integer
        Dim Curbytesbin As String = ""
        Dim Flips As RotateFlipType


        While loopvar < 8

            If BlockNum < 512 Then

                Curbytesbin = VB.Right("0000000000000000" & Convert.ToString(Int32.Parse(ReverseHEX(ReadHEX(BlockSet, BlockNum * 16 + (loopvar * 2), 2)), System.Globalization.NumberStyles.HexNumber), 2), 16)

            Else

                Curbytesbin = VB.Right("0000000000000000" & Convert.ToString(Int32.Parse(ReverseHEX(ReadHEX(BlockSet, (BlockNum - 512) * 16 + (loopvar * 2), 2)), System.Globalization.NumberStyles.HexNumber), 2), 16)

            End If

            tilenum = Convert.ToInt32(Curbytesbin.Remove(0, 6), 2)
            palnum = Convert.ToInt32(Curbytesbin.Substring(0, 4), 2)
            Yflip = Convert.ToInt32(Curbytesbin.Substring(4, 1), 2)
            Xflip = Convert.ToInt32(Curbytesbin.Substring(5, 1), 2)

            If palnum > 12 Then
                palnum = 12
            End If

            If Yflip = 0 And Xflip = 0 Then

                Flips = RotateFlipType.RotateNoneFlipNone

            ElseIf Yflip = 0 And Xflip = 1 Then

                Flips = RotateFlipType.RotateNoneFlipX

            ElseIf Yflip = 1 And Xflip = 0 Then

                Flips = RotateFlipType.RotateNoneFlipY

            ElseIf Yflip = 1 And Xflip = 1 Then

                Flips = RotateFlipType.RotateNoneFlipXY

            End If


            If tilenum < 512 Then

                If loopvar = 0 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet1Image, tilenum, TilePals(palnum), True, Flips), output, 0, 0, 0, 0, 8, 8)

                ElseIf loopvar = 1 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet1Image, tilenum, TilePals(palnum), True, Flips), output, 8, 0, 0, 0, 8, 8)

                ElseIf loopvar = 2 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet1Image, tilenum, TilePals(palnum), True, Flips), output, 0, 8, 0, 0, 8, 8)

                ElseIf loopvar = 3 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet1Image, tilenum, TilePals(palnum), True, Flips), output, 8, 8, 0, 0, 8, 8)

                ElseIf loopvar = 4 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet1Image, tilenum, TilePals(palnum), True, Flips), output, 0, 0, 0, 0, 8, 8)

                ElseIf loopvar = 5 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet1Image, tilenum, TilePals(palnum), True, Flips), output, 8, 0, 0, 0, 8, 8)

                ElseIf loopvar = 6 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet1Image, tilenum, TilePals(palnum), True, Flips), output, 0, 8, 0, 0, 8, 8)

                ElseIf loopvar = 7 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet1Image, tilenum, TilePals(palnum), True, Flips), output, 8, 8, 0, 0, 8, 8)

                End If


            Else

                tileimage = Image2


                If loopvar = 0 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet2Image, tilenum - 512, TilePals(palnum), True, Flips), output, 0, 0, 0, 0, 8, 8)

                ElseIf loopvar = 1 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet2Image, tilenum - 512, TilePals(palnum), True, Flips), output, 8, 0, 0, 0, 8, 8)

                ElseIf loopvar = 2 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet2Image, tilenum - 512, TilePals(palnum), True, Flips), output, 0, 8, 0, 0, 8, 8)

                ElseIf loopvar = 3 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet2Image, tilenum - 512, TilePals(palnum), True, Flips), output, 8, 8, 0, 0, 8, 8)

                ElseIf loopvar = 4 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet2Image, tilenum - 512, TilePals(palnum), True, Flips), output, 0, 0, 0, 0, 8, 8)

                ElseIf loopvar = 5 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet2Image, tilenum - 512, TilePals(palnum), True, Flips), output, 8, 0, 0, 0, 8, 8)

                ElseIf loopvar = 6 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet2Image, tilenum - 512, TilePals(palnum), True, Flips), output, 0, 8, 0, 0, 8, 8)

                ElseIf loopvar = 7 Then

                    BitmapBLT(LoadSingleTileToBitmap2(TileSet2Image, tilenum - 512, TilePals(palnum), True, Flips), output, 8, 8, 0, 0, 8, 8)

                End If

            End If



            loopvar = loopvar + 1
        End While

        BlockTopToBitmap = output

    End Function

    Public Function MapDatatoBitmap(BlockImage As Bitmap, MapDataFile As String, MapHeight As Integer, MapWidth As Integer) As Bitmap

        Dim OutputImg As New Bitmap(MapWidth * 16, MapHeight * 16)
        Dim OutputImg2 As New Bitmap(MapWidth * 16, MapHeight * 16)
        Dim OutputImg3 As New Bitmap(MapWidth * 16, MapHeight * 16)
        Dim numOfTiles As Integer = MapWidth * MapHeight
        Dim loopvar As Integer = 0

        Dim across As Integer = 0
        Dim down As Integer = 0

        Dim curbytesbin As String = ""
        Dim curtile As Integer = 0
        Dim curperm As Integer = 0
        Dim maptiles As String = ""
        Dim MovementPerm As String = ""

        Dim PermissionsBitMap As New Bitmap(AppPath & "img\moveperms.png", True)

        While loopvar < numOfTiles

            curbytesbin = VB.Right("0000000000000000" & Convert.ToString(Int32.Parse(ReverseHEX(ReadHEX(MapDataFile, loopvar * 2, 2)), System.Globalization.NumberStyles.HexNumber), 2), 16)

            curtile = Convert.ToInt32(curbytesbin.Substring(6, 10), 2)
            curperm = Convert.ToInt32(curbytesbin.Substring(0, 6), 2)

            maptiles = maptiles & curtile & ","
            MovementPerm = MovementPerm & curperm & ","

            BitmapBLT(BlockImage, OutputImg, across * 16, down * 16, TileNumToX(curtile) * 16, TileNumToY(curtile) * 16, 16, 16)
            BitmapBLT(BlockImage, OutputImg3, across * 16, down * 16, TileNumToX(curtile) * 16, TileNumToY(curtile) * 16, 16, 16)

            BitmapBLT(PermissionsBitMap, OutputImg2, across * 16, down * 16, 0, curperm * 16, 16, 16)

            across = across + 1

            If across = MapWidth Then
                across = 0
                down = down + 1
            End If

            loopvar = loopvar + 1
        End While

        MapTilesArray = maptiles.Split(",")
        MapPermsArray = MovementPerm.Split(",")

        MapWithPermissions = New Bitmap(MapWidth * 16, MapHeight * 16)

        Dim g As Graphics = Graphics.FromImage(OutputImg)
        g.DrawImage(OutputImg2, 0, 0)

        MapWithPermissions = OutputImg

        Return OutputImg3

    End Function

    Public Function BorderDatatoBitmap(BlockImage As Bitmap, MapDataFile As String, MapHeight As Integer, MapWidth As Integer) As Bitmap

        Dim OutputImg As New Bitmap(MapWidth * 16, MapHeight * 16)
        Dim OutputImg2 As New Bitmap(MapWidth * 16, MapHeight * 16)
        Dim OutputImg3 As New Bitmap(MapWidth * 16, MapHeight * 16)
        Dim numOfTiles As Integer = MapWidth * MapHeight
        Dim loopvar As Integer = 0

        Dim across As Integer = 0
        Dim down As Integer = 0

        Dim curbytesbin As String = ""
        Dim curtile As Integer = 0
        Dim curperm As Integer = 0
        Dim maptiles As String = ""
        Dim MovementPerm As String = ""

        Dim PermissionsBitMap As New Bitmap(AppPath & "img\moveperms.png", True)

        While loopvar < numOfTiles

            curbytesbin = VB.Right("0000000000000000" & Convert.ToString(Int32.Parse(ReverseHEX(ReadHEX(MapDataFile, loopvar * 2, 2)), System.Globalization.NumberStyles.HexNumber), 2), 16)

            curtile = Convert.ToInt32(curbytesbin.Substring(6, 10), 2)
            curperm = Convert.ToInt32(curbytesbin.Substring(0, 6), 2)

            maptiles = maptiles & curtile & ","
            MovementPerm = MovementPerm & curperm & ","

            BitmapBLT(BlockImage, OutputImg, across * 16, down * 16, TileNumToX(curtile) * 16, TileNumToY(curtile) * 16, 16, 16)
            BitmapBLT(BlockImage, OutputImg3, across * 16, down * 16, TileNumToX(curtile) * 16, TileNumToY(curtile) * 16, 16, 16)

            BitmapBLT(PermissionsBitMap, OutputImg2, across * 16, down * 16, 0, curperm * 16, 16, 16)

            across = across + 1

            If across = MapWidth Then
                across = 0
                down = down + 1
            End If

            loopvar = loopvar + 1
        End While

        BorderTilesArray = maptiles.Split(",")
        BorderPermsArray = MovementPerm.Split(",")

        BorderWithPermissions = New Bitmap(MapWidth * 16, MapHeight * 16)

        Dim g As Graphics = Graphics.FromImage(OutputImg)
        g.DrawImage(OutputImg2, 0, 0)

        BorderWithPermissions = OutputImg

        Return OutputImg3

    End Function

    Public Function TileNumToX(tilenumber As Integer) As Integer

        While tilenumber > 7

            tilenumber = tilenumber - 8

        End While

        Return tilenumber

    End Function

    Public Function TileNumToY(tilenumber As Integer) As Integer

        Dim counter As Integer = 0

        While tilenumber > 7

            tilenumber = tilenumber - 8

            counter = counter + 1

        End While

        Return counter

    End Function

End Module
