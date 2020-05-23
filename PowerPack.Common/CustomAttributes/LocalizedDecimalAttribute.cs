using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using PowerPack.Common.Localization;

namespace PowerPack.Common.CustomAttributes
{
    /// <summary>
    /// To validate decimal numbers
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class LocalizedDecimalAttribute : RegularExpressionAttribute
    {
        private static string pattern = LocalizationHelper.GetResourceText("Shared.Expressions.Decimal");

        static LocalizedDecimalAttribute()
        {
            // necessary to enable client side validation
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(LocalizedDecimalAttribute), typeof(RegularExpressionAttributeAdapter));
        }

        public LocalizedDecimalAttribute() : base(pattern)
        {
            ErrorMessage = string.Format(LocalizationHelper.GetResourceText("Shared.Messages.DecimalRange"), LocalizationHelper.GetResourceText("Shared.Limits.Decimal"));
        }
    }
}
