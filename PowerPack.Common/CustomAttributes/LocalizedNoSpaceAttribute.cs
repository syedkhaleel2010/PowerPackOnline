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
    public class LocalizedNoSpaceAttribute : RegularExpressionAttribute
    {
        private static string pattern = LocalizationHelper.GetResourceText("Shared.Expressions.NoSpace");

        static LocalizedNoSpaceAttribute()
        {
            // necessary to enable client side validation
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(LocalizedNoSpaceAttribute), typeof(RegularExpressionAttributeAdapter));
        }

        public LocalizedNoSpaceAttribute() : base(pattern)
        {
            ErrorMessage = string.Format(LocalizationHelper.GetResourceText("Shared.Messages.vNoSpaceField"));
        }
    }
}
