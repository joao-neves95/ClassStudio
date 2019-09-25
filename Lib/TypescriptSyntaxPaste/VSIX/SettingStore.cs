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
using Microsoft.VisualStudio.Settings;
After:
using Microsoft.VisualStudio.Settings;
using Microsoft.Collections.Shell;
using Microsoft.VisualStudio.Shell.Settings;
using System;
using System.Collections.Generic;
using System.IO;
*/
using Microsoft.VisualStudio.Settings;
using Microsoft.VisualStudio.Shell;
/* Unmerged change from project 'TypescriptSyntaxPaste (net472)'
Before:
using System.Linq;

/* Unmerged change from project 'TypescriptSyntaxPaste (net472)'
After:
/* Unmerged change from project 'TypescriptSyntaxPaste (net472)'
*/


/* Unmerged change from project 'TypescriptSyntaxPaste (net472)'
Before:
using Microsoft.VisualStudio.Shell;
After:
using Microsoft.Text;
*/
using System.IO;

/* Unmerged change from project 'TypescriptSyntaxPaste (net472)'
Before:
using System.Threading.Tasks;
After:
using System.Linq;
using System.Threading.Tasks;
*/
/* Unmerged change from project 'TypescriptSyntaxPaste (net472)'
Before:
using System.IO;
After:
using System.Xml.Serialization;
*/


namespace TypescriptSyntaxPaste.VSIX
{
    public class SettingStore : ISettingStore
    {
        public static SettingStore Instance = new SettingStore();

        private WritableSettingsStore userSettingsStore;

        private const string IsConvertToInterfaceConst = "IsConvertToInterface";
        private const string IsConvertMemberToCamelCaseConst = "IsConvertMemberToCamelCase";
        private const string CollectionPath = "TypescriptSyntaxPaste";
        private const string IsConvertListToArrayConst = "IsConvertListToArray";
        private const string ReplacedTypeNameArrayConst = "ReplacedTypeNameArray";
        private const string AddIPrefixInterfaceDeclarationConst = "AddIPrefixInterfaceDeclaration";
        private const string IsInterfaceOptionalPropertiesConsts = "IsInterfaceOptionalProperties";

        protected SettingStore()
        {
            SettingsManager settingsManager = new ShellSettingsManager( ServiceProvider.GlobalProvider );
            userSettingsStore = settingsManager.GetWritableSettingsStore( SettingsScope.UserSettings );
            if (!userSettingsStore.CollectionExists( CollectionPath ))
            {
                userSettingsStore.CreateCollection( CollectionPath );
            }
        }

        public bool IsConvertMemberToCamelCase
        {
            get
            {
                if (!userSettingsStore.PropertyExists( CollectionPath, IsConvertMemberToCamelCaseConst ))
                {
                    return false;
                }

                return userSettingsStore.GetBoolean( CollectionPath, IsConvertMemberToCamelCaseConst );
            }
            set
            {

                userSettingsStore.SetBoolean( CollectionPath, IsConvertMemberToCamelCaseConst, value );
            }
        }

        public bool IsConvertToInterface
        {
            get
            {
                if (!userSettingsStore.PropertyExists( CollectionPath, IsConvertToInterfaceConst ))
                {
                    return false;
                }

                return userSettingsStore.GetBoolean( CollectionPath, IsConvertToInterfaceConst );
            }
            set
            {

                userSettingsStore.SetBoolean( CollectionPath, IsConvertToInterfaceConst, value );
            }
        }

        public bool IsConvertListToArray
        {
            get
            {
                if (!userSettingsStore.PropertyExists( CollectionPath, IsConvertListToArrayConst ))
                {
                    return false;
                }

                return userSettingsStore.GetBoolean( CollectionPath, IsConvertListToArrayConst );
            }
            set
            {

                userSettingsStore.SetBoolean( CollectionPath, IsConvertListToArrayConst, value );
            }
        }

        public bool IsInterfaceOptionalProperties
        {
            get
            {
                if (!userSettingsStore.PropertyExists( CollectionPath, IsInterfaceOptionalPropertiesConsts ))
                {
                    return false;
                }

                return userSettingsStore.GetBoolean( CollectionPath, IsInterfaceOptionalPropertiesConsts );
            }
            set
            {

                userSettingsStore.SetBoolean( CollectionPath, IsInterfaceOptionalPropertiesConsts, value );
            }
        }

        XmlSerializer serializer = new XmlSerializer( typeof( TypeNameReplacementData[] ) );
        private TypeNameReplacementData[] replacedTypeNameArray;

        public TypeNameReplacementData[] ReplacedTypeNameArray
        {
            get
            {
                if (replacedTypeNameArray != null)
                {
                    return replacedTypeNameArray;
                }

                if (!userSettingsStore.PropertyExists( CollectionPath, ReplacedTypeNameArrayConst ))
                {
                    return new TypeNameReplacementData[] {
                        new TypeNameReplacementData
                        {
                            NewTypeName = "Date",
                            OldTypeName = "DateTimeOffset"
                        },
                        new TypeNameReplacementData
                        {
                            NewTypeName = "Date",
                            OldTypeName = "DateTime"
                        }
                    };
                }

                using (StringReader textReader = new StringReader( userSettingsStore.GetString( CollectionPath, ReplacedTypeNameArrayConst ) ))
                {
                    replacedTypeNameArray = (TypeNameReplacementData[])serializer.Deserialize( textReader );
                }

                return replacedTypeNameArray;

            }
            set
            {
                using (StringWriter textWriter = new StringWriter())
                {
                    serializer.Serialize( textWriter, value );
                    userSettingsStore.SetString( CollectionPath, ReplacedTypeNameArrayConst, textWriter.ToString() );
                    replacedTypeNameArray = value;
                }
            }
        }

        public bool AddIPrefixInterfaceDeclaration
        {
            get
            {
                if (!userSettingsStore.PropertyExists( CollectionPath, AddIPrefixInterfaceDeclarationConst ))
                {
                    return false;
                }

                return userSettingsStore.GetBoolean( CollectionPath, AddIPrefixInterfaceDeclarationConst );
            }
            set
            {

                userSettingsStore.SetBoolean( CollectionPath, AddIPrefixInterfaceDeclarationConst, value );
            }
        }
    }
}
