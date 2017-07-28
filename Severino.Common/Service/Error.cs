using System;

namespace Severino.Common.Service
{
    /// <summary>
    /// Classe para representação e notificação de erros
    /// </summary>
    public sealed class Error
    {
        /// <summary>
        /// Método construtor
        /// </summary>
        /// <param name="type">Enumerador que identifica o tipo do erro</param>
        /// <param name="message">Mensagem de erro</param>
        public Error(TypeError type, string message)
        {
            if (string.IsNullOrEmpty(message) || string.IsNullOrWhiteSpace(message))
                throw new ArgumentNullException(nameof(message));

            Type = type;
            Message = message;
        }

        /// <summary>
        /// Método construtor
        /// </summary>
        /// <param name="type">Enumerador que identifica o tipo do erro</param>
        /// <param name="message">Mensagem de erro</param>
        /// <param name="details">Detalhes complementares do erro</param>
        public Error(TypeError type, string message, string details)
            : this(type, message)
        {
            if (string.IsNullOrEmpty(details) || string.IsNullOrWhiteSpace(details))
                throw new ArgumentNullException(nameof(details));

            Details = details;
        }

        /// <summary>
        /// Método construtor
        /// </summary>
        /// <param name="type">Enumerador que identifica o tipo do erro</param>
        /// <param name="message">Mensagem de erro</param>
        /// <param name="exception">Exception ocorrido</param>
        public Error(TypeError type, string message, Exception exception)
            : this(type, message)
        {
            Exception = exception ?? throw new ArgumentNullException(nameof(exception));
        }

        /// <summary>
        /// Método construtor
        /// </summary>
        /// <param name="type">Enumerador que identifica o tipo do erro</param>
        /// <param name="message">Mensagem de erro</param>
        /// <param name="details">Detalhes complementares do erro</param>
        /// <param name="exception">Exception ocorrido</param>
        public Error(TypeError type, string message, string details, Exception exception)
            : this(type, message, details)
        {
            Exception = exception ?? throw new ArgumentNullException(nameof(exception));
        }

        /// <summary>
        /// Mensagem do erro
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Detalhes adicionais do erro
        /// </summary>
        public string Details { get; private set; }

        /// <summary>
        /// Exception interno
        /// </summary>
        public Exception Exception { get; private set; }

        /// <summary>
        /// Enumerador identificador do tipo do erro
        /// </summary>
        public TypeError Type { get; private set; }

        /// <summary>
        /// Sobrecarga do método ToString()
        /// </summary>
        public override string ToString()
        {
            return $"{Message}. {Details}";
        }
    }
}