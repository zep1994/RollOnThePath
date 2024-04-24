using MvvmHelpers;
using RollWithIt.Models.Lessons;
using RollWithIt.Services.Lesson;
using System.Collections.ObjectModel;

namespace RollWithIt.ViewModels
{
    public class LessonShowViewModel : BaseViewModel
    {
        private readonly LessonService _lessonService = new();

        private ObservableCollection<LessonSection>? _lessonSections;
        public ObservableCollection<LessonSection>? LessonSections
        {
            get => _lessonSections;
            set => SetProperty(ref _lessonSections, value);
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
