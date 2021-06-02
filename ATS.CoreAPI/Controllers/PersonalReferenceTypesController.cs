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
    public class PersonalReferenceTypesController : ControllerBase
    {
        private readonly IPersonalReferenceTypesBusiness _personalReferenceTypesBusiness;

        public PersonalReferenceTypesController(IPersonalReferenceTypesBusiness personalReferenceTypesBusiness)
        {
            _personalReferenceTypesBusiness = personalReferenceTypesBusiness;
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var result = _personalReferenceTypesBusiness.Get(id);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            var result = _personalReferenceTypesBusiness.GetAll();
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpGet("GetOnlyActives")]
        public IActionResult GetOnlyActives()
        {
            var result = _personalReferenceTypesBusiness.GetOnlyActives();
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpPost("Save")]
        public IActionResult Save(PersonalReferenceType personalReferenceType)
        {
            var result = _personalReferenceTypesBusiness.Save(personalReferenceType);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            PersonalReferenceType personalReference = _personalReferenceTypesBusiness.Get(id);

            if (personalReference != null && personalReference.ID > 0)
            {
                var result = _personalReferenceTypesBusiness.Delete(personalReference.ID);
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
            PersonalReferenceType personalReference = _personalReferenceTypesBusiness.GetByName(name);

            if (personalReference != null && personalReference.ID > 0)
            {
                var result = _personalReferenceTypesBusiness.Delete(personalReference.ID);
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
