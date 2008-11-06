using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Serialization;

namespace QuickGraph.Serialization
{
    internal static class SerializationHelper    
    {
        public static IEnumerable<KeyValuePair<PropertyInfo, string>> GetAttributeProperties(Type type)
        {
            var currentType = type;
            while (
                currentType != null &&
                currentType != typeof(object) &&
                currentType != typeof(ValueType))
            {
                foreach (PropertyInfo property in currentType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    // must have a get, and not be an index
                    if (!property.CanRead || property.GetIndexParameters().Length > 0)
                        continue;
                    // is it tagged with XmlAttributeAttribute?
                    string name = GetAttributeName(property);
                    if (name != null)
                        yield return new KeyValuePair<PropertyInfo, string>(property, name);
                }

                currentType = currentType.BaseType;
            }
        }

        public static string GetAttributeName(PropertyInfo property)
        {
            object[] attributes = property.GetCustomAttributes(typeof(XmlAttributeAttribute), true);
            if (attributes.Length == 0)
                return null;
            else
            {
                XmlAttributeAttribute attribute = attributes[0] as XmlAttributeAttribute;
                if (String.IsNullOrEmpty(attribute.AttributeName))
                    return property.Name;
                else
                    return attribute.AttributeName;
            }
        }
    }
}
