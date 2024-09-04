using RollWithIt.Models.Lessons;
using RollWithIt.ViewModels;

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
