using ApplicationATS.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationATS.Controllers
{
    [Route("api/[controller]")]
    public class StatiesController : Controller
    {
        private readonly AtsDbContext _context;

        public StatiesController(AtsDbContext context)
        {
            _context = context;
        }

        public IEnumerable<State> Get()
        {
            return (IEnumerable<State>)_context.States.ToList();
        }

        public State Get(int cdState)
        {
            State state = _context.States.First(s => s.CdState == cdState);
            return state;
        }

        public State GetByShortName(string shortName)
        {
            State state = _context.States.First(s => s.DsShorName == shortName);
            return state;
        }

        public void Insert([FromBody] State state)
        {
            _context.States.Add(state);
        }

        public void Delete(int cdState)
        {
            State state = Get(cdState);

            if (state != null && state.CdState > 0)
                _context.States.Remove(state);
        }

    }
}
