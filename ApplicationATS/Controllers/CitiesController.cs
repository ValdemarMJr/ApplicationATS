using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApplicationATS.Models;

namespace ApplicationATS.Controllers
{
    [Route("api/[controller]")]
    public class CitiesController : ControllerBase
    {
        private readonly AtsDbContext _context;

        public CitiesController(AtsDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<City> Get()
        {
            return (IEnumerable<City>)_context.Cities.ToList();
        }


    }
}
