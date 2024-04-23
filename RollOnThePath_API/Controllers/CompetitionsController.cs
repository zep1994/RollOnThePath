using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RollOnThePath_API.Data;
using RollOnThePath_API.Models.Jujitsu;
using System.Security.Claims;

namespace RollOnThePath_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CompetitionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/Competitions
        [HttpPost]
        public async Task<ActionResult<Competition>> PostCompetition(Competition competition)
        {
            // Retrieve the current user's ID from the token
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            // Associate the competition with the current user
            competition.UserId = userId;

            // Convert local DateTime to UTC if not null before saving
            if (competition.DateTime.HasValue)
            {
                competition.DateTime = competition.DateTime.Value.ToUniversalTime();
            }

            _context.Competitions.Add(competition);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompetition", new { id = competition.Id }, competition);
        }
    }
}