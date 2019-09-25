﻿/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */

using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;

namespace RoslynTypeScript.Translation
{
    public class ThrowStatementTranslation : StatementTranslation
    {
        public new ThrowStatementSyntax Syntax
        {
            get { return (ThrowStatementSyntax)base.Syntax; }
            set { base.Syntax = value; }
        }

        public ThrowStatementTranslation() { }
        public ThrowStatementTranslation(ThrowStatementSyntax syntax, SyntaxTranslation parent) : base( syntax, parent )
        {
            Expression = syntax.Expression.Get<ExpressionTranslation>( this );
        }

        public ExpressionTranslation Expression { get; set; }

        protected override string InnerTranslate()
        {

            var err = "err";
            // try to find exception variable from catch clause
            if (Expression == null)
            {
                var tokenText = this.Syntax.Ancestors().OfType<CatchClauseSyntax>().FirstOrDefault()?.Declaration?.Identifier.ValueText;

                err = tokenText ?? err;

            }
            else
            {
                err = Expression.Translate();
            }

            return $"throw {err};";
        }
    }
}
