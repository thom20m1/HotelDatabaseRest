using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ModelLib.Model;

namespace HotelDatabaseRest.DBUtil
{
    public class ManageRoom
    {
        private const string ConnString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private const String GETALL = "Select * From Room";
        private const String GETONE = "Select * From Room WHERE RoomNo = @RoomNo AND HotelNo = @HotelNo";
        private const string INSERT = "INSERT INTO Room VALUES (@RoomNo, @HotelNo, @Kapacity, @Price)";
        private const string DELETE = "DELETE FROM Room WHERE RoomNo = @RoomNo AND HotelNo = @HotelNo";
        private const string UPDATE = "UPDATE Room " +
                                      "SET RoomNo = @RoomNo, HotelNo = @HotelNo, Kapacity = @Kapacity, Price = @Price" +
                                      "WHERE RoomNo = @RoomID AND HotelID = @HotelID";
        // GET: api/Rooms
        public IEnumerable<Room> Get()
        {
            List<Room> liste = new List<Room>();

            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(GETALL, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Room room = ReadRoom(reader);
                liste.Add(room);
            }
            conn.Close();
            return liste;
        }

        private Room ReadRoom(SqlDataReader reader)
        {
            Room room = new Room();

            room.RoomNo = reader.GetInt32(0);
            room.HotelNo = reader.GetInt32(1);
            room.Kapacity = reader.GetString(2);
            room.Price = reader.GetInt32(3);

            return room;
        }


        // GET: api/Rooms/5
        public Room Get(int idHotel, int idRoom)
        {
            Room room = null;

            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(GETONE, conn);
            cmd.Parameters.AddWithValue("@HotelNo", idHotel);
            cmd.Parameters.AddWithValue("@RoomNo", idRoom);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                room = ReadRoom(reader);
            }
            conn.Close();
            return room;
        }

        // POST: api/Rooms
        public bool Post(Room room)
        {
            bool retValue;

            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(INSERT, conn);
            cmd.Parameters.AddWithValue("@RoomNo", room.RoomNo);
            cmd.Parameters.AddWithValue("@HotelNo", room.HotelNo);
            cmd.Parameters.AddWithValue("@Kapacity", room.Kapacity);
            cmd.Parameters.AddWithValue("@Price", room.Price);

            int rowsAffected = cmd.ExecuteNonQuery();
            retValue = rowsAffected == 1;
            conn.Close();


            return retValue;
        }

        // PUT: api/Rooms/5
        public bool Put(int idHotel, int idRoom, Room room)
        {
            bool retValue;

            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(UPDATE, conn);
            cmd.Parameters.AddWithValue("@RoomNo", room.RoomNo);
            cmd.Parameters.AddWithValue("@HotelID", idHotel);
            cmd.Parameters.AddWithValue("@RoomID", idRoom);
            cmd.Parameters.AddWithValue("@HotelNo", room.HotelNo);
            cmd.Parameters.AddWithValue("@Kapacity", room.Kapacity);
            cmd.Parameters.AddWithValue("@Price", room.Price);
            

            int rowsAffected = cmd.ExecuteNonQuery();
            retValue = rowsAffected == 1;
            conn.Close();

            return retValue;
        }

        // DELETE: api/Rooms/5
        public bool Delete(int idRoom, int idHotel)
        {
            bool retValue;

            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(DELETE, conn);
            cmd.Parameters.AddWithValue("@RoomNo", idRoom);
            cmd.Parameters.AddWithValue("@HotelNo", idHotel);

            int rowsAffected = cmd.ExecuteNonQuery();

            retValue = rowsAffected == 1;
            conn.Close();

            return retValue;
        }

    }
}