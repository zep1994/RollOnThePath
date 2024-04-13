using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using RollWithIt.Models;
using RollWithIt.Views.Lessons;

namespace RollWithIt.ViewModels
{
    public class LessonViewModel : INotifyPropertyChanged
    {
        // Command to show section details
        public ICommand ShowSectionCommand { get; }

        private List<Lesson>? _lessons;
        public List<Lesson>? Lessons
        {
            get => _lessons;
            set
            {
                _lessons = value;
                OnPropertyChanged();
            }
        }

        // Add Title property
        private string? _title;
        public string? Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        private string? _description;
        public string? Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        private string? _beltrecommendation;
        public string? BeltRecommendation
        {
            get => _beltrecommendation;
            set
            {
                _beltrecommendation = value;
                OnPropertyChanged();
            }
        }

        private string? _content;
        public string? Content
        {
            get => _content;
            set
            {
                _content = value;
                OnPropertyChanged();
            }
        }

        // Add Sections property
        private List<LessonSection>? _sections;
        public List<LessonSection>? Sections
        {
            get => _sections;
            set
            {
                _sections = value;
                OnPropertyChanged();
            }
        }

        private ICommand? _sectionCommand;

        public ICommand? SectionCommand
        {
            get => _sectionCommand;
            set
            {
                _sectionCommand = value;
                OnPropertyChanged();
            }
        }

        public LessonViewModel()
        {
            SectionCommand = new Command<LessonSection>(ExecuteSectionCommand);

            // Initialize your lessons data here
            Lessons =
            [
                new() {
                    Title = "Lesson Title 1",
                    Description = "Lesson Description 1",
                    BeltRecommendation = "Belt Recommendation 1",
                    Sections = new List<LessonSection>
                    {
                        new() {
                            LessonId = 1, // Set LessonId here
                            Title = "Section 1",
                            Description = "Section 1 Description",
                            SubLessons = new List<SubLesson>
                            {
                                new() {
                                    Title = "Sub-Lesson 1",
                                    Description = "Sub-Lesson 1 Description",
                                    Content = "Sub-Lesson 1 Content"
                                },
                                new() {
                                    Title = "Sub-Lesson 2",
                                    Description = "Sub-Lesson 2 Description",
                                    Content = "Sub-Lesson 2 Content"
                                }
                            }
                        }
                    }
                },
                new() {
                    Title = "Lesson Title 2",
                    Description = "Lesson Description 2",
                    BeltRecommendation = "Belt Recommendation 2",
                    Sections = new List<LessonSection>
                    {
                        new() {
                            LessonId = 2, // Set LessonId here
                            Title = "Section 1",
                            Description = "Section 1 Description",
                            SubLessons = new List<SubLesson>
                            {
                                new() {
                                    Title = "Sub-Lesson 1",
                                    Description = "Sub-Lesson 1 Description",
                                    Content = "Sub-Lesson 1 Content"
                                },
                                new() {
                                    Title = "Sub-Lesson 2",
                                    Description = "Sub-Lesson 2 Description",
                                    Content = "Sub-Lesson 2 Content"
                                }
                            }
                        },
                        new() {
                            LessonId = 2, // Set LessonId here
                            Title = "Section 2",
                            Description = "Section 2 Description",
                            SubLessons =
                            [
                                new SubLesson
                                {
                                    Title = "Sub-Lesson 3",
                                    Description = "Sub-Lesson 3 Description",
                                    Content = "Sub-Lesson 3 Content"
                                },
                                new SubLesson
                                {
                                    Title = "Sub-Lesson 4",
                                    Description = "Sub-Lesson 4 Description",
                                    Content = "Sub-Lesson 4 Content"
                                }
                            ]
                        }
                    }
                }
            ];
        }

        // Add SubLessons property
        private List<SubLesson> _subLesson;
        public List<SubLesson> SubLesson
        {
            get => _subLesson;
            set
            {
                _subLesson = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void ExecuteSectionCommand(LessonSection section)
        {
            if (section.SubLessons != null && section.SubLessons.Count > 0)
            {
                // Pass the first sub-lesson to the ShowSubLesson page
                await Application.Current.MainPage.Navigation.PushAsync(new ShowSubLesson(section.SubLessons[0]));
            }
            else
            {
                // Handle the case where there are no sub-lessons
                await Application.Current.MainPage.DisplayAlert("No Sub-Lessons", "There are no sub-lessons available for this section.", "OK");
            }
        }
    }
}
