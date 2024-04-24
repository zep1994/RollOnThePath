using RollWithIt.Views.Auth;

namespace RollWithIt
{
    public partial class App : Application
    {
        public static string? JWTToken { get; set; }

        public App()
        {
            InitializeComponent();

            // Check if the user is logged in based on the presence of a JWT token
            if (string.IsNullOrEmpty(JWTToken))
            {
                // User is not logged in, show the LoginPage
                MainPage = new LoginPage();
            }
            else
            {
                // User is logged in, show the MainPage
                MainPage = new AppShell();
            }
        }

        public static void LoginSuccess()
        {
            // Update MainPage to the home page (MainPage in AppShell)
            Current.MainPage = new AppShell();
        }
    }
}
