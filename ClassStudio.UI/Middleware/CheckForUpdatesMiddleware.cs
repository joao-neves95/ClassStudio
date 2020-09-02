/*
 * Copyright (c) 2019-2020 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GPLv3.0 license (GNU General Public License v3.0),
 * located in the root of this project, under the name "LICENSE.md".
 *
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ElectronNET.API;
using ElectronNET.API.Entities;
using ClassStudio.UI.Enums;
using ClassStudio.UI.Models;

namespace ClassStudio.UI.Middleware
{
    public class CheckForUpdatesMiddleware
    {
        private readonly RequestDelegate _next;

        public CheckForUpdatesMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            // DOT NOT AWAIT.
            _ = Task.Run( async () =>
            {
                try
                {
                    Console.WriteLine( "Checking for Updates..." );
                    Electron.Notification.Show( new NotificationOptions( "ClassStudio", "Checking for Updates..." ) );

                    // TODO: Add a timeout task cancelation token.
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
                    else
                    {
                        throw new Exception( "[ UPADTE ERROR ]", new Exception( JsonConvert.SerializeObject( updateCheck ) ) );
                    }
                }
                catch (Exception e)
                {
                    Electron.Notification.Show( new NotificationOptions( "ClassStudio", "An error occured during update." ) );

                    if (e.Message == "[ UPADTE ERROR ]")
                    {
                        Console.WriteLine( e.InnerException.Message );
                    }
                    else
                    {
                        Console.WriteLine( e.Message );
                    }
                }
            } );

            await _next( httpContext );
        }
    }

    public static class CheckForUpdatesMiddlewareExtension
    {
        public static IApplicationBuilder CheckForUpdates(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CheckForUpdatesMiddleware>();
        }
    }
}
