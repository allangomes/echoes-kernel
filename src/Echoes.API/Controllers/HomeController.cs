using System.Net;
using Microsoft.AspNetCore.Mvc;
using Auxo.Api;

namespace Echoes.API.Controllers
{
    [Route("[controller]")]
    public class HomeController
    {
        [HttpGet]
        public IActionResult Get() => Result.Factory(HttpStatusCode.Created, "BLABLA");
    }
}