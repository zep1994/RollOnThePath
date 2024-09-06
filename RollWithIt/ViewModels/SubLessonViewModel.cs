using MvvmHelpers;
using RollWithIt.Models.Lessons;
using RollWithIt.Services.Lesson;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace RollWithIt.ViewModels
{
    public class SubLessonViewModel : BaseViewModel
    {
        private SubLesson _subLesson;
        public SubLesson SubLesson
        {
            get => _subLesson;
            set => SetProperty(ref _subLesson, value);
        }

        private readonly LessonService _lessonService = new();

        public SubLessonViewModel()
        {
        }

        // Load SubLesson based on a LessonSection ID
        public async Task LoadSubLessons(int lessonSectionId)
        {
            Console.WriteLine(lessonSectionId); // Debugging log to verify the correct ID
            var subLessons = await _lessonService.GetSubLessonsBySectionId(lessonSectionId);
            if (subLessons != null && subLessons.Count > 0)
            {
                SubLesson = subLessons[0]; // Assuming you want to display the first SubLesson for simplicity
            }
        }
    }
}
