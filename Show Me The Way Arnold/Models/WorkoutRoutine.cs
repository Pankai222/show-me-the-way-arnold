using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Show_Me_The_Way_Arnold.Models
{
    public class WorkoutRoutine
    {
        public string Name { get; set; }
        public string Duration { get; set; }
        public int? Difficulty { get; set; }
        public List<WorkoutRoutineHasExercises>? WorkoutRoutineHasExercises { get; set; }
    }
    
    public class WorkoutRoutineHasExercises
    {
        public int? Sets { get; set; }
        public int? Repetitions { get; set; }
        public int ExerciseId { get; set; }
        public Exercise? Exercise { get; set; }
    }
}