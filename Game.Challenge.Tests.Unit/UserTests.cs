using Game.Challenge.Data;
using Game.Challenge.Domain.User;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;

namespace Game.Challenge.Tests.Unit
{
    public class UserTests : BaseTest
    {
        public UserTests() : base(new DbContextOptionsBuilder<DatabaseContext>()
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
        public void Should_Create_a_new_user_without_errors()
        {
            using (var context = new DatabaseContext(ContextOptions))
            {
                User userTest = new User();
                userTest.FirstName = "FirstName Test 1";
                userTest.LastName = "LastName Test 1";
                userTest.Username = "UserNameTest";
                userTest.Email = "Test@gmail.com";
                userTest.Address = new Domain.Address.Address()
                {
                    City = "Berlin",
                    Country = "Germany",
                    Line1 = "Line 1 of Address Test",
                    Line2 = "Line 2 of Address Test",
                    Line3 = "Line 3 of Address Test",
                    ZipCode = "10700",
                };
                userTest.UserGames = new List<Domain.Game.UserGame>();

                userTest.UserGames.Add(new Domain.Game.UserGame()
                {
                    GameId = 1,
                    GameState = Domain.Game.GameState.Active,
                    LastPlayed = System.DateTime.Now,
                    RegisterDate = System.DateTime.Now.AddDays(-7),
                });

                userTest.UserGames.Add(new Domain.Game.UserGame()
                {
                    GameId = 2,
                    GameState = Domain.Game.GameState.Active,
                    LastPlayed = System.DateTime.Now.AddDays(-1),
                    RegisterDate = System.DateTime.Now.AddDays(-10),
                });

                Assert.AreEqual(0, userTest.UserId);
                Assert.DoesNotThrowAsync(async () => await context.Users.AddAsync(userTest));
                Assert.AreNotEqual(0, userTest.UserId);

                Assert.DoesNotThrow(() => context.SaveChanges());
            }
        }

        [Test]
        public async void Should_Update_a_user_without_errors()
        {
            using (var context = new DatabaseContext(ContextOptions))
            {
                User userTest = await context.Users.Include(i=>i.Address).FirstAsync(f => f.Username == "UserNameTest");

                if (userTest == null)
                {
                    Assert.AreEqual(null, userTest);
                }
                else
                {
                    userTest.FirstName = "FirstName UpdateTest 2";
                    userTest.LastName = "LastName UpdateTest 2";
                    userTest.Username = "UserNameUpdateTest";
                    userTest.Email = "UpdateTest@gmail.com";
                    userTest.Address = new Domain.Address.Address()
                    {
                        City = "Berlin UpdateTest",
                        Country = "Germany UpdateTest",
                        Line1 = "Line 1 of Address UpdateTest",
                        Line2 = "Line 2 of Address UpdateTest",
                        Line3 = "Line 3 of Address UpdateTest",
                        ZipCode = "10900",
                    };

                    Assert.DoesNotThrow(() => context.SaveChanges());

                    userTest = await context.Users.Include(i => i.Address).FirstAsync(f => f.Username == "UserNameUpdateTest");

                    Assert.AreEqual(userTest.FirstName, "FirstName UpdateTest 1");
                    Assert.AreEqual(userTest.LastName, "LastName UpdateTest 1");
                    Assert.AreEqual(userTest.FirstName, "UserNameUpdateTest");
                    Assert.AreEqual(userTest.FirstName, "UpdateTest@gmail.com");


                    Assert.AreEqual(userTest.Address.City, "Berlin UpdateTest");
                    Assert.AreEqual(userTest.Address.Country, "Germany UpdateTest");
                    Assert.AreEqual(userTest.Address.Line1, "Line 1 of Address UpdateTest");
                    Assert.AreEqual(userTest.Address.Line2, "Line 2 of Address UpdateTest");
                    Assert.AreEqual(userTest.Address.Line3, "Line 3 of Address UpdateTest");
                    Assert.AreEqual(userTest.Address.ZipCode, "10900");
                }

            }
        }

    }
}
