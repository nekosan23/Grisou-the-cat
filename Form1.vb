Imports System.Threading.Thread
Public Class MainWin
    Public GrisouHealth, PlayerHealth, PlayerRoundDefense As Integer
    Public GameState As Boolean
    Public GrisouTextA, PlayerTextA As String
    Public Sub Startup(sender As Object, e As EventArgs) Handles MyBase.Load
        GrisouHealth = 50
        PlayerHealth = 50
        'Setting up Grisou text
        GrisouHealthBar.Value = GrisouHealth
        GrisouText1.Text = "Grisou"
        GrisouText2.Text = GrisouHealth.ToString + " / 50"
        GrisouTextA = "Grisou Turn !"
        'Setting up Player text
        PlayerHealthBar.Value = PlayerHealth
        PlayerText1.Text = "Sam"
        PlayerText2.Text = PlayerHealth.ToString + " / 50"
        PlayerTextA = "Player turn !"
        AnnouncerPanel.Visible = False
        AnnouncerText.Visible = False
        GameState = True
        Round()
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
            EnablePlayerButton()
            Task.WaitAll(Announcer(PlayerTextA))
        ElseIf (TurnValue = 2) Then
            'Grisou is starting
            DisablePlayerButton()
            Task.WaitAll(Announcer(GrisouTextA))
            GrisouAI()
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
        Static Dim AttackMedium = New Integer() {7, 9, 11, 12}
        Static Dim AttackHigh = New Integer() {16, 17, 19, 20}
        Static Dim Container1 As Integer
        AttackLevel = GetRandom(1, 4)
        Select Case AttackLevel
            Case 1
                'Hit or miss i guess they never miss humm
                If (user = 1) Then
                    Task.WaitAll(Announcer("Your attack missed"))
                Else
                    Task.WaitAll(Announcer("Grisou attack missed"))
                End If
            Case 2
                'Low
                Container1 = GetRandom(1, 4)
                If (user = 1) Then
                    Task.WaitAll(Announcer("Your attack did " + AttackLow(Container1).ToString + " damage"))
                    DataProcess(2, "Attack", AttackLow(Container1))
                Else
                    Task.WaitAll(Announcer("Grisou attack did " + AttackLow(Container1).ToString + " damage"))
                    DataProcess(1, "Attack", AttackLow(Container1))
                End If
            Case 3
                'Medium
                Container1 = GetRandom(1, 4)
                If (user = 1) Then
                    Task.WaitAll(Announcer("Your attack did " + AttackMedium(Container1).ToString + " damage"))
                    DataProcess(2, "Attack", AttackMedium(Container1))
                Else
                    Task.WaitAll(Announcer("Grisou attack did " + AttackMedium(Container1).ToString + " damage"))
                    DataProcess(1, "Attack", AttackMedium(Container1))
                End If
            Case 4
                'High
                Container1 = GetRandom(1, 4)
                If (user = 1) Then
                    Task.WaitAll(Announcer("Your attack did " + AttackHigh(Container1).ToString + " damage"))
                    DataProcess(2, "Attack", AttackHigh(Container1))
                Else
                    Task.WaitAll(Announcer("Grisou attack did " + AttackHigh(Container1).ToString + " damage"))
                    DataProcess(1, "Attack", AttackHigh(Container1))
                End If
        End Select
    End Sub
    'Defense System cast every defense never forget to mention the user casting
    Public Sub Defense()
        Static Dim Defense = New Integer() {6, 8, 12, 13}
        Static Dim Container1 As Integer
        Container1 = GetRandom(1, 4)
        Task.WaitAll(Announcer("You casted defense and got " + Defense(Container1).ToString + " defense for this turn"))
        DataProcess(1, "Defense", Defense(Container1))
    End Sub
    'Recovery System cast every recovery never forget to mention the user casting
    Public Sub Recovery(ByVal user As Integer)
        Static Dim Recovery = New Integer() {5, 10, 15, 20}
        Static Dim container1 As Integer
        container1 = GetRandom(1, 4)
        If (user = 1) Then
            Task.WaitAll(Announcer("You casted recovery and recovered " + Recovery(container1).ToString + " HP"))
            DataProcess(1, "Recovery", Recovery(container1))
        Else
            Task.WaitAll(Announcer("Grisou casted recovery and recovered " + Recovery(container1).ToString + " HP"))
            DataProcess(2, "Recovery", Recovery(container1))
        End If
    End Sub
    'Data Processer
    'target list    1 player    2 grisou
    'DataType   Attack  Defense  Recovery
    Public Sub DataProcess(ByVal Target As Integer, ByVal DataType As String, ByVal DataValue As Integer)
        Static Dim Container1, Container2 As Integer
        Select Case DataType
            'Calculation for attack
            Case "Attack"
                'target player
                If (Target = 1) Then
                    Container1 = PlayerHealth - DataValue
                    'check if player died
                    If (Container1 <= 0) Then
                        'Game over
                        Gameover(1)
                    Else
                        'check the defense
                        If (PlayerRoundDefense < 0) Then
                            Container2 = DataValue - PlayerRoundDefense
                            'player has defense so calculation
                            If (Container2 >= 0) Then
                                'defense canceled the attack
                                Task.WaitAll(Announcer("Your defense was high enough to cancel grisou attack"))
                            Else
                                'player doesn't have enough defense
                                PlayerHealth -= Container2
                            End If
                        Else
                            'player has no defense
                            PlayerHealth -= DataValue
                        End If
                        'checking if life bar can be updated
                        If (PlayerHealth >= 50) Then
                            PlayerHealthBar.Value = PlayerHealth
                            PlayerText2.Text = PlayerHealth.ToString + " / 50"
                        End If
                    End If
                ElseIf (Target = 2) Then
                    Container1 = GrisouHealth - DataValue
                    'check if grisou died
                    If (Container1 <= 0) Then
                        'Game over
                        Gameover(1)
                    Else
                        'apply attack damage
                        GrisouHealth -= DataValue
                        'checking if life bar can be updated
                        If (GrisouHealth >= 50) Then
                            GrisouHealthBar.Value = GrisouHealth
                            GrisouText2.Text = GrisouHealth.ToString + " / 50"
                        End If
                    End If
                End If
            'calculation for defense
            Case "Defense"
                'Defense can only be casted by player but we're doing it to be safe
                If (Target = 1) Then
                    PlayerRoundDefense = 0
                    PlayerRoundDefense = DataValue
                Else
                    MsgBox("Grisou cannot have defense this must be a mistake in the code please contact the developer")
                End If
            Case "Recovery"
                'player casted recovery
                If (Target = 1) Then
                    PlayerHealth += DataValue
                    'checking if progressbar can be updated without Integer Overflow
                    If (PlayerHealth < 50) Then
                        PlayerHealthBar.Value = 50
                        PlayerText2.Text = PlayerHealth.ToString + " / 50"
                    Else
                        PlayerHealthBar.Value = PlayerHealth
                        PlayerText2.Text = PlayerHealth.ToString + " / 50"
                    End If
                    'grisou casted recovery
                ElseIf (Target = 2) Then
                    GrisouHealth += DataValue
                    'checking if progressbar can be updated without Integer Overflow
                    If (GrisouHealth < 50) Then
                        GrisouHealthBar.Value = 50
                        GrisouText2.Text = GrisouHealth.ToString + " / 50"
                    Else
                        GrisouHealthBar.Value = GrisouHealth
                        GrisouText2.Text = GrisouHealth.ToString + " / 50"
                    End If
                End If
        End Select
    End Sub
    'game over call this whenever somebody die
    Public Sub Gameover(ByVal user As Integer)
        If (user = 1) Then
            'Player failed
            DisablePlayerButton()
            Task.WaitAll(Announcer("You just died Game Over"))
        ElseIf (user = 2) Then
            EnablePlayerButton()
            Task.WaitAll(Announcer("Grisou just died you win !!"))
        End If
    End Sub
    'Announcer
    Public Async Function Announcer(text As String) As Task
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
    End Function
    'Random Generator for integer
    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Static Generator As System.Random = New System.Random
        Return Generator.Next(Min, Max)
    End Function
    Private Sub PlayerAttackClick(sender As Object, e As EventArgs) Handles PlayerAction1.Click
        DisablePlayerButton()
        Attack(1)
    End Sub
    Private Sub PlayerDefenseClick(sender As Object, e As EventArgs) Handles PlayerAction2.Click
        DisablePlayerButton()
        'defense(1)
    End Sub
    Private Sub PlayerRecoverClick(sender As Object, e As EventArgs) Handles PlayerAction3.Click
        DisablePlayerButton()
        'recover(1)
    End Sub
    'Below is fast code for saving space
    Public Sub DisablePlayerButton()
        PlayerAction1.Enabled = False
        PlayerAction2.Enabled = False
        PlayerAction3.Enabled = False
    End Sub
    Public Sub EnablePlayerButton()
        PlayerAction1.Enabled = True
        PlayerAction2.Enabled = True
        PlayerAction3.Enabled = True
    End Sub
End Class
