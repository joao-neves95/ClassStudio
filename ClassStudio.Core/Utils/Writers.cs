﻿/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */

using System.IO;

namespace ClassStudio.Core.Utils
{
    public static class Writers
    {
        /// <summary>
        /// 
        /// Comment header type: /* (...) */
        /// 
        /// </summary>
        /// <param name="stringWriter"></param>
        /// <param name="useMethod"> This has no use but to differentiate this method from the extension with the same name. </param>
        /// <returns></returns>
        public static StringWriter WriteClassStudioHeader(StringWriter stringWriter, sbyte useMethod)
        {
            return stringWriter.WriteClassStudioHeader();
        }

        // TODO: Un-hardcode ClassStudio's version.
        /// <summary>
        /// 
        /// Comment header type: /* (...) */
        /// 
        /// </summary>
        /// <param name="stringWriter"></param>
        /// <returns></returns>
        public static StringWriter WriteClassStudioHeader(this StringWriter stringWriter)
        {
            stringWriter.WriteLine( "" );
            stringWriter.WriteLine( "/* ***************************************************************" );
            stringWriter.WriteLine( " * This code was auto generated by ClassStudio v0.2.0.           *" );
            stringWriter.WriteLine( " *                                                                                               *" );
            stringWriter.WriteLine( " * https://github.com/joao-neves95/ClassStudio                     *" );
            stringWriter.WriteLine( " *                                                                                               *" );
            stringWriter.WriteLine( " * ***************************************************************" );
            stringWriter.WriteLine( " */" );
            stringWriter.WriteLine( "" );

            return stringWriter;
        }
    }
}
