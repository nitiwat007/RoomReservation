using Room.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room.Interface
{
    public interface IRoomRepository
    {
        RoomModel GetRoomByID(string ID);
        //RoomModel GetRoomByIDWithEntityFrameWork(string ID);
        IQueryable<RoomModel> GetRooms();
        //IQueryable<RoomModel> GetRoomsWithEntityFrameWork();
    }
}
