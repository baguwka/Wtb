using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Web.Http;

namespace WtbTestApp.Controllers
{
    public class CurrencyController : ApiController
    {
        [HttpGet]
        [Route("api/GetCurrency")]
        public async Task<IHttpActionResult> GetCurrency()
        {
            return Ok("asdasd");
        }
    }
}
