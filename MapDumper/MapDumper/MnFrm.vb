Imports System.IO
Imports System.Windows.Forms.Application
Imports System.Net

Public Class MnFrm
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
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
                ROMNameLabel.Text = ""
                LoadedROM = ""

                MessageBox.Show("I haven't added Jap support out of pure lazziness. I will though if it get's highly Demanded.")

                End

            Else

                ROMNameLabel.Text = header & " - " & GetString(GetINIFileLocation(), header, "ROMName", "")

            End If
        Else
            ROMNameLabel.Text = ""

            LoadedROM = ""

            MessageBox.Show("Not one of the Pokemon games...")

            End

        End If

        LoadBanksAndMaps()

    End Sub

    Private Sub MnFrm_DragDrop(sender As Object, e As DragEventArgs) Handles MyBase.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim MyFiles() As String


            ' Assign the files to an array.
            MyFiles = e.Data.GetData(DataFormats.FileDrop)

            If MyFiles.Length > 1 Then
                MessageBox.Show("One file only please...")
            End If

            'MessageBox.Show(MyFiles.Length)

            ' MessageBox.Show(IO.Path.GetExtension(MyFiles(0)))

            If IO.Path.GetExtension(MyFiles(0)) = ".gba" Or IO.Path.GetExtension(MyFiles(0)) = ".GBA" Then

                LoadedROM = MyFiles(0)

                HandleOpenedROM()
            Else

                MessageBox.Show("File must end with a .gba extension.")

            End If

            ' Loop through the array and add the files to the list.
            'For i = 0 To MyFiles.Length - 1
            'ListBox1.Items.Add(MyFiles(i))
            'Next
        End If
    End Sub

    Private Sub MnFrm_DragEnter(sender As Object, e As DragEventArgs) Handles MyBase.DragEnter

        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        End If

    End Sub

    Private Sub LoadBanksAndMaps()

        MapsAndBanks.Nodes.Clear()

        Point2MapBankPointers = Int32.Parse(GetString(GetINIFileLocation(), header, "Pointer2PointersToMapBanks", ""), System.Globalization.NumberStyles.HexNumber)

        MapBankPointers = Conversion.Hex((Conversion.Val(("&H" & ReverseHEX(ReadHEX(LoadedROM, Point2MapBankPointers, 4)))) - &H8000000))

        i = 0

    End Sub

End Class
