using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Arnold_Web_DocumentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        // GET: api/Workout
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Workout/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Workout
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Workout/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Workout/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
