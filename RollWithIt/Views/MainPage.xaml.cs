using RollWithIt.Views.Auth;
using RollWithIt.Views.Lessons;
using RollWithIt.Views.Users;

namespace RollWithIt.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
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

        private async void OnLearnNewTechniquesClicked(object sender, EventArgs e)
        {
            // Navigate to the page where users can learn new techniques
            await Navigation.PushAsync(new LessonsPage());
        }

        private async void OnTrackedLessonsClicked(object sender, EventArgs e)
        {
            // Navigate to the page where users can see their tracked lessons
            await Navigation.PushAsync(new TrackedLessonsPage());
        }

        private async void OnUserProfileClicked(object sender, EventArgs e)
        {
            // Navigate to the user profile page
            await Navigation.PushAsync(new UserProfile());
        }
    }

}
