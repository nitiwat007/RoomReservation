using Service_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_API.Interface
{
    public interface IRoomBLL
    {
        List<RoomModel> GetRooms();
        RoomModel GetRoomByID(string ID);
    }
}
