Public Class MnFrm
    Private Sub ConvertTextButton_Click(sender As Object, e As EventArgs) Handles ConvertTextButton.Click

        Dim texttoconvert As String
        Dim outputtext As String = ""
        Dim bytearray As Byte()

        texttoconvert = TextBoxBefore.Text

        bytearray = ConvertStringToByteArray(Asc2Sapp(Replace(texttoconvert, vbCrLf, "\n") & "\x"))

        Dim forloopbyte As Byte

        outputtext = outputtext & ".byte"

        For Each forloopbyte In bytearray
            outputtext = outputtext & " 0x" & MakeProperByte(forloopbyte) & ","
        Next

        TextBoxAfter.Text = outputtext & " 0x20, 0x20" & vbCrLf & "@" & TextBoxBefore.Text
    End Sub
End Class
