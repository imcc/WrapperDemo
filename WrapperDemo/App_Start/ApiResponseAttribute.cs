using System.Net.Http;
using System.Web.Http.Filters;
using WrapperDemo.Models;

namespace WrapperDemo
{
    public class ApiResponseAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);

            if (actionExecutedContext.Exception != null)
            {
                return;
            }

            var result = new ApiResponse
            {
                Success = true,
                StatusCode = actionExecutedContext.ActionContext.Response.StatusCode,
                Result = actionExecutedContext.ActionContext.Response.Content.ReadAsAsync<object>().Result
            };
            // 重新封裝回傳格式
            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(result.StatusCode, result);
        }
    }
}
