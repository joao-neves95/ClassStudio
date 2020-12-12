/*
 * Copyright (c) 2019-2020 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GPLv3.0 license (GNU General Public License v3.0),
 * located in the root of this project, under the name "LICENSE.md".
 *
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ClassStudio.Core.Utils
{
    public static class Readers
    {
        public static string[] ReadDirectory(string[] directoryPaths, string extension = "*.*")
        {
            List<string> allFilePaths = new List<string>();

            for (int i = 0; i < directoryPaths.Length; ++i)
            {
                allFilePaths.AddRange( Readers.ReadDirectory( directoryPaths[i], extension ) );
            }

            return allFilePaths.ToArray();
        }

        /// <summary>
        /// 
        /// Returns an array of all the files in the provided directory that matches the extension pattern.
        /// 
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="extension"> Eg: "*.*" = all; "*.XML" = all .xml files </param>
        /// <returns></returns>
        public static string[] ReadDirectory(string directoryPath, string extension = "*.*")
        {
            return Directory.GetFiles( directoryPath, extension );
        }

        /// <summary>
        /// 
        /// Reads all provided files and returns them in a single string.
        /// 
        /// </summary>
        /// <param name="filePaths"></param>
        /// <returns></returns>
        public static async Task<string[]> ReadFileAsync(string[] filePaths)
        {
            for (int i = 0; i < filePaths.Length; ++i)
            {
                filePaths[i] = await Readers.ReadFileAsync( filePaths[i] );
            }

            return filePaths;
        }

        public static async Task<string> ReadFileAsync(string filePath)
        {
            return await File.ReadAllTextAsync( filePath, Encoding.UTF8 );
        }
    }
}
