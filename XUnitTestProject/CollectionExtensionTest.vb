Imports CautiousDotNetExtensionLib.CollectionExtensions
Imports Xunit

Namespace XUnitTestProject
    Public Class CollectionExtensionTest
        <Fact>
        Sub TestArrayCast()
            Dim A() As Double = {1.34, 2.12, 3.235, 4.324, 5.234}
            Dim B = A.Map(Function(D As Double)
                              Return CInt(D)
                          End Function)

            For I As Integer = 0 To A.Count - 1
                Assert.Equal(CInt(A(I)), B(I))
            Next
        End Sub

        <Fact>
        Sub TestZipWithIndex()

            Dim A() As Double = {1.34, 2.12, 3.235, 4.324, 5.234}
            Dim B = A.ZipWithIndex()

            For I As Integer = 0 To A.Count - 1
                Assert.Equal(I, B(I).Index)
                Assert.Equal(A(I), B(I).Value)
            Next

        End Sub

    End Class
End Namespace

