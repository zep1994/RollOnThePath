using RollWithIt.ViewModels;
using RollWithIt.Models;


namespace RollWithIt.Views.Lessons
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LessonsPage : ContentPage
    {
        public LessonsPage()
        {
            InitializeComponent();
            BindingContext = new LessonViewModel();
        }

        // Handle the click event of the section button
        private async void OnSectionButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            LessonSection section = (LessonSection)button.BindingContext;
            await Navigation.PushAsync(new SectionShowPage(section));
        }
    }
}
