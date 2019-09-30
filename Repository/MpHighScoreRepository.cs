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

        /// <summary>
        /// Fetches all multi player high score entries from the database in a descending order based on the score
        /// </summary>
        /// <returns>Returns an enumerable list containing all multi player high scores</returns>
        public IEnumerable<MpHighScore> GetAllHighScores()
        {
            return FindAll().OrderByDescending(entry => entry.Score).ToList();
        }

        /// <summary>
        /// Adds a multi player high score entry to the database
        /// </summary>
        /// <param name="highScore">multi player high score object</param>
        public void AddHighScore(MpHighScore highScore)
        {
            highScore.Id = Guid.NewGuid();
            Create(highScore);
        }
    }
}