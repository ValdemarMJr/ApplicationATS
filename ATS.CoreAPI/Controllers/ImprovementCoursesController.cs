using ATS.CoreAPI.Business;
using ATS.CoreAPI.Model.Entitys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class ImprovementCoursesController : ControllerBase
    {
        private readonly IImprovementCourseBusiness _improvementCourseBusiness;

        public ImprovementCoursesController(IImprovementCourseBusiness improvementCourseBusiness)
        {
            _improvementCourseBusiness = improvementCourseBusiness;
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var result = _improvementCourseBusiness.Get(id);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            var result = _improvementCourseBusiness.GetAll();
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpGet("GetOnlyActives")]
        public IActionResult GetOnlyActives()
        {
            var result = _improvementCourseBusiness.GetOnlyActives();
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpPost("Save")]
        public IActionResult Save(ImprovementCourse civilState)
        {
            var result = _improvementCourseBusiness.Save(civilState);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            ImprovementCourse improvementCourse = _improvementCourseBusiness.Get(id);

            if (improvementCourse != null && improvementCourse.ID > 0)
            {
                var result = _improvementCourseBusiness.Delete(improvementCourse.ID);
                if (result != null)
                    return Ok(result);
                else
                    return BadRequest("Invalid client request");
            }
            else
                return BadRequest("Invalid client request");
        }

        [HttpDelete("DeleteByName")]
        public IActionResult DeleteByName(string name)
        {
            ImprovementCourse improvementCourse = _improvementCourseBusiness.GetByName(name);

            if (improvementCourse != null && improvementCourse.ID > 0)
            {
                var result = _improvementCourseBusiness.Delete(improvementCourse.ID);
                if (result != null)
                    return Ok(result);
                else
                    return BadRequest("Invalid client request");
            }
            else
                return BadRequest("Invalid client request");
        }
    }
}
