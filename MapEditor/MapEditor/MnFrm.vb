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

        SelectedBlockInBlockEditor = 0

        If SelectedBlockInBlockEditor < 512 Then

            loopvar = 0

            Dim tilenum As Integer = 0
            Dim palnum As Integer = 0
            Dim Yflip As Integer
            Dim Xflip As Integer
            Dim Curbytesbin As String = ""
            Dim Flips As RotateFlipType



            While loopvar < 8

                If SelectedBlockInBlockEditor < 512 Then

                    Curbytesbin = VB.Right("0000000000000000" & Convert.ToString(Int32.Parse(ReverseHEX(ReadHEX(TextBox6.Text, SelectedBlockInBlockEditor * 16 + (loopvar * 2), 2)), System.Globalization.NumberStyles.HexNumber), 2), 16)

                Else

                    Curbytesbin = VB.Right("0000000000000000" & Convert.ToString(Int32.Parse(ReverseHEX(ReadHEX(TextBox5.Text, (SelectedBlockInBlockEditor - 512) * 16 + (loopvar * 2), 2)), System.Globalization.NumberStyles.HexNumber), 2), 16)

                End If

                tilenum = Convert.ToInt32(Curbytesbin.Remove(0, 6), 2)
                palnum = Convert.ToInt32(Curbytesbin.Substring(0, 4), 2)
                Yflip = Convert.ToInt32(Curbytesbin.Substring(4, 1), 2)
                Xflip = Convert.ToInt32(Curbytesbin.Substring(5, 1), 2)

                If palnum > 12 Then
                    palnum = 12
                End If

                SelectedBlockPals(loopvar) = palnum
                SelectedBlockY(loopvar) = Yflip
                SelectedBlockX(loopvar) = Xflip
                SelectedBlockTile(loopvar) = tilenum


                loopvar = loopvar + 1

            End While

            SelectedBlockPictureBox.Image = BlockToBitmap(TextBox6.Text, TextBox1.Text, TextBox4.Text, SelectedBlockInBlockEditor)
            BlockBottomPictureBox.Image = BlockBottomToBitmap(TextBox6.Text, TextBox1.Text, TextBox4.Text, SelectedBlockInBlockEditor)
            BlockTopPictureBox.Image = BlockTopToBitmap(TextBox6.Text, TextBox1.Text, TextBox4.Text, SelectedBlockInBlockEditor)

            BehaviorComboBox.SelectedIndex = "&H" & ReadHEX(TextBox8.Text, SelectedBlockInBlockEditor * 2, 1)
            BackgroundComboBox.SelectedIndex = "&H" & ReadHEX(TextBox8.Text, 1 + (SelectedBlockInBlockEditor * 2), 1)
        Else

            loopvar = 0

            Dim tilenum As Integer = 0
            Dim palnum As Integer = 0
            Dim Yflip As Integer
            Dim Xflip As Integer
            Dim Curbytesbin As String = ""
            Dim Flips As RotateFlipType



            While loopvar < 8

                If SelectedBlockInBlockEditor < 512 Then

                    Curbytesbin = VB.Right("0000000000000000" & Convert.ToString(Int32.Parse(ReverseHEX(ReadHEX(TextBox6.Text, SelectedBlockInBlockEditor * 16 + (loopvar * 2), 2)), System.Globalization.NumberStyles.HexNumber), 2), 16)

                Else

                    Curbytesbin = VB.Right("0000000000000000" & Convert.ToString(Int32.Parse(ReverseHEX(ReadHEX(TextBox5.Text, (SelectedBlockInBlockEditor - 512) * 16 + (loopvar * 2), 2)), System.Globalization.NumberStyles.HexNumber), 2), 16)

                End If

                tilenum = Convert.ToInt32(Curbytesbin.Remove(0, 6), 2)
                palnum = Convert.ToInt32(Curbytesbin.Substring(0, 4), 2)
                Yflip = Convert.ToInt32(Curbytesbin.Substring(4, 1), 2)
                Xflip = Convert.ToInt32(Curbytesbin.Substring(5, 1), 2)

                If palnum > 12 Then
                    palnum = 12
                End If

                SelectedBlockPals(loopvar) = palnum
                SelectedBlockY(loopvar) = Yflip
                SelectedBlockX(loopvar) = Xflip
                SelectedBlockTile(loopvar) = tilenum


                loopvar = loopvar + 1

            End While

            SelectedBlockPictureBox.Image = BlockToBitmap(TextBox5.Text, TextBox1.Text, TextBox4.Text, SelectedBlockInBlockEditor)
            BlockBottomPictureBox.Image = BlockBottomToBitmap(TextBox6.Text, TextBox1.Text, TextBox4.Text, SelectedBlockInBlockEditor)
            BlockTopPictureBox.Image = BlockTopToBitmap(TextBox6.Text, TextBox1.Text, TextBox4.Text, SelectedBlockInBlockEditor)

            BehaviorComboBox.SelectedIndex = "&H" & ReadHEX(TextBox7.Text, SelectedBlockInBlockEditor * 2, 1)
            BackgroundComboBox.SelectedIndex = "&H" & ReadHEX(TextBox7.Text, 1 + (SelectedBlockInBlockEditor * 2), 1)
        End If

        SelectionStatus.Text = "Selected Block: " & SelectedBlockInBlockEditor


        stop_time = Now
        elapsed_time = stop_time.Subtract(start_time)
        LoadTImeLabel.Text = "Block Load Time: " & elapsed_time.TotalSeconds.ToString("0.00")

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

            Dim Flips As RotateFlipType

            If SelectedTileImgInBlockEditorY = 0 And SelectedTileImgInBlockEditorX = 0 Then

                Flips = RotateFlipType.RotateNoneFlipNone

            ElseIf SelectedTileImgInBlockEditorY = 0 And SelectedTileImgInBlockEditorX = 1 Then

                Flips = RotateFlipType.RotateNoneFlipX

            ElseIf SelectedTileImgInBlockEditorY = 1 And SelectedTileImgInBlockEditorX = 0 Then

                Flips = RotateFlipType.RotateNoneFlipY

            ElseIf SelectedTileImgInBlockEditorY = 1 And SelectedTileImgInBlockEditorX = 1 Then

                Flips = RotateFlipType.RotateNoneFlipXY

            End If

            If SelectedTileImgInBlockEditor < 512 Then

                SelectedTilePictureBox.Image = LoadSingleTileToBitmap2(TileSet1Image, SelectedTileImgInBlockEditor, TilePals(SelectedTileImgInBlockEditorPal), True, Flips)


            Else

                SelectedTilePictureBox.Image = LoadSingleTileToBitmap2(TileSet2Image, SelectedTileImgInBlockEditor - 512, TilePals(SelectedTileImgInBlockEditorPal), True, Flips)

            End If

        End If

    End Sub

    Private Sub GroupBox1_Resize(sender As Object, e As EventArgs) Handles GroupBox1.Resize
        Panel3.Height = GroupBox1.Height - 100
    End Sub

    Private Sub LoadBlockset()

        Dim PrimaryBlocksInfo As New FileInfo(TextBox6.Text)
        Dim SecondaryBlocksInfo As New FileInfo(TextBox5.Text)

        Dim loopvar As Integer = 0

        Dim BlockHeight As Integer = (((PrimaryBlocksInfo.Length + SecondaryBlocksInfo.Length) / 2) / 8) / 8

        BlockHeight = BlockHeight + 1

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

                'MsgBox(System.IO.Path.GetFileName(TextBox1.Text))

                w.WriteLine("@\" & System.IO.Path.GetFileName(TextBox1.Text))
                w.WriteLine("@\" & System.IO.Path.GetFileName(TextBox2.Text))
                w.WriteLine("@\" & System.IO.Path.GetFileName(TextBox4.Text))
                w.WriteLine("@\" & System.IO.Path.GetFileName(TextBox3.Text))
                w.WriteLine("@\" & System.IO.Path.GetFileName(TextBox6.Text))
                w.WriteLine("@\" & System.IO.Path.GetFileName(TextBox5.Text))
                w.WriteLine("@\" & System.IO.Path.GetFileName(TextBox8.Text))
                w.WriteLine("@\" & System.IO.Path.GetFileName(TextBox7.Text))
                w.WriteLine("@\" & System.IO.Path.GetFileName(TextBox9.Text))
                w.WriteLine(TextBox13.Text)
                w.WriteLine(TextBox12.Text)
                w.WriteLine("@\" & System.IO.Path.GetFileName(TextBox10.Text))
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

            'MsgBox(System.IO.Path.GetDirectoryName(fileOpenDialog.FileName))

            TextBox1.Text = Replace(ReadLine(1, allLines), "@", System.IO.Path.GetDirectoryName(fileOpenDialog.FileName), 1, 1)
            TextBox2.Text = Replace(ReadLine(2, allLines), "@", System.IO.Path.GetDirectoryName(fileOpenDialog.FileName), 1, 1)
            TextBox4.Text = Replace(ReadLine(3, allLines), "@", System.IO.Path.GetDirectoryName(fileOpenDialog.FileName), 1, 1)
            TextBox3.Text = Replace(ReadLine(4, allLines), "@", System.IO.Path.GetDirectoryName(fileOpenDialog.FileName), 1, 1)
            TextBox6.Text = Replace(ReadLine(5, allLines), "@", System.IO.Path.GetDirectoryName(fileOpenDialog.FileName), 1, 1)
            TextBox5.Text = Replace(ReadLine(6, allLines), "@", System.IO.Path.GetDirectoryName(fileOpenDialog.FileName), 1, 1)
            TextBox8.Text = Replace(ReadLine(7, allLines), "@", System.IO.Path.GetDirectoryName(fileOpenDialog.FileName), 1, 1)
            TextBox7.Text = Replace(ReadLine(8, allLines), "@", System.IO.Path.GetDirectoryName(fileOpenDialog.FileName), 1, 1)
            TextBox9.Text = Replace(ReadLine(9, allLines), "@", System.IO.Path.GetDirectoryName(fileOpenDialog.FileName), 1, 1)
            TextBox13.Text = ReadLine(10, allLines)
            TextBox12.Text = ReadLine(11, allLines)
            TextBox10.Text = Replace(ReadLine(12, allLines), "@", System.IO.Path.GetDirectoryName(fileOpenDialog.FileName), 1, 1)

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
        Panel5.Height = MEBlocksGroup.Height - 100
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

            SelectedTileImgInBlockEditorX = 0
            SelectedTileImgInBlockEditorY = 0

            CheckBox3.Checked = False
            CheckBox4.Checked = False

            If SelectedTileImgInBlockEditor < 512 Then

                SelectedTilePictureBox.Image = LoadSingleTileToBitmap2(TileSet1Image, SelectedTileImgInBlockEditor, TilePals(SelectedTileImgInBlockEditorPal), True, RotateFlipType.RotateNoneFlipNone)


            Else

                SelectedTilePictureBox.Image = LoadSingleTileToBitmap2(TileSet2Image, SelectedTileImgInBlockEditor - 512, TilePals(SelectedTileImgInBlockEditorPal), True, RotateFlipType.RotateNoneFlipNone)

            End If

            SelectionStatus.Text = "Selected Tile: " & SelectedTileImgInBlockEditor

        End If

    End Sub

    Private Sub MnFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        BehaviorComboBox.Items.Clear()

        BehaviorComboBox.Items.AddRange(IO.File.ReadAllLines(AppPath & "txt\BehaviorBytes.txt"))

        BackgroundComboBox.Items.Clear()

        BackgroundComboBox.Items.AddRange(IO.File.ReadAllLines(AppPath & "txt\BackgroundBytes.txt"))

        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub BlockSetsPictureBox_Click(sender As Object, e As EventArgs) Handles BlockSetsPictureBox.Click
        Dim [me] As MouseEventArgs = DirectCast(e, MouseEventArgs)
        Dim coordinates As Point = [me].Location

        If [me].Button = MouseButtons.Right Then

            SelectedBlockInBlockEditor = (Math.Floor(coordinates.X / (16 * 2)) + (Math.Floor(coordinates.Y / (16 * 2)) * 8))



        ElseIf [me].Button = MouseButtons.Left Then
            SelectedBlockInBlockEditor = (Math.Floor(coordinates.X / (16 * 2)) + (Math.Floor(coordinates.Y / (16 * 2)) * 8))

            If SelectedBlockInBlockEditor < 512 Then

                Dim loopvar As Integer = 0

                Dim tilenum As Integer = 0
                Dim palnum As Integer = 0
                Dim Yflip As Integer
                Dim Xflip As Integer
                Dim Curbytesbin As String = ""
                Dim Flips As RotateFlipType



                While loopvar < 8

                    If SelectedBlockInBlockEditor < 512 Then

                        Curbytesbin = VB.Right("0000000000000000" & Convert.ToString(Int32.Parse(ReverseHEX(ReadHEX(TextBox6.Text, SelectedBlockInBlockEditor * 16 + (loopvar * 2), 2)), System.Globalization.NumberStyles.HexNumber), 2), 16)

                    Else

                        Curbytesbin = VB.Right("0000000000000000" & Convert.ToString(Int32.Parse(ReverseHEX(ReadHEX(TextBox5.Text, (SelectedBlockInBlockEditor - 512) * 16 + (loopvar * 2), 2)), System.Globalization.NumberStyles.HexNumber), 2), 16)

                    End If

                    tilenum = Convert.ToInt32(Curbytesbin.Remove(0, 6), 2)
                    palnum = Convert.ToInt32(Curbytesbin.Substring(0, 4), 2)
                    Yflip = Convert.ToInt32(Curbytesbin.Substring(4, 1), 2)
                    Xflip = Convert.ToInt32(Curbytesbin.Substring(5, 1), 2)

                    If palnum > 12 Then
                        palnum = 12
                    End If

                    SelectedBlockPals(loopvar) = palnum
                    SelectedBlockY(loopvar) = Yflip
                    SelectedBlockX(loopvar) = Xflip
                    SelectedBlockTile(loopvar) = tilenum


                    loopvar = loopvar + 1

                End While

                SelectedBlockPictureBox.Image = BlockToBitmap(TextBox6.Text, TextBox1.Text, TextBox4.Text, SelectedBlockInBlockEditor)
                    BlockBottomPictureBox.Image = BlockBottomToBitmap(TextBox6.Text, TextBox1.Text, TextBox4.Text, SelectedBlockInBlockEditor)
                BlockTopPictureBox.Image = BlockTopToBitmap(TextBox6.Text, TextBox1.Text, TextBox4.Text, SelectedBlockInBlockEditor)

                BehaviorComboBox.SelectedIndex = "&H" & ReadHEX(TextBox8.Text, SelectedBlockInBlockEditor * 2, 1)
                BackgroundComboBox.SelectedIndex = "&H" & ReadHEX(TextBox8.Text, 1 + (SelectedBlockInBlockEditor * 2), 1)
            Else

                Dim loopvar As Integer = 0

                Dim tilenum As Integer = 0
                Dim palnum As Integer = 0
                Dim Yflip As Integer
                Dim Xflip As Integer
                Dim Curbytesbin As String = ""
                Dim Flips As RotateFlipType



                While loopvar < 8

                    If SelectedBlockInBlockEditor < 512 Then

                        Curbytesbin = VB.Right("0000000000000000" & Convert.ToString(Int32.Parse(ReverseHEX(ReadHEX(TextBox6.Text, SelectedBlockInBlockEditor * 16 + (loopvar * 2), 2)), System.Globalization.NumberStyles.HexNumber), 2), 16)

                    Else

                        Curbytesbin = VB.Right("0000000000000000" & Convert.ToString(Int32.Parse(ReverseHEX(ReadHEX(TextBox5.Text, (SelectedBlockInBlockEditor - 512) * 16 + (loopvar * 2), 2)), System.Globalization.NumberStyles.HexNumber), 2), 16)

                    End If

                    tilenum = Convert.ToInt32(Curbytesbin.Remove(0, 6), 2)
                    palnum = Convert.ToInt32(Curbytesbin.Substring(0, 4), 2)
                    Yflip = Convert.ToInt32(Curbytesbin.Substring(4, 1), 2)
                    Xflip = Convert.ToInt32(Curbytesbin.Substring(5, 1), 2)

                    If palnum > 12 Then
                        palnum = 12
                    End If

                    SelectedBlockPals(loopvar) = palnum
                    SelectedBlockY(loopvar) = Yflip
                    SelectedBlockX(loopvar) = Xflip
                    SelectedBlockTile(loopvar) = tilenum


                    loopvar = loopvar + 1

                End While

                If SelectedBlockInBlockEditor < 512 Then

                    SelectedBlockPictureBox.Image = BlockToBitmap(TextBox6.Text, TextBox1.Text, TextBox4.Text, SelectedBlockInBlockEditor)
                    BlockBottomPictureBox.Image = BlockBottomToBitmap(TextBox6.Text, TextBox1.Text, TextBox4.Text, SelectedBlockInBlockEditor)
                    BlockTopPictureBox.Image = BlockTopToBitmap(TextBox6.Text, TextBox1.Text, TextBox4.Text, SelectedBlockInBlockEditor)

                    BehaviorComboBox.SelectedIndex = "&H" & ReadHEX(TextBox8.Text, SelectedBlockInBlockEditor * 2, 1)
                    BackgroundComboBox.SelectedIndex = "&H" & ReadHEX(TextBox8.Text, 1 + (SelectedBlockInBlockEditor * 2), 1)

                Else

                    SelectedBlockPictureBox.Image = BlockToBitmap(TextBox5.Text, TextBox1.Text, TextBox4.Text, SelectedBlockInBlockEditor)
                    BlockBottomPictureBox.Image = BlockBottomToBitmap(TextBox5.Text, TextBox1.Text, TextBox4.Text, SelectedBlockInBlockEditor)
                    BlockTopPictureBox.Image = BlockTopToBitmap(TextBox5.Text, TextBox1.Text, TextBox4.Text, SelectedBlockInBlockEditor)

                    BehaviorComboBox.SelectedIndex = "&H" & ReadHEX(TextBox7.Text, (SelectedBlockInBlockEditor * 2) - (512 * 2), 1)
                    BackgroundComboBox.SelectedIndex = "&H" & ReadHEX(TextBox7.Text, 1 + (SelectedBlockInBlockEditor * 2) - (512 * 2), 1)

                End If


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

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
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

            TextBox10.Text = fileOpenDialog.FileName


        End If
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        If TextBox10.Text = "" Or TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox4.Text = "" Or TextBox3.Text = "" Or TextBox6.Text = "" Or TextBox5.Text = "" Or TextBox8.Text = "" Or TextBox7.Text = "" Or TextBox9.Text = "" Then

            MsgBox("Please check that you have loaded all the files!")
            Exit Sub

        End If

        Dim start_time As DateTime
        Dim stop_time As DateTime
        Dim elapsed_time As TimeSpan

        start_time = Now

        Button5_Click(sender, e)

        MEBlocksPictureBox2.Height = BlocksImage.Height * 2
        MEBlocksPictureBox2.Width = BlocksImage.Width * 2

        MEBlocksPictureBox2.Image = BlocksImage
        MEBlocksPictureBox2.Refresh()

        BorderPictureBox.Image = BorderDatatoBitmap(BlocksImage, TextBox10.Text, 2, 2)

        BorderPictureBox.Height = 2 * 2 * 16
        BorderPictureBox.Width = 2 * 2 * 16

        SelectedBlockInBorderEditor = 0


        If SelectedBlockInBorderEditor < 512 Then

            BorderSelectedBlockPictureBox.Image = BlockToBitmap(TextBox6.Text, TextBox1.Text, TextBox4.Text, SelectedBlockInBorderEditor)
        Else

            BorderSelectedBlockPictureBox.Image = BlockToBitmap(TextBox5.Text, TextBox1.Text, TextBox4.Text, SelectedBlockInBorderEditor)
        End If

        SelectionStatus.Text = "Selected Block: " & SelectedBlockInBorderEditor

        stop_time = Now
        elapsed_time = stop_time.Subtract(start_time)
        LoadTImeLabel.Text = "Border Load Time: " & elapsed_time.TotalSeconds.ToString("0.00")

        Button19.Enabled = True
        Button20.Enabled = True
    End Sub

    Private Sub GroupBox9_Resize(sender As Object, e As EventArgs) Handles GroupBox9.Resize
        Panel10.Height = GroupBox9.Height - 100
    End Sub

    Private Sub MEBlocksPictureBox2_Click(sender As Object, e As EventArgs) Handles MEBlocksPictureBox2.Click
        Dim [me] As MouseEventArgs = DirectCast(e, MouseEventArgs)
        Dim coordinates As Point = [me].Location

        If [me].Button = MouseButtons.Right Then

        ElseIf [me].Button = MouseButtons.Left Then
            SelectedBlockInBorderEditor = (Math.Floor(coordinates.X / (16 * 2)) + (Math.Floor(coordinates.Y / (16 * 2)) * 8))

            If SelectedBlockInBlockEditor < 512 Then

                BorderSelectedBlockPictureBox.Image = BlockToBitmap(TextBox6.Text, TextBox1.Text, TextBox4.Text, SelectedBlockInBorderEditor)
            Else

                BorderSelectedBlockPictureBox.Image = BlockToBitmap(TextBox5.Text, TextBox1.Text, TextBox4.Text, SelectedBlockInBorderEditor)
            End If

            SelectionStatus.Text = "Selected Block: " & SelectedBlockInBorderEditor
        End If
    End Sub

    Private Sub BorderPictureBox_Click(sender As Object, e As EventArgs) Handles BorderPictureBox.Click
        Dim [me] As MouseEventArgs = DirectCast(e, MouseEventArgs)
        Dim coordinates As Point = [me].Location

        If [me].Button = MouseButtons.Right Then

            SelectedBlockInBorderEditor = BorderTilesArray((Math.Floor(coordinates.X / (16 * 2)) + (Math.Floor(coordinates.Y / (16 * 2)) * 2)))

            If SelectedBlockInBorderEditor < 512 Then

                BorderSelectedBlockPictureBox.Image = BlockToBitmap(TextBox6.Text, TextBox1.Text, TextBox4.Text, SelectedBlockInBorderEditor)
            Else

                BorderSelectedBlockPictureBox.Image = BlockToBitmap(TextBox5.Text, TextBox1.Text, TextBox4.Text, SelectedBlockInBorderEditor)
            End If

            SelectionStatus.Text = "Selected Block: " & SelectedBlockInBorderEditor

        ElseIf [me].Button = MouseButtons.Left Then

            BorderTilesArray((Math.Floor(coordinates.X / (16 * 2)) + (Math.Floor(coordinates.Y / (16 * 2)) * 2))) = SelectedBlockInBorderEditor

            Dim MapBitmap As New Bitmap(BorderPictureBox.Image)
            Dim TileBitmap As New Bitmap(BorderSelectedBlockPictureBox.Image)

            BitmapBLT(TileBitmap, MapBitmap, Math.Floor(coordinates.X / (16 * 2)) * 16, (Math.Floor(coordinates.Y / (16 * 2))) * 16, 0, 0, 16, 16)

            BorderPictureBox.Image = MapBitmap

        End If
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        Dim size As Integer = 2 * 2

        Dim loopvar As Integer = 0

        Dim tilebin As String
        Dim permbin As String

        While loopvar < size

            tilebin = VB.Right("0000000000" & Convert.ToString(Convert.ToInt32(BorderTilesArray(loopvar)), 2), 10)
            permbin = VB.Right("000000" & Convert.ToString(Convert.ToInt32(BorderPermsArray(loopvar)), 2), 6)

            WriteHEX(TextBox10.Text, loopvar * 2, ReverseHEX(VB.Right("0000" & Hex(Convert.ToInt32(permbin & tilebin, 2)), 4)))

            loopvar = loopvar + 1

        End While

        MsgBox("Border saved!")
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click

        Dim buffinteger As Integer = SelectedBlockInBlockEditor

        Dim loopvar As Integer = 0

        Dim tilenum As Integer = 0
        Dim palnum As Integer = 0
        Dim Yflip As Integer
        Dim Xflip As Integer
        Dim Curbytesbin As String = ""
        Dim Curbytes As String = ""
        Dim Flips As RotateFlipType


        While loopvar < 8


            palnum = SelectedBlockPals(loopvar)
            Yflip = SelectedBlockY(loopvar)
            Xflip = SelectedBlockX(loopvar)
            tilenum = SelectedBlockTile(loopvar)

            Curbytesbin = VB.Right("0000" & Convert.ToString(palnum, 2), 4) & Yflip & Xflip & VB.Right("0000000000" & Convert.ToString(tilenum, 2), 10)

            Curbytes = Curbytes & ReverseHEX(VB.Right("0000" & Hex(Convert.ToInt32(Curbytesbin, 2)), 4))

            loopvar = loopvar + 1

        End While

        ' MsgBox(Curbytes)

        If SelectedBlockInBlockEditor < 512 Then

            WriteHEX(TextBox8.Text, SelectedBlockInBlockEditor * 2, Hex(BehaviorComboBox.SelectedIndex))
            WriteHEX(TextBox8.Text, 1 + (SelectedBlockInBlockEditor * 2), Hex(BackgroundComboBox.SelectedIndex))

            WriteHEX(TextBox6.Text, SelectedBlockInBlockEditor * 16, Curbytes)

        Else

            WriteHEX(TextBox7.Text, (SelectedBlockInBlockEditor - 512) * 2, Hex(BehaviorComboBox.SelectedIndex))
            WriteHEX(TextBox7.Text, 1 + ((SelectedBlockInBlockEditor - 512) * 2), Hex(BackgroundComboBox.SelectedIndex))

            WriteHEX(TextBox6.Text, (SelectedBlockInBlockEditor - 512) * 16, Curbytes)

        End If

        'Load code here

        SelectedBlockInBlockEditor = buffinteger

        Dim PalBuff As String
        Dim Temp(&HFFFF) As Byte
        loopvar = 0

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

        'SelectedTileImgInBlockEditor = 0
        'SelectedTileImgInBlockEditorPal = 0

        If SelectedTileImgInBlockEditor < 512 Then

            SelectedTilePictureBox.Image = LoadSingleTileToBitmap2(TileSet1Image, SelectedTileImgInBlockEditor, TilePals(SelectedTileImgInBlockEditorPal), True, RotateFlipType.RotateNoneFlipNone)

        Else

            SelectedTilePictureBox.Image = LoadSingleTileToBitmap2(TileSet2Image, SelectedTileImgInBlockEditor - 512, TilePals(SelectedTileImgInBlockEditorPal), True, RotateFlipType.RotateNoneFlipNone)

        End If


        SelectionStatus.Text = "Selected Tile: " & SelectedTileImgInBlockEditor

        ComboBox1.SelectedIndex = -1
        ComboBox1.SelectedIndex = 0

        LoadBlockset()


        If SelectedBlockInBlockEditor < 512 Then

            loopvar = 0

            tilenum = 0
            palnum = 0

            Curbytesbin = ""

            While loopvar < 8

                If SelectedBlockInBlockEditor < 512 Then

                    Curbytesbin = VB.Right("0000000000000000" & Convert.ToString(Int32.Parse(ReverseHEX(ReadHEX(TextBox6.Text, SelectedBlockInBlockEditor * 16 + (loopvar * 2), 2)), System.Globalization.NumberStyles.HexNumber), 2), 16)

                Else

                    Curbytesbin = VB.Right("0000000000000000" & Convert.ToString(Int32.Parse(ReverseHEX(ReadHEX(TextBox5.Text, (SelectedBlockInBlockEditor - 512) * 16 + (loopvar * 2), 2)), System.Globalization.NumberStyles.HexNumber), 2), 16)

                End If

                tilenum = Convert.ToInt32(Curbytesbin.Remove(0, 6), 2)
                palnum = Convert.ToInt32(Curbytesbin.Substring(0, 4), 2)
                Yflip = Convert.ToInt32(Curbytesbin.Substring(4, 1), 2)
                Xflip = Convert.ToInt32(Curbytesbin.Substring(5, 1), 2)

                If palnum > 12 Then
                    palnum = 12
                End If

                SelectedBlockPals(loopvar) = palnum
                SelectedBlockY(loopvar) = Yflip
                SelectedBlockX(loopvar) = Xflip
                SelectedBlockTile(loopvar) = tilenum


                loopvar = loopvar + 1

            End While

            SelectedBlockPictureBox.Image = BlockToBitmap(TextBox6.Text, TextBox1.Text, TextBox4.Text, SelectedBlockInBlockEditor)
            BlockBottomPictureBox.Image = BlockBottomToBitmap(TextBox6.Text, TextBox1.Text, TextBox4.Text, SelectedBlockInBlockEditor)
            BlockTopPictureBox.Image = BlockTopToBitmap(TextBox6.Text, TextBox1.Text, TextBox4.Text, SelectedBlockInBlockEditor)

            BehaviorComboBox.SelectedIndex = "&H" & ReadHEX(TextBox8.Text, SelectedBlockInBlockEditor * 2, 1)
            BackgroundComboBox.SelectedIndex = "&H" & ReadHEX(TextBox8.Text, 1 + (SelectedBlockInBlockEditor * 2), 1)
        Else

            loopvar = 0

            tilenum = 0
            palnum = 0

            Curbytesbin = ""




            While loopvar < 8

                If SelectedBlockInBlockEditor < 512 Then

                    Curbytesbin = VB.Right("0000000000000000" & Convert.ToString(Int32.Parse(ReverseHEX(ReadHEX(TextBox6.Text, SelectedBlockInBlockEditor * 16 + (loopvar * 2), 2)), System.Globalization.NumberStyles.HexNumber), 2), 16)

                Else

                    Curbytesbin = VB.Right("0000000000000000" & Convert.ToString(Int32.Parse(ReverseHEX(ReadHEX(TextBox5.Text, (SelectedBlockInBlockEditor - 512) * 16 + (loopvar * 2), 2)), System.Globalization.NumberStyles.HexNumber), 2), 16)

                End If

                tilenum = Convert.ToInt32(Curbytesbin.Remove(0, 6), 2)
                palnum = Convert.ToInt32(Curbytesbin.Substring(0, 4), 2)
                Yflip = Convert.ToInt32(Curbytesbin.Substring(4, 1), 2)
                Xflip = Convert.ToInt32(Curbytesbin.Substring(5, 1), 2)

                If palnum > 12 Then
                    palnum = 12
                End If

                SelectedBlockPals(loopvar) = palnum
                SelectedBlockY(loopvar) = Yflip
                SelectedBlockX(loopvar) = Xflip
                SelectedBlockTile(loopvar) = tilenum


                loopvar = loopvar + 1

            End While

            SelectedBlockPictureBox.Image = BlockToBitmap(TextBox5.Text, TextBox1.Text, TextBox4.Text, SelectedBlockInBlockEditor)
            BlockBottomPictureBox.Image = BlockBottomToBitmap(TextBox6.Text, TextBox1.Text, TextBox4.Text, SelectedBlockInBlockEditor)
            BlockTopPictureBox.Image = BlockTopToBitmap(TextBox6.Text, TextBox1.Text, TextBox4.Text, SelectedBlockInBlockEditor)

            BehaviorComboBox.SelectedIndex = "&H" & ReadHEX(TextBox7.Text, SelectedBlockInBlockEditor * 2, 1)
            BackgroundComboBox.SelectedIndex = "&H" & ReadHEX(TextBox7.Text, 1 + (SelectedBlockInBlockEditor * 2), 1)
        End If

        SelectionStatus.Text = "Selected Block: " & SelectedBlockInBlockEditor

    End Sub

    Private Sub BlockBottomPictureBox_Click(sender As Object, e As EventArgs) Handles BlockBottomPictureBox.Click

        Dim [me] As MouseEventArgs = DirectCast(e, MouseEventArgs)
        Dim coordinates As Point = [me].Location

        If [me].Button = MouseButtons.Left Then

            Dim curselection As Integer = (Math.Floor(coordinates.X / (32)) + (Math.Floor(coordinates.Y / (32)) * 2))

            Dim MapBitmap As New Bitmap(BlockBottomPictureBox.Image)
            Dim TileBitmap As New Bitmap(SelectedTilePictureBox.Image)

            BitmapBLT(TileBitmap, MapBitmap, Math.Floor(coordinates.X / (32)) * 8, Math.Floor(coordinates.Y / (32)) * 8, 0, 0, 8, 8)

            BlockBottomPictureBox.Image = MapBitmap

            SelectedBlockPals(curselection) = SelectedTileImgInBlockEditorPal
            SelectedBlockY(curselection) = SelectedTileImgInBlockEditorY
            SelectedBlockX(curselection) = SelectedTileImgInBlockEditorX
            SelectedBlockTile(curselection) = SelectedTileImgInBlockEditor


        ElseIf [me].Button = MouseButtons.Right Then

            Dim curselection As Integer = (Math.Floor(coordinates.X / (16 * 2)) + (Math.Floor(coordinates.Y / (16 * 2)) * 8))

            Dim output As New Bitmap(16, 16)

            Dim tileimage As String = ""

            Dim tilenum As Integer = 0
            Dim palnum As Integer = 0
            Dim Yflip As Integer
            Dim Xflip As Integer
            Dim Curbytesbin As String = ""
            Dim Flips As RotateFlipType

            SelectedTileImgInBlockEditor = SelectedBlockTile(Math.Floor(coordinates.X / (32)) + (Math.Floor(coordinates.Y / (32)) * 2))

            ComboBox1.SelectedIndex = SelectedBlockPals(Math.Floor(coordinates.X / (32)) + (Math.Floor(coordinates.Y / (32)) * 2))

            SelectedTileImgInBlockEditorX = SelectedBlockX(Math.Floor(coordinates.X / (32)) + (Math.Floor(coordinates.Y / (32)) * 2))
            SelectedTileImgInBlockEditorY = SelectedBlockY(Math.Floor(coordinates.X / (32)) + (Math.Floor(coordinates.Y / (32)) * 2))

            If SelectedTileImgInBlockEditorX = 1 Then

                CheckBox3.Checked = True

            Else

                CheckBox3.Checked = False

            End If

            If SelectedTileImgInBlockEditorY = 1 Then

                CheckBox4.Checked = True

            Else

                CheckBox4.Checked = False

            End If

            If SelectedTileImgInBlockEditorY = 0 And SelectedTileImgInBlockEditorX = 0 Then

                Flips = RotateFlipType.RotateNoneFlipNone

            ElseIf SelectedTileImgInBlockEditorY = 0 And SelectedTileImgInBlockEditorX = 1 Then

                Flips = RotateFlipType.RotateNoneFlipX

            ElseIf SelectedTileImgInBlockEditorY = 1 And SelectedTileImgInBlockEditorX = 0 Then

                Flips = RotateFlipType.RotateNoneFlipY

            ElseIf SelectedTileImgInBlockEditorY = 1 And SelectedTileImgInBlockEditorX = 1 Then

                Flips = RotateFlipType.RotateNoneFlipXY

            End If

            If SelectedTileImgInBlockEditor < 512 Then

                SelectedTilePictureBox.Image = LoadSingleTileToBitmap2(TileSet1Image, SelectedTileImgInBlockEditor, TilePals(SelectedTileImgInBlockEditorPal), True, Flips)


            Else

                SelectedTilePictureBox.Image = LoadSingleTileToBitmap2(TileSet2Image, SelectedTileImgInBlockEditor - 512, TilePals(SelectedTileImgInBlockEditorPal), True, Flips)

            End If

            SelectionStatus.Text = "Selected Tile: " & SelectedTileImgInBlockEditor

        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = True Then
            SelectedTileImgInBlockEditorX = 1

        Else
            SelectedTileImgInBlockEditorX = 0
        End If

        Dim Flips As RotateFlipType

        If SelectedTileImgInBlockEditorY = 0 And SelectedTileImgInBlockEditorX = 0 Then

            Flips = RotateFlipType.RotateNoneFlipNone

        ElseIf SelectedTileImgInBlockEditorY = 0 And SelectedTileImgInBlockEditorX = 1 Then

            Flips = RotateFlipType.RotateNoneFlipX

        ElseIf SelectedTileImgInBlockEditorY = 1 And SelectedTileImgInBlockEditorX = 0 Then

            Flips = RotateFlipType.RotateNoneFlipY

        ElseIf SelectedTileImgInBlockEditorY = 1 And SelectedTileImgInBlockEditorX = 1 Then

            Flips = RotateFlipType.RotateNoneFlipXY

        End If

        If SelectedTileImgInBlockEditor < 512 Then

            SelectedTilePictureBox.Image = LoadSingleTileToBitmap2(TileSet1Image, SelectedTileImgInBlockEditor, TilePals(SelectedTileImgInBlockEditorPal), True, Flips)


        Else

            SelectedTilePictureBox.Image = LoadSingleTileToBitmap2(TileSet2Image, SelectedTileImgInBlockEditor - 512, TilePals(SelectedTileImgInBlockEditorPal), True, Flips)

        End If

    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged
        If CheckBox4.Checked = True Then
            SelectedTileImgInBlockEditorY = 1

        Else
            SelectedTileImgInBlockEditorY = 0
        End If

        Dim Flips As RotateFlipType

        If SelectedTileImgInBlockEditorY = 0 And SelectedTileImgInBlockEditorX = 0 Then

            Flips = RotateFlipType.RotateNoneFlipNone

        ElseIf SelectedTileImgInBlockEditorY = 0 And SelectedTileImgInBlockEditorX = 1 Then

            Flips = RotateFlipType.RotateNoneFlipX

        ElseIf SelectedTileImgInBlockEditorY = 1 And SelectedTileImgInBlockEditorX = 0 Then

            Flips = RotateFlipType.RotateNoneFlipY

        ElseIf SelectedTileImgInBlockEditorY = 1 And SelectedTileImgInBlockEditorX = 1 Then

            Flips = RotateFlipType.RotateNoneFlipXY

        End If

        If SelectedTileImgInBlockEditor < 512 Then

            SelectedTilePictureBox.Image = LoadSingleTileToBitmap2(TileSet1Image, SelectedTileImgInBlockEditor, TilePals(SelectedTileImgInBlockEditorPal), True, Flips)


        Else

            SelectedTilePictureBox.Image = LoadSingleTileToBitmap2(TileSet2Image, SelectedTileImgInBlockEditor - 512, TilePals(SelectedTileImgInBlockEditorPal), True, Flips)

        End If

    End Sub

    Private Sub BlockTopPictureBox_Click(sender As Object, e As EventArgs) Handles BlockTopPictureBox.Click
        Dim [me] As MouseEventArgs = DirectCast(e, MouseEventArgs)
        Dim coordinates As Point = [me].Location

        If [me].Button = MouseButtons.Left Then

            Dim curselection As Integer = (Math.Floor(coordinates.X / (32)) + (Math.Floor(coordinates.Y / (32)) * 2))

            Dim MapBitmap As New Bitmap(BlockTopPictureBox.Image)
            Dim TileBitmap As New Bitmap(SelectedTilePictureBox.Image)

            BitmapBLT(TileBitmap, MapBitmap, Math.Floor(coordinates.X / (32)) * 8, Math.Floor(coordinates.Y / (32)) * 8, 0, 0, 8, 8)

            BlockTopPictureBox.Image = MapBitmap

            SelectedBlockPals(curselection + 4) = SelectedTileImgInBlockEditorPal
            SelectedBlockY(curselection + 4) = SelectedTileImgInBlockEditorY
            SelectedBlockX(curselection + 4) = SelectedTileImgInBlockEditorX
            SelectedBlockTile(curselection + 4) = SelectedTileImgInBlockEditor


        ElseIf [me].Button = MouseButtons.Right Then

            Dim curselection As Integer = (Math.Floor(coordinates.X / (16 * 2)) + (Math.Floor(coordinates.Y / (16 * 2)) * 8))

            Dim output As New Bitmap(16, 16)

            Dim tileimage As String = ""

            Dim tilenum As Integer = 0
            Dim palnum As Integer = 0
            Dim Yflip As Integer
            Dim Xflip As Integer
            Dim Curbytesbin As String = ""
            Dim Flips As RotateFlipType

            SelectedTileImgInBlockEditor = SelectedBlockTile(Math.Floor(coordinates.X / (32)) + (Math.Floor(coordinates.Y / (32)) * 2) + 4)

            ComboBox1.SelectedIndex = SelectedBlockPals(Math.Floor(coordinates.X / (32)) + (Math.Floor(coordinates.Y / (32)) * 2) + 4)

            SelectedTileImgInBlockEditorX = SelectedBlockX(Math.Floor(coordinates.X / (32)) + (Math.Floor(coordinates.Y / (32)) * 2) + 4)
            SelectedTileImgInBlockEditorY = SelectedBlockY(Math.Floor(coordinates.X / (32)) + (Math.Floor(coordinates.Y / (32)) * 2) + 4)

            If SelectedTileImgInBlockEditorX = 1 Then

                CheckBox3.Checked = True

            Else

                CheckBox3.Checked = False

            End If

            If SelectedTileImgInBlockEditorY = 1 Then

                CheckBox4.Checked = True

            Else

                CheckBox4.Checked = False

            End If

            If SelectedTileImgInBlockEditorY = 0 And SelectedTileImgInBlockEditorX = 0 Then

                Flips = RotateFlipType.RotateNoneFlipNone

            ElseIf SelectedTileImgInBlockEditorY = 0 And SelectedTileImgInBlockEditorX = 1 Then

                Flips = RotateFlipType.RotateNoneFlipX

            ElseIf SelectedTileImgInBlockEditorY = 1 And SelectedTileImgInBlockEditorX = 0 Then

                Flips = RotateFlipType.RotateNoneFlipY

            ElseIf SelectedTileImgInBlockEditorY = 1 And SelectedTileImgInBlockEditorX = 1 Then

                Flips = RotateFlipType.RotateNoneFlipXY

            End If

            If SelectedTileImgInBlockEditor < 512 Then

                SelectedTilePictureBox.Image = LoadSingleTileToBitmap2(TileSet1Image, SelectedTileImgInBlockEditor, TilePals(SelectedTileImgInBlockEditorPal), True, Flips)


            Else

                SelectedTilePictureBox.Image = LoadSingleTileToBitmap2(TileSet2Image, SelectedTileImgInBlockEditor - 512, TilePals(SelectedTileImgInBlockEditorPal), True, Flips)

            End If

            SelectionStatus.Text = "Selected Tile: " & SelectedTileImgInBlockEditor

        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.SelectedIndex = -1 Then
        Else

            PictureBox3.BackColor = TilePals(ComboBox2.SelectedIndex)(0)
            PictureBox4.BackColor = TilePals(ComboBox2.SelectedIndex)(1)
            PictureBox5.BackColor = TilePals(ComboBox2.SelectedIndex)(2)
            PictureBox8.BackColor = TilePals(ComboBox2.SelectedIndex)(3)
            PictureBox7.BackColor = TilePals(ComboBox2.SelectedIndex)(4)
            PictureBox6.BackColor = TilePals(ComboBox2.SelectedIndex)(5)
            PictureBox14.BackColor = TilePals(ComboBox2.SelectedIndex)(6)
            PictureBox13.BackColor = TilePals(ComboBox2.SelectedIndex)(7)
            PictureBox12.BackColor = TilePals(ComboBox2.SelectedIndex)(8)
            PictureBox11.BackColor = TilePals(ComboBox2.SelectedIndex)(9)
            PictureBox10.BackColor = TilePals(ComboBox2.SelectedIndex)(10)
            PictureBox9.BackColor = TilePals(ComboBox2.SelectedIndex)(11)
            PictureBox18.BackColor = TilePals(ComboBox2.SelectedIndex)(12)
            PictureBox17.BackColor = TilePals(ComboBox2.SelectedIndex)(13)
            PictureBox16.BackColor = TilePals(ComboBox2.SelectedIndex)(14)
            PictureBox15.BackColor = TilePals(ComboBox2.SelectedIndex)(15)

            TextBox11.Text = VB.Right("0000" & Hex(ColorToRGB16(TilePals(ComboBox2.SelectedIndex)(0))), 4)
            TextBox14.Text = VB.Right("0000" & Hex(ColorToRGB16(TilePals(ComboBox2.SelectedIndex)(1))), 4)
            TextBox15.Text = VB.Right("0000" & Hex(ColorToRGB16(TilePals(ComboBox2.SelectedIndex)(2))), 4)
            TextBox18.Text = VB.Right("0000" & Hex(ColorToRGB16(TilePals(ComboBox2.SelectedIndex)(3))), 4)
            TextBox17.Text = VB.Right("0000" & Hex(ColorToRGB16(TilePals(ComboBox2.SelectedIndex)(4))), 4)
            TextBox16.Text = VB.Right("0000" & Hex(ColorToRGB16(TilePals(ComboBox2.SelectedIndex)(5))), 4)
            TextBox24.Text = VB.Right("0000" & Hex(ColorToRGB16(TilePals(ComboBox2.SelectedIndex)(6))), 4)
            TextBox23.Text = VB.Right("0000" & Hex(ColorToRGB16(TilePals(ComboBox2.SelectedIndex)(7))), 4)
            TextBox22.Text = VB.Right("0000" & Hex(ColorToRGB16(TilePals(ComboBox2.SelectedIndex)(8))), 4)
            TextBox21.Text = VB.Right("0000" & Hex(ColorToRGB16(TilePals(ComboBox2.SelectedIndex)(9))), 4)
            TextBox20.Text = VB.Right("0000" & Hex(ColorToRGB16(TilePals(ComboBox2.SelectedIndex)(10))), 4)
            TextBox19.Text = VB.Right("0000" & Hex(ColorToRGB16(TilePals(ComboBox2.SelectedIndex)(11))), 4)
            TextBox28.Text = VB.Right("0000" & Hex(ColorToRGB16(TilePals(ComboBox2.SelectedIndex)(12))), 4)
            TextBox27.Text = VB.Right("0000" & Hex(ColorToRGB16(TilePals(ComboBox2.SelectedIndex)(13))), 4)
            TextBox26.Text = VB.Right("0000" & Hex(ColorToRGB16(TilePals(ComboBox2.SelectedIndex)(14))), 4)
            TextBox25.Text = VB.Right("0000" & Hex(ColorToRGB16(TilePals(ComboBox2.SelectedIndex)(15))), 4)

        End If
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
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

        ComboBox2.SelectedIndex = -1
        ComboBox2.SelectedIndex = 0

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click

        ColorDialogPalEdit.ShowDialog()
        TilePals(ComboBox2.SelectedIndex)(0) = ColorDialogPalEdit.Color
        PictureBox3.BackColor = TilePals(ComboBox2.SelectedIndex)(0)
        TextBox11.Text = VB.Right("0000" & Hex(ColorToRGB16(TilePals(ComboBox2.SelectedIndex)(0))), 4)

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click

        ColorDialogPalEdit.ShowDialog()
        TilePals(ComboBox2.SelectedIndex)(1) = ColorDialogPalEdit.Color
        PictureBox4.BackColor = TilePals(ComboBox2.SelectedIndex)(1)
        TextBox14.Text = VB.Right("0000" & Hex(ColorToRGB16(TilePals(ComboBox2.SelectedIndex)(1))), 4)
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click

        ColorDialogPalEdit.ShowDialog()
        TilePals(ComboBox2.SelectedIndex)(2) = ColorDialogPalEdit.Color
        PictureBox5.BackColor = TilePals(ComboBox2.SelectedIndex)(2)
        TextBox15.Text = VB.Right("0000" & Hex(ColorToRGB16(TilePals(ComboBox2.SelectedIndex)(2))), 4)
    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click

        ColorDialogPalEdit.ShowDialog()
        TilePals(ComboBox2.SelectedIndex)(3) = ColorDialogPalEdit.Color
        PictureBox8.BackColor = TilePals(ComboBox2.SelectedIndex)(3)
        TextBox18.Text = VB.Right("0000" & Hex(ColorToRGB16(TilePals(ComboBox2.SelectedIndex)(3))), 4)
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click

        ColorDialogPalEdit.ShowDialog()
        TilePals(ComboBox2.SelectedIndex)(4) = ColorDialogPalEdit.Color
        PictureBox7.BackColor = TilePals(ComboBox2.SelectedIndex)(4)
        TextBox17.Text = VB.Right("0000" & Hex(ColorToRGB16(TilePals(ComboBox2.SelectedIndex)(4))), 4)
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        ColorDialogPalEdit.ShowDialog()
        TilePals(ComboBox2.SelectedIndex)(5) = ColorDialogPalEdit.Color
        PictureBox6.BackColor = TilePals(ComboBox2.SelectedIndex)(5)
        TextBox16.Text = VB.Right("0000" & Hex(ColorToRGB16(TilePals(ComboBox2.SelectedIndex)(5))), 4)
    End Sub

    Private Sub PictureBox14_Click(sender As Object, e As EventArgs) Handles PictureBox14.Click
        ColorDialogPalEdit.ShowDialog()
        TilePals(ComboBox2.SelectedIndex)(6) = ColorDialogPalEdit.Color
        PictureBox14.BackColor = TilePals(ComboBox2.SelectedIndex)(6)
        TextBox24.Text = VB.Right("0000" & Hex(ColorToRGB16(TilePals(ComboBox2.SelectedIndex)(6))), 4)
    End Sub

    Private Sub PictureBox13_Click(sender As Object, e As EventArgs) Handles PictureBox13.Click
        ColorDialogPalEdit.ShowDialog()
        TilePals(ComboBox2.SelectedIndex)(7) = ColorDialogPalEdit.Color
        PictureBox13.BackColor = TilePals(ComboBox2.SelectedIndex)(7)
        TextBox23.Text = VB.Right("0000" & Hex(ColorToRGB16(TilePals(ComboBox2.SelectedIndex)(7))), 4)
    End Sub

    Private Sub PictureBox12_Click(sender As Object, e As EventArgs) Handles PictureBox12.Click
        ColorDialogPalEdit.ShowDialog()
        TilePals(ComboBox2.SelectedIndex)(8) = ColorDialogPalEdit.Color
        PictureBox12.BackColor = TilePals(ComboBox2.SelectedIndex)(8)
        TextBox22.Text = VB.Right("0000" & Hex(ColorToRGB16(TilePals(ComboBox2.SelectedIndex)(8))), 4)
    End Sub

    Private Sub PictureBox11_Click(sender As Object, e As EventArgs) Handles PictureBox11.Click
        ColorDialogPalEdit.ShowDialog()
        TilePals(ComboBox2.SelectedIndex)(9) = ColorDialogPalEdit.Color
        PictureBox11.BackColor = TilePals(ComboBox2.SelectedIndex)(9)
        TextBox21.Text = VB.Right("0000" & Hex(ColorToRGB16(TilePals(ComboBox2.SelectedIndex)(9))), 4)
    End Sub

    Private Sub PictureBox10_Click(sender As Object, e As EventArgs) Handles PictureBox10.Click
        ColorDialogPalEdit.ShowDialog()
        TilePals(ComboBox2.SelectedIndex)(10) = ColorDialogPalEdit.Color
        PictureBox10.BackColor = TilePals(ComboBox2.SelectedIndex)(10)
        TextBox20.Text = VB.Right("0000" & Hex(ColorToRGB16(TilePals(ComboBox2.SelectedIndex)(10))), 4)
    End Sub

    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click
        ColorDialogPalEdit.ShowDialog()
        TilePals(ComboBox2.SelectedIndex)(11) = ColorDialogPalEdit.Color
        PictureBox9.BackColor = TilePals(ComboBox2.SelectedIndex)(11)
        TextBox19.Text = VB.Right("0000" & Hex(ColorToRGB16(TilePals(ComboBox2.SelectedIndex)(11))), 4)
    End Sub

    Private Sub PictureBox18_Click(sender As Object, e As EventArgs) Handles PictureBox18.Click
        ColorDialogPalEdit.ShowDialog()
        TilePals(ComboBox2.SelectedIndex)(12) = ColorDialogPalEdit.Color
        PictureBox18.BackColor = TilePals(ComboBox2.SelectedIndex)(12)
        TextBox28.Text = VB.Right("0000" & Hex(ColorToRGB16(TilePals(ComboBox2.SelectedIndex)(12))), 4)
    End Sub

    Private Sub PictureBox17_Click(sender As Object, e As EventArgs) Handles PictureBox17.Click
        ColorDialogPalEdit.ShowDialog()
        TilePals(ComboBox2.SelectedIndex)(13) = ColorDialogPalEdit.Color
        PictureBox17.BackColor = TilePals(ComboBox2.SelectedIndex)(13)
        TextBox27.Text = VB.Right("0000" & Hex(ColorToRGB16(TilePals(ComboBox2.SelectedIndex)(13))), 4)
    End Sub

    Private Sub PictureBox16_Click(sender As Object, e As EventArgs) Handles PictureBox16.Click
        ColorDialogPalEdit.ShowDialog()
        TilePals(ComboBox2.SelectedIndex)(14) = ColorDialogPalEdit.Color
        PictureBox16.BackColor = TilePals(ComboBox2.SelectedIndex)(14)
        TextBox26.Text = VB.Right("0000" & Hex(ColorToRGB16(TilePals(ComboBox2.SelectedIndex)(14))), 4)
    End Sub

    Private Sub PictureBox15_Click(sender As Object, e As EventArgs) Handles PictureBox15.Click
        ColorDialogPalEdit.ShowDialog()
        TilePals(ComboBox2.SelectedIndex)(15) = ColorDialogPalEdit.Color
        PictureBox15.BackColor = TilePals(ComboBox2.SelectedIndex)(15)
        TextBox25.Text = VB.Right("0000" & Hex(ColorToRGB16(TilePals(ComboBox2.SelectedIndex)(15))), 4)
    End Sub

    Private Sub TextBox11_TextChanged(sender As Object, e As EventArgs) Handles TextBox11.TextChanged
        If TextBox11.Text <> "" Then
            TilePals(ComboBox2.SelectedIndex)(0) = RGB16ToColor(Int32.Parse(TextBox11.Text, System.Globalization.NumberStyles.HexNumber))
            PictureBox3.BackColor = TilePals(ComboBox2.SelectedIndex)(0)
        End If
    End Sub

    Private Sub TextBox14_TextChanged(sender As Object, e As EventArgs) Handles TextBox14.TextChanged
        If TextBox14.Text <> "" Then
            TilePals(ComboBox2.SelectedIndex)(1) = RGB16ToColor(Int32.Parse(TextBox14.Text, System.Globalization.NumberStyles.HexNumber))
            PictureBox4.BackColor = TilePals(ComboBox2.SelectedIndex)(1)
        End If
    End Sub

    Private Sub TextBox15_TextChanged(sender As Object, e As EventArgs) Handles TextBox15.TextChanged
        If TextBox15.Text <> "" Then
            TilePals(ComboBox2.SelectedIndex)(2) = RGB16ToColor(Int32.Parse(TextBox15.Text, System.Globalization.NumberStyles.HexNumber))
            PictureBox5.BackColor = TilePals(ComboBox2.SelectedIndex)(2)
        End If
    End Sub

    Private Sub TextBox18_TextChanged(sender As Object, e As EventArgs) Handles TextBox18.TextChanged
        If TextBox18.Text <> "" Then
            TilePals(ComboBox2.SelectedIndex)(3) = RGB16ToColor(Int32.Parse(TextBox18.Text, System.Globalization.NumberStyles.HexNumber))
            PictureBox8.BackColor = TilePals(ComboBox2.SelectedIndex)(3)
        End If
    End Sub

    Private Sub TextBox17_TextChanged(sender As Object, e As EventArgs) Handles TextBox17.TextChanged
        If TextBox17.Text <> "" Then
            TilePals(ComboBox2.SelectedIndex)(4) = RGB16ToColor(Int32.Parse(TextBox17.Text, System.Globalization.NumberStyles.HexNumber))
            PictureBox7.BackColor = TilePals(ComboBox2.SelectedIndex)(4)
        End If
    End Sub

    Private Sub TextBox16_TextChanged(sender As Object, e As EventArgs) Handles TextBox16.TextChanged
        If TextBox16.Text <> "" Then
            TilePals(ComboBox2.SelectedIndex)(5) = RGB16ToColor(Int32.Parse(TextBox16.Text, System.Globalization.NumberStyles.HexNumber))
            PictureBox6.BackColor = TilePals(ComboBox2.SelectedIndex)(5)
        End If
    End Sub

    Private Sub TextBox24_TextChanged(sender As Object, e As EventArgs) Handles TextBox24.TextChanged
        If TextBox24.Text <> "" Then
            TilePals(ComboBox2.SelectedIndex)(6) = RGB16ToColor(Int32.Parse(TextBox24.Text, System.Globalization.NumberStyles.HexNumber))
            PictureBox14.BackColor = TilePals(ComboBox2.SelectedIndex)(6)
        End If
    End Sub

    Private Sub TextBox23_TextChanged(sender As Object, e As EventArgs) Handles TextBox23.TextChanged
        If TextBox23.Text <> "" Then
            TilePals(ComboBox2.SelectedIndex)(7) = RGB16ToColor(Int32.Parse(TextBox23.Text, System.Globalization.NumberStyles.HexNumber))
            PictureBox13.BackColor = TilePals(ComboBox2.SelectedIndex)(7)
        End If
    End Sub

    Private Sub TextBox22_TextChanged(sender As Object, e As EventArgs) Handles TextBox22.TextChanged
        If TextBox22.Text <> "" Then
            TilePals(ComboBox2.SelectedIndex)(8) = RGB16ToColor(Int32.Parse(TextBox22.Text, System.Globalization.NumberStyles.HexNumber))
            PictureBox12.BackColor = TilePals(ComboBox2.SelectedIndex)(8)
        End If
    End Sub

    Private Sub TextBox21_TextChanged(sender As Object, e As EventArgs) Handles TextBox21.TextChanged
        If TextBox21.Text <> "" Then
            TilePals(ComboBox2.SelectedIndex)(9) = RGB16ToColor(Int32.Parse(TextBox21.Text, System.Globalization.NumberStyles.HexNumber))
            PictureBox11.BackColor = TilePals(ComboBox2.SelectedIndex)(9)
        End If
    End Sub

    Private Sub TextBox20_TextChanged(sender As Object, e As EventArgs) Handles TextBox20.TextChanged
        If TextBox20.Text <> "" Then
            TilePals(ComboBox2.SelectedIndex)(10) = RGB16ToColor(Int32.Parse(TextBox20.Text, System.Globalization.NumberStyles.HexNumber))
            PictureBox10.BackColor = TilePals(ComboBox2.SelectedIndex)(10)
        End If
    End Sub

    Private Sub TextBox19_TextChanged(sender As Object, e As EventArgs) Handles TextBox19.TextChanged
        If TextBox19.Text <> "" Then
            TilePals(ComboBox2.SelectedIndex)(11) = RGB16ToColor(Int32.Parse(TextBox19.Text, System.Globalization.NumberStyles.HexNumber))
            PictureBox9.BackColor = TilePals(ComboBox2.SelectedIndex)(11)
        End If
    End Sub

    Private Sub TextBox28_TextChanged(sender As Object, e As EventArgs) Handles TextBox28.TextChanged
        If TextBox28.Text <> "" Then
            TilePals(ComboBox2.SelectedIndex)(12) = RGB16ToColor(Int32.Parse(TextBox28.Text, System.Globalization.NumberStyles.HexNumber))
            PictureBox18.BackColor = TilePals(ComboBox2.SelectedIndex)(12)
        End If
    End Sub

    Private Sub TextBox27_TextChanged(sender As Object, e As EventArgs) Handles TextBox27.TextChanged
        If TextBox27.Text <> "" Then
            TilePals(ComboBox2.SelectedIndex)(13) = RGB16ToColor(Int32.Parse(TextBox27.Text, System.Globalization.NumberStyles.HexNumber))
            PictureBox17.BackColor = TilePals(ComboBox2.SelectedIndex)(13)
        End If
    End Sub

    Private Sub TextBox26_TextChanged(sender As Object, e As EventArgs) Handles TextBox26.TextChanged
        If TextBox26.Text <> "" Then
            TilePals(ComboBox2.SelectedIndex)(14) = RGB16ToColor(Int32.Parse(TextBox26.Text, System.Globalization.NumberStyles.HexNumber))
            PictureBox16.BackColor = TilePals(ComboBox2.SelectedIndex)(14)
        End If
    End Sub

    Private Sub TextBox25_TextChanged(sender As Object, e As EventArgs) Handles TextBox25.TextChanged
        If TextBox25.Text <> "" Then
            TilePals(ComboBox2.SelectedIndex)(15) = RGB16ToColor(Int32.Parse(TextBox25.Text, System.Globalization.NumberStyles.HexNumber))
            PictureBox15.BackColor = TilePals(ComboBox2.SelectedIndex)(15)
        End If
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click

        Dim loopvar As Integer = 0
        Dim curpal As String = ""

        While loopvar < 13

            If loopvar < 6 Then

                curpal = ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(TilePals(loopvar)(0))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(TilePals(loopvar)(1))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(TilePals(loopvar)(2))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(TilePals(loopvar)(3))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(TilePals(loopvar)(4))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(TilePals(loopvar)(5))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(TilePals(loopvar)(6))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(TilePals(loopvar)(7))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(TilePals(loopvar)(8))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(TilePals(loopvar)(9))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(TilePals(loopvar)(10))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(TilePals(loopvar)(11))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(TilePals(loopvar)(12))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(TilePals(loopvar)(13))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(TilePals(loopvar)(14))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(TilePals(loopvar)(15))), 4))

                WriteHEX(TextBox2.Text, (loopvar * 32), curpal)

                ' PalBuff = ReadHEX(TextBox2.Text, (loopvar * 32), 32)

            Else

                curpal = ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(TilePals(loopvar)(0))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(TilePals(loopvar)(1))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(TilePals(loopvar)(2))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(TilePals(loopvar)(3))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(TilePals(loopvar)(4))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(TilePals(loopvar)(5))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(TilePals(loopvar)(6))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(TilePals(loopvar)(7))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(TilePals(loopvar)(8))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(TilePals(loopvar)(9))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(TilePals(loopvar)(10))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(TilePals(loopvar)(11))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(TilePals(loopvar)(12))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(TilePals(loopvar)(13))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(TilePals(loopvar)(14))), 4)) & ReverseHEX(VB.Right("0000" & Hex(ColorToRGB16(TilePals(loopvar)(15))), 4))

                WriteHEX(TextBox3.Text, (loopvar * 32), curpal)

                '  PalBuff = ReadHEX(TextBox3.Text, ((loopvar) * 32), 32)

            End If

            loopvar = loopvar + 1
        End While

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged

        Dim Tiles1 As Bitmap
        Dim Tiles2 As Bitmap

        If ComboBox3.SelectedIndex = -1 Then

        Else
            Tiles1 = LoadTilesToBitmap(TextBox1.Text, TilePals(ComboBox3.SelectedIndex), CheckBox1.Checked, True)
            Tiles2 = LoadTilesToBitmap(TextBox4.Text, TilePals(ComboBox3.SelectedIndex), CheckBox2.Checked, True)

            TilesPictureBox1.Image = Tiles1
            TilesPictureBox2.Image = Tiles2

        End If
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click

        Button5_Click(sender, e)

        ComboBox3.SelectedIndex = -1
            ComboBox3.SelectedIndex = 0

    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click

        SaveFileDialog.FileName = "TileSet1.png"
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

            LoadTilesToBitmap(TextBox1.Text, TilePals(ComboBox3.SelectedIndex), CheckBox1.Checked, True).Save(SaveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png)

        End If

    End Sub

    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click


        SaveFileDialog.FileName = "TileSet2.png"
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

            LoadTilesToBitmap(TextBox4.Text, TilePals(ComboBox3.SelectedIndex), CheckBox2.Checked, True).Save(SaveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png)

        End If

    End Sub

    Private Sub Button28_Click(sender As Object, e As EventArgs) Handles Button28.Click

        fileOpenDialog.FileName = ""
        fileOpenDialog.CheckFileExists = True

        ' Check to ensure that the selected path exists.  Dialog box displays 
        ' a warning otherwise.
        fileOpenDialog.CheckPathExists = True

        ' Get or set default extension. Doesn't include the leading ".".
        fileOpenDialog.DefaultExt = "png"

        ' Return the file referenced by a link? If False, simply returns the selected link
        ' file. If True, returns the file linked to the LNK file.
        fileOpenDialog.DereferenceLinks = True

        ' Just as in VB6, use a set of pairs of filters, separated with "|". Each 
        ' pair consists of a description|file spec. Use a "|" between pairs. No need to put a
        ' trailing "|". You can set the FilterIndex property as well, to select the default
        ' filter. The first filter is numbered 1 (not 0). The default is 1. 
        fileOpenDialog.Filter =
            "(*.png)|*.png*"

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

            Dim importimg As New Bitmap(fileOpenDialog.FileName)
            Dim convertedimage As String

            'ConvertBitmapToPalette2(importimg, TilePals(ComboBox3.SelectedIndex), True)

            convertedimage = ByteArrayToHexString(CompressBytes(SaveBitmapToArray(importimg, TilePals(ComboBox3.SelectedIndex))))

            If File.Exists(TextBox1.Text) Then

                File.Delete(TextBox1.Text)

            End If

            WriteHEX(TextBox1.Text, 0, convertedimage)

            Button24_Click(sender, e)

        End If

    End Sub

    Private Sub Button27_Click(sender As Object, e As EventArgs) Handles Button27.Click

        fileOpenDialog.FileName = ""
        fileOpenDialog.CheckFileExists = True

        ' Check to ensure that the selected path exists.  Dialog box displays 
        ' a warning otherwise.
        fileOpenDialog.CheckPathExists = True

        ' Get or set default extension. Doesn't include the leading ".".
        fileOpenDialog.DefaultExt = "png"

        ' Return the file referenced by a link? If False, simply returns the selected link
        ' file. If True, returns the file linked to the LNK file.
        fileOpenDialog.DereferenceLinks = True

        ' Just as in VB6, use a set of pairs of filters, separated with "|". Each 
        ' pair consists of a description|file spec. Use a "|" between pairs. No need to put a
        ' trailing "|". You can set the FilterIndex property as well, to select the default
        ' filter. The first filter is numbered 1 (not 0). The default is 1. 
        fileOpenDialog.Filter =
            "(*.png)|*.png*"

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

            Dim importimg As New Bitmap(fileOpenDialog.FileName)
            Dim convertedimage As String

            'ConvertBitmapToPalette2(importimg, TilePals(ComboBox3.SelectedIndex), True)

            convertedimage = ByteArrayToHexString(CompressBytes(SaveBitmapToArray(importimg, TilePals(ComboBox3.SelectedIndex))))

            If File.Exists(TextBox4.Text) Then

                File.Delete(TextBox4.Text)

            End If

            WriteHEX(TextBox4.Text, 0, convertedimage)

            Button24_Click(sender, e)

        End If

    End Sub
End Class
