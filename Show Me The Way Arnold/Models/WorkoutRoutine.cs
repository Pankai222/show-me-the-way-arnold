using System.Collections.Generic;

namespace Show_Me_The_Way_Arnold.Models
{
    public class WorkoutRoutine
    {
        public string Name { get; set; }
        public string Duration { get; set; }
        public int? Difficulty { get; set; }
        public List<Exercise> WorkoutRoutineHasExercises { get; set; }
    }
}