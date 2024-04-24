using RollWithIt.Models.Lessons;
using RollWithIt.ViewModels;

namespace RollWithIt.Views.Lessons
{
    public partial class LessonsSectionPage : ContentPage
    {
        //private readonly LessonsSectionViewModel _viewModel = new LessonsSectionViewModel();
        //private readonly string _lessonId = "";

        //public LessonsSectionPage(Lesson lesson)
        //{
        //    InitializeComponent();
        //    BindingContext = _viewModel;

        //    // Extract lessonId from the lesson object
        //    _lessonId = lesson.Id.ToString();            
        //}
        //protected override async void OnAppearing()
        //{
        //    base.OnAppearing();
        //    if (BindingContext is LessonsSectionViewModel viewModel)
        //    {
        //        await viewModel.LoadLessonSections(_lessonId);
        //    }
        //}

        //private async void OnLessonSectionClicked(object sender, EventArgs e)
        //{
        //    if (sender is Button { BindingContext: LessonSection lessonSection })
        //    {
        //        Console.WriteLine("Lesson button clicked. Navigating to LessonShowPage...");

        //        // Set the selected lesson before navigating
        //        _viewModel.SelectedSubLesson = lessonSection;
        //        await Navigation.PushAsync(new SubLessonsPage(lessonSection));
        //    }
        //    else
        //    {
        //        Console.WriteLine("Lesson button click event handler triggered, but lesson object is null or not correctly bound.");
        //    }
        //}
    }
}
