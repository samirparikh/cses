using CSES.Core;

namespace CSES.Solutions.Introductory;

/// <summary>
/// Solver for CSES "Missing Number" problem.
/// Problem: https://cses.fi/problemset/task/1083
/// You are given all numbers between 1,2,n except one. Your task is to
/// find the missing number.
/// </summary>
public class MissingNumberSolver : ISolver
{
    public string Solve(string input)
    {
        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        int n = int.Parse(lines[0]);
        var numbers = lines[1].Split(' ').Select(int.Parse).ToArray();
        var set = new HashSet<int>(numbers);
        
        for (int i = 1; i <= n; i++)
            if (!set.Contains(i)) return i.ToString();
        return "0";
    } 
}
