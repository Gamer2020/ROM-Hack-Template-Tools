Imports System.IO
Imports VB = Microsoft.VisualBasic
Imports System.Windows.Forms.Application

Public Class MnFrm



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        fileOpenDialog.FileName = ""
        fileOpenDialog.CheckFileExists = True

        ' Check to ensure that the selected path exists.  Dialog box displays 
        ' a warning otherwise.
        fileOpenDialog.CheckPathExists = True

        ' Get or set default extension. Doesn't include the leading ".".
        fileOpenDialog.DefaultExt = "bin"

        ' Return the file referenced by a link? If False, simply returns the selected link
        ' file. If True, returns the file linked to the LNK file.
        fileOpenDialog.DereferenceLinks = True

        ' Just as in VB6, use a set of pairs of filters, separated with "|". Each 
        ' pair consists of a description|file spec. Use a "|" between pairs. No need to put a
        ' trailing "|". You can set the FilterIndex property as well, to select the default
        ' filter. The first filter is numbered 1 (not 0). The default is 1. 
        fileOpenDialog.Filter =
            "(*.bin)|*.bin*"

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

        fileOpenDialog.Title = "Select bin to open:"

        ' Only accept valid Win32 file names?
        fileOpenDialog.ValidateNames = True


        If fileOpenDialog.ShowDialog = DialogResult.OK Then

            TextBox1.Text = fileOpenDialog.FileName


        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        fileOpenDialog.FileName = ""
        fileOpenDialog.CheckFileExists = True

        ' Check to ensure that the selected path exists.  Dialog box displays 
        ' a warning otherwise.
        fileOpenDialog.CheckPathExists = True

        ' Get or set default extension. Doesn't include the leading ".".
        fileOpenDialog.DefaultExt = "bin"

        ' Return the file referenced by a link? If False, simply returns the selected link
        ' file. If True, returns the file linked to the LNK file.
        fileOpenDialog.DereferenceLinks = True

        ' Just as in VB6, use a set of pairs of filters, separated with "|". Each 
        ' pair consists of a description|file spec. Use a "|" between pairs. No need to put a
        ' trailing "|". You can set the FilterIndex property as well, to select the default
        ' filter. The first filter is numbered 1 (not 0). The default is 1. 
        fileOpenDialog.Filter =
            "(*.bin)|*.bin*"

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

        fileOpenDialog.Title = "Select bin to open:"

        ' Only accept valid Win32 file names?
        fileOpenDialog.ValidateNames = True


        If fileOpenDialog.ShowDialog = DialogResult.OK Then

            TextBox2.Text = fileOpenDialog.FileName


        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        fileOpenDialog.FileName = ""
        fileOpenDialog.CheckFileExists = True

        ' Check to ensure that the selected path exists.  Dialog box displays 
        ' a warning otherwise.
        fileOpenDialog.CheckPathExists = True

        ' Get or set default extension. Doesn't include the leading ".".
        fileOpenDialog.DefaultExt = "bin"

        ' Return the file referenced by a link? If False, simply returns the selected link
        ' file. If True, returns the file linked to the LNK file.
        fileOpenDialog.DereferenceLinks = True

        ' Just as in VB6, use a set of pairs of filters, separated with "|". Each 
        ' pair consists of a description|file spec. Use a "|" between pairs. No need to put a
        ' trailing "|". You can set the FilterIndex property as well, to select the default
        ' filter. The first filter is numbered 1 (not 0). The default is 1. 
        fileOpenDialog.Filter =
            "(*.bin)|*.bin*"

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

        fileOpenDialog.Title = "Select bin to open:"

        ' Only accept valid Win32 file names?
        fileOpenDialog.ValidateNames = True


        If fileOpenDialog.ShowDialog = DialogResult.OK Then

            TextBox4.Text = fileOpenDialog.FileName


        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        fileOpenDialog.FileName = ""
        fileOpenDialog.CheckFileExists = True

        ' Check to ensure that the selected path exists.  Dialog box displays 
        ' a warning otherwise.
        fileOpenDialog.CheckPathExists = True

        ' Get or set default extension. Doesn't include the leading ".".
        fileOpenDialog.DefaultExt = "bin"

        ' Return the file referenced by a link? If False, simply returns the selected link
        ' file. If True, returns the file linked to the LNK file.
        fileOpenDialog.DereferenceLinks = True

        ' Just as in VB6, use a set of pairs of filters, separated with "|". Each 
        ' pair consists of a description|file spec. Use a "|" between pairs. No need to put a
        ' trailing "|". You can set the FilterIndex property as well, to select the default
        ' filter. The first filter is numbered 1 (not 0). The default is 1. 
        fileOpenDialog.Filter =
            "(*.bin)|*.bin*"

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

        fileOpenDialog.Title = "Select bin to open:"

        ' Only accept valid Win32 file names?
        fileOpenDialog.ValidateNames = True


        If fileOpenDialog.ShowDialog = DialogResult.OK Then

            TextBox3.Text = fileOpenDialog.FileName


        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        fileOpenDialog.FileName = ""
        fileOpenDialog.CheckFileExists = True

        ' Check to ensure that the selected path exists.  Dialog box displays 
        ' a warning otherwise.
        fileOpenDialog.CheckPathExists = True

        ' Get or set default extension. Doesn't include the leading ".".
        fileOpenDialog.DefaultExt = "bin"

        ' Return the file referenced by a link? If False, simply returns the selected link
        ' file. If True, returns the file linked to the LNK file.
        fileOpenDialog.DereferenceLinks = True

        ' Just as in VB6, use a set of pairs of filters, separated with "|". Each 
        ' pair consists of a description|file spec. Use a "|" between pairs. No need to put a
        ' trailing "|". You can set the FilterIndex property as well, to select the default
        ' filter. The first filter is numbered 1 (not 0). The default is 1. 
        fileOpenDialog.Filter =
            "(*.bin)|*.bin*"

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

        fileOpenDialog.Title = "Select bin to open:"

        ' Only accept valid Win32 file names?
        fileOpenDialog.ValidateNames = True


        If fileOpenDialog.ShowDialog = DialogResult.OK Then

            TextBox6.Text = fileOpenDialog.FileName


        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        fileOpenDialog.FileName = ""
        fileOpenDialog.CheckFileExists = True

        ' Check to ensure that the selected path exists.  Dialog box displays 
        ' a warning otherwise.
        fileOpenDialog.CheckPathExists = True

        ' Get or set default extension. Doesn't include the leading ".".
        fileOpenDialog.DefaultExt = "bin"

        ' Return the file referenced by a link? If False, simply returns the selected link
        ' file. If True, returns the file linked to the LNK file.
        fileOpenDialog.DereferenceLinks = True

        ' Just as in VB6, use a set of pairs of filters, separated with "|". Each 
        ' pair consists of a description|file spec. Use a "|" between pairs. No need to put a
        ' trailing "|". You can set the FilterIndex property as well, to select the default
        ' filter. The first filter is numbered 1 (not 0). The default is 1. 
        fileOpenDialog.Filter =
            "(*.bin)|*.bin*"

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

        fileOpenDialog.Title = "Select bin to open:"

        ' Only accept valid Win32 file names?
        fileOpenDialog.ValidateNames = True


        If fileOpenDialog.ShowDialog = DialogResult.OK Then

            TextBox5.Text = fileOpenDialog.FileName


        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        fileOpenDialog.FileName = ""
        fileOpenDialog.CheckFileExists = True

        ' Check to ensure that the selected path exists.  Dialog box displays 
        ' a warning otherwise.
        fileOpenDialog.CheckPathExists = True

        ' Get or set default extension. Doesn't include the leading ".".
        fileOpenDialog.DefaultExt = "bin"

        ' Return the file referenced by a link? If False, simply returns the selected link
        ' file. If True, returns the file linked to the LNK file.
        fileOpenDialog.DereferenceLinks = True

        ' Just as in VB6, use a set of pairs of filters, separated with "|". Each 
        ' pair consists of a description|file spec. Use a "|" between pairs. No need to put a
        ' trailing "|". You can set the FilterIndex property as well, to select the default
        ' filter. The first filter is numbered 1 (not 0). The default is 1. 
        fileOpenDialog.Filter =
            "(*.bin)|*.bin*"

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

        fileOpenDialog.Title = "Select bin to open:"

        ' Only accept valid Win32 file names?
        fileOpenDialog.ValidateNames = True


        If fileOpenDialog.ShowDialog = DialogResult.OK Then

            TextBox8.Text = fileOpenDialog.FileName


        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        fileOpenDialog.FileName = ""
        fileOpenDialog.CheckFileExists = True

        ' Check to ensure that the selected path exists.  Dialog box displays 
        ' a warning otherwise.
        fileOpenDialog.CheckPathExists = True

        ' Get or set default extension. Doesn't include the leading ".".
        fileOpenDialog.DefaultExt = "bin"

        ' Return the file referenced by a link? If False, simply returns the selected link
        ' file. If True, returns the file linked to the LNK file.
        fileOpenDialog.DereferenceLinks = True

        ' Just as in VB6, use a set of pairs of filters, separated with "|". Each 
        ' pair consists of a description|file spec. Use a "|" between pairs. No need to put a
        ' trailing "|". You can set the FilterIndex property as well, to select the default
        ' filter. The first filter is numbered 1 (not 0). The default is 1. 
        fileOpenDialog.Filter =
            "(*.bin)|*.bin*"

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

        fileOpenDialog.Title = "Select bin to open:"

        ' Only accept valid Win32 file names?
        fileOpenDialog.ValidateNames = True


        If fileOpenDialog.ShowDialog = DialogResult.OK Then

            TextBox7.Text = fileOpenDialog.FileName


        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox4.Text = "" Or TextBox3.Text = "" Or TextBox6.Text = "" Or TextBox5.Text = "" Or TextBox8.Text = "" Or TextBox7.Text = "" Or TextBox9.Text = "" Then

            MsgBox("Please check that you have loaded all the files!")
            Exit Sub

        End If

        Dim start_time As DateTime
        Dim stop_time As DateTime
        Dim elapsed_time As TimeSpan

        start_time = Now

        Dim PalBuff As String
        Dim Temp(&HFFFF) As Byte
        Dim loopvar As Integer = 0

        While loopvar < 13

            If loopvar < 6 Then

                PalBuff = ReadHEX(TextBox2.Text, (loopvar * 32), 32)

            Else

                PalBuff = ReadHEX(TextBox3.Text, ((loopvar) * 32), 32)

            End If

            Temp = HexStringToByteArray(PalBuff)

            TilePals(loopvar) = LoadPalette(Temp)

            loopvar = loopvar + 1
        End While

        BufferTileImages(TextBox1.Text, TextBox4.Text, CheckBox1.Checked, CheckBox2.Checked)

        GroupBox1.Enabled = True

        SelectedTileImgInBlockEditor = 0
        SelectedTileImgInBlockEditorPal = 0

        If SelectedTileImgInBlockEditor < 512 Then

            SelectedTilePictureBox.Image = LoadSingleTileToBitmap2(TileSet1Image, SelectedTileImgInBlockEditor, TilePals(SelectedTileImgInBlockEditorPal), True, RotateFlipType.RotateNoneFlipNone)

        Else

            SelectedTilePictureBox.Image = LoadSingleTileToBitmap2(TileSet2Image, SelectedTileImgInBlockEditor - 512, TilePals(SelectedTileImgInBlockEditorPal), True, RotateFlipType.RotateNoneFlipNone)

        End If


        SelectionStatus.Text = "Selected Tile: " & SelectedTileImgInBlockEditor

        ComboBox1.SelectedIndex = -1
        ComboBox1.SelectedIndex = 0

        LoadBlockset()

        stop_time = Now
        elapsed_time = stop_time.Subtract(start_time)
        LoadTImeLabel.Text = "BlocK Load Time: " & elapsed_time.TotalSeconds.ToString("0.00")

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        Dim Tiles1 As Bitmap
        Dim Tiles2 As Bitmap
        Dim Tiles3 As New Bitmap(128, 512)

        If ComboBox1.SelectedIndex = -1 Then

        Else

            SelectedTileImgInBlockEditorPal = ComboBox1.SelectedIndex

            Tiles1 = LoadTilesToBitmap(TextBox1.Text, TilePals(ComboBox1.SelectedIndex), CheckBox1.Checked, True)
            Tiles2 = LoadTilesToBitmap(TextBox4.Text, TilePals(ComboBox1.SelectedIndex), CheckBox2.Checked, True)

            BitmapBLT(Tiles1, Tiles3, 0, 0, 0, 0, 128, 256)
            BitmapBLT(Tiles2, Tiles3, 0, 256, 0, 0, 128, 256)

            TilesPictureBox.Height = Tiles3.Height * 2
            TilesPictureBox.Width = Tiles3.Width * 2


            TilesPictureBox.Image = Tiles3

        End If

    End Sub

    Private Sub GroupBox1_Resize(sender As Object, e As EventArgs) Handles GroupBox1.Resize
        Panel3.Height = GroupBox1.Height - 89
    End Sub

    Private Sub LoadBlockset()

        Dim PrimaryBlocksInfo As New FileInfo(TextBox6.Text)
        Dim SecondaryBlocksInfo As New FileInfo(TextBox5.Text)

        Dim loopvar As Integer = 0

        Dim BlockHeight As Integer = (((PrimaryBlocksInfo.Length + SecondaryBlocksInfo.Length) / 2) / 8) / 8

        Dim Blockset As New Bitmap(128, BlockHeight * 16)

        Dim across As Integer = 0
        Dim down As Integer = 0

        While loopvar < ((PrimaryBlocksInfo.Length / 16) + (SecondaryBlocksInfo.Length / 16))

            If loopvar < 512 Then

                BitmapBLT(BlockToBitmap(TextBox6.Text, TextBox1.Text, TextBox4.Text, loopvar), Blockset, across * 16, down * 16, 0, 0, 16, 16)
            Else

                BitmapBLT(BlockToBitmap(TextBox5.Text, TextBox1.Text, TextBox4.Text, loopvar), Blockset, across * 16, down * 16, 0, 0, 16, 16)

            End If
            across = across + 1

            If across = 8 Then
                across = 0
                down = down + 1
            End If

            loopvar = loopvar + 1
        End While

        BlockSetsPictureBox.Height = Blockset.Height * 2
        BlockSetsPictureBox.Width = Blockset.Width * 2

        BlocksImage = New Bitmap(128, BlockHeight * 16)

        BlocksImage = Blockset

        BlockSetsPictureBox.Image = Blockset
        BlockSetsPictureBox.Refresh()

    End Sub

    Private Sub GroupBox3_Resize(sender As Object, e As EventArgs) Handles GroupBox3.Resize
        Panel4.Height = GroupBox3.Height - 46
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        SaveFileDialog.FileName = ""
        'SaveFileDialog.CheckFileExists = True

        ' Check to ensure that the selected path exists.  Dialog box displays 
        ' a warning otherwise.
        SaveFileDialog.CheckPathExists = True

        ' Get or set default extension. Doesn't include the leading ".".
        SaveFileDialog.DefaultExt = "txt"

        ' Return the file referenced by a link? If False, simply returns the selected link
        ' file. If True, returns the file linked to the LNK file.
        SaveFileDialog.DereferenceLinks = True

        ' Just as in VB6, use a set of pairs of filters, separated with "|". Each 
        ' pair consists of a description|file spec. Use a "|" between pairs. No need to put a
        ' trailing "|". You can set the FilterIndex property as well, to select the default
        ' filter. The first filter is numbered 1 (not 0). The default is 1. 
        SaveFileDialog.Filter =
            "(*.txt)|*.txt*"

        'SaveFileDialog.Multiselect = False

        ' Restore the original directory when done selecting
        ' a file? If False, the current directory changes
        ' to the directory in which you selected the file.
        ' Set this to True to put the current folder back
        ' where it was when you started.
        ' The default is False.
        '.RestoreDirectory = False

        ' Show the Help button and Read-Only checkbox?
        SaveFileDialog.ShowHelp = False
        'SaveFileDialog.ShowReadOnly = False

        ' Start out with the read-only check box checked?
        ' This only make sense if ShowReadOnly is True.
        'SaveFileDialog.ReadOnlyChecked = False

        SaveFileDialog.Title = "Save as"

        ' Only accept valid Win32 file names?
        SaveFileDialog.ValidateNames = True


        If SaveFileDialog.ShowDialog = DialogResult.OK Then

            If File.Exists(SaveFileDialog.FileName) Then
                File.Delete(SaveFileDialog.FileName)
            End If

            Using w As StreamWriter = File.AppendText(SaveFileDialog.FileName)
                w.WriteLine(TextBox1.Text)
                w.WriteLine(TextBox2.Text)
                w.WriteLine(TextBox4.Text)
                w.WriteLine(TextBox3.Text)
                w.WriteLine(TextBox6.Text)
                w.WriteLine(TextBox5.Text)
                w.WriteLine(TextBox8.Text)
                w.WriteLine(TextBox7.Text)
                w.WriteLine(TextBox9.Text)
                w.WriteLine(TextBox13.Text)
                w.WriteLine(TextBox12.Text)
            End Using

        End If

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        fileOpenDialog.FileName = ""
        fileOpenDialog.CheckFileExists = True

        ' Check to ensure that the selected path exists.  Dialog box displays 
        ' a warning otherwise.
        fileOpenDialog.CheckPathExists = True

        ' Get or set default extension. Doesn't include the leading ".".
        fileOpenDialog.DefaultExt = "txt"

        ' Return the file referenced by a link? If False, simply returns the selected link
        ' file. If True, returns the file linked to the LNK file.
        fileOpenDialog.DereferenceLinks = True

        ' Just as in VB6, use a set of pairs of filters, separated with "|". Each 
        ' pair consists of a description|file spec. Use a "|" between pairs. No need to put a
        ' trailing "|". You can set the FilterIndex property as well, to select the default
        ' filter. The first filter is numbered 1 (not 0). The default is 1. 
        fileOpenDialog.Filter =
            "(*.txt)|*.txt*"

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

        fileOpenDialog.Title = "Select txt file to open"

        ' Only accept valid Win32 file names?
        fileOpenDialog.ValidateNames = True


        If fileOpenDialog.ShowDialog = DialogResult.OK Then

            Dim reader As New System.IO.StreamReader(fileOpenDialog.FileName)
            Dim allLines As List(Of String) = New List(Of String)
            Do While Not reader.EndOfStream
                allLines.Add(reader.ReadLine())
            Loop

            TextBox1.Text = ReadLine(1, allLines)
            TextBox2.Text = ReadLine(2, allLines)
            TextBox4.Text = ReadLine(3, allLines)
            TextBox3.Text = ReadLine(4, allLines)
            TextBox6.Text = ReadLine(5, allLines)
            TextBox5.Text = ReadLine(6, allLines)
            TextBox8.Text = ReadLine(7, allLines)
            TextBox7.Text = ReadLine(8, allLines)
            TextBox9.Text = ReadLine(9, allLines)
            TextBox13.Text = ReadLine(10, allLines)
            TextBox12.Text = ReadLine(11, allLines)

        End If

    End Sub

    Public Function ReadLine(lineNumber As Integer, lines As List(Of String)) As String
        Return lines(lineNumber - 1)
    End Function

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox4.Text = "" Or TextBox3.Text = "" Or TextBox6.Text = "" Or TextBox5.Text = "" Or TextBox8.Text = "" Or TextBox7.Text = "" Or TextBox9.Text = "" Then

            MsgBox("Please check that you have loaded all the files!")
            Exit Sub

        End If

        Dim start_time As DateTime
        Dim stop_time As DateTime
        Dim elapsed_time As TimeSpan

        start_time = Now

        Button5_Click(sender, e)

        MEBlocksPictureBox.Height = BlocksImage.Height * 2
        MEBlocksPictureBox.Width = BlocksImage.Width * 2

        MEBlocksPictureBox.Image = BlocksImage
        MEBlocksPictureBox.Refresh()

        MapPictureBox.Image = MapDatatoBitmap(BlocksImage, TextBox9.Text, TextBox13.Text, TextBox12.Text)

        MapPictureBox.Height = TextBox13.Text * 2 * 16
        MapPictureBox.Width = TextBox12.Text * 2 * 16

        MapPanel.Width = GroupBox4.Width - 20
        MapPanel.Height = GroupBox4.Height - 50

        SelectedBlockInMapEditor = 0


        If SelectedBlockInMapEditor < 512 Then

            MapSelectedBlockPictureBox.Image = BlockToBitmap(TextBox6.Text, TextBox1.Text, TextBox4.Text, SelectedBlockInMapEditor)
        Else

            MapSelectedBlockPictureBox.Image = BlockToBitmap(TextBox5.Text, TextBox1.Text, TextBox4.Text, SelectedBlockInMapEditor)
        End If

        SelectionStatus.Text = "Selected Block: " & SelectedBlockInMapEditor

        stop_time = Now
        elapsed_time = stop_time.Subtract(start_time)
        LoadTImeLabel.Text = "Map Load Time: " & elapsed_time.TotalSeconds.ToString("0.00")

        Button14.Enabled = True
        Button15.Enabled = True

    End Sub

    Private Sub MEBlocksGroup_Resize(sender As Object, e As EventArgs) Handles MEBlocksGroup.Resize
        Panel5.Height = MEBlocksGroup.Height - 46
    End Sub

    Private Sub GroupBox4_Resize(sender As Object, e As EventArgs) Handles GroupBox4.Resize

    End Sub

    Private Sub TabPage3_Resize(sender As Object, e As EventArgs) Handles TabPage3.Resize
        GroupBox4.Width = TabPage3.Width - GroupBox5.Width - MEBlocksGroup.Width

        MapPanel.Width = GroupBox4.Width - 20
        MapPanel.Height = GroupBox4.Height - 50

    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        SaveFileDialog.FileName = ""
        'SaveFileDialog.CheckFileExists = True

        ' Check to ensure that the selected path exists.  Dialog box displays 
        ' a warning otherwise.
        SaveFileDialog.CheckPathExists = True

        ' Get or set default extension. Doesn't include the leading ".".
        SaveFileDialog.DefaultExt = "png"

        ' Return the file referenced by a link? If False, simply returns the selected link
        ' file. If True, returns the file linked to the LNK file.
        SaveFileDialog.DereferenceLinks = True

        ' Just as in VB6, use a set of pairs of filters, separated with "|". Each 
        ' pair consists of a description|file spec. Use a "|" between pairs. No need to put a
        ' trailing "|". You can set the FilterIndex property as well, to select the default
        ' filter. The first filter is numbered 1 (not 0). The default is 1. 
        SaveFileDialog.Filter =
            "(*.png)|*.png*"

        'SaveFileDialog.Multiselect = False

        ' Restore the original directory when done selecting
        ' a file? If False, the current directory changes
        ' to the directory in which you selected the file.
        ' Set this to True to put the current folder back
        ' where it was when you started.
        ' The default is False.
        '.RestoreDirectory = False

        ' Show the Help button and Read-Only checkbox?
        SaveFileDialog.ShowHelp = False
        'SaveFileDialog.ShowReadOnly = False

        ' Start out with the read-only check box checked?
        ' This only make sense if ShowReadOnly is True.
        'SaveFileDialog.ReadOnlyChecked = False

        SaveFileDialog.Title = "Save as"

        ' Only accept valid Win32 file names?
        SaveFileDialog.ValidateNames = True


        If SaveFileDialog.ShowDialog = DialogResult.OK Then

            MapPictureBox.Image.Save(SaveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png)

        End If

    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox4.Text = "" Or TextBox3.Text = "" Or TextBox6.Text = "" Or TextBox5.Text = "" Or TextBox8.Text = "" Or TextBox7.Text = "" Or TextBox9.Text = "" Then

            MsgBox("Please check that you have loaded all the files!")
            Exit Sub

        End If

        Dim start_time As DateTime
        Dim stop_time As DateTime
        Dim elapsed_time As TimeSpan

        start_time = Now

        Button13_Click(sender, e)

        PictureBox1.Image = MapWithPermissions

        PictureBox1.Height = TextBox13.Text * 2 * 16
        PictureBox1.Width = TextBox12.Text * 2 * 16

        Panel8.Width = GroupBox7.Width - 20
        Panel8.Height = GroupBox7.Height - 50

        PictureBox2.Load(AppPath & "img\moveperms.png")
        PictureBox2.Height = 1024 * 2
        PictureBox2.Width = 16 * 2

        ' Panel9.Height = GroupBox8.Height - 100

        SelectedPermInPermEditor = 0

        Dim PermissionsBitMap As New Bitmap(AppPath & "img\moveperms.png", True)
        Dim SinglePerm As New Bitmap(16, 16)
        BitmapBLT(PermissionsBitMap, SinglePerm, 0, 0, 0, SelectedPermInPermEditor * 16, 16, 16)

        SelectionStatus.Text = "Selected Permission: " & SelectedPermInPermEditor

        SelectedPermPictureBox.Image = SinglePerm

        stop_time = Now
        elapsed_time = stop_time.Subtract(start_time)
        LoadTImeLabel.Text = "Movement Permission Load Time: " & elapsed_time.TotalSeconds.ToString("0.00")

        Button14.Enabled = True

    End Sub

    Private Sub TabPage4_Resize(sender As Object, e As EventArgs) Handles TabPage4.Resize
        GroupBox7.Width = TabPage4.Width - GroupBox8.Width - GroupBox6.Width

        Panel8.Width = GroupBox7.Width - 20
        Panel8.Height = GroupBox7.Height - 50

        GroupBox8.Height = TabPage4.Height - 50
        Panel9.Height = TabPage4.Height - 50

    End Sub

    Private Sub TextBox13_TextChanged(sender As Object, e As EventArgs) Handles TextBox13.TextChanged

    End Sub

    Private Sub TextBox12_TextChanged(sender As Object, e As EventArgs) Handles TextBox12.TextChanged

    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        fileOpenDialog.FileName = ""
        fileOpenDialog.CheckFileExists = True

        ' Check to ensure that the selected path exists.  Dialog box displays 
        ' a warning otherwise.
        fileOpenDialog.CheckPathExists = True

        ' Get or set default extension. Doesn't include the leading ".".
        fileOpenDialog.DefaultExt = "bin"

        ' Return the file referenced by a link? If False, simply returns the selected link
        ' file. If True, returns the file linked to the LNK file.
        fileOpenDialog.DereferenceLinks = True

        ' Just as in VB6, use a set of pairs of filters, separated with "|". Each 
        ' pair consists of a description|file spec. Use a "|" between pairs. No need to put a
        ' trailing "|". You can set the FilterIndex property as well, to select the default
        ' filter. The first filter is numbered 1 (not 0). The default is 1. 
        fileOpenDialog.Filter =
            "(*.bin)|*.bin*"

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

        fileOpenDialog.Title = "Select bin to open:"

        ' Only accept valid Win32 file names?
        fileOpenDialog.ValidateNames = True


        If fileOpenDialog.ShowDialog = DialogResult.OK Then

            TextBox9.Text = fileOpenDialog.FileName


        End If
    End Sub

    Private Sub TilesPictureBox_Click(sender As Object, e As EventArgs) Handles TilesPictureBox.Click
        Dim [me] As MouseEventArgs = DirectCast(e, MouseEventArgs)
        Dim coordinates As Point = [me].Location

        If [me].Button = MouseButtons.Right Then

        ElseIf [me].Button = MouseButtons.left Then
            SelectedTileImgInBlockEditor = (Math.Floor(coordinates.X / (8 * 2)) + (Math.Floor(coordinates.Y / (8 * 2)) * 16))

            If SelectedTileImgInBlockEditor < 512 Then

                SelectedTilePictureBox.Image = LoadSingleTileToBitmap2(TileSet1Image, SelectedTileImgInBlockEditor, TilePals(SelectedTileImgInBlockEditorPal), True, RotateFlipType.RotateNoneFlipNone)


            Else

                SelectedTilePictureBox.Image = LoadSingleTileToBitmap2(TileSet2Image, SelectedTileImgInBlockEditor - 512, TilePals(SelectedTileImgInBlockEditorPal), True, RotateFlipType.RotateNoneFlipNone)

            End If

            SelectionStatus.Text = "Selected Tile: " & SelectedTileImgInBlockEditor

        End If

    End Sub

    Private Sub MnFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub BlockSetsPictureBox_Click(sender As Object, e As EventArgs) Handles BlockSetsPictureBox.Click
        Dim [me] As MouseEventArgs = DirectCast(e, MouseEventArgs)
        Dim coordinates As Point = [me].Location

        If [me].Button = MouseButtons.Right Then

        ElseIf [me].Button = MouseButtons.Left Then
            SelectedBlockInBlockEditor = (Math.Floor(coordinates.X / (16 * 2)) + (Math.Floor(coordinates.Y / (16 * 2)) * 8))

            If SelectedBlockInBlockEditor < 512 Then

                SelectedBlockPictureBox.Image = BlockToBitmap(TextBox6.Text, TextBox1.Text, TextBox4.Text, SelectedBlockInBlockEditor)
                BlockBottomPictureBox.Image = BlockBottomToBitmap(TextBox6.Text, TextBox1.Text, TextBox4.Text, SelectedBlockInBlockEditor)
                BlockTopPictureBox.Image = BlockTopToBitmap(TextBox6.Text, TextBox1.Text, TextBox4.Text, SelectedBlockInBlockEditor)
            Else

                SelectedBlockPictureBox.Image = BlockToBitmap(TextBox5.Text, TextBox1.Text, TextBox4.Text, SelectedBlockInBlockEditor)
                BlockBottomPictureBox.Image = BlockBottomToBitmap(TextBox6.Text, TextBox1.Text, TextBox4.Text, SelectedBlockInBlockEditor)
                BlockTopPictureBox.Image = BlockTopToBitmap(TextBox6.Text, TextBox1.Text, TextBox4.Text, SelectedBlockInBlockEditor)
            End If

            SelectionStatus.Text = "Selected Block: " & SelectedBlockInBlockEditor

        End If
    End Sub

    Private Sub MEBlocksPictureBox_Click(sender As Object, e As EventArgs) Handles MEBlocksPictureBox.Click
        Dim [me] As MouseEventArgs = DirectCast(e, MouseEventArgs)
        Dim coordinates As Point = [me].Location

        If [me].Button = MouseButtons.Right Then

        ElseIf [me].Button = MouseButtons.Left Then
            SelectedBlockInMapEditor = (Math.Floor(coordinates.X / (16 * 2)) + (Math.Floor(coordinates.Y / (16 * 2)) * 8))

            If SelectedBlockInMapEditor < 512 Then

                MapSelectedBlockPictureBox.Image = BlockToBitmap(TextBox6.Text, TextBox1.Text, TextBox4.Text, SelectedBlockInMapEditor)
            Else

                MapSelectedBlockPictureBox.Image = BlockToBitmap(TextBox5.Text, TextBox1.Text, TextBox4.Text, SelectedBlockInMapEditor)
            End If

            SelectionStatus.Text = "Selected Block: " & SelectedBlockInMapEditor

        End If
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click

        Dim size As Integer = TextBox13.Text * TextBox12.Text

        Dim loopvar As Integer = 0

        Dim tilebin As String
        Dim permbin As String

        While loopvar < size

            tilebin = VB.Right("0000000000" & Convert.ToString(Convert.ToInt32(MapTilesArray(loopvar)), 2), 10)
            permbin = VB.Right("000000" & Convert.ToString(Convert.ToInt32(MapPermsArray(loopvar)), 2), 6)

            WriteHEX(TextBox9.Text, loopvar * 2, ReverseHEX(VB.Right("0000" & Hex(Convert.ToInt32(permbin & tilebin, 2)), 4)))

            loopvar = loopvar + 1

        End While

        MsgBox("Map saved!")

        'MsgBox(MapTilesArray(0))

        'MapTilesArray
        'MapPermsArray
    End Sub

    Private Sub MapPictureBox_MouseHover(sender As Object, e As EventArgs) Handles MapPictureBox.MouseHover

    End Sub

    Private Sub MapPictureBox_MouseMove(sender As Object, e As MouseEventArgs) Handles MapPictureBox.MouseMove
        Dim [me] As MouseEventArgs = DirectCast(e, MouseEventArgs)
        Dim coordinates As Point = [me].Location

        XYCoord.Text = "X: " & Math.Floor(coordinates.X / (16 * 2)) & " Y: " & (Math.Floor(coordinates.Y / (16 * 2)))

    End Sub

    Private Sub MapPictureBox_MouseClick(sender As Object, e As MouseEventArgs) Handles MapPictureBox.MouseClick

    End Sub

    Private Sub MapPictureBox_Click(sender As Object, e As EventArgs) Handles MapPictureBox.Click
        Dim [me] As MouseEventArgs = DirectCast(e, MouseEventArgs)
        Dim coordinates As Point = [me].Location

        If [me].Button = MouseButtons.Right Then

            SelectedBlockInMapEditor = MapTilesArray((Math.Floor(coordinates.X / (16 * 2)) + (Math.Floor(coordinates.Y / (16 * 2)) * TextBox12.Text)))

            If SelectedBlockInMapEditor < 512 Then

                MapSelectedBlockPictureBox.Image = BlockToBitmap(TextBox6.Text, TextBox1.Text, TextBox4.Text, SelectedBlockInMapEditor)
            Else

                MapSelectedBlockPictureBox.Image = BlockToBitmap(TextBox5.Text, TextBox1.Text, TextBox4.Text, SelectedBlockInMapEditor)
            End If

            SelectionStatus.Text = "Selected Block: " & SelectedBlockInMapEditor

        ElseIf [me].Button = MouseButtons.Left Then

            MapTilesArray((Math.Floor(coordinates.X / (16 * 2)) + (Math.Floor(coordinates.Y / (16 * 2)) * TextBox12.Text))) = SelectedBlockInMapEditor

            Dim MapBitmap As New Bitmap(MapPictureBox.Image)
            Dim TileBitmap As New Bitmap(MapSelectedBlockPictureBox.Image)

            BitmapBLT(TileBitmap, MapBitmap, Math.Floor(coordinates.X / (16 * 2)) * 16, (Math.Floor(coordinates.Y / (16 * 2))) * 16, 0, 0, 16, 16)

            MapPictureBox.Image = MapBitmap

        End If
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click

        Dim size As Integer = TextBox13.Text * TextBox12.Text

        Dim loopvar As Integer = 0

        Dim tilebin As String
        Dim permbin As String

        While loopvar < size

            tilebin = VB.Right("0000000000" & Convert.ToString(Convert.ToInt32(MapTilesArray(loopvar)), 2), 10)
            permbin = VB.Right("000000" & Convert.ToString(Convert.ToInt32(MapPermsArray(loopvar)), 2), 6)

            WriteHEX(TextBox9.Text, loopvar * 2, ReverseHEX(VB.Right("0000" & Hex(Convert.ToInt32(permbin & tilebin, 2)), 4)))

            loopvar = loopvar + 1

        End While

        MsgBox("Map saved!")

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim [me] As MouseEventArgs = DirectCast(e, MouseEventArgs)
        Dim coordinates As Point = [me].Location

        If [me].Button = MouseButtons.Right Then

            SelectedPermInPermEditor = MapPermsArray((Math.Floor(coordinates.X / (16 * 2)) + (Math.Floor(coordinates.Y / (16 * 2)) * TextBox12.Text)))

            SelectionStatus.Text = "Selected Permission: " & SelectedPermInPermEditor

            Dim PermissionsBitMap As New Bitmap(AppPath & "img\moveperms.png", True)
            Dim SinglePerm As New Bitmap(16, 16)
            BitmapBLT(PermissionsBitMap, SinglePerm, 0, 0, 0, SelectedPermInPermEditor * 16, 16, 16)

            SelectedPermPictureBox.Image = SinglePerm

        ElseIf [me].Button = MouseButtons.Left Then

            MapPermsArray((Math.Floor(coordinates.X / (16 * 2)) + (Math.Floor(coordinates.Y / (16 * 2)) * TextBox12.Text))) = SelectedPermInPermEditor

            Dim MapBitmap As New Bitmap(PictureBox1.Image)
            Dim TileBitmap As New Bitmap(BlockToBitmap(TextBox6.Text, TextBox1.Text, TextBox4.Text, MapTilesArray((Math.Floor(coordinates.X / (16 * 2)) + (Math.Floor(coordinates.Y / (16 * 2)) * TextBox12.Text)))))
            Dim PermBitmap As New Bitmap(SelectedPermPictureBox.Image)

            Dim g As Graphics = Graphics.FromImage(TileBitmap)
            g.DrawImage(PermBitmap, 0, 0)


            BitmapBLT(TileBitmap, MapBitmap, Math.Floor(coordinates.X / (16 * 2)) * 16, (Math.Floor(coordinates.Y / (16 * 2))) * 16, 0, 0, 16, 16)

            PictureBox1.Image = MapBitmap

        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim [me] As MouseEventArgs = DirectCast(e, MouseEventArgs)
        Dim coordinates As Point = [me].Location

        If [me].Button = MouseButtons.Right Then

        ElseIf [me].Button = MouseButtons.Left Then
            SelectedPermInPermEditor = (Math.Floor(coordinates.Y / (32)))

            SelectionStatus.Text = "Selected Permission: " & SelectedPermInPermEditor

            Dim PermissionsBitMap As New Bitmap(AppPath & "img\moveperms.png", True)
            Dim SinglePerm As New Bitmap(16, 16)
            BitmapBLT(PermissionsBitMap, SinglePerm, 0, 0, 0, SelectedPermInPermEditor * 16, 16, 16)

            SelectedPermPictureBox.Image = SinglePerm

            'MsgBox(PictureBox2.Height)

        End If

    End Sub
End Class
