﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelDatabaseRest.DBUtil;
using ModelLib.Model;

namespace HotelDatabaseRest.Controllers
{
    public class GuestsController : ApiController
    {

        private ManageGuest manager = new ManageGuest();
        // GET: api/Guests
        public IEnumerable<Guest> Get()
        {
            return manager.Get();
        }

        // GET: api/Guests/5
        public Guest Get(int id)
        {
            return manager.Get(id);
        }

        // POST: api/Guests
        public bool Post([FromBody]Guest guest)
        {
            return manager.Post(guest);
        }

        // PUT: api/Guests/5
        public bool Put(int id, [FromBody]Guest guest)
        {
            return manager.Put(id, guest);
        }

        // DELETE: api/Guests/5
        public bool Delete(int id)
        {
            return manager.Delete(id);
        }
    }
}
