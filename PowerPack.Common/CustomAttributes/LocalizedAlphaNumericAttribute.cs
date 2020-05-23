using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using PowerPack.Common.Localization;


namespace PowerPack.Common.CustomAttributes
{
    /// <summary>
    /// To validate phone numbers
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class LocalizedAlphaNumericAttribute : RegularExpressionAttribute
    {
        private static string pattern = LocalizationHelper.GetResourceText("Shared.Expressions.AlphaNumeric");

        static LocalizedAlphaNumericAttribute()
        {
            // necessary to enable client side validation
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(LocalizedAlphaNumericAttribute), typeof(RegularExpressionAttributeAdapter));
        }

        public LocalizedAlphaNumericAttribute() : base(pattern)
        {
            ErrorMessage = string.Format(LocalizationHelper.GetResourceText("Shared.Messages.vAlphaNumericField"));
        }
    }
}
