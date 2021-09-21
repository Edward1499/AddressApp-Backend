using System.Net;

namespace AddressApp.BLL.Exceptions
{
    public class ExistingRecordException : BaseException
    {
        public ExistingRecordException(string message)
            : base(message, (int)HttpStatusCode.InternalServerError) { }
    }
}
