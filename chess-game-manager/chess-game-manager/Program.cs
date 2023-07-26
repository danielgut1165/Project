// See https://aka.ms/new-console-template for more information

using System.Text;
using chess_game_manager;
using chess_game_manager.Pieces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

class Program
{
    private static readonly string _url = "amqps://nkinbgvx:Y9va4y4Tbp8I8RxmBLxLA6lC7jMVcBlY@shrimp.rmq.cloudamqp.com/nkinbgvx";
    static void Main(string[] args)
    {
        //GameState game = new GameState("45", "8/8/8/8/3B4/8/8/8");
        //game.PrintBoard();
        //Console.WriteLine();
        //game.MakeMove(47, 44);
        //game.PrintBoard();
        //Console.WriteLine();
        //game.DebugMovesAll('P');
        //game.DebugMovesAll('B');
        //game.DebugMovesAll('R');
        //game.PrintDebugBoard();
        //Console.WriteLine(game.GenerateFen());
        var connectionFactory = new ConnectionFactory
        {
            Uri = new Uri(_url),
        };

        using var connection = connectionFactory.CreateConnection();
        using var channel = connection.CreateModel();

        Console.WriteLine("hello world");
        

    }
}
//rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR
//r1bk3r/p2pBpNp/n4n2/1p1NP2P6P1/3P4/P1P1K3/q5b1
//8/8/8/4p1K1/2k1P3/8/8/8