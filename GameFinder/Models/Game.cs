namespace GameFinder.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Publisher { get; set; }
        public int MaxPlayers { get; set; }
        public int MinPlayers { get; set; }
        public int MinAge { get; set; }
        public int AvgPlayTime { get; set; }

    }
}