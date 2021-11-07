#nullable disable

namespace Arnold_Web_API.Models
{
    public class WorkoutRoutineHasExercise
    {
        public int WorkoutRoutineIdworkoutRoutine { get; set; }
        public int ExerciseIdexercise { get; set; }
        public int? Sets { get; set; }
        public int? Repetitions { get; set; }

        public Exercise ExerciseIdexerciseNavigation { get; set; }
        public WorkoutRoutine WorkoutRoutineIdworkoutRoutineNavigation { get; set; }
    }
}
