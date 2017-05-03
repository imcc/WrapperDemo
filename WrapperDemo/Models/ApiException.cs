using System;
using System.Net;

namespace WrapperDemo.Models
{
    public class ApiException : Exception
    {
        public string ErrorId { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public ApiException()
            : this("API Call Error")
        {
        }

        public ApiException(string errorMessage)
            : base(errorMessage)
        {
            ErrorId = "unknown_api_error";
            StatusCode = HttpStatusCode.BadRequest;
        }
    }
}