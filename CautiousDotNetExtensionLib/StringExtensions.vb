Imports System.Runtime.CompilerServices

Public Module StringExtensions

    ''' <summary>
    ''' Extracts data out of a String.
    ''' </summary>
    ''' <param name="S">The String that the data should be extraced from</param>
    ''' <param name="Pattern">The pattern, where the capuring groups are labeled with {n} and n beeing the index in the result-array</param>
    ''' <returns>An array of strings. At position i there is the value capured by group-i</returns>
    <Extension()>
    Public Function Match(ByVal S As String, ByVal Pattern As String) As String()
        Dim ResultList As New Dictionary(Of Integer, String)

        Dim IndexOfFirstMatch = Pattern.IndexOf("{"c)


        While IndexOfFirstMatch >= 0
            Dim sWork = S.Substring(0, IndexOfFirstMatch)
            Dim pWork = Pattern.Substring(0, IndexOfFirstMatch)

            If Not pWork = sWork Then
                Throw New ArgumentException("Does not match pattern")
            End If

            S = S.Substring(IndexOfFirstMatch)
            Pattern = Pattern.Substring(IndexOfFirstMatch)

            If Pattern.IndexOf("}"c) = Pattern.Length - 1 Then
                ResultList.Add(CInt(GetValueBetweenTwoIndex(Pattern, Pattern.IndexOf("{"c), Pattern.IndexOf("}"c))), S)
                Pattern = ""
            Else
                Dim SMatchEnd = S.IndexOf(Pattern(Pattern.IndexOf("}"c) + 1))
                Dim SMatch = S.Substring(0, SMatchEnd)
                ResultList.Add(CInt(GetValueBetweenTwoIndex(Pattern, Pattern.IndexOf("{"c), Pattern.IndexOf("}"c))), SMatch)

                Pattern = Pattern.Substring(Pattern.IndexOf("}"c) + 1)
                S = S.Substring(SMatchEnd)
            End If

            IndexOfFirstMatch = Pattern.IndexOf("{"c)
        End While



        Dim IndexCount = ResultList.Keys.Max
        Dim resArray(IndexCount) As String

        For Each Item In ResultList
            resArray(Item.Key) = Item.Value
        Next

        Return resArray
    End Function

    Private Function GetValueBetweenTwoIndex(S As String, index1 As Integer, index2 As Integer) As String
        Return S.Substring(index1 + 1, (index2 - index1) - 1)
    End Function


End Module
