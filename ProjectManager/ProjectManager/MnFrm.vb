﻿Imports System.IO
Imports System.Net
Imports VB = Microsoft.VisualBasic

Public Class MnFrm
    Private Sub FeatureListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FeatureListBox.SelectedIndexChanged
        TabControl1.SelectedIndex() = FeatureListBox.SelectedIndex
    End Sub

    Private Sub FeatureListBox_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles FeatureListBox.ItemCheck
        'Dim messageBoxVB As New System.Text.StringBuilder()
        'messageBoxVB.AppendFormat("{0} = {1}", "Index", e.Index)
        'messageBoxVB.AppendLine()
        'messageBoxVB.AppendFormat("{0} = {1}", "NewValue", e.NewValue)
        'messageBoxVB.AppendLine()
        'messageBoxVB.AppendFormat("{0} = {1}", "CurrentValue", e.CurrentValue)
        'messageBoxVB.AppendLine()
        'MessageBox.Show(messageBoxVB.ToString(), "ItemCheck Event")

        WriteString(AppPath & "ProjectSettings.ini", "Settings", "Feature" & e.Index, e.NewValue)


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim result As Integer = MessageBox.Show("This will download and replace the current version you have of this project. Make sure to back up any customizations you have made. Are you sure you want to continue?", "Are you sure?", MessageBoxButtons.YesNo)

        If result = DialogResult.Yes Then
            If System.IO.File.Exists(AppPath & "temp\PokeExpansion.zip") = True Then

                System.IO.File.Delete(AppPath & "temp\PokeExpansion.zip")

            End If

            If (System.IO.Directory.Exists(AppPath & "PokeExpansion-master\")) Then
                System.IO.Directory.Delete(AppPath & "PokeExpansion-master\", True)
            End If

            DownloadFile("https://github.com/DizzyEggg/PokeExpansion/archive/master.zip", AppPath & "temp\PokeExpansion.zip")

            Unzipfile(AppPath & "temp\PokeExpansion.zip", AppPath & "")
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim result As Integer = MessageBox.Show("This will download and replace the current version you have of this project. Make sure to back up any customizations you have made. Are you sure you want to continue?", "Are you sure?", MessageBoxButtons.YesNo)

        If result = DialogResult.Yes Then
            If System.IO.File.Exists(AppPath & "temp\Pokemon-Emerald-Battle-Engine-Upgrade.zip") = True Then

                System.IO.File.Delete(AppPath & "temp\Pokemon-Emerald-Battle-Engine-Upgrade.zip")

            End If

            If (System.IO.Directory.Exists(AppPath & "Pokemon-Emerald-Battle-Engine-Upgrade-master\")) Then
                System.IO.Directory.Delete(AppPath & "Pokemon-Emerald-Battle-Engine-Upgrade-master\", True)
            End If

            DownloadFile("https://github.com/KDSKardabox/Pokemon-Emerald-Battle-Engine-Upgrade/archive/master.zip", AppPath & "temp\Pokemon-Emerald-Battle-Engine-Upgrade.zip")
            Unzipfile(AppPath & "temp\Pokemon-Emerald-Battle-Engine-Upgrade.zip", AppPath & "")

        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim result As Integer = MessageBox.Show("This will download and replace the current version you have of this project. Make sure to back up any customizations you have made. Are you sure you want to continue?", "Are you sure?", MessageBoxButtons.YesNo)

        If result = DialogResult.Yes Then

            If System.IO.File.Exists(AppPath & "temp\Shiny_Hack.zip") = True Then

                System.IO.File.Delete(AppPath & "temp\Shiny_Hack.zip")

            End If

            If (System.IO.Directory.Exists(AppPath & "Shiny_Hack-master\")) Then
                System.IO.Directory.Delete(AppPath & "Shiny_Hack-master\", True)
            End If

            DownloadFile("https://github.com/Gamer2020/Shiny_Hack/archive/master.zip", AppPath & "temp\Shiny_Hack.zip")

            Unzipfile(AppPath & "temp\Shiny_Hack.zip", AppPath & "")

        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim result As Integer = MessageBox.Show("This will download and replace the current version you have of this project. Make sure to back up any customizations you have made. Are you sure you want to continue?", "Are you sure?", MessageBoxButtons.YesNo)

        If result = DialogResult.Yes Then

            If System.IO.File.Exists(AppPath & "temp\ItemTmTutorExpansion.zip") = True Then

                System.IO.File.Delete(AppPath & "temp\ItemTmTutorExpansion.zip")

            End If

            If (System.IO.Directory.Exists(AppPath & "ItemTmTutorExpansion-master\")) Then
                System.IO.Directory.Delete(AppPath & "ItemTmTutorExpansion-master\", True)
            End If

            DownloadFile("https://github.com/DizzyEggg/ItemTmTutorExpansion/archive/master.zip", AppPath & "temp\ItemTmTutorExpansion.zip")

            Unzipfile(AppPath & "temp\ItemTmTutorExpansion.zip", AppPath & "")


        End If
    End Sub

    Private Sub MnFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (Not System.IO.Directory.Exists(AppPath & "temp\")) Then
            System.IO.Directory.CreateDirectory(AppPath & "temp\")
        End If

        If GetString(AppPath & "ProjectSettings.ini", "Settings", "Feature1", "0") = "1" Then
            FeatureListBox.SetItemChecked(1, True)
        End If

        If GetString(AppPath & "ProjectSettings.ini", "Settings", "Feature0", "0") = "1" Then
            FeatureListBox.SetItemChecked(0, True)
        End If

        If GetString(AppPath & "ProjectSettings.ini", "Settings", "Feature2", "0") = "1" Then
            FeatureListBox.SetItemChecked(2, True)
        End If

        If GetString(AppPath & "ProjectSettings.ini", "Settings", "Feature3", "0") = "1" Then
            FeatureListBox.SetItemChecked(3, True)
        End If

        If GetString(AppPath & "ProjectSettings.ini", "Settings", "ExpandROM", "0") = "1" Then
            CheckBox1.Checked = True
        End If

        If GetString(AppPath & "ProjectSettings.ini", "Settings", "CreatePatch", "0") = "1" Then
            CheckBox2.Checked = True
        End If

        TextBox1.Text = GetString(AppPath & "ProjectSettings.ini", "Settings", "ROMName", "Template")

        CalcSaveRamOffsetForItems()



    End Sub

    Public Sub CalcSaveRamOffsetForItems()

        If TextBox7.Text <> "" And TextBox2.Text <> "" Then


            TextBox8.Text = VB.Right("00000000" & Hex(MakeEvenIfNot(("&H" & TextBox7.Text) + Math.Ceiling(TextBox2.Text / 8) + Math.Ceiling(TextBox2.Text / 8))), 8)

        End If

    End Sub

    Public Sub SaveRamCalc()

        Dim ExpansionLines() As String = IO.File.ReadAllLines(AppPath & "PokeExpansion-master\scripts\expansion.py")
        Dim ExpansionCount As Integer = 0

        For Each Line As String In ExpansionLines

            If Line.StartsWith("dex_pokes") = True Then

                ExpansionLines(ExpansionCount) = "dex_pokes = " & TextBox2.Text


            End If

            ExpansionCount = ExpansionCount + 1

        Next

        IO.File.WriteAllLines(AppPath & "PokeExpansion-master\scripts\expansion.py", ExpansionLines)

        ExpansionLines = IO.File.ReadAllLines(AppPath & "PokeExpansion-master\src\defines.h")
        ExpansionCount = 0

        For Each Line As String In ExpansionLines

            If Line.StartsWith("#define DEX_POKES") = True Then

                ExpansionLines(ExpansionCount) = "#define DEX_POKES " & TextBox2.Text

            End If

            ExpansionCount = ExpansionCount + 1

        Next

        IO.File.WriteAllLines(AppPath & "PokeExpansion-master\src\defines.h", ExpansionLines)

        ExpansionLines = IO.File.ReadAllLines(AppPath & "PokeExpansion-master\BPEE.ld")
        ExpansionCount = 0

        For Each Line As String In ExpansionLines

            If Line.StartsWith("new_saveblock = ") = True Then

                ExpansionLines(ExpansionCount) = "new_saveblock = 0x" & TextBox7.Text & ";"

            End If

            ExpansionCount = ExpansionCount + 1

        Next

        IO.File.WriteAllLines(AppPath & "PokeExpansion-master\BPEE.ld", ExpansionLines)

        ExpansionLines = IO.File.ReadAllLines(AppPath & "ItemTmTutorExpansion-master\scripts\items.py")
        ExpansionCount = 0

        For Each Line As String In ExpansionLines

            If Line.StartsWith("EXPANDED_BAG_OFFSET") = True Then

                ExpansionLines(ExpansionCount) = "EXPANDED_BAG_OFFSET = 0x" & TextBox8.Text

            End If

            ExpansionCount = ExpansionCount + 1

        Next

        IO.File.WriteAllLines(AppPath & "ItemTmTutorExpansion-master\scripts\items.py", ExpansionLines)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        SaveRamCalc()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        SaveRamCalc()
    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged
        CalcSaveRamOffsetForItems()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        CalcSaveRamOffsetForItems()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then

            WriteString(AppPath & "ProjectSettings.ini", "Settings", "ExpandROM", 1)

        Else
            WriteString(AppPath & "ProjectSettings.ini", "Settings", "ExpandROM", 0)
        End If

    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged

        If CheckBox2.Checked = True Then

            WriteString(AppPath & "ProjectSettings.ini", "Settings", "CreatePatch", 1)

        Else
            WriteString(AppPath & "ProjectSettings.ini", "Settings", "CreatePatch", 0)
        End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        WriteString(AppPath & "ProjectSettings.ini", "Settings", "ROMName", TextBox1.Text)
    End Sub
End Class
