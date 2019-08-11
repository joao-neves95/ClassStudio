using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassStudio.UI.Models.Components;

namespace ClassStudio.UI.Models
{
    public class IndexViewModel
    {
        public SelectViewModel InputTypeSelector { get; set; }

        public SelectViewModel OutputTypeSelector { get; set; }
    }
}
