﻿using RollWithIt.Views.Auth;

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

        private async void OnLessonsButtonClicked(object sender, EventArgs e)
        {
            // Navigate to the LessonsPage
            await Navigation.PushAsync(new Lessons.LessonsPage());
        }

        private async void OnSignUpClicked(object sender, EventArgs e)
        {
            // Navigate to the sign-up page
            await Navigation.PushAsync(new SignUpPage());
        }

        private async void OnLearnNewTechniquesClicked(object sender, EventArgs e)
        {
            // Navigate to the LessonsPage
            await Navigation.PushAsync(new Lessons.LessonsPage());
        }
    }

}
