using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WrapperDemo.Models;

namespace WrapperDemo.Controllers
{
    public class Error404Controller : ApiController
    {
        public object Get()
        {
            //var response = Request.CreateResponse(HttpStatusCode.NotFound, "找不到此API");

            throw new ApiDoesntExistException();
        }
    }
}