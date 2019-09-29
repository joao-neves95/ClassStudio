﻿/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */

using Microsoft.CodeAnalysis.CSharp.Syntax;
using RoslynTypeScript.Translation;

namespace RoslynTypeScript.Contract
{
    public interface ITypeParameterConstraint
    {
        TypeParameterListTranslation TypeParameterList { get; set; }

        SyntaxListTranslation<TypeParameterConstraintClauseSyntax, TypeParameterConstraintClauseTranslation> ConstraintClauses { get; set; }
    }
}
