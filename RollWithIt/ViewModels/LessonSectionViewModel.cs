using MvvmHelpers;
using RollWithIt.Models.Lessons;
using RollWithIt.Services.Lesson;
using System.Collections.ObjectModel;

namespace RollWithIt.ViewModels
{
    public class LessonSectionViewModel : BaseViewModel
    {
        private ObservableCollection<LessonSection> _lessonSections = [];
        public ObservableCollection<LessonSection> LessonSections
        {
            get => _lessonSections;
            set => SetProperty(ref _lessonSections, value);
        }

        private readonly LessonService _lessonService = new();

        private LessonSection? _selectedSection;
        public LessonSection? SelectedSection
        {
            get => _selectedSection;
            set => SetProperty(ref _selectedSection, value);
        }

        public LessonSectionViewModel()
        {
            LessonSections = [];
        }


        public async Task LoadSections(int lessonId)
        {
            var sections = await _lessonService.GetSectionsByLessonId(lessonId);
            LessonSections.Clear();
            foreach (var section in sections)
            {
                Console.WriteLine($"Loading Section: {section.Title}, ID: {section.Id}"); // Debugging log to verify the correct ID
                LessonSections.Add(section);
            }
        }
    }
}
