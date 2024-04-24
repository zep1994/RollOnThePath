using RollWithIt.Views.Auth;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace RollWithIt.ViewModels
{
    public class AppShellViewModel : INotifyPropertyChanged
    {
        private readonly string _url = "http://10.0.2.2:5252";

        private string _logoutButtonText;
        public string LogoutButtonText
        {
            get => _logoutButtonText;
            set
            {
                if (_logoutButtonText != value)
                {
                    _logoutButtonText = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand OnLogoutClickedCommand { get; }

        public AppShellViewModel()
        {
            _logoutButtonText = "Logout";
            OnLogoutClickedCommand = new Command(OnLogoutClicked);
        }

        private async void OnLogoutClicked()
        {
            // Call the logout API endpoint
            var httpClient = new HttpClient();
            var response = await httpClient.PostAsync($"{_url}/api/auth/logout", null);

            if (response.IsSuccessStatusCode)
            {
                // Redirect to the login page
                await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
            }
            else
            {
                // Show an error message if logout fails
                await Application.Current.MainPage.DisplayAlert("Logout", "Failed to logout. Please try again.", "OK");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}