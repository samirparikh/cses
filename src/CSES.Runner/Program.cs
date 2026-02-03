using CSES.Solutions.IntroductoryProblems;

internal static class Program
{
    private static int Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Usage: dotnet run --project src/CSES.Runner -- <path-to-input>");
            Console.WriteLine("Example: dotnet run --project src/CSES.Runner -- src/CSES.Solutions/Introductory/MissingNumber/TestData/1.in");
            return 1;
        }

        var inputPath = args[0];
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"Input file not found: {inputPath}");
            return 1;
        }

        var input = File.ReadAllText(inputPath);
        var solver = new MissingNumberSolver();
        var output = solver.Solve(input);

        Console.WriteLine("---- Solver Output ----");
        Console.WriteLine(output);
        return 0;
    }
}
