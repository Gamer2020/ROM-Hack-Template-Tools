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

            Dim arrFrameLimits(244) As Integer

            arrFrameLimits(0) = 17
            arrFrameLimits(1) = 8
            arrFrameLimits(2) = 26
            arrFrameLimits(3) = 11
            arrFrameLimits(4) = 4
            arrFrameLimits(5) = 6
            For i = 6 To 58
                arrFrameLimits(i) = 8
            Next
            arrFrameLimits(59) = 9
            arrFrameLimits(60) = 0
            arrFrameLimits(61) = 2
            arrFrameLimits(62) = 2
            For i = 63 To 75
                arrFrameLimits(i) = 8
            Next
            arrFrameLimits(76) = 0
            arrFrameLimits(77) = 0
            arrFrameLimits(78) = 0
            arrFrameLimits(79) = 0
            arrFrameLimits(80) = 0
            arrFrameLimits(81) = 0
            arrFrameLimits(82) = 3
            arrFrameLimits(83) = 8
            arrFrameLimits(84) = 8
            arrFrameLimits(85) = 8
            arrFrameLimits(86) = 3
            arrFrameLimits(87) = 0
            arrFrameLimits(88) = 8
            arrFrameLimits(89) = 17
            arrFrameLimits(90) = 8
            arrFrameLimits(91) = 26
            arrFrameLimits(92) = 11
            arrFrameLimits(93) = 4
            arrFrameLimits(94) = 0
            arrFrameLimits(95) = 8
            arrFrameLimits(96) = 8
            arrFrameLimits(97) = 0
            arrFrameLimits(98) = 8
            arrFrameLimits(99) = 8
            arrFrameLimits(100) = 8
            arrFrameLimits(101) = 17
            arrFrameLimits(102) = 8
            arrFrameLimits(103) = 26
            arrFrameLimits(104) = 11
            arrFrameLimits(105) = 4
            arrFrameLimits(106) = 17
            arrFrameLimits(107) = 8
            arrFrameLimits(108) = 26
            arrFrameLimits(109) = 11
            arrFrameLimits(110) = 4
            arrFrameLimits(111) = 8
            arrFrameLimits(112) = 8
            arrFrameLimits(113) = 8
            arrFrameLimits(114) = 0
            arrFrameLimits(115) = 0
            For i = 116 To 137
                arrFrameLimits(i) = 8
            Next
            arrFrameLimits(138) = 11
            arrFrameLimits(139) = 11
            arrFrameLimits(140) = 8
            arrFrameLimits(141) = 8
            arrFrameLimits(142) = 8
            For i = 143 To 187
                arrFrameLimits(i) = 0
            Next
            arrFrameLimits(188) = 8
            arrFrameLimits(189) = 8
            arrFrameLimits(190) = 8
            arrFrameLimits(191) = 8
            arrFrameLimits(192) = 8
            arrFrameLimits(193) = 8
            arrFrameLimits(194) = 0
            arrFrameLimits(195) = 0
            arrFrameLimits(196) = 8
            arrFrameLimits(197) = 8
            arrFrameLimits(198) = 8
            arrFrameLimits(199) = 8
            arrFrameLimits(200) = 8
            arrFrameLimits(201) = 8
            arrFrameLimits(202) = 0
            For i = 203 To 218
                arrFrameLimits(i) = 8
            Next
            arrFrameLimits(219) = 17
            arrFrameLimits(220) = 17
            arrFrameLimits(221) = 8
            arrFrameLimits(222) = 8
            arrFrameLimits(223) = 8
            arrFrameLimits(224) = 0
            For i = 225 To 244
                arrFrameLimits(i) = 8
            Next

            Dim OutPutFile As String = ".text" & vbCrLf _
& ".thumb" & vbCrLf _
& ".align 2" & vbCrLf & vbCrLf _
& ".global OW_Data" & vbCrLf _
& "OW_Data:" & vbCrLf & vbCrLf

            Dim OutPutFile2 As String = ".text" & vbCrLf _
& ".thumb" & vbCrLf _
& ".align 2" & vbCrLf & vbCrLf

            Dim OutPutFile3 As String = ".text" & vbCrLf _
& ".thumb" & vbCrLf _
& ".align 2" & vbCrLf & vbCrLf _
& ".global OW_Pointer_Table" & vbCrLf _
& "OW_Pointer_Table:" & vbCrLf & vbCrLf

            Dim LoopVar As Integer = 0
            Dim curoff As Integer
            Dim offvar As Integer
            Dim LoopVar2 As Integer = 0

            Dim CurSpriteData As Integer

            offvar = Int32.Parse((GetString(GetINIFileLocation(), header, "OWSpriteBank", "")), System.Globalization.NumberStyles.HexNumber)

            While LoopVar < (GetString(GetINIFileLocation(), header, "OWSpriteCount", "")) + 1 = True


                curoff = offvar + (36 * (LoopVar))

                OutPutFile3 = OutPutFile3 & ".word  OW_Header" & LoopVar & "" & vbCrLf

                OutPutFile = OutPutFile & ".global OW_Header" & LoopVar & vbCrLf _
                        & "OW_Header" & LoopVar & ":" & vbCrLf & vbCrLf
                OutPutFile = OutPutFile & ".short    0x" & ReverseHEX(ReadHEX(LoadedROM, curoff, 2)) & "   @Starter Bytes" & vbCrLf
                OutPutFile = OutPutFile & ".byte    0x" & ReverseHEX(ReadHEX(LoadedROM, curoff + 2, 1)) & "   @pal_num" & vbCrLf
                OutPutFile = OutPutFile & ".byte    0x" & ReverseHEX(ReadHEX(LoadedROM, curoff + 3, 1)) & "   @?" & vbCrLf
                OutPutFile = OutPutFile & ".short    0x" & ReverseHEX(ReadHEX(LoadedROM, curoff + 4, 2)) & "   @?" & vbCrLf
                OutPutFile = OutPutFile & ".short    0x" & ReverseHEX(ReadHEX(LoadedROM, curoff + 6, 2)) & "   @Unkown Data Size?" & vbCrLf
                OutPutFile = OutPutFile & ".byte    0x" & (ReadHEX(LoadedROM, curoff + 8, 1)) & "   @Width" & vbCrLf
                OutPutFile = OutPutFile & ".byte    0x" & (ReadHEX(LoadedROM, curoff + 9, 1)) & "   @?" & vbCrLf
                OutPutFile = OutPutFile & ".byte    0x" & (ReadHEX(LoadedROM, curoff + 10, 1)) & "   @Height" & vbCrLf
                OutPutFile = OutPutFile & ".byte    0x" & (ReadHEX(LoadedROM, curoff + 11, 1)) & "   @?" & vbCrLf
                OutPutFile = OutPutFile & ".word    0x" & ReverseHEX(ReadHEX(LoadedROM, curoff + 12, 4)) & "   @Unkown Data?" & vbCrLf
                OutPutFile = OutPutFile & ".word    0x" & ReverseHEX(ReadHEX(LoadedROM, curoff + 16, 4)) & "   @Unkown Pointer?" & vbCrLf
                OutPutFile = OutPutFile & ".word    0x" & ReverseHEX(ReadHEX(LoadedROM, curoff + 20, 4)) & "   @Unkown Pointer?" & vbCrLf
                OutPutFile = OutPutFile & ".word    0x" & ReverseHEX(ReadHEX(LoadedROM, curoff + 24, 4)) & "   @Unkown Pointer?" & vbCrLf
                OutPutFile = OutPutFile & ".word    " & "OW_Sprite_Data" & LoopVar & "   @Sprite Pointer" & vbCrLf
                CurSpriteData = Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, curoff + 28, 4)), System.Globalization.NumberStyles.HexNumber) - &H8000000
                OutPutFile = OutPutFile & ".word    0x" & ReverseHEX(ReadHEX(LoadedROM, curoff + 32, 4)) & "   @Unkown Pointer?" & vbCrLf

                OutPutFile = OutPutFile & vbCrLf

                OutPutFile2 = OutPutFile2 & ".global OW_Sprite_Data" & LoopVar & vbCrLf _
                        & "OW_Sprite_Data" & LoopVar & ":" & vbCrLf & vbCrLf

                LoopVar2 = 0

                While LoopVar2 < (arrFrameLimits(LoopVar) + 1)

                    OutPutFile2 = OutPutFile2 & ".word    0x" & ReverseHEX(ReadHEX(LoadedROM, CurSpriteData + (LoopVar2 * 8), 4)) & "   @Sprite Image" & vbCrLf
                    OutPutFile2 = OutPutFile2 & ".short    0x" & ReverseHEX(ReadHEX(LoadedROM, CurSpriteData + (LoopVar2 * 8) + 4, 2)) & "   @Data Size" & vbCrLf
                    OutPutFile2 = OutPutFile2 & ".short    0x" & ReverseHEX(ReadHEX(LoadedROM, CurSpriteData + (LoopVar2 * 8) + 6, 2)) & "   @Other Data?" & vbCrLf

                    LoopVar2 = LoopVar2 + 1
                End While

                OutPutFile2 = OutPutFile2 & vbCrLf

                LoopVar = LoopVar + 1

            End While

            File.WriteAllText(FolderBrowserDialog1.SelectedPath & "\OWData.s", OutPutFile)
            File.WriteAllText(FolderBrowserDialog1.SelectedPath & "\OWSpriteData.s", OutPutFile2)
            File.WriteAllText(FolderBrowserDialog1.SelectedPath & "\OWPointerTable.s", OutPutFile3)

            Me.Text = "OW Dumper"
            Me.UseWaitCursor = False
            Me.Enabled = True
            Me.BringToFront()

        End If
    End Sub
End Class
