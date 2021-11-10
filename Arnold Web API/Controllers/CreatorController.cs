using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arnold_Web_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Arnold_Web_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CreatorController : ControllerBase
    {
        private readonly WorkoutdbContext _context;
        
        public CreatorController(WorkoutdbContext workoutdbContext)
        {
            _context = workoutdbContext;
        }
        
        // GET: api/Creator
        [HttpGet]
        public async Task<ActionResult<Creator>> GetCreators()
        {
            var creators = await _context.Creators
                .Include(c => c.Contacts)
                .Include(w => w.WorkoutRoutines)
                .ToListAsync();

            return Ok(creators);
        }
    }
}
