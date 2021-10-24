using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CreateInk.Helper.AuthenticationHelper
{
    public class AuthenticationException : Exception
    {
        public AuthenticationException() : base() { }

        public AuthenticationException(string message) : base(message) { }

        public AuthenticationException(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
