using Room.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Room.Models;
using System.Data.OracleClient;

namespace Room.Repositories
{
    public class RoomFromOracle : IRoomRepository
    {
        Room.DataSources.Oracle.RoomFromOracle db = new Room.DataSources.Oracle.RoomFromOracle();
        readonly string _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["regist2005_new"].ConnectionString;
        
        public RoomModel GetRoomByID(string ID)
        {
            var connection = new OracleConnection(_connectionString);
            OracleCommand cmd = new OracleCommand(string.Format("select ROOM_ID,ROOM_NAME,BUILDING_ID,STUD_CAPACITY,EXAM_CAPACITY from regist2005_new.room where room_id='{0}'", ID), connection);
            connection.Open();
            OracleDataReader reader = null;
            RoomModel room = null;
            try
            {
                reader = cmd.ExecuteReader();


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        room = new RoomModel();
                        room.ID = reader["ROOM_ID"].ToString();
                        room.Name = reader["ROOM_NAME"].ToString();
                        room.BuildingID = reader["BUILDING_ID"].ToString();
                        room.StudCapacity = (reader["STUD_CAPACITY"] == null || string.IsNullOrWhiteSpace(reader["STUD_CAPACITY"].ToString())) ? 0 : int.Parse(reader["STUD_CAPACITY"].ToString());
                        room.ExamCapacity = (reader["EXAM_CAPACITY"] == null || string.IsNullOrWhiteSpace(reader["EXAM_CAPACITY"].ToString())) ? 0 : int.Parse(reader["EXAM_CAPACITY"].ToString());
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                reader.Close();
                connection.Close();
            }

            return room;
            //return db.ROOMs.Where(x => x.ROOM_ID == ID).Select(x => new RoomModel { ID = x.ROOM_ID, BuildingID = x.BUILDING_ID, ExamCapacity = x.EXAM_CAPACITY.Value, StudCapacity = x.STUD_CAPACITY.Value, Name = x.ROOM_NAME }).SingleOrDefault();

        }

        public IQueryable<RoomModel> GetRooms()
        {
            var connection = new OracleConnection(_connectionString);
            OracleCommand cmd = new OracleCommand("select ROOM_ID,ROOM_NAME,BUILDING_ID,STUD_CAPACITY,EXAM_CAPACITY from regist2005_new.room", connection);
            connection.Open();
            OracleDataReader reader = null;
            var Rooms = new List<RoomModel>();
            try
            {
                reader = cmd.ExecuteReader();


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var room = new RoomModel();
                        room.ID = reader["ROOM_ID"].ToString();
                        room.Name = reader["ROOM_NAME"].ToString();
                        room.BuildingID = reader["BUILDING_ID"].ToString();
                        room.StudCapacity = (reader["STUD_CAPACITY"] == null || string.IsNullOrWhiteSpace(reader["STUD_CAPACITY"].ToString())) ? 0 : int.Parse(reader["STUD_CAPACITY"].ToString());
                        room.ExamCapacity = (reader["EXAM_CAPACITY"] == null || string.IsNullOrWhiteSpace(reader["EXAM_CAPACITY"].ToString())) ? 0 : int.Parse(reader["EXAM_CAPACITY"].ToString());
                        Rooms.Add(room);
                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                reader.Close();
                connection.Close();
            }
            return Rooms.AsQueryable();
            //return db.ROOMs.Select(x => new RoomModel { ID = x.ROOM_ID, BuildingID = x.BUILDING_ID, ExamCapacity = x.EXAM_CAPACITY.Value, StudCapacity = x.STUD_CAPACITY.Value, Name = x.ROOM_NAME }).AsQueryable();
        }

        public RoomModel GetRoomByIDWithEntityFrameWork(string ID)
        {
            return db.ROOMs.Where(x => x.ROOM_ID == ID).Select(x => new RoomModel { ID = x.ROOM_ID, BuildingID = x.BUILDING_ID, ExamCapacity = x.EXAM_CAPACITY.Value, StudCapacity = x.STUD_CAPACITY.Value, Name = x.ROOM_NAME }).SingleOrDefault();
        }
        public IQueryable<RoomModel> GetRoomsWithEntityFrameWork()
        {
            return db.ROOMs.Select(x => new RoomModel { ID = x.ROOM_ID, BuildingID = x.BUILDING_ID, ExamCapacity = x.EXAM_CAPACITY.Value, StudCapacity = x.STUD_CAPACITY.Value, Name = x.ROOM_NAME }).AsQueryable();
        }
    }
}