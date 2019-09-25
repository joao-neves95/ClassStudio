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
After:
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RoslynTypeScript.Translation;
using System;
*/
using RoslynTypeScript.Translation;
using System.Linq;
/* Unmerged change from project 'TypescriptSyntaxPaste (net472)'
Before:
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RoslynTypeScript.Translation;
After:
using System.Threading.Tasks;
*/


namespace RoslynTypeScript.Patch
{
    /// <summary>
    /// Not using at this moment!!!!
    /// try to find constructor and set default value for field which is number, boolean. Because
    /// in javascript all fields are undefined at the first place.
    /// </summary>
    public class FieldInitializePatch : Patch
    {
        public void Apply(ClassDeclarationTranslation typeTranslation)
        {
            var fields = typeTranslation.Members.GetEnumerable<FieldDeclarationTranslation>();
            if (!fields.Any())
            {
                return;
            }

            ConstructorDeclarationTranslation constructor = FindConstructor( typeTranslation );
            if (constructor == null)
            {
                return;
            }

            if (!typeTranslation.HasExplicitBase())
            {
                return;
            }

            foreach (FieldDeclarationTranslation field in fields)
            {
                if (field.Modifiers.IsStatic)
                {
                    continue;
                }

                AssignmentExpressionTranslation assignment = BuildAssignment( field );
                constructor.Body.Statements.Insert( 0, assignment );
            }
        }

        private ConstructorDeclarationTranslation FindConstructor(TypeDeclarationTranslation typeTranslation)
        {
            var constructor = typeTranslation.Members.GetEnumerable<ConstructorDeclarationTranslation>().FirstOrDefault( f => !f.IsDeclarationOverload );
            return constructor;
        }

        private AssignmentExpressionTranslation BuildAssignment(FieldDeclarationTranslation field)
        {
            var declarator = field.Declaration.Variables.GetEnumerable().First();
            var initializeStr = declarator.GetInitializerStr();
            string statement = $"this.{declarator.Identifier.Translate()}{initializeStr};";
            return new AssignmentExpressionTranslation() { SyntaxString = statement };
        }
    }
}
