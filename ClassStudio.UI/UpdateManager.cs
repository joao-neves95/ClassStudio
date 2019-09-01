/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */

using ElectronNET.API;
using ElectronNET.API.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClassStudio.UI
{
    public sealed class UpdateManager
    {

        #region SINGLETON CONTRUCTOR

        static UpdateManager() { }

        private UpdateManager() { }

        /// <summary>
        /// 
        /// The current instance.
        /// 
        /// </summary>
        public static UpdateManager _ { get; } = new UpdateManager();

        #endregion SINGLETON CONTRUCTOR


        #region PUBLIC METHODS

        public async Task<UpdateCheckResult> CheckForUpdates()
        {
            throw new NotImplementedException();
        }

        #endregion PUBLIC METHODS
    }
}
