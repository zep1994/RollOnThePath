using RollWithIt.Auth;

namespace RollWithIt.Components;

public partial class SlidingSidebarMenu : ContentView
{
    public SlidingSidebarMenu()
    {
        InitializeComponent();
    }

    private async void OnSignUpClicked(object sender, EventArgs e)
    {
        // Navigate to the sign-in page
        await Navigation.PushAsync(new SignUpPage());
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        // Navigate to the login page
        await Navigation.PushAsync(new LoginPage());
    }
}
