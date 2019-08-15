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
    public abstract class BaseParameterListTranslation : CSharpSyntaxTranslation
    {
        public new BaseParameterListSyntax Syntax
        {
            get { return (BaseParameterListSyntax)base.Syntax; }
            set { base.Syntax = value; }
        }

        public BaseParameterListTranslation() { }
        public BaseParameterListTranslation(BaseParameterListSyntax syntax, SyntaxTranslation parent) : base(syntax, parent)
        {
            Parameters = syntax.Parameters.Get<ParameterSyntax, ParameterTranslation>(this);
        }

        public SeparatedSyntaxListTranslation<ParameterSyntax,ParameterTranslation> Parameters { get; set; }

        protected override string InnerTranslate()
        {
            return Syntax.ToString();
        }
    }
}
