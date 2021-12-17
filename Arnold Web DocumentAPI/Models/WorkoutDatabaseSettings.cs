namespace Arnold_Web_DocumentAPI.Models
{
    public class WorkoutDatabaseSettings : IWorkoutDatabaseSettings
    {
        public string WorkoutRoutinesCollectionName { get; set; }

        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }

    public interface IWorkoutDatabaseSettings
    {
        public string WorkoutRoutinesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
