using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MedicalibaryREST.Controllers
{
    [RoutePrefix("api/HelloThere")]
    public class HelloWorldController : ApiController
    {
        public HelloWorldController() { }

        [Route("")]
        public string WellHelloThere()
        {
            return "Hello My Sweet Princess ;)";
        }
    }
}
