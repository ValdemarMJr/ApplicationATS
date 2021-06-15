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
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateBusiness _candidateBusiness;

        public CandidateController(ICandidateBusiness candidateBusiness)
        {
            _candidateBusiness = candidateBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var claims = User.Claims;
            var result = _candidateBusiness.Get(Convert.ToInt32(claims.First(claim => claim.Type.Equals("id")).Value));
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }
        [HttpGet("Get")]
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


        [HttpGet("GetContacts")]
        public IActionResult GetContactsByCandidate()
        {
            var claims = User.Claims;
            var result = _candidateBusiness.GetContactsByCandidate(Convert.ToInt32(claims.First(claim => claim.Type.Equals("id")).Value));
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }
        [HttpGet("GetContactsByCandidateID")]
        public IActionResult GetContactsByCandidate(int candidateID)
        {
            var result = _candidateBusiness.GetContactsByCandidate(candidateID);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpGet("GetPersonalReferences")]
        public IActionResult GetPersonalReferencesByCandidate()
        {
            var claims = User.Claims;
            var result = _candidateBusiness.GetPersonalReferencesByCandidate(Convert.ToInt32(claims.First(claim => claim.Type.Equals("id")).Value));
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }
        [HttpGet("GetPersonalReferencesByCandidateID")]
        public IActionResult GetPersonalReferencesByCandidate(int candidateID)
        {
            var result = _candidateBusiness.GetPersonalReferencesByCandidate(candidateID);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpGet("GetAcademicEducation")]
        public IActionResult GetAcademicEducationByCandidate()
        {
            var claims = User.Claims;
            var result = _candidateBusiness.GetAcademicEducationByCandidate(Convert.ToInt32(claims.First(claim => claim.Type.Equals("id")).Value));
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpGet("GetAcademicEducationByCandidateID")]
        public IActionResult GetAcademicEducationByCandidate(int candidateID)
        {
            var result = _candidateBusiness.GetAcademicEducationByCandidate(candidateID);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpGet("GetImprovmentCourses")]
        public IActionResult GetImprovmentCoursesByCandidate()
        {
            var claims = User.Claims;
            var result = _candidateBusiness.GetImprovmentCoursesByCandidate(Convert.ToInt32(claims.First(claim => claim.Type.Equals("id")).Value));
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }
        [HttpGet("GetImprovmentCoursesByCandidateID")]
        public IActionResult GetImprovmentCoursesByCandidate(int candidateID)
        {
            var result = _candidateBusiness.GetImprovmentCoursesByCandidate(candidateID);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpGet("GetExperiences")]
        public IActionResult GetExperiencesByCandidate()
        {
            var claims = User.Claims;
            var result = _candidateBusiness.GetExperiencesByCandidate(Convert.ToInt32(claims.First(claim => claim.Type.Equals("id")).Value));
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }
        [HttpGet("GetExperiencesByCandidateID")]
        public IActionResult GetExperiencesByCandidate(int candidateID)
        {
            var result = _candidateBusiness.GetExperiencesByCandidate(candidateID);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpGet("GetRoles")]
        public IActionResult GetRolesByCandidate()
        {
            var claims = User.Claims;
            var result = _candidateBusiness.GetRolesByCandidate(Convert.ToInt32(claims.First(claim => claim.Type.Equals("id")).Value));
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpGet("GetRolesByCandidateID")]
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


        [HttpPost("SaveCandidateAcademicEducation")]
        public IActionResult SaveCandidateAcademicEducation(CandidateAcademicEducation candidateAcademicEducation)
        {
            var result = _candidateBusiness.SaveCandidateAcademicEducation(candidateAcademicEducation);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpPost("SaveCandidateExperiences")]
        public IActionResult SaveCandidateExperiences(CandidateExperience candidateExperience)
        {
            var result = _candidateBusiness.SaveCandidateExperiences(candidateExperience);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }


        [HttpPost("SaveCandidateImprovmentCourse")]
        public IActionResult SaveCandidateImprovmentCourse(CandidateImprovementCourse candidateImprovmentCourse)
        {
            var result = _candidateBusiness.SaveCandidateImprovmentCourse(candidateImprovmentCourse);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpPost("SaveCandidatePersonalReferences")]
        public IActionResult SaveCandidatePersonalReferences(CandidatePersonalReference candidatePersonalReference)
        {
            var result = _candidateBusiness.SaveCandidatePersonalReferences(candidatePersonalReference);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpPost("SaveCandidateRoles")]
        public IActionResult SaveCandidateRoles(CandidateRole candidateRole)
        {
            var result = _candidateBusiness.SaveCandidateRoles(candidateRole);
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
