using Microsoft.Maui.Controls;
using RollWithIt.ViewModels;

namespace RollWithIt.Views.Lessons
{
    public partial class SectionShowPage : ContentPage
    {  
        public SectionShowPage(int lessonSectionId, string lessonTitle, int lessonId)
        {
            InitializeComponent();
            BindingContext = new SectionShowViewModel(lessonSectionId, lessonTitle, lessonId);
        }
    }
}
