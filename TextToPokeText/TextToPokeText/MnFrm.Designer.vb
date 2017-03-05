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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MnFrm))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.TextBoxBefore = New System.Windows.Forms.TextBox()
        Me.TextBoxAfter = New System.Windows.Forms.TextBox()
        Me.ConvertTextButton = New System.Windows.Forms.ToolStripButton()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBoxBefore)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ToolStrip1)
        Me.SplitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TextBoxAfter)
        Me.SplitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SplitContainer1.Size = New System.Drawing.Size(833, 440)
        Me.SplitContainer1.SplitterDistance = 253
        Me.SplitContainer1.SplitterWidth = 8
        Me.SplitContainer1.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConvertTextButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 226)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(833, 27)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TextBoxBefore
        '
        Me.TextBoxBefore.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxBefore.Location = New System.Drawing.Point(0, 0)
        Me.TextBoxBefore.Multiline = True
        Me.TextBoxBefore.Name = "TextBoxBefore"
        Me.TextBoxBefore.Size = New System.Drawing.Size(833, 226)
        Me.TextBoxBefore.TabIndex = 1
        '
        'TextBoxAfter
        '
        Me.TextBoxAfter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxAfter.Location = New System.Drawing.Point(0, 0)
        Me.TextBoxAfter.Multiline = True
        Me.TextBoxAfter.Name = "TextBoxAfter"
        Me.TextBoxAfter.Size = New System.Drawing.Size(833, 179)
        Me.TextBoxAfter.TabIndex = 2
        '
        'ConvertTextButton
        '
        Me.ConvertTextButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ConvertTextButton.Image = CType(resources.GetObject("ConvertTextButton.Image"), System.Drawing.Image)
        Me.ConvertTextButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ConvertTextButton.Name = "ConvertTextButton"
        Me.ConvertTextButton.Size = New System.Drawing.Size(121, 24)
        Me.ConvertTextButton.Text = "V Convert Text V"
        '
        'MnFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(833, 440)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "MnFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Text To PokeText"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents TextBoxBefore As TextBox
    Friend WithEvents TextBoxAfter As TextBox
    Friend WithEvents ConvertTextButton As ToolStripButton
End Class
