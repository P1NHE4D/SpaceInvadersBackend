using System.Collections.Generic;
using Entities.Models;

namespace Contracts
{
    public interface ISpHighScoreRepository : IRepositoryBase<SpHighScore>
    {
        IEnumerable<SpHighScore> GetAllHighScores();
        void AddHighScore(SpHighScore highScore);
    }
}