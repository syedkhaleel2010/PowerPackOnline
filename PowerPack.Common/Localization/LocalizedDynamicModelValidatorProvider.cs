using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using PowerPack.Common.CustomAttributes;
using PowerPack.Common.Helpers.Extensions;
using System.Web.Mvc;

namespace PowerPack.Common.Localization
{
    public class LocalizedDynamicModelValidatorProvider : DataAnnotationsModelValidatorProvider
    {
        protected override IEnumerable<ModelValidator> GetValidators(ModelMetadata metadata, ControllerContext context, IEnumerable<Attribute> attributes)
        {
            string resourceKeyPath = string.Empty;
            IList<Attribute> newAttributes = new List<Attribute>(attributes);
            LocalizedDynamicValidatorsAttribute resourceMapperAttr = attributes.FirstOrDefault(a => a is LocalizedDynamicValidatorsAttribute) as LocalizedDynamicValidatorsAttribute;

            if (resourceMapperAttr == null)
            {
                System.Reflection.MemberInfo classInfo = metadata.ContainerType;
                if (classInfo != null)
                {
                    var resourceMapperRootAttr = classInfo.GetCustomAttributes(typeof(ResourceMappingRootAttribute), false).FirstOrDefault() as ResourceMappingRootAttribute;
                    if (resourceMapperRootAttr != null)
                    {
                        resourceKeyPath = resourceMapperRootAttr.Path + "." + metadata.PropertyName;
                    }
                }
            }
            else
            {
                resourceKeyPath = resourceMapperAttr.ResourceKeyPath;
            }

            if (!string.IsNullOrEmpty(resourceKeyPath))
            {
                string[] validators = ResourceManager.GetValidators(resourceKeyPath).Replace(" ", "").Split(',');
                var maxLength = ResourceManager.GetMaxLength(resourceKeyPath);
                if (!string.IsNullOrEmpty(maxLength))
                {
                    var required = new MaxLengthAttribute(maxLength.ToInteger());
                    required.ErrorMessage =string.Format(LocalizationHelper.GetResourceText("Shared.Messages.MaximumLengthExceeded"),maxLength);
                    newAttributes.Add(required);
                }
                for (int i = 0; i < validators.Length; i++)
                {
                    if (string.Equals(validators[i], "required", StringComparison.OrdinalIgnoreCase))
                    {
                        var required = new LocalizedRequiredAttribute();
                        newAttributes.Add(required);
                    }
                    else if (validators[i].StartsWith("email", StringComparison.OrdinalIgnoreCase))
                    {
                        var email = new LocalizedEmailAttribute();
                        newAttributes.Add(email);
                    }
                    else if (validators[i].StartsWith("phone", StringComparison.OrdinalIgnoreCase))
                    {
                        var phone = new LocalizedPhoneAttribute();
                        newAttributes.Add(phone);
                    }
                    else if (validators[i].StartsWith("alphanumeric", StringComparison.OrdinalIgnoreCase))
                    {
                        var alphanumeric = new LocalizedAlphaNumericAttribute();
                        newAttributes.Add(alphanumeric);
                    }
                    else if (validators[i].StartsWith("zipcode", StringComparison.OrdinalIgnoreCase))
                    {
                        var zipcode = new LocalizedZipCodeAttribute();
                        newAttributes.Add(zipcode);
                    }
                    else if (validators[i].StartsWith("mark", StringComparison.OrdinalIgnoreCase))
                    {
                        double minMark = 0;
                        double maxMark = 100;
                        if (validators[i].Contains("-"))
                        {
                            string[] validatorPatternArray = validators[i].Split('-');

                            if (validatorPatternArray.Length == 2)
                            {
                                maxMark = validatorPatternArray[1].ToDouble();
                            }
                            else if (validatorPatternArray.Length > 2)
                            {
                                minMark = validatorPatternArray[1].ToDouble();
                                maxMark = validatorPatternArray[2].ToDouble();
                            }
                        }

                        var num = new RangeAttribute(minMark, maxMark);
                        num.ErrorMessage = string.Format(LocalizationHelper.GetResourceText("Shared.Messages.NumberRange"), minMark, maxMark);
                        newAttributes.Add(num);
                    }
                    else if (validators[i].StartsWith("number", StringComparison.OrdinalIgnoreCase))
                    {
                        int max = 100;
                        if (validators[i].Contains("-"))
                        {
                            int.TryParse(validators[i].Split('-')[1], out max);
                        }
                        var num = new LocalizedNumberAttribute(max);
                        newAttributes.Add(num);
                    }
                    else if (validators[i].StartsWith("decimal", StringComparison.OrdinalIgnoreCase))
                    {
                        var num = new LocalizedDecimalAttribute();
                        newAttributes.Add(num);
                    }
                    else if (validators[i].StartsWith("url", StringComparison.OrdinalIgnoreCase))
                    {
                        var url = new LocalizedUrlAttribute();
                        newAttributes.Add(url);
                    }
                    else if (validators[i].StartsWith("nospace", StringComparison.OrdinalIgnoreCase))
                    {
                        var url = new LocalizedNoSpaceAttribute();
                        newAttributes.Add(url);
                    }
                }
            }

            return base.GetValidators(metadata, context, newAttributes);
        }

        public static IDictionary<string, object> GetValidatorAttributes(string validators)
        {
            IDictionary<string, object> attributes = new Dictionary<string, object>();

            string[] validatorList = !string.IsNullOrEmpty(validators) ? validators.Replace(" ", "").Split(',') : new string[] { };
            foreach (var item in validatorList)
            {
                if (!attributes.Keys.Contains("data-val"))
                {
                    attributes.Add("data-val", "true");
                }
                if (string.Equals(item, "required", StringComparison.OrdinalIgnoreCase))
                {
                    attributes.Add("data-val-required", LocalizationHelper.GetResourceText("Shared.Messages.Mandatory"));
                }
                else if (item.StartsWith("email", StringComparison.OrdinalIgnoreCase))
                {
                    attributes.Add("data-val-email", LocalizationHelper.GetResourceText("Shared.Messages.vEmailField"));
                }
                else if (item.StartsWith("phone", StringComparison.OrdinalIgnoreCase))
                {
                    attributes.Add("data-val-phone", LocalizationHelper.GetResourceText("Shared.Messages.vPhoneField"));
                }
                else if (item.StartsWith("zipcode", StringComparison.OrdinalIgnoreCase))
                {
                    attributes.Add("data-val-zipcode", LocalizationHelper.GetResourceText("Shared.Messages.vZipCodeField"));
                }
                else if (item.StartsWith("mark", StringComparison.OrdinalIgnoreCase))
                {
                    string min = string.Empty;
                    string max = string.Empty;
                    string rangeValidatorMessage = string.Empty;
                    if (item.Contains("-"))
                    {
                        var rangeArray = item.Split('-');
                        if (rangeArray.Length > 2)
                        {
                            min = rangeArray[1];
                            max = rangeArray[2];
                            rangeValidatorMessage = LocalizationHelper.GetResourceText("Shared.Messages.NumberRange");
                        }
                        else
                        {
                            max = rangeArray[1];
                            rangeValidatorMessage = LocalizationHelper.GetResourceText("Shared.Messages.vNumericLimited");
                        }
                    }
                    else
                    {
                        max = "10000";
                    }
                    if (!string.IsNullOrWhiteSpace(min))
                    {
                        attributes.Add("data-val-range-min", min);
                    }
                    attributes.Add("data-val-range-max", max);
                    attributes.Add("data-val-range", rangeValidatorMessage);
                }
                else if (item.StartsWith("number", StringComparison.OrdinalIgnoreCase))
                {
                    attributes.Add("data-val-number", LocalizationHelper.GetResourceText("Shared.Messages.NumberRange"));
                }
                else if (item.StartsWith("number", StringComparison.OrdinalIgnoreCase))
                {
                    attributes.Add("data-val-decimal", string.Format(LocalizationHelper.GetResourceText("Shared.Messages.DecimalRange"), LocalizationHelper.GetResourceText("Shared.Limits.Decimal")));
                }
                else if (item.StartsWith("file-", StringComparison.OrdinalIgnoreCase))
                {
                    attributes.Add("data-val-filetype", item.Split('-')[1]);
                }
            }
            return attributes;
        }
    }
}
