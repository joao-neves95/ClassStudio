/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */

using ClassStudio.Core.Utils;
using System.IO;
using Xml2CSharp;

namespace ClassStudio.Core.Generators
{
    public static class XML
    {
        public static string ToCSharp(string xml)
        {
            ClassInfoWriter classInfoWriter = new ClassInfoWriter(
                new Xml2CSharpConverer().Convert( xml )
            );

            using StringWriter stringWriter = new StringWriter().WriteClassStudioHeader();
            classInfoWriter.Write( stringWriter );

            return stringWriter.ToString();
        }
    }
}
