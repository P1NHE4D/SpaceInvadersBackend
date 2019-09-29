using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class TestMpHighScoreRepository
    {
        private static MpHighScore scoreOne = new MpHighScore
        {
            Id = new Guid(),
            PlayerOneName = "DummyOne",
            PlayerTwoName = "DummyPartner",
            Score = 430
        };

        private static MpHighScore scoreTwo = new MpHighScore
        {
            Id = new Guid(),
            PlayerOneName = "DummyTwo",
            PlayerTwoName = "DummyPartner",
            Score = 500
        };

        [TestMethod]
        public void TestAddHighScore()
        {
            var options = new DbContextOptionsBuilder<RepositoryContext>()
                .UseInMemoryDatabase(databaseName: "TestAddHighScore").Options;

            using (var context = new RepositoryContext(options))
            {
                var service = new MpHighScoreRepository(context);
                service.AddHighScore(scoreOne);
                service.AddHighScore(scoreTwo);
                context.SaveChanges();
            }

            using (var context = new RepositoryContext(options))
            {
                Assert.AreEqual(2, context.MpHighScores.Count());
            }
        }

        [TestMethod]
        public void TestGetAllScores()
        {
            var options = new DbContextOptionsBuilder<RepositoryContext>()
                .UseInMemoryDatabase(databaseName: "TestGetAllScores").Options;

            using (var context = new RepositoryContext(options))
            {
                context.MpHighScores.Add(scoreOne);
                context.MpHighScores.Add(scoreTwo);
                context.SaveChanges();
            }

            using (var context = new RepositoryContext(options))
            {
                var service = new MpHighScoreRepository(context);
                Assert.AreEqual(2, service.GetAllHighScores().Count());
            }
        }
    }
}