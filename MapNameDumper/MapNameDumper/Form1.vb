Public Class Form1
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

        Dim namestextvar As String = ""
        Dim namestextvar2 As String = ".thumb" & vbCrLf _
& ".align 2" & vbCrLf & vbCrLf _
& ".global Map_Names" & vbCrLf _
& "Map_Names:" & vbCrLf & vbCrLf

        Dim LoopVar As Integer = 0

        Dim offvar As Integer

        offvar = Int32.Parse((GetString(GetINIFileLocation(), header, "MapLabelData", "")), System.Globalization.NumberStyles.HexNumber)


        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfMapLabels", ""))

            Dim curoff As Integer

            curoff = offvar + (8 * (LoopVar))

            offvar = Int32.Parse((GetString(GetINIFileLocation(), header, "MapLabelData", "")), System.Globalization.NumberStyles.HexNumber)

            namestextvar = namestextvar & ".align 2" & vbCrLf & ".global MapLabel" & LoopVar & "" & vbCrLf & "MapLabel" & LoopVar & ":" & vbCrLf & ".string    """ & GetMapLabelName(LoopVar) & "$""" & vbCrLf & vbCrLf

            namestextvar2 = namestextvar2 & ".byte    0x" & ReadHEX(LoadedROM, curoff, 1) & "   @World Map X" & vbCrLf
            namestextvar2 = namestextvar2 & ".byte    0x" & ReadHEX(LoadedROM, curoff + 1, 1) & "   @World Map Y" & vbCrLf
            namestextvar2 = namestextvar2 & ".byte    0x" & ReadHEX(LoadedROM, curoff + 2, 1) & "   @World Map Width" & vbCrLf
            namestextvar2 = namestextvar2 & ".byte    0x" & ReadHEX(LoadedROM, curoff + 3, 1) & "   @World Map Height" & vbCrLf
            namestextvar2 = namestextvar2 & ".long    MapLabel" & LoopVar & " @Pointer to Name" & vbCrLf

            namestextvar2 = namestextvar2 & vbCrLf

            LoopVar = LoopVar + 1
        End While


        TextBox1.Text = namestextvar2 & namestextvar

    End Sub

End Class
