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
    public class TypeArgumentListTranslation : CSharpSyntaxTranslation
    {
        public new TypeArgumentListSyntax Syntax
        {
            get { return (TypeArgumentListSyntax)base.Syntax; }
            set { base.Syntax = value; }
        }

        public TypeArgumentListTranslation() { }
        public TypeArgumentListTranslation(TypeArgumentListSyntax syntax, SyntaxTranslation parent) : base( syntax, parent )
        {
            Arguments = syntax.Arguments.Get<TypeSyntax, TypeTranslation>( this );
        }

        public SeparatedSyntaxListTranslation<TypeSyntax, TypeTranslation> Arguments { get; set; }

        protected override string InnerTranslate()
        {
            return $"<{Arguments.Translate()}> ";
        }
    }
}
