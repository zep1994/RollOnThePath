using MvvmHelpers;
using RollWithIt.Models.Lessons;
using RollWithIt.Services.Lesson;
using System.Collections.ObjectModel;

namespace RollWithIt.ViewModels
{
    public class LessonSectionViewModel : BaseViewModel
    {
        private LessonSection? _lessonSection;
        public LessonSection? LessonSection
        {
            get => _lessonSection;
            set => SetProperty(ref _lessonSection, value);
        }

        private readonly LessonService _lessonService = new();

        private ObservableCollection<SubLesson>? _subLessons;
        public ObservableCollection<SubLesson>? SubLessons
        {
            get => _subLessons;
            set => SetProperty(ref _subLessons, value);
        }

        // Property to store the selected lesson
        private SubLesson? _selectedSubLesson;
        public SubLesson? SelectedSubLesson
        {
            get => _selectedSubLesson;
            set => SetProperty(ref _selectedSubLesson, value);
        }

        public LessonSectionViewModel()
        {
            SubLessons = new ObservableCollection<SubLesson>();
        }

        public async Task LoadSubLessons(string lessonSectionId)
        {
            var subLessons = await _lessonService.GetSubLessonsAsync(lessonSectionId);
            if (SubLessons != null)
            {
                SubLessons.Clear();
            }
            foreach (var subLesson in subLessons)
            {
                SubLessons.Add(subLesson);
            }
        }
    }
}
