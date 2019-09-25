﻿/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */

using Microsoft.CodeAnalysis.CSharp.Syntax;
/* Unmerged change from project 'TypescriptSyntaxPaste (net472)'
Before:
using System;
After:
using RoslynTypeScript.Patch;
using System;
*/

/* Unmerged change from project 'TypescriptSyntaxPaste (net472)'
Before:
using System.Threading.Tasks;
using RoslynTypeScript.Patch;
After:
using System.Threading.Tasks;
*/


namespace RoslynTypeScript.Translation
{
    public class LabeledStatementTranslation : SyntaxTranslation
    {
        public new LabeledStatementSyntax Syntax
        {
            get { return (LabeledStatementSyntax)base.Syntax; }
            set { base.Syntax = value; }
        }

        public LabeledStatementTranslation() { }
        public LabeledStatementTranslation(LabeledStatementSyntax syntax, SyntaxTranslation parent) : base( syntax, parent )
        {
            Statement = syntax.Statement.Get<StatementTranslation>( this );
        }

        public StatementTranslation Statement { get; set; }

        public override void ApplyPatch()
        {
            base.ApplyPatch();

        }

        public bool TakeCare { get; set; }

        public bool IgnoreLabel { get; set; }

        protected override string InnerTranslate()
        {

            //string add = TakeCare ? "(^_^)" :"";
            string label = IgnoreLabel ? string.Empty : Syntax.Identifier.ToString() + ":";
            return $@"{label}
                 {Statement.Translate()}";
        }
    }
}
