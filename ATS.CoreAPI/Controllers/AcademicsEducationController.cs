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
    public class AcademicsEducationController : ControllerBase
    {
        private readonly IAcademicsEducationBusiness _academicsEducationBusiness;

        public AcademicsEducationController(IAcademicsEducationBusiness academicsEducationBusiness)
        {
            _academicsEducationBusiness = academicsEducationBusiness;
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var result = _academicsEducationBusiness.Get(id);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            var result = _academicsEducationBusiness.GetAll();
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpGet("GetOnlyActives")]
        public IActionResult GetOnlyActives()
        {
            var result = _academicsEducationBusiness.GetOnlyActives();
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpPost("Save")]
        public IActionResult Save(AcademicEducation academicEducation)
        {
            var result = _academicsEducationBusiness.Save(academicEducation);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            AcademicEducation academicEducation = _academicsEducationBusiness.Get(id);

            if (academicEducation != null && academicEducation.ID > 0)
            {
                var result = _academicsEducationBusiness.Delete(academicEducation.ID);
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
            AcademicEducation academicEducation = _academicsEducationBusiness.GetByName(name);

            if (academicEducation != null && academicEducation.ID > 0)
            {
                var result = _academicsEducationBusiness.Delete(academicEducation.ID);
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
