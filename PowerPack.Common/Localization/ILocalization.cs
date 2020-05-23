using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPack.Common.Localization
{
    public interface ILocalized
    {
        string Key { get; set; }
        bool Colon { get; set; }
    }
}
