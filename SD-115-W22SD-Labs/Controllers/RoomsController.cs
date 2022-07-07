using Microsoft.AspNetCore.Mvc;
using SD_115_W22SD_Labs.Models;
using System.Diagnostics;

namespace SD_115_W22SD_Labs.Controllers
{
    public class RoomsController : Controller
    {
        public IActionResult Index()
        {
            return View(Hotel.Rooms);
        }
        
        public IActionResult TotalCapacity()
        {
            ViewBag.TotalNumberOfRoomRemaining = Hotel.Rooms.Aggregate(0, (prev, room) => prev + (room.Occupied ? 0 : 1));
            return View(Hotel.Rooms);
        }

        [HttpGet]
        [Route("Rooms/Occupants/{occupants:int}")]
        public IActionResult Occupants(int occupants)
        {
            Room? room = Hotel.Rooms.OrderBy((room) => room.Number).FirstOrDefault((room) => room.Capacity >= occupants);
            return View(room);
        }
    }
}
