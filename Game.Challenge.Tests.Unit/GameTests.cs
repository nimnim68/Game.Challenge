using Game.Challenge.Data;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Game.Challenge.Tests.Unit
{
    public class GameTests : BaseTest
    {
        public GameTests() : base(new DbContextOptionsBuilder<DatabaseContext>()
               .UseInMemoryDatabase(databaseName: "GameChallengeTest")
               .Options)
        {

        }

        [SetUp]
        public void Setup()
        {
            Seed();
        }

        [Test]
        public void Should_Create_a_new_game_without_errors()
        {
            using (var context = new DatabaseContext(ContextOptions))
            {

                Domain.Game.Game gameTest = new Domain.Game.Game();
                gameTest.Name = "Game Test";
                gameTest.ThumbnailImage = "https://previews.123rf.com/images/aquir/aquir1311/aquir131100316/23569861-.jpg?fj=1";

                Assert.AreEqual(0, gameTest.GameId);
                Assert.DoesNotThrowAsync(async () => await context.Games.AddAsync(gameTest));
                Assert.AreNotEqual(0, gameTest.GameId);

                Assert.DoesNotThrow(() => context.SaveChanges());
            }
        }
    }
}
