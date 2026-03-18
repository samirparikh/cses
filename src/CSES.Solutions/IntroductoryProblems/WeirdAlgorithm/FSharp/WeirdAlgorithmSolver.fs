namespace CSES.Solutions.IntroductoryProblems

open CSES.Core

/// Solver for CSES "Weird Algorithm" problem.
/// Problem: https://cses.fi/problemset/task/1068
/// Given a number n, follow these rules:
/// - If n is even, divide it by 2
/// - If n is odd, multiply by 3 and add 1
/// Repeat until n becomes 1
type WeirdAlgorithmSolver() =
    let rec collatz n acc =
        if n = 1L then
            List.rev (1L :: acc)
        elif n % 2L = 0L then
            collatz (n / 2L) (n :: acc)
        else
            collatz (n * 3L + 1L) (n :: acc)

    interface ISolver with
        member _.Solve(input: string) =
            let n = int64 (input.Trim())
            let result = collatz n []
            (result |> List.map string |> String.concat " ") + " "
