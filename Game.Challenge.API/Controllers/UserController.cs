using AutoMapper;
using Game.Challenge.API.Dto.User;
using Game.Challenge.Data;
using Game.Challenge.Domain.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Game.Challenge.API.Controllers
{
    [Route(Routes.UserRoute)]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public UserController(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET api/<UserController>/7
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(long id)
        {
            User user = await _context.Users.Include(g => g.Address).Include(g => g.UserGames).ThenInclude(g => g.Game).FirstAsync(f => f.UserId == id);
            if (user == null)
                return StatusCode(404);

            if (user.UserGames?.Any() == true)
            {
                user.UserGames = user.UserGames.OrderByDescending(o => o.LastPlayed).ToList();
            }

            return Ok(_mapper.Map<User>(user));
        }

        // POST api/<UserController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserCreateDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] UserCreateDto value)
        {
            User user = _mapper.Map<User>(value);

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            var created = _mapper.Map<User>(user);
            return CreatedAtAction(nameof(Get), new { id = created.UserId }, created);
        }

        // PATCH api/<UserController>/7
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserEditDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Patch(long id, [FromBody] UserEditDto value)
        {
            User user = await _context.Users.Include(g => g.Address).FirstOrDefaultAsync(g => g.UserId == id);
            if (user == null)
                return StatusCode(404);

            if (value.Address != null)
            {
                if (!string.IsNullOrEmpty(value.Address.Line1))
                    user.Address.Line1 = value.Address.Line1;

                if (!string.IsNullOrEmpty(value.Address.Line2))
                    user.Address.Line2 = value.Address.Line2;

                if (!string.IsNullOrEmpty(value.Address.Line3))
                    user.Address.Line3 = value.Address.Line3;

                if (!string.IsNullOrEmpty(value.Address.City))
                    user.Address.City = value.Address.City;

                if (!string.IsNullOrEmpty(value.Address.ZipCode))
                    user.Address.ZipCode = value.Address.ZipCode;

                if (!string.IsNullOrEmpty(value.Address.Country))
                    user.Address.Country = value.Address.Country;
            }

            if (!string.IsNullOrEmpty(value.FirstName))
                user.FirstName = value.FirstName;

            if (!string.IsNullOrEmpty(value.LastName))
                user.LastName = value.LastName;

            if (!string.IsNullOrEmpty(value.Email))
                user.Email = value.Email;

            await _context.SaveChangesAsync();
            User updatedUser = _mapper.Map<User>(user);
            return Ok(updatedUser);
        }


    }
}
