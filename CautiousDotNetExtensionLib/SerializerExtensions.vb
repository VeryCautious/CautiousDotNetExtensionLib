Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Runtime.Serialization.Formatters.Binary

Public Module SerializerExtensions

    <Extension()>
    Public Sub SerializeToFile(BF As BinaryFormatter, obj As Object, Path As String)
        Using stream As FileStream = File.Create(Path)
            BF.Serialize(stream, obj)
        End Using
    End Sub

    <Extension()>
    Public Function DeserializeFromFile(BF As BinaryFormatter, Path As String) As Object
        Dim v As Object = Nothing
        Using Stream = File.OpenRead(Path)
            v = BF.Deserialize(Stream)
        End Using
        Return v
    End Function

End Module
