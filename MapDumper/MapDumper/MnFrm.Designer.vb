﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.Button4 = New System.Windows.Forms.Button()
        Me.ROMNameLabel = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.fileOpenDialog = New System.Windows.Forms.OpenFileDialog()
        Me.MapsAndBanks = New System.Windows.Forms.TreeView()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(424, 31)
        Me.Button4.Margin = New System.Windows.Forms.Padding(4)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(374, 72)
        Me.Button4.TabIndex = 11
        Me.Button4.Text = "Load ROM"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'ROMNameLabel
        '
        Me.ROMNameLabel.Location = New System.Drawing.Point(8, 31)
        Me.ROMNameLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.ROMNameLabel.Name = "ROMNameLabel"
        Me.ROMNameLabel.Size = New System.Drawing.Size(387, 33)
        Me.ROMNameLabel.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.ROMNameLabel)
        Me.GroupBox4.Location = New System.Drawing.Point(13, 25)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Size = New System.Drawing.Size(403, 78)
        Me.GroupBox4.TabIndex = 12
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Game Loaded"
        '
        'fileOpenDialog
        '
        Me.fileOpenDialog.FileName = "OpenFileDialog1"
        '
        'MapsAndBanks
        '
        Me.MapsAndBanks.Location = New System.Drawing.Point(13, 110)
        Me.MapsAndBanks.Name = "MapsAndBanks"
        Me.MapsAndBanks.Size = New System.Drawing.Size(242, 368)
        Me.MapsAndBanks.TabIndex = 13
        '
        'MnFrm
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(826, 490)
        Me.Controls.Add(Me.MapsAndBanks)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.GroupBox4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "MnFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Map Dumper"
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Button4 As Button
    Friend WithEvents ROMNameLabel As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents fileOpenDialog As OpenFileDialog
    Friend WithEvents MapsAndBanks As TreeView
End Class
