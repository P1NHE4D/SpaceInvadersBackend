using System;
using System.Linq;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;

namespace UnitTests
{
    [TestClass]
    public class TestSpHighScoreRepository
    {
        private static SpHighScore scoreOne = new SpHighScore
        {
            Id = new Guid(),
            PlayerOneName = "DummyOne",
            Score = 430
        };

        private static SpHighScore scoreTwo = new SpHighScore
        {
            Id = new Guid(),
            PlayerOneName = "DummyTwo",
            Score = 500
        };

        [TestMethod]
        public void TestAddHighScore()
        {
            var options = new DbContextOptionsBuilder<RepositoryContext>()
                .UseInMemoryDatabase(databaseName: "TestAddHighScore").Options;

            using (var context = new RepositoryContext(options))
            {
                var service = new SpHighScoreRepository(context);
                service.AddHighScore(scoreOne);
                service.AddHighScore(scoreTwo);
                context.SaveChanges();
            }

            using (var context = new RepositoryContext(options))
            {
                Assert.AreEqual(2, context.SpHighScores.Count());
            }
        }

        [TestMethod]
        public void TestGetAllScores()
        {
            var options = new DbContextOptionsBuilder<RepositoryContext>()
                .UseInMemoryDatabase(databaseName: "TestGetAllScores").Options;

            using (var context = new RepositoryContext(options))
            {
                context.SpHighScores.Add(scoreOne);
                context.SpHighScores.Add(scoreTwo);
                context.SaveChanges();
            }

            using (var context = new RepositoryContext(options))
            {
                var service = new SpHighScoreRepository(context);
                Assert.AreEqual(2, service.GetAllHighScores().Count());
            }
        }

    }
}