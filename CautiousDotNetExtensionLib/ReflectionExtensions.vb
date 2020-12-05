Imports System.Reflection

Public Module ReflectionExtensions

    Public Function LoadInstances(Of T)(Optional args As Object() = Nothing) As IEnumerable(Of T)
        Dim thisAsm As Assembly = Assembly.GetExecutingAssembly()
        Dim types = thisAsm.GetTypes().Where(Function(ty As Type) (GetType(T).IsAssignableFrom(ty) AndAlso ty.IsClass AndAlso Not ty.IsAbstract)).ToList()

        If args Is Nothing Then
            Return types.Map(Function(typ As Type) CType(Activator.CreateInstance(typ), T))
        Else
            Return types.Map(Function(typ As Type) CType(Activator.CreateInstance(typ, args), T))
        End If
    End Function

End Module
