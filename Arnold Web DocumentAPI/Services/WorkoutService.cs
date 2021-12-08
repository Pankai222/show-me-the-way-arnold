using System.Collections.Generic;
using Arnold_Web_DocumentAPI.Models;
using MongoDB.Driver;

namespace Arnold_Web_DocumentAPI.Services
{
    public class WorkoutService
    {
        private readonly IMongoCollection<WorkoutRoutine> _workoutRoutines;

        public WorkoutService(IWorkoutDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _workoutRoutines = database.GetCollection<WorkoutRoutine>(settings.WorkoutRoutinesCollectionName);
        }

        public List<WorkoutRoutine> Get()
        {
            List<WorkoutRoutine> workoutRoutines = _workoutRoutines.Find(emp => true).ToList();
            return workoutRoutines;
        }

        public WorkoutRoutine Get(string id) =>
            _workoutRoutines.Find(emp => emp.Id == id).FirstOrDefault();
    }
}