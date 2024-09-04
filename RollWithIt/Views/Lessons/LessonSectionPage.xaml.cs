using RollWithIt.Models.Lessons;
using RollWithIt.ViewModels;

namespace RollWithIt.Views.Lessons;

public partial class LessonSectionPage : ContentPage
{
    private LessonSectionViewModel _viewModel;

    public LessonSectionPage(Lesson lesson)
    {
        InitializeComponent();
        _viewModel = new LessonSectionViewModel();
        BindingContext = _viewModel;
        _viewModel.Lesson = lesson;
        _ = _viewModel.LoadSections(lesson.Id);
    }

    private async void OnSectionClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is SubLesson sublesson)
        {
            Console.WriteLine("Lesson button clicked. Navigating to LessonShowPage...");

            // Set the selected lesson before navigating
            _viewModel.SelectedSubLesson = sublesson;
            await Navigation.PushAsync(new SubLessonDetailPage(sublesson));
        }
        else
        {
            Console.WriteLine("Lesson button click event handler triggered, but lesson object is null or not correctly bound.");
        }
    }
}
