using RollWithIt.ViewModels;
using RollWithIt.Models.Lessons;
using RollWithIt.Services.Lesson;


namespace RollWithIt.Views.Lessons
{
    public partial class LessonShowPage : ContentPage
    {
        private readonly LessonShowViewModel _viewModel;
        private readonly string _lessonId = "";

        public LessonShowPage(Lesson lesson)
        {
            InitializeComponent();
            _viewModel = new LessonShowViewModel(); // Pass LessonService instance to the ViewModel
            BindingContext = _viewModel;

            // Extract lessonId from the lesson object
            _lessonId = lesson.Id.ToString();

            
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext is LessonShowViewModel viewModel)
            {
                await viewModel.LoadLessonSections(_lessonId);
            }
        }

        private async void OnViewSublessonsClicked(object sender, EventArgs e)
        {
            // Navigate to LessonSectionPage and pass the selected lesson section
            await Navigation.PushAsync(new LessonSectionPage(_viewModel.SelectedSubLesson));
        }
    }
}
