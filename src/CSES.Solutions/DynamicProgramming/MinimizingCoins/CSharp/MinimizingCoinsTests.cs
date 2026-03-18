using Xunit;

namespace CSES.Solutions.DynamicProgramming;

/// <summary>
/// Tests for the MinimizingCoins problem.
/// </summary>
public class MinimizingCoinsTests : BaseSolverTests<MinimizingCoinsSolver>
{
    private const string TestDataFolder = "DynamicProgramming/MinimizingCoins/TestData";

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
    [InlineData(13)]
    [InlineData(14)]
    [InlineData(15)]
    [InlineData(16)]
    [InlineData(17)]
    [InlineData(18)]
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
