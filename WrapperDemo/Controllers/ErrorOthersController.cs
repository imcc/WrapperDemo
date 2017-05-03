using System.Web.Http;
using System.Web.Mvc;

namespace WrapperDemo.Controllers
{
    public class ErrorOthersController : ApiController
    {
        public object Get(int id)
        {
            return new HttpStatusCodeResult(id);
        }
    }
}