﻿/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoslynTypeScript.Translation
{
    public class AccessorListTranslation : CSharpSyntaxTranslation
    {

        public SyntaxListTranslation<AccessorDeclarationSyntax, AccessorDeclarationTranslation> Accessors { get; set; }

        public AccessorListTranslation(AccessorListSyntax syntax, SyntaxTranslation parent) : base(syntax, parent)
        {
            Accessors = syntax.Accessors.Get<AccessorDeclarationSyntax, AccessorDeclarationTranslation>(this);
        }

        public void SetModifier(SyntaxTokenListTranslation modifiers)
        {
            foreach (var item in Accessors.GetEnumerable())
            {
                item.ParentModifiers = modifiers.TokenListSyntax.Get(item);
            }
        }

        public new AccessorListSyntax Syntax
        {
            get { return (AccessorListSyntax)base.Syntax; }
            set { base.Syntax = value; }
        }

        protected override string InnerTranslate()
        {
            return Accessors.Translate();
        }

        public bool IsShorten()
        {
            return Accessors.GetEnumerable().First().IsShorten();
        }
    }
}
