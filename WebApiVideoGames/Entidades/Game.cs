namespace WebApiVideoGames.Entidades
{
    public class Game
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public List<VideoGame> videoGames { get; set; }
    }
}
