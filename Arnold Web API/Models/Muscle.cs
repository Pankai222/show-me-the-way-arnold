using System.Collections.Generic;

#nullable disable

namespace Arnold_Web_API.Models
{
    public class Muscle
    {
        public Muscle()
        {
            ExerciseHasMuscles = new HashSet<ExerciseHasMuscle>();
        }

        public int Idmuscle { get; set; }
        public string Name { get; set; }
        public string Bodypart { get; set; }
        public string Musclegroup { get; set; }

        public virtual ICollection<ExerciseHasMuscle> ExerciseHasMuscles { get; set; }
    }
}
