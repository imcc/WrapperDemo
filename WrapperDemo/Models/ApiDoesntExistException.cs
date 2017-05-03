using System.Net;

namespace WrapperDemo.Models
{
    public class ApiDoesntExistException : ApiException
    {
        public ApiDoesntExistException()
            : base("找不到此API")
        {
            ErrorId = "api_doesnt_exist";
            StatusCode = HttpStatusCode.NotFound;
        }
    }
}