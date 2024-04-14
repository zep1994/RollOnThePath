using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RollWithIt.ViewModels
{
    public class LessonViewModel
    {
        public string? LessonTitle { get; set; }
        public string? LessonId { get; set; }

        public ICommand ViewSectionsCommand { get; }

        public LessonViewModel()
        {
            ViewSectionsCommand = new Command(async () => await ViewSectionsAsync());
        }

        private async Task ViewSectionsAsync()
        {
            // Navigate to the Sections page passing the LessonTitle and LessonId
            await Shell.Current.GoToAsync($"//sections?lessonTitle={Uri.EscapeDataString(LessonTitle)}&lessonId={Uri.EscapeDataString(LessonId)}");
        }
    }
}
