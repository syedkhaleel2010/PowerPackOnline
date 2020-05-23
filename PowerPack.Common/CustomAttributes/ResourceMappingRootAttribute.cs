using System;

namespace PowerPack.Common.CustomAttributes
{
    [AttributeUsage(System.AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false)]
    public class ResourceMappingRootAttribute : Attribute
    {
        public string Path
        {
            get; set;
        }

        public ResourceMappingRootAttribute()
        {
        }
    }
}
