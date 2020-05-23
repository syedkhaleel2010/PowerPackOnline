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
    public class LocalizedPhoneAttribute : RegularExpressionAttribute
    {
        private static string pattern = LocalizationHelper.GetResourceText("Shared.Expressions.Phone");

        static LocalizedPhoneAttribute()
        {
            // necessary to enable client side validation
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(LocalizedPhoneAttribute), typeof(RegularExpressionAttributeAdapter));
        }

        public LocalizedPhoneAttribute() : base(pattern)
        {
            ErrorMessage = string.Format(LocalizationHelper.GetResourceText("Shared.Messages.vPhoneField"));
        }
    }
}
