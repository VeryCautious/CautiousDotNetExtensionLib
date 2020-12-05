Imports System.Runtime.CompilerServices

Public Module MathExtensions

    ''' <summary>
    ''' Clamps a value between two other values.
    ''' </summary>
    <Extension()>
    Public Function Clamp(I As Integer, Min As Integer, Max As Integer) As Integer
        Return Math.Min(Math.Max(Min, I), Max)
    End Function

    ''' <summary>
    ''' Clamps a value between two other values.
    ''' </summary>
    <Extension()>
    Public Function Clamp(I As Double, Min As Double, Max As Double) As Double
        Return Math.Min(Math.Max(Min, I), Max)
    End Function

    ''' <summary>
    ''' Clamps a value between two other values.
    ''' </summary>
    <Extension()>
    Public Function Clamp(I As Single, Min As Single, Max As Single) As Single
        Return Math.Min(Math.Max(Min, I), Max)
    End Function

    '<Extension()>
    'Public Function IsBetween(value As Double, Lower As Double, Upper As Double) As Boolean
    '    Return value >= Lower AndAlso value <= Upper
    'End Function

    '<Extension()>
    'Public Function IsBetween(value As Integer, Lower As Integer, Upper As Integer) As Boolean
    '    Return value >= Lower AndAlso value <= Upper
    'End Function

    '<Extension()>
    'Public Function IsBetween(value As Single, Lower As Single, Upper As Single) As Boolean
    '    Return value >= Lower AndAlso value <= Upper
    'End Function

    <Extension()>
    Public Function IsBetween(Of T As IComparable)(value As T, Lower As T, Upper As T) As Boolean
        Return value.CompareTo(Lower) >= 0 AndAlso value.CompareTo(Upper) <= 0
    End Function
End Module
