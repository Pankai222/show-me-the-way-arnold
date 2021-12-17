using System.Collections.Generic;
using Arnold_Web_DocumentAPI.Models;
using Arnold_Web_DocumentAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Arnold_Web_DocumentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        private readonly WorkoutService _workoutService;  
  
        public WorkoutController(WorkoutService workoutService)  
        {  
            _workoutService = workoutService;
        }

        [HttpGet]
        public ActionResult<List<WorkoutRoutine>> Get() => _workoutService.Get();

        [HttpGet("{id}", Name = "Get")]
        public ActionResult<WorkoutRoutine> Get(string id)
        {
            var workout = _workoutService.Get(id);

            if (workout is null)
            {
                return NotFound();
            }

            return workout;
        }
        
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
        
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
