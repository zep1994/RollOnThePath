using RollWithIt.Models.Lessons;
using RollWithIt.ViewModels;

namespace RollWithIt.Views.Lessons;

public partial class LessonsPage : ContentPage
{
    private readonly LessonsViewModel _viewModel;

    public LessonsPage()
    {
        InitializeComponent();
        _viewModel = new LessonsViewModel();
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.LoadLessonsAsync();
    }

    private async void OnLessonClicked(object sender, EventArgs e)
    {
        if (sender is Button { BindingContext: Lesson lesson })
        {
            Console.WriteLine("Lesson button clicked. Navigating to LessonShowPage...");

            // Set the selected lesson before navigating
            _viewModel.SelectedLesson = lesson;
            await Navigation.PushAsync(new LessonSectionPage(lesson));
        }
        else
        {
            Console.WriteLine("Lesson button click event handler triggered, but lesson object is null or not correctly bound.");
        }
    }
}