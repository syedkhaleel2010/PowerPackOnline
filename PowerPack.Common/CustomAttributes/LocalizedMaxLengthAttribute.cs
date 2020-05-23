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
    public class LocalizedMaxLengthAttribute : MaxLengthAttribute
    {
        static LocalizedMaxLengthAttribute()
        {
            // necessary to enable client side validation
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(LocalizedMaxLengthAttribute), typeof(MaxLengthAttributeAdapter));
        }
        
        public LocalizedMaxLengthAttribute(int length) : base()
        {
            ErrorMessage = LocalizationHelper.GetResourceText("Shared.Messages.MaximumLengthExceeded");
        }
    }
}
