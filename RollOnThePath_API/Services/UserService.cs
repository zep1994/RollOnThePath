using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RollOnThePath_API.Models;

namespace RollOnThePath_API.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly string _url;

        public UserService()
        {
            _httpClient = new HttpClient();
            _url = "http://10.0.2.2:5252";
        }

        public async Task<UserInfo> GetUserInfoAsync(string userId)
        {
            // Set up your API endpoint URL
            var apiUrl = $"{_url}/api/users/{userId}";

            try
            {
                // Make authorized GET request to API endpoint
                var response = await _httpClient.GetAsync(apiUrl);

                // Ensure success status code
                response.EnsureSuccessStatusCode();

                // Read response content as string
                var responseBody = await response.Content.ReadAsStringAsync();

                // Deserialize JSON response to UserInfo object
                var userInfo = JsonConvert.DeserializeObject<UserInfo>(responseBody);
                if (userInfo != null)
                {
                    return userInfo;
                } else
                {
                    return null;
                }

            }
            catch (HttpRequestException ex)
            {
                // Handle HTTP request exception
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
    }
}