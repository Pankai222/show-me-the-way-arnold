using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MatBlazor;
using Show_Me_The_Way_Arnold.Models;

namespace Show_Me_The_Way_Arnold.Services
{
    public class CreatorService
    {
        private readonly HttpClient _httpClient;
        
        public CreatorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<List<Creator>> GetCreators()
        {
            const string creatorCall = "https://localhost:5001/api/Creator";

            return await _httpClient.GetJsonAsync<List<Creator>>(creatorCall);
        }
    }
}