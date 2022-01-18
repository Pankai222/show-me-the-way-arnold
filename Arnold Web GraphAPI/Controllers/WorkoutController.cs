using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Arnold_Web_GraphAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Neo4j.Driver;

namespace Arnold_Web_GraphAPI.Controllers
{
    [Route("/api/graph/[controller]")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        private readonly IDriver _driver;
        
        public WorkoutController(IDriver driver)
        {
            _driver = driver;
        }

        [HttpGet]
        public async Task<ActionResult<List<WorkoutRoutine>>> GetWorkouts()
        {
            await using var session = _driver.AsyncSession();
            var workouts = await session.ReadTransactionAsync(async tx =>
            {
                var resultCursor = await tx.RunAsync(@"MATCH (c: Creator)-[:CREATED]->(workout:Workout)-[:HAS]->(e: Exercise)
                                                     RETURN workout.name as name,
                                                            workout.duration as duration,
                                                            workout.difficulty as difficulty,
                                                            workout.createDate as createDate,
                                                            (c.firstname + ' ' + c.lastname) as creator,
                                                            COLLECT({ 
                                                                name: e.name,
                                                                category: e.category,
                                                                compound: e.compound
                                                            }) as exercises");
                return await resultCursor.ToListAsync(entry => new WorkoutRoutine(
                        entry["name"].As<string>(),
                        entry["duration"].As<string>(), 
                        entry["difficulty"].As<int?>(),
                        entry["createDate"].As<DateTime?>(),
                        entry["creator"].As<string?>(),
                        new Util().MapToExercise(entry["exercises"].As<List<IDictionary<string, object>>>())));
            });

            if (workouts is null)
            {
                return NotFound();
            }

            return Ok(workouts);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<WorkoutRoutine>> GetWorkout(string name)
        {
            await using var session = _driver.AsyncSession();
            var workout = await session.ReadTransactionAsync(async tx =>
            {
                    var cursor = await tx.RunAsync(@"MATCH (c: Creator)-[:CREATED]->(workout:Workout)-[:HAS]->(e: Exercise)
                                                WHERE TOLOWER(workout.name) = TOLOWER($name)
                                                RETURN workout.name as name,
                                                       workout.duration as duration,
                                                       workout.difficulty as difficulty,
                                                       workout.createDate as createDate,
                                                       (c.firstname + ' ' + c.lastname) as creator,
                                                       COLLECT({
                                                           name: e.name,
                                                           category: e.category,
                                                           compound: e.compound
                                                       }) as exercises", new Dictionary<string, object>{{"name", name}});
                    
                    return await cursor.SingleAsync(entry => new WorkoutRoutine(
                    entry["name"].As<string>(),
                    entry["duration"].As<string>(),
                    entry["difficulty"].As<int?>(),
                    entry["createDate"].As<DateTime?>(),
                    entry["creator"].As<string?>(),
                    new Util().MapToExercise(entry["exercises"].As<List<IDictionary<string, object>>>())));
            });

            if (workout is null)
            {
                return NotFound();
            }

            return Ok(workout);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorkout(WorkoutRoutine workoutRoutine)
        { 
            await using var session = _driver.AsyncSession();
            await session.WriteTransactionAsync(tx => tx.RunAsync(@"CREATE (workout:Workout {name: $name, duration: $duration,
                                                                                                                      difficulty: $difficulty,
                                                                                                                      createDate: $createDate})
                                                                                             CREATE (workout)-[:HAS]->($exercises)
                                                                                                                      ",
                new WorkoutRoutine(workoutRoutine.Name, workoutRoutine.Duration, workoutRoutine.Difficulty, workoutRoutine.CreateDate, workoutRoutine.Creator, workoutRoutine.Exercises)));
            return StatusCode(201, "Workout created");
        }

        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteWorkout(string name)
        {
            await using var session = _driver.AsyncSession();
            await session.WriteTransactionAsync(tx => tx.RunAsync(@"MATCH (workout:Workout)
                                                                                             WHERE TOLOWER(workout.name) = TOLOWER($name)
                                                                                             DETACH DELETE workout", new Dictionary<string, object>{{"name", name}}));
            return StatusCode(200, "Workout deleted");
        }
    }
}
