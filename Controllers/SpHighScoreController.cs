using System;
using Microsoft.AspNetCore.Mvc;
using Contracts;

namespace SpaceInvadersServer.Controllers
{
    [Route("api/sp-high-score")]
    public class SpHighScoreController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;

        public SpHighScoreController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllSpHighScores()
        {
            try
            {
                var scores = _repository.SpHighScore.GetAllHighScores();
                
                _logger.LogInfo("Retrieved all single player high scores from database");

                return Ok(scores);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occured in GetAllSpHighScores: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}