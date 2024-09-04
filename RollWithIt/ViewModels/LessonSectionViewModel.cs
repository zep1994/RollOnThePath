using MvvmHelpers;
using RollWithIt.Models.Lessons;
using RollWithIt.Services.Lesson;
using System.Collections.ObjectModel;

namespace RollWithIt.ViewModels
{
    public class LessonSectionViewModel : BaseViewModel
    {
        private ObservableCollection<LessonSection> _lessonSections = new ObservableCollection<LessonSection>();
        public ObservableCollection<LessonSection> LessonSections
        {
            get => _lessonSections;
            set => SetProperty(ref _lessonSections, value);
        }

        private readonly LessonService _lessonService = new();

        private Lesson _lesson;
        public Lesson Lesson
        {
            get => _lesson;
            set => SetProperty(ref _lesson, value);
        }

        private SubLesson? _selectedSubLesson;
        public SubLesson? SelectedSubLesson
        {
            get => _selectedSubLesson;
            set => SetProperty(ref _selectedSubLesson, value);
        }

        public LessonSectionViewModel()
        {
            _lessonSections = new ObservableCollection<LessonSection>();
        }


        public async Task LoadSections(int lessonId)
        {
            var sections = await _lessonService.GetSectionsByLessonId(lessonId);
            LessonSections.Clear();
            foreach (var section in sections)
            {
                LessonSections.Add(section);
            }
        }
    }
}
