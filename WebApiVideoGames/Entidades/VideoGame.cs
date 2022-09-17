namespace WebApiVideoGames.Entidades
{
    public class VideoGame
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Genero { get; set; }

        public int GameId { get; set; }

        public Game Game { get; set; }
        public object Games { get; internal set; }
    }
}
