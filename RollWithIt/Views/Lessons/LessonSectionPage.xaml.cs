using RollWithIt.Models.Lessons;
using RollWithIt.ViewModels;

namespace RollWithIt.Views.Lessons;

public partial class LessonSectionPage : ContentPage
{
    public LessonSectionPage(LessonSection lessonSection)
    {
        InitializeComponent();

        // Create an instance of the view model
        var viewModel = new LessonSectionViewModel
        {
            // Set the LessonSection property
            LessonSection = lessonSection
        };

        // Set the BindingContext
        BindingContext = viewModel;

        // Load sublessons
        _ = LoadSubLessonsAsync(lessonSection.Id.ToString());
    }

    private async Task LoadSubLessonsAsync(string lessonSectionId)
    {
        // Retrieve the view model from the BindingContext
        if (BindingContext is LessonSectionViewModel viewModel)
        {
            // Load sublessons asynchronously
            await viewModel.LoadSubLessons(lessonSectionId);
        }
    }
}