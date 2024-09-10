using RollWithIt.Models.Lessons;
using RollWithIt.ViewModels;

namespace RollWithIt.Views.Lessons;

public partial class SubLessonDetailPage : ContentPage
{
    private SubLessonViewModel _viewModel;

    public SubLessonDetailPage(LessonSection section)
    {
        InitializeComponent();
        _viewModel = new SubLessonViewModel();
        BindingContext = _viewModel;
        _viewModel.LoadSubLessons(section.Id); // Load sublessons related to the section ID
    }
    private async void OnSubLessonClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is SubLesson subLesson)
        {
            Console.WriteLine("Section button clicked. Navigating to SubLessonDetailPage...");

            // Navigate to SubLessonDetailPage with the selected section ID
            await Navigation.PushAsync(new SubLessonShowPage(subLesson));
        }
    }

}
