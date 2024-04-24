using RollWithIt.Views.Auth;

namespace RollWithIt
{
    public partial class AppShell : Shell
    {
        public bool IsLoggedIn { get; set; } // Bind this property to show/hide the logout button
        private readonly string _url = "http://10.0.2.2:5252";

        public AppShell()
        {
            InitializeComponent();
            BindingContext = this;

            // Set the initial login status
            IsLoggedIn = !string.IsNullOrEmpty(App.JWTToken);
            UpdateLogoutButtonVisibility();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            // Navigate to the login page
            await Navigation.PushAsync(new LoginPage());
        }

        private async void OnSignUpClicked(object sender, EventArgs e)
        {
            // Navigate to the sign-up page
            await Navigation.PushAsync(new SignUpPage());
        }

        private async Task OnLogoutClicked(object? sender, EventArgs e)
        {
            // Call the logout API endpoint
            var httpClient = new HttpClient();
            var response = await httpClient.PostAsync($"{_url}/api/auth/logout", null);

            if (response.IsSuccessStatusCode)
            {
                // Show a success message
                await DisplayAlert("Logout", "Logout successful", "OK");

                // Redirect to the login page
                await Navigation.PushAsync(new LoginPage());
            }
            else
            {
                // Show an error message if logout fails
                await DisplayAlert("Logout", "Failed to logout. Please try again.", "OK");
            }
        }

        private void UpdateLogoutButtonVisibility()
        {
            // Check if the user is logged in
            if (!string.IsNullOrEmpty(App.JWTToken))
            {
                // If logged in, show the logout button
                ToolbarItems.Add(new ToolbarItem
                {
                    Text = "Logout",
                    Command = new Command(async () => await OnLogoutClicked(null, EventArgs.Empty))
                });
            }
        }
    }
}