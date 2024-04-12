using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RollOnThePath_API.Data;
using RollOnThePath_API.Models;
using System.Security.Claims;

namespace RollOnThePath_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MatchesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Matches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Match>>> GetMatches()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var matches = await _context.Matches.Where(m => m.UserId == userId).ToListAsync();
            return Ok(matches);
        }

        // GET: api/Matches/{competitionId}
        [HttpGet("{competitionId}")]
        public async Task<ActionResult<IEnumerable<Match>>> GetMatchesByCompetition(int competitionId)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var matches = await _context.Matches
                .Where(m => m.UserId == userId && m.CompetitionId == competitionId)
                .ToListAsync();
            return Ok(matches);
        }

        // POST: api/Matches
        [HttpPost]
        public async Task<ActionResult<Match>> PostMatch(Match match)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            match.UserId = userId;

            _context.Matches.Add(match);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMatch", new { id = match.Id }, match);
        }
    }
}