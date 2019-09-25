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
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;
After:
using System.Threading.Tasks;
*/


namespace RoslynTypeScript.Translation
{
    public class MemberAccessExpressionTranslation : ExpressionTranslation
    {
        public new MemberAccessExpressionSyntax Syntax
        {
            get { return (MemberAccessExpressionSyntax)base.Syntax; }
            set { base.Syntax = value; }
        }

        public ExpressionTranslation Expression { get; set; }
        public SimpleNameTranslation Name { get; set; }

        public bool IsInInvocation { get; set; }

        public MemberAccessExpressionTranslation(MemberAccessExpressionSyntax syntax, SyntaxTranslation parent) : base( syntax, parent )
        {
            Expression = syntax.Expression.Get<ExpressionTranslation>( this );
            Name = syntax.Name.Get<SimpleNameTranslation>( this );

            var simpleName = Name as SimpleNameTranslation;

            if (simpleName != null)
            {
                simpleName.DetectApplyThis = false;
            }
        }

        public override void ApplyPatch()
        {
            base.ApplyPatch();
            var genericTranslation = Expression as GenericNameTranslation;
            if (genericTranslation != null)
            {
                var identifier = Name as IdentifierNameTranslation;
                if (identifier != null && identifier.IsStatic)
                {
                    genericTranslation.ExcludeTypeParameter = true;
                    if (IsInInvocation)
                    {
                        identifier.TypeArgumentList = genericTranslation.TypeArgumentList;
                    }

                }
            }
        }

        protected override string InnerTranslate()
        {

            string str = Syntax.ToString();

            return NormalTranslate();
        }

        private string NormalTranslate()
        {
            return string.Format( "{0}{1}{2}", Expression.Translate(), Syntax.OperatorToken.ToString(), Name.Translate() );
        }
    }
}
