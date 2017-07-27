using System;
using System.Collections.Generic;
using System.Linq;
using Severino.Common.Extensions;

namespace Severino.Common.Service
{
    public abstract class DtoResponseBase
    {
        public ICollection<Error> Errors { get; private set; }

        public bool Success
        {
            get
            {
                return Errors == null || Errors.Count == 0;
            }
        }

        public Error AddError(TypeError type, string message)
        {
            if (Errors == null)
                Errors = new List<Error>();

            Error error = new Error(type, message);

            Errors.Add(error);

            return error;
        }

        public Error AddError(TypeError type, string message, string details)
        {
            if (Errors == null)
                Errors = new List<Error>();

            Error error = new Error(type, message, details);

            Errors.Add(error);

            return error;
        }

        public Error AddError(TypeError type, string message, Exception exception)
        {
            if (Errors == null)
                Errors = new List<Error>();

            Error error = new Error(type, message, exception);

            Errors.Add(error);

            return error;
        }

        public Error AddError(TypeError type, string message, string details, Exception exception)
        {
            if (Errors == null)
                Errors = new List<Error>();

            Error error = new Error(type, message, details, exception);

            Errors.Add(error);

            return error;
        }

        public void AddErrors(ICollection<Error> errors)
        {
            errors.ToList().ForEach((item) => {
                AddError(item.Type, item.Details, item.Exception);
            });
        }
    }
}