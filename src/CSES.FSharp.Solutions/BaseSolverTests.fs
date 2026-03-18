namespace CSES.FSharp.Solutions

open System
open System.IO
open CSES.Core
open Xunit

/// Base class for all F# solver tests. Provides helper methods to run tests
/// against input/output file pairs.
[<AbstractClass>]
type BaseSolverTests<'TSolver when 'TSolver :> ISolver and 'TSolver : (new : unit -> 'TSolver)>() =
    let solver = new 'TSolver()

    member _.Solver = solver

    /// Runs a test by reading the input from a file, solving it,
    /// and comparing the result with the expected output file.
    member _.RunTest(testDataFolder: string, testNumber: int) =
        let inputPath = Path.Combine(testDataFolder, $"{testNumber}.in")
        let outputPath = Path.Combine(testDataFolder, $"{testNumber}.out")

        Assert.True(File.Exists(inputPath), $"Input file not found: {inputPath}")
        Assert.True(File.Exists(outputPath), $"Output file not found: {outputPath}")

        let input = File.ReadAllText(inputPath)
        let expectedOutput = File.ReadAllText(outputPath).TrimEnd([| '\r'; '\n' |])
        let actualOutput = solver.Solve(input).TrimEnd([| '\r'; '\n' |])

        Assert.Equal(expectedOutput, actualOutput)

/// Module with helper functions for test data discovery
module TestHelpers =
    /// Gets all test numbers available in the test data folder as xUnit theory data.
    let getTestNumbers (testDataFolder: string) : seq<obj[]> =
        if not (Directory.Exists(testDataFolder)) then
            Seq.empty
        else
            Directory.GetFiles(testDataFolder, "*.in")
            |> Seq.map Path.GetFileNameWithoutExtension
            |> Seq.choose (fun name ->
                match Int32.TryParse(name) with
                | true, n -> Some n
                | false, _ -> None)
            |> Seq.sort
            |> Seq.map (fun n -> [| box n |])
