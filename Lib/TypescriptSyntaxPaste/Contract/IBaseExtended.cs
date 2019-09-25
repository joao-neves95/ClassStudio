/*
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
using RoslynTypeScript.Translation;
using System;
*/
using
/* Unmerged change from project 'TypescriptSyntaxPaste (net472)'
Before:
using System.Threading.Tasks;
using RoslynTypeScript.Translation;
After:
using System.Threading.Tasks;
*/
RoslynTypeScript.Translation;

namespace RoslynTypeScript.Contract
{
    public interface IBaseExtended
    {
        BaseListTranslation BaseList { get; set; }
    }
}
