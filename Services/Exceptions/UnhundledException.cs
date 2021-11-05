using System;
namespace SalesWebMvc.Services.Exceptions
{
    public class UnhundledException : ApplicationException
    {
        public UnhundledException(string message) : base(message) { }
    }
}
