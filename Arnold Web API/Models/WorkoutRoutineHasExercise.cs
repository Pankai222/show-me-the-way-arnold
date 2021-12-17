using System.Text.Json.Serialization;

namespace Arnold_Web_API.Models
{
    public class WorkoutRoutineHasExercise
    {
        public int WorkoutRoutineId { get; set; }
        public int ExerciseId { get; set; }
        public int? Sets { get; set; }
        public int? Repetitions { get; set; }
        
        public virtual Exercise? Exercise { get; set; }
    }
}
