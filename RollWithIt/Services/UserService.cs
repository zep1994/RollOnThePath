using Newtonsoft.Json;
using RollWithIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollWithIt.Services
{
    public class UserService
    {
        private readonly string _url;
        private readonly HttpClient _httpClient;

        public UserService()
        {
            _httpClient = new HttpClient();
            _url = "http://10.0.2.2:5252";

        }

        public async Task<UserInfo> GetUserInfoAsync()
        {
            // Retrieve JWT token from App.JWT
            var jwtToken = App.JWTToken;

            // Set JWT token in request headers
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwtToken);

            try
            {
                // Make authorized GET request to API endpoint
                var response = await _httpClient.GetAsync($"{_url}/api/users/userinfo");

                // Ensure success status code
                response.EnsureSuccessStatusCode();

                // Read response content as string
                var responseBody = await response.Content.ReadAsStringAsync();

                // Deserialize JSON response to UserInfo object
                var userInfo = JsonConvert.DeserializeObject<UserInfo>(responseBody);

                return userInfo;
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
