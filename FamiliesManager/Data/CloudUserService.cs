using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FamiliesManager.Models;

namespace FamiliesManager.Data
{
    public class CloudUserService : IUserService
    {
        private const string Uri = "https://localhost:5003";

        private readonly HttpClient _client;

        public CloudUserService()
        {
            _client = new HttpClient();
        }

        public async Task<User> ValidateUserAsync(string username, string password)
        {
            User initUser = new User
            {
                Username = username,
                Password = password
            };
            string userAsJson = JsonSerializer.Serialize(initUser);
            StringContent content = new StringContent(
                userAsJson,
                Encoding.UTF8,
                "application/json"
            );
            
            HttpResponseMessage responseMessage = 
                await _client.PostAsync(Uri + "/users", content);

            if (!responseMessage.IsSuccessStatusCode){
                throw new Exception($"Error: {responseMessage.Content.ReadAsStringAsync().Result}");}

            string result = await responseMessage.Content.ReadAsStringAsync();

            User user = JsonSerializer.Deserialize<User>(result, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return user;
        }
    }
}