using CSES.Core;

namespace CSES.Solutions.IntroductoryProblems;

/// <summary>
/// Solver for CSES "Weird Algorithm" problem.
/// Problem: https://cses.fi/problemset/task/1068
/// Given a number n, follow these rules:
/// - If n is even, divide it by 2
/// - If n is odd, multiply by 3 and add 1
/// Repeat until n becomes 1
/// </summary>
public class WeirdAlgorithmSolver : ISolver
{
    public string Solve(string input)
    {
        long n = long.Parse(input.Trim());
        var result = new List<long>();

        while (n != 1)
        {
            result.Add(n);
            if (n % 2 == 0)
            {
                n /= 2;
            }
            else
            {
                n = n * 3 + 1;
            }
        }
        result.Add(1);

        return string.Join(" ", result) + " ";
    }
}
