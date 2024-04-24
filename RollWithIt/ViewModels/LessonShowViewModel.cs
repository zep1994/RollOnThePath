using MvvmHelpers;
using RollWithIt.Models.Lessons;
using RollWithIt.Services.Lesson;
using System.Collections.ObjectModel;

namespace RollWithIt.ViewModels
{
    public class LessonShowViewModel : BaseViewModel
    {
        private Lesson? _lesson;
        public Lesson? Lesson
        {
            get => _lesson;
            set => SetProperty(ref _lesson, value);
        }

        private readonly LessonService _lessonService = new();

        private ObservableCollection<LessonSection>? _lessonSections;
        public ObservableCollection<LessonSection>? LessonSections
        {
            get => _lessonSections;
            set => SetProperty(ref _lessonSections, value);
        }

        // Property to store the selected lesson
        private LessonSection? _selectedLessonSection;
        public LessonSection? SelectedSubLesson
        {
            get => _selectedLessonSection;
            set => SetProperty(ref _selectedLessonSection, value);
        }

        public LessonShowViewModel()
        {
            LessonSections = new ObservableCollection<LessonSection>();
        }

        public async Task LoadLessonSections(string lessonId)
        {
            var lessonSections = await _lessonService.GetLessonSectionsAsync(lessonId);
            if (LessonSections != null)
            {
                LessonSections.Clear();
            }
            foreach (var lessonSection in lessonSections)
            {
                LessonSections.Add(lessonSection);
            }
        }
    }
}
