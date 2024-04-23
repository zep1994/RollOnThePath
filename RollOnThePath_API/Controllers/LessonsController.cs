using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RollOnThePath_API.Models.Lessons;
using RollOnThePath_API.Services.Lesson;

namespace RollOnThePath_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

                return CreatedAtAction(nameof(GetLessonSection), new { lessonId, id = createdLessonSection.Id }, createdLessonSection);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("sections/{id}")]
        public async Task<ActionResult<LessonSection>> GetLessonSection(int id)
        {
            try
            {
                var lessonSection = await _lessonService.GetLessonSection(id);
                if (lessonSection == null)
                {
                    return NotFound($"Lesson section with ID {id} not found");
                }

                return Ok(lessonSection);
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