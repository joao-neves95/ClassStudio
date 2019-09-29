﻿/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */

using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace RoslynTypeScript.Translation
{
    public class InvocationExpressionTranslation : ExpressionTranslation
    {
        public new InvocationExpressionSyntax Syntax
        {
            get { return (InvocationExpressionSyntax)base.Syntax; }
            set { base.Syntax = value; }
        }

        public ExpressionTranslation Expression { get; set; }
        public ArgumentListTranslation ArgumentList { get; set; }

        public InvocationExpressionTranslation() { }

        public InvocationExpressionTranslation(InvocationExpressionSyntax syntax, SyntaxTranslation parent) : base( syntax, parent )
        {
            Expression = syntax.Expression.Get<ExpressionTranslation>( this );
            ArgumentList = syntax.ArgumentList.Get<ArgumentListTranslation>( this );
            if (Expression is MemberAccessExpressionTranslation)
            {
                var memberAccess = (MemberAccessExpressionTranslation)Expression;
                memberAccess.IsInInvocation = true;
            }
        }

        public override void ApplyPatch()
        {
            base.ApplyPatch();
        }


        protected override string InnerTranslate()
        {
            var invocationName = Syntax.Expression.ToString();
            if (invocationName.EndsWith( "ReferenceEquals" ))
            {
                return $"ReferenceEquals{ArgumentList.Translate()}";
            }

            var name = this.Syntax.Expression.ToString();

            if (Expression is MemberAccessExpressionTranslation)
            {
                var memberAccess = (MemberAccessExpressionTranslation)Expression;
                memberAccess.IsInInvocation = true;

            }

            return string.Format( "{0}{1}", Expression.Translate(), ArgumentList.Translate() );
        }
    }
}
