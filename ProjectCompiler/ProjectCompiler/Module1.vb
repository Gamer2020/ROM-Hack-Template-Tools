Imports System.IO
Imports System.Net
Imports VB = Microsoft.VisualBasic

Module Module1

    Sub Main()

        LastROMLocal = AppPath & "Base\rom.gba"

        If GetString(AppPath & "ProjectSettings.ini", "Settings", "Feature1", "0") = "1" Then

            If (System.IO.Directory.Exists(AppPath & "Pokemon-Emerald-Battle-Engine-Upgrade-master\")) Then
                ApplyEngineUpgrade()
            End If

        End If

        If GetString(AppPath & "ProjectSettings.ini", "Settings", "Feature0", "0") = "1" Then

            If (System.IO.Directory.Exists(AppPath & "PokeExpansion-master\")) Then
                ApplyPokeExpan()
            End If

        End If

        If GetString(AppPath & "ProjectSettings.ini", "Settings", "Feature2", "0") = "1" Then

            If (System.IO.Directory.Exists(AppPath & "ItemTmTutorExpansion-master\")) Then
                ApplyItemExpan()
            End If


        End If

        If GetString(AppPath & "ProjectSettings.ini", "Settings", "Feature3", "0") = "1" Then

            If (System.IO.Directory.Exists(AppPath & "Shiny_Hack-master\")) Then
                ApplyShinyHack()
            End If

        End If

        If (System.IO.Directory.Exists(AppPath & "Game\")) Then
            ApplyGame()
        End If


    End Sub

    Public Sub ApplyShinyHack()

        Dim proc As New Process


        File.Copy(LastROMLocal, AppPath & "Shiny_Hack-master\rom.gba", True)

        LastROMLocal = AppPath & "Shiny_Hack-master\rom.gba"


        proc.StartInfo.WorkingDirectory = AppPath & "Shiny_Hack-master\"
        proc.StartInfo.FileName = "python" 'Use the the full Pathname of the program
        proc.StartInfo.Arguments = "scripts//make.py" 'This is the argument that is used
        proc.StartInfo.UseShellExecute = False
        proc.StartInfo.RedirectStandardOutput = True
        proc.StartInfo.CreateNoWindow = True 'Dont show the cmd window when the program is running
        proc.Start()
        proc.WaitForExit()

        LastROMLocal = AppPath & "Shiny_Hack-master\test.gba"

    End Sub

    Public Sub ApplyPokeExpan()

        Dim proc As New Process

        File.Copy(LastROMLocal, AppPath & "PokeExpansion-master\rom.gba", True)

        LastROMLocal = AppPath & "PokeExpansion-master\rom.gba"

        proc.StartInfo.WorkingDirectory = AppPath & "build\PokeExpansion-master\"
        proc.StartInfo.FileName = "python" 'Use the the full Pathname of the program
        proc.StartInfo.Arguments = "scripts//expansion.py" 'This is the argument that is used
        proc.StartInfo.UseShellExecute = False
        proc.StartInfo.RedirectStandardOutput = True
        proc.StartInfo.CreateNoWindow = True 'Dont show the cmd window when the program is running
        proc.Start()
        proc.WaitForExit()

        LastROMLocal = AppPath & "PokeExpansion-master\test.gba"



    End Sub

    Public Sub ApplyItemExpan()

        Dim proc As New Process

        File.Copy(LastROMLocal, AppPath & "ItemTmTutorExpansion-master\rom.gba", True)

        LastROMLocal = AppPath & "ItemTmTutorExpansion-master\rom.gba"

        proc.StartInfo.WorkingDirectory = AppPath & "ItemTmTutorExpansion-master\"
        proc.StartInfo.FileName = "python" 'Use the the full Pathname of the program
        proc.StartInfo.Arguments = "scripts//items.py" 'This is the argument that is used
        proc.StartInfo.UseShellExecute = False
        proc.StartInfo.RedirectStandardOutput = True
        proc.StartInfo.CreateNoWindow = True 'Dont show the cmd window when the program is running
        proc.Start()
        proc.WaitForExit()

        LastROMLocal = AppPath & "ItemTmTutorExpansion-master\test.gba"

    End Sub

    Public Sub ApplyEngineUpgrade()

        Dim proc As New Process

        File.Copy(LastROMLocal, AppPath & "Pokemon-Emerald-Battle-Engine-Upgrade-master\BPEE0.gba", True)

        LastROMLocal = AppPath & "Pokemon-Emerald-Battle-Engine-Upgrade-master\BPEE0.gba"

        proc.StartInfo.WorkingDirectory = AppPath & "Pokemon-Emerald-Battle-Engine-Upgrade-master\"
        proc.StartInfo.FileName = "python" 'Use the the full Pathname of the program
        proc.StartInfo.Arguments = "scripts//make.py" 'This is the argument that is used
        proc.StartInfo.UseShellExecute = False
        proc.StartInfo.RedirectStandardOutput = True
        proc.StartInfo.CreateNoWindow = True 'Dont show the cmd window when the program is running
        proc.Start()
        proc.WaitForExit()


        LastROMLocal = AppPath & "Pokemon-Emerald-Battle-Engine-Upgrade-master\test.gba"


    End Sub

    Public Sub ApplyGame()
        Dim proc As New Process


        File.Copy(LastROMLocal, AppPath & "Game\rom.gba", True)

        LastROMLocal = AppPath & "Game\rom.gba"


        proc.StartInfo.WorkingDirectory = AppPath & "Game\"
        proc.StartInfo.FileName = "python" 'Use the the full Pathname of the program
        proc.StartInfo.Arguments = "scripts//make.py" 'This is the argument that is used
        proc.StartInfo.UseShellExecute = False
        proc.StartInfo.RedirectStandardOutput = True
        proc.StartInfo.CreateNoWindow = True 'Dont show the cmd window when the program is running
        proc.Start()
        proc.WaitForExit()

        LastROMLocal = AppPath & "Game\test.gba"

    End Sub

End Module
