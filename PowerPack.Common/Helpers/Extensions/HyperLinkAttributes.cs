
using PowerPack.Common.ViewModels;
using PowerPack.Models;

namespace PowerPack.Common.Helpers.Extensions
{
    public class HyperlinkAttributes
    {
        public string Id { get; set; }

        internal string DefaultCssClass { get; set; }
        public string InnerIconCssClass { get; set; }

        public string CssClass { get; set; }

        public string Title { get; set; }

        public string TitleResourceKey { get; set; }
        public bool IsTitleFormatted { get; set; }
        public object[] TitleFormatValues { get; set; }

        public string TextResourceKey { get; set; }

        public string OnClick { get; set; }
        public PagePermission PagePermission { get; set; }
    }
}