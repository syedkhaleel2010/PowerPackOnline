using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using PowerPack.Common.Localization;

namespace PowerPack.Common.CustomAttributes
{
    /// <summary>
    /// To validate integer numbers
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class LocalizedNumberAttribute : RegularExpressionAttribute
    {
        private static string pattern = LocalizationHelper.GetResourceText("Shared.Expressions.Number");

        static LocalizedNumberAttribute()
        {
            // necessary to enable client side validation
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(LocalizedNumberAttribute), typeof(RegularExpressionAttributeAdapter));
        }

        public LocalizedNumberAttribute(int max) : base(pattern.Replace("[Max]", max.ToString()).Replace("[FirstDigitMax]", Math.Truncate((Convert.ToDecimal(max - 1)) / 10).ToString()))
        {
            ErrorMessage = string.Format(LocalizationHelper.GetResourceText("Shared.Messages.NumberRange"), 0, max);
        }
    }
}
