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
    public class TypeParameterListTranslation : SyntaxTranslation
    {
        public new TypeParameterListSyntax Syntax
        {
            get { return (TypeParameterListSyntax)base.Syntax; }
            set { base.Syntax = value; }
        }
        public SeparatedSyntaxListTranslation<TypeParameterSyntax, TypeParameterTranslation> Parameters { get; set; }

        public TypeParameterListTranslation() { }

        public TypeParameterListTranslation(TypeParameterListSyntax syntax, SyntaxTranslation parent) : base( syntax, parent )
        {
            Parameters = syntax.Parameters.Get<TypeParameterSyntax, TypeParameterTranslation>( this );
        }

        private bool isExcludeConstraint;
        public bool IsExcludeConstraint
        {
            get { return this.isExcludeConstraint; }
            set
            {
                this.isExcludeConstraint = value;
                foreach (var item in Parameters.GetEnumerable())
                {
                    item.IsExcludeConstraint = value;
                }
            }
        }

        protected override string InnerTranslate()
        {
            return string.Format( "<{0}>", Parameters.Translate() );
        }
    }
}
