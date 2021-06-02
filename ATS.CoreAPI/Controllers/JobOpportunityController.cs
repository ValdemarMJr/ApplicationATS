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
    public class JobOpportunityController : ControllerBase
    {
        private readonly IJobOpportunityBusiness _jobOpportunityBusiness;

        public JobOpportunityController(IJobOpportunityBusiness jobOpportunityBusiness)
        {
            _jobOpportunityBusiness = jobOpportunityBusiness;
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var result = _jobOpportunityBusiness.Get(id);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            var result = _jobOpportunityBusiness.GetAll();
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpGet("GetOnlyActives")]
        public IActionResult GetOnlyActives()
        {
            var result = _jobOpportunityBusiness.GetOnlyActives();
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpPost("Save")]
        public IActionResult Save(JobOpportunity jobOpportunity)
        {
            var result = _jobOpportunityBusiness.Save(jobOpportunity);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            JobOpportunity jobOpportunity = _jobOpportunityBusiness.Get(id);

            if (jobOpportunity != null && jobOpportunity.ID > 0)
            {
                var result = _jobOpportunityBusiness.Delete(jobOpportunity.ID);
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
            JobOpportunity jobOpportunity = _jobOpportunityBusiness.GetByName(name);

            if (jobOpportunity != null && jobOpportunity.ID > 0)
            {
                var result = _jobOpportunityBusiness.Delete(jobOpportunity.ID);
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
