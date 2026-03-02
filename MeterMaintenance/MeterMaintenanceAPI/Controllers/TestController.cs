using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MeterMaintenanceAPI.Controllers
{
    public class TestController : ApiController
    {
        [HttpGet]
        [Route("api/test")]
        public IHttpActionResult Test()
        {
            return Ok("WORKING");
        }
    }
}
