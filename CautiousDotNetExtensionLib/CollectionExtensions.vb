Imports System.Runtime.CompilerServices

Public Module CollectionExtensions

    ''' <summary>
    ''' Applies a function to every Item in the list and returns a new list containing the function-results
    ''' </summary>
    ''' <typeparam name="F">The Type that the first list contains</typeparam>
    ''' <typeparam name="T">The Type the resultlist will contain</typeparam>
    ''' <param name="InputList">The list that should be mapped</param>
    ''' <param name="MappingFunction">A function that defines what to do to every Item in the first list</param>
    ''' <returns>A list of results of the function</returns>
    <Extension>
    Public Function Map(Of F, T)(InputList As List(Of F), MappingFunction As Func(Of F, T)) As List(Of T)
        Dim ResultList As New List(Of T)

        For Each Item As F In InputList
            ResultList.Add(MappingFunction.Invoke(Item))
        Next

        Return ResultList
    End Function

    ''' <summary>
    ''' Returns a new IEnumerable containing IndexValuePairs.
    ''' </summary>
    ''' <typeparam name="T">The Type that is stored in the Inputlist</typeparam>
    <Extension>
    Public Function ZipWithIndex(Of T)(InputList As IEnumerable(Of T)) As IEnumerable(Of IndexValuePair(Of T))
        Dim indexList = GetIndexCollection(0, InputList.Count - 1)
        Return InputList.Zip(indexList, Function(f As T, s As Integer) As IndexValuePair(Of T)
                                            Return New IndexValuePair(Of T)(s, f)
                                        End Function)
    End Function

    ''' <summary>
    ''' Gets an IEnumerable that contains the numbers form StartValue to EndValue. [StartValue,...,EndValue]
    ''' </summary>
    Public Function GetIndexCollection(StartValue As Integer, EndValue As Integer) As IEnumerable(Of Integer)
        Dim a(0 To EndValue - StartValue) As Integer

        For I As Integer = 0 To EndValue - StartValue
            a(I) = I + StartValue
        Next

        Return a
    End Function

    ''' <summary>
    ''' Applies a function to every Item in the array and returns a new array containing the function-results
    ''' </summary>
    ''' <typeparam name="F">The Type that the first array contains</typeparam>
    ''' <typeparam name="T">The Type the resultlist will contain</typeparam>
    ''' <param name="InputArray">The list that should be mapped</param>
    ''' <param name="MappingFunction">A function that defines what to do to every Item in the first array</param>
    ''' <returns>A array of results of the function</returns>
    <Extension>
    Public Function Map(Of F, T)(InputArray As F(), MappingFunction As Func(Of F, T)) As T()
        Dim ResultArray(0 To InputArray.Count - 1) As T

        For i As Integer = 0 To InputArray.Count - 1
            ResultArray(i) = MappingFunction.Invoke(InputArray(i))
        Next

        Return ResultArray
    End Function

End Module
