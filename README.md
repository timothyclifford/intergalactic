# Merchant's Guide to the Galaxy

I chose to work with .NET core and C#, mainly because I haven't worked with the framework for some time and it's been going through a lot of change. I felt this was a good opportunity to get reacquainted and also to try and use some of the new C# 6 language features.

Overall, I like the direction .NET is headed. VS Code as an IDE is still not as nice to work with as VS Pro & R# but it's fast and lightweight. Running and debugging from the IDE is still a bit buggy so I was using the terminal instead.

In terms of design, I tried to keep it simple as it's easy to over engineer tasks such as this. I identified four variants in the test input:

- Unit definition
- Resource definition
- Unit question
- Resource question

These variants drove a good percentage of the design.

I separated the parsing of input and the generation of output as this allows input variants to be ordered in any way. For example, definitions can come before or after questions. If everything was done inline, definitions would always need to come before questions.

With each factory only really relying on a regular expression to create

I tried to do as much validation of input without going over the top. Input is validated when parsing each string within the factory `Create` methods. Validation also occurs when trying to answer a question - see `QueryManager.cs` - the code checks a definition exists for the unit and resource in question and also checks the units compose a valid roman numeral.

## Install .NET Core

1. Open a web browser
2. Navigate to https://www.microsoft.com/net/core
3. Follow the steps relevant to your platform

## To configure application

Application configuration is stored in `~/intergalactic/config.json` and controls the regular expressions for matching input. Ideally the roman numeral validation would also be managed from configuration - see `RomanNumeral.IsValid()`

## To run application

1. Open a terminal
2. Navigate to the project root (~/intergalactic/)
3. Execute the following command

```sh
dotnet run --project src/Galaxy.App --filename src/Galaxy.App/input.txt
```

The filename parameter can be replaced with the path of your own input file.

You should see output similar to the following:

```
pish tegj glob glob is 42
glob prok Silver is 68 Credits
glob prok Gold is 57800 Credits
glob prok Iron is 782 Credits
I have no idea what you are talking about
```

## To run tests

1. Open a terminal
2. Navigate to the project root (~/intergalactic/)
3. Execute the following command

```sh
dotnet test test/Galaxy.Core.Tests
```

You should see output similar to the following:

```
xUnit.net .NET CLI test runner (64-bit osx.10.11-x64)
  Discovering: Galaxy.Core.Tests
  Discovered:  Galaxy.Core.Tests
  Starting:    Galaxy.Core.Tests
  Finished:    Galaxy.Core.Tests
=== TEST EXECUTION SUMMARY ===
   Galaxy.Core.Tests  Total: 35, Errors: 0, Failed: 0, Skipped: 0, Time: 0.202s
SUMMARY: Total: 1 targets, Passed: 1, Failed: 0.
```