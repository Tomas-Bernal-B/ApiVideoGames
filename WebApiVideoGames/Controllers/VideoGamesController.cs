using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiVideoGames.Entidades;
using WebApiVideoGames.Migrations;

namespace WebApiVideoGames.Controllers
{
    [ApiController]
    [Route("api/videoGames")]
    public class VideoGamesController: ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public VideoGamesController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<VideoGame>>> GetById(int id)
        {
            return await dbContext.VideoGames.Include(x => x.Games).ToListAsync();
        }

        [HttpPost]

        public async Task<ActionResult> Post(VideoGame videoGame)
        {
            var existeGame = await dbContext.Games.AnyAsync(x => x.Id == videoGame.GameId);

            if (!existeGame)
            {
                return BadRequest("No existe el videojuego con el id ingresado");
            }
            dbContext.Add(videoGame);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(VideoGame videoGame, int id)
        {
            if (videoGame.Id != id)
            {
                return BadRequest("El id del videojugo no coincide con el establecido url.");
            }

            dbContext.Update(videoGame);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.VideoGames.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound("El videojuego no fue encontrado");
            }

            dbContext.Remove(new VideoGame()
            {
                Id = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();
        }


    }

}
