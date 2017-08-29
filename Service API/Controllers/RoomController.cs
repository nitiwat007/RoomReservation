using Service_API.BLL;
using Service_API.Interface;
using Service_API.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Service_API.Controllers
{   /// <summary>
/// 
/// </summary>
    public class RoomController : ApiController
    {
        IRoomBLL roomBLL = new RoomBLL();
        /// <summary>
        /// Get List of Room
        /// </summary>
        /// <returns></returns>
        [Route("rooms")][ResponseType(typeof(List<RoomModel>))]
        public IHttpActionResult GetRooms()
        {
            List<RoomModel> Rooms = null;
            try
            {
                Rooms = roomBLL.GetRooms();
            }
            catch (Exception)
            {

                return BadRequest();
            }

            return Ok(Rooms);
        }
        /// <summary>
        /// Get Room by ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>RoomModel</returns>
        [Route("rooms/{ID}")][ResponseType(typeof(RoomModel))]
        public IHttpActionResult GetRoomByID(string ID)
        {
            RoomModel Room = null;
            try
            {
                
                Room= roomBLL.GetRoomByID(ID);
            }
            catch (Exception)
            {

                return BadRequest();
            }
            return Ok(Room);
        }
    }
}
