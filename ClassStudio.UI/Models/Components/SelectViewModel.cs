using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassStudio.UI.Models.Components
{
    public class SelectViewModel
    {
        public string Id { get; set; }

        public List<OptionViewModel> Options { get; set; }
    }

    public class OptionViewModel
    {
        public string Label { get; set; }

        public string Value { get; set; }
    }
}
