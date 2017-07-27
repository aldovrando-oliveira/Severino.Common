using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Severino.Common.Attributes;

namespace Severino.Common.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum target)
        {
            var member = target.GetType().GetTypeInfo().GetMember(target.ToString()).FirstOrDefault();
            var attr = member.GetCustomAttributes(typeof(DescriptionAttribute), true).FirstOrDefault() as DescriptionAttribute;

            return attr == null ? target.ToString() : attr.Description;
        }

        public static IDictionary<T, string> GetEnumValuesWithDescription<T>(this Type type) where T : struct, IConvertible
        {
            if (!type.GetTypeInfo().IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

            return type.GetTypeInfo().GetEnumValues()
                    .OfType<T>()
                    .ToDictionary(
                        key => key,
                        val => (val as Enum).GetDescription()
                    );
        }
    }
}