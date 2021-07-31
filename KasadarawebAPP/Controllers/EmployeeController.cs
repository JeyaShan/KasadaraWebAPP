using KasadarawebAPP.Models;
using KasadarawebAPP.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KasadarawebAPP.Controllers
{
    [RoutePrefix("api/Employee")]
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeRepository _repo;

        public EmployeeController(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        [Route("getdata")]
        [HttpGet]
        public IHttpActionResult getdata()
        {
           var result= _repo.value();
            return Ok(result);
        }

        [Route("CreateEmployee")]
        [HttpPost]
        public IHttpActionResult CreateEmployee(Employeetable emp)
        {
            var result = _repo.CreateEmployee(emp);
            return Ok(result);
        }

        [Route("UpdateEmployee")]
        [HttpPost]
        public IHttpActionResult UpdateEmployee(Employeetable emp)
        {
            var result = _repo.UpdateEmployee(emp);
            return Ok(result);
        }

        [Route("DeleteEmployee/{ID}")]
        [HttpDelete]
        public IHttpActionResult DeleteEmployee(int ID)
        {
            var result = _repo.DeleteEmployee(ID);
            return Ok(result);
        }

        [Route("EmployeeData/{ID}")]
        [HttpGet]
        public IHttpActionResult EmployeeData(int ID)
        {
            var result = _repo.EmployeeData(ID);
            return Ok(result);
        }

        [Route("EmployeeList")]
        [HttpGet]
        public IHttpActionResult EmployeeList()
        {
            var result = _repo.EmployeeList();
            return Ok(result);
        }

        [Route("EmployeeHireDateList")]
        [HttpGet]
        public IHttpActionResult EmployeeHireDateList()
        {
            var result = _repo.EmployeeDateHireList();
            return Ok(result);
        }
    }
}
