using chess_api_signalR.Models;
using Microsoft.AspNetCore.Mvc;

namespace chess_api_signalR.Controllers
{
    public class HomeController : Controller
    {
        public JsonResult Index()
        {
            var exampleGameState = new ChessState("43", "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR", "52->36");
            return Json(exampleGameState);
        }
    }
}
