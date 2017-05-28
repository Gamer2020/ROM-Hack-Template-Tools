
Imports System.Collections.Generic
Imports System.Text
Imports System.IO
Imports System.Runtime.InteropServices

Namespace Nintenlord.UPSpatcher
    Public Class UPSfile
        Private m_validPatch As Boolean
        Public ReadOnly Property ValidPatch() As Boolean
            Get
                Return m_validPatch
            End Get
        End Property
        Private originalFileCRC32 As UInteger
        Private newFileCRC32 As UInteger
        Private patchCRC32 As UInteger
        Private oldFileSize As ULong
        Private newFileSize As ULong
        Private changedOffsets As ULong()
        Private XORbytes As Byte()()

        'Public Sub New(filePath As String)
        '    Dim changedOffsetsList As New List(Of ULong)()
        '    Dim XORbytesList As New List(Of Byte())()

        '    m_validPatch = False
        '    If Not File.Exists(filePath) Then
        '        Return
        '    End If
        '    Dim UPSfile As Byte()
        '    Try
        '        Dim br As New BinaryReader(File.Open(filePath, FileMode.Open))
        '        UPSfile = br.ReadBytes(CInt(br.BaseStream.Length))
        '        br.Close()
        '    Catch generatedExceptionName As Exception
        '        Return
        '    End Try

        '    'header
        '    Dim currentPtr As Pointer(Of Byte) = UPSptr
        '    Dim header As New String(CType(currentPtr, Pointer(Of SByte)), 0, 4, Encoding.ASCII)
        '    If header <> "UPS1" Then
        '        Return
        '    End If
        '    currentPtr += 4
        '    oldFileSize = Decrypt(New Pointer(Of Byte*)(currentPtr))
        '    newFileSize = Decrypt(New Pointer(Of Byte*)(currentPtr))

        '    'body
        '    Dim filePosition As ULong = 0
        '    While currentPtr - UPSptr + 1 < UPSfile.Length - 12
        '        filePosition += Decrypt(New Pointer(Of Byte*)(currentPtr))
        '        changedOffsetsList.Add(filePosition)
        '        Dim newXORdata As New List(Of Byte)()

        '        While currentPtr.Target <> 0
        '            newXORdata.Add((System.Math.Max(System.Threading.Interlocked.Increment(currentPtr), currentPtr - 1)).Target)
        '        End While
        '        XORbytesList.Add(newXORdata.ToArray())
        '        filePosition += CULng(newXORdata.Count) + 1
        '        currentPtr += 1
        '    End While

        '    'end
        '    originalFileCRC32 = CType(currentPtr, Pointer(Of UInteger)).Target
        '    newFileCRC32 = CType(currentPtr + 4, Pointer(Of UInteger)).Target
        '    patchCRC32 = CType(currentPtr + 8, Pointer(Of UInteger)).Target



        '    changedOffsets = changedOffsetsList.ToArray()
        '    XORbytes = XORbytesList.ToArray()

        '    If patchCRC32 <> calculatePatchCRC32() Then
        '        Return
        '    End If

        '    m_validPatch = True
        'End Sub

        Public Sub New(originalFile As Byte(), newFile As Byte())
            Dim changedOffsetsList As New List(Of ULong)()
            Dim XORbytesList As New List(Of Byte())()
            m_validPatch = True
            oldFileSize = CULng(originalFile.Length)
            newFileSize = CULng(newFile.Length)

            Dim maxSize As ULong
            If oldFileSize > newFileSize Then
                maxSize = oldFileSize
            Else
                maxSize = newFileSize
            End If

            For i As ULong = 0 To maxSize - 1
                Dim x As Byte = If(i < oldFileSize, originalFile(i), CByte(&H0))
                Dim y As Byte = If(i < newFileSize, newFile(i), CByte(&H0))

                If x <> y Then
                    changedOffsetsList.Add(CULng(i))
                    Dim newXORbytes As New List(Of Byte)()
                    While x <> y AndAlso i < maxSize
                        newXORbytes.Add(CByte(x Xor y))
                        i += 1
                        x = If(i < oldFileSize, originalFile(i), CByte(&H0))
                        y = If(i < newFileSize, newFile(i), CByte(&H0))
                    End While
                    XORbytesList.Add(newXORbytes.ToArray())
                End If
            Next
            originalFileCRC32 = CRC32.crc32_calculate(originalFile)
            newFileCRC32 = CRC32.crc32_calculate(newFile)
            changedOffsets = changedOffsetsList.ToArray()
            XORbytes = XORbytesList.ToArray()
            patchCRC32 = calculatePatchCRC32()
        End Sub

        Private Shared Function Encrypt(offset As ULong) As Byte()
            Dim bytes As New List(Of Byte)(8)

            Dim x As ULong = offset And &H7F
            offset >>= 7
            While offset <> 0
                bytes.Add(CByte(x))
                offset -= 1
                x = offset And &H7F
                offset >>= 7
            End While
            bytes.Add(CByte(&H80 Or x))
            Return bytes.ToArray()
        End Function

        'Private Shared Function Decrypt(pointer As Pointer(Of Pointer(Of Byte))) As ULong
        '    Dim value As ULong = 0
        '    Dim shift As Integer = 1
        '    Dim x As Byte = (System.Math.Max(System.Threading.Interlocked.Increment((pointer.Target)), (pointer.Target) - 1)).Target
        '    value += CULng((x And &H7F) * shift)
        '    While (x And &H80) = 0
        '        shift <<= 7
        '        value += CULng(shift)
        '        x = (System.Math.Max(System.Threading.Interlocked.Increment((pointer.Target)), (pointer.Target) - 1)).Target
        '        value += CULng((x And &H7F) * shift)
        '    End While
        '    Return value
        'End Function

        Private Function calculatePatchCRC32() As UInteger
            Return CRC32.crc32_calculate(ToBinary())
        End Function

        Public Function ValidToApply(file As Byte()) As Boolean
            Dim fileCRC32 As UInteger = CRC32.crc32_calculate(file)
            Dim fitsAsOld As Boolean = oldFileSize = CULng(file.Length) AndAlso fileCRC32 = originalFileCRC32
            Dim fitsAsNew As Boolean = newFileSize = CULng(file.Length) AndAlso fileCRC32 = newFileCRC32

            Return m_validPatch AndAlso (fitsAsOld OrElse fitsAsNew)
        End Function

        'Public Function Apply(file As Byte()) As Byte()
        '    Dim lenght As ULong = CULng(file.LongLength)
        '    If lenght < newFileSize Then
        '        lenght = newFileSize
        '    End If

        '    Dim result As Byte() = New Byte(lenght - 1) {}


        '    Marshal.Copy(file, 0, New IntPtr(resultPtr), Math.Min(file.Length, result.Length))
        '    'int index = file.Length;
        '    'while (index < result.Length)
        '    '    resultPtr[index++] = 0;

        '    For i As Integer = 0 To changedOffsets.LongLength - 1
        '        For u As ULong = 0 To CULng(XORbytes(i).LongLength) - 1
        '            resultPtr(changedOffsets(i) + u) = resultPtr(changedOffsets(i) + u) Xor XORbytes(i)(u)
        '        Next
        '    Next

        '    Return result
        'End Function

        'Public Function Apply(path As String) As Byte()
        '    If Not m_validPatch OrElse Not File.Exists(path) Then
        '        Return Nothing
        '    End If

        '    Dim br As New BinaryReader(File.Open(path, FileMode.Open))
        '    Dim file__1 As Byte() = br.ReadBytes(CInt(br.BaseStream.Length))
        '    br.Close()
        '    Return Apply(file__1)
        'End Function

        Private Function ToBinary() As Byte()
            Dim file As New List(Of Byte)()
            file.Add(Convert.ToByte("U"c))
            file.Add(Convert.ToByte("P"c))
            file.Add(Convert.ToByte("S"c))
            file.Add(Convert.ToByte("1"c))
            file.AddRange(Encrypt(oldFileSize))
            file.AddRange(Encrypt(newFileSize))

            For i As Integer = 0 To changedOffsets.LongLength - 1
                Dim relativeOffset As ULong = changedOffsets(i)
                If i <> 0 Then
                    relativeOffset -= changedOffsets(i - 1) + CULng(XORbytes(i - 1).Length) + 1
                End If

                file.AddRange(Encrypt(relativeOffset))
                file.AddRange(XORbytes(i))
                file.Add(0)
            Next

            file.AddRange(BitConverter.GetBytes(originalFileCRC32))
            file.AddRange(BitConverter.GetBytes(newFileCRC32))

            Return file.ToArray()
        End Function

        Public Sub writeToFile(path As String)
            Dim bw As New BinaryWriter(File.Open(path, FileMode.Create))
            Dim file__1 As Byte() = ToBinary()
            bw.Write(file__1)
            bw.Write(CRC32.crc32_calculate(file__1))
            bw.Close()
        End Sub

        Public Function getData() As Integer(,)
            Dim result As Integer(,) = New Integer(changedOffsets.Length - 1, 1) {}
            For i As Integer = 0 To changedOffsets.Length - 1
                result(i, 0) = CInt(changedOffsets(i))
                result(i, 1) = XORbytes(i).Length
            Next
            Return result
        End Function
    End Class

End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
