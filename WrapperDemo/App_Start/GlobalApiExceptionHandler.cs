using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using WrapperDemo.Utils;

namespace WrapperDemo
{
    public class GlobalApiExceptionHandler : ExceptionHandler
    {
        internal class GlobalExceptionResponseActoinResult : IHttpActionResult
        {
            public HttpRequestMessage Request { get; set; }

            public Exception Exception { get; set; }

            //public Task ExecuteAsync(CancellationToken cancellationToken)
            //{
            //    var apiResponseResult = ExceptionUtils.ToApiResponse(Exception);
            //    var response = new HttpResponseMessage(apiResponseResult.StatusCode)
            //    {
            //        Content = new ObjectContent(apiResponseResult.GetType(), apiResponseResult, new JsonMediaTypeFormatter()),
            //        RequestMessage = Request,
            //    };
            //    return Task.FromResult(response);
            //}

            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                var apiResponseResult = ExceptionUtils.ToApiResponse(Exception);
                var response = new HttpResponseMessage(apiResponseResult.StatusCode)
                {
                    Content = new ObjectContent(apiResponseResult.GetType(), apiResponseResult, new JsonMediaTypeFormatter()),
                    RequestMessage = Request,
                };
                return Task.FromResult(response);
            }
        }

        /// 

        /// 在衍生類別中覆寫時，同步處理例外狀況。
        /// 

        ///例外狀況處理常式內容。
        public override void Handle(ExceptionHandlerContext context)
        {
            context.Result = new GlobalExceptionResponseActoinResult
            {
                Request = context.ExceptionContext.Request,
                Exception = context.Exception
            };
        }
    }
}