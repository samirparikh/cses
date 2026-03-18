using Xunit;

namespace CSES.Solutions.IntroductoryProblems;

/// <summary>
/// Tests for the IncreasingArray problem.
/// </summary>
public class IncreasingArrayTests : BaseSolverTests<IncreasingArraySolver>
{
    private const string TestDataFolder = "IntroductoryProblems/IncreasingArray/TestData";

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(7)]
    public void Test(int testNumber)
    {
        RunTest(TestDataFolder, testNumber);
    }

    // Alternative: Use this instead if you want to auto-discover all test files
    // [Theory]
    // [MemberData(nameof(GetAllTests))]
    // public void Test(int testNumber)
    // {
    //     RunTest(TestDataFolder, testNumber);
    // }
    //
    // public static IEnumerable<object[]> GetAllTests()
    //     => GetTestNumbers(TestDataFolder);
}
