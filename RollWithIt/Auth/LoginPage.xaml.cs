using RollWithIt.Views;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RollWithIt.Auth;

public partial class LoginPage : ContentPage
{
    private readonly HttpClient _httpClient;
    private readonly string _url;

    public LoginPage()
    {
        InitializeComponent();
        _httpClient = new HttpClient();
        _url = "http://10.0.2.2:5252";
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string username = UsernameEntry.Text;
        string password = PasswordEntry.Text;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            await DisplayAlert("Error", "Please enter both username and password.", "OK");
            return;
        }

        var loginRequest = new
        {
            Username = username,
            Password = password
        };

        string jsonRequest = JsonSerializer.Serialize(loginRequest);
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

        try
        {
            var response = await _httpClient.PostAsync($"{_url}/api/auth/login", content);

            if (response.IsSuccessStatusCode)
            {
                // Login successful
                string jsonResponse = await response.Content.ReadAsStringAsync();
                var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(jsonResponse);

                if (tokenResponse != null)
                {
                    // Handle the JWT token (e.g., save it to secure storage, set it as a property in App class, etc.)
                    App.JWTToken = tokenResponse.token;

                    // Navigate to the next page (e.g., homepage)
                    await Navigation.PushAsync(new HomePage());
                }
            }
            else
            {
                // Login failed
                await DisplayAlert("Error", "Login failed. Please check your credentials and try again.", "OK");
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., network errors)
            await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
        }
    }

    // Define a class to represent the token response from the API
    public class TokenResponse
    {
        public string? token { get; set; }
    }
}
