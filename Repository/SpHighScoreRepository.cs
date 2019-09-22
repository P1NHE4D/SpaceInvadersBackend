using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class SpHighScoreRepository: RepositoryBase<SpHighScore>, ISpHighScoreRepository
    {
        public SpHighScoreRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}