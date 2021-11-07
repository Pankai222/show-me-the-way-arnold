using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arnold_Web_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Arnold_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        private readonly ILogger<WorkoutController> _logger;
        private readonly WorkoutdbContext _context;

        public WorkoutController(ILogger<WorkoutController> logger, WorkoutdbContext workoutdbContext)
        {
            _logger = logger;
            _context = workoutdbContext;
        }
        
        // GET: api/WorkoutRoutine
        [HttpGet]
        public ActionResult<WorkoutRoutine> GetWorkouts()
        {
            var workoutRoutines = _context.WorkoutRoutines.ToList();

            if (workoutRoutines.Count == 0)
            {
                return NotFound();
            }
            
            return Ok(workoutRoutines);
        }

        // GET: api/WorkoutRoutine/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<WorkoutRoutine> GetWorkoutById(int id)
        {
            var workoutRoutine = _context.WorkoutRoutines.Find(id);

            if (workoutRoutine is null)
            {
                return NotFound();
            }

            return Ok(workoutRoutine);
        }

        // POST: api/WorkoutRoutine
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/WorkoutRoutine/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/WorkoutRoutine/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
