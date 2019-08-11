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
            SelectViewModel selectViewModel = new SelectViewModel()
            {
                Options = new List<OptionViewModel>()
                {
                    new OptionViewModel()
                    {
                        Label = "XML",
                        Value = ((int)LangEnym.XML).ToString()
                    },
                    new OptionViewModel()
                    {
                        Label = "C#",
                        Value = ((int)LangEnym.CSharp).ToString()
                    }
                }
            };

            IndexViewModel indexViewModel = new IndexViewModel()
            {
                InputTypeSelector = selectViewModel,
                OutputTypeSelector = selectViewModel
            };

            indexViewModel.InputTypeSelector.Id = "input-selector";
            indexViewModel.OutputTypeSelector.Id = "output-selector";

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
