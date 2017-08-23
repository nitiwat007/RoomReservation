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
        [TestMethod]
        public void TestRoomBLLGetRooms()
        {
            // Assemble
            RoomBLL roomBLL = new RoomBLL();

            // Act
            int getRooms = roomBLL.GetRooms().Count;

            // Assert
            Assert.AreNotEqual(0, getRooms);
        }

        [TestMethod]
        public void TestRoomBLLGetRoomByID()
        {
            // Assemble
            RoomBLL roomBLL = new RoomBLL();

            // Act
            string roomName = roomBLL.GetRoomByID("05403").Name;

            // Assert
            Assert.AreEqual("5403A", roomName);
        }
    }
}
