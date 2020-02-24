using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dating_app.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContex _contex;
        public ValuesController(DataContex contex)
        {
            _contex=contex;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetValues()
        {

            var values = _contex.Values.ToList();
            
            return Ok(values);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> GetValue(int id)
        {
            var value=_contex.Values.FirstOrDefault(x=>x.ID== id);
            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
