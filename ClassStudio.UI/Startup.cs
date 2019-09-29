/*
 * Copyright (c) 2019 Jo�o Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */

using ClassStudio.UI.Enums;
using ClassStudio.UI.Models;
using ElectronNET.API;
using ElectronNET.API.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ClassStudio.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// A dynamic representation of the JObject electron.manifest.json file.
        /// </summary>
        public static dynamic ElectronManifestJObj { get; private set; }
        public static string CurrentAppVersion { get; private set; }

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
            _ = Task.Run( () =>
            {
                Console.WriteLine( "Opening main window..." );

                _ = Electron.WindowManager.CreateWindowAsync(
                    new BrowserWindowOptions()
                    {
                        Height = 900,
                        Width = 1150,
                        Center = true
                    } );
            } );

            // TODO: (REFACTORING) Make this a middleware.
            // Do not await.
            _ = Task.Run( async () =>
            {
                Console.WriteLine( "Checking for Updates..." );
                Electron.Notification.Show( new NotificationOptions( "ClassStudio", "Checking for Updates..." ) );

                CheckUpdateResponse updateCheck = await UpdateService._.CheckForUpdates();


                if (updateCheck.Success && updateCheck.UpdateAvailable)
                {
                    Uri updateUri = new Uri( $"https://sourceforge.net/projects/class-studio/files/ClassStudio Setup {updateCheck.NewAvailableVersion}.exe/download" );
                    string _title = $"ClassStudio update available";
                    string _body = $"v{updateCheck.CurrentVersion} -> v{updateCheck.NewAvailableVersion}\nUpdate link: {updateUri}";

                    MessageBoxOptions messageBoxOptions = new MessageBoxOptions( _body )
                    {
                        Type = MessageBoxType.info,
                        Title = _title,
                        Buttons = new string[] { "Open Link", "Skip Update" },
                    };

                    MessageBoxResult messageBoxResult = await Electron.Dialog.ShowMessageBoxAsync( messageBoxOptions );

                    if (messageBoxResult.Response == (int)UpdateMessageBoxResult.Download)
                    {
                        if (RuntimeInformation.IsOSPlatform( OSPlatform.Windows ))
                        {
                            Process.Start( new ProcessStartInfo( "cmd", $"/c start {Uri.EscapeUriString( updateUri.ToString().Replace( "&", "^&" ) )}" ) { CreateNoWindow = true } );
                        }
                        else if (RuntimeInformation.IsOSPlatform( OSPlatform.Linux ))
                        {
                            Process.Start( "xdg-open", updateUri.ToString() );
                        }
                        else if (RuntimeInformation.IsOSPlatform( OSPlatform.OSX ))
                        {
                            Process.Start( "open", updateUri.ToString() );
                        }
                    }
                }
                else if (updateCheck.Success && !updateCheck.UpdateAvailable)
                {
                    Electron.Notification.Show( new NotificationOptions( "ClassStudio", "No updates available." ) );
                }
                else if (!updateCheck.Success && env.IsDevelopment())
                {
                    Electron.Notification.Show( new NotificationOptions( "ClassStudio", JsonConvert.SerializeObject( updateCheck ) ) );
                    Console.WriteLine( "ClassStudio update result" );
                    Console.WriteLine( JsonConvert.SerializeObject( updateCheck ) );
                }
                else
                {
                    Electron.Notification.Show( new NotificationOptions( "ClassStudio", "An error occured during update." ) );
                }
            } );
        }

        #endregion CONFIGURE

    }
}
