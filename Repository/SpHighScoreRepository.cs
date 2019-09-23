using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<SpHighScore> GetAllHighScores()
        {
            return FindAll().OrderByDescending(entry => entry.Score).ToList();
        }

        public void AddHighScore(SpHighScore highScore)
        {
            highScore.Id = Guid.NewGuid();
            Create(highScore);
        }
    }
}