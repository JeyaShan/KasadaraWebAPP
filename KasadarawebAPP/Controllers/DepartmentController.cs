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
    public class DepartmentController : ApiController
    {
        private readonly IDepartmentRepository _repo;

        public DepartmentController(IDepartmentRepository repo)
        {
            _repo = repo;
        }
        [Route("CreateDepartment")]
        [HttpPost]
        public IHttpActionResult CreateDepartment(Departmenttable dep)
        {
            var result = _repo.CreateDepartment(dep);
            return Ok(result);
        }

        [Route("UpdateDepartment")]
        [HttpPost]
        public IHttpActionResult UpdateDepartment(Departmenttable dep)
        {
            var result = _repo.UpdateDepartment(dep);
            return Ok(result);
        }

        [Route("DeleteDepartment/{ID}")]
        [HttpDelete]
        public IHttpActionResult DeleteDepartment(int ID)
        {
            var result = _repo.DeleteDepartment(ID);
            return Ok(result);
        }

        [Route("DepartmentData/{ID}")]
        [HttpGet]
        public IHttpActionResult DepartmentData(int ID)
        {
            var result = _repo.DepartmentData(ID);
            return Ok(result);
        }

        [Route("DepartmentList")]
        [HttpGet]
        public IHttpActionResult DepartmentList()
        {
            var result = _repo.DepartmentList();
            return Ok(result);
        }

        
    }
}
