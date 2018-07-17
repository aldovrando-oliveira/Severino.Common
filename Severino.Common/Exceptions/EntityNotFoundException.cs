using System;

namespace Severino.Common.Exceptions
{
    /// <summary>
    /// Exception disparado quando pesquisas não retornam nenhum objeto
    /// </summary>
    public class EntityNotFoundException : Exception
    {
        /// <summary>
        /// Método construtor
        /// </summary>
        public EntityNotFoundException() { }

        /// <summary>
        /// Método consturor
        /// </summary>
        /// <param name="message">Mensagem descritiva do erro</param>
        public EntityNotFoundException(string message) : base(message) { }

        /// <summary>
        /// Método construtor
        /// </summary>
        /// <param name="message">Mensagem descritiva do erro</param>
        /// <param name="type">Tipo do objeto que não foi encontrado</param>
        public EntityNotFoundException(string message, Type type) : base(message)
        {
            Type = type;
        }

        /// <summary>
        /// Método construtor
        /// </summary>
        /// <param name="type">Tipo da entidade não encontrada</param>
        public EntityNotFoundException(Type type)
            : base($"{type.GetType().Name} não encontrado")
        {
            Type = type;
        }

        /// <summary>
        /// Tipo do objeto que não foi encontrado
        /// </summary>
        public Type Type { get; }
    }
}