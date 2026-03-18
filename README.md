# CSES Problem Solutions

Solutions to problems from the [CSES Problem Set](https://cses.fi/problemset/) written in C# and F#.

## Table of Contents

- [Project Structure](#project-structure)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Building the Project](#building-the-project)
- [Running Tests](#running-tests)
  - [Run All Tests](#run-all-tests)
  - [Run Tests by Language](#run-tests-by-language)
  - [Run Tests by Problem](#run-tests-by-problem)
  - [Run Tests by Category](#run-tests-by-category)
  - [Verbose Test Output](#verbose-test-output)
- [Console Runner (Manual Testing)](#console-runner-manual-testing)
  - [C# Runner](#c-runner)
  - [F# Runner](#f-runner)
- [Adding a New Problem](#adding-a-new-problem)
  - [Adding a C# Solution](#adding-a-c-solution)
  - [Adding an F# Solution](#adding-an-f-solution)
- [Namespace Conventions](#namespace-conventions)
- [Features](#features)
- [Auto-Discovery Alternative](#auto-discovery-alternative)
- [Tips](#tips)

## Project Structure

```
cses/
├── src/
│   ├── CSES.Core/                        # Core interfaces (shared by C# and F#)
│   │   ├── ISolver.cs                    # Interface all solvers implement
│   │   └── CSES.Core.csproj
│   ├── CSES.Solutions/                   # All problem solvers, tests, and test data
│   │   ├── CSES.CSharp.csproj            # C# test project
│   │   ├── CSES.FSharp.fsproj            # F# test project
│   │   ├── BaseSolverTests.cs            # C# base test class
│   │   ├── BaseSolverTests.fs            # F# base test class
│   │   ├── IntroductoryProblems/         # Category folder
│   │   │   └── WeirdAlgorithm/           # Problem folder
│   │   │       ├── CSharp/               # C# implementation
│   │   │       │   ├── WeirdAlgorithmSolver.cs
│   │   │       │   └── WeirdAlgorithmTests.cs
│   │   │       ├── FSharp/               # F# implementation
│   │   │       │   ├── WeirdAlgorithmSolver.fs
│   │   │       │   └── WeirdAlgorithmTests.fs
│   │   │       └── TestData/             # Shared test data
│   │   │           ├── 1.in
│   │   │           ├── 1.out
│   │   │           └── ...
│   │   └── DynamicProgramming/           # Another category folder
│   │       └── ...
│   ├── CSES.CSharp.Runner/               # C# console runner for manual testing
│   │   ├── Program.cs
│   │   └── CSES.CSharp.Runner.csproj
│   └── CSES.FSharp.Runner/               # F# console runner for manual testing
│       ├── Program.fs
│       └── CSES.FSharp.Runner.fsproj
├── CSES.slnx
└── README.md
```

**Key Points:**
- Each problem has `CSharp/` and/or `FSharp/` subfolders for language-specific implementations
- `TestData/` is shared between both languages, avoiding duplication
- Both C# and F# solvers implement the same `ISolver` interface from `CSES.Core`

## Getting Started

### Prerequisites

- .NET 10.0 SDK or later

### Building the Project

```bash
dotnet build
```

## Running Tests

### Run All Tests

Run all tests for both C# and F#:
```bash
dotnet test
```

### Run Tests by Language

Run only C# tests:
```bash
dotnet test src/CSES.Solutions/CSES.CSharp.csproj
```

Run only F# tests:
```bash
dotnet test src/CSES.Solutions/CSES.FSharp.fsproj
```

### Run Tests by Problem

Run tests for a specific problem (both languages):
```bash
dotnet test --filter "FullyQualifiedName~WeirdAlgorithm"
```

Run tests for a specific problem (C# only):
```bash
dotnet test src/CSES.Solutions/CSES.CSharp.csproj --filter "FullyQualifiedName~WeirdAlgorithm"
```

Run tests for a specific problem (F# only):
```bash
dotnet test src/CSES.Solutions/CSES.FSharp.fsproj --filter "FullyQualifiedName~WeirdAlgorithm"
```

### Run Tests by Category

Run tests for an entire category (both languages):
```bash
dotnet test --filter "FullyQualifiedName~IntroductoryProblems"
```

Run tests for a category (C# only):
```bash
dotnet test src/CSES.Solutions/CSES.CSharp.csproj --filter "FullyQualifiedName~DynamicProgramming"
```

### Verbose Test Output

Run tests with detailed output showing each test as it runs:
```bash
dotnet test --filter "FullyQualifiedName~WeirdAlgorithm" --logger "console;verbosity=normal"
```

## Console Runner (Manual Testing)

The runner projects allow you to run a solver directly against a test input file and see any debug output.

### C# Runner

1. Edit `src/CSES.CSharp.Runner/Program.cs` to import the category namespace and instantiate your solver:
   ```csharp
   using CSES.Solutions.IntroductoryProblems;  // Change to your category

   var solver = new MissingNumberSolver();      // Change to your solver
   ```

2. Run the solver with an input file:
   ```bash
   dotnet run --project src/CSES.CSharp.Runner -- src/CSES.Solutions/IntroductoryProblems/MissingNumber/TestData/1.in
   ```

### F# Runner

1. Edit `src/CSES.FSharp.Runner/Program.fs` to instantiate your solver:
   ```fsharp
   open CSES.Solutions.IntroductoryProblems

   let solver: ISolver option = Some (WeirdAlgorithmSolver() :> ISolver)
   ```

2. Run the solver with an input file:
   ```bash
   dotnet run --project src/CSES.FSharp.Runner -- src/CSES.Solutions/IntroductoryProblems/WeirdAlgorithm/TestData/1.in
   ```

## Adding a New Problem

### Adding a C# Solution

#### Step 1: Create the Problem Folder

Create the folder structure:
```
src/CSES.Solutions/{Category}/{ProblemName}/CSharp/
src/CSES.Solutions/{Category}/{ProblemName}/TestData/
```

Example: `src/CSES.Solutions/IntroductoryProblems/MissingNumber/CSharp/`

#### Step 2: Create the Solver

Create `{ProblemName}Solver.cs` in the `CSharp/` folder:

```csharp
using CSES.Core;

namespace CSES.Solutions.CategoryName;

/// <summary>
/// Solver for CSES "Problem Name" problem.
/// Problem: https://cses.fi/problemset/task/XXXX
/// </summary>
public class ProblemNameSolver : ISolver
{
    public string Solve(string input)
    {
        // Parse input
        // Solve problem
        // Return output
    }
}
```

#### Step 3: Create the Test Class

Create `{ProblemName}Tests.cs` in the `CSharp/` folder:

```csharp
using Xunit;

namespace CSES.Solutions.CategoryName;

public class ProblemNameTests : BaseSolverTests<ProblemNameSolver>
{
    private const string TestDataFolder = "CategoryName/ProblemName/TestData";

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    // Add more test numbers as needed
    public void Test(int testNumber)
    {
        RunTest(TestDataFolder, testNumber);
    }
}
```

#### Step 4: Add Test Data

Add test files to the `TestData/` folder:
- `1.in`, `1.out`
- `2.in`, `2.out`
- etc.

#### Step 5: Run the Tests

```bash
dotnet test src/CSES.Solutions/CSES.CSharp.csproj --filter "FullyQualifiedName~ProblemName"
```

### Adding an F# Solution

#### Step 1: Create the Problem Folder

Create the folder structure (TestData may already exist from C#):
```
src/CSES.Solutions/{Category}/{ProblemName}/FSharp/
src/CSES.Solutions/{Category}/{ProblemName}/TestData/   # If not already present
```

#### Step 2: Create the Solver

Create `{ProblemName}Solver.fs` in the `FSharp/` folder:

```fsharp
namespace CSES.Solutions.CategoryName

open CSES.Core

/// Solver for CSES "Problem Name" problem.
/// Problem: https://cses.fi/problemset/task/XXXX
type ProblemNameSolver() =
    interface ISolver with
        member _.Solve(input: string) =
            // Parse input
            // Solve problem
            // Return output
            ""
```

#### Step 3: Create the Test Class

Create `{ProblemName}Tests.fs` in the `FSharp/` folder:

```fsharp
namespace CSES.Solutions.CategoryName

open Xunit

type ProblemNameTests() =
    inherit CSES.Solutions.BaseSolverTests<ProblemNameSolver>()

    static let testDataFolder = "CategoryName/ProblemName/TestData"

    [<Theory>]
    [<InlineData(1)>]
    [<InlineData(2)>]
    // Add more test numbers as needed
    member this.Test(testNumber: int) =
        this.RunTest(testDataFolder, testNumber)
```

#### Step 4: Update the F# Project File

Add the new `.fs` files to `src/CSES.Solutions/CSES.FSharp.fsproj` in the `<Compile>` section. **F# requires explicit file ordering**, so add them after `BaseSolverTests.fs`:

```xml
<ItemGroup>
  <Compile Include="BaseSolverTests.fs" />
  <Compile Include="CategoryName/ProblemName/FSharp/ProblemNameSolver.fs" />
  <Compile Include="CategoryName/ProblemName/FSharp/ProblemNameTests.fs" />
</ItemGroup>
```

#### Step 5: Run the Tests

```bash
dotnet test src/CSES.Solutions/CSES.FSharp.fsproj --filter "FullyQualifiedName~ProblemName"
```

## Namespace Conventions

Both C# and F# use the same namespace pattern:

- **Base classes** use `CSES.Solutions` (e.g., `BaseSolverTests`)
- **Category-specific code** uses `CSES.Solutions.{CategoryName}` (e.g., `CSES.Solutions.IntroductoryProblems`)
- **Language subfolders** (`CSharp/`, `FSharp/`) don't create additional namespace levels

**Examples:**

```csharp
// IntroductoryProblems/WeirdAlgorithm/CSharp/WeirdAlgorithmSolver.cs
namespace CSES.Solutions.IntroductoryProblems;
```

```fsharp
// IntroductoryProblems/WeirdAlgorithm/FSharp/WeirdAlgorithmSolver.fs
namespace CSES.Solutions.IntroductoryProblems
```

This allows C# and F# implementations to coexist in the same namespace.

## Features

### Multi-Language Support

- Solve problems in C#, F#, or both
- Shared test data between implementations
- Same `ISolver` interface for both languages

### Reusable Test Framework

The `BaseSolverTests<T>` class (available in both C# and F#) provides:
- Automatic test file discovery
- Input/output comparison
- Clear error messages
- Easy setup for new problems

### Flexible Test Execution

Use xunit filters to run:
- All tests: `dotnet test`
- One language: `dotnet test src/CSES.Solutions/CSES.CSharp.csproj`
- One category: `dotnet test --filter "FullyQualifiedName~IntroductoryProblems"`
- One problem: `dotnet test --filter "FullyQualifiedName~WeirdAlgorithm"`

### Clean Architecture

- **CSES.Core**: Shared `ISolver` interface
- **CSES.Solutions**: Problem solvers organized by category with shared test data
- **CSES.CSharp.Runner / CSES.FSharp.Runner**: Console runners for debugging

## Auto-Discovery Alternative

If you prefer to automatically run all test files without manually specifying them:

**C#:**
```csharp
[Theory]
[MemberData(nameof(GetAllTests))]
public void Test(int testNumber)
{
    RunTest(TestDataFolder, testNumber);
}

public static IEnumerable<object[]> GetAllTests()
    => GetTestNumbers(TestDataFolder);
```

**F#:**
```fsharp
// Use the TestHelpers module from BaseSolverTests.fs
static member GetAllTests() = TestHelpers.getTestNumbers testDataFolder

[<Theory>]
[<MemberData(nameof(ProblemNameTests.GetAllTests))>]
member this.Test(testNumber: int) =
    this.RunTest(testDataFolder, testNumber)
```

## Tips

1. Keep each solver focused on a single problem
2. Use meaningful variable names that match the problem description
3. Add comments explaining the algorithm if it's not obvious
4. Consider performance for problems with large inputs
5. Test edge cases (minimum values, maximum values, etc.)
6. Start with C# or F# - the shared TestData makes adding the other language easy
7. Use the console runner for debugging specific test cases with print statements
