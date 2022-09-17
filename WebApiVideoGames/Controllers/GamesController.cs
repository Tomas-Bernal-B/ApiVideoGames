using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiVideoGames.Entidades;

namespace WebApiVideoGames.Controllers
{
    [ApiController]
    [Route("api/games")]
    public class GamesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public GamesController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Game>>> Get()
        {
            return await dbContext.Games.ToListAsync();
            
        }

        [HttpPost]
        public async Task<ActionResult> Post(Game game)
        {
            dbContext.Add(game);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Put(Game game, int id)
        {
            if(game.Id != id)
            {
                return BadRequest("El id del game no coincido con el establecido en el url.");
            }
            dbContext.Update(game);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Games.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound();
            }
            dbContext.Remove(new Game()
            {
                Id = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
