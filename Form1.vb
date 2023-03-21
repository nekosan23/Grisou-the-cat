Imports System.Threading.Thread

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
            Case 1 'grisou choose attack
                GameLogic(2, "A")
            Case 2 'grisou choose defense
                GameLogic(2, "D")
            Case 3 ' grisou choose recovery
                GameLogic(2, "R")
        End Select
        LastChoice = Choice
    End Sub
    'Game Engine V2
    'this is my attempt at fusing GameOver, GameUpdate, Dataprocessor and GameEngine
    'Caster 1= player  2=Grisou
    'TypeOfAttack A = Attack  D = Defense  R= Recovery
    Public Sub GameLogic(ByVal Caster As Integer, ByVal TypeOfAttack As String)
        'setting all the variables
        Static Dim Strength, AttackValue, DefenseValue, RecoveryValue As Integer
        Static Dim AttackLow = New Integer() {1, 2, 3, 4}
        Static Dim AttackMedium = New Integer() {7, 9, 11, 12}
        Static Dim AttackHigh = New Integer() {16, 17, 19, 20}
        Static Dim Defense = New Integer() {6, 8, 12, 13}
        Static Dim Recovery = New Integer() {5, 10, 15, 18}
        Select Case TypeOfAttack
            Case "A" 'Attack
                Strength = GetRandom(1, 4)
                Select Case Strength
                    Case 1 'missed
                        AttackValue = 0 : Exit Select
                    Case 2 'Low
                        Strength = GetRandom(1, 4)
                        AttackValue = AttackLow(Strength) : Exit Select
                    Case 3 'Medium
                        Strength = GetRandom(1, 4)
                        AttackValue = AttackMedium(Strength) : Exit Select
                    Case 4 'High
                        Strength = GetRandom(1, 4)
                        AttackValue = AttackHigh(Strength) : Exit Select
                End Select
            Case "D" 'Defense
                Strength = GetRandom(1, 4)
                DefenseValue = Defense(Strength) : Exit Select
            Case "R" 'Recovery
                Strength = GetRandom(1, 4)
                RecoveryValue = Recovery(Strength) : Exit Select
        End Select
        Select Case Caster 'check the caster and start the math make sure to set null value to 0 
            Case 1 'You Cast

            Case 2 'Grisou Cast

        End Select
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
        'refresh everything
        PlayerText1.Refresh() : PlayerText2.Refresh() : PlayerHealthBar.Refresh() : PlayerDefenseText.Refresh()
        GrisouText1.Refresh() : GrisouText2.Refresh() : GrisouHealthBar.Refresh() : GrisouDefenseText.Refresh()
        'death check
        If (PlayerHealth <= 0) Then
            'You died
            DisablePlayerButton()
            Task.WaitAll(Announcer("You died! Game Over"))
        End If
        If (GrisouHealth <= 0) Then
            'Grisou died
            DisablePlayerButton()
            Task.WaitAll(Announcer("Grisou died you win !!"))
        End If
        Select Case TurnValue 'Checking and changing the turn and sending back to round()
            Case 1
                TurnValue = 2
            Case 2
                TurnValue = 1
        End Select
        Round()
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
        DisablePlayerButton() : GameLogic(1, "A")
    End Sub
    Private Sub PlayerDefenseClick(sender As Object, e As EventArgs) Handles PlayerAction2.Click
        DisablePlayerButton() : GameLogic(1, "D")
    End Sub
    Private Sub PlayerRecoverClick(sender As Object, e As EventArgs) Handles PlayerAction3.Click
        DisablePlayerButton() : GameLogic(1, "R")
    End Sub
    'Below is fast code for saving space
    Public Sub DisablePlayerButton()
        PlayerAction1.Enabled = False : PlayerAction2.Enabled = False : PlayerAction3.Enabled = False
    End Sub
    Public Sub EnablePlayerButton()
        PlayerAction1.Enabled = True : PlayerAction2.Enabled = True : PlayerAction3.Enabled = True
    End Sub
End Class
