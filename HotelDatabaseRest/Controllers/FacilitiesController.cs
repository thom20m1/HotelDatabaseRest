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

        // PUT: api/Facilities/5
        public bool Put(int idHotel, int idFacility, [FromBody]Facility facility)
        {
            return manager.Put(idHotel, idFacility, facility);
        }

        // DELETE: api/Facilities/5
        public bool Delete(int idHotel, int idFacility)
        {
            return manager.Delete(idHotel, idFacility);
        }
    }
}
