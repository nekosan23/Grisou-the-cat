﻿Imports System.Threading.Thread

Public Class MainWin
    Public GrisouHealth, PlayerHealth, PlayerDefense, GrisouDefense As Integer
    Public GameState As Boolean
    Public GrisouTextA, PlayerTextA As String
    Public TurnValue As Integer
    Public FailSafe As Boolean
    Public Choice, LastChoice As Integer
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
    'Round system
    Public Sub Round()
        If (GameState = True) Then
            TurnValue = GetRandom(1, 2)
            GameState = False
        End If
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
    End Sub
    'Grisou AI yes we made a cat intelligent
    Public Sub GrisouAI()
        Choice = Nothing
        Do Until (Choice = Not LastChoice And Choice = Not Nothing) 'Do loop until i get a difference
            Choice = GetRandom(1, 3)
        Loop
        Select Case Choice 'check grisou choice
            Case 1 'grisou chose attack
                GameEngine(2, 1, "A")
            Case 2 'grisou chose defense
                GameEngine(2, 1, "D")
            Case 3 ' grisou chose recovery
                GameEngine(2, 1, "R")
        End Select
        LastChoice = Choice
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
        'everything is in GameLogic
    End Sub
    'Game Engine V2
    'this is my attempt at fusing GameOver, GameUpdate, Dataprocessor and GameEngine
    Public Sub GameLogic(ByVal Caster As Integer, ByVal Target As Integer, ByVal TypeOfAttack As String)
        'setting all the variables
        Static Dim Container1 As Integer
        Static Dim AttackLow = New Integer() {1, 2, 3, 4}
        Static Dim AttackMedium = New Integer() {7, 9, 11, 12}
        Static Dim AttackHigh = New Integer() {16, 17, 19, 20}
        Static Dim Defense = New Integer() {6, 8, 12, 13}
        Static Dim Recovery = New Integer() {5, 10, 15, 18}
        'Checking if someone died and updating UI
        PlayerText2.Text = PlayerHealth.ToString + " / 50" : GrisouText2.Text = GrisouHealth.ToString + " / 50"
        PlayerDefenseText.Text = PlayerDefense.ToString : GrisouDefenseText.Text = GrisouDefense.ToString
        'updating ProgressBar and checking for overflow to prevent OverFlowException
        Select Case PlayerHealth
            Case <= 0 'digit is 0 or lower
                PlayerHealthBar.Value = 0
            Case >= 50 'bigger or equal to 50
                PlayerHealthBar.Value = 50
            Case < 50 'under 50
                PlayerHealthBar.Value = PlayerHealth
        End Select
        Select Case GrisouHealth
            Case <= 0 'digit is 0 or lower
                GrisouHealthBar.Value = 0
            Case >= 50 'bigger or equal to 50
                GrisouHealthBar.Value = 50
            Case < 50 'under 50
                GrisouHealthBar.Value = GrisouHealth
        End Select
        'death check
        If (PlayerHealth <= 0) Then
            'You died
            DisablePlayerButton()
            Task.WaitAll(Announcer("You died! Game Over"))
        Else
            Round()
        End If
        If (GrisouHealth <= 0) Then
            'Grisou died
            DisablePlayerButton()
            Task.WaitAll(Announcer("Grisou died you win !!"))
        Else
            Round()
        End If
    End Sub
    'Announcer
    Public Async Function Announcer(text As String) As Task
        'Dim animationcountdown As Integer = -490
        'AnnouncerText.Text = text
        'AnnouncerText.Visible = True
        'AnnouncerPanel.Visible = True
        ' Do
        'AnnouncerPanel.Location = New Point(animationcountdown, 292)
        'animationcountdown += 10
        'Sleep(10)
        'Loop Until animationcountdown = 10
        'AnnouncerText.Refresh()
        'AnnouncerText.Visible = False
        'AnnouncerPanel.Visible = False
        Console.WriteLine(text)
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
        PlayerAction1.Enabled = False : PlayerAction2.Enabled = False : PlayerAction3.Enabled = False
    End Sub
    Public Sub EnablePlayerButton()
        PlayerAction1.Enabled = True : PlayerAction2.Enabled = True : PlayerAction3.Enabled = True
    End Sub
End Class
