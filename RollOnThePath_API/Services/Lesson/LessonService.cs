using Microsoft.EntityFrameworkCore;
using RollOnThePath_API.Data;
using RollOnThePath_API.Models.Lessons;
using RollOnThePath_API.Models.Users;

namespace RollOnThePath_API.Services.Lesson
{
    public class LessonService : ILessonService
    {
        private readonly ApplicationDbContext _dbContext;

        public LessonService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Models.Lessons.Lesson>> GetAllLessons()
        {
            try
            {
                // Fetch all lessons from the database asynchronously
                return await _dbContext.Lessons.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error occurred while fetching lessons: {ex.Message}");
                throw; // Re-throw the exception for centralized exception handling
            }
        }

        public async Task<User> GetUserById(string id)
        {
            try
            {
                return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == int.Parse(id));
            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException("*** ERROR ***:", ex);
            }
        }

        public async Task<Models.Lessons.Lesson> GetLessonById(int id)
        {
            return await _dbContext.Lessons.FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task AddLesson(Models.Lessons.Lesson lesson)
        {
            // Check if the lesson object is null
            if (lesson == null)
            {
                throw new ArgumentNullException(nameof(lesson), "Lesson object cannot be null.");
            }

            // Add any necessary validations here

            try
            {
                // Add the lesson to the context
                _dbContext.Lessons.Add(lesson);

                // Save changes to the database
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Log the error or handle it appropriately
                throw new Exception("An error occurred while saving the lesson to the database.", ex);
            }
        }

        public async Task<LessonSection> CreateLessonSection(int lessonId, LessonSection lessonSection)
        {
            // Retrieve the lesson from the database
            var lesson = await _dbContext.Lessons.FindAsync(lessonId);
            if (lesson == null)
            {
                throw new ArgumentException($"Lesson with ID {lessonId} not found.");
            }

            try
            {
                // Assign the lesson ID to the lesson section
                lessonSection.LessonId = lessonId;
                // Add the lesson section
                _dbContext.LessonsSection.Add(lessonSection);
                await _dbContext.SaveChangesAsync();

                // Update the lesson with the new lesson section
                lesson.LessonSections.Add(lessonSection);
                await _dbContext.SaveChangesAsync();

                return lessonSection;

            } catch(DbUpdateException ex) 
            {
                throw new DbUpdateException("An error occurred while saving the lesson to the database.", ex);
            }
        }

        public async Task<SubLesson> CreateSubLesson(int sectionId, SubLesson subLesson)
        {
            // Retrieve the LessonSection by its ID
            var section = await _dbContext.LessonsSection.FindAsync(sectionId);
            if (section == null)
            {
                throw new ArgumentException("Invalid LessonSection ID");
            }

            // Add the subLesson to the LessonSection
            subLesson.LessonSectionId = sectionId;
            _dbContext.SubLessons.Add(subLesson);

            // Update the LessonSection's collection of sublessons
            section.SubLessons.Add(subLesson);

            // Save changes to the database
            await _dbContext.SaveChangesAsync();

            return subLesson;
        }


        public async Task<List<LessonSection>> GetLessonSectionsAsync(int lessonId)
        {
            try
            {
                var sections = await _dbContext.LessonsSection
                         .Where(ls => ls.LessonId == lessonId)
                         .ToListAsync();
                return sections;
            }
            catch (DbUpdateException ex)
            {
                // Log the error or handle it accordingly
                Console.WriteLine($"Error in GetLessonSectionsAsync: {ex.Message}");
                throw; // Rethrow the exception to propagate it
            }

        }
        public async Task<List<SubLesson>> GetSubLessonsBySectionId(int sectionId)
        {
            try
            {
                // Retrieve all SubLessons associated with a given LessonSection ID
                return await _dbContext.SubLessons
                                       .Where(sl => sl.LessonSectionId == sectionId)
                                       .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while fetching SubLessons for section ID {sectionId}: {ex.Message}");
                throw;
            }
        }


        public async Task<List<Models.Lessons.Lesson>> GetAllLessonsMatchingBelt(string beltColor)
        {
            return await _dbContext.Lessons
                                 .Where(l => l.Belt == beltColor)
                                 .ToListAsync();
        }

        public async Task<List<SubLesson>> GetSubLessonsAsync(int lessonSectionId)
        {
            try
            {
                // Retrieve sublessons from the database for the given lesson section ID
                var subLessons = await _dbContext.SubLessons
                                                   .Where(sl => sl.LessonSectionId == lessonSectionId)
                                                   .ToListAsync();

                return subLessons;
            }
            catch (Exception ex)
            {
                // Log the error or handle it as needed
                throw new Exception("Error occurred while fetching sublessons", ex);
            }
        }
    }
}