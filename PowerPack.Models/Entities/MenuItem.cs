using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPack.Models
{
    public class MenuItem
    {
        public string MenuCategory { get; set; }
        public string ModuleName { get; set; }
        public string CssClass { get; set; }
        public string ModuleUrl { get; set; }
        public int ParentModuleId { get; set; }
        public int Sequence { get; set; }
        public string ModuleCode { get; set; }
        public bool ShowInMenu { get; set; }

    }
}
