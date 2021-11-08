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
        
        // GET: api/Exercise/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Exercise>> GetExerciseById(int id)
        {
            var exercise = await _context.Exercises.Where(exercise => exercise.Idexercise == id).ToListAsync();

            if (exercise is null)
            {
                return NotFound();
            }

            return Ok(exercise);
        }
        
        // PUT: api/Exercise/id
        [HttpPut]
        public ActionResult<Exercise> Put([FromBody] Exercise exercise)
        {
            var exerciseToUpdate = _context.Exercises.FirstOrDefault(ex => ex.Idexercise == exercise.Idexercise);
            if (exerciseToUpdate is null)
            {
                return NotFound();
            }

            exerciseToUpdate.Name = exercise.Name;
            exerciseToUpdate.Category = exercise.Category;
            exerciseToUpdate.Compound = exercise.Compound;
            _context.Exercises.Update(exerciseToUpdate);
            _context.SaveChangesAsync();
            return Ok(exerciseToUpdate);
        }
        
        // POST: api/Exercise
        [HttpPost]
        public async Task<ActionResult<Exercise>> Post([FromBody] Exercise exercise)
        {
            _context.Exercises.Add(exercise);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetExerciseById), new {id = exercise.Idexercise}, exercise);
        }
        
        // DELETE: api/Exercise/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // TODO: check if the thing we are trying to remove actually exists :^)
            _context.Exercises.Remove(_context.Exercises.Single(exercise => exercise.Idexercise == id));
            _context.SaveChangesAsync();
        }
    }
}