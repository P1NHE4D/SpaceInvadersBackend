using Entities.Models;
using Microsoft.EntityFrameworkCore;

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