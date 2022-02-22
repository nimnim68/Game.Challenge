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
    public class UserAdminController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public UserAdminController(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // DELETE api/<UserAdminController>/7
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(long id)
        {
            User user = await _context.Users.Include(g => g.Address).Include(g => g.UserGames).FirstAsync(f => f.UserId == id);
            if (user == null)
                return StatusCode(404);

            if (user.UserGames?.Any() == true)
                _context.UserGames.RemoveRange(user.UserGames);

            if (user.Address != null)
                _context.Address.Remove(user.Address);

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PATCH api/<UserAdminController>/7
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserAdminEditDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Patch(long id, [FromBody] UserAdminEditDto value)
        {
            User user = await _context.Users.Include(g => g.UserGames).FirstOrDefaultAsync(g => g.UserId == id);
            if (user == null)
                return StatusCode(404);

            if (value.UserGames != null)
            {
                foreach (var usergameValue in value.UserGames)
                {
                    if (usergameValue.GameState != null)
                    {
                        var usergame = user.UserGames.FirstOrDefault(f => f.UserGameId == usergameValue.UserGameId);
                        if (usergame != null)
                        {
                            usergame.GameState = usergameValue.GameState;
                        }
                    }
                }
            }
            else
            {
                return StatusCode(404);
            }

            await _context.SaveChangesAsync();
            User updatedUser = _mapper.Map<User>(user);
            return Ok(updatedUser);
        }
    }
}
