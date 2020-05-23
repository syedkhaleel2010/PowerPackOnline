using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

// Custom namespaces
using PowerPack.Common.Localization;

namespace PowerPack.Common.CustomAttributes
{
    /// <summary>
    /// For custom numeric and range validation
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class LocalizedRequiredAttribute : RequiredAttribute
    {
        static LocalizedRequiredAttribute()
        {
            // necessary to enable client side validation
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(LocalizedRequiredAttribute), typeof(RequiredAttributeAdapter));
        }
        
        public LocalizedRequiredAttribute() : base()
        {
            ErrorMessage = LocalizationHelper.GetResourceText("Shared.Messages.Mandatory");
        }
        public override bool IsValid(object value)
        {
            if (value is string) return !string.IsNullOrWhiteSpace((string)value);

            return base.IsValid(value);
        }

    }
}
