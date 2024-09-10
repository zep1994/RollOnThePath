using MvvmHelpers;
using RollWithIt.Models.Lessons;
using RollWithIt.Services.Lesson;
using System.Collections.ObjectModel;

namespace RollWithIt.ViewModels
{
    public class SubLessonViewModel : BaseViewModel
    {
        private ObservableCollection<SubLesson>? _subLessons;
        public ObservableCollection<SubLesson>? SubLessons
        {
            get => _subLessons;
            set => SetProperty(ref _subLessons, value);
        }

        private readonly LessonService _lessonService = new();

        public SubLessonViewModel()
        {
            SubLessons = [];
        }

        // Load SubLesson based on a LessonSection ID
        public async Task LoadSubLessons(int lessonSectionId)
        {
            var subLessons = await _lessonService.GetSubLessonsBySectionId(lessonSectionId);
            if (subLessons != null)
            {
                SubLessons.Clear();
                foreach (var subLesson in subLessons)
                {
                    SubLessons.Add(subLesson);
                }
            }
        }
    }
}
