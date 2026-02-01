using CSES.Core;
using Xunit;

namespace CSES.Solutions;

/// <summary>
/// Base class for all solver tests. Provides helper methods to run tests
/// against input/output file pairs.
/// </summary>
public abstract class BaseSolverTests<TSolver> where TSolver : ISolver, new()
{
    protected readonly TSolver Solver;

    protected BaseSolverTests()
    {
        Solver = new TSolver();
    }

    /// <summary>
    /// Runs a test by reading the input from a file, solving it,
    /// and comparing the result with the expected output file.
    /// </summary>
    /// <param name="testDataFolder">The folder containing the test data (relative to the test class)</param>
    /// <param name="testNumber">The test number (e.g., 1 for 1.in/1.out)</param>
    protected void RunTest(string testDataFolder, int testNumber)
    {
        var inputPath = Path.Combine(testDataFolder, $"{testNumber}.in");
        var outputPath = Path.Combine(testDataFolder, $"{testNumber}.out");

        Assert.True(File.Exists(inputPath), $"Input file not found: {inputPath}");
        Assert.True(File.Exists(outputPath), $"Output file not found: {outputPath}");

        var input = File.ReadAllText(inputPath);
        var expectedOutput = File.ReadAllText(outputPath).TrimEnd('\r', '\n');
        var actualOutput = Solver.Solve(input).TrimEnd('\r', '\n');

        Assert.Equal(expectedOutput, actualOutput);
    }

    /// <summary>
    /// Gets all test numbers available in the test data folder.
    /// </summary>
    protected static IEnumerable<object[]> GetTestNumbers(string testDataFolder)
    {
        if (!Directory.Exists(testDataFolder))
        {
            yield break;
        }

        var inputFiles = Directory.GetFiles(testDataFolder, "*.in")
            .Select(Path.GetFileNameWithoutExtension)
            .Where(name => int.TryParse(name, out _))
            .Select(int.Parse)
            .OrderBy(n => n);

        foreach (var testNumber in inputFiles)
        {
            yield return new object[] { testNumber };
        }
    }
}
