using Xunit;

namespace CSES.Solutions.Introductory;

/// <summary>
/// Tests for the Weird Algorithm problem.
/// </summary>
public class WeirdAlgorithmTests : BaseSolverTests<WeirdAlgorithmSolver>
{
    private const string TestDataFolder = "Introductory/WeirdAlgorithm/TestData";

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
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
