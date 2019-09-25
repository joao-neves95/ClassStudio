/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */

using Microsoft.CodeAnalysis;

namespace RoslynTypeScript.Translation
{
    public class GenericTranslation : CSharpSyntaxTranslation

    /* Unmerged change from project 'TypescriptSyntaxPaste (net472)'
    Before:
        {

            public GenericTranslation(SyntaxNode syntax,  SyntaxTranslation parent) : base(syntax, parent)
    After:
        {

            public GenericTranslation(SyntaxNode syntax,  SyntaxTranslation parent) : base(syntax, parent)
    */
    {

        public GenericTranslation(SyntaxNode syntax, SyntaxTranslation parent) : base( syntax, parent )
        {
        }

        protected override string InnerTranslate()
        {
            return Syntax.ToString();
        }
    }
}
