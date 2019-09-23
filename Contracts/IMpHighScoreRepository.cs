using System.Collections.Generic;
using Entities.Models;

namespace Contracts
{
    public interface IMpHighScoreRepository : IRepositoryBase<MpHighScore>
    {
        IEnumerable<MpHighScore> GetAllHighScores();
        void AddHighScore(MpHighScore highScore);
    }
}