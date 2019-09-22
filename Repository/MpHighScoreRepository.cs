using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<MpHighScore> GetAllHighScores()
        {
            return FindAll().OrderBy(entry => entry.Score).ToList();
        }
    }
}