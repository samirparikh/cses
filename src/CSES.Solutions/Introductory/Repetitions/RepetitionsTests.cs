using Xunit;

namespace CSES.Solutions.Introductory;

/// <summary>
/// Tests for the Repetitions problem.
/// </summary>
public class RepetitionsTests : BaseSolverTests<RepetitionsSolver>
{
    private const string TestDataFolder = "Introductory/Repetitions/TestData";

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(7)]
    [InlineData(8)]
    [InlineData(9)]
    [InlineData(10)]
    [InlineData(11)]
    [InlineData(12)]
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