using System.Text.Json.Serialization;

namespace Show_Me_The_Way_Arnold.Models
{
    public class WorkoutRoutineHasExercises
    {
        public int? Sets { get; set; }
        public int? Repetitions { get; set; }
        [JsonPropertyName("exerciseidexercise")]
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
    }
}