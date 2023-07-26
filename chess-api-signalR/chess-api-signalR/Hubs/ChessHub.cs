using chess_api_signalR.Models;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace chess_api_signalR.Hubs
{
    public class ChessHub : Hub
    {
        //private static readonly string _url = "amqps://nkinbgvx:Y9va4y4Tbp8I8RxmBLxLA6lC7jMVcBlY@shrimp.rmq.cloudamqp.com/nkinbgvx";
        public async Task SendBoardState(string gameID, string fen, string move)
        {

            var gameState = new ChessState(gameID, fen, move);
            var json = JsonConvert.SerializeObject(gameState);
            System.Diagnostics.Debug.WriteLine(json);

            /*var connectionFactory = new ConnectionFactory
            {
                Uri = new Uri(_url)
            };

            using var connection = connectionFactory.CreateConnection();
            using var channel = connection.CreateModel();*/

            //channel.ExchangeDeclare(exchange: "chess-topic", ExchangeType.Topic);


            await Clients.All.SendAsync("ReceiveMessage", gameID, fen, move);
        }
    }
}
