/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */

using Microsoft.CodeAnalysis.CSharp.Syntax;
/* Unmerged change from project 'TypescriptSyntaxPaste (net472)'
Before:
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;
After:
using System.Threading.Tasks;
*/


namespace RoslynTypeScript.Translation
{
    public class GotoStatementTranslation : StatementTranslation
    {
        public new GotoStatementSyntax Syntax
        {
            get { return (GotoStatementSyntax)base.Syntax; }
            set { base.Syntax = value; }
        }

        public GotoStatementTranslation() { }
        public GotoStatementTranslation(GotoStatementSyntax syntax, SyntaxTranslation parent) : base( syntax, parent )
        {

        }

        public ExpressionTranslation Expression { get; set; }

        protected override string InnerTranslate()
        {

            return Syntax.ToString();
        }
    }
}
