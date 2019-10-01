using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using ClassStudio.UI.Enums;
using ClassStudio.UI.Models;
using ElectronNET.API;
using ElectronNET.API.Entities;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

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
            catch(Exception e)
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

            await _next( httpContext );
        }
    }
}
