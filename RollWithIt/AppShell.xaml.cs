using RollWithIt.Views.Auth;

namespace RollWithIt
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            BindingContext = this;
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
    }
}
