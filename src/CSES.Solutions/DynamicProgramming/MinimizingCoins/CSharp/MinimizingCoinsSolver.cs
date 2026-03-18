using CSES.Core;

namespace CSES.Solutions.DynamicProgramming;

/// <summary>
/// Solver for CSES "Minimizing Coins" problem.
/// Problem: https://cses.fi/problemset/task/1634
/// Consider a money system consisting of n coins. Each coin has a positive
/// integer value. Your task is to produce a sum of money x using the available
/// coins in such a way that the number of coins is minimal.
/// For example, if the coins are \{1,5,7\} and the desired sum is 11, an
/// optimal solution is 5+5+1 which requires 3 coins.
/// Input:
///     The first input line has two integers n and x: the number of coins and
///     the desired sum of money.
///     The second line has n distinct integers c_1,c_2,\dots,c_n: the value of
///     each coin.
/// Output:
///     Print one integer: the minimum number of coins. If it is not possible
///     to produce the desired sum, print -1.
/// </summary>
public class MinimizingCoinsSolver : ISolver
{
    public string Solve(string input)
    {
        var lines = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        var firstLineParts = lines[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
        int numCoins = int.Parse(firstLineParts[0]);
        int desiredSum = int.Parse(firstLineParts[1]);

        int[] coins = lines[1].Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int[] dp = new int[desiredSum + 1];
        Array.Fill(dp, int.MaxValue);
        dp[0] = 0;

        for (int coin = 0; coin < numCoins; coin++)
        {
            for (int sum = 1; sum <= desiredSum; sum++)
            {
                //if (coins[coin] > sum) continue;
                if (coins[coin] > sum || dp[sum - coins[coin]] == int.MaxValue) continue;
                dp[sum] = Math.Min(dp[sum], dp[sum - coins[coin]] + 1);
            }
        }

        if (dp[desiredSum] != int.MaxValue) return dp[desiredSum].ToString();
        return "-1";
    }
}
