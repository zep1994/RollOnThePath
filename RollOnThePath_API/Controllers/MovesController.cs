using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RollOnThePath_API.Models;
using RollOnThePath_API.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;


namespace RollOnThePath_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MovesController(ApplicationDbContext context) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;

        // GET: api/Moves
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Move>>> GetMoves()
        {
            return await _context.Moves.ToListAsync();
        }

        // GET: api/Moves/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Move>> GetMove(int id)
        {
            var move = await _context.Moves.FindAsync(id);

            if (move == null)
            {
                return NotFound();
            }

            return move;
        }

        // POST: api/Moves
        [HttpPost]
        public async Task<ActionResult<Move>> CreateMove(Move move)
        {
            _context.Moves.Add(move);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMove), new { id = move.Id }, move);
        }

        // PUT: api/Moves/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMove(int id, Move move)
        {
            if (id != move.Id)
            {
                return BadRequest();
            }

            _context.Entry(move).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoveExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Moves/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMove(int id)
        {
            var move = await _context.Moves.FindAsync(id);
            if (move == null)
            {
                return NotFound();
            }

            _context.Moves.Remove(move);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MoveExists(int id)
        {
            return _context.Moves.Any(e => e.Id == id);
        }

        [HttpGet("beltsearch")]
        [Authorize] // Requires authentication
        public IActionResult GetMovesForCurrentUserBelt()
        {
            // Retrieve the logged-in user's id from claims
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null) { return NotFound(); }
            // Retrieve the user's information from the database
            var user = _context.Users.FirstOrDefault(u => u.Id == int.Parse(userId));

            if (user == null)
            {
                return NotFound("User not found");
            }

            // Get moves suitable for the user's belt rank
            var movesForUserBelt = _context.Moves
                .Where(m => m.SuggestedBelt == user.BeltRank)
                .ToList();

            return Ok(movesForUserBelt);
        }
    }
}