using System.Collections.Generic;
using System.Threading.Tasks;
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
        public Task<List<WorkoutRoutine>> Get() => _workoutService.Get();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<WorkoutRoutine>> Get(string id)
        {
            var workout = await _workoutService.Get(id);

            if (workout is null)
            {
                return NotFound();
            }
            return workout;
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(WorkoutRoutine workoutRoutine)
        {
            await _workoutService.Create(workoutRoutine);

            return CreatedAtAction(nameof(Get), new { id = workoutRoutine.Id }, workoutRoutine);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, WorkoutRoutine updatedBook)
        {
            var book = await _workoutService.Get(id);

            if (book is null)
            {
                return NotFound();
            }

            updatedBook.Id = book.Id;

            await _workoutService.Update(id, updatedBook);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var book = await _workoutService.Get(id);

            if (book is null)
            {
                return NotFound();
            }

            await _workoutService.Remove(book.Id);

            return NoContent();
        }
    }
}
