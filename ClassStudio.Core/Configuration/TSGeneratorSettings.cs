﻿/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */

using System;
using System.Collections.Generic;
using System.Text;
using TypescriptSyntaxPaste;
using TypescriptSyntaxPaste.VSIX;

namespace ClassStudio.Core.Configuration
{
    public class TSGeneratorSettings : ISettingStore
    {
        public bool AddIPrefixInterfaceDeclaration { get { return true; } set => throw new NotImplementedException(); }

        public bool IsConvertListToArray { get { return true; } set => throw new NotImplementedException(); }

        public bool IsConvertMemberToCamelCase { get { return false; } set => throw new NotImplementedException(); }

        public bool IsConvertToInterface { get { return false; } set => throw new NotImplementedException(); }

        public bool IsInterfaceOptionalProperties { get { return false; } set => throw new NotImplementedException(); }

        public TypeNameReplacementData[] ReplacedTypeNameArray { get { return new TypeNameReplacementData[0]; } set => throw new NotImplementedException(); }
    }
}
