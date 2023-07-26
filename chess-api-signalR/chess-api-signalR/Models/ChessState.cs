namespace chess_api_signalR.Models
{
    public class ChessState
    {
        public string GameID { get; set; }
        public string GameFen { get; set; }
        public string Move { get; set; }

        public ChessState(string gameID, string gameFen, string move)
        {
            GameID = gameID;
            GameFen = gameFen;
            Move = move;
        }
    }
}
