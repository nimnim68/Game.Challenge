using Game.Challenge.Domain.Game;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Challenge.Domain.User
{
    public class User
    {
        [Key]
        public long UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Address.Address Address { get; set; }
        public List<UserGame> UserGames { get; set; }

    }
}
