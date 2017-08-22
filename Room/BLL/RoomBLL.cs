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
        readonly string _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["regist2005_new"].ConnectionString;
        public RoomModel GetRoomByID(string ID)
        {

            var connection = new OracleConnection(_connectionString);
            OracleCommand cmd = new OracleCommand(string.Format("select * from regist2005_new.room where room_id='{0}'",ID), connection);
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
        }
        public IEnumerable<RoomModel> GetRooms()
        {
            var connection = new OracleConnection(_connectionString);
            OracleCommand cmd = new OracleCommand("select * from regist2005_new.room", connection);
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
                        room.StudCapacity = (reader["STUD_CAPACITY"] == null|| string.IsNullOrWhiteSpace(reader["STUD_CAPACITY"].ToString())) ? 0 : int.Parse(reader["STUD_CAPACITY"].ToString());
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
            
            return Rooms;
        }

    }
}