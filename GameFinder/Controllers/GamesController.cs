using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GameFinder.Models;
using GameFinder.Entities;
using GameFinder.Services;

namespace GameFinder.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private GameFinderContext _db;
        private IUserService _userService;

        public GamesController(GameFinderContext db, IUserService userService)
        {
            _db = db;
            _userService = userService;
        }


        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User userParam)
        {
            var user = _userService.Authenticate(userParam.Username, userParam.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [HttpGet]
        [Route("user/")]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        // GET api/games
        [HttpGet]
        public ActionResult<IEnumerable<Game>> Get(string name, string type, string publisher, int maxplayers, int minplayers, int minage)
        {
            var query = _db.Games.AsQueryable();

            if (name != null)
            {
                query = query.Where(entry => entry.Name.ToLower().Contains(name.ToLower())); 
            }
            if (type != null)
            {
                query = query.Where(entry => entry.Type.ToLower().Contains(type.ToLower()));
            }
            if (publisher != null)
            {
                query = query.Where(entry => entry.Publisher.ToLower().Contains(publisher.ToLower()));
            }
            if (maxplayers != 0)
            {
                query = query.Where(entry => entry.MaxPlayers <= maxplayers);
            }
            if (minplayers != 0)
            {
                query = query.Where(entry => entry.MinPlayers >= minplayers);
            }
            if (minage != 0)
            {
                query = query.Where(entry => entry.MinAge >= minage);
            }
            return query.ToList();
        }

        // POST api/games
        [HttpPost]
        public void Post([FromBody] Game game)
        {
            _db.Games.Add(game);
            _db.SaveChanges();
        }

        // GET api/games/5
        [HttpGet("{id}")]
        public ActionResult<Game> GetAction(int id)
        {
            return _db.Games.FirstOrDefault(entry => entry.GameId == id);
        }

        [HttpPut("{id}")]
        public void Put (int id, [FromBody] Game game)
        {
            game.GameId = id;
            _db.Entry(game).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
        }

        // DELETE api/games/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var gameToDelete = _db.Games.FirstOrDefault(entry => entry.GameId == id);
            _db.Games.Remove(gameToDelete);
            _db.SaveChanges();
        }
    }
}