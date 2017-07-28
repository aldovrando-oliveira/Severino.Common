using System;

namespace Severino.Common.Attributes
{
    /// <summary>
    /// Atributo para auxiliar na descrição de enumeradores
    /// </summary>
    public class DescriptionAttribute : Attribute
    {
        /// <summary>
        /// Descrição do item do enumerador
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Método construtor
        /// </summary>
        /// <param name="description">Descrição do item do enumerador</param>
        public DescriptionAttribute(string description)
        {
            Description = description;
        }
    }
}