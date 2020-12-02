Public Class IndexValuePair(Of T)

    Public ReadOnly Property Index As Integer
    Public ReadOnly Property Value As T

    Public Sub New(index As Integer, value As T)
        Me.Index = index
        Me.Value = value
    End Sub
End Class
