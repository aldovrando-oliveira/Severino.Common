using System;
using System.Collections.Generic;
using System.Linq;
using Severino.Common.Extensions;

namespace Severino.Common.Service
{
    /// <summary>
    /// Classe base para os DTOs de resposta dos serviços de dominio
    /// </summary>
    public abstract class DtoResponseBase
    {
        /// <summary>
        /// Coleção de erros
        /// </summary>
        public ICollection<Error> Errors { get; private set; }

        /// <summary>
        /// Indica se o processo ocorreu com sucesso
        /// </summary>
        /// <remarks>
        /// <para>
        /// Essa propriedade indica se ocorreu algum erro no processo.
        /// </para>
        /// <para>
        /// Caso seja incluído algum erro, automaticamente essa propriedade retornará false
        /// </para>
        /// </remarks>
        /// <returns></returns>
        public bool Success { get => Errors == null || Errors.Count == 0; }

        /// <summary>
        /// Adiciona um novo erro ao response
        /// </summary>
        /// <param name="type">Enumerador que identifica o tipo do erro</param>
        /// <param name="message">Mensagem de erro</param>
        /// <returns>Retorna uma instância de <see cref="Error" /></returns>
        public Error AddError(TypeError type, string message)
        {
            if (Errors == null)
                Errors = new List<Error>();

            var error = new Error(type, message);

            Errors.Add(error);

            return error;
        }

        /// <summary>
        /// Adiciona um novo erro ao response
        /// </summary>
        /// <param name="type">Enumerador que identifica o tipo do erro</param>
        /// <param name="message">Mensagem de erro</param>
        /// <param name="details">Detalhes adicionais do erro</param>
        /// <returns>Retorna uma instância de <see cref="Error" /></returns>
        public Error AddError(TypeError type, string message, string details)
        {
            if (Errors == null)
                Errors = new List<Error>();

            var error = new Error(type, message, details);

            Errors.Add(error);

            return error;
        }

        /// <summary>
        /// Adiciona um novo erro ao response
        /// </summary>
        /// <param name="type">Enumerador que identifica o tipo do erro</param>
        /// <param name="message">Mensagem de erro</param>
        /// <param name="exception">Erro interno que está sendo tratado</param>
        /// <returns>Retorna uma instância de <see cref="Error" /></returns>
        public Error AddError(TypeError type, string message, Exception exception)
        {
            if (Errors == null)
                Errors = new List<Error>();

            var error = new Error(type, message, exception);

            Errors.Add(error);

            return error;
        }

        /// <summary>
        /// Adiciona um novo erro ao response
        /// </summary>
        /// <param name="type">Enumerador que identifica o tipo do erro</param>
        /// <param name="message">Mensagem de erro</param>
        /// <param name="details">Detalhes adicionais do erro</param>
        /// <param name="exception">Erro interno que está sendo tratado</param>
        /// <returns>Retorna uma instância de <see cref="Error" /></returns>
        public Error AddError(TypeError type, string message, string details, Exception exception)
        {
            if (Errors == null)
                Errors = new List<Error>();

            var error = new Error(type, message, details, exception);

            Errors.Add(error);

            return error;
        }

        /// <summary>
        /// Adiciona uma lista de erros ao response
        /// </summary>
        /// <param name="errors">Celeção de erros a serem adicionados</param>
        public void AddErrors(ICollection<Error> errors)
        {
            void Action(Error item)
            {
                AddError(item.Type, item.Details, item.Exception);
            }

            errors.ToList().ForEach(Action);
        }
    }
}