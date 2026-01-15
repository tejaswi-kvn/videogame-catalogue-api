using Microsoft.EntityFrameworkCore;
using System;
using VideoGameCatalogue.Api.Models;


namespace VideoGameCatalogue.Api.Data
{
    public class VideoGamesDbContext : DbContext
    {
        public VideoGamesDbContext(DbContextOptions<VideoGamesDbContext> options) : base(options) { }

        public DbSet<VideoGame> VideoGames { get; set; }
    }
}
