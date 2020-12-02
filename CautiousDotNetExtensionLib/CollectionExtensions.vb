Imports System.Runtime.CompilerServices

Public Module CollectionExtensions

    <Extension>
    Public Function Map(Of F, T)(InputList As List(Of F), MappingFunction As Func(Of F, T)) As List(Of T)
        Dim ResultList As New List(Of T)

        For Each Item As F In InputList
            ResultList.Add(MappingFunction.Invoke(Item))
        Next

        Return ResultList
    End Function

    <Extension>
    Public Function ZipWithIndex(Of T)(InputList As IEnumerable(Of T)) As IEnumerable(Of IndexValuePair(Of T))
        Dim indexList = GetIndexCollection(0, InputList.Count - 1)
        Return InputList.Zip(indexList, Function(f As T, s As Integer) As IndexValuePair(Of T)
                                            Return New IndexValuePair(Of T)(s, f)
                                        End Function)
    End Function

    Public Function GetIndexCollection(StartValue As Integer, EndValue As Integer) As IEnumerable(Of Integer)
        Dim a(0 To EndValue - StartValue) As Integer

        For I As Integer = 0 To EndValue - StartValue
            a(I) = I + StartValue
        Next

        Return a
    End Function

    <Extension>
    Public Function Map(Of F, T)(InputArray As F(), MappingFunction As Func(Of F, T)) As T()
        Dim ResultArray(0 To InputArray.Count - 1) As T

        For i As Integer = 0 To InputArray.Count - 1
            ResultArray(i) = MappingFunction.Invoke(InputArray(i))
        Next

        Return ResultArray
    End Function

End Module
