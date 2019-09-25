﻿/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */

using RoslynTypeScript.Translation;
using System.Linq;

namespace RoslynTypeScript.VirtualTranslation
{
    public class PredicateGenericNameTranslation : BaseFunctionGenericNameTranslation
    {
        public PredicateGenericNameTranslation(GenericNameTranslation genericNameTranslation) : base( genericNameTranslation )
        {
        }

        protected override string InnerTranslate()
        {
            var firstParam = genericNameTranslation.TypeArgumentList.Arguments.GetEnumerable().First();
            return $"(_:{firstParam.Translate()})=>boolean";
        }
    }
}
