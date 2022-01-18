using System.Collections.Generic;
using System.Threading.Tasks;
using Arnold_Web_GraphAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Neo4j.Driver;

namespace Arnold_Web_GraphAPI.Controllers
{
    [Route("/api/graph/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IDriver _driver;

        public ExerciseController(IDriver driver)
        {
            _driver = driver;
        }

        [HttpGet]
        public async Task<ActionResult<List<Exercise>>> GetExercises()
        {
            await using var session = _driver.AsyncSession();
            var exercises = await session.ReadTransactionAsync(async tx =>
            {
                var resultCursor = await tx.RunAsync(@"MATCH (exercise:Exercise)
                                                     RETURN exercise.name as name,
                                                            exercise.category as category,
                                                            exercise.compound as compound");
                return await resultCursor.ToListAsync(entry => new Exercise(
                    entry["name"].As<string>(),
                    entry["category"].As<string>(),
                    entry["compound"].As<bool>()
                ));
            });

            if (exercises is null)
            {
                return NotFound();
            }

            return Ok(exercises);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Exercise>> GetExercise(string name)
        {
            await using var session = _driver.AsyncSession();
            var exercise = await session.ReadTransactionAsync(async tx =>
            {
                var resultCursor = await tx.RunAsync(@"MATCH (exercise:Exercise)
                                                     WHERE TOLOWER(exercise.name) = TOLOWER($name)
                                                     RETURN exercise.name as name,
                                                            exercise.category as category,
                                                            exercise.compound as compound", new {name});
                return await resultCursor.SingleAsync(entry => new Exercise(
                    entry["name"].As<string>(),
                    entry["category"].As<string>(),
                    entry["compound"].As<bool>()
                ));
            });

            if (exercise is null)
            {
                return NotFound();
            }

            return Ok(exercise);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExercise(string name, string category, bool compound)
        {
            await using var session = _driver.AsyncSession();
            await session.WriteTransactionAsync(tx =>
                tx.RunAsync(@"CREATE (:Exercise {name: $name, category: $category, compound: $compound})",
                    new {name, category, compound}));
            return StatusCode(201, "Exercise created");
        }

        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteExercise(string name)
        {
            await using var session = _driver.AsyncSession();
            await session.WriteTransactionAsync(tx =>
                tx.RunAsync(
                    @"MATCH (exercise:Exercise) WHERE TOLOWER(exercise.name) = TOLOWER($name) DETACH DELETE exercise",
                    new {name}));
            return StatusCode(201, "Exercise deleted");
        }
    }
}