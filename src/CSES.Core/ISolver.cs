namespace CSES.Core;

/// <summary>
/// Interface that all CSES problem solvers must implement.
/// </summary>
public interface ISolver
{
    /// <summary>
    /// Solves the problem with the given input and returns the result.
    /// </summary>
    /// <param name="input">The input string (may contain multiple lines)</param>
    /// <returns>The solution output (may contain multiple lines)</returns>
    string Solve(string input);
}
