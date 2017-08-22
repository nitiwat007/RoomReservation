using Room.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room.Interface
{
    public interface IRoomBLL
    {
        IEnumerable<RoomModel> GetRooms();
        RoomModel GetRoomByID(string ID);
    }
}
