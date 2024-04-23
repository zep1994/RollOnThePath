namespace RollWithIt
{
    public partial class App : Application
    {
        public static string? JWTToken { get; set; }

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
