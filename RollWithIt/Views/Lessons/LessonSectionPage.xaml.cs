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
        _viewModel.LoadSections(lesson.Id); // Ensuring the ViewModel loads the appropriate sections
    }

    private async void OnSectionClicked(object sender, EventArgs e)
    {
        if (sender is Button { BindingContext: LessonSection section })
        {
            Console.WriteLine("Section button clicked. Navigating to SubLessonDetailPage...");

            // Navigate to SubLessonDetailPage with the selected section ID
            _viewModel.SelectedSection = section;
            await Navigation.PushAsync(new SubLessonDetailPage(section));
        }
        else
        {
            Console.WriteLine("Section button click event handler triggered, but section object is null or not correctly bound.");
        }
    }
}
