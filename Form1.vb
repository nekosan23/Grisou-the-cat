Imports System.Threading.Thread
Public Class MainWin
    Public GrisouHealth, PlayerHealth, GrisouRoundDefense, PlayerRoundDefense As Integer
    Public GameState As Boolean
    Public GrisouTextA, PlayerTextA As String
    Public Sub Startup(sender As Object, e As EventArgs) Handles MyBase.Load
        GrisouHealth = 50
        PlayerHealth = 50
        'Setting up Grisou 
        GrisouHealthBar.Value = GrisouHealth
        GrisouText1.Text = "Grisou"
        GrisouText2.Text = GrisouHealth.ToString + " / 50"
        GrisouTextA = "Grisou Turn !"
        'Setting up Player
        PlayerHealthBar.Value = PlayerHealth
        PlayerText1.Text = "Sam"
        PlayerText2.Text = PlayerHealth.ToString + " / 50"
        PlayerTextA = "Player turn !"
        AnnouncerPanel.Visible = False
        AnnouncerText.Visible = False
        GameState = True
        'Round()
    End Sub
    'Round system need to be active at any time or else game break
    Public Sub Round()
        Dim TurnValue As Integer
        If (GameState = True) Then
            'Game Just Got started

            'Rolling dice who's starting
            TurnValue = GetRandom(1, 2)
        ElseIf (GameState = False) Then
            'Game Already Started

            'if this get called it mean the person did his turn so let change the value
            If (TurnValue = 1) Then
                TurnValue = 2
            ElseIf (TurnValue = 2) Then
                TurnValue = 1
            End If
        Else
                MsgBox("GameState is not found")
        End If
        'Checking who's turn it is
        If (TurnValue = 1) Then
            'player is starting
            PlayerAction1.Enabled = True
            PlayerAction2.Enabled = True
            PlayerAction3.Enabled = True
            Announcer(PlayerTextA)
        ElseIf (TurnValue = 2) Then
            'Grisou is starting
            PlayerAction1.Enabled = False
            PlayerAction2.Enabled = False
            PlayerAction3.Enabled = False
            Announcer(GrisouTextA)
        End If
    End Sub
    'Grisou AI yes we made a cat intelligent
    Public Sub GrisouAI()

    End Sub

    'attack system cast at every attack never forget to mention the user casting
    Public Sub Attack(ByVal user As Integer)
        'setting up variable
        Static Dim AttackLevel As Integer
        Static Dim AttackLow = New Integer() {1, 2, 3, 4}
        Static Dim AttackMedium = New Integer() {7, 9, 11, 13}
        Static Dim AttackHigh = New Integer() {16, 17, 19, 20}
        Static Dim Container1 As Integer
        AttackLevel = GetRandom(1, 4)
        Select Case AttackLevel
            Case 1
                'Hit or miss i guess they never miss humm
                If (user = 1) Then
                    Announcer("Your attack missed")
                Else
                    Announcer("Grisou attack missed")
                End If
            Case 2
                'Low
                Container1 = GetRandom(1, 4)
                If (user = 1) Then
                    Announcer("Your attack did " + AttackLow(Container1) + " damage")
                    DataProcess(2, "Attack", AttackLow(Container1))
                Else
                    Announcer("Grisou attack did " + AttackLow(Container1) + " damage")
                    DataProcess(1, "Attack", AttackLow(Container1))
                End If
            Case 3
                'Medium
                Container1 = GetRandom(1, 4)
                If (user = 1) Then
                    Announcer("Your attack did " + AttackMedium(Container1) + " damage")
                    DataProcess(2, "Attack", AttackMedium(Container1))
                Else
                    Announcer("Grisou attack did " + AttackMedium(Container1) + " damage")
                    DataProcess(1, "Attack", AttackMedium(Container1))
                End If
            Case 4
                'High
                Container1 = GetRandom(1, 4)
                If (user = 1) Then
                    Announcer("Your attack did " + AttackHigh(Container1) + " damage")
                    DataProcess(2, "Attack", AttackHigh(Container1))
                Else
                    Announcer("Grisou attack did " + AttackHigh(Container1) + " damage")
                    DataProcess(1, "Attack", AttackHigh(Container1))
                End If
        End Select
    End Sub
    'Defense System cast every defense never forget to mention the user casting
    Public Sub Defense(ByVal user As Integer)
        Static Dim Defense = New Integer() {6, 8, 12, 14}
        Static Dim Container1 As Integer
        Container1 = GetRandom(1, 4)
        If (user = 1) Then
            Announcer("You casted defense and got " + Defense(Container1) + " defense for this turn")
            DataProcess(1, "Defense", Defense(Container1))
        Else
            Announcer("Grisou casted defense and got " + Defense(Container1) + " defense for this turn")
            DataProcess(2, "Defense", Defense(Container1))
        End If
    End Sub
    'Recovery System cast every recovery never forget to mention the user casting
    Public Sub Recovery(ByVal user As Integer)
        Static Dim Recovery = New Integer() {5, 10, 15, 18}
        Static Dim container1 As Integer
        container1 = GetRandom(1, 4)
        If (user = 1) Then
            Announcer("You casted recovery and recovered " + Recovery(container1) + " HP")
            DataProcess(1, "Recovery", Recovery(container1))
        Else
            Announcer("Grisou casted recovery and recovered " + Recovery(container1) + " HP")
            DataProcess(2, "Recovery", Recovery(container1))
        End If
    End Sub
    'Data Processer
    'target list    1 player    2 grisou
    'DataType   Attack  Defense  Recovery
    Public Sub DataProcess(ByVal Target As Integer, ByVal DataType As String, ByVal DataValue As Integer)

    End Sub
    'Announcer
    Public Sub Announcer(text As String) '294
        Dim animationcountdown As Integer = -490
        AnnouncerText.Text = text
        AnnouncerText.Visible = True
        AnnouncerPanel.Visible = True
        Do
            AnnouncerPanel.Location = New Point(animationcountdown, 292)
            animationcountdown += 10
            Sleep(10)
        Loop Until animationcountdown = 10
        AnnouncerText.Refresh()
        Sleep(3000)
        AnnouncerText.Visible = False
        AnnouncerPanel.Visible = False
    End Sub
    'Random Generator for integer
    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Static Generator As System.Random = New System.Random
        Return Generator.Next(Min, Max)
    End Function
    Private Sub PlayerAttackClick(sender As Object, e As EventArgs) Handles PlayerAction1.Click
        'PlayerAction1.Enabled = False
        'PlayerAction2.Enabled = False
        'PlayerAction3.Enabled = False
        'Attack(1)
    End Sub
    Private Sub PlayerDefenseClick(sender As Object, e As EventArgs) Handles PlayerAction2.Click
        PlayerAction1.Enabled = False
        PlayerAction2.Enabled = False
        PlayerAction3.Enabled = False
        'defense(1)
    End Sub
    Private Sub PlayerRecoverClick(sender As Object, e As EventArgs) Handles PlayerAction3.Click
        PlayerAction1.Enabled = False
        PlayerAction2.Enabled = False
        PlayerAction3.Enabled = False
        'recover(1)
    End Sub
End Class
