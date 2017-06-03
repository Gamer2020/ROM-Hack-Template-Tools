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

            FileNum = FreeFile()

            FileOpen(FileNum, LoadedROM, OpenMode.Binary)
            'Opens the ROM as binary
            FileGet(FileNum, header, &HAD, True)
            header2 = Mid(header, 1, 3)
            header3 = Mid(header, 4, 1)
            FileClose(FileNum)

            Dim pointertext As String = ""
            Dim descriptext As String = ""

            Dim loopvar As Integer

            loopvar = 0

            While (loopvar < (GetString(GetINIFileLocation(), header, "NumberOfAbilities", ""))) = True



                Dim AbilityDesc As Integer = Int32.Parse((GetString(GetINIFileLocation(), header, "AbilityDescriptionTable", "")), System.Globalization.NumberStyles.HexNumber)

                Dim descPointer As String = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (AbilityDesc) + (loopvar * 4), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)

                FileNum = FreeFile()
                FileOpen(FileNum, LoadedROM, OpenMode.Binary)
                Dim DescpText As String = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"

                FileGet(FileNum, DescpText, Int32.Parse(((descPointer)), System.Globalization.NumberStyles.HexNumber) + 1, True)
                DescpText = Sapp2Asc(DescpText)
                DescpText = Mid$(DescpText, 1, InStr(1, DescpText, "\x"))
                DescpText = Replace(DescpText, "\n", vbCrLf)
                DescpText = Replace(RTrim$(DescpText), "\", "")

                FileClose(FileNum)

                pointertext = pointertext & ".word " & GetAbilityName(loopvar).Replace(" ", "_") & "_description" & vbCrLf

                descriptext = descriptext & "" & GetAbilityName(loopvar).Replace(" ", "_") & "_description:" & vbCrLf & ".byte " & (EveryN(DescpText, 1, "_, ").Replace(" _", "Space")).Replace(".", "Dot, ") & "Termin" & vbCrLf & vbCrLf

                loopvar = loopvar + 1

            End While

            TextBox1.Text = pointertext & vbCrLf & descriptext

        End If

    End Sub
End Class
