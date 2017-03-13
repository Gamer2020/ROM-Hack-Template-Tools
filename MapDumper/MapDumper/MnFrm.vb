Imports System.IO
Imports System.Windows.Forms.Application
Imports System.Net

Imports System.IO.Directory

Public Class MnFrm

    Dim outputtext As String
    Dim outputlevel2 As String
    Dim outputlevel4 As String

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

        LoadMapList()

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

        MapBankPointers = ((Val(("&H" & ReverseHEX(ReadHEX(LoadedROM, Point2MapBankPointers, 4)))) - &H8000000))

        i = 0

        While (ReadHEX(LoadedROM, MapBankPointers + (i * 4), "4") <> "02000000") And (ReadHEX(LoadedROM, MapBankPointers + (i * 4), "4") <> "FFFFFFFF") 'And ((("&H" & ReverseHEX(ReadHEX(LoadedROM, MapBankPointers + (i * 4), 4)))) < &H8000000)

            MapsAndBanks.Nodes.Add(i)

            Dim OriginalBankPointer As String = GetString((AppPath & "ini\roms.ini"), header, ("OriginalBankPointer" & i), "")
            Dim NumberOfMapsInBank As String = GetString((AppPath & "ini\roms.ini"), header, ("NumberOfMapsInBank" & i), "")


            x = 0

            BankPointer = ((Val(("&H" & ReverseHEX(ReadHEX(LoadedROM, MapBankPointers + (i * 4), 4)))) - &H8000000))

            While (x <= 299)

                HeaderPointer = ((Val(("&H" & ReverseHEX(ReadHEX(LoadedROM, BankPointer + (x * 4), 4)))) - &H8000000))

                If (ReadHEX(LoadedROM, BankPointer + (x * 4), 4) = "F7F7F7F7") Then
                    Exit While
                End If

                If OriginalBankPointer = Hex(BankPointer) Then

                    Dim maplabelvar As Integer

                    maplabelvar = CInt((Val(("&H" & ReadHEX(LoadedROM, HeaderPointer + 20, 1)))))

                    If ((header2 = "BPR") Or (header2 = "BPG")) Then

                        MapsAndBanks.Nodes.Item(i).Nodes.Add(New TreeNode(x & " - " & MapNameList.Items.Item(maplabelvar - &H58)))

                    ElseIf (mMain.header2 = "BPE") Then

                        MapsAndBanks.Nodes.Item(i).Nodes.Add(New TreeNode(x & " - " & MapNameList.Items.Item(maplabelvar)))

                    ElseIf ((mMain.header2 = "AXP") Or (mMain.header2 = "AXV")) Then

                        MapsAndBanks.Nodes.Item(i).Nodes.Add(New TreeNode(x & " - " & MapNameList.Items.Item(maplabelvar)))

                    End If
                    'MapsAndBanks.Nodes.Item(i).Nodes.Add(New TreeNode(x & " - " & GetMapLabelName(1)))

                    If NumberOfMapsInBank = x Then

                        Exit While

                    End If

                Else

                    If (ReadHEX(LoadedROM, BankPointer + (x * 4), 4) = "77777777") Then
                        MapsAndBanks.Nodes.Item(i).Nodes.Add(New TreeNode((x & " - Reserved")))
                    Else

                        Dim maplabelvar As Integer

                        maplabelvar = CInt((Val(("&H" & ReadHEX(LoadedROM, HeaderPointer + 20, 1)))))

                        If ((header2 = "BPR") Or (header2 = "BPG")) Then

                            MapsAndBanks.Nodes.Item(i).Nodes.Add(New TreeNode(x & " - " & MapNameList.Items.Item(maplabelvar - &H58)))

                        ElseIf (mMain.header2 = "BPE") Then

                            MapsAndBanks.Nodes.Item(i).Nodes.Add(New TreeNode(x & " - " & MapNameList.Items.Item(maplabelvar)))

                        ElseIf ((mMain.header2 = "AXP") Or (mMain.header2 = "AXV")) Then

                            MapsAndBanks.Nodes.Item(i).Nodes.Add(New TreeNode(x & " - " & MapNameList.Items.Item(maplabelvar)))

                        End If

                    End If

                End If

                x = x + 1
            End While

            i = i + 1

        End While


    End Sub

    Private Sub LoadMapList()
        MapNameList.Items.Clear()
        Dim i As Integer
        For i = 0 To (GetString((AppPath & "ini\roms.ini"), header, "NumberOfMapLabels", "")) - 1
            MapNameList.Items.Add(GetMapLabelName(i))
        Next i
    End Sub

    Private Sub MapsAndBanks_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles MapsAndBanks.AfterSelect

        If (InStr(MapsAndBanks.SelectedNode.FullPath, "\", CompareMethod.Binary) > 0) Then

            MapBank = (MapsAndBanks.SelectedNode.Parent.Index)
            MapNumber = (MapsAndBanks.SelectedNode.Index)

            Point2MapBankPointers = Int32.Parse(GetString(GetINIFileLocation(), header, "Pointer2PointersToMapBanks", ""), System.Globalization.NumberStyles.HexNumber)

            MapBankPointers = ((Val(("&H" & ReverseHEX(ReadHEX(LoadedROM, Point2MapBankPointers, 4)))) - &H8000000))


            BankPointer = ((Val(("&H" & ReverseHEX(ReadHEX(LoadedROM, MapBankPointers + (MapBank * 4), 4)))) - &H8000000))


            HeaderPointer = ((Val(("&H" & ReverseHEX(ReadHEX(LoadedROM, BankPointer + (MapNumber * 4), 4)))) - &H8000000))

            outputtext = ".text" & vbCrLf &
    ".thumb" & vbCrLf &
    ".align 2" & vbCrLf & vbCrLf

            If ((mMain.header2 = "BPR") Or (mMain.header2 = "BPG")) Then




            ElseIf (mMain.header2 = "BPE") Then

                EMLoadOutput()

            ElseIf ((mMain.header2 = "AXP") Or (mMain.header2 = "AXV")) Then


            End If

            OutputTextBox.Text = outputtext

        End If

    End Sub

    Private Sub EMLoadOutput()

        Dim loopvar As Integer

        outputtext = outputtext & "Bank" & MapBank & "_Map" & MapNumber & "_Header:" & vbCrLf

        'Header

        Map_Footer = ("&H" & ReverseHEX(ReadHEX(LoadedROM, HeaderPointer, 4))) - &H8000000

        outputtext = outputtext & "    .long    " & "Bank" & MapBank & "_Map" & MapNumber & "_Footer" & "  @Footer" & vbCrLf

        Map_Events = ("&H" & ReverseHEX(ReadHEX(LoadedROM, HeaderPointer + 4, 4))) - &H8000000

        outputtext = outputtext & "    .long    " & "Bank" & MapBank & "_Map" & MapNumber & "_Events" & "  @Events" & vbCrLf

        Map_Level_Scripts = ("&H" & ReverseHEX(ReadHEX(LoadedROM, HeaderPointer + 8, 4))) - &H8000000

        outputtext = outputtext & "    .long    " & "Bank" & MapBank & "_Map" & MapNumber & "_Level_Scripts" & "  @Level Scripts" & vbCrLf

        Map_Connection_Header = ("&H" & ReverseHEX(ReadHEX(LoadedROM, HeaderPointer + 12, 4))) - &H8000000

        outputtext = outputtext & "    .long    " & "Bank" & MapBank & "_Map" & MapNumber & "_Connections_Header" & "  @Connections" & vbCrLf

        outputtext = outputtext & "    .short    0x" & ReverseHEX(ReadHEX(LoadedROM, HeaderPointer + 16, 2)) & "  @Music" & vbCrLf
        outputtext = outputtext & "    .short    0x" & ReverseHEX(ReadHEX(LoadedROM, HeaderPointer + 18, 2)) & "  @Foorter ID" & vbCrLf
        outputtext = outputtext & "    .byte    0x" & (ReadHEX(LoadedROM, HeaderPointer + 20, 1)) & "  @Name" & vbCrLf
        outputtext = outputtext & "    .byte    0x" & (ReadHEX(LoadedROM, HeaderPointer + 21, 1)) & "  @Light" & vbCrLf
        outputtext = outputtext & "    .byte    0x" & (ReadHEX(LoadedROM, HeaderPointer + 22, 1)) & "  @Weather" & vbCrLf
        outputtext = outputtext & "    .byte    0x" & (ReadHEX(LoadedROM, HeaderPointer + 23, 1)) & "  @Type" & vbCrLf
        outputtext = outputtext & "    .byte    0x" & (ReadHEX(LoadedROM, HeaderPointer + 24, 1)) & "  @Field_18" & vbCrLf
        outputtext = outputtext & "    .byte    0x" & (ReadHEX(LoadedROM, HeaderPointer + 25, 1)) & "  @Can_Dig" & vbCrLf
        outputtext = outputtext & "    .byte    0x" & (ReadHEX(LoadedROM, HeaderPointer + 26, 1)) & "  @Show_Name" & vbCrLf
        outputtext = outputtext & "    .byte    0x" & (ReadHEX(LoadedROM, HeaderPointer + 27, 1)) & "  @BattleType" & vbCrLf

        'Footer

        outputtext = outputtext & vbCrLf

        outputtext = outputtext & "Bank" & MapBank & "_Map" & MapNumber & "_Footer:" & vbCrLf

        outputtext = outputtext & "    .long    0x" & ReverseHEX(ReadHEX(LoadedROM, Map_Footer, 4)) & "  @Map Width" & vbCrLf
        outputtext = outputtext & "    .long    0x" & ReverseHEX(ReadHEX(LoadedROM, Map_Footer + 4, 4)) & "  @Map Height" & vbCrLf
        outputtext = outputtext & "    .long    0x" & ReverseHEX(ReadHEX(LoadedROM, Map_Footer + 8, 4)) & "  @Border Data" & vbCrLf
        outputtext = outputtext & "    .long    0x" & ReverseHEX(ReadHEX(LoadedROM, Map_Footer + 12, 4)) & "  @Map data / Movement Permissons" & vbCrLf
        outputtext = outputtext & "    .long    0x" & ReverseHEX(ReadHEX(LoadedROM, Map_Footer + 16, 4)) & "  @Primary Tileset" & vbCrLf
        outputtext = outputtext & "    .long    0x" & ReverseHEX(ReadHEX(LoadedROM, Map_Footer + 20, 4)) & "  @Secondary Tileset" & vbCrLf

        'Events

        outputtext = outputtext & vbCrLf

        outputtext = outputtext & "Bank" & MapBank & "_Map" & MapNumber & "_Events:" & vbCrLf

        NPC_Num = "&H" & (ReadHEX(LoadedROM, Map_Events, 1))

        outputtext = outputtext & "    .byte    0x" & (ReadHEX(LoadedROM, Map_Events, 1)) & "  @Number of NPC Events" & vbCrLf

        Warp_Num = "&H" & (ReadHEX(LoadedROM, Map_Events + 1, 1))

        outputtext = outputtext & "    .byte    0x" & (ReadHEX(LoadedROM, Map_Events + 1, 1)) & "  @Number of Warps" & vbCrLf

        Script_Event_Num = "&H" & (ReadHEX(LoadedROM, Map_Events + 2, 1))

        outputtext = outputtext & "    .byte    0x" & (ReadHEX(LoadedROM, Map_Events + 2, 1)) & "  @Number of Script Events" & vbCrLf

        SignPost_Num = "&H" & (ReadHEX(LoadedROM, Map_Events + 3, 1))

        outputtext = outputtext & "    .byte    0x" & (ReadHEX(LoadedROM, Map_Events + 3, 1)) & "  @Number of Signposts" & vbCrLf

        NPC_Pointer = ("&H" & ReverseHEX(ReadHEX(LoadedROM, Map_Events + 4, 4))) - &H8000000

        outputtext = outputtext & "    .long    " & "Bank" & MapBank & "_Map" & MapNumber & "_NPCs" & "  @Pointer to NPC Events" & vbCrLf

        Warp_Pointer = ("&H" & ReverseHEX(ReadHEX(LoadedROM, Map_Events + 8, 4))) - &H8000000

        outputtext = outputtext & "    .long    " & "Bank" & MapBank & "_Map" & MapNumber & "_Warps" & "  @Pointer to Warps" & vbCrLf

        Script_Event_Pointer = ("&H" & ReverseHEX(ReadHEX(LoadedROM, Map_Events + 12, 4))) - &H8000000

        outputtext = outputtext & "    .long    " & "Bank" & MapBank & "_Map" & MapNumber & "_Script_Events" & "  @Pointer to Script Events" & vbCrLf

        SignPost_Pointer = ("&H" & ReverseHEX(ReadHEX(LoadedROM, Map_Events + 16, 4))) - &H8000000

        outputtext = outputtext & "    .long    " & "Bank" & MapBank & "_Map" & MapNumber & "_Sign_Posts" & "  @Pointer to Signposts" & vbCrLf

        loopvar = 0

        outputtext = outputtext & vbCrLf

        outputtext = outputtext & "Bank" & MapBank & "_Map" & MapNumber & "_NPCs:" & vbCrLf

        While loopvar < NPC_Num

            outputtext = outputtext & vbCrLf & "@NPC " & (loopvar + 1) & vbCrLf

            outputtext = outputtext & "    .byte    0x" & (ReadHEX(LoadedROM, NPC_Pointer + (loopvar * 24), 1)) & "  @NPC Number" & vbCrLf
            outputtext = outputtext & "    .byte    0x" & (ReadHEX(LoadedROM, NPC_Pointer + 1 + (loopvar * 24), 1)) & "  @Sprite ID" & vbCrLf
            outputtext = outputtext & "    .short    0x" & ReverseHEX(ReadHEX(LoadedROM, NPC_Pointer + 2 + (loopvar * 24), 2)) & "  @???" & vbCrLf
            outputtext = outputtext & "    .short    0x" & ReverseHEX(ReadHEX(LoadedROM, NPC_Pointer + 4 + (loopvar * 24), 2)) & "  @X Position" & vbCrLf
            outputtext = outputtext & "    .short    0x" & ReverseHEX(ReadHEX(LoadedROM, NPC_Pointer + 6 + (loopvar * 24), 2)) & "  @Y Position" & vbCrLf
            outputtext = outputtext & "    .byte    0x" & (ReadHEX(LoadedROM, NPC_Pointer + 8 + (loopvar * 24), 1)) & "  @Height" & vbCrLf
            outputtext = outputtext & "    .byte    0x" & (ReadHEX(LoadedROM, NPC_Pointer + 9 + (loopvar * 24), 1)) & "  @Behaviour" & vbCrLf
            outputtext = outputtext & "    .short    0x" & ReverseHEX(ReadHEX(LoadedROM, NPC_Pointer + 10 + (loopvar * 24), 2)) & "  @Behaviour Property" & vbCrLf
            outputtext = outputtext & "    .byte    0x" & (ReadHEX(LoadedROM, NPC_Pointer + 12 + (loopvar * 24), 1)) & "  @Is_Trainer" & vbCrLf
            outputtext = outputtext & "    .byte    0x" & (ReadHEX(LoadedROM, NPC_Pointer + 13 + (loopvar * 24), 1)) & "  @???" & vbCrLf
            outputtext = outputtext & "    .short    0x" & ReverseHEX(ReadHEX(LoadedROM, NPC_Pointer + 14 + (loopvar * 24), 2)) & "  @radius_or_plantID" & vbCrLf
            outputtext = outputtext & "    .long    0x" & ReverseHEX(ReadHEX(LoadedROM, NPC_Pointer + 16 + (loopvar * 24), 4)) & "  @Script Pointer" & vbCrLf
            outputtext = outputtext & "    .short    0x" & ReverseHEX(ReadHEX(LoadedROM, NPC_Pointer + 20 + (loopvar * 24), 2)) & "  @Flag" & vbCrLf
            outputtext = outputtext & "    .short    0x" & ReverseHEX(ReadHEX(LoadedROM, NPC_Pointer + 22 + (loopvar * 24), 2)) & "  @???" & vbCrLf

            loopvar = loopvar + 1
        End While

        loopvar = 0

        outputtext = outputtext & vbCrLf

        outputtext = outputtext & "Bank" & MapBank & "_Map" & MapNumber & "_Warps:" & vbCrLf

        While loopvar < Warp_Num

            outputtext = outputtext & vbCrLf & "@Warp " & (loopvar + 1) & vbCrLf

            outputtext = outputtext & "    .short    0x" & ReverseHEX(ReadHEX(LoadedROM, Warp_Pointer + (loopvar * 8), 2)) & "  @X Position" & vbCrLf
            outputtext = outputtext & "    .short    0x" & ReverseHEX(ReadHEX(LoadedROM, Warp_Pointer + 2 + (loopvar * 8), 2)) & "  @Y Position" & vbCrLf
            outputtext = outputtext & "    .byte    0x" & (ReadHEX(LoadedROM, Warp_Pointer + 4 + (loopvar * 8), 1)) & "  @Height" & vbCrLf
            outputtext = outputtext & "    .byte    0x" & (ReadHEX(LoadedROM, Warp_Pointer + 5 + (loopvar * 8), 1)) & "  @Target Warp" & vbCrLf
            outputtext = outputtext & "    .byte    0x" & (ReadHEX(LoadedROM, Warp_Pointer + 6 + (loopvar * 8), 1)) & "  @Target Map" & vbCrLf
            outputtext = outputtext & "    .byte    0x" & (ReadHEX(LoadedROM, Warp_Pointer + 7 + (loopvar * 8), 1)) & "  @Target Bank" & vbCrLf

            loopvar = loopvar + 1
        End While

        loopvar = 0

        outputtext = outputtext & vbCrLf

        outputtext = outputtext & "Bank" & MapBank & "_Map" & MapNumber & "_Script_Events:" & vbCrLf

        While loopvar < Script_Event_Num

            outputtext = outputtext & vbCrLf & "@Script Event " & (loopvar + 1) & vbCrLf

            outputtext = outputtext & "    .short    0x" & ReverseHEX(ReadHEX(LoadedROM, Script_Event_Pointer + (loopvar * 16), 2)) & "  @X Position" & vbCrLf
            outputtext = outputtext & "    .short    0x" & ReverseHEX(ReadHEX(LoadedROM, Script_Event_Pointer + 2 + (loopvar * 16), 2)) & "  @Y Position" & vbCrLf
            outputtext = outputtext & "    .byte    0x" & (ReadHEX(LoadedROM, Script_Event_Pointer + 4 + (loopvar * 16), 1)) & "  @Height" & vbCrLf
            outputtext = outputtext & "    .byte    0x" & (ReadHEX(LoadedROM, Script_Event_Pointer + 5 + (loopvar * 16), 1)) & "  @???" & vbCrLf
            outputtext = outputtext & "    .short    0x" & ReverseHEX(ReadHEX(LoadedROM, Script_Event_Pointer + 6 + (loopvar * 16), 2)) & "  @Variable" & vbCrLf
            outputtext = outputtext & "    .short    0x" & ReverseHEX(ReadHEX(LoadedROM, Script_Event_Pointer + 8 + (loopvar * 16), 2)) & "  @Value" & vbCrLf
            outputtext = outputtext & "    .short    0x" & ReverseHEX(ReadHEX(LoadedROM, Script_Event_Pointer + 10 + (loopvar * 16), 2)) & "  @???" & vbCrLf
            outputtext = outputtext & "    .long    0x" & ReverseHEX(ReadHEX(LoadedROM, Script_Event_Pointer + 12 + (loopvar * 16), 4)) & "  @Script Pointer" & vbCrLf

            loopvar = loopvar + 1
        End While

        loopvar = 0

        outputtext = outputtext & vbCrLf

        outputtext = outputtext & "Bank" & MapBank & "_Map" & MapNumber & "_Sign_Posts:" & vbCrLf

        While loopvar < SignPost_Num

            outputtext = outputtext & vbCrLf & "@Sign Post " & (loopvar + 1) & vbCrLf

            outputtext = outputtext & "    .short    0x" & ReverseHEX(ReadHEX(LoadedROM, SignPost_Pointer + (loopvar * 12), 2)) & "  @X Position" & vbCrLf
            outputtext = outputtext & "    .short    0x" & ReverseHEX(ReadHEX(LoadedROM, SignPost_Pointer + 2 + (loopvar * 12), 2)) & "  @Y Position" & vbCrLf
            outputtext = outputtext & "    .byte    0x" & (ReadHEX(LoadedROM, SignPost_Pointer + 4 + (loopvar * 12), 1)) & "  @???" & vbCrLf
            outputtext = outputtext & "    .byte    0x" & (ReadHEX(LoadedROM, SignPost_Pointer + 5 + (loopvar * 12), 1)) & "  @Hidden Item" & vbCrLf
            outputtext = outputtext & "    .byte    0x" & (ReadHEX(LoadedROM, SignPost_Pointer + 6 + (loopvar * 12), 1)) & "  @???" & vbCrLf
            outputtext = outputtext & "    .byte    0x" & (ReadHEX(LoadedROM, SignPost_Pointer + 7 + (loopvar * 12), 1)) & "  @???" & vbCrLf
            outputtext = outputtext & "    .long    0x" & ReverseHEX(ReadHEX(LoadedROM, SignPost_Pointer + 8 + (loopvar * 12), 4)) & "  @Script Pointer" & vbCrLf

            loopvar = loopvar + 1
        End While

        'Level Scripts

        outputtext = outputtext & vbCrLf

        outputtext = outputtext & "Bank" & MapBank & "_Map" & MapNumber & "_Level_Scripts:" & vbCrLf



        loopvar = 0

        While (ReadHEX(LoadedROM, Map_Level_Scripts + (loopvar * 5), 1) <> "00")



            If (ReadHEX(LoadedROM, Map_Level_Scripts + (loopvar * 5), 1)) = "02" Then

                outputtext = outputtext & "    .byte    0x" & (ReadHEX(LoadedROM, Map_Level_Scripts + (loopvar * 5), 1)) & "  @Type" & vbCrLf
                outputtext = outputtext & "    .long    " & "Bank" & MapBank & "_Map" & MapNumber & "_Level_Scripts_2" & "  @Pointer" & vbCrLf

                LevelScript2Pointer = ("&H" & ReverseHEX(ReadHEX(LoadedROM, Map_Level_Scripts + 1 + (loopvar * 5), 4))) - &H8000000

                Dim loopvar2 As Integer

                loopvar2 = 0

                outputlevel2 = outputlevel2 & vbCrLf

                outputlevel2 = outputlevel2 & "Bank" & MapBank & "_Map" & MapNumber & "_Level_Scripts_2:" & vbCrLf

                While ReverseHEX(ReadHEX(LoadedROM, LevelScript2Pointer + (loopvar2 * 8), 2)) <> "0000"

                    outputlevel2 = outputlevel2 & "    .short    0x" & ReverseHEX(ReadHEX(LoadedROM, LevelScript2Pointer + (loopvar2 * 8), 2)) & "  @Variable" & vbCrLf
                    outputlevel2 = outputlevel2 & "    .short    0x" & ReverseHEX(ReadHEX(LoadedROM, LevelScript2Pointer + 2 + (loopvar2 * 8), 2)) & "  @Value to run" & vbCrLf
                    outputlevel2 = outputlevel2 & "    .long    0x" & ReverseHEX(ReadHEX(LoadedROM, LevelScript2Pointer + 4 + (loopvar2 * 8), 4)) & "  @Pointer" & vbCrLf

                    loopvar2 = loopvar2 + 1
                End While

                outputlevel2 = outputlevel2 & "    .short    0x" & ReverseHEX(ReadHEX(LoadedROM, LevelScript2Pointer + (loopvar2 * 8), 2)) & "  @Terminator" & vbCrLf

            ElseIf (ReadHEX(LoadedROM, Map_Level_Scripts + (loopvar * 5), 1)) = "04" Then

                outputtext = outputtext & "    .byte    0x" & (ReadHEX(LoadedROM, Map_Level_Scripts + (loopvar * 5), 1)) & "  @Type" & vbCrLf
                outputtext = outputtext & "    .long    " & "Bank" & MapBank & "_Map" & MapNumber & "_Level_Scripts_4" & "  @Pointer" & vbCrLf

                LevelScript4Pointer = ("&H" & ReverseHEX(ReadHEX(LoadedROM, Map_Level_Scripts + 1 + (loopvar * 5), 4))) - &H8000000

                Dim loopvar2 As Integer

                loopvar2 = 0

                outputlevel4 = outputlevel4 & vbCrLf

                outputlevel4 = outputlevel4 & "Bank" & MapBank & "_Map" & MapNumber & "_Level_Scripts_4:" & vbCrLf

                While ReverseHEX(ReadHEX(LoadedROM, LevelScript2Pointer + (loopvar2 * 8), 2)) <> "0000"

                    outputlevel4 = outputlevel4 & "    .short    0x" & ReverseHEX(ReadHEX(LoadedROM, LevelScript4Pointer + (loopvar2 * 8), 2)) & "  @Variable" & vbCrLf
                    outputlevel4 = outputlevel4 & "    .short    0x" & ReverseHEX(ReadHEX(LoadedROM, LevelScript4Pointer + 2 + (loopvar2 * 8), 2)) & "  @Value to run" & vbCrLf
                    outputlevel4 = outputlevel4 & "    .long    0x" & ReverseHEX(ReadHEX(LoadedROM, LevelScript4Pointer + 4 + (loopvar2 * 8), 4)) & "  @Pointer" & vbCrLf

                    loopvar2 = loopvar2 + 1
                End While

                outputlevel4 = outputlevel4 & "    .short    0x" & ReverseHEX(ReadHEX(LoadedROM, LevelScript4Pointer + (loopvar2 * 8), 2)) & "  @Terminator" & vbCrLf

            Else

                outputtext = outputtext & "    .byte    0x" & (ReadHEX(LoadedROM, Map_Level_Scripts + (loopvar * 5), 1)) & "  @Type" & vbCrLf
                outputtext = outputtext & "    .long    0x" & ReverseHEX(ReadHEX(LoadedROM, Map_Level_Scripts + 1 + (loopvar * 5), 4)) & "  @Pointer" & vbCrLf

            End If

            loopvar = loopvar + 1
        End While

        outputtext = outputtext & "    .byte    0x" & (ReadHEX(LoadedROM, Map_Level_Scripts + (loopvar * 5), 1)) & "  @Terminator" & vbCrLf

        outputtext = outputtext & outputlevel2
        outputtext = outputtext & outputlevel4

        'Connections

        outputtext = outputtext & vbCrLf

        outputtext = outputtext & "Bank" & MapBank & "_Map" & MapNumber & "_Connections_Header:" & vbCrLf

        Connection_Num = ("&H" & ReverseHEX(ReadHEX(LoadedROM, Map_Connection_Header, 4)))
        Connection_Pointer = ("&H" & ReverseHEX(ReadHEX(LoadedROM, Map_Connection_Header + 4, 4))) - &H8000000

        outputtext = outputtext & "    .long    0x" & ReverseHEX(ReadHEX(LoadedROM, Map_Connection_Header, 4)) & "  @Number of Connections" & vbCrLf
        outputtext = outputtext & "    .long    " & "Bank" & MapBank & "_Map" & MapNumber & "_Connections" & "  @Pointer to Connections" & vbCrLf

        loopvar = 0

        outputtext = outputtext & vbCrLf

        outputtext = outputtext & "Bank" & MapBank & "_Map" & MapNumber & "_Connections:" & vbCrLf

        While loopvar < Connection_Num

            outputtext = outputtext & "    .long    0x" & ReverseHEX(ReadHEX(LoadedROM, Connection_Pointer + (loopvar * 12), 4)) & "  @Direction" & vbCrLf
            outputtext = outputtext & "    .long    0x" & ReverseHEX(ReadHEX(LoadedROM, Connection_Pointer + 4 + (loopvar * 12), 4)) & "  @Offset Reference" & vbCrLf
            outputtext = outputtext & "    .byte    0x" & (ReadHEX(LoadedROM, Connection_Pointer + 8 + (loopvar * 12), 1)) & "  @Map Bank" & vbCrLf
            outputtext = outputtext & "    .byte    0x" & (ReadHEX(LoadedROM, Connection_Pointer + 9 + (loopvar * 12), 1)) & "  @Map Number" & vbCrLf
            outputtext = outputtext & "    .short    0x" & ReverseHEX(ReadHEX(LoadedROM, Connection_Pointer + 10 + (loopvar * 12), 2)) & "  @Filler" & vbCrLf

            loopvar = loopvar + 1
        End While


    End Sub

    Private Sub ExportBttn_Click(sender As Object, e As EventArgs) Handles ExportBttn.Click

        FolderBrowserDialog1.Description = "Select folder to export to:"

        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            Me.Text = "Please wait..."
            Me.UseWaitCursor = True




            Me.Text = "Map Dumper"
        Me.UseWaitCursor = False
        Me.Enabled = True
            Me.BringToFront()

        End If
    End Sub
End Class
