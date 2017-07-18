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

            FileNum = FreeFile()

            FileOpen(FileNum, LoadedROM, OpenMode.Binary)
            'Opens the ROM as binary
            FileGet(FileNum, header, &HAD, True)
            header2 = Mid(header, 1, 3)
            header3 = Mid(header, 4, 1)
            FileClose(FileNum)

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FolderBrowserDialog1.Description = "Select folder to export to:"

        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            Me.Text = "Please wait..."
            Me.UseWaitCursor = True

            Dim PokeOutPut As String = ""
            Dim AttackOutPut As String = ""
            Dim ItemOutPut As String = ""

            Dim LoopVar As Integer

            LoopVar = 0

            While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfPokemon", "")) - 1 = True

                LoopVar = LoopVar + 1

                PokeOutPut = PokeOutPut & "	.set POKE_" & GetPokemonName(LoopVar) & ",  " & LoopVar & vbCrLf

            End While

            LoopVar = 0

            While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfAttacks", "")) + 1 = True

                AttackOutPut = AttackOutPut & "	.set Attack_" & GetAttackName(LoopVar).replace(" ", "_") & ",  " & LoopVar & vbCrLf

                LoopVar = LoopVar + 1

            End While

            LoopVar = 0

            While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfItems", "")) = True

                ItemOutPut = ItemOutPut & "	.set Item_" & GetItemName(LoopVar).replace(" ", "_") & ",  " & LoopVar & vbCrLf

                LoopVar = LoopVar + 1

            End While

            File.WriteAllText(FolderBrowserDialog1.SelectedPath & "\Poke_constants.inc", PokeOutPut)
            File.WriteAllText(FolderBrowserDialog1.SelectedPath & "\Attack_constants.inc", AttackOutPut)
            File.WriteAllText(FolderBrowserDialog1.SelectedPath & "\Item_constants.inc", ItemOutPut)

            Me.Text = "Define Dumper"
            Me.UseWaitCursor = False
            Me.Enabled = True
            Me.BringToFront()

        End If
    End Sub
End Class
