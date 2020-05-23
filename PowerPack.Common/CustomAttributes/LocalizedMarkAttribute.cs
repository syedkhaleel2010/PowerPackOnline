using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using PowerPack.Common.Localization;

namespace PowerPack.Common.CustomAttributes
{
    /// <summary>
    /// For custom numeric and range validation
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class LocalizedMarkAttribute : RegularExpressionAttribute
    {
        private static string pattern = LocalizationHelper.GetResourceText("Shared.Expressions.Mark");

        static LocalizedMarkAttribute()
        {
            // necessary to enable client side validation
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(LocalizedMarkAttribute), typeof(RegularExpressionAttributeAdapter));
        }
        
        public LocalizedMarkAttribute(int Max) : base(pattern.Replace("[Max]", Max.ToString()).Replace("[FirstDigitMax]", Math.Truncate((Convert.ToDecimal(Max - 1)) / 10).ToString()))
        {
            ErrorMessage = string.Format(LocalizationHelper.GetResourceText("Shared.Messages.NumberRange"), 0, Max);
        }
    }
}
