using RollWithIt.Models.Lessons;
using RollWithIt.ViewModels;

namespace RollWithIt.Views.Lessons;

public partial class SubLessonShowPage : ContentPage
{
    public SubLessonShowPage(SubLesson subLesson)
    {
        InitializeComponent();
        Console.WriteLine($"SubLesson Title: {subLesson.Title}, Description: {subLesson.Description}");
        BindingContext = new SubLessonShowViewModel(subLesson);
    }
}
