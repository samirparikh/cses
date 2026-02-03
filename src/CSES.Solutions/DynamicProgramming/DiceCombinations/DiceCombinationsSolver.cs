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
        int n = int.Parse(input.Trim());
        const int MOD = 1_000_000_007;
        long[] dp = new long[n + 1];
        dp[0] = 1;
        for (int i = 1; i <= n; i++)
        {
            for (int dice = 1; dice <= 6; dice++)
            {
                if (i - dice >= 0)
                {
                    dp[i] = (dp[i] + dp[i - dice]) % MOD;
                }
            }
        }
        return dp[n].ToString();
    }
}
