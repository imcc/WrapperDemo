using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WrapperDemo.Models;

namespace WrapperDemo.Controllers
{
    public class ValuesController : ApiController
    {
        public ValuesController()
        {
            //throw new Exception("构造函数里的异常");
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            throw new Exception("用于测试的Exception");
            //return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            throw new ApiException("测试的api exception");
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
