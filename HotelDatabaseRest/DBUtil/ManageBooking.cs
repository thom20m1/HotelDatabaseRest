using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ModelLib.Model;

namespace HotelDatabaseRest.DBUtil
{
    public class ManageBooking
    {
        private const string ConnString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private const String GETALL = "Select * From Booking";
        private const String GETONE = "Select * From Booking WHERE BookingNo = @No";
        private const string INSERT = "INSERT INTO Booking VALUES (@BookingNo, @RoomNo, @HotelNo, @GuestNo, @StartDate, @EndDate)";
        private const string DELETE = "DELETE FROM Booking WHERE BookingNo = @No";
        private const string UPDATE = "UPDATE Booking " +
                                      "SET BookingNo = @BookingNo, RoomNo = @RoomNo, HotelNo = @HotelNo, GuestNo = @GuestNo, StartDate = @StartDate, EndDate = @EndDate " +
                                      "WHERE BookingNo = @ID";
        // GET: api/Bookings
        public IEnumerable<Booking> Get()
        {
            List<Booking> liste = new List<Booking>();

            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(GETALL, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Booking booking = ReadBooking(reader);
                liste.Add(booking);
            }
            conn.Close();
            return liste;
        }

        private Booking ReadBooking(SqlDataReader reader)
        {
            Booking booking = new Booking();

            booking.BookingNo = reader.GetInt32(0);
            booking.RoomNo = reader.GetInt32(1);
            booking.HotelNo = reader.GetInt32(2);
            booking.GuestNo = reader.GetInt32(3);
            booking.StartDate = reader.GetString(4);
            booking.EndDate = reader.GetString(5);

            return booking;
        }


        // GET: api/Bookings/5
        public Booking Get(int id)
        {
            Booking booking = null;

            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(GETONE, conn);
            cmd.Parameters.AddWithValue("@No", id);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                booking = ReadBooking(reader);
            }
            conn.Close();
            return booking;
        }

        // POST: api/Bookings
        public bool Post(Booking booking)
        {
            bool retValue;

            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(INSERT, conn);
            cmd.Parameters.AddWithValue("@BookingNo", booking.BookingNo);
            cmd.Parameters.AddWithValue("@RoomNo", booking.RoomNo);
            cmd.Parameters.AddWithValue("@HotelNo", booking.HotelNo);
            cmd.Parameters.AddWithValue("@GuestNo", booking.GuestNo);
            cmd.Parameters.AddWithValue("@StartDate", booking.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", booking.EndDate);


            int rowsAffected = cmd.ExecuteNonQuery();
            retValue = rowsAffected == 1;
            conn.Close();


            return retValue;
        }

        // PUT: api/Hotels/5
        public bool Put(int id, Booking booking)
        {
            bool retValue;

            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(UPDATE, conn);
            cmd.Parameters.AddWithValue("@BookingNo", booking.BookingNo);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@RoomNo", booking.RoomNo);
            cmd.Parameters.AddWithValue("@HotelNo", booking.HotelNo);
            cmd.Parameters.AddWithValue("@GuestNo", booking.GuestNo);
            cmd.Parameters.AddWithValue("@StartDate", booking.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", booking.EndDate);


            int rowsAffected = cmd.ExecuteNonQuery();
            retValue = rowsAffected == 1;
            conn.Close();

            return retValue;
        }

        // DELETE: api/Bookings/5
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