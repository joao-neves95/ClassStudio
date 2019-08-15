# TypescriptSyntaxPaste

----

**Original Repository: https://github.com/nhabuiduc/TypescriptSyntaxPaste**

Adapted and migrated to .NET Core 3.

It does not work as a Visual Studio Extension anymore.<br/>
Its intent now, is to be used as a library.

----

- Visual Studio Extension which converts C# SYNTAX to Typescript SYNTAX.

**BRIEF CODE INFORMATION**

Almost all converting classes are in folder Translation, which for each file containing the convert method to convert one kind of
syntax (C#) to Typescript. For example ````ClassDeclarationSyntax```` in Roslyn will be ````ClassDeclarationTranslation```` in this project.

Let say you want convert :
in C#: ````class A {}````
typescript: ````class myA{}````

you just need to navigate to class ClassDeclarationTranslation in project, then change this line:
````
 return $@"{GetAttributeList()}export class {Syntax.Identifier}{TypeParameterList?.Translate()} {baseTranslation}
           {{
           {Members.Translate()}
           }}";
 ````
to:
````
 return $@"{GetAttributeList()}export class my{Syntax.Identifier}{TypeParameterList?.Translate()} {baseTranslation}
           {{
           {Members.Translate()}
           }}";
````

For more information: http://bdnprojects.net/CSharpSyntaxParser/
