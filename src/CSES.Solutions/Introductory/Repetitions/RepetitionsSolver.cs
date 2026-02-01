using CSES.Core;

namespace CSES.Solutions.Introductory;

/// <summary>
/// Solver for CSES "Weird Algorithm" problem.
/// Problem: https://cses.fi/problemset/task/1069
/// You are given a DNA sequence: a string consisting of characters A, C, G, and
/// T. Your task is to find the longest repetition in the sequence. This is a
/// maximum-length substring containing only one type of character.
/// </summary>
public class RepetitionsSolver : ISolver
{
    public string Solve(string input)
    {

        string sequence = input;
        int longestRepeatLength = 0;
        //Console.WriteLine($"Input Sequence: <{sequence}>");
        //Console.WriteLine($"Sequence Length: {sequence.Length}");
        //Console.WriteLine($"length: {"ABCCCDDDDDEE".Length}");
        
        for (int i = 0; i < sequence.Length; i++)
        {
            char currentNucleotide = sequence[i];
            int currentLength = 1;
        
            for (int j = i + 1; j < sequence.Length; j++)
            {
                if (sequence[j] == currentNucleotide)
                {
                    currentLength++;
                }
                else
                {
                    break;
                }
            }
        
            if (currentLength > longestRepeatLength)
            {
                longestRepeatLength = currentLength;
            }
            if (longestRepeatLength >= sequence.Length / 2)
            {
                break; // No need to check further
            }
        }

        return Convert.ToString(longestRepeatLength);
    } 
}
