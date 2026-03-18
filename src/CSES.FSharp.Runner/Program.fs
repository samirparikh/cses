open System
open System.IO
open CSES.Core

// Edit this to instantiate the solver you want to test
// Example: let solver = YourSolver() :> ISolver
let solver: ISolver option = None

[<EntryPoint>]
let main args =
    match solver with
    | None ->
        printfn "No solver configured. Edit Program.fs to set the solver."
        1
    | Some s ->
        match args with
        | [| inputPath |] when File.Exists(inputPath) ->
            let input = File.ReadAllText(inputPath)
            let result = s.Solve(input)
            printfn "%s" result
            0
        | [| inputPath |] ->
            printfn "File not found: %s" inputPath
            1
        | _ ->
            printfn "Usage: dotnet run -- <input-file>"
            1
