Imports System.IO
Imports System.Net
Imports VB = Microsoft.VisualBasic

Module Module1

    Sub Main()

        LastROMLocal = AppPath & "Base\rom.gba"

        If GetString(AppPath & "ProjectSettings.ini", "Settings", "ExpandROM", "0") = "1" Then

            File.Copy(LastROMLocal, AppPath & "Base\ex-rom.gba", True)

            LastROMLocal = AppPath & "Base\ex-rom.gba"

            Dim fileinfo As New FileInfo(LastROMLocal)
            Dim Temp(33554431 - fileinfo.Length) As Byte

            MemSet(Temp, &HFF)

            Dim s As New System.IO.FileStream(LastROMLocal, System.IO.FileMode.Append, System.IO.FileAccess.Write, System.IO.FileShare.ReadWrite)
            s.Write(Temp, 0, Temp.Length)
            s.Close()

            Dim fileinfo2 As New FileInfo(LastROMLocal)

            Console.WriteLine("Expanded ROM: " & fileinfo2.Length & " bytes")

        End If

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


        If System.IO.File.Exists(AppPath & "Base\ex-rom.gba") Then
            System.IO.File.Delete(AppPath & "Base\ex-rom.gba")
        End If

        File.Copy(LastROMLocal, AppPath & GetString(AppPath & "ProjectSettings.ini", "Settings", "ROMName", "OutPut") & ".gba", True)

        LastROMLocal = AppPath & GetString(AppPath & "ProjectSettings.ini", "Settings", "ROMName", "OutPut") & ".gba"

        If GetString(AppPath & "ProjectSettings.ini", "Settings", "CreatePatch", "0") = "1" Then

            Console.WriteLine("Building ups patch...")

            Dim original As Byte() = Nothing, modified As Byte() = Nothing

            Try
                Dim br As New BinaryReader(File.OpenRead(AppPath & "Base\rom.gba"))
                original = br.ReadBytes(CInt(br.BaseStream.Length))
                br.Close()
            Catch generatedExceptionName As Exception
                Console.WriteLine("Error opening file" & vbLf + AppPath & "Base\rom.gba")
                Return
            End Try


            Try
                Dim br As New BinaryReader(File.Open(LastROMLocal, FileMode.Open))
                modified = br.ReadBytes(CInt(br.BaseStream.Length))
                br.Close()
            Catch generatedExceptionName As Exception
                Console.WriteLine("Error opening file" & vbLf + LastROMLocal)
                Return
            End Try

            Dim patch As New Nintenlord.UPSpatcher.UPSfile(original, modified)

            patch.writeToFile(AppPath & GetString(AppPath & "ProjectSettings.ini", "Settings", "ROMName", "OutPut") & ".ups")
            Console.WriteLine("Patch has been created.")

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
        proc.StartInfo.RedirectStandardOutput = False
        proc.StartInfo.CreateNoWindow = False 'Dont show the cmd window when the program is running
        proc.Start()
        proc.WaitForExit()

        LastROMLocal = AppPath & "Shiny_Hack-master\test.gba"

    End Sub

    Public Sub ApplyPokeExpan()

        Dim proc As New Process

        File.Copy(LastROMLocal, AppPath & "PokeExpansion-master\rom.gba", True)

        LastROMLocal = AppPath & "PokeExpansion-master\rom.gba"

        proc.StartInfo.WorkingDirectory = AppPath & "PokeExpansion-master\"
        proc.StartInfo.FileName = "python" 'Use the the full Pathname of the program
        proc.StartInfo.Arguments = "scripts//expansion.py" 'This is the argument that is used
        proc.StartInfo.UseShellExecute = False
        proc.StartInfo.RedirectStandardOutput = False
        proc.StartInfo.CreateNoWindow = False 'Dont show the cmd window when the program is running
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
        proc.StartInfo.RedirectStandardOutput = False
        proc.StartInfo.CreateNoWindow = False 'Dont show the cmd window when the program is running
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
        proc.StartInfo.RedirectStandardOutput = False
        proc.StartInfo.CreateNoWindow = False 'Dont show the cmd window when the program is running
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
        proc.StartInfo.RedirectStandardOutput = False
        proc.StartInfo.CreateNoWindow = False 'Dont show the cmd window when the program is running
        proc.Start()
        proc.WaitForExit()

        LastROMLocal = AppPath & "Game\test.gba"

    End Sub


    Public Sub MemSet(array As Byte(), value As Byte)

        Dim block As Integer = 32, index As Integer = 0
        Dim length As Integer = Math.Min(block, array.Length)

        'Fill the initial array
        While index < length

            array(System.Math.Max(System.Threading.Interlocked.Increment(index), index - 1) - 1) = value
        End While

        length = array.Length
        While index < length
            Buffer.BlockCopy(array, 0, array, index, Math.Min(block, length - index))
            index += block
            block *= 2
        End While

    End Sub

End Module
