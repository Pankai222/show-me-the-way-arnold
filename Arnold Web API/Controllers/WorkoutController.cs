using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arnold_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<ActionResult<WorkoutRoutine>> GetWorkouts()
        {
            var workoutRoutines = await _context.WorkoutRoutines
                 .Include(workout => workout.WorkoutRoutineHasExercises)
                 .ThenInclude(e => e.Exercise)
                 .ToListAsync();

            if (workoutRoutines.Count == 0)
            {
                return NotFound();
            }
            
            return Ok(workoutRoutines);
        }

        // GET: api/WorkoutRoutine/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<WorkoutRoutine>> GetWorkoutById(int id)
        {
            var workoutRoutine = await _context.WorkoutRoutines.Where(x => x.IdworkoutRoutine == id)
                .Include(workout => workout.WorkoutRoutineHasExercises)
                .ThenInclude(e => e.Exercise)
                .ToListAsync();

            if (workoutRoutine is null)
            {
                return NotFound();
            }

            return Ok(workoutRoutine);
        }

        // POST: api/WorkoutRoutine
        [HttpPost]
        public async Task<ActionResult<WorkoutRoutine>> Post(string name, string duration, int difficulty, List<WorkoutRoutineHasExercise> workoutExercises)
        {
            var workoutRoutineExercises = new List<WorkoutRoutineHasExercise>();
            
            workoutRoutineExercises.AddRange(workoutExercises.Select(routineExercise => new WorkoutRoutineHasExercise
            {
                Sets = routineExercise.Sets, 
                Repetitions = routineExercise.Repetitions,
                Exercise = _context.Exercises.Find(routineExercise.ExerciseIdexercise)
            }));
            
            var workout = new WorkoutRoutine
            {
                Name = name,
                Duration = duration,
                Difficulty = difficulty,
                CreatorIdCreator = 1,
                WorkoutRoutineHasExercises = workoutRoutineExercises
            };
            
            _context.WorkoutRoutines.Add(workout);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetWorkoutById), new {id = workout.IdworkoutRoutine}, workout);
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
