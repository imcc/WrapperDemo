using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using WrapperDemo.Models;
using WrapperDemo.Utils;

namespace WrapperDemo
{
    public class ApiExceptionResponseAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnException(actionExecutedContext);

            // 將錯誤訊息轉成要回傳的ApiResponseResult
            var errorApiResponseResult = ExceptionUtils.ToApiResponse(actionExecutedContext.Exception);

            // 重新打包回傳的訊息
            actionExecutedContext.Response =
                actionExecutedContext.Request.CreateResponse(errorApiResponseResult.StatusCode, errorApiResponseResult);
        }
    }
}