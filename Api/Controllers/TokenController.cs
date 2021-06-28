using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("token")]
    [ApiController]
    public class TokenController : Controller
    {
        [HttpPost]
        public ActionResult Authentication() 
        {
        }
    }
}
