using System.ComponentModel;
using RollWithIt.Models;

namespace RollWithIt.ViewModels
{
    public class SubLessonViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private SubLesson _subLesson;

        public SubLesson SubLesson
        {
            get { return _subLesson; }
            set
            {
                _subLesson = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SubLesson)));
            }
        }

        // Constructor
        public SubLessonViewModel()
        {
        }
    }
}
