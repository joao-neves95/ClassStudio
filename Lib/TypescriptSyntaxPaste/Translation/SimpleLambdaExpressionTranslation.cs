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
    public class SimpleLambdaExpressionTranslation : ExpressionTranslation
    {
        public new SimpleLambdaExpressionSyntax Syntax
        {
            get { return (SimpleLambdaExpressionSyntax)base.Syntax; }
            set { base.Syntax = value; }
        }

        public SimpleLambdaExpressionTranslation() { }
        public SimpleLambdaExpressionTranslation(SimpleLambdaExpressionSyntax syntax, SyntaxTranslation parent) : base( syntax, parent )
        {
            Body = syntax.Body.Get<CSharpSyntaxTranslation>( this );
            Parameter = syntax.Parameter.Get<ParameterTranslation>( this );
        }

        public CSharpSyntaxTranslation Body { get; set; }
        public ParameterTranslation Parameter { get; set; }

        protected override string InnerTranslate()
        {
            //return Syntax.ToString();
            return $"{Parameter.Translate()} => {Body.Translate()}";
        }
    }
}
