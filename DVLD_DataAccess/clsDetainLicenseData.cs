using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsDetainLicenseData
    {
        public int DetainID {  get; set; }
        public int LicenseID {  get; set; }
        public DateTime DetainDate {  get; set; }
        public float FineFees {  get; set; }
        public int CreateByUserID {  get; set; }
        public int IsReleased {  get; set; }
        public DateTime? ReleasedDate { get;set; }
        public int? ReleasedByUserID {  get; set; }
        public int? ReleasedAppID {  get; set; }



        public static string ConnectionString = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

        static public DataTable GetAllDetainedLicense()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            string query = "select * from detainedLicenses_View order by IsReleased ,DetainID;";

            SqlCommand command = new SqlCommand(query, connection);

            DataTable dt = new DataTable();
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
        static public int DetainLicense(int LicenseID,float FineFees,int CreateByUserID)
        {

            SqlConnection connection = new SqlConnection(ConnectionString);

            string query = @"insert into DetainedLicenses(LicenseID,DetainDate,FineFees,CreatedByUserID,IsReleased)
                             values(@LicenseID,GetDate(),@FineFees,@CreatedByUserID,0);Select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreateByUserID);
            command.Parameters.AddWithValue("@FineFees", FineFees);

            int DetainID = -1;

            try
            {


                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    DetainID = InsertID;
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return DetainID;
        }
        static public bool ReleasedLicense(int LicenseID,int ReleasedByUserID, int ReleasedAppID )
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            string query = @"update DetainedLicenses set 
                             ReleaseDate = GETDATE(),
                             ReleasedByUserID = @ReleasedByUserID,
                             ReleaseApplicationID =@ReleaseApplicationID,
                             IsReleased = 1
                             where LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            command.Parameters.AddWithValue("@ReleaseApplicationID", ReleasedAppID);

            int RowsAffected = -1;
            try
            {
                connection.Open();
                RowsAffected = command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return (RowsAffected > 0);

        }
        static public bool IsTheLicenseDetained(int LicenseID)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            string query = @"
                            select Found=1 from DetainedLicenses
                            where LicenseID=@LicenseID and IsReleased = 0";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            bool IsFound = false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                IsFound = reader.HasRows;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }
        static public bool GetDetainLicenseInfoByLicenseID(int LicenseID,ref clsDetainLicenseData DetainLicenseData)
        {
            SqlConnection connection= new SqlConnection(ConnectionString);
            string query = @"select * from DetainedLicenses
                            where LicenseID=@LicenseID";
            SqlCommand command= new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            bool IsFound = true;
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    DetainLicenseData.DetainID = Convert.ToInt32(reader["DetainID"]);
                    DetainLicenseData.LicenseID = Convert.ToInt32(reader["LicenseID"]);
                    DetainLicenseData.DetainDate = Convert.ToDateTime(reader["DetainDate"]);
                    DetainLicenseData.FineFees = Convert.ToInt32(reader["FineFees"]);
                    DetainLicenseData.CreateByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    DetainLicenseData.IsReleased = Convert.ToInt32(reader["IsReleased"]);

                    DetainLicenseData.ReleasedDate= reader["ReleaseDate"] != DBNull.Value? (DateTime?)reader["ReleaseDate"] : null;
                    DetainLicenseData.ReleasedAppID= reader["ReleaseApplicationID"] != DBNull.Value ? (int?)reader["ReleaseApplicationID"] : null;
                    DetainLicenseData.ReleasedByUserID=  reader["ReleasedByUserID"] != DBNull.Value ? (int?)reader["ReleasedByUserID"] : null;

                }
                else
                {
                    IsFound = false;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error " + ex.Message);

                IsFound = false;
            }
            finally
            {
                connection.Close();
            }
            return IsFound;

        }
        static public bool GetDetainLicenseInfoByDetainID(int DetainID, ref clsDetainLicenseData DetainLicenseData)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = @"select * from DetainedLicenses
                            where DetainID=@DetainID ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DetainID", DetainID);

            bool IsFound = true;
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    DetainLicenseData.DetainID = Convert.ToInt32(reader["DetainID"]);
                    DetainLicenseData.LicenseID = Convert.ToInt32(reader["LicenseID"]);
                    DetainLicenseData.DetainDate = Convert.ToDateTime(reader["DetainDate"]);
                    DetainLicenseData.FineFees = Convert.ToInt32(reader["FineFees"]);
                    DetainLicenseData.CreateByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    DetainLicenseData.IsReleased = Convert.ToInt32(reader["IsReleased"]);
                    DetainLicenseData.ReleasedDate = Convert.ToDateTime(reader["ReleaseDate"]);
                    DetainLicenseData.ReleasedAppID = Convert.ToInt32(reader["ReleaseApplicationID"]);
                    DetainLicenseData.ReleasedByUserID = Convert.ToInt32(reader["ReleasedByUserID"]);



                }
                else
                {
                    IsFound = false;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error " + ex.Message);

                IsFound = false;
            }
            finally
            {
                connection.Close();
            }
            return IsFound;

        }



    }
}
