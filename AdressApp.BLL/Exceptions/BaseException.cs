using System;

namespace AddressApp.BLL.Exceptions
{
    [Serializable]
    public class BaseException : Exception
    {
        public string Title { get; set; } = "Error";
        public string Detail { get; set; }
        public int Code { get; set; }
        public BaseException(string message, int code)
            : base(message)
        {
            Detail = message;
            Code = code;
        }
    }
}
