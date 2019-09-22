using System.Collections.Generic;
using SpaceInvadersServer.Entities.Models;

namespace Contracts
{
    public interface IMpHighScoreRepository : IRepositoryBase<MpHighScore>
    {
        IEnumerable<MpHighScore> GetAllHighScores();
    }
}