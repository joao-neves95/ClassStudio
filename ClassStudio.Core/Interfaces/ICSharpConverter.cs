/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */


using System.IO;
using System.Threading.Tasks;

namespace ClassStudio.Core.Interfaces
{
    public interface ICSharpConverter
    {
        string ToXML<T>(T classInput);

        Task<string> ToTypeScript(string[] typescriptInputs);

        Task<string> ToTypeScript(string typescriptInput, bool writeGeneratorHeader = true, StringWriter stringWriter = null);
    }
}
