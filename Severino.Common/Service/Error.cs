using System;

namespace Severino.Common.Service
{
    public sealed class Error
    {
        public Error(TypeError type, string message)
        {
            if (string.IsNullOrEmpty(message) || string.IsNullOrWhiteSpace(message))
                throw new ArgumentNullException(nameof(message));

            Type = type;
            Message = message;
        }

        public Error(TypeError type, string message, string details)
            :this(type, message)
        {
            if (string.IsNullOrEmpty(details) || string.IsNullOrWhiteSpace(details))
                throw new ArgumentNullException(nameof(details));
            
            Details = details;
        }
        public Error(TypeError type, string message, Exception exception)
            :this(type, message)
        {
            Exception = exception ?? throw new ArgumentNullException(nameof(exception));
        }
        public Error(TypeError type, string message, string details, Exception exception)
            :this(type, message, details)
        {
            Exception = exception ?? throw new ArgumentNullException(nameof(exception));
        }

        public string Message { get; private set; }
        public string Details { get; private set; }
        public Exception Exception { get; private set; }
        public TypeError Type { get; private set; }

        public override string ToString()
        {
            return $"{Message}. {Details}";
        }
    }
    }
}