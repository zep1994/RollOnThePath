using Microsoft.Maui.Controls;
using RollWithIt.Models;
using RollWithIt.Views;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RollWithIt.Auth;
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
            Username = UsernameEntry.Text,
            Email = EmailEntry.Text,
            Password = PasswordEntry.Text,
            FirstName = FirstNameEntry.Text,
            LastName = LastNameEntry.Text
        };

        if (string.IsNullOrEmpty(UsernameEntry.Text) || string.IsNullOrEmpty(PasswordEntry.Text))
        {
            await DisplayAlert("Error", "Please enter both username and password.", "OK");
            return;
        }

        try
        {
            var response = await _httpClient.PostAsJsonAsync($"{_url}/api/auth/signup", user);

            if (response.IsSuccessStatusCode)
            {
                // Handle successful sign-in
                // For example, navigate to home page
                await Navigation.PushAsync(new LoginPage());
            }
            else
            {
                // Handle sign-in failure
                await DisplayAlert("Error", "Sign-in failed. Please check your credentials and try again.", "OK");
            }
        }
        catch (Exception ex)
        {
            // Handle sign-in error
            await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
        }
    }
}
