<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class InterfaceWindow
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.DataBox = New System.Windows.Forms.TextBox()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuBar = New System.Windows.Forms.MenuStrip()
        Me.ProgramMainMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.InformationMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuitMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileMainMenuSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.FileMainMenuSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuBar.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataBox
        '
        Me.DataBox.AllowDrop = True
        Me.DataBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataBox.BackColor = System.Drawing.SystemColors.Window
        Me.DataBox.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataBox.Location = New System.Drawing.Point(2, 27)
        Me.DataBox.Multiline = True
        Me.DataBox.Name = "DataBox"
        Me.DataBox.ReadOnly = True
        Me.DataBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataBox.Size = New System.Drawing.Size(584, 341)
        Me.DataBox.TabIndex = 3
        '
        'MenuBar
        '
        Me.MenuBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProgramMainMenu})
        Me.MenuBar.Location = New System.Drawing.Point(0, 0)
        Me.MenuBar.Name = "MenuBar"
        Me.MenuBar.Size = New System.Drawing.Size(586, 24)
        Me.MenuBar.TabIndex = 4
        Me.MenuBar.Text = "MenuBar"
        '
        'ProgramMainMenu
        '
        Me.ProgramMainMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenFileMenu, Me.FileMainMenuSeparator1, Me.InformationMenu, Me.FileMainMenuSeparator2, Me.QuitMenu})
        Me.ProgramMainMenu.Name = "ProgramMainMenu"
        Me.ProgramMainMenu.Size = New System.Drawing.Size(65, 20)
        Me.ProgramMainMenu.Text = "&Program"
        '
        'OpenFileMenu
        '
        Me.OpenFileMenu.Name = "OpenFileMenu"
        Me.OpenFileMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OpenFileMenu.Size = New System.Drawing.Size(180, 22)
        Me.OpenFileMenu.Text = "&Open File"
        '
        'InformationMenu
        '
        Me.InformationMenu.Name = "InformationMenu"
        Me.InformationMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys)
        Me.InformationMenu.Size = New System.Drawing.Size(180, 22)
        Me.InformationMenu.Text = "&Information"
        '
        'QuitMenu
        '
        Me.QuitMenu.Name = "QuitMenu"
        Me.QuitMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Q), System.Windows.Forms.Keys)
        Me.QuitMenu.Size = New System.Drawing.Size(180, 22)
        Me.QuitMenu.Text = "&Quit"
        '
        'FileMainMenuSeparator1
        '
        Me.FileMainMenuSeparator1.Name = "FileMainMenuSeparator1"
        Me.FileMainMenuSeparator1.Size = New System.Drawing.Size(177, 6)
        '
        'FileMainMenuSeparator2
        '
        Me.FileMainMenuSeparator2.Name = "FileMainMenuSeparator2"
        Me.FileMainMenuSeparator2.Size = New System.Drawing.Size(177, 6)
        '
        'InterfaceWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(586, 365)
        Me.Controls.Add(Me.DataBox)
        Me.Controls.Add(Me.MenuBar)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuBar
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "InterfaceWindow"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.MenuBar.ResumeLayout(False)
        Me.MenuBar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataBox As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents MenuBar As System.Windows.Forms.MenuStrip
    Friend WithEvents ProgramMainMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InformationMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents QuitMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileMainMenuSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FileMainMenuSeparator2 As System.Windows.Forms.ToolStripSeparator
End Class
