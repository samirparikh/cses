using CSES.Core;

namespace CSES.Solutions.Introductory;

/// <summary>
/// Solver for CSES "Increasing Array" problem.
/// Problem: https://cses.fi/problemset/task/1094
/// You are given an array of n integers. You want to modify the array so that
/// it is increasing, i.e., every element is at least as large as the previous
/// element.
/// On each move, you may increase the value of any element by one. What is
/// the minimum number of moves required?
/// </summary>
public class IncreasingArraySolver : ISolver
{
    public string Solve(string input)
    {
        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        int n = int.Parse(lines[0]);
        var numbers = lines[1].Split(' ').Select(int.Parse).ToArray();
        long moves = 0;
        for (int i = 1; i < n; i++)
        {
            if (numbers[i] < numbers[i - 1])
            {
                moves += numbers[i - 1] - numbers[i];
                numbers[i] = numbers[i - 1];
            }
        }
        return moves.ToString();
    } 
}
