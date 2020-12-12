/*
 * Copyright (c) 2019-2020 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GPLv3.0 license (GNU General Public License v3.0),
 * located in the root of this project, under the name "LICENSE.md".
 *
 */

using System.IO;
using System.Threading.Tasks;

using ClassStudio.Core.Enums;
using ClassStudio.Core.Interfaces;
using ClassStudio.Core.Services.Converters;
using ClassStudio.Core.Utils;

namespace ClassStudio.Core.Services
{
    public class ConverterService : IConverterService
    {
        public async Task<string> ConvertAsync(ConverterType converterType, string[] input)
        {
            using StringWriter allContent = new StringWriter();
            allContent.WriteClassStudioHeader();

            for (int i = 0; i < input.Length; ++i)
            {
                await this.ConvertAsync( converterType, input[i], false, allContent );
                await allContent.WriteLineAsync();
            }

            return allContent.ToString();
        }

        public async Task<string> ConvertAsync(ConverterType converterType, string input, bool writeGeneratorHeader = true, StringWriter stringWriter = null)
        {
            bool dispose = false;

            if (stringWriter == null)
            {
                stringWriter = new StringWriter();
                dispose = true;
            }

            if (writeGeneratorHeader)
            {
                stringWriter.WriteClassStudioHeader();
            }

            await ConverterFactory.Get( converterType ).ConvertAsync( input, stringWriter );

            string result = stringWriter.ToString();

            if (dispose)
            {
                await stringWriter.DisposeAsync();
            }

            return result;
        }
    }
}
