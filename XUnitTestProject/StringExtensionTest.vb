Imports CautiousDotNetExtensionLib.StringExtensions
Imports CautiousDotNetExtensionLib.MathExtensions
Imports Xunit
Namespace XUnitTestProject
    Public Class StringExtensionTest

        <Fact>
        Sub TestPatternMatch1()
            Dim s As String = "1:2:3"
            Dim Matches = s.Match("{0}:{1}:{2}")
            Assert.Equal("1", Matches(0))
            Assert.Equal("2", Matches(1))
            Assert.Equal("3", Matches(2))
        End Sub

        <Fact>
        Sub TestPatternMatch2()
            Dim s As String = "(1.23,4.56,-\78.9)"
            Dim Matches = s.Match("({0},{1},-\{2}){3}")
            Assert.Equal("1.23", Matches(0))
            Assert.Equal("4.56", Matches(1))
            Assert.Equal("78.9", Matches(2))
            Assert.Equal("", Matches(3))

            Dim a As Integer = 5
            Assert.True(a.IsBetween(3, 6))
            Assert.True(Not a.IsBetween(6, 9))
        End Sub

        <Fact>
        Sub TestPatternMatch3()
            Dim s As String = "Hello Elisa Merkel."
            Dim Matches = s.Match("Hello {1} {0}.")
            Assert.Equal("Merkel", Matches(0))
            Assert.Equal("Elisa", Matches(1))
        End Sub

        <Fact>
        Sub TestPatternMatch4()
            Dim s As String = "odiwahjdop"
            Dim Matches = s.Match("{5}")
            Assert.Equal(s, Matches(5))
        End Sub

    End Class
End Namespace
