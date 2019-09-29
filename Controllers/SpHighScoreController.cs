using System;
using Microsoft.AspNetCore.Mvc;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Cors;

namespace SpaceInvadersServer.Controllers
{
    [EnableCors("CorsPolicy")]
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

        [HttpPost]
        public IActionResult AddSpHighScore([FromBody]SpHighScore spHighScore)
        {
            try
            {
                if (spHighScore == null)
                {
                    _logger.LogError("SpHighScore object received from client is null");
                    return BadRequest("SpHighScore object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("SpHighScore object received from client is invalid");
                    return BadRequest("Invalid SpHighScore object");
                }
                
                _repository.SpHighScore.AddHighScore(spHighScore);
                _repository.Save();

                return Created("api/sp-high-score", spHighScore);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occured in AddSpHighScore: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}