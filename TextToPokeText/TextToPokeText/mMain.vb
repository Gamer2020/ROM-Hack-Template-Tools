Module mMain
    Public Function ConvertStringToByteArray(ByRef str As String) As Byte()
        Dim buffer2 As Byte() = New Byte(((str.Length - 1) + 1) - 1) {}
        Dim num2 As Integer = (str.Length - 1)
        Dim i As Integer = 0
        Do While (i <= num2)
            buffer2(i) = CByte(Strings.Asc(Strings.Mid(str, (i + 1), 1)))
            i += 1
        Loop
        Return buffer2
    End Function

    Public Function MakeProperByte(DaByte As Byte) As String
        Dim OutputByte As String


        If Len(Hex(DaByte)) = 1 Then
            OutputByte = "0" & Hex(DaByte)
        Else
            OutputByte = Hex(DaByte)
        End If

        MakeProperByte = OutputByte

    End Function

End Module
