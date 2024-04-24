using RollWithIt.Views.Lessons;
using RollWithIt.Views.Users;

namespace RollWithIt.Views;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
    }

    private async void UserProfile_Clicked(object sender, EventArgs e)
    {
        // Navigate to User Profile page
        await Navigation.PushAsync(new UserProfile());
    }

    private async void Lessons_Clicked(object sender, EventArgs e)
    {
        // Navigate to Lessons page
        await Navigation.PushAsync(new LessonsPage());
    }

    private async void Progression_Clicked(object sender, EventArgs e)
    {
        // Navigate to Progression page
        await Navigation.PushAsync(new ProgressionPage());
    }

    private async void Logout_Clicked(object sender, EventArgs e)
    {
        // Perform logout actions
        // For example, clear authentication token, navigate to login page, etc.
        // For demonstration, let's navigate back to the login page
        await Navigation.PopToRootAsync(); // Navigate back to the root (login) page
    }
}
