using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using RollWithIt.Models;
using RollWithIt.Services;

namespace RollWithIt.Views.Users;

public partial class UserProfile : ContentPage
{
    private readonly string _url;
    private readonly HttpClient _httpClient;
    private UserInfo _userInfo;

    public UserProfile()
    {
        InitializeComponent();
        _url = "http://10.0.2.2:5252";
        _httpClient = new HttpClient();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        try
        {
            // Get JWT token from App.JWTToken
            var jwtToken = App.JWTToken;

            // Add JWT token to the Authorization header
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

            var response = await _httpClient.GetAsync($"{_url}/api/users/UserProfile");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();

                // Log JSON response for debugging
                Console.WriteLine("JSON Response:");
                Console.WriteLine(jsonString);

                try
                {
                    // Deserialize JSON response into UserInfo object
                    _userInfo = JsonSerializer.Deserialize<UserInfo>(jsonString);

                    // Check if deserialization was successful
                    if (_userInfo != null)
                    {
                        usernameLabel.Text = _userInfo.Username;
                        emailLabel.Text = _userInfo.Email;
                        firstNameLabel.Text = _userInfo.FirstName;
                        lastNameLabel.Text = _userInfo.LastName;
                    }
                    else
                    {
                        ErrorMessageLabel.Text = "Failed to deserialize user profile data.";
                    }
                }
                catch (Exception ex)
                {
                    ErrorMessageLabel.Text = "Deserialization error: " + ex.Message;
                }
            }
            else
            {
                // Handle error response
                ErrorMessageLabel.Text = "Failed to fetch user profile: " + response.ReasonPhrase;
            }
        }
        catch (Exception ex)
        {
            // Handle exception
            ErrorMessageLabel.Text = "An error occurred: " + ex.Message;
        }
    }
}