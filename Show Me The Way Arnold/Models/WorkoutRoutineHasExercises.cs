namespace Show_Me_The_Way_Arnold.Models
{
    public class WorkoutRoutineHasExercises
    {
        public int? Sets { get; set; }
        public int? Repetitions { get; set; }
        public int ExerciseIdExercise { get; set; }
        public Exercise Exercise { get; set; }
    }
}