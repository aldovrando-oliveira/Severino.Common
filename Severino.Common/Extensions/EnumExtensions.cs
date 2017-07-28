using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Severino.Common.Attributes;

namespace Severino.Common.Extensions
{
    /// <summary>
    /// Extensão para Enums
    /// </summary>
    public static class EnumExtensions
    {

        /// <summary>
        /// Retorna a descrição de um item de enumerador
        /// </summary>
        /// <param name="target">Item a ser recuperado a descrição</param>
        /// <returns></returns>
        public static string GetDescription(this Enum target)
        {
            var member = target.GetType().GetTypeInfo().GetMember(target.ToString()).FirstOrDefault();
            var attr = member.GetCustomAttributes(typeof(DescriptionAttribute), true).FirstOrDefault() as DescriptionAttribute;

            return attr == null ? target.ToString() : attr.Description;
        }

        /// <summary>
        /// Retorna uma lista com as descrições de todos os itens de um enumerador
        /// </summary>
        /// <param name="type">Tipo a ser pesquisado</param>
        /// <returns>Retorna uma instância Dictionary tendo como chave um item do Enum e como valor sua respectiva descrição</returns>
        /// <exception cref="ArgumentException">Ocorre quando o argumento 'type' informado não for um enumerador </exception>
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