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
    public class StateController : ControllerBase
    {
        private readonly IStateBusiness _stateBusiness;

        public StateController(IStateBusiness stateBusiness)
        {
            _stateBusiness = stateBusiness;
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var result = _stateBusiness.Get(id);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            var result = _stateBusiness.GetAll();
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpGet("GetOnlyActives")]
        public IActionResult GetOnlyActives()
        {
            var result = _stateBusiness.GetOnlyActives();
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpPost("Save")]
        public IActionResult Save(State state)
        {
            var result = _stateBusiness.Save(state);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            State state = _stateBusiness.Get(id);

            if (state != null && state.ID > 0)
            {
                var result = _stateBusiness.Delete(state.ID);
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
            State state = _stateBusiness.GetByName(name);

            if (state != null && state.ID > 0)
            {
                var result = _stateBusiness.Delete(state.ID);
                if (result != null)
                    return Ok(result);
                else
                    return BadRequest("Invalid client request");
            }
            else
                return BadRequest("Invalid client request");
        }

        [HttpDelete("DeleteByShortName")]
        public IActionResult DeleteByShortName(string shortName)
        {
            State state = _stateBusiness.GetByShortName(shortName);

            if (state != null && state.ID > 0)
            {
                var result = _stateBusiness.Delete(state.ID);
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
