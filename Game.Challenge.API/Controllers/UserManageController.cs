using AutoMapper;
using Game.Challenge.API.Dto.User;
using Game.Challenge.Data;
using Game.Challenge.Domain.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Game.Challenge.API.Controllers
{
    [Route(Routes.UserRouteManage)]
    [ApiController]
    public class UserManageController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public UserManageController(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/<UserManageController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserManageReadDto>>> GetAll(UserManageSearchDto input)
        {
            List<User> users = await _context.Users.Where(g => g.Username.Contains(input.Username)).ToListAsync();
            if (!users?.Any() == true)
                return NotFound("Users not found");

            return Ok(_mapper.Map<List<UserManageReadDto>>(users));
        }

        // GET api/<UserManageController>/7
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserManageReadDto))]
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

            return Ok(_mapper.Map<UserManageReadDto>(user));
        }

        // PATCH api/<UserManageController>/7
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserManageReadDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Patch(long id, [FromBody] UserManageEditDto value)
        {
            User user = await _context.Users.Include(g => g.Address).FirstAsync(g => g.UserId == id);
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

            if (!string.IsNullOrEmpty(value.Username))
                user.Username = value.Username;

            if (!string.IsNullOrEmpty(value.LastName))
                user.LastName = value.LastName;

            if (!string.IsNullOrEmpty(value.Email))
                user.Email = value.Email;

            await _context.SaveChangesAsync();
            UserManageReadDto updatedUser = _mapper.Map<UserManageReadDto>(user);
            return Ok(updatedUser);
        }

    }
}
