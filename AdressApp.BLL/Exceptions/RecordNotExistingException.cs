using System.Net;

namespace AddressApp.BLL.Exceptions
{
    public class RecordNotExistingException : BaseException
    {
        public RecordNotExistingException(string message)
            : base(message, (int)HttpStatusCode.NotFound) { }
    }
}
