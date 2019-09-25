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
    public abstract class BaseArgumentListTranslation : CSharpSyntaxTranslation
    {
        public new BaseArgumentListSyntax Syntax
        {
            get { return (BaseArgumentListSyntax)base.Syntax; }
            set { base.Syntax = value; }
        }

        public BaseArgumentListTranslation() { }
        public BaseArgumentListTranslation(BaseArgumentListSyntax syntax, SyntaxTranslation parent) : base( syntax, parent )
        {
            Arguments = syntax.Arguments.Get<ArgumentSyntax, ArgumentTranslation>( this );
        }

        public SeparatedSyntaxListTranslation<ArgumentSyntax, ArgumentTranslation> Arguments { get; set; }
    }
}
