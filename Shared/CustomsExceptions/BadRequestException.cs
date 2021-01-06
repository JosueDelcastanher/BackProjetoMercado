using Domain.FluentValidations.HBSIS.Padawan.Produtos.Domain;
using System;
using System.Collections.Generic;

namespace Shared.CustomsExceptions
{
    [Serializable]
    public class BadRequestException : Exception
    {
        public HashSet<Error> Errors { get; private set; }

        public BadRequestException(HashSet<Error> errors)
        {
            this.Errors = errors;
        }

        public BadRequestException(string message) : base(message) { }
        public BadRequestException(string message, Exception inner) : base(message, inner) { }
        protected BadRequestException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

    }
}
