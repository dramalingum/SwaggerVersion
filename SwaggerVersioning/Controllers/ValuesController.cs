﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SwaggerVersioning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [ApiExplorerSettings(GroupName = "apim")]
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
