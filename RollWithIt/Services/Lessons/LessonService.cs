using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using RollWithIt.Models;
using RollWithIt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollWithIt.Services.Lessons
{
    public class LessonService
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly string URL = "http://10.0.2.2:5252/api/lessons";
        private List<Lesson>? _lessons;


        public LessonService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Lesson>> GetLessons()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{URL}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Lesson>>(json);
                }
                else
                {
                    // Handle error
                    Console.WriteLine($"Failed to fetch lessons: {response.StatusCode}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine($"Exception while fetching lessons: {ex.Message}");
                return null;
            }
        }

        public async Task<Lesson> GetLessonByTitleAsync(string title)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{URL}?title={title}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (content is not null)
                    {
                        Lesson? lesson = JsonConvert.DeserializeObject<Lesson>(content);
                        if (lesson != null)
                        {
                            return lesson;
                        }
                        
                    }
                }
                else
                {
                    // Handle unsuccessful response
                    Console.WriteLine($"Failed to retrieve lesson '{title}'. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine($"Error: {ex.Message}");
            }
            return null;
        }
    }
}