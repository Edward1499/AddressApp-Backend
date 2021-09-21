using System;
using System.Collections.Generic;
using System.Text;

namespace AddressApp.BLL.Exceptions
{
    public class UnprocessedObjectException : BaseException
    {
        private const int UnprocessableEntity = 422;
        public UnprocessedObjectException(string message)
            : base(message, UnprocessableEntity) { }
    }
}
