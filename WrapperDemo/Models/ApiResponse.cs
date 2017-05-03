using System.Net;

namespace WrapperDemo.Models
{
    public class ApiResponse
    {
        public bool Success { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public object Result { get; set; }

        public object Error { get; set; }
    }
}