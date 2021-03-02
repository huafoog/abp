﻿using System;
using System.Reflection;

namespace Volo.Abp.Http.ProxyScripting.Configuration
{
    public static class AbpApiPropertyNameConfiguration
    {
        public static Func<PropertyInfo, string> PropertyNameGenerator { get; set; }
        
        static AbpApiPropertyNameConfiguration()
        {
            PropertyNameGenerator = propertyInfo =>
            {
                var jsonPropertyNameAttribute = propertyInfo.GetSingleAttributeOrNull<System.Text.Json.Serialization.JsonPropertyNameAttribute>(true);

                if (jsonPropertyNameAttribute != null)
                {
                    return jsonPropertyNameAttribute.Name;
                }
                
                var jsonPropertyAttribute = propertyInfo.GetSingleAttributeOrNull<Newtonsoft.Json.JsonPropertyAttribute>(true);

                if (jsonPropertyAttribute != null)
                {
                    return jsonPropertyAttribute.PropertyName;
                }

                return null;
            };
        }
    }
}