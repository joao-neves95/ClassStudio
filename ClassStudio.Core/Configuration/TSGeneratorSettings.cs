/*
 * Copyright (c) 2019-2020 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GPLv3.0 license (GNU General Public License v3.0),
 * located in the root of this project, under the name "LICENSE.md".
 *
 */

using System;

using CSharpToTypescript;
using CSharpToTypescript.VSIX;

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
