using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            var properties = obj
                .GetType()
                .GetProperties();

            foreach (PropertyInfo property in properties)
            {
                IEnumerable<MyValidationAttribute> propertyCustomAttr = property
                    .GetCustomAttributes()
                    .Where(n => n is MyValidationAttribute)
                    .Cast<MyValidationAttribute>();

                foreach (MyValidationAttribute attribute in propertyCustomAttr)
                {
                    bool result = attribute.IsValid(property.GetValue(obj));

                    if (!result)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
