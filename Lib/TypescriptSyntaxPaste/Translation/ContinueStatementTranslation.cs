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
    public class ContinueStatementTranslation : StatementTranslation
    {
        public new ContinueStatementSyntax Syntax
        {
            get { return (ContinueStatementSyntax)base.Syntax; }
            set { base.Syntax = value; }
        }

        public ContinueStatementTranslation() { }
        public ContinueStatementTranslation(ContinueStatementSyntax syntax, SyntaxTranslation parent) : base(syntax, parent)
        {
        }

        protected override string InnerTranslate()
        {
            return Syntax.ToString();
        }
    }
}
