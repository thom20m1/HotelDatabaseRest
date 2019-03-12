using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ModelLib.Model;

namespace HotelDatabaseRest.DBUtil
{
    public class ManageGuest
    {
        private const string ConnString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private const String GETALL = "Select * From Guest";
        private const String GETONE = "Select * From Guest WHERE GuestNo =@No";
        private const string INSERT = "INSERT INTO Guest VALUES (@No, @Name, @PhoneNo, @Email)";
        private const string DELETE = "DELETE FROM Guest WHERE GuestNo = @No";

        private const string UPDATE = "UPDATE Guest " +
                                      "SET GuestNo = @GuestNo, Name = @Name, PhoneNo = @PhoneNo, Email = @Email " +
                                      "WHERE GuestNo = @No";

        // GET: api/Guest
        public IEnumerable<Guest> Get()
        {
            List<Guest> liste = new List<Guest>();

            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(GETALL, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Guest guest = ReadGuest(reader);
                liste.Add(guest);
            }

            conn.Close();
            return liste;
        }

        private Guest ReadGuest(SqlDataReader reader)
        {
            Guest guest = new Guest();

            guest.GuestNo = reader.GetInt32(0);
            guest.Name = reader.GetString(1);
            guest.PhoneNo = reader.GetString(2);
            guest.Email = reader.GetString(3);

            return guest;
        }


        // GET: api/Guest/5
        public Guest Get(int id)
        {
            Guest guest = null;

            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(GETONE, conn);
            cmd.Parameters.AddWithValue("@No", id);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                guest = ReadGuest(reader);
            }

            conn.Close();
            return guest;
        }

        // POST: api/Guest
        public bool Post(Guest guest)
        {
            bool retValue;

            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(INSERT, conn);
            cmd.Parameters.AddWithValue("@No", guest.GuestNo);
            cmd.Parameters.AddWithValue("@Name", guest.Name);
            cmd.Parameters.AddWithValue("@PhoneNo", guest.PhoneNo);
            cmd.Parameters.AddWithValue("@Email", guest.Email);

            int rowsAffected = cmd.ExecuteNonQuery();
            retValue = rowsAffected == 1;
            conn.Close();


            return retValue;
        }

        // PUT: api/Guest/5
        public bool Put(int id, Guest guest)
        {
            bool retValue;

            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(UPDATE, conn);
            cmd.Parameters.AddWithValue("@GuestNo", guest.GuestNo);
            cmd.Parameters.AddWithValue("@No", id);
            cmd.Parameters.AddWithValue("@Name", guest.Name);
            cmd.Parameters.AddWithValue("@PhoneNo", guest.PhoneNo);
            cmd.Parameters.AddWithValue("@Email", guest.Email);

            int rowsAffected = cmd.ExecuteNonQuery();
            retValue = rowsAffected == 1;
            conn.Close();

            return retValue;
        }

        // DELETE: api/Guest/5
        public bool Delete(int id)
        {
            bool retValue;

            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(DELETE, conn);
            cmd.Parameters.AddWithValue("@No", id);

            int rowsAffected = cmd.ExecuteNonQuery();

            retValue = rowsAffected == 1;
            conn.Close();

            return retValue;
        }
    }
}