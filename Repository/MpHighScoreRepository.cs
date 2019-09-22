using Contracts;
using Entities;
using SpaceInvadersServer.Entities.Models;

namespace Repository
{
    public class MpHighScoreRepository: RepositoryBase<MpHighScore>, IMpHighScoreRepository
    {
        public MpHighScoreRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}