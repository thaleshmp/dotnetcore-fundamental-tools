using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace FundamentalTools.Helpers.Enumerator
{
    public static class EnumeratorExtensions
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
                return attributes.First().Description;

            return value.ToString();
        }

        public static T Parse<T>(string value)
        {
            return Parse<T>(value, true);
        }

        public static T Parse<T>(string value, bool ignoreCase)
        {
            return (T)Enum.Parse(typeof(T), value, ignoreCase);
        }

        public static bool TryParse<T>(string value, out T returnedValue)
        {
            return TryParse<T>(value, true, out returnedValue);
        }

        public static bool TryParse<T>(string value, bool ignoreCase, out T returnedValue)
        {
            try
            {
                returnedValue = (T)Enum.Parse(typeof(T), value, ignoreCase);
                return true;
            }
            catch
            {
                returnedValue = default(T);
                return false;
            }
        }
    }
}