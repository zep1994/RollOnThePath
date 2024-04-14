using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RollWithIt.Models;

namespace RollWithIt.Views
{
    public class SectionShowViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<SectionWithSubLessons> _sections;
        private readonly string _url = "http://10.0.2.2:5252";
        private readonly int _lessonSectionId;
        private readonly string _lessonTitle;
        private readonly int _lessonId;

        public ObservableCollection<SectionWithSubLessons> Sections
        {
            get { return _sections; }
            set
            {
                _sections = value;
                OnPropertyChanged(nameof(Sections));
            }
        }

        public SectionShowViewModel(int lessonSectionId, string lessonTitle, int lessonId)
        {
            _lessonSectionId = lessonSectionId;
            _lessonTitle = lessonTitle;
            _lessonId = lessonId;
            Sections = new ObservableCollection<SectionWithSubLessons>();
            LoadSectionsWithSubLessons();
        }


        public SectionShowViewModel(ObservableCollection<string> lessonTitles, string lessonId, string title, int id)
        {
        }

        private async Task LoadSectionsWithSubLessons()
        {
            try
            {
                using var httpClient = new HttpClient();
                var response = await httpClient.GetAsync($"{_url}/api/{_lessonSectionId}/sections");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var sections = JsonConvert.DeserializeObject<List<SectionWithSubLessons>>(content);

                    foreach (var section in sections)
                    {
                        Sections.Add(section);
                    }
                }
                else
                {
                    Console.WriteLine("Failed to fetch sections data from the API.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
