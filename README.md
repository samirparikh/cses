# CSES Problem Solutions

Solutions to problems from the [CSES Problem Set](https://cses.fi/problemset/) written in C#.

## Project Structure

```
cses/
├── src/
│   ├── CSES.Core/              # Core interfaces and utilities
│   │   ├── ISolver.cs          # Interface all solvers implement
│   │   └── CSES.Core.csproj
│   └── CSES.Solutions/         # All problem solvers, tests, and test data
│       ├── BaseSolverTests.cs  # Base test class with helpers
│       ├── Introductory/       # Category folder
│       │   └── WeirdAlgorithm/ # Problem folder
│       │       ├── WeirdAlgorithmSolver.cs
│       │       ├── WeirdAlgorithmTests.cs
│       │       └── TestData/   # Test input/output files
│       │           ├── 1.in
│       │           ├── 1.out
│       │           ├── 2.in
│       │           └── 2.out
│       └── CSES.Solutions.csproj
├── CSES.slnx
└── README.md
```

**Note:** Each problem has its own folder containing the solver, tests, and test data all in one place for easy navigation.

## Getting Started

### Prerequisites

- .NET 10.0 SDK or later

### Building the Project

```bash
dotnet build
```

### Running Tests

Run all tests:
```bash
dotnet test
```

Run tests for a specific problem:
```bash
dotnet test --filter "FullyQualifiedName~WeirdAlgorithmTests"
```

Run tests for a specific category:
```bash
dotnet test --filter "FullyQualifiedName~Introductory"
```

Run a specific test case:
```bash
dotnet test --filter "FullyQualifiedName~WeirdAlgorithmTests.Test" --filter "DisplayName~testNumber=1"
```

## Adding a New Problem

### Step 1: Create the Problem Folder

Create a new folder for your problem in `src/CSES.Solutions/{Category}/{ProblemName}/`

For example: `src/CSES.Solutions/Introductory/MissingNumber/`

### Step 2: Create the Solver

Create the solver class in the problem folder:

`src/CSES.Solutions/{Category}/{ProblemName}/{ProblemName}Solver.cs`

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

### Step 3: Create the Test Class

Create the test class in the same problem folder:

`src/CSES.Solutions/{Category}/{ProblemName}/{ProblemName}Tests.cs`

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

### Step 4: Add Test Data

Create a `TestData` folder in the problem folder and add test files:

`src/CSES.Solutions/{Category}/{ProblemName}/TestData/`
- `1.in`, `1.out`
- `2.in`, `2.out`
- etc.

The `.in` files contain the input and `.out` files contain the expected output.

**Complete Example Structure:**
```
src/CSES.Solutions/Introductory/MissingNumber/
├── MissingNumberSolver.cs
├── MissingNumberTests.cs
└── TestData/
    ├── 1.in
    ├── 1.out
    ├── 2.in
    └── 2.out
```

### Step 5: Run the Tests

```bash
dotnet test --filter "FullyQualifiedName~ProblemNameTests"
```

## Features

### Reusable Test Framework

The `BaseSolverTests<T>` class provides:
- Automatic test file discovery
- Input/output comparison
- Clear error messages
- Easy setup for new problems

### Flexible Test Execution

Use xunit filters to run:
- All tests: `dotnet test`
- Tests for one category: `dotnet test --filter "FullyQualifiedName~CategoryName"`
- Tests for one problem: `dotnet test --filter "FullyQualifiedName~ProblemNameTests"`
- A specific test case: Add additional filters for test numbers

### Clean Architecture

- **CSES.Core**: Shared interfaces and utilities
- **CSES.Solutions**: Problem solvers, tests, and test data organized by category and problem
  - Each problem has its own folder containing everything related to that problem
  - Navigate to one folder to work on a complete problem

## Auto-Discovery Alternative

If you prefer to automatically run all test files without manually specifying them, you can use the `MemberData` approach in your test class:

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

This will automatically discover all `*.in` files and run tests for them.

## Tips

1. Keep each solver focused on a single problem
2. Use meaningful variable names that match the problem description
3. Add comments explaining the algorithm if it's not obvious
4. Consider performance for problems with large inputs
5. Test edge cases (minimum values, maximum values, etc.)
