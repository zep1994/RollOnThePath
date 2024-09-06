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
}
