/*
 * Copyright (c) 2019 Jo�o Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */

using System;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ElectronNET.API;
using ElectronNET.API.Entities;
using ClassStudio.UI.Enums;
using ClassStudio.UI.Models;
using ClassStudio.UI.Middleware;

namespace ClassStudio.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        #region PROPERTIES

        /// <summary>
        /// A dynamic representation of the JObject electron.manifest.json file.
        /// </summary>
        public static dynamic ElectronManifestJObj { get; private set; }
        
        public static string CurrentAppVersion { get; private set; }

        public static BrowserWindow MainWindow { get; private set; }

        #endregion PROPERTIES


        #region CONFIGURATION

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc( options => options.EnableEndpointRouting = false )
                    .AddJsonOptions( options => options.JsonSerializerOptions.PropertyNameCaseInsensitive = true );

            services.AddSpaStaticFiles( configuration => configuration.RootPath = "Scripts/dist/class-studio" );
        }

        #endregion CONFIGURATION


        #region CONFIGURE

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler( "/Home/Error" );
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints( endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}"
                );
            } );

            app.UseSpa( spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "Scripts";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer( npmScript: "start" );
                }
            } );

            await Task.Run( async () =>
            {
                Startup.ElectronManifestJObj = JObject.Parse( await File.ReadAllTextAsync( "./electron.manifest.json" ) );
                Startup.CurrentAppVersion = Startup.ElectronManifestJObj.build.buildVersion.Value;
                Electron.App.SetAppUserModelId( Startup.ElectronManifestJObj.build.appId.Value );
            } );

            // Do not await.
            _ = Task.Run( async () =>
            {
                Console.WriteLine( "Opening main window..." );

                Startup.MainWindow = await Electron.WindowManager.CreateWindowAsync(
                    new BrowserWindowOptions()
                    {
                        Height = 900,
                        Width = 1150,
                        Center = true
                    } );
            } );

            app.CheckForUpdates();
        }

        #endregion CONFIGURE

    }
}
