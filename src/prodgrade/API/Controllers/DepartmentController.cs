using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok("Get all student");
        }

        [HttpGet("{code}")]
        public IActionResult GetByCode(string code)
        {
            return Ok("Get this " + code + " depatement data");
        }

        [HttpPost]
        public IActionResult Insert()
        {
            return Ok("Insert new department");
        }

        [HttpPut("{code}")]
        public IActionResult Update(string code)
        {
            return Ok("Update this " + code + " depatement data");
        }

        [HttpDelete("{code}")]
        public IActionResult Delete(string code)
        {
            return Ok("Delete this " + code + " depatement data");
        }
    }
}
