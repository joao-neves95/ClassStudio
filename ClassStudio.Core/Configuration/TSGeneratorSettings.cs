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
        public bool IsConvertToInterface { get { return true; } set => throw new NotImplementedException(); }
        public bool IsInterfaceOptionalProperties { get { return false; } set => throw new NotImplementedException(); }
        public TypeNameReplacementData[] ReplacedTypeNameArray { get { return new TypeNameReplacementData[0]; } set => throw new NotImplementedException(); }
    }
}
