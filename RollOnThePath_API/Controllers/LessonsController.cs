using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RollOnThePath_API.Models.Lessons;
using RollOnThePath_API.Services.Lesson;

namespace RollOnThePath_API.Controllers
{
    [Route("api/[controller]"), ApiController]
    public class LessonsController : ControllerBase
    {
        private readonly ILessonService _lessonService;

        public LessonsController(ILessonService lessonService)
        {
            _lessonService = lessonService ?? throw new ArgumentNullException(nameof(lessonService));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLessons()
        {
            try
            {
                var lessons = await _lessonService.GetAllLessons();
                return Ok(lessons);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLessonById(int id)
        {
            try
            {
                var lesson = await _lessonService.GetLessonById(id);
                if (lesson == null)
                {
                    return NotFound();
                }
                return Ok(lesson);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddLesson([FromBody] Lesson lesson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _lessonService.AddLesson(lesson);
                return CreatedAtAction(nameof(GetLessonById), new { id = lesson.Id }, lesson);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("{lessonId}/sections")]
        public async Task<IActionResult> CreateLessonSection(int lessonId, [FromBody] LessonSection lessonSection)
        {
            try
            {
                var createdLessonSection = await _lessonService.CreateLessonSection(lessonId, lessonSection);
                if (createdLessonSection == null)
                {
                    return NotFound($"Lesson with ID {lessonId} not found");
                }

                return CreatedAtAction(nameof(GetLessonSections), new { lessonId, id = createdLessonSection.Id }, createdLessonSection);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{lessonId}/sections")]
        public async Task<IActionResult> GetLessonSections(int lessonId)
        {
            try
            {
                var lessonSections = await _lessonService.GetLessonSectionsAsync(lessonId);
                // Configure JSON serializer settings
                var serializerSettings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    PreserveReferencesHandling = PreserveReferencesHandling.None
                };

                var json = JsonConvert.SerializeObject(lessonSections, serializerSettings);

                if (json == null)
                {
                    return NotFound($"Lesson section with ID {lessonId} not found");
                }

                return Content(json, "application/json");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{lessonSectionId}/sublessons")]
        public async Task<IActionResult> GetSubLessonsAsync(int lessonSectionId)
        {
            try
            {
                var subLessons = await _lessonService.GetSubLessonsAsync(lessonSectionId);
                // Configure JSON serializer settings
                var serializerSettings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    PreserveReferencesHandling = PreserveReferencesHandling.None
                };

                var json = JsonConvert.SerializeObject(subLessons, serializerSettings);

                if (json == null)
                {
                    return NotFound($"Lesson section with ID {lessonSectionId} not found");
                }

                return Content(json, "application/json");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("sections/{sectionId}/sublessons")]
        public async Task<IActionResult> CreateSubLesson(int sectionId, SubLesson subLesson)
        {
            try
            {
                var createdSubLesson = await _lessonService.CreateSubLesson(sectionId, subLesson);
                return Ok(createdSubLesson);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}