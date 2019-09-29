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
    public class ArgumentTranslation : SyntaxTranslation
    {
        public new ArgumentSyntax Syntax
        {
            get { return (ArgumentSyntax)base.Syntax; }
            set { base.Syntax = value; }
        }

        public ArgumentTranslation() { }

        public ArgumentTranslation(ArgumentSyntax syntax, SyntaxTranslation parent) : base( syntax, parent )
        {
            Expression = syntax.Expression.Get<ExpressionTranslation>( this );
        }


        /* Unmerged change from project 'TypescriptSyntaxPaste (net472)'
        Before:
                public ExpressionTranslation Expression { get; set; }


                public bool IsExistingRefOrOutKeyword
        After:
                public ExpressionTranslation Expression { get; set; }


                public bool IsExistingRefOrOutKeyword
        */
        public ExpressionTranslation Expression { get; set; }


        public bool IsExistingRefOrOutKeyword
        {
            get { return !Syntax.RefOrOutKeyword.Span.IsEmpty; }
        }

        public override void ApplyPatch()
        {
            base.ApplyPatch();
            Helper.ApplyFunctionBindToCorrectContext( this.Expression );
        }

        protected override string InnerTranslate()
        {

            string nameColon = string.Empty;
            if (Syntax.NameColon != null)
            {
                nameColon = $"/*{Syntax.NameColon.ToString()}*/";
            }
            return $"{nameColon}{Expression.Translate()}";
        }
    }
}
