# CHANGELOG

&nbsp;

#### *v0.6.2 - 29/06/2021

  - Backend:
    - Updated LibCSharpToTypescript, which fixed C# to TypeScript compilation on this .NET 5 environment.
    - Updated dependencies.
  - UI:
    - Improved the input/output code language selection (drop downs) using a conversion mapping
      adjacency list, with dynamic update.
    - Fixed dependency vulnerabilities.

&nbsp;

#### v0.6.1 - 07/04/2021

  - Backend:
    - Fixed an issue with the dispose of a stream by Xml2CSharp, which made XML/JSON to CSharp not work.
    - Solved a memory leak on the ConverterService.
    - Other small fixes, improvements and optimizations.
    - Update to Xml2CSharp as a sub-module and use new async method.
    - Update LibCSharpToTypescript from v1.0.3 to v1.0.4.
    - Migrate from .NET Core 3.1 to .NET 5.
    - Updated other dependencies.
  - UI:
    - Fixed a typo on the Generator's "Compile" button.
    - Migrate Electron v9.31.2 to v11.5.1
    - Migrate Angular 8 to 11.2.
    - Updated other dependencies.

&nbsp;

#### v0.6.0 - 12/12/2020

  - Added JSON to C# class generation.
  - Big internal refactorings.

&nbsp;

#### v0.5.0 - 11/11/2020

  - (UI) Added the ability to remove selected files.
  - (Backend) Multiple internal refactorings and improvements.
  - (Global) Updated multiple dependencies.

&nbsp;

#### v0.4.1 - 22/11/2019

  - Fixed a bug that caused issues with the installer.\
    When the user updated ClassStudio it continued
    with the previous cached version.

&nbsp;

#### v0.4.0 - 13/10/2019

  - Added support for having files and directories as input, instead of only code.
  - Solved multiple memory leaks.
  - Small fix on the Generator header whitespace.
  - Updated everything to the release version of .NET Core 3.
  - Multiple small internal refactorings.

&nbsp;

#### v0.3.0 - 29/09/2019

  - Migrated from a vanilla JavaScript MVC frontend solution to Angular 8.
  - Added an update system. Currently launching during startup.
  - Cleanup the code.

&nbsp;

#### v0.2.0 - 01/09/2019

  - Added suport for C# to TypeScript class generation.
  - Fixed the input and output language selectors (UI).
  - Muliple other fixes and code refactorings.

&nbsp;

#### v0.1.0 - 18/08/2019

  - First version. XML to C# class generator.
