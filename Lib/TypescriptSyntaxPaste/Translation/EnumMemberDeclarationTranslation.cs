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
    public class EnumMemberDeclarationTranslation : MemberDeclarationTranslation
    {
        public new EnumMemberDeclarationSyntax Syntax
        {
            get { return (EnumMemberDeclarationSyntax)base.Syntax; }
            set { base.Syntax = value; }
        }
        public EnumMemberDeclarationTranslation() { }
        public EnumMemberDeclarationTranslation(EnumMemberDeclarationSyntax syntax, SyntaxTranslation parent) : base( syntax, parent )
        {
        }


        protected override string InnerTranslate()
        {
            return Syntax.ToString();
        }
    }
}
