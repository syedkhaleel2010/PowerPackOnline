using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using PowerPack.Common.Localization;

namespace PowerPack.Common.CustomAttributes
{
    /// <summary>
    /// To validate email
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class LocalizedEmailAttribute : RegularExpressionAttribute
    {
        private static string pattern = LocalizationHelper.GetResourceText("Shared.Expressions.Email");

        static LocalizedEmailAttribute()
        {
            // necessary to enable client side validation
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(LocalizedEmailAttribute), typeof(RegularExpressionAttributeAdapter));
        }

        public LocalizedEmailAttribute() : base(pattern)
        {
            ErrorMessage = string.Format(LocalizationHelper.GetResourceText("Shared.Messages.vEmailField"));
        }
    }
}
