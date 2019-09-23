using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class MpHighScoreRepository: RepositoryBase<MpHighScore>, IMpHighScoreRepository
    {
        public MpHighScoreRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<MpHighScore> GetAllHighScores()
        {
            return FindAll().OrderByDescending(entry => entry.Score).ToList();
        }

        public void AddHighScore(MpHighScore highScore)
        {
            highScore.Id = Guid.NewGuid();
            Create(highScore);
        }
    }
}