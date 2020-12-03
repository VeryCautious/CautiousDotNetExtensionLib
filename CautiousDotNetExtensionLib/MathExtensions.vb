Imports System.Runtime.CompilerServices

Module MathExtensions

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

End Module
