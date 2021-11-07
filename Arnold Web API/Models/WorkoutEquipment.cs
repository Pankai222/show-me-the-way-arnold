using System.Collections.Generic;

#nullable disable

namespace Arnold_Web_API.Models
{
    public class WorkoutEquipment
    {
        public WorkoutEquipment()
        {
            ExerciseHasWorkoutEquipments = new HashSet<ExerciseHasWorkoutEquipment>();
        }

        public int IdworkoutEquipment { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ExerciseHasWorkoutEquipment> ExerciseHasWorkoutEquipments { get; set; }
    }
}
