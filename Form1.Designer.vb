<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainWin
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
        Me.MainDisplay = New System.Windows.Forms.Panel()
        Me.AnnouncerPanel = New System.Windows.Forms.Panel()
        Me.AnnouncerText = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GrisouDefenseText = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GrisouHealthBar = New System.Windows.Forms.ProgressBar()
        Me.GrisouText2 = New System.Windows.Forms.Label()
        Me.GrisouText1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PlayerDefenseText = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PlayerHealthBar = New System.Windows.Forms.ProgressBar()
        Me.PlayerText2 = New System.Windows.Forms.Label()
        Me.PlayerText1 = New System.Windows.Forms.Label()
        Me.PlayerAction3 = New System.Windows.Forms.Button()
        Me.PlayerAction2 = New System.Windows.Forms.Button()
        Me.PlayerAction1 = New System.Windows.Forms.Button()
        Me.MainDisplay.SuspendLayout()
        Me.AnnouncerPanel.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainDisplay
        '
        Me.MainDisplay.BackgroundImage = Global.WindowsApp2.My.Resources.Resources.grisouporn
        Me.MainDisplay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.MainDisplay.Controls.Add(Me.AnnouncerPanel)
        Me.MainDisplay.Controls.Add(Me.Panel2)
        Me.MainDisplay.Controls.Add(Me.Panel1)
        Me.MainDisplay.Controls.Add(Me.PlayerAction3)
        Me.MainDisplay.Controls.Add(Me.PlayerAction2)
        Me.MainDisplay.Controls.Add(Me.PlayerAction1)
        Me.MainDisplay.Location = New System.Drawing.Point(0, 0)
        Me.MainDisplay.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MainDisplay.Name = "MainDisplay"
        Me.MainDisplay.Size = New System.Drawing.Size(480, 720)
        Me.MainDisplay.TabIndex = 0
        '
        'AnnouncerPanel
        '
        Me.AnnouncerPanel.BackColor = System.Drawing.SystemColors.ControlDark
        Me.AnnouncerPanel.Controls.Add(Me.AnnouncerText)
        Me.AnnouncerPanel.Location = New System.Drawing.Point(0, 292)
        Me.AnnouncerPanel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.AnnouncerPanel.Name = "AnnouncerPanel"
        Me.AnnouncerPanel.Size = New System.Drawing.Size(480, 50)
        Me.AnnouncerPanel.TabIndex = 6
        '
        'AnnouncerText
        '
        Me.AnnouncerText.AutoSize = True
        Me.AnnouncerText.Location = New System.Drawing.Point(12, 17)
        Me.AnnouncerText.Name = "AnnouncerText"
        Me.AnnouncerText.Size = New System.Drawing.Size(48, 16)
        Me.AnnouncerText.TabIndex = 0
        Me.AnnouncerText.Text = "Label1"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GrisouDefenseText)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.GrisouHealthBar)
        Me.Panel2.Controls.Add(Me.GrisouText2)
        Me.Panel2.Controls.Add(Me.GrisouText1)
        Me.Panel2.Location = New System.Drawing.Point(268, 12)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(200, 78)
        Me.Panel2.TabIndex = 4
        '
        'GrisouDefenseText
        '
        Me.GrisouDefenseText.AutoSize = True
        Me.GrisouDefenseText.Location = New System.Drawing.Point(69, 53)
        Me.GrisouDefenseText.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.GrisouDefenseText.Name = "GrisouDefenseText"
        Me.GrisouDefenseText.Size = New System.Drawing.Size(14, 16)
        Me.GrisouDefenseText.TabIndex = 4
        Me.GrisouDefenseText.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 53)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Defense : "
        '
        'GrisouHealthBar
        '
        Me.GrisouHealthBar.Location = New System.Drawing.Point(0, 27)
        Me.GrisouHealthBar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GrisouHealthBar.Maximum = 50
        Me.GrisouHealthBar.Name = "GrisouHealthBar"
        Me.GrisouHealthBar.Size = New System.Drawing.Size(200, 23)
        Me.GrisouHealthBar.Step = 0
        Me.GrisouHealthBar.TabIndex = 2
        '
        'GrisouText2
        '
        Me.GrisouText2.AutoSize = True
        Me.GrisouText2.Location = New System.Drawing.Point(147, 57)
        Me.GrisouText2.Name = "GrisouText2"
        Me.GrisouText2.Size = New System.Drawing.Size(0, 16)
        Me.GrisouText2.TabIndex = 1
        '
        'GrisouText1
        '
        Me.GrisouText1.AutoSize = True
        Me.GrisouText1.Location = New System.Drawing.Point(4, 2)
        Me.GrisouText1.Name = "GrisouText1"
        Me.GrisouText1.Size = New System.Drawing.Size(0, 16)
        Me.GrisouText1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PlayerDefenseText)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.PlayerHealthBar)
        Me.Panel1.Controls.Add(Me.PlayerText2)
        Me.Panel1.Controls.Add(Me.PlayerText1)
        Me.Panel1.Location = New System.Drawing.Point(12, 540)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 75)
        Me.Panel1.TabIndex = 3
        '
        'PlayerDefenseText
        '
        Me.PlayerDefenseText.AutoSize = True
        Me.PlayerDefenseText.Location = New System.Drawing.Point(68, 49)
        Me.PlayerDefenseText.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.PlayerDefenseText.Name = "PlayerDefenseText"
        Me.PlayerDefenseText.Size = New System.Drawing.Size(14, 16)
        Me.PlayerDefenseText.TabIndex = 5
        Me.PlayerDefenseText.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 49)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Defense : "
        '
        'PlayerHealthBar
        '
        Me.PlayerHealthBar.Location = New System.Drawing.Point(0, 23)
        Me.PlayerHealthBar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PlayerHealthBar.Maximum = 50
        Me.PlayerHealthBar.Name = "PlayerHealthBar"
        Me.PlayerHealthBar.Size = New System.Drawing.Size(200, 23)
        Me.PlayerHealthBar.TabIndex = 3
        '
        'PlayerText2
        '
        Me.PlayerText2.AutoSize = True
        Me.PlayerText2.Location = New System.Drawing.Point(147, 50)
        Me.PlayerText2.Name = "PlayerText2"
        Me.PlayerText2.Size = New System.Drawing.Size(0, 16)
        Me.PlayerText2.TabIndex = 2
        '
        'PlayerText1
        '
        Me.PlayerText1.AutoSize = True
        Me.PlayerText1.Location = New System.Drawing.Point(3, 2)
        Me.PlayerText1.Name = "PlayerText1"
        Me.PlayerText1.Size = New System.Drawing.Size(0, 16)
        Me.PlayerText1.TabIndex = 2
        '
        'PlayerAction3
        '
        Me.PlayerAction3.Enabled = False
        Me.PlayerAction3.Location = New System.Drawing.Point(325, 631)
        Me.PlayerAction3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PlayerAction3.Name = "PlayerAction3"
        Me.PlayerAction3.Size = New System.Drawing.Size(141, 78)
        Me.PlayerAction3.TabIndex = 2
        Me.PlayerAction3.Text = "Recover"
        Me.PlayerAction3.UseVisualStyleBackColor = True
        '
        'PlayerAction2
        '
        Me.PlayerAction2.Enabled = False
        Me.PlayerAction2.Location = New System.Drawing.Point(172, 631)
        Me.PlayerAction2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PlayerAction2.Name = "PlayerAction2"
        Me.PlayerAction2.Size = New System.Drawing.Size(148, 78)
        Me.PlayerAction2.TabIndex = 1
        Me.PlayerAction2.Text = "Defense"
        Me.PlayerAction2.UseVisualStyleBackColor = True
        '
        'PlayerAction1
        '
        Me.PlayerAction1.Location = New System.Drawing.Point(12, 631)
        Me.PlayerAction1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PlayerAction1.Name = "PlayerAction1"
        Me.PlayerAction1.Size = New System.Drawing.Size(155, 78)
        Me.PlayerAction1.TabIndex = 0
        Me.PlayerAction1.Text = "Attaque"
        Me.PlayerAction1.UseVisualStyleBackColor = True
        '
        'MainWin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(480, 720)
        Me.Controls.Add(Me.MainDisplay)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "MainWin"
        Me.Text = "Jeux de merde a sam"
        Me.MainDisplay.ResumeLayout(False)
        Me.AnnouncerPanel.ResumeLayout(False)
        Me.AnnouncerPanel.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MainDisplay As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PlayerAction3 As Button
    Friend WithEvents PlayerAction2 As Button
    Friend WithEvents PlayerAction1 As Button
    Friend WithEvents GrisouHealthBar As ProgressBar
    Friend WithEvents GrisouText2 As Label
    Friend WithEvents GrisouText1 As Label
    Friend WithEvents PlayerHealthBar As ProgressBar
    Friend WithEvents PlayerText2 As Label
    Friend WithEvents PlayerText1 As Label
    Friend WithEvents AnnouncerPanel As Panel
    Friend WithEvents AnnouncerText As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GrisouDefenseText As Label
    Friend WithEvents PlayerDefenseText As Label
End Class
