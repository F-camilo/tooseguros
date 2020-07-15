using System;

namespace TooSeguros.Domain.Exceptions
{
    public class TransacaoException : Exception
    {
        public TransacaoException(string message)
        : base(message)
        {
        }
    }
}
