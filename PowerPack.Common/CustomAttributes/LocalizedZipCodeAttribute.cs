using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using PowerPack.Common.Localization;

namespace PowerPack.Common.CustomAttributes
{
    /// <summary>
    /// To validate zipcode
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class LocalizedZipCodeAttribute : RegularExpressionAttribute
    {
        private static string pattern = LocalizationHelper.GetResourceText("Shared.Expressions.ZipCode");

        static LocalizedZipCodeAttribute()
        {
            // necessary to enable client side validation
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(LocalizedZipCodeAttribute), typeof(RegularExpressionAttributeAdapter));
        }

        public LocalizedZipCodeAttribute() : base(pattern)
        {
            ErrorMessage = LocalizationHelper.GetResourceText("Shared.Messages.vZipCodeField");
        }
    }
}
