using Game.Challenge.Data;
using Game.Challenge.Domain.User;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;

namespace Game.Challenge.Tests.Unit
{
    public abstract class BaseTest
    {

        protected DbContextOptions<DatabaseContext> ContextOptions { get; }

        protected List<User> Users { get; set; }

        protected List<Domain.Game.Game> Games { get; set; }

        protected List<Domain.Game.UserGame> UserGames { get; set; }

        protected BaseTest(DbContextOptions<DatabaseContext> contextOptions)
        {
            ContextOptions = contextOptions;
            Games = new List<Domain.Game.Game>();
            Users = new List<User>();

            Seed();
        }

        public void Seed()
        {
            Games = new List<Domain.Game.Game>();
            Users = new List<User>();

            using (var context = new DatabaseContext(ContextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Domain.Game.Game gameOne = new Domain.Game.Game();
                gameOne.GameId = 1;
                gameOne.Name = "Game 1";
                gameOne.ThumbnailImage = "https://previews.123rf.com/images/aquir/aquir1311/aquir131100316/23569861-.jpg?fj=1";

                Domain.Game.Game gameTwo = new Domain.Game.Game();
                gameTwo.GameId = 2;
                gameTwo.Name = "Game 2";
                gameTwo.ThumbnailImage = "https://previews.123rf.com/images/aquir/aquir1311/aquir131100316/23569861-.jpg?fj=1";

                context.AddRange(gameOne, gameTwo);

                User userOne = new User();
                userOne.FirstName = "Nima";
                userOne.LastName = "Misaghi";
                userOne.Username = "nimnim68";
                userOne.Email = "misaghi.nima@gmail.com";
                userOne.Address = new Domain.Address.Address()
                {
                    City = "Berlin",
                    Country = "Germany",
                    Line1 = "Line 1 of Address",
                    Line2 = "Line 2 of Address",
                    Line3 = "Line 3 of Address",
                    ZipCode = "10179",
                };
                userOne.UserGames = new List<Domain.Game.UserGame>();

                userOne.UserGames.Add(new Domain.Game.UserGame()
                {
                    GameId = 1,
                    GameState = Domain.Game.GameState.Active,
                    LastPlayed = System.DateTime.Now,
                    RegisterDate = System.DateTime.Now.AddDays(-7),
                });

                userOne.UserGames.Add(new Domain.Game.UserGame()
                {
                    GameId = 2,
                    GameState = Domain.Game.GameState.Active,
                    LastPlayed = System.DateTime.Now.AddDays(-1),
                    RegisterDate = System.DateTime.Now.AddDays(-10),
                });

                User userTwo = new User();
                userTwo.FirstName = "Mina";
                userTwo.LastName = "Misaghi";
                userTwo.Username = "mina2022";
                userTwo.Email = "mina2022@gmail.com";
                userTwo.Address = new Domain.Address.Address()
                {
                    City = "Berlin",
                    Country = "Germany",
                    Line1 = "Line 1 of Address Mina",
                    Line2 = "Line 2 of Address Mina",
                    Line3 = "Line 3 of Address Mina",
                    ZipCode = "10180",
                };
                userTwo.UserGames = new List<Domain.Game.UserGame>();

                userTwo.UserGames.Add(new Domain.Game.UserGame()
                {
                    GameId = 1,
                    GameState = Domain.Game.GameState.Active,
                    LastPlayed = System.DateTime.Now.AddDays(-2),
                    RegisterDate = System.DateTime.Now.AddDays(-10),
                });

                userTwo.UserGames.Add(new Domain.Game.UserGame()
                {
                    GameId = 2,
                    GameState = Domain.Game.GameState.Banned,
                    LastPlayed = System.DateTime.Now.AddDays(-10),
                    RegisterDate = System.DateTime.Now.AddDays(-30),
                });

                context.AddRange(userOne, userTwo);

                context.SaveChanges();

                Users.Add(userOne);
                Users.Add(userTwo);

                Games.Add(gameOne);
                Games.Add(gameTwo);
            }
        }

    }
}