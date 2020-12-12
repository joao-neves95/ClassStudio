/*
 * Copyright (c) 2019-2020 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GPLv3.0 license (GNU General Public License v3.0),
 * located in the root of this project, under the name "LICENSE.md".
 *
 */

using System.IO;
using System.Threading.Tasks;

namespace ClassStudio.Core.Interfaces
{
    public interface IConverterService<TInput>
    {
        public Task<string> Convert(TInput[] input);

        public Task<string> Convert(TInput input, bool writeGeneratorHeader = true, StringWriter stringWriter = null);
    }
}
