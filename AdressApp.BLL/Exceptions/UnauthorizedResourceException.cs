using System.Net;

namespace AddressApp.BLL.Exceptions
{
    public class UnauthorizedResourceException : BaseException
    {
        public UnauthorizedResourceException(string message)
            : base(message, (int)HttpStatusCode.Unauthorized) { }
    }
}
