using System;
using System.Net;
using WrapperDemo.Models;

namespace WrapperDemo.Utils
{
    public class ExceptionUtils
    {
        public static ApiResponse ToApiResponse(Exception exception)
        {
            var errorApiResponseResult = new ApiResponse();

            if (exception is ApiException)
            {
                var apiException = exception as ApiException;
                errorApiResponseResult.StatusCode = apiException.StatusCode;
                errorApiResponseResult.Error = new
                {
                    ErrorId = apiException.ErrorId,
                    Message = apiException.Message
                };
            }
            else
            {
                errorApiResponseResult.StatusCode = HttpStatusCode.BadRequest;
                errorApiResponseResult.Error = new
                {
                    ErrorId = "",
                    Message = exception.Message
                };
            }
            return errorApiResponseResult;
        }
    }
}