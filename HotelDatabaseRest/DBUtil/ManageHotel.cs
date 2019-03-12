using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using ModelLib.Model;

namespace HotelDatabaseRest.DBUtil
{
    public class ManageHotel
    {
        private const string ConnString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ThomasHotelDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private const string GETALL = "Select * From Hotel";
        private const string GETONE = "Select * From Hotel WHERE HotelID = @ID";
        private const string INSERT = "INSERT INTO Hotel VALUES (@ID, @Name, @Address, @PhoneNo, @Email)";
        private const string DELETE = "DELETE FROM Hotel WHERE HotelID = @ID";
        private const string UPDATE = "UPDATE Hotel " +
                                      "SET HotelID = @HotelID, Name = @Name, Address = @Address, PhoneNo = @PhoneNo, Email = @Email " +
                                      "WHERE HotelID = @ID";
        // GET: api/Hoteller
        public IEnumerable<Hotel> Get()
        {
            List<Hotel> liste = new List<Hotel>();

            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(GETALL, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Hotel hotel = ReadHotel(reader);
                liste.Add(hotel);
            }
            conn.Close();
            return liste;
        }

        private Hotel ReadHotel(SqlDataReader reader)
        {
            Hotel hotel = new Hotel();

            hotel.Id = reader.GetInt32(0);
            hotel.Name = reader.GetString(1);
            hotel.Address = reader.GetString(2);
            hotel.PhoneNo = reader.GetString(3);
            hotel.Email = reader.GetString(4);

            return hotel;
        }


        // GET: api/Hotels/5
        public Hotel Get(int id)
        {
            Hotel hotel = null;

            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(GETONE, conn);
            cmd.Parameters.AddWithValue("@ID", id);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                hotel = ReadHotel(reader);
            }
            conn.Close();
            return hotel;
        }

        // POST: api/Hotels
        public bool Post(Hotel hotel)
        {
            bool retValue;

            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(INSERT, conn);
            cmd.Parameters.AddWithValue("@ID", hotel.Id);
            cmd.Parameters.AddWithValue("@Name", hotel.Name);
            cmd.Parameters.AddWithValue("@Address", hotel.Address);
            cmd.Parameters.AddWithValue("@PhoneNo", hotel.PhoneNo);
            cmd.Parameters.AddWithValue("@Email", hotel.Email);

            int rowsAffected = cmd.ExecuteNonQuery();
            retValue = rowsAffected == 1;
            conn.Close();


            return retValue;
        }

        // PUT: api/Hotels/5
        public bool Put(int id, Hotel hotel)
        {
            bool retValue;

            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(UPDATE, conn);
            cmd.Parameters.AddWithValue("@HotelID", hotel.Id);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@Name", hotel.Name);
            cmd.Parameters.AddWithValue("@Address", hotel.Address);
            cmd.Parameters.AddWithValue("@PhoneNo", hotel.PhoneNo);
            cmd.Parameters.AddWithValue("@Email", hotel.Email);

            int rowsAffected = cmd.ExecuteNonQuery();
            retValue = rowsAffected == 1;
            conn.Close();

            return retValue;
        }

        // DELETE: api/Hotels/5
        public bool Delete(int id)
        {
            bool retValue;

            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(DELETE, conn);
            cmd.Parameters.AddWithValue("@ID", id);

            int rowsAffected = cmd.ExecuteNonQuery();

            retValue = rowsAffected == 1;
            conn.Close();

            return retValue;
        }

    }
}