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
        Array.Sort(coins);
        Array.Reverse(coins);
        List<int> answers = new List<int>();

        // Debug (don’t print in final CSES submission)
        Console.Error.WriteLine($"numCoins: {numCoins}, desiredSum: {desiredSum}");
        Console.Error.WriteLine($"coins: {string.Join(", ", coins)}");
        /*
        while (desiredSum > 0)
        {
            foreach (int coin in coins)
            {
                Console.Error.WriteLine($"desired sum = {desiredSum}");
                Console.Error.WriteLine($"processing coin {coin}");
                minCoins += desiredSum / coin;
                desiredSum = desiredSum % coin;
                Console.Error.WriteLine($"min coins is now {minCoins}");
                Console.Error.WriteLine($"desired sum = {desiredSum}");
                Console.Error.WriteLine("-------------");
            }
        }

        Console.Error.WriteLine($"min coins = {minCoins}");
        */

        for (int i = 0; i < coins.Length; i++)
        {
            int minCoins = 0;
            int sum = desiredSum;
            //Console.Error.WriteLine("-----------");
            //Console.Error.WriteLine($"starting at i = {i}");
            for (int j = i; j < coins.Length; j++)
            {
                //Console.Error.WriteLine($"desired sum = {sum}");
                //Console.Error.WriteLine($"processing coin {coins[j]}");
                minCoins += sum / coins[j];
                sum = sum % coins[j];
                //Console.Error.WriteLine($"min coins is now {minCoins}");
                //Console.Error.WriteLine($"desired sum = {sum}");
                //Console.Error.WriteLine("-------------");
            }
            if (sum == 0)
            {
                answers.Add(minCoins);
            }
        }
        Console.Error.WriteLine($"answers {string.Join(", ", answers)}");
        if (answers.Count == 0)
        {
            return "-1";
        }
        else
        {

            int min = answers[0];
            for (int i = 1; i < answers.Count; i++)
            {
                if (answers[i] < min) min = answers[i];
            }
            Console.Error.WriteLine($"answer {min}");

            return min.ToString();
        }
    }
}
