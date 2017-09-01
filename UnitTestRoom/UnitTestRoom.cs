using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Room.BLL;
using Room.Models;
using System.Collections.Generic;
using Room.Interface;

namespace UnitTestRoom
{
    [TestClass]
    public class UnitTestRoom
    {
        IRoomRepository roomRepositorySqlServer = new Room.Repositories.RoomFromSqlServer();
        IRoomRepository roomRepositoryOracle = new Room.Repositories.RoomFromOracle();
        [TestMethod]
        public void TestRoomBLLGetRoomsOracle()
        {
            // Assemble
            RoomBLL roomBLL = new RoomBLL(roomRepositoryOracle);

            // Act
            int getRooms = roomBLL.GetRooms().Count;

            // Assert
            Assert.AreNotEqual(0, getRooms);
        }

        [TestMethod]
        public void TestRoomBLLGetRoomByIDOracle()
        {
            // Assemble
            RoomBLL roomBLL = new RoomBLL(roomRepositoryOracle);

            // Act
            string roomName = roomBLL.GetRoomByID("05403").Name;

            // Assert
            Assert.AreEqual("5403A", roomName);
        }
        [TestMethod]
        public void TestRoomBLLGetRoomsSqlServer()
        {
            // Assemble
            RoomBLL roomBLL = new RoomBLL(roomRepositorySqlServer);

            // Act
            int getRooms = roomBLL.GetRooms().Count;

            // Assert
            Assert.AreNotEqual(0, getRooms);
        }

        [TestMethod]
        public void TestRoomBLLGetRoomByIDSqlServer()
        {
            // Assemble
            RoomBLL roomBLL = new RoomBLL(roomRepositorySqlServer);

            // Act
            string roomName = roomBLL.GetRoomByID("05403").Name;

            // Assert
            Assert.AreEqual("5403A", roomName);
        }
        [TestMethod]
        public void TestRoomBLLGetRoomByIDOracleEF()
        {
            // Assemble
            RoomBLL roomBLL = new RoomBLL(roomRepositoryOracle);

            // Act
            string roomName = roomBLL.GetRoomByIDWithEntityFrameWork("05403").Name;

            // Assert
            Assert.AreEqual("5403A", roomName);

        }
        [TestMethod]
        public void TestRoomBLLGetRoomsOracleEF()
        {
            // Assemble
            RoomBLL roomBLL = new RoomBLL(roomRepositoryOracle);

            // Act
            int getRooms = roomBLL.GetRoomByWithEntityFrameWork().Count;

            // Assert
            Assert.AreNotEqual(0, getRooms);
        }
    }
}
