Imports System.Threading.Thread
Public Class MainWin
    Public GrisouHealth, PlayerHealth, PlayerDefense, GrisouDefense As Integer
    Public GameState As Boolean
    Public GrisouTextA, PlayerTextA As String
    Public TurnValue As Integer
    Public Sub Startup(sender As Object, e As EventArgs) Handles MyBase.Load
        PlayerHealth = 50 : GrisouHealth = 50 : PlayerDefense = 0 : GrisouDefense = 0
        'Setting up Grisou text
        GrisouHealthBar.Value = GrisouHealth : GrisouText1.Text = "Grisou" : GrisouText2.Text = GrisouHealth.ToString + " / 50" : GrisouDefenseText.Text = GrisouDefense.ToString : GrisouTextA = "Grisou Turn !"
        'Setting up Player text
        PlayerHealthBar.Value = PlayerHealth : PlayerText1.Text = "Master" : PlayerText2.Text = PlayerHealth.ToString + " / 50" : PlayerDefenseText.Text = PlayerDefense.ToString : PlayerTextA = "Master turn !"
        AnnouncerPanel.Visible = False : AnnouncerText.Visible = False
        GameState = True
        Round()
    End Sub
    'Round system need to be active at any time or else game break
    Public Sub Round()
        Select Case GameState
            Case True 'first time playing
                TurnValue = GetRandom(1, 2)
                Select Case TurnValue
                    Case 1
                        'player is starting
                        EnablePlayerButton()
                        Task.WaitAll(Announcer(PlayerTextA)) : Console.WriteLine("first game announcer")
                    Case 2
                        'Grisou is starting
                        DisablePlayerButton()
                        Task.WaitAll(Announcer(GrisouTextA)) : Console.WriteLine("grisou turn")
                        GrisouAI()
                End Select
            Case False 'game already started
                If (TurnValue = 1) Then
                    TurnValue = 2
                ElseIf (TurnValue = 2) Then
                    TurnValue = 1
                End If
                If (TurnValue = 1) Then 'Checking who's turn it is
                    'player is starting
                    EnablePlayerButton()
                    Task.WaitAll(Announcer(PlayerTextA)) : Console.WriteLine("second game announcer")
                ElseIf (TurnValue = 2) Then
                    'Grisou is starting
                    DisablePlayerButton()
                    Task.WaitAll(Announcer(GrisouTextA))
                    GrisouAI()
                End If
        End Select
    End Sub
    'Grisou AI yes we made a cat intelligent
    Public Sub GrisouAI()
        Dim LastChoice As Integer 'last choice so she cannot spam
        Static Dim Choice As Integer ' current choice
        Choice = GetRandom(1, 3)
        If (Choice = LastChoice) Then 'if she chose the same cancel
            GrisouAI()
        ElseIf (LastChoice = Nothing) Then ' if she never played before
            Select Case Choice 'check grisou choice
                Case 1 'grisou chose attack
                    LastChoice = Choice
                    GameEngine(2, 1, "A")
                Case 2 'grisou chose defense
                    LastChoice = Choice
                    GameEngine(2, 1, "D")
                Case 3 ' grisou chose recovery
                    LastChoice = Choice
                    GameEngine(2, 1, "R")
            End Select
        Else 'if the choice is not her first turn and not the same
            Select Case Choice 'check grisou choice
                Case 1 'grisou chose attack
                    LastChoice = Choice
                    GameEngine(2, 1, "A")
                Case 2 'grisou chose defense
                    LastChoice = Choice
                    GameEngine(2, 1, "D")
                Case 3 ' grisou chose recovery
                    LastChoice = Choice
                    GameEngine(2, 1, "R")
            End Select
        End If
    End Sub
    'New Processing Script
    'Caster 1= player  2=Grisou
    'Target 1= player  2=Grisou
    'TypeOfAttack A = Attack  D = Defense  R= Recovery
    Public Sub GameEngine(ByVal Caster As Integer, ByVal Target As Integer, ByVal TypeOfAttack As String)
        'setting variable for attack
        Static Dim Container1 As Integer
        Static Dim AttackLow = New Integer() {1, 2, 3, 4}
        Static Dim AttackMedium = New Integer() {7, 9, 11, 12}
        Static Dim AttackHigh = New Integer() {16, 17, 19, 20}
        'setting variable for defense
        Static Dim Defense = New Integer() {6, 8, 12, 13}
        'setting variable for recovery
        Static Dim Recovery = New Integer() {5, 10, 15, 18}
        Select Case TypeOfAttack
            Case "A" 'Attack script
                Container1 = GetRandom(1, 4) 'get attack failed , low , medium , high
                Select Case Container1 'check Attack strengh
                    Case 1 'missed
                        If (Target = 1) Then 'Grisou missed
                            DataProcessor(1, 0, "A")
                        Else 'player missed
                            DataProcessor(2, 0, "A")
                        End If
                    Case 2 'Low hit
                        Container1 = GetRandom(1, 4)
                        If (Target = 1) Then 'Grisou attack low
                            DataProcessor(1, AttackLow(Container1), "A")
                        Else 'player attack low
                            DataProcessor(2, AttackLow(Container1), "A")
                        End If
                    Case 3 'Medium hit
                        Container1 = GetRandom(1, 4)
                        If (Target = 1) Then 'Grisou attack medium
                            DataProcessor(1, AttackMedium(Container1), "A")
                        Else 'player attack medium
                            DataProcessor(2, AttackMedium(Container1), "A")
                        End If
                    Case 4 'high hit
                        Container1 = GetRandom(1, 4)
                        If (Target = 1) Then 'Grisou attack high
                            DataProcessor(1, AttackHigh(Container1), "A")
                        Else 'player attack high
                            DataProcessor(2, AttackHigh(Container1), "A")
                        End If
                End Select
            Case "D" 'Defense script
                Container1 = GetRandom(1, 4) ' get defense amount
                Select Case Caster
                    Case "1" 'player casted defense
                        DataProcessor(1, Defense(Container1), "D")
                    Case "2" 'grisou casted defense
                        DataProcessor(2, Defense(Container1), "D")
                End Select
            Case "R" 'Recovery script
                Container1 = GetRandom(1, 4) 'get recovery amount
                Select Case Caster
                    Case "1" 'player casted recovery
                        DataProcessor("1", Recovery(Container1), "R")
                    Case "2" ' grisou casted recovery
                        DataProcessor("2", Recovery(Container1), "R")
                End Select
        End Select

    End Sub
    'process Value
    'don't forget to ship target, value, type of attack
    Public Sub DataProcessor(ByVal Target As Integer, ByVal Amount As Integer, ByVal Type As String)
        Static Dim container1 As Integer 'contain advance math result
        Select Case Target
            Case 1 'target player
                Select Case Type

                    Case "A" 'grisou attack player
                        If (Amount = 0) Then 'check if missed
                            Task.WaitAll(Announcer(My.Settings.GAM1.ToString))
                            GameUpdate()
                        Else
                            Select Case PlayerDefense ' checking defense
                                Case >= Amount ' defense is higher then attack
                                    Task.WaitAll(Announcer(My.Settings.PDH1.ToString))
                                    GameUpdate()
                                Case < Amount 'defense is there but lower
                                    container1 = Amount - PlayerDefense
                                    PlayerHealth -= container1
                                    Task.WaitAll(Announcer(My.Settings.PDL1.ToString + container1.ToString + My.Settings.DAM.ToString))
                                    GameUpdate()
                                Case = 0 'no defense
                                    PlayerHealth -= Amount
                                    Task.WaitAll(Announcer(My.Settings.GA1.ToString + Amount.ToString + My.Settings.DAM.ToString))
                                    GameUpdate()
                            End Select
                        End If
                    Case "D" 'player Casted Defense
                        PlayerDefense += Amount
                        Task.WaitAll(Announcer(My.Settings.PDC1.ToString + Amount.ToString + My.Settings.D1.ToString))
                        GameUpdate()
                    Case "R" 'player casted recovery
                        PlayerHealth += Amount
                        Task.WaitAll(Announcer(My.Settings.PR1.ToString + Amount.ToString + My.Settings.R1.ToString))
                        GameUpdate()
                End Select
            Case 2 'target grisou
                Select Case Type
                    Case "A"
                        If (Amount = 0) Then 'check if missed
                            Task.WaitAll(Announcer(My.Settings.PAM1.ToString))
                            GameUpdate()
                        Else
                            Select Case GrisouDefense ' checking defense
                                Case >= Amount ' defense is higher then attack
                                    Task.WaitAll(Announcer(My.Settings.GDH1.ToString))
                                    GameUpdate()
                                Case < Amount 'defense is there but lower
                                    container1 = Amount - GrisouDefense
                                    GrisouHealth -= container1
                                    Task.WaitAll(Announcer(My.Settings.GDL1.ToString + container1.ToString + My.Settings.DAM.ToString))
                                    GameUpdate()
                                Case = 0 'no defense
                                    GrisouHealth -= Amount
                                    Task.WaitAll(Announcer(My.Settings.PA1.ToString + Amount.ToString + My.Settings.DAM.ToString))
                                    GameUpdate()
                            End Select
                        End If
                    Case "D" 'grisou casted defense
                        GrisouDefense += Amount
                        Task.WaitAll(Announcer(My.Settings.GDC1.ToString + Amount.ToString + My.Settings.D1.ToString))
                        GameUpdate()
                    Case "R" 'grisou casted recovery
                        GrisouHealth += Amount
                        Task.WaitAll(Announcer(My.Settings.GR1.ToString + Amount.ToString + My.Settings.R1.ToString))
                        GameUpdate()
                End Select
        End Select
    End Sub
    'GameUpdate
    'update everything and check for death
    Public Sub GameUpdate()
        'updating player info
        PlayerText2.Text = PlayerHealth.ToString + " / 50"
        If (PlayerHealth <= 0) Then 'if value is under 0
            PlayerHealthBar.Value = 0
        ElseIf (PlayerHealth <= 50) Then 'if value is between 50 and 0
            PlayerHealthBar.Value = PlayerHealth
        Else 'if it's over 50
            PlayerHealthBar.Value = 50
        End If
        PlayerDefenseText.Text = PlayerDefense.ToString
        'updating grisou info
        GrisouText2.Text = GrisouHealth.ToString + " / 50"
        If (GrisouHealth <= 0) Then 'if value is under 0
            GrisouHealthBar.Value = 0
        ElseIf (GrisouHealth <= 50) Then 'if value is between 50 and 0
            GrisouHealthBar.Value = PlayerHealth
        Else 'if it's over 50
            GrisouHealthBar.Value = 50
        End If
        GrisouDefenseText.Text = GrisouDefense.ToString
        If (PlayerHealth <= 0) Then 'check if player died
            Gameover(1)
        Else
            Round()
        End If
        If (GrisouHealth <= 0) Then 'check if grisou died
            Gameover(2)
        Else
            Round()
        End If
    End Sub
    'game over call this whenever somebody die
    Public Sub Gameover(ByVal user As Integer)
        If (user = 1) Then
            'Player failed
            DisablePlayerButton()
            Task.WaitAll(Announcer("You died! Game Over"))
        ElseIf (user = 2) Then
            'Grisou failed
            DisablePlayerButton()
            Task.WaitAll(Announcer("Grisou died you win !!"))
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
        DisablePlayerButton() : GameEngine(1, 2, "A")
    End Sub
    Private Sub PlayerDefenseClick(sender As Object, e As EventArgs) Handles PlayerAction2.Click
        DisablePlayerButton() : GameEngine(1, 2, "D")
    End Sub
    Private Sub PlayerRecoverClick(sender As Object, e As EventArgs) Handles PlayerAction3.Click
        DisablePlayerButton() : GameEngine(1, 2, "R")
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
