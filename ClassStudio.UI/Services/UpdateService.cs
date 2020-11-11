/*
 * Copyright (c) 2019-2020 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GPLv3.0 license (GNU General Public License v3.0),
 * located in the root of this project, under the name "LICENSE.md".
 *
 */

using ClassStudio.Core.Services;
using ClassStudio.UI.Models;

using ElectronNET.API.Entities;

using System;
using System.IO;
using System.Threading.Tasks;

namespace ClassStudio.UI
{
    public sealed class UpdateService
    {

        #region SINGLETON CONTRUCTOR

        static UpdateService() { }

        private UpdateService() { }

        /// <summary>
        /// 
        /// The current instance.
        /// 
        /// </summary>
        public static UpdateService _ { get; } = new UpdateService();

        #endregion SINGLETON CONTRUCTOR


        #region PUBLIC METHODS

        /// <summary>
        /// 
        /// Returns [true] if there is a new update available, [false] if not, or [null] in case of error.
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<CheckUpdateResponse> CheckForUpdates()
        {
            CheckUpdateResponse checkUpdateResponse = new CheckUpdateResponse();

            try
            {
                checkUpdateResponse.CurrentVersion = Startup.CurrentAppVersion;

                string versionPage = await Http.GetAsync( Startup.ElectronManifestJObj.settings.githubVersionFileUrl.Value );

                if (versionPage.StartsWith( "ERROR:" ))
                {
                    checkUpdateResponse.Success = false;
                    checkUpdateResponse.ErrorMessage = versionPage;
                    return checkUpdateResponse;
                }
                else
                {
                    checkUpdateResponse.Success = true;
                    string line;
                    sbyte lineNum = 0;
                    using StringReader stringReader = new StringReader( versionPage );

                    while ((line = await stringReader.ReadLineAsync()) != null)
                    {
                        lineNum++;

                        if (lineNum == 3)
                        {
                            line = line.Replace( "*", String.Empty ).Replace( "v", String.Empty ).Trim();
                            break;
                        }
                    }

                    if (checkUpdateResponse.CurrentVersion != line)
                    {
                        checkUpdateResponse.UpdateAvailable = true;
                        checkUpdateResponse.NewAvailableVersion = line;
                    }
                    else
                    {
                        checkUpdateResponse.UpdateAvailable = false;
                    }

                }
            }
            catch (Exception e)
            {
                checkUpdateResponse.Success = false;
                checkUpdateResponse.ErrorMessage = e.Message + "\n" + e.StackTrace;
            }

            return checkUpdateResponse;
        }

        #endregion PUBLIC METHODS
    }
}
