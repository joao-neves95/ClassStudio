/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ClassStudio.UI.Models;
using ClassStudio.UI.Models.Components;
using ClassStudio.UI.Enums;

namespace ClassStudio.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            IndexViewModel indexViewModel = new IndexViewModel()
            {
                InputTypeSelector = new SelectViewModel()
                {
                    Id = "input-selector", // Resources.Resources_FrontendIDs.Generator_InputTypeSelector,
                    Options = new List<OptionViewModel>()
                    {
                        new OptionViewModel()
                        {
                            Label = "XML",
                            Value = ((int)LangEnum.XML).ToString()
                        },
                        new OptionViewModel()
                        {
                            Label = "C#",
                            Value = ((int)LangEnum.CSharp).ToString()
                        }
                    }
                },
                OutputTypeSelector = new SelectViewModel()
                {
                    Id = "output-selector", // Resources.Resources_FrontendIDs.Generator_OutputTypeSelector,
                    Options = new List<OptionViewModel>()
                    {
                        new OptionViewModel()
                        {
                            Label = "C#",
                            Value = ((int)LangEnum.CSharp).ToString()
                        },
                        new OptionViewModel()
                        {
                            Label = "TypeScript",
                            Value = ((int)LangEnum.TypeScript).ToString()
                        },
                    }
                }
            };

            return View( indexViewModel );
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache( Duration = 0, Location = ResponseCacheLocation.None, NoStore = true )]
    public IActionResult Error()
    {
        return View( new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier } );
    }
}
}
