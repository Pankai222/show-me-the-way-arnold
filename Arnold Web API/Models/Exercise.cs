using System.Collections.Generic;

#nullable disable

namespace Arnold_Web_API.Models
{
    public class Exercise
    {
        public Exercise()
        {
            ExerciseHasMuscles = new HashSet<ExerciseHasMuscle>();
            ExerciseHasWorkoutEquipments = new HashSet<ExerciseHasWorkoutEquipment>();
            ExerciseVideos = new HashSet<ExerciseVideo>();
            WorkoutRoutineHasExercises = new HashSet<WorkoutRoutineHasExercise>();
        }

        public int Idexercise { get; set; }
        public string Category { get; set; }
        public sbyte Compound { get; set; }
        public string Name { get; set; }

        public ICollection<ExerciseHasMuscle> ExerciseHasMuscles { get; set; }
        public ICollection<ExerciseHasWorkoutEquipment> ExerciseHasWorkoutEquipments { get; set; }
        public ICollection<ExerciseVideo> ExerciseVideos { get; set; }
        public ICollection<WorkoutRoutineHasExercise> WorkoutRoutineHasExercises { get; set; }
    }
}
