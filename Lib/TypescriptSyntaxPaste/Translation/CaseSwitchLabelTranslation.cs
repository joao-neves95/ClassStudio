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
    public class CaseSwitchLabelTranslation : SwitchLabelTranslation
    {
        public new CaseSwitchLabelSyntax Syntax
        {
            get { return (CaseSwitchLabelSyntax)base.Syntax; }
            set { base.Syntax = value; }
        }

        public CaseSwitchLabelTranslation() { }
        public CaseSwitchLabelTranslation(CaseSwitchLabelSyntax syntax, SyntaxTranslation parent) : base( syntax, parent )
        {
            Value = syntax.Value.Get<ExpressionTranslation>( this );
        }


        public ExpressionTranslation Value { get; set; }

        protected override string InnerTranslate()
        {
            return $"case {Value.Translate()}:";
        }
    }
}
