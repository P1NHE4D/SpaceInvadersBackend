using System;
using Microsoft.AspNetCore.Mvc;
using Contracts;

namespace SpaceInvadersServer.Controllers
{
    [Route("api/mp-high-score")]
    public class MpHighScoreController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;

        public MpHighScoreController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllMpHighScores()
        {
            try
            {
                var scores = _repository.MpHighScore.GetAllHighScores();
                
                _logger.LogInfo("Retrieved all multi player high scores from database");

                return Ok(scores);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occured in GetAllMpHighScores: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}