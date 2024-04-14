
using RollWithIt.Models;
using Microsoft.Maui.Controls;


namespace RollWithIt.Views.Lessons
{
    public partial class LessonsPage : ContentPage
    {
        public LessonsPage()
        {
            InitializeComponent();
        }

        private async Task LoadLessons()
        {
            try
            {
                HttpClient client = new HttpClient();

                // Assuming you have a method to retrieve the JWT token from your app
                string token = GetJwtToken();

                // Add JWT token to the request headers
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await client.GetAsync("http://localhost:5000/api/lessons");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    List<Lesson>? Lessons = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Lesson>>(content);
                    BindingContext = this;
                }
                else
                {
                    // Handle error
                }
            }
            catch (HttpRequestException)
            {
                // Handle network error
            }
        }

        private string GetJwtToken()
        {
            throw new NotImplementedException();
        }
    }
}
