using MvvmHelpers;
using RollWithIt.Models.Lessons;

namespace RollWithIt.ViewModels
{
    public class SubLessonViewModel : BaseViewModel
    {
        private SubLesson _subLesson;
        public SubLesson SubLesson
        {
            get => _subLesson;
            set
            {
                if (SetProperty(ref _subLesson, value))
                {
                    OnPropertyChanged(nameof(SubLesson));
                }
            }
        }

        public SubLessonViewModel(SubLesson subLesson)
        {
            SubLesson = subLesson;
            LoadAdditionalData();
        }

        private async Task LoadAdditionalData()
        {
            // Example: Load additional data related to the SubLesson if needed
            // This could involve making a service call or processing data
            // For demonstration, let's assume this is where you might refresh or process
        }
    }
}
