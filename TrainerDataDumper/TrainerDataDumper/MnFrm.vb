Imports System.IO

Public Class MnFrm
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        fileOpenDialog.FileName = ""
        fileOpenDialog.CheckFileExists = True

        ' Check to ensure that the selected path exists.  Dialog box displays 
        ' a warning otherwise.
        fileOpenDialog.CheckPathExists = True

        ' Get or set default extension. Doesn't include the leading ".".
        fileOpenDialog.DefaultExt = "GBA"

        ' Return the file referenced by a link? If False, simply returns the selected link
        ' file. If True, returns the file linked to the LNK file.
        fileOpenDialog.DereferenceLinks = True

        ' Just as in VB6, use a set of pairs of filters, separated with "|". Each 
        ' pair consists of a description|file spec. Use a "|" between pairs. No need to put a
        ' trailing "|". You can set the FilterIndex property as well, to select the default
        ' filter. The first filter is numbered 1 (not 0). The default is 1. 
        fileOpenDialog.Filter =
            "(*.gba)|*.gba*"

        fileOpenDialog.Multiselect = False

        ' Restore the original directory when done selecting
        ' a file? If False, the current directory changes
        ' to the directory in which you selected the file.
        ' Set this to True to put the current folder back
        ' where it was when you started.
        ' The default is False.
        '.RestoreDirectory = False

        ' Show the Help button and Read-Only checkbox?
        fileOpenDialog.ShowHelp = False
        fileOpenDialog.ShowReadOnly = False

        ' Start out with the read-only check box checked?
        ' This only make sense if ShowReadOnly is True.
        fileOpenDialog.ReadOnlyChecked = False

        fileOpenDialog.Title = "Select ROM to open:"

        ' Only accept valid Win32 file names?
        fileOpenDialog.ValidateNames = True


        If fileOpenDialog.ShowDialog = DialogResult.OK Then

            LoadedROM = fileOpenDialog.FileName

            HandleOpenedROM()

        End If
    End Sub

    Private Sub HandleOpenedROM()
        FileNum = FreeFile()

        FileOpen(FileNum, LoadedROM, OpenMode.Binary)
        'Opens the ROM as binary
        FileGet(FileNum, header, &HAD, True)
        header2 = Mid(header, 1, 3)
        header3 = Mid(header, 4, 1)
        FileClose(FileNum)

        'MsgBox(GetINIFileLocation())

        If header2 = "BPR" Or header2 = "BPG" Or header2 = "BPE" Or header2 = "AXP" Or header2 = "AXV" Then
            If header3 = "J" Then

                LoadedROM = ""

                MessageBox.Show("I haven't added Jap support out of pure lazziness. I will though if it get's highly Demanded.")

                End

            Else


            End If
        Else

            LoadedROM = ""

            MessageBox.Show("Not one of the Pokemon games...")

            End

        End If


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        FolderBrowserDialog1.Description = "Select folder to export to:"

        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            Me.Text = "Please wait..."
            Me.UseWaitCursor = True

            Dim OutPutFile As String = ".text" & vbCrLf _
& ".thumb" & vbCrLf _
& ".align 2" & vbCrLf & vbCrLf _
& ".global Trainer_Data" & vbCrLf _
& "Trainer_Data:" & vbCrLf & vbCrLf

            Dim OutPutFile2 As String = ".include ""src/constants/Poke_constants.inc""" & vbCrLf _
            & ".include ""src/constants/Attack_constants.inc""" & vbCrLf _
            & ".include ""src/constants/Item_constants.inc""" & vbCrLf & vbCrLf _
            & ".text" & vbCrLf _
& ".thumb" & vbCrLf _
& ".align 2" & vbCrLf & vbCrLf _
& ".global Trainer_Poke_Data" & vbCrLf _
& "Trainer_Poke_Data:" & vbCrLf & vbCrLf

            Dim offvar As Integer
            'If ((mMain.header2 = "BPR") Or (mMain.header2 = "BPG")) Then

            'ElseIf (mMain.header2 = "BPE") Or ((mMain.header2 = "AXP") Or (mMain.header2 = "AXV")) Then

            'End If

            offvar = Int32.Parse((GetString(GetINIFileLocation(), header, "TrainerTable", "")), System.Globalization.NumberStyles.HexNumber)


            Dim curoff As Integer
            Dim curtype As Integer
            Dim Pokeoff As Integer
            Dim Pokenum As Integer
            Dim LoopVar As Integer

            LoopVar = 0

            While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfTrainers", "")) + 1 = True

                curoff = offvar + (40 * (LoopVar))

                OutPutFile = OutPutFile & "@" & LoopVar & " - " & GetTrainerName(LoopVar) & vbCrLf

                OutPutFile = OutPutFile & ".byte    0x" & ReadHEX(LoadedROM, curoff, 1) & "   @Party Type" & vbCrLf

                curtype = ReadHEX(LoadedROM, curoff, 1)

                OutPutFile = OutPutFile & ".byte    0x" & ReadHEX(LoadedROM, curoff + 1, 1) & "   @Trainer Class" & vbCrLf

                OutPutFile = OutPutFile & ".byte    0x" & ReadHEX(LoadedROM, curoff + 2, 1) & "   @Gender and Music" & vbCrLf

                OutPutFile = OutPutFile & ".byte    0x" & ReadHEX(LoadedROM, curoff + 3, 1) & "   @Trainer Pic" & vbCrLf

                OutPutFile = OutPutFile & ".string    """ & GetTrainerName(LoopVar) & "$"", 12   @Trainer Name" & vbCrLf

                OutPutFile = OutPutFile & ".hword    0x" & ReverseHEX(ReadHEX(LoadedROM, curoff + 16, 2)) & "   @Item 1" & vbCrLf
                OutPutFile = OutPutFile & ".hword    0x" & ReverseHEX(ReadHEX(LoadedROM, curoff + 18, 2)) & "   @Item 2" & vbCrLf
                OutPutFile = OutPutFile & ".hword    0x" & ReverseHEX(ReadHEX(LoadedROM, curoff + 20, 2)) & "   @Item 3" & vbCrLf
                OutPutFile = OutPutFile & ".hword    0x" & ReverseHEX(ReadHEX(LoadedROM, curoff + 22, 2)) & "   @Item 4" & vbCrLf

                OutPutFile = OutPutFile & ".long    0x" & ReverseHEX(ReadHEX(LoadedROM, curoff + 24, 4)) & "   @Double Battle" & vbCrLf

                OutPutFile = OutPutFile & ".long    0x" & ReverseHEX(ReadHEX(LoadedROM, curoff + 28, 4)) & "   @AI flag" & vbCrLf

                Pokenum = (ReadHEX(LoadedROM, curoff + 32, 1))

                OutPutFile = OutPutFile & ".long    0x" & (ReadHEX(LoadedROM, curoff + 32, 1)) & "   @Number Of Pokemon" & vbCrLf

                'OutPutFile = OutPutFile & ".long    0x" & ReverseHEX(ReadHEX(LoadedROM, curoff + 36, 4)) & "   @Pointer to Pokemon" & vbCrLf

                Pokeoff = Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, curoff + 36, 4)), System.Globalization.NumberStyles.HexNumber) - &H8000000

                OutPutFile = OutPutFile & ".long    Trainer" & LoopVar & "Pokes   @Pointer to Pokemon" & vbCrLf

                OutPutFile = OutPutFile & vbCrLf

                OutPutFile2 = OutPutFile2 & ".global Trainer" & LoopVar & "Pokes" & vbCrLf
                OutPutFile2 = OutPutFile2 & "Trainer" & LoopVar & "Pokes:" & vbCrLf

                Dim pokeloop As Integer = 0

                If curtype = 0 Then

                    While pokeloop < Pokenum

                        OutPutFile2 = OutPutFile2 & ".hword 0x" & ReverseHEX(ReadHEX(LoadedROM, Pokeoff + 0 + (pokeloop * 8), 2)) & "  @EVs" & vbCrLf
                        OutPutFile2 = OutPutFile2 & ".hword " & Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, Pokeoff + 2 + (pokeloop * 8), 2)), System.Globalization.NumberStyles.HexNumber) & "  @Level" & vbCrLf
                        OutPutFile2 = OutPutFile2 & ".hword POKE_" & GetPokemonName(Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, Pokeoff + 4 + (pokeloop * 8), 2)), System.Globalization.NumberStyles.HexNumber)) & "  @Species" & vbCrLf
                        OutPutFile2 = OutPutFile2 & ".hword 0" & "  @Filler" & vbCrLf

                        OutPutFile2 = OutPutFile2 & vbCrLf
                        pokeloop = pokeloop + 1
                    End While


                ElseIf curtype = 1 Then

                    While pokeloop < Pokenum

                        OutPutFile2 = OutPutFile2 & ".hword 0x" & ReverseHEX(ReadHEX(LoadedROM, Pokeoff + 0 + (pokeloop * 16), 2)) & "  @EVs" & vbCrLf
                        OutPutFile2 = OutPutFile2 & ".hword " & Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, Pokeoff + 2 + (pokeloop * 16), 2)), System.Globalization.NumberStyles.HexNumber) & "  @Level" & vbCrLf
                        OutPutFile2 = OutPutFile2 & ".hword POKE_" & GetPokemonName(Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, Pokeoff + 4 + (pokeloop * 16), 2)), System.Globalization.NumberStyles.HexNumber)) & "  @Species" & vbCrLf
                        OutPutFile2 = OutPutFile2 & ".hword " & Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, Pokeoff + 6 + (pokeloop * 16), 2)), System.Globalization.NumberStyles.HexNumber) & "  @Move 1" & vbCrLf
                        OutPutFile2 = OutPutFile2 & ".hword " & Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, Pokeoff + 8 + (pokeloop * 16), 2)), System.Globalization.NumberStyles.HexNumber) & "  @Move 2" & vbCrLf
                        OutPutFile2 = OutPutFile2 & ".hword " & Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, Pokeoff + 10 + (pokeloop * 16), 2)), System.Globalization.NumberStyles.HexNumber) & "  @Move 3" & vbCrLf
                        OutPutFile2 = OutPutFile2 & ".hword " & Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, Pokeoff + 12 + (pokeloop * 16), 2)), System.Globalization.NumberStyles.HexNumber) & "  @Move 4" & vbCrLf
                        OutPutFile2 = OutPutFile2 & ".hword 0" & "  @Filler" & vbCrLf

                        OutPutFile2 = OutPutFile2 & vbCrLf
                        pokeloop = pokeloop + 1
                    End While

                ElseIf curtype = 2 Then

                    While pokeloop < Pokenum

                        OutPutFile2 = OutPutFile2 & ".hword 0x" & ReverseHEX(ReadHEX(LoadedROM, Pokeoff + 0 + (pokeloop * 8), 2)) & "  @EVs" & vbCrLf
                        OutPutFile2 = OutPutFile2 & ".hword " & Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, Pokeoff + 2 + (pokeloop * 8), 2)), System.Globalization.NumberStyles.HexNumber) & "  @Level" & vbCrLf
                        OutPutFile2 = OutPutFile2 & ".hword POKE_" & GetPokemonName(Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, Pokeoff + 4 + (pokeloop * 8), 2)), System.Globalization.NumberStyles.HexNumber)) & "  @Species" & vbCrLf
                        OutPutFile2 = OutPutFile2 & ".hword " & Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, Pokeoff + 6 + (pokeloop * 8), 2)), System.Globalization.NumberStyles.HexNumber) & "  @Held Item" & vbCrLf

                        OutPutFile2 = OutPutFile2 & vbCrLf
                        pokeloop = pokeloop + 1
                    End While

                ElseIf curtype = 3 Then

                    While pokeloop < Pokenum

                        OutPutFile2 = OutPutFile2 & ".hword 0x" & ReverseHEX(ReadHEX(LoadedROM, Pokeoff + 0 + (pokeloop * 16), 2)) & "  @EVs" & vbCrLf
                        OutPutFile2 = OutPutFile2 & ".hword " & Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, Pokeoff + 2 + (pokeloop * 16), 2)), System.Globalization.NumberStyles.HexNumber) & "  @Level" & vbCrLf
                        OutPutFile2 = OutPutFile2 & ".hword POKE_" & GetPokemonName(Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, Pokeoff + 4 + (pokeloop * 16), 2)), System.Globalization.NumberStyles.HexNumber)) & "  @Species" & vbCrLf
                        OutPutFile2 = OutPutFile2 & ".hword " & Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, Pokeoff + 6 + (pokeloop * 16), 2)), System.Globalization.NumberStyles.HexNumber) & "  @Held Item" & vbCrLf
                        OutPutFile2 = OutPutFile2 & ".hword " & Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, Pokeoff + 8 + (pokeloop * 16), 2)), System.Globalization.NumberStyles.HexNumber) & "  @Move 1" & vbCrLf
                        OutPutFile2 = OutPutFile2 & ".hword " & Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, Pokeoff + 10 + (pokeloop * 16), 2)), System.Globalization.NumberStyles.HexNumber) & "  @Move 2" & vbCrLf
                        OutPutFile2 = OutPutFile2 & ".hword " & Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, Pokeoff + 12 + (pokeloop * 16), 2)), System.Globalization.NumberStyles.HexNumber) & "  @Move 3" & vbCrLf
                        OutPutFile2 = OutPutFile2 & ".hword " & Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, Pokeoff + 14 + (pokeloop * 16), 2)), System.Globalization.NumberStyles.HexNumber) & "  @Move 4" & vbCrLf

                        OutPutFile2 = OutPutFile2 & vbCrLf
                        pokeloop = pokeloop + 1
                    End While


                End If

                OutPutFile2 = OutPutFile2 & vbCrLf
                LoopVar = LoopVar + 1
            End While

            If (Not System.IO.Directory.Exists(FolderBrowserDialog1.SelectedPath & "\TrainerPics")) Then
                System.IO.Directory.CreateDirectory(FolderBrowserDialog1.SelectedPath & "\TrainerPics")
            End If

            Dim TrainerImages As String = ".text" & vbCrLf _
& ".thumb" & vbCrLf _
& ".align 2" & vbCrLf & vbCrLf

            LoopVar = 0

            While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfTrainerImages", "")) + 1

                Dim bitout As Bitmap = GetAndDrawTrainerSpriteToBitmap(LoopVar, True)
                TrainerImages = TrainerImages & ".align 2" & vbCrLf
                TrainerImages = TrainerImages & ".global TrainerPic" & LoopVar & vbCrLf
                TrainerImages = TrainerImages & "TrainerPic" & LoopVar & ":" & vbCrLf
                TrainerImages = TrainerImages & ".incbin " & """imglz77/TrainerPics/TrainerPic" & LoopVar & ".bin""" & vbCrLf & vbCrLf
                TrainerImages = TrainerImages & ".align 2" & vbCrLf
                TrainerImages = TrainerImages & ".global TrainerPal" & LoopVar & vbCrLf
                TrainerImages = TrainerImages & "TrainerPal" & LoopVar & ":" & vbCrLf
                TrainerImages = TrainerImages & ".incbin " & """imglz77/TrainerPics/TrainerPic" & LoopVar & ".pal""" & vbCrLf & vbCrLf

                bitout.Save(FolderBrowserDialog1.SelectedPath & "\TrainerPics\TrainerPic" & LoopVar & ".png")

                LoopVar = LoopVar + 1
            End While

            Dim TrainerImagePointers As String = ".text" & vbCrLf _
& ".thumb" & vbCrLf _
& ".align 2" & vbCrLf & vbCrLf

            Dim imagepointers As String = ".global Trainer_Image_Pointers" & vbCrLf _
                & "Trainer_Image_Pointers:" & vbCrLf & vbCrLf
            Dim palpointers As String = ".global Trainer_Pal_Pointers" & vbCrLf _
                & "Trainer_Pal_Pointers:" & vbCrLf & vbCrLf

            LoopVar = 0

            While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfTrainerImages", "")) + 1


                imagepointers = imagepointers & ".long    TrainerPic" & LoopVar & vbCrLf
                imagepointers = imagepointers & ".hword    0x800" & vbCrLf
                imagepointers = imagepointers & ".hword    " & LoopVar & vbCrLf & vbCrLf

                palpointers = palpointers & ".long    TrainerPal" & LoopVar & "" & vbCrLf
                palpointers = palpointers & ".hword    0x00" & vbCrLf
                palpointers = palpointers & ".hword    " & LoopVar & vbCrLf & vbCrLf

                LoopVar = LoopVar + 1
            End While

            TrainerImagePointers = TrainerImagePointers & imagepointers & palpointers

            Dim moneytableoutput As String = ".text" & vbCrLf _
& ".thumb" & vbCrLf _
& ".align 2" & vbCrLf & vbCrLf &
".global Trainer_Money_Table" & vbCrLf & "Trainer_Money_Table:" & vbCrLf

            Dim moneytableoffvar As Integer

            Dim looper As Integer = 0

            moneytableoffvar = Int32.Parse((GetString(GetINIFileLocation(), header, "TrainerMoneyTable", "")), System.Globalization.NumberStyles.HexNumber)

            While 255 <> Int32.Parse(ReadHEX(LoadedROM, moneytableoffvar + (looper * 4), 1), System.Globalization.NumberStyles.HexNumber)


                moneytableoutput = moneytableoutput & ".byte   " & Int32.Parse(ReadHEX(LoadedROM, moneytableoffvar + (looper * 4), 1), System.Globalization.NumberStyles.HexNumber) & "  @Class" & vbCrLf
                moneytableoutput = moneytableoutput & ".byte   " & Int32.Parse(ReadHEX(LoadedROM, moneytableoffvar + (looper * 4) + 1, 1), System.Globalization.NumberStyles.HexNumber) & "  @Money Rate" & vbCrLf
                moneytableoutput = moneytableoutput & ".hword 0x0000    @Padding" & vbCrLf

                looper = looper + 1

            End While

            moneytableoutput = moneytableoutput & ".byte   255" & "  @Class" & vbCrLf
            moneytableoutput = moneytableoutput & ".byte   5" & "  @Money Rate" & vbCrLf
            moneytableoutput = moneytableoutput & ".hword 0x0000    @Padding" & vbCrLf

            File.WriteAllText(FolderBrowserDialog1.SelectedPath & "\TrainerImages.s", TrainerImages)
            File.WriteAllText(FolderBrowserDialog1.SelectedPath & "\TrainerData.s", OutPutFile)
            File.WriteAllText(FolderBrowserDialog1.SelectedPath & "\TrainerPokemonData.s", OutPutFile2)
            File.WriteAllText(FolderBrowserDialog1.SelectedPath & "\TrainerImageTable.s", TrainerImagePointers)
            File.WriteAllText(FolderBrowserDialog1.SelectedPath & "\TrainerMoneyTable.s", moneytableoutput)

            Me.Text = "Trainer Data Dumper"
            Me.UseWaitCursor = False
            Me.Enabled = True
            Me.BringToFront()

        End If

    End Sub
End Class
