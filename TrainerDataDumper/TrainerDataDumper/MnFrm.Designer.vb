<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MnFrm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.fileOpenDialog = New System.Windows.Forms.OpenFileDialog()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(36, 40)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(281, 176)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Load ROM"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'fileOpenDialog
        '
        Me.fileOpenDialog.FileName = "OpenFileDialog1"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(365, 40)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(281, 176)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Dump Data"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'MnFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(678, 267)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "MnFrm"
        Me.Text = "Trainer Data Dumper"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents fileOpenDialog As OpenFileDialog
    Friend WithEvents Button2 As Button
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
End Class
