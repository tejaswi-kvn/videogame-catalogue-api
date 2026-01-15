using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoGameCatalogue.Api.Data;
using VideoGameCatalogue.Api.Models;

namespace VideoGameCatalogue.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGamesController : ControllerBase
    {
        private readonly VideoGamesDbContext _context;

        public VideoGamesController(VideoGamesDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all video games
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VideoGame>>> GetVideoGames()
        {
            return await _context.VideoGames.ToListAsync();
        }

        /// <summary>
        /// Update the video game by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="videoGame"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVideoGame(Guid id, VideoGame videoGame)
        {
            if (id != videoGame.Id)
            {
                return BadRequest();
            }

            _context.Entry(videoGame).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideoGameExists(id))
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

        /// <summary>
        /// Create a new video game
        /// </summary>
        /// <param name="videoGame"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<VideoGame>> PostVideoGame(VideoGame videoGame)
        {
            _context.VideoGames.Add(videoGame);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVideoGame", new { id = videoGame.Id }, videoGame);
        }

       /// <summary>
       /// Deletes the video game with the specified unique identifier.
       /// </summary>
       /// <param name="id">The unique identifier of the video game to delete.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideoGame(Guid id)
        {
            var videoGame = await _context.VideoGames.FindAsync(id);
            if (videoGame == null)
            {
                return NotFound();
            }

            _context.VideoGames.Remove(videoGame);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VideoGameExists(Guid id)
        {
            return _context.VideoGames.Any(e => e.Id == id);
        }
    }
}
