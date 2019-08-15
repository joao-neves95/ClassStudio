/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using Xml2CSharp;
using System.Threading.Tasks;

namespace ClassStudio.Core.Generators
{
    public static class XML
    {
        public static string ToCSharp(string xml)
        {
            ClassInfoWriter classInfoWriter = new ClassInfoWriter(
                new Xml2CSharpConverer().Convert( xml )
            );

            StringWriter stringWriter = new StringWriter();
            classInfoWriter.Write( stringWriter );

            return stringWriter.ToString();
        }
    }
}
