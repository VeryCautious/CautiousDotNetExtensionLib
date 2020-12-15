Imports System.Runtime.CompilerServices

Public Module StringExtensions


    <Extension()>
    Public Function Match(ByVal S As String, ByVal Pattern As String, Optional Greedy As Boolean = False) As String()
        Dim ret = TryMatch(S, Pattern, Greedy)
        If ret Is Nothing Then
            Throw New ArgumentException("Does not match pattern")
        End If
        Return ret
    End Function

    <Extension()>
    Public Function TryMatch(ByVal S As String, ByVal Pattern As String, Optional Greedy As Boolean = False) As String()
        Dim ret = S.MatchToDict(Pattern, Greedy)

        If Not ret.FoundMatch Then
            Return Nothing
        End If

        Dim IndexCount = ret.Matches.Keys.Max
        Dim resArray(IndexCount) As String

        For Each Item In ret.Matches
            resArray(Item.Key) = Item.Value
        Next

        Return resArray
    End Function

    ''' <summary>
    ''' Basicly reverses the String.Format() function by splitting a string into parts.
    ''' The pattern defines the structure of the string with some capturing groups that the function tries to match.
    ''' For instance the String "(a,b,c)" with the pattern "({1},{0})" will result in a dictionary with two values:
    ''' Dict(0) = "b,c" and Dict(1) = "a". The default is not greedy!
    ''' </summary>
    ''' <param name="Greedy">If set to true the Capturing group caputers as mutch as it can whilst still matching</param>
    ''' <returns></returns>
    <Extension()>
    Public Function MatchToDict(ToMatch As String, Pattern As String, Optional Greedy As Boolean = False) As (Matches As Dictionary(Of Integer, String), FoundMatch As Boolean)
        Dim FirstPattern As Integer = Pattern.IndexOf("{")

        If FirstPattern < 0 Then
            If ToMatch = Pattern Then
                Return (New Dictionary(Of Integer, String), True)
            Else
                Return (Nothing, False)
            End If
        End If

        If Not ToMatch.Substring(0, FirstPattern) = Pattern.Substring(0, FirstPattern) Then
            Return (Nothing, False)
        End If

        Dim MatchIndex = CInt(Pattern.Substring(FirstPattern + 1, Pattern.IndexOf("}"c) - (FirstPattern + 1)))

        If ToMatch.Count <= FirstPattern Then
            Return (New Dictionary(Of Integer, String) From {{MatchIndex, ""}}, True)
        End If

        ToMatch = ToMatch.Substring(FirstPattern)
        Pattern = Pattern.Substring(Pattern.IndexOf("}") + 1)

        If Pattern = "" Then
            Return (New Dictionary(Of Integer, String) From {{MatchIndex, ToMatch}}, True)
        End If

        Dim PossibleMatches As New List(Of (Index As Integer, Matched As String))

        Dim StartVal As Integer = 0
        Dim EndVal As Integer = ToMatch.Count - 1
        Dim StepSize As Integer = 1

        If Greedy Then
            StartVal = ToMatch.Count - 1
            EndVal = 0
            StepSize = -1
        End If

        For I As Integer = StartVal To EndVal Step StepSize
            If ToMatch(I) = Pattern(0) Then PossibleMatches.Add((I, ToMatch.Substring(0, I)))
        Next


        For Each M In PossibleMatches
            Dim res = MatchToDict(ToMatch.Substring(M.Index), Pattern)
            If res.FoundMatch Then
                res.Matches.Add(MatchIndex, M.Matched)
                Return res
            End If
        Next

        Return (Nothing, False)
    End Function

    <Extension()>
    Public Function GetValueBetweenTwoIndex(S As String, index1 As Integer, index2 As Integer) As String
        Return S.Substring(index1 + 1, (index2 - index1) - 1)
    End Function


End Module
