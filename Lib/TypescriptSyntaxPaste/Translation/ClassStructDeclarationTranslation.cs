﻿/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */


/* Unmerged change from project 'TypescriptSyntaxPaste (net472)'
Before:
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RoslynTypeScript.Patch;
After:
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RoslynTypeScript.Patch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Syntax;
using System.Threading.Tasks;
*/

namespace RoslynTypeScript.Translation
{
    public abstract class ClassStructDeclarationTranslation : TypeDeclarationTranslation
    {
        public ClassStructDeclarationTranslation(TypeDeclarationSyntax syntax, SyntaxTranslation parent) : base( syntax, parent )
        {
            if (syntax.BaseList != null)
            {
                BaseList = syntax.BaseList.Get<BaseListTranslation>( this );
            }
        }

        public override void ApplyPatch()
        {
            base.ApplyPatch();
            // ConstructorPatch constructorPatch = new ConstructorPatch();
            // constructorPatch.Apply(this);
        }

        public BaseListTranslation BaseList { get; set; }

        public bool HasExplicitBase()
        {
            if (Syntax.BaseList == null)
            {
                return false;
            }

            return BaseList.GetBaseClass() != null;
        }
    }
}
