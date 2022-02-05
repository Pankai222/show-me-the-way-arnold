using System.Collections.Generic;
using System.Threading.Tasks;
using Arnold_Web_DocumentAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Arnold_Web_DocumentAPI.Services
{
    public class WorkoutService
    {
        private readonly IMongoCollection<WorkoutRoutine> _workoutRoutines;

        public WorkoutService(IOptions<WorkoutDatabaseSettings> workoutDatabaseSettings)
        {
            var client = new MongoClient(workoutDatabaseSettings.Value.ConnectionString);
            var database = client.GetDatabase(workoutDatabaseSettings.Value.DatabaseName);

            _workoutRoutines = database.GetCollection<WorkoutRoutine>(workoutDatabaseSettings.Value.WorkoutRoutinesCollectionName);
        }

        public async Task<List<WorkoutRoutine>> Get() =>
            await _workoutRoutines.Find(emp => true).ToListAsync();
        

        public async Task<WorkoutRoutine> Get(string id) =>
            await _workoutRoutines.Find(emp => emp.Id == id).FirstOrDefaultAsync();

        public async Task Create(WorkoutRoutine workoutRoutine) =>
            await _workoutRoutines.InsertOneAsync(workoutRoutine);

        public async Task Update(string id, WorkoutRoutine workoutRoutine) =>
            await _workoutRoutines.ReplaceOneAsync(x => x.Id == id, workoutRoutine);

        public async Task Remove(string id) =>
            await _workoutRoutines.DeleteOneAsync(x => x.Id == id);
    }
}