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
            var exercises = await _context.Exercises
                .Include(eq => eq.ExerciseHasWorkoutEquipment)
                    .ThenInclude(we => we.WorkoutEquipment)
                .Include(m => m.ExerciseHasMuscles)
                    .ThenInclude(mu => mu.Muscle)
                .Include(ev => ev.ExerciseVideos)
                .AsNoTracking()
                .ToListAsync();

            if (exercises.Count == 0)
            {
                return NotFound();
            }

            return Ok(exercises);
        }

        // GET: api/Exercise/id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Exercise>> GetExerciseById(int id)
        {
            var exercise = await _context.Exercises
                .Where(exercise => exercise.Id == id)
                .Include(eq => eq.ExerciseHasWorkoutEquipment)
                    .ThenInclude(we => we.WorkoutEquipment)
                .Include(m => m.ExerciseHasMuscles)
                    .ThenInclude(mu => mu.Muscle)
                .Include(ev => ev.ExerciseVideos)
                .AsNoTracking()
                .ToListAsync();
            
            if (exercise is null)
            {
                return NotFound();
            }

            return Ok(exercise);
        }

        // PUT: api/Exercise/id
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Exercise>> UpdateExercise(int id, Exercise exercise)
        {
            if (id != exercise.Id) { return BadRequest("Exercise ID mismatch"); }

            var exerciseToUpdate = await GetExerciseById(id);
            if (exerciseToUpdate is null) { return NotFound("Exercise not found"); }

            var result = await _context.Exercises.FirstOrDefaultAsync(e => e.Id == exercise.Id);
            if (result == null) return BadRequest("Failed to update exercise");
            
            result.Name = exercise.Name;
            result.Category = exercise.Category;
            result.Compound = exercise.Compound;

            await _context.SaveChangesAsync();

            return Ok(exerciseToUpdate);

        }

        // POST: api/Exercise
        [HttpPost]
        public async Task<ActionResult<Exercise>> CreateExercise([FromBody] Exercise exercise)
        {
            _context.Exercises.Add(exercise);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetExerciseById), new {id = exercise.Id}, exercise);
        }

        // DELETE: api/Exercise/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // TODO: check if the thing we are trying to remove actually exists :^)
            _context.Exercises.Remove(_context.Exercises.Single(exercise => exercise.Id == id));
            _context.SaveChangesAsync();
        }
    }
}