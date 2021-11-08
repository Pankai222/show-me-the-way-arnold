using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arnold_Web_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Arnold_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly ILogger<ExerciseController> _logger;
        private readonly WorkoutdbContext _context;

        public ExerciseController(ILogger<ExerciseController> logger, WorkoutdbContext workoutdbContext)
        {
            _logger = logger;
            _context = workoutdbContext;
        }
        
        [HttpGet]
        public async Task<ActionResult<Exercise>> GetExercises()
        {
            var exercises = await _context.Exercises.ToListAsync();

            if (exercises.Count == 0)
            {
                return NotFound();
            }
            
            return Ok(exercises);
        }
    }
}