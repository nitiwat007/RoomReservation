using Room.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Room.Models;

namespace Room.Repositories
{
    public class RoomFromSqlServer : IRoomRepository
    {
        reservation_systemEntities db = new reservation_systemEntities();
        public RoomModel GetRoomByID(string ID)
        {
            //return db.rooms.Where(x => x.ROOM_ID == ID).Select(x=>new RoomModel { ID=x.ROOM_ID, BuildingID=x.BUILD_ID,ExamCapacity=0,StudCapacity=x.size.Value,Name=x.ROOM_NAME}).SingleOrDefault();
            return db.sp_room(ID).Select(x => new RoomModel { ID = x.ROOM_ID, BuildingID = x.BUILD_ID, ExamCapacity = 0, StudCapacity = x.size.Value, Name = x.ROOM_NAME }).SingleOrDefault();  // use stored procedure         
        }

        public RoomModel GetRoomByIDWithEntityFrameWork(string ID)
        {
            throw new NotImplementedException();
        }

        public RoomModel GetRoomGetRoomByIDWithEntityFrameWork(string ID)
        {
            throw new NotImplementedException();
        }

        public IQueryable<RoomModel> GetRooms()
        {
            //return db.rooms.Select(x => new RoomModel { ID = x.ROOM_ID, BuildingID = x.BUILD_ID, ExamCapacity = 0, StudCapacity = x.size.Value, Name = x.ROOM_NAME });
            return db.sp_room(null).Select(x => new RoomModel { ID = x.ROOM_ID, BuildingID = x.BUILD_ID, ExamCapacity = 0, StudCapacity = x.size.Value, Name = x.ROOM_NAME }).AsQueryable();
        }

        public IQueryable<RoomModel> GetRoomsWithEntityFrameWork()
        {
            throw new NotImplementedException();
        }
    }
}