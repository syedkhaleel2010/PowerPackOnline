using PowerPack.Common.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PowerPack.Common.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class LocalizedUrlAttribute : RegularExpressionAttribute
    {
        private static string pattern = LocalizationHelper.GetResourceText("Shared.Expressions.Url");

        static LocalizedUrlAttribute()
        {
            // necessary to enable client side validation
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(LocalizedUrlAttribute), typeof(RegularExpressionAttributeAdapter));
        }

        public LocalizedUrlAttribute() : base(pattern)
        {
            ErrorMessage = string.Format(LocalizationHelper.GetResourceText("Shared.Messages.vUrlField"));
        }
    }

}
