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

            //base.OnModelCreating(modelBuilder);
        }

    }
}
