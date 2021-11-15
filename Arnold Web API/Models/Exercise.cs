using System.Collections.Generic;

namespace Arnold_Web_API.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public bool Compound { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<ExerciseHasMuscle>? ExerciseHasMuscles { get; set; }
        public virtual ICollection<ExerciseHasWorkoutEquipment>? ExerciseHasWorkoutEquipment { get; set; }
        public virtual ICollection<ExerciseVideo>? ExerciseVideos { get; set; }
        
    }
}
