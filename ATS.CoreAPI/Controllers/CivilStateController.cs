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
    public class CivilStateController : ControllerBase
    {
        private readonly ICivilStateBusiness _civilStateBusiness;

        public CivilStateController(ICivilStateBusiness civilStateBusiness)
        {
            _civilStateBusiness = civilStateBusiness;
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var result = _civilStateBusiness.Get(id);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            var result = _civilStateBusiness.GetAll();
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpGet("GetOnlyActives")]
        public IActionResult GetOnlyActives()
        {
            var result = _civilStateBusiness.GetOnlyActives();
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpPost("Save")]
        public IActionResult Save(CivilState civilState)
        {
            var result = _civilStateBusiness.Save(civilState);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            CivilState civilState = _civilStateBusiness.Get(id);

            if (civilState != null && civilState.ID > 0)
            {
                var result = _civilStateBusiness.Delete(civilState.ID);
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
            CivilState civilState = _civilStateBusiness.GetByName(name);

            if (civilState != null && civilState.ID > 0)
            {
                var result = _civilStateBusiness.Delete(civilState.ID);
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
