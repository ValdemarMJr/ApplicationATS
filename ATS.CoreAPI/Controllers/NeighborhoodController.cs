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
    public class NeighborhoodController : ControllerBase
    {
        private readonly INeighborhoodBusiness _neighborhoodBusiness;

        public NeighborhoodController(INeighborhoodBusiness neighborhoodBusiness)
        {
            _neighborhoodBusiness = neighborhoodBusiness;
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var result = _neighborhoodBusiness.Get(id);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _neighborhoodBusiness.GetAll();
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpGet("GetOnlyActives")]
        public IActionResult GetOnlyActives()
        {
            var result = _neighborhoodBusiness.GetOnlyActives();
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }


        [HttpGet("GetByCity")]
        public IActionResult GetByCity(int cityID, bool onlyActives)
        {
            var result = _neighborhoodBusiness.GetByCity(cityID, onlyActives);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpGet("GetByName")]
        public IActionResult GetByName(int cityID, string name)
        {
            var result = _neighborhoodBusiness.GetByName(cityID, name);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpPost("Save")]
        public IActionResult Save(Neighborhood neighborhood)
        {
            var result = _neighborhoodBusiness.Save(neighborhood);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            Neighborhood neighborhood = _neighborhoodBusiness.Get(id);

            if (neighborhood != null && neighborhood.ID > 0)
            {
                var result = _neighborhoodBusiness.Delete(neighborhood.ID);
                if (result != null)
                    return Ok(result);
                else
                    return BadRequest("Invalid client request");
            }
            else
                return BadRequest("Invalid client request");
        }

        [HttpDelete("DeleteByName")]
        public IActionResult DeleteByName(int cityID, string name)
        {
            Neighborhood neighborhood = _neighborhoodBusiness.GetByName(cityID, name);

            if (neighborhood != null && neighborhood.ID > 0)
            {
                var result = _neighborhoodBusiness.Delete(neighborhood.ID);
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
