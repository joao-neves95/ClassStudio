/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */


/* Unmerged change from project 'TypescriptSyntaxPaste (net472)'
Before:
using Microsoft.CodeAnalysis.CSharp;
After:
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
*/
using Microsoft.CodeAnalysis;
/* Unmerged change from project 'TypescriptSyntaxPaste (net472)'
Before:
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
After:
using System.Threading.Tasks;
*/


namespace RoslynTypeScript.Translation
{
    public abstract class CSharpSyntaxTranslation : SyntaxTranslation
    {
        public CSharpSyntaxTranslation() { }
        public CSharpSyntaxTranslation(SyntaxNode syntax, SyntaxTranslation parent) : base( syntax, parent )
        {
        }
    }
}
