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
& ".global OW_Data" & vbCrLf _
& "OW_Data:" & vbCrLf & vbCrLf

            Dim LoopVar As Integer = 0
            Dim curoff As Integer
            Dim offvar As Integer
            offvar = Int32.Parse((GetString(GetINIFileLocation(), header, "TrainerTable", "")), System.Globalization.NumberStyles.HexNumber)

            While LoopVar < (GetString(GetINIFileLocation(), header, "OWSpriteCount", "")) + 1 = True

                curoff = offvar + (36 * (LoopVar))

                OutPutFile = OutPutFile & "@Sprite " & LoopVar & vbCrLf
                OutPutFile = OutPutFile & ".short    0x" & ReverseHEX(ReadHEX(LoadedROM, curoff, 2)) & "   @tiles_tag" & vbCrLf
                OutPutFile = OutPutFile & ".byte    0x" & ReverseHEX(ReadHEX(LoadedROM, curoff + 2, 1)) & "   @pal_num" & vbCrLf
                OutPutFile = OutPutFile & ".byte    0x" & ReverseHEX(ReadHEX(LoadedROM, curoff + 3, 1)) & "   @Unused?" & vbCrLf
                OutPutFile = OutPutFile & ".short    0x" & ReverseHEX(ReadHEX(LoadedROM, curoff + 4, 2)) & "   @pal_tag_2?" & vbCrLf
                OutPutFile = OutPutFile & ".short    0x" & ReverseHEX(ReadHEX(LoadedROM, curoff + 6, 2)) & "   @field_6" & vbCrLf
                OutPutFile = OutPutFile & ".long    0x" & ReverseHEX(ReadHEX(LoadedROM, curoff + 8, 4)) & "   @pos_neg_center" & vbCrLf
                OutPutFile = OutPutFile & ".byte    0x" & ReverseHEX(ReadHEX(LoadedROM, curoff + 12, 1)) & "   @pal_slot_and_unknown" & vbCrLf
                OutPutFile = OutPutFile & ".byte    0x" & ReverseHEX(ReadHEX(LoadedROM, curoff + 13, 1)) & "   @field_D" & vbCrLf
                OutPutFile = OutPutFile & ".short    0x" & ReverseHEX(ReadHEX(LoadedROM, curoff + 14, 2)) & "   @unused" & vbCrLf

                OutPutFile = OutPutFile & vbCrLf

                LoopVar = LoopVar + 1

            End While

            File.WriteAllText(FolderBrowserDialog1.SelectedPath & "\OWData.s", OutPutFile)

            Me.Text = "OW Dumper"
            Me.UseWaitCursor = False
            Me.Enabled = True
            Me.BringToFront()

        End If
    End Sub
End Class
