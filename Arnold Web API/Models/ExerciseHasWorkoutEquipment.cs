#nullable disable

namespace Arnold_Web_API.Models
{
    public class ExerciseHasWorkoutEquipment
    {
        public int ExerciseIdexercise { get; set; }
        public int WorkoutEquipmentIdworkoutEquipment { get; set; }

        public Exercise Exercise { get; set; }
        public WorkoutEquipment WorkoutEquipment { get; set; }
    }
}
