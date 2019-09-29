using System;
using Microsoft.AspNetCore.Mvc;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Cors;

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
        
        [HttpPost]
        public IActionResult AddMpHighScore([FromBody]MpHighScore mpHighScore)
        {
            try
            {
                if (mpHighScore == null)
                {
                    _logger.LogError("MpHighScore object received from client is null");
                    return BadRequest("MpHighScore object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("MpHighScore object received from client is invalid");
                    return BadRequest("Invalid MpHighScore object");
                }
                
                _repository.MpHighScore.AddHighScore(mpHighScore);
                _repository.Save();

                return Created("api/mp-high-score", mpHighScore);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occured in AddMpHighScore: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}