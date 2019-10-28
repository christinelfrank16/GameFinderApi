using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GameFinder.Models;

namespace GameFinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private GameFinderContext _db;

        public GamesController(GameFinderContext db)
        {
            _db = db;
        }

        // GET api/games
        [HttpGet]
        public ActionResult<IEnumerable<Game>> Get()
        {
            return _db.Games.ToList();
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