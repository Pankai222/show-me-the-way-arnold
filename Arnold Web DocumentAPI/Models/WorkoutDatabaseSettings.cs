namespace Arnold_Web_DocumentAPI.Models
{
    public class WorkoutDatabaseSettings : IWorkoutDatabaseSettings
    {
        public string WorkoutRoutinesCollectionName { get; set; } = null!;

        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;
    }

    public interface IWorkoutDatabaseSettings
    {
        public string WorkoutRoutinesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
