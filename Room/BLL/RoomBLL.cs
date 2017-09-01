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

        public RoomModel GetRoomByIDWithEntityFrameWork(string ID)
        {
            return roomRepository.GetRoomByIDWithEntityFrameWork(ID);
        }

        public List<RoomModel> GetRoomByWithEntityFrameWork()
        {
            return roomRepository.GetRoomsWithEntityFrameWork().ToList();
        }

        public List<RoomModel> GetRooms()
        {
                       
            return roomRepository.GetRooms().ToList();
        }

    }
}