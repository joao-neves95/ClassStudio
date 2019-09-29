﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClassStudio.Core.Services
{
    public static class Http
    {
        // TODO: Create better error handling.

        public static async Task<string> GetAsync(string url)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync( url );
                string response = await responseMessage.Content.ReadAsStringAsync();

                if (responseMessage.IsSuccessStatusCode)
                {
                    return response;
                }
                else
                {
                    return "ERROR: " + response;
                }
            }
        }
    }
}
