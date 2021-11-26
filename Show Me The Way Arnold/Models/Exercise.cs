using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Show_Me_The_Way_Arnold.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public bool Compound { get; set; }

        public List<ExerciseHasMuscles> Muscles { get; set; }
        public List<ExerciseHasWorkoutEquipment> Equipment { get; set; }
    }

    public class ExerciseHasMuscles
    {
        public int MuscleId { get; set; }
        public Muscle Muscle { get; set; }
    }

    public class ExerciseHasWorkoutEquipment
    {
        public int WorkoutEquipmentId { get; set; }
        public WorkoutEquipment WorkoutEquipment { get; set; }
    }
}