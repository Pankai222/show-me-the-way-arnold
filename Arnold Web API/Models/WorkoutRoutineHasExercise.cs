using System.Text.Json.Serialization;

namespace Arnold_Web_API.Models
{
    public class WorkoutRoutineHasExercise
    {
        public int WorkoutRoutineIdworkoutRoutine { get; set; }
        public int ExerciseIdexercise { get; set; }
        public int? Sets { get; set; }
        public int? Repetitions { get; set; }
        
        public virtual Exercise Exercise { get; set; }
        public virtual WorkoutRoutine WorkoutRoutine { get; set; }
    }
}
