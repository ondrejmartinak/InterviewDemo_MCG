using System;

namespace Microgen.Business.Accounting.Exceptions
{
    public class CurrencyNotFountException : Exception
    {
        public CurrencyNotFountException(string message) : base(message)
        {

        }
    }
}
