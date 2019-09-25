/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */

using Microsoft.CodeAnalysis.CSharp.Syntax;

/* Unmerged change from project 'TypescriptSyntaxPaste (net472)'
Before:
using RoslynTypeScript.Patch;
After:
using RoslynTypeScript.Contract;
using RoslynTypeScript.Patch;
*/
using RoslynTypeScript.Contract;
using System.Linq;
/* Unmerged change from project 'TypescriptSyntaxPaste (net472)'
Before:
using System.Threading.Tasks;
using RoslynTypeScript.Contract;
After:
using System.Threading.Tasks;
*/


namespace RoslynTypeScript.Translation
{
    public class ClassDeclarationTranslation : ClassStructDeclarationTranslation, IBaseExtended
    {
        public new ClassDeclarationSyntax Syntax
        {
            get { return (ClassDeclarationSyntax)base.Syntax; }
            set { base.Syntax = value; }
        }

        public ClassDeclarationTranslation(ClassDeclarationSyntax syntax, SyntaxTranslation parent) : base( syntax, parent )
        {
            var constructor = Members.GetEnumerable<ConstructorDeclarationTranslation>().FirstOrDefault();
            if (constructor == null)
            {
                return;
            }
        }

        public override void ApplyPatch()
        {
            base.ApplyPatch();
        }

        protected override string InnerTranslate()
        {

            string baseTranslation = BaseList?.Translate();

            return $@"{GetAttributeList()}export class {Syntax.Identifier}{TypeParameterList?.Translate()} {baseTranslation}
                {{
                {Members.Translate()} 
                }}";
        }
    }
}
