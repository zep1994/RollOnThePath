using RollWithIt.Models.Lessons;
using RollWithIt.ViewModels;
using Microsoft.Maui.Controls;

namespace RollWithIt.Views.Lessons
{
    public partial class SubLessonDetailPage : ContentPage
    {
        public SubLessonDetailPage(SubLesson subLesson)
        {
            InitializeComponent();
            BindingContext = new SubLessonViewModel(subLesson);
        }
    }
}
