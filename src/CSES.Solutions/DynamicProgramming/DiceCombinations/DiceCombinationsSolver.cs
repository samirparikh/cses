using CSES.Core;

namespace CSES.Solutions.DynamicProgramming;

/// <summary>
/// Solver for CSES "Dice Combinations" problem.
/// Problem: https://cses.fi/problemset/task/1633
/// Your task is to count the number of ways to construct sum n by throwing a
/// dice one or more times. Each throw produces an outcome between 1 and 6.
///     For example, if n=3, there are 4 ways:
///
///         * 1+1+1
///         * 1+2
///         * 2+1
///         * 3
/// </summary>

public class DiceCombinationsSolver : ISolver
{
    public string Solve(string input)
    {
        const int MOD = 1_000_000_007;
        int n = int.Parse(input.Trim());

        if (n == 0) return "1";
        
        long[] ways = new long[n + 1];
        ways[0] = 1;
       
        for (int i = 1; i <= n; i++)
        {
            for (int dice = 1; dice <= Math.Min(6, i); dice++)
            {
                ways[i] = (ways[i] + ways[i - dice]) % MOD;
            }
        }

        return ways[n].ToString();
    }
}
