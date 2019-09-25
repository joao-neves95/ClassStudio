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
    public abstract class TypeTranslation : ExpressionTranslation
    {
        public TypeTranslation() { }
        public TypeTranslation(TypeSyntax syntax, SyntaxTranslation parent) : base( syntax, parent )
        {
        }

        public bool ActAsTypeParameter { get; set; }

        public virtual bool IsPrimitive
        {
            get { return false; }
        }

        public virtual string GetTypeIgnoreGeneric()
        {
            return this.Translate();
        }
    }
}
