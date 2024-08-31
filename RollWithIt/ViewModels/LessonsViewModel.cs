using MvvmHelpers;
using RollWithIt.Models.Lessons;
using RollWithIt.Services.Lesson;
using System.Collections.ObjectModel;

namespace RollWithIt.ViewModels
{
    public class LessonsViewModel : BaseViewModel
    {
        private readonly LessonService _lessonService = new();

        private ObservableCollection<Lesson>? _lessons;
        public ObservableCollection<Lesson>? Lessons
        {
            get => _lessons;
            set => SetProperty(ref _lessons, value);
        }

        // Property to store the selected lesson
        private Lesson? _selectedLesson;
        public Lesson? SelectedLesson
        {
            get => _selectedLesson;
            set => SetProperty(ref _selectedLesson, value);
        }

        public LessonsViewModel()
        {
            Lessons = new ObservableCollection<Lesson>();
        }

        public async Task LoadLessonsAsync()
        {
                                                                                                                                                                                                                                                            var lessons = await _lessonService.GetAllLessons();
            if (Lessons != null)
            {
                Lessons.Clear();
            }
            foreach (var lesson in lessons)
            {
                Lessons.Add(lesson);
            }
        }
    }
}