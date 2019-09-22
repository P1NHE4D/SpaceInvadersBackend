using Entities.Models;
using Microsoft.EntityFrameworkCore;
using SpaceInvadersServer.Entities.Models;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<SpHighScore> SpHighScores { get; set; }
        
        public DbSet<MpHighScore> MpHighScores { get; set; }
    }
}