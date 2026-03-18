namespace CSES.FSharp.Solutions.IntroductoryProblems

open Xunit

/// Tests for the Weird Algorithm problem.
type WeirdAlgorithmTests() =
    inherit CSES.FSharp.Solutions.BaseSolverTests<WeirdAlgorithmSolver>()

    static let testDataFolder = "IntroductoryProblems/WeirdAlgorithm/TestData"

    [<Theory>]
    [<InlineData(1)>]
    [<InlineData(2)>]
    [<InlineData(3)>]
    [<InlineData(4)>]
    [<InlineData(5)>]
    [<InlineData(6)>]
    [<InlineData(7)>]
    [<InlineData(8)>]
    [<InlineData(9)>]
    [<InlineData(10)>]
    [<InlineData(11)>]
    [<InlineData(12)>]
    [<InlineData(13)>]
    [<InlineData(14)>]
    member this.Test(testNumber: int) =
        this.RunTest(testDataFolder, testNumber)
