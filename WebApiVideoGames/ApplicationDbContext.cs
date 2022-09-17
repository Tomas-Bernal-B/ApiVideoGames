using Microsoft.EntityFrameworkCore;
using WebApiVideoGames.Entidades;

namespace WebApiVideoGames
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Game> Games { get; set; }

        public DbSet<VideoGame> VideoGames { get; set; }
    }
}
