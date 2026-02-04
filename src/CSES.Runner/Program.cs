//   This file is designed for manual ad-hoc testing - you manually edit it to test
//   whichever problem you're currently working on. The pattern is:
// 
//   1. Update the using statement to the category you're testing
//   2. Update the solver instantiation to the specific solver you want to test
// 
//   For DynamicProgramming Testing
// 
//   When you want to test a DynamicProgramming problem, you would:
// 
//   using CSES.Solutions.DynamicProgramming;  // Change this line
// 
//   internal static class Program
//   {
//       private static int Main(string[] args)
//       {
//           // ... existing code ...
// 
//           var solver = new YourDynamicProgrammingSolver();  // Change this line
//           var output = solver.Solve(input);
// 
//           // ... rest of code ...
//       }
//   }

using CSES.Solutions.DynamicProgramming;

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
        var solver = new DiceCombinationsSolver();
        var output = solver.Solve(input);

        Console.WriteLine("---- Solver Output ----");
        Console.WriteLine(output);
        return 0;
    }
}
