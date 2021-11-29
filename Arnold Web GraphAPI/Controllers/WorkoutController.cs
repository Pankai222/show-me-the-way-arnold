using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        [HttpPost]
        public async Task<IActionResult> CreateWorkout(string name)
        { 
            await using var session = _driver.AsyncSession();
            await session.WriteTransactionAsync(tx => tx.RunAsync("CREATE (workout:Workout {name: $name})", new Dictionary<string, object>{{"name", name}}));
            return StatusCode(201, "Workout created");
        }
    }
}
