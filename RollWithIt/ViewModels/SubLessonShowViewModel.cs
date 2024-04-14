using System.ComponentModel;
using RollWithIt.Models;

namespace RollWithIt.ViewModels
{
    public class SubLessonShowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private SubLesson _subLesson;

        public SubLessonShowViewModel(SubLesson subLesson)
        {
            SubLesson = subLesson;
        }

        public SubLesson SubLesson
        {
            get { return _subLesson; }
            set
            {
                _subLesson = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SubLesson)));
            }
        }
    }
}
