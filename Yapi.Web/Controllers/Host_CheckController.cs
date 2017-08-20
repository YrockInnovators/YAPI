using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Yapi.Web.Controllers
{
    public class Host_CheckController : ApiController
    {
        public IHttpActionResult Get()
        {
            var project = typeof(Yapi.Web.WebApiApplication).Assembly.GetName().Name;
            var version = typeof(Yapi.Web.WebApiApplication).Assembly.GetName().Version;
            return Ok($"{project} {version}");
        }
    }
}
