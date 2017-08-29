using Room.Interface;
using Room.Models;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Web;

namespace Room.BLL
{
    public class RoomBLL : IRoomBLL
    {
        IRoomRepository roomRepository;

        public RoomBLL(IRoomRepository repository)
        {
            roomRepository = repository;
        }
        public RoomModel GetRoomByID(string ID)
        {         
            return roomRepository.GetRoomByID(ID);
        }
        public List<RoomModel> GetRooms()
        {
                       
            return roomRepository.GetRooms().ToList();
        }

    }
}