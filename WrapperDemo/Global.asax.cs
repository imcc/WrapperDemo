using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Newtonsoft.Json;
using WrapperDemo.Utils;

namespace WrapperDemo
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error()
        {
            var exception = Server.GetLastError();
            if (exception == null)
            {
                return;
            }

            var exceptionToSerialize = exception.InnerException ?? exception;
            Response.ContentType = "text/json";
            Response.Write(JsonConvert.SerializeObject(ExceptionUtils.ToApiResponse((Exception)exceptionToSerialize)));
            Response.End();
        }
    }
}
