namespace Show_Me_The_Way_Arnold.Models
{
    public class WorkoutRoutineHasExercises
    {
        public int Sets { get; set; }
        public int Reps { get; set; }
        public Exercise Exercise { get; set; }
    }
}