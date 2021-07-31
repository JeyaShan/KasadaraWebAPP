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
    public class GradeController : ApiController
    {
        private readonly IGradeRepository _repo;

        public GradeController(IGradeRepository repo)
        {
            _repo = repo;
        }

        [Route("CreateGrade")]
        [HttpPost]
        public IHttpActionResult CreateGrade(Gradetable grade)
        {
            var result = _repo.CreateGrade(grade);
            return Ok(result);
        }

        [Route("UpdateGrade")]
        [HttpPost]
        public IHttpActionResult UpdateGrade(Gradetable grade)
        {
            var result = _repo.UpdateGrade(grade);
            return Ok(result);
        }

        [Route("DeleteGrade/{ID}")]
        [HttpDelete]
        public IHttpActionResult DeleteGrade(int ID)
        {
            var result = _repo.DeleteGrade(ID);
            return Ok(result);
        }

        [Route("GradeData/{ID}")]
        [HttpGet]
        public IHttpActionResult GradeData(int ID)
        {
            var result = _repo.GradeData(ID);
            return Ok(result);
        }

        [Route("GradeList")]
        [HttpGet]
        public IHttpActionResult GradeList()
        {
            var result = _repo.GradeList();
            return Ok(result);
        }
    }
}
