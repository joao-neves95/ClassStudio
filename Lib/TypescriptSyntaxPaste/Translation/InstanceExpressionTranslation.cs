﻿/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */

using Microsoft.CodeAnalysis.CSharp.Syntax;
using RoslynTypeScript.Translation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoslynTypeScript
{
    public abstract class InstanceExpressionTranslation :ExpressionTranslation
    {
        public InstanceExpressionTranslation(InstanceExpressionSyntax syntax, SyntaxTranslation parent) : base(syntax, parent)
        {
        }
    }
}
