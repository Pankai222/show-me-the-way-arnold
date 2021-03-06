using System.Collections.Generic;
using System.Threading.Tasks;
using Arnold_Web_GraphAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Neo4j.Driver;

namespace Arnold_Web_GraphAPI.Controllers
{
    [Route("/api/graph/[controller]")]
    [ApiController]
    public class CreatorController : ControllerBase
    {
        private readonly IDriver _driver;

        public CreatorController(IDriver driver)
        {
            _driver = driver;
        }

        [HttpGet]
        public async Task<ActionResult<List<Creator>>> GetCreators()
        {
            await using var session = _driver.AsyncSession();
            var creators = await session.ReadTransactionAsync(async tx =>
            {
                var result = await tx.RunAsync(@"MATCH (c:Creator)-[:CREATED]->(w: Workout)
                                                    RETURN c.firstname as firstname, 
                                                           c.lastname as lastname,
                                                           COLLECT({
                                                               name: w.name,
                                                               duration: w.duration,
                                                               difficulty: w.difficulty
                                                           }) as workouts");
                return await result.ToListAsync(entry => new Creator(
                    entry["firstname"].As<string>(),
                    entry["lastname"].As<string>(),
                    entry["workouts"].As<List<IDictionary<string, object>>>()));
            });

            if (creators is null)
            {
                return NotFound();
            }

            return Ok(creators);
        }

        [HttpGet("{firstname}")]
        public async Task<ActionResult<Creator>> GetCreator(string firstname)
        {
            await using var session = _driver.AsyncSession();
            var creator = await session.ReadTransactionAsync(async tx =>
            {
                var result = await tx.RunAsync(@"MATCH (creator:Creator)-[:CREATED]->(w:Workout)
                                                        WHERE TOLOWER(creator.firstname) = TOLOWER($firstname)
                                                        RETURN creator.firstname as firstname,
                                                               creator.lastname as lastname,
                                                               COLLECT({
                                                                   name: w.name,
                                                                   duration: w.duration,
                                                                   difficulty: w.difficulty
                                                               }) as workouts", new {firstname});
                return await result.SingleAsync(entry => new Creator(
                    entry["firstname"].As<string>(),
                    entry["lastname"].As<string>(),
                    entry["workouts"].As<List<IDictionary<string, object>>>()));
            });

            if (creator is null)
            {
                return NotFound();
            }

            return Ok(creator);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCreator(string firstname, string? lastname)
        {
            await using var session = _driver.AsyncSession();
            await session.WriteTransactionAsync(tx =>
                tx.RunAsync(@"CREATE (:Creator {firstname: $firstname, lastname: $lastname})", new {firstname, lastname}));
            return StatusCode(201, "Creator created");
        }

        [HttpDelete("{firstname}")]
        public async Task<IActionResult> DeleteCreator(string firstname)
        {
            await using var session = _driver.AsyncSession();
            await session.WriteTransactionAsync(tx =>
                tx.RunAsync(@"MATCH (creator:Creator) WHERE creator.firstname = $firstname DETACH DELETE creator", new {firstname}));
            return StatusCode(201, "Creator deleted");
        }
    }
}