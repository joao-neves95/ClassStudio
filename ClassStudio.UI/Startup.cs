/*
 * Copyright (c) 2019-2020 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GPLv3.0 license (GNU General Public License v3.0),
 * located in the root of this project, under the name "LICENSE.md".
 *
 */

using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Newtonsoft.Json.Linq;
using ElectronNET.API;
using ElectronNET.API.Entities;

using ClassStudio.Core.Interfaces;
using ClassStudio.Core.Services;
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

            services.AddSingleton<IConverterService, ConverterService>();
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

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();
            app.UseAuthorization();

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

            await Task.Run( async () =>
            {
                Console.WriteLine( "Opening main window..." );

                Startup.MainWindow = await Electron.WindowManager.CreateWindowAsync(
                    new BrowserWindowOptions()
                    {
                        Height = 900,
                        Width = 1150,
                        Center = true
                    } );

                await Startup.MainWindow.WebContents.Session.ClearCacheAsync();

                //Startup.MainWindow.SetTitle( Configuration["WindowTitle"] );
                //Startup.MainWindow.OnReadyToShow += () => Startup.MainWindow.Show();
            } );

            app.CheckForUpdates();
        }

        #endregion CONFIGURE

    }
}
