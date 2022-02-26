using Game.Challenge.Domain.User;
using Game.Challenge.Domain.Game;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Challenge.Domain.Address;

namespace Game.Challenge.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Game.Challenge.Domain.Game.Game> Games { get; set; }
        public DbSet<Game.Challenge.Domain.Game.UserGame> UserGames { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(b => b.Address)
                .WithOne(i => i.User)
                .HasForeignKey<Address>(b => b.UserId);

            modelBuilder.Entity<UserGame>()
                .HasOne(p => p.Game)
                .WithMany(b => b.UserGames)
                .HasForeignKey(p => p.GameId);

            modelBuilder.Entity<UserGame>()
                .HasOne(p => p.User)
                .WithMany(b => b.UserGames)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<Game.Challenge.Domain.Game.Game>().HasData(new Game.Challenge.Domain.Game.Game
            {
                GameId = 1,
                Name = "Call of duty",
                ThumbnailImage = "https://previews.123rf.com/images/aquir/aquir1311/aquir131100316/23569861-.jpg?fj=1",
            });

            modelBuilder.Entity<Game.Challenge.Domain.Game.Game>().HasData(new Game.Challenge.Domain.Game.Game
            {
                GameId = 2,
                Name = "Need for speed",
                ThumbnailImage = "https://previews.123rf.com/images/aquir/aquir1311/aquir131100316/23569861-.jpg?fj=1",
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = 1,
                FirstName = "FirstName Test 1",
                LastName = "LastName Test 1",
                Username = "UserNameTest",
                Email = "Test@gmail.com",
            });

            modelBuilder.Entity<Address>().HasData(new Address
            {
                AddressId = 1,
                UserId = 1,
                City = "Berlin",
                Country = "Germany",
                Line1 = "Line 1 of Address Test",
                Line2 = "Line 2 of Address Test",
                Line3 = "Line 3 of Address Test",
                ZipCode = "10700",
            });


            modelBuilder.Entity<UserGame>().HasData(new UserGame
            {
                UserGameId = 1,
                GameId = 1,
                UserId = 1,
                GameState = Domain.Game.GameState.Active,
                LastPlayed = System.DateTime.Now,
                RegisterDate = System.DateTime.Now.AddDays(-7),
            });

            modelBuilder.Entity<UserGame>().HasData(new UserGame
            {
                UserGameId = 2,
                GameId = 2,
                UserId = 1,
                GameState = Domain.Game.GameState.Active,
                LastPlayed = System.DateTime.Now.AddDays(-2),
                RegisterDate = System.DateTime.Now.AddDays(-10),
            });
            //base.OnModelCreating(modelBuilder);
        }

    }
}
