using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EmployeePortalAPI.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EmployeePortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // GET: api/Employee
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Employee/5
        [HttpGet("{id}", Name = "Get")]
        public dynamic Get(int id)
        {
            EmployeeManager employeeManager = new EmployeeManager();
            return (JsonConvert.SerializeObject(employeeManager.getEmployee(id)));
        }

        // POST: api/Employee
        [HttpPost]
        public IActionResult Post([FromBody] dynamic value)
        {
            // JOSN STRING  TO  DESELIZE  TO THAT  OBJECT
            EmployeeManager employeeManager = new EmployeeManager();
            if (employeeManager.addEmployee(Convert.ToString(value)) == true)
                //return Request.CreateResponse(HttpStatusCode.Created);
                return StatusCode((int)HttpStatusCode.Created, new { description = "OK", status = HttpStatusCode.Created });
            else
                //return Request.CreateResponse(HttpStatusCode.NotFound, "Not Executed Successfully");
                return StatusCode((int)HttpStatusCode.NotFound, new { description = "Not Executed Successfully", status = HttpStatusCode.Created });
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] dynamic value)
        {
            EmployeeManager employeeManager = new EmployeeManager();
            if (employeeManager.editEmployee(id, Convert.ToString(value)) == true)
                return StatusCode((int)HttpStatusCode.OK, new { description = "OK", status = HttpStatusCode.Created });
            else
                return StatusCode((int)HttpStatusCode.NotFound, new { description = "Not Executed Successfully", status = HttpStatusCode.Created });
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, dynamic value)
        {
            EmployeeManager employeeManager = new EmployeeManager();
            if (employeeManager.deleteEmployee(id, Convert.ToString(value)) == true)
                return StatusCode((int)HttpStatusCode.OK, new { description = "OK", status = HttpStatusCode.Created });
            else
                return StatusCode((int)HttpStatusCode.NotFound, new { description = "Not Executed Successfully", status = HttpStatusCode.Created });
        }
    }
}
