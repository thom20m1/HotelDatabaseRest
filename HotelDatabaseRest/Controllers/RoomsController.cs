using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelDatabaseRest.DBUtil;
using ModelLib.Model;

namespace HotelDatabaseRest.Controllers
{
    public class RoomsController : ApiController
    {

        private ManageRoom manager = new ManageRoom();
        // GET: api/Rooms
        public IEnumerable<Room> Get()
        {
            return manager.Get();
        }

        // GET: api/Rooms/5
        [Route ("api/Rooms/{idHotel}:int/{idRoom}:int")]
        public Room Get(int idHotel, int idRoom)
        {
            return manager.Get(idHotel, idRoom);
        }

        // POST: api/Rooms
        public bool Post([FromBody]Room room)
        {
            return manager.Post(room);
        }

        // PUT: api/Rooms/5
        public bool Put(int idHotel, int idRoom, [FromBody]Room room)
        {
            return manager.Put(idHotel,idRoom,room);
        }

        // DELETE: api/Rooms/5
        public bool Delete(int idHotel, int idRoom)
        {
            return manager.Delete(idRoom, idHotel);
        }
    }
}
