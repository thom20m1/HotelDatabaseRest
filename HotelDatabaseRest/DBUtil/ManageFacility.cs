using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ModelLib.Model;

namespace HotelDatabaseRest.DBUtil
{
    public class ManageFacility
    {
        private const string ConnString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ThomasHotelDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private const String GETALL = "Select * From Facility";
        private const String GETONE = "Select * From Facility WHERE FacilityNo = @FacilityNo AND HotelNo = @HotelNo";
        private const string INSERT = "INSERT INTO Facility VALUES (@HotelNo, @FacilityNo, @Type)";
        private const string DELETE = "DELETE FROM Facility WHERE FacilityNo = @FacilityNo AND HotelNo = @HotelNo";

        private const string UPDATE = "UPDATE Facility " +
                                      "SET FacilityNo = @FacilityNo, HotelNo = @HotelNo, Type = @Type " +
                                      "WHERE FacilityNo = @FacilityID AND HotelNo = @HotelID";

        // GET: api/Facility
        public IEnumerable<Facility> Get()
        {
            List<Facility> liste = new List<Facility>();

            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(GETALL, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Facility facility= ReadFacility(reader);
                liste.Add(facility);
            }

            conn.Close();
            return liste;
        }

        private Facility ReadFacility(SqlDataReader reader)
        {
            Facility facility = new Facility();

            facility.HotelNo = reader.GetInt32(0);
            facility.FacilityNo = reader.GetInt32(1);
            facility.Type = reader.GetString(2);

            return facility;
        }


        // GET: api/Facility/5
        public Facility Get(int idHotel, int idFacility)
        {
            Facility facility = null;

            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(GETONE, conn);
            cmd.Parameters.AddWithValue("@HotelNo", idHotel);
            cmd.Parameters.AddWithValue("@FacilityNo", idFacility);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                facility = ReadFacility(reader);
            }

            conn.Close();
            return facility;
        }

        // POST: api/Facility
        public bool Post(Facility facility)
        {
            bool retValue;

            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(INSERT, conn);
            cmd.Parameters.AddWithValue("@HotelNo", facility.HotelNo);
            cmd.Parameters.AddWithValue("@FacilityNo", facility.FacilityNo);
            cmd.Parameters.AddWithValue("@Type", facility.Type);

            int rowsAffected = cmd.ExecuteNonQuery();
            retValue = rowsAffected == 1;
            conn.Close();


            return retValue;
        }

        // PUT: api/Facility/5
        public bool Put(int idHotel, int idFacility, Facility facility)
        {
            bool retValue;

            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(UPDATE, conn);
            cmd.Parameters.AddWithValue("@HotelNo", facility.HotelNo);
            cmd.Parameters.AddWithValue("@FacilityNo", facility.FacilityNo);
            cmd.Parameters.AddWithValue("@FacilityID", idFacility);
            cmd.Parameters.AddWithValue("@HotelID", idHotel);
            cmd.Parameters.AddWithValue("@Type", facility.Type);

            int rowsAffected = cmd.ExecuteNonQuery();
            retValue = rowsAffected == 1;
            conn.Close();

            return retValue;
        }

        // DELETE: api/Facility/5
        public bool Delete(int idHotel, int idFacility)
        {
            bool retValue;

            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(DELETE, conn);
            cmd.Parameters.AddWithValue("@HotelNo", idHotel);
            cmd.Parameters.AddWithValue("@FacilityNo", idFacility);

            int rowsAffected = cmd.ExecuteNonQuery();

            retValue = rowsAffected == 1;
            conn.Close();

            return retValue;
        }
    }
}