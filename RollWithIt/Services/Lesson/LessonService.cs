using RollWithIt.Models.Lessons;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

namespace RollWithIt.Services.Lesson
{
    public class LessonService : ILessonService
    {
        private readonly string _baseUrl = "http://10.0.2.2:5252";
        private readonly HttpClient _httpClient = new();

        public async Task<List<Models.Lessons.Lesson>?> GetUserLessonsAsync()
        {
            try
            {
                var jwtToken = App.JWTToken;
                if (jwtToken == null) { throw new ArgumentNullException(nameof(jwtToken)); }
                var userId = GetUserIdFromToken(jwtToken);
                // Ensure JWT token is provided
                if (string.IsNullOrEmpty(jwtToken))
                {
                    throw new ArgumentNullException(nameof(jwtToken), "JWT token cannot be null or empty");
                }

                // Set JWT token in the request header
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

                // Make GET request to retrieve user's lessons
                HttpResponseMessage response = await _httpClient.GetAsync($"{_baseUrl}/api/users/{userId}/lessons");
                response.EnsureSuccessStatusCode(); // Throw exception for non-success status codes

                // Deserialize response content to list of lessons
                string content = await response.Content.ReadAsStringAsync();
                List<Models.Lessons.Lesson>? lessons = JsonSerializer.Deserialize<List<Models.Lessons.Lesson>?>(content);

                if (lessons ==  null || lessons.Count == 0) { return null; }
                return lessons;
            }
            catch (Exception ex)
            {
                // Log or handle exception
                Console.WriteLine($"Error in GetUserLessonsAsync: {ex.Message}");
                throw; // Propagate exception to caller
            }
        }

        public async Task<List<LessonSection>?> GetLessonSectionsAsync(string lessonId)
        {
            var jwtToken = App.JWTToken;
            if (jwtToken == null) { throw new ArgumentNullException(nameof(jwtToken)); }
            // Ensure JWT token is provided
            if (string.IsNullOrEmpty(jwtToken))
            {
                throw new ArgumentNullException(nameof(jwtToken), "JWT token cannot be null or empty");
            }

            // Set JWT token in the request header
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

            var response = await _httpClient.GetAsync($"{_baseUrl}/api/lessons/{lessonId}/sections");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<LessonSection>>(content);
            }
            else
            {
                // Handle unsuccessful response
                return [];
            }
        }

        private static string? GetUserIdFromToken(string jwtToken)
        {
            try
            {
                // Decode the JWT token
                var handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(jwtToken);

                // Extract the user ID claim
                var userIdClaim = token.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier);
                if (userIdClaim != null)
                {
                    return userIdClaim.Value;
                }
                else
                {
                    // Throw an exception or return null if user ID claim is not found
                    throw new Exception("User ID claim not found in token");
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine($"Error extracting user ID from token: {ex.Message}");
                return null;
            }
        }
    }
}


//public async Task<List<Models.Lessons.Lesson>?> GetUserLessonsWithSectionsAsync()
//{
//    try
//    {
//        var jwtToken = App.JWTToken;
//        if (jwtToken == null) { throw new ArgumentNullException(nameof(jwtToken)); }
//        var userId = GetUserIdFromToken(jwtToken);
//        if (!string.IsNullOrEmpty(userId))
//        {
//            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

//            // Make a GET request to fetch the user's lessons with sections
//            var response = await _httpClient.GetAsync($"{_baseUrl}/api/users/{userId}/lessons");
//            response.EnsureSuccessStatusCode();

//            var content = await response.Content.ReadAsStringAsync();
//            var options = new JsonSerializerOptions
//            {
//                PropertyNameCaseInsensitive = true
//            };

//            // Deserialize the JSON response into a list of lessons or a single lesson
//            var lesson = JsonSerializer.Deserialize<Models.Lessons.Lesson>(content, options);
//            if (lesson != null)
//            {
//                return [lesson];
//            }
//            else
//            {
//                var lessonList = JsonSerializer.Deserialize<List<Models.Lessons.Lesson>>(content, options);
//                return lessonList ?? [];
//            }
//        }
//    }
//    catch (Exception ex)
//    {
//        // Handle exception appropriately
//        Console.WriteLine($"Error: {ex.Message}");
//        return new List<Models.Lessons.Lesson>(); // or throw the exception if necessary
//    }
//    return null;
//}