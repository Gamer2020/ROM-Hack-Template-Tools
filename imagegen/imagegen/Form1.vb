Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim OutputImg As New Bitmap(16, 64 * 16)

        Dim looper As Integer = 0

        While looper < 64

            BitmapBLT(GenPermissionTile(looper), OutputImg, 0, looper * 16, 0, 0, 16, 16)

            looper = looper + 1
        End While

        PictureBox1.Image = OutputImg

        PictureBox1.Height = OutputImg.Height * 2
        PictureBox1.Width = OutputImg.Width * 2

    End Sub

    Public Function GenPermissionTile(Text As String) As Bitmap

        Dim Permcolors As Color() = New Color(63) {}
        Permcolors(0) = Color.FromArgb(128, 0, 0, 0)
        Permcolors(1) = Color.FromArgb(128, 255, 0, 0)
        Permcolors(2) = Color.FromArgb(128, 0, 255, 0)
        Permcolors(3) = Color.FromArgb(128, 0, 0, 255)
        Permcolors(4) = Color.FromArgb(128, 255, 255, 0)
        Permcolors(5) = Color.FromArgb(128, 0, 255, 255)
        Permcolors(6) = Color.FromArgb(128, 255, 0, 255)
        Permcolors(7) = Color.FromArgb(128, 255, 255, 255)
        Permcolors(8) = Color.FromArgb(128, 128, 0, 0)
        Permcolors(9) = Color.FromArgb(128, 0, 128, 0)
        Permcolors(10) = Color.FromArgb(128, 0, 0, 128)
        Permcolors(11) = Color.FromArgb(128, 128, 128, 0)
        Permcolors(12) = Color.FromArgb(128, 0, 128, 128)
        Permcolors(13) = Color.FromArgb(128, 128, 0, 128)
        Permcolors(14) = Color.FromArgb(128, 128, 128, 128)
        Permcolors(15) = Color.FromArgb(128, 0, 0, 0)
        Permcolors(16) = Color.FromArgb(128, 255, 0, 0)
        Permcolors(17) = Color.FromArgb(128, 0, 255, 0)
        Permcolors(18) = Color.FromArgb(128, 0, 0, 255)
        Permcolors(19) = Color.FromArgb(128, 255, 255, 0)
        Permcolors(20) = Color.FromArgb(128, 0, 255, 255)
        Permcolors(21) = Color.FromArgb(128, 255, 0, 255)
        Permcolors(22) = Color.FromArgb(128, 255, 255, 255)
        Permcolors(23) = Color.FromArgb(128, 128, 0, 0)
        Permcolors(24) = Color.FromArgb(128, 0, 128, 0)
        Permcolors(25) = Color.FromArgb(128, 0, 0, 128)
        Permcolors(26) = Color.FromArgb(128, 128, 128, 0)
        Permcolors(27) = Color.FromArgb(128, 0, 128, 128)
        Permcolors(28) = Color.FromArgb(128, 128, 0, 128)
        Permcolors(29) = Color.FromArgb(128, 128, 128, 128)
        Permcolors(30) = Color.FromArgb(128, 0, 0, 0)
        Permcolors(31) = Color.FromArgb(128, 0, 0, 0)
        Permcolors(32) = Color.FromArgb(128, 0, 0, 0)
        Permcolors(33) = Color.FromArgb(128, 0, 0, 0)
        Permcolors(34) = Color.FromArgb(128, 0, 0, 0)
        Permcolors(35) = Color.FromArgb(128, 0, 0, 0)
        Permcolors(36) = Color.FromArgb(128, 0, 0, 0)
        Permcolors(37) = Color.FromArgb(128, 0, 0, 0)
        Permcolors(38) = Color.FromArgb(128, 0, 0, 0)
        Permcolors(39) = Color.FromArgb(128, 0, 0, 0)
        Permcolors(40) = Color.FromArgb(128, 0, 0, 0)
        Permcolors(41) = Color.FromArgb(128, 0, 0, 0)
        Permcolors(42) = Color.FromArgb(128, 0, 0, 0)
        Permcolors(43) = Color.FromArgb(128, 0, 0, 0)
        Permcolors(44) = Color.FromArgb(128, 0, 0, 0)
        Permcolors(45) = Color.FromArgb(128, 0, 0, 0)
        Permcolors(46) = Color.FromArgb(128, 0, 0, 0)
        Permcolors(47) = Color.FromArgb(128, 0, 0, 0)
        Permcolors(48) = Color.FromArgb(128, 0, 0, 0)
        Permcolors(49) = Color.FromArgb(128, 0, 0, 0)
        Permcolors(50) = Color.FromArgb(128, 0, 0, 0)
        Permcolors(51) = Color.FromArgb(128, 0, 0, 0)
        Permcolors(52) = Color.FromArgb(128, 0, 0, 0)
        Permcolors(53) = Color.FromArgb(128, 0, 0, 0)
        Permcolors(54) = Color.FromArgb(128, 0, 0, 0)
        Permcolors(55) = Color.FromArgb(128, 0, 0, 0)
        Permcolors(56) = Color.FromArgb(128, 0, 0, 0)
        Permcolors(57) = Color.FromArgb(128, 0, 0, 0)
        Permcolors(58) = Color.FromArgb(128, 0, 0, 0)
        Permcolors(59) = Color.FromArgb(128, 0, 0, 0)
        Permcolors(60) = Color.FromArgb(128, 0, 0, 0)
        Permcolors(61) = Color.FromArgb(128, 0, 0, 0)
        Permcolors(62) = Color.FromArgb(128, 0, 0, 0)
        Permcolors(63) = Color.FromArgb(128, 0, 0, 0)

        Dim FontColor As Color = Color.FromArgb(128, 0, 0, 0)

        Dim BackColor As Color = Permcolors(Text)

        Dim FontName As String = "Impact"

        Dim FontSize As Integer = 8

        Dim Height As Integer = 16

        Dim Width As Integer = 16

        Dim objBitmap As New Bitmap(Width, Height)
        Dim objGraphics As Graphics = Graphics.FromImage(objBitmap)

        Dim objFont As New Font(FontName, FontSize)

        'Following PointF object defines where the text will be displayed in the

        'specified area of the image
        Dim objPoint As New Point(2, 0)

        If Text < 16 Then
            objPoint = New Point(4, 0)
        End If

        Dim objBrushForeColor As New SolidBrush(FontColor)

        Dim objBrushBackColor As New SolidBrush(BackColor)

        objGraphics.FillRectangle(objBrushBackColor, 0, 0, Width, Height)

        objGraphics.DrawString(Hex(Text), objFont, objBrushForeColor, objPoint)

        Return objBitmap

    End Function

    Public Sub BitmapBLT(ByRef srcBitmap As Bitmap, ByRef destBitmap As Bitmap, ByVal destX As Integer, ByVal destY As Integer, ByVal srcX As Integer, ByVal srcY As Integer, ByVal width As Integer, ByVal height As Integer)
        Dim num As Integer = 0
        Dim i As Integer = 0
        Do While (num < width)
            Do While (i < height)
                If ((((((((((srcX + num) >= 0) And ((srcY + i) >= 0)) And ((destX + num) >= 0)) And ((destY + i) >= 0)) And ((srcX + num) < srcBitmap.Width)) And ((srcY + i) < srcBitmap.Height)) And ((destX + num) < destBitmap.Width)) And ((destY + i) < destBitmap.Height)) AndAlso (srcBitmap.GetPixel((srcX + num), (srcY + i)).A >= &H80)) Then
                    destBitmap.SetPixel((destX + num), (destY + i), srcBitmap.GetPixel((srcX + num), (srcY + i)))
                End If
                i += 1
            Loop
            num += 1
            i = 0
        Loop
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
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

            PictureBox1.Image.Save(SaveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png)

        End If

    End Sub
End Class
