using MvvmHelpers;
using RollWithIt.Models.Lessons;

namespace RollWithIt.ViewModels
{
    public class SubLessonShowViewModel : BaseViewModel
    {
        private SubLesson _subLesson;
        public SubLesson SubLesson
        {
            get => _subLesson;
            set => SetProperty(ref _subLesson, value);
        }

        public SubLessonShowViewModel(SubLesson subLesson) => SubLesson = subLesson; 
    }
}
