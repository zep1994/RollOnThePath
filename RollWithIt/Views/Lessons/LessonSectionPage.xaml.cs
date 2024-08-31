using RollWithIt.Models.Lessons;
using RollWithIt.ViewModels;

namespace RollWithIt.Views.Lessons;

public partial class LessonSectionPage : ContentPage
{
    private LessonSectionViewModel _viewModel;

    public LessonSectionPage(LessonSection lessonSection)
    {
        InitializeComponent();

        // Create an instance of the view model
        _viewModel = new LessonSectionViewModel
        {
            // Set the LessonSection property
            LessonSection = lessonSection
        };

        // Set the BindingContext
        BindingContext = _viewModel;

        // Load sublessons
        LoadSubLessonsAsync(lessonSection.Id);
    }

    private async void LoadSubLessonsAsync(int lessonSectionId)
    {
        // Call LoadSubLessons on the ViewModel
        await _viewModel.LoadSubLessons(lessonSectionId);
    }

    private async void OnLessonSectionClicked(object sender, EventArgs e)
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
