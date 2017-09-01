using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Room.Models;
using Room.BLL;
using Room.Interface;

namespace Room.Controllers
{
    public class RoomController : Controller
    {
        IRoomRepository roomRepository = new Repositories.RoomFromSqlServer();
        // GET: Room
        public ActionResult Index()
        {
            //var roomBLL = new RoomBLL();
            IRoomBLL roomBLL = new RoomBLL(roomRepository);
            return View(roomBLL.GetRooms());
        }
        public ActionResult Rooms()
        {
            //var roomBLL = new RoomBLL();
            IRoomBLL roomBLL = new RoomBLL(roomRepository);
            return View(roomBLL.GetRooms());
        }

        public ActionResult RoomDetail(string ID)
        {
            //var roomBLL = new RoomBLL();
            IRoomBLL roomBLL = new RoomBLL(roomRepository);
            return View(roomBLL.GetRoomByID(ID));
        }
    }
}