/*
 * Copyright (c) 2019-2020 Jo�o Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GPLv3.0 license (GNU General Public License v3.0),
 * located in the root of this project, under the name "LICENSE.md".
 *
 */

using ElectronNET.API;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ClassStudio.UI
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder( args ).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder( args )
                .ConfigureWebHostDefaults( webBuilder =>
                {
                    webBuilder.UseElectron( args );
                    webBuilder.UseStartup<Startup>();
                } );
    }
}
