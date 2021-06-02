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
    public class ContactTypeController : ControllerBase
    {
        private readonly IContactTypeBusiness _contactTypeBusiness;

        public ContactTypeController(IContactTypeBusiness contactTypeBusiness)
        {
            _contactTypeBusiness = contactTypeBusiness;
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var result = _contactTypeBusiness.Get(id);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            var result = _contactTypeBusiness.GetAll();
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpGet("GetOnlyActives")]
        public IActionResult GetOnlyActives()
        {
            var result = _contactTypeBusiness.GetOnlyActives();
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpPost("Save")]
        public IActionResult Save(ContactType contactType)
        {
            var result = _contactTypeBusiness.Save(contactType);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            ContactType contactType = _contactTypeBusiness.Get(id);

            if (contactType != null && contactType.ID > 0)
            {
                var result = _contactTypeBusiness.Delete(contactType.ID);
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
            ContactType contactType = _contactTypeBusiness.GetByName(name);

            if (contactType != null && contactType.ID > 0)
            {
                var result = _contactTypeBusiness.Delete(contactType.ID);
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
