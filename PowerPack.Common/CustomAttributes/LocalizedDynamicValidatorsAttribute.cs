using System;

namespace PowerPack.Common.CustomAttributes
{
    /// <summary>
    /// To attach dynamic validators as configured in resource file
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class LocalizedDynamicValidatorsAttribute : Attribute
    {
        public string ResourceKeyPath
        {
            get; set;
        }

        public LocalizedDynamicValidatorsAttribute()
        {
        }
    }
}
