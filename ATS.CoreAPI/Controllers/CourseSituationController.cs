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
    public class CourseSituationController : ControllerBase
    {
        private readonly ICourseSituationBusiness _courseSituationBusiness;

        public CourseSituationController(ICourseSituationBusiness courseSituationBusiness)
        {
            _courseSituationBusiness = courseSituationBusiness;
        }
        [HttpGet]
        public IActionResult Get(int id)
        {
            var result = _courseSituationBusiness.Get(id);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            var result = _courseSituationBusiness.GetAll();
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpGet("GetOnlyActives")]
        public IActionResult GetOnlyActives()
        {
            var result = _courseSituationBusiness.GetOnlyActives();
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpPost("Save")]
        public IActionResult Save(CourseSituation courseSituation)
        {
            var result = _courseSituationBusiness.Save(courseSituation);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            CourseSituation courseSituation = _courseSituationBusiness.Get(id);

            if (courseSituation != null && courseSituation.ID > 0)
            {
                var result = _courseSituationBusiness.Delete(courseSituation.ID);
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
            CourseSituation courseSituation = _courseSituationBusiness.GetByName(name);

            if (courseSituation != null && courseSituation.ID > 0)
            {
                var result = _courseSituationBusiness.Delete(courseSituation.ID);
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
