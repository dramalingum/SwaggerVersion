using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace SwaggerVersioning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SharedController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
