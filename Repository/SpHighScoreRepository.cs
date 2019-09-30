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
        
        /// <summary>
        /// Fetches all single player high score entries from the database in a descending order based on the score
        /// </summary>
        /// <returns>Returns an enumerable list containing all single player high scores</returns>
        public IEnumerable<SpHighScore> GetAllHighScores()
        {
            return FindAll().OrderByDescending(entry => entry.Score).ToList();
        }

        /// <summary>
        /// Adds a single player high score entry to the database
        /// </summary>
        /// <param name="highScore">single player high score object</param>
        public void AddHighScore(SpHighScore highScore)
        {
            highScore.Id = Guid.NewGuid();
            Create(highScore);
        }
    }
}