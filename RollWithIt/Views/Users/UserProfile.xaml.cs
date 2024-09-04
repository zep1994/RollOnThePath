using System.Net.Http.Headers;
using System.Text.Json;
using RollWithIt.Models.Users;

namespace RollWithIt.Views.Users;

public partial class UserProfile : ContentPage
{
    private readonly string _url = "http://10.0.2.2:5252";
    private readonly HttpClient _httpClient = new();
    private UserInfo _userInfo = new();

    public UserProfile()
    {
        InitializeComponent(); 
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
                    if (jsonString != null)
                    {
                        // Deserialize JSON response into UserInfo object
                        _userInfo = JsonSerializer.Deserialize<UserInfo>(jsonString);

                        // Check if deserialization was successful
                        if (_userInfo != null)
                        {
                            // Bind _userInfo to UI elements
                            usernameLabel.Text = _userInfo.UserName;
                            emailLabel.Text = _userInfo.Email;
                            firstNameLabel.Text = _userInfo.FirstName;
                            lastNameLabel.Text = _userInfo.LastName;
                            beltRankLabel.Text = _userInfo.BeltRank;
                            // Bind other properties as needed
                        }
                        else
                        {
                            ErrorMessageLabel.Text = "Failed to deserialize user profile data.";
                        }
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