using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MatBlazor;
using Show_Me_The_Way_Arnold.Models;

namespace Show_Me_The_Way_Arnold.Services
{
    public class ExerciseService
    {
        private readonly HttpClient _httpClient;

        public ExerciseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Exercise>> GetExercises()
        {
            const string exerciseCall = "https://localhost:5001/api/Exercise";

            return await _httpClient.GetJsonAsync<List<Exercise>>(exerciseCall);
        }
    }
}