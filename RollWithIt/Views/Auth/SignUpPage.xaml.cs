using RollWithIt.Models.Users;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace RollWithIt.Views.Auth
{
    public partial class SignUpPage : ContentPage
    {
        private readonly HttpClient _httpClient;
        private readonly string _url;

        public SignUpPage()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            _url = "http://10.0.2.2:5252";
        }

        private async void OnSignInClicked(object sender, EventArgs e)
        {
            var user = new User
            {
                UserName = UsernameEntry.Text,
                Email = EmailEntry.Text,
                Password = PasswordEntry.Text,
                FirstName = FirstNameEntry.Text,
                LastName = LastNameEntry.Text,
                BeltRank = BeltRankEntry.Text
            };

            if (string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password))
            {
                await DisplayAlert("Error", "Please enter both username and password.", "OK");
                return;
            }

            // Serialize the user object to JSON
            var jsonRequest = JsonSerializer.Serialize(user);

            try
            {
                // Send the request to check if username or email already exists
                var checkResponse = await _httpClient.PostAsync($"{_url}/api/users/signupvalidation", new StringContent(jsonRequest, Encoding.UTF8, "application/json"));

                if (!checkResponse.IsSuccessStatusCode)
                {
                    // Handle sign-in failure
                    await DisplayAlert("Error", "Failed to check username or email availability.", "OK");
                    return;
                }

                // Read the response content as boolean
                var checkResult = await checkResponse.Content.ReadFromJsonAsync<bool>();

                if (checkResult)
                {
                    await DisplayAlert("Error", "Username or email already exists. Please choose a different one.", "OK");
                    return;
                }

                // Proceed with sign-up if username and email are available
                var signUpResponse = await _httpClient.PostAsync($"{_url}/api/auth/signup", new StringContent(jsonRequest, Encoding.UTF8, "application/json"));

                if (signUpResponse.IsSuccessStatusCode)
                {
                    // Handle successful sign-up
                    // For example, navigate to the login page
                    await Navigation.PushAsync(new LoginPage());
                }
                else
                {
                    // Handle sign-up failure
                    await DisplayAlert("Error", "Sign-up failed. Please try again.", "OK");
                }
            }
            catch (Exception ex)
            {
                // Handle sign-up error
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }
    }
}
