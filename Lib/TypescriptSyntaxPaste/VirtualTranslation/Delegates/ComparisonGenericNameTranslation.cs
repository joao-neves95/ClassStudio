﻿/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoslynTypeScript.Translation;

namespace RoslynTypeScript.VirtualTranslation.Delegates
{
    public class ComparisonGenericNameTranslation : BaseFunctionGenericNameTranslation
    {
        public ComparisonGenericNameTranslation(GenericNameTranslation genericNameTranslation) : base(genericNameTranslation)
        {
        }

        protected override string InnerTranslate()
        {
            var firstParam = genericNameTranslation.TypeArgumentList.Arguments.GetEnumerable().First();
            string firstParamStr = firstParam.Translate();
            return $"(_:{firstParamStr}, __:{firstParamStr})=> number";
        }
    }
}
