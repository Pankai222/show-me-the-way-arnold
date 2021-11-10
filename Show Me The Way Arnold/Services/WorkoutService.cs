using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MatBlazor;
using Show_Me_The_Way_Arnold.Models;

namespace Show_Me_The_Way_Arnold.Services
{
    public class WorkoutService
    {
        private readonly HttpClient _httpClient;
        
        public WorkoutService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<List<WorkoutRoutine>> GetWorkoutRoutines()
        {
            var getRoutinesCall = "https://localhost:5001/api/Workout";

            return await _httpClient.GetJsonAsync<List<WorkoutRoutine>>(getRoutinesCall);
        }

        public async Task AddWorkoutRoutine(WorkoutRoutine payload)
        {
            var postRoutineCall = "https://localhost:5001/api/Workout";
            var response = await _httpClient.PostAsJsonAsync(postRoutineCall, payload);
            if (!response.IsSuccessStatusCode)
            {
               Console.WriteLine($"There was an error {response.ReasonPhrase}");
            }
        }
    }
}