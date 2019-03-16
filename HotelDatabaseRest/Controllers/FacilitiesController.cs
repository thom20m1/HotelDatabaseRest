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
    public class FacilitiesController : ApiController
    {
        private ManageFacility manager = new ManageFacility();
        // GET: api/Facilities
        public IEnumerable<Facility> Get()
        {
            return manager.Get();
        }

        [Route("api/Rooms/{idHotel}:int/{idFacility}:int")]
        // GET: api/Facilities/5
        public Facility Get(int idHotel, int idFacility)
        {
            return manager.Get(idHotel, idFacility);
        }
        
        // POST: api/Facilities
        public bool Post([FromBody]Facility facility)
        {
            return manager.Post(facility);
        }

        [Route("api/Rooms/{idHotel}:int/{idFacility}:int")]
        // PUT: api/Facilities/5
        public bool Put(int idHotel, int idFacility, [FromBody]Facility facility)
        {
            return manager.Put(idHotel, idFacility, facility);
        }

        [Route("api/Rooms/{idHotel}:int/{idFacility}:int")]
        // DELETE: api/Facilities/5
        public bool Delete(int idHotel, int idFacility)
        {
            return manager.Delete(idHotel, idFacility);
        }
    }
}
