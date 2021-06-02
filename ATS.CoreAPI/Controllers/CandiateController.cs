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
    public class CandiateController : ControllerBase
    {
        private readonly ICandidateBusiness _candidateBusiness;

        public CandiateController(ICandidateBusiness candidateBusiness)
        {
            _candidateBusiness = candidateBusiness;
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var result = _candidateBusiness.Get(id);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpGet("GetByCPF")]
        public IActionResult GetByCPF(string cpf)
        {
            var result = _candidateBusiness.GetByCPF(cpf);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpGet("GetByEmail")]
        public IActionResult GetByEmail(string email)
        {
            var result = _candidateBusiness.GetByEmail(email);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }


        [HttpGet("GetContactsByCandidate")]
        public IActionResult GetContactsByCandidate(int candidateID)
        {
            var result = _candidateBusiness.GetContactsByCandidate(candidateID);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpGet("GetPersonalReferencesByCandidate")]
        public IActionResult GetPersonalReferencesByCandidate(int candidateID)
        {
            var result = _candidateBusiness.GetPersonalReferencesByCandidate(candidateID);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpGet("GetAcademicEducationByCandidate")]
        public IActionResult GetAcademicEducationByCandidate(int candidateID)
        {
            var result = _candidateBusiness.GetAcademicEducationByCandidate(candidateID);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpGet("GetImprovmentCoursesByCandidate")]
        public IActionResult GetImprovmentCoursesByCandidate(int candidateID)
        {
            var result = _candidateBusiness.GetImprovmentCoursesByCandidate(candidateID);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpGet("GetExperiencesByCandidate")]
        public IActionResult GetExperiencesByCandidate(int candidateID)
        {
            var result = _candidateBusiness.GetExperiencesByCandidate(candidateID);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpGet("GetRolesByCandidate")]
        public IActionResult GetRolesByCandidate(int candidateID)
        {
            var result = _candidateBusiness.GetRolesByCandidate(candidateID);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpPost("Save")]
        public IActionResult Save(Candidate candidate)
        {
            var result = _candidateBusiness.Save(candidate);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }


        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            Candidate candidate = _candidateBusiness.Get(id);

            if (candidate != null && candidate.ID > 0)
            {
                var result = _candidateBusiness.Delete(candidate.ID);
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
