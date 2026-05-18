using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsDriverData
    {
        public int DriverID { set; get; }
        public int PersonID { set; get; }
        public int CreatedByUserID { set; get; }
        public DateTime CreatedDate { get; set; }


        public static string ConnectionString = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

        public static bool GetDriverInfoByDriverID(int DriverID,ref clsDriverData DriverInfo)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(ConnectionString);

            string query = "SELECT * FROM Drivers WHERE DriverID = @DriverID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    DriverInfo.DriverID = (int)reader["DriverID"];
                    DriverInfo.CreatedByUserID = (int)reader["CreatedByUserID"];
                    DriverInfo.CreatedDate = (DateTime)reader["CreatedDate"];


                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        public static bool GetDriverInfoByPersonID(int PersonID,ref clsDriverData DriverInfo)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(ConnectionString);

            string query = "SELECT * FROM Drivers WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    DriverInfo.DriverID = (int)reader["DriverID"];
                    DriverInfo.CreatedByUserID = (int)reader["CreatedByUserID"];
                    DriverInfo.CreatedDate = (DateTime)reader["CreatedDate"];

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        static public DataTable GetAllDrivers()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select * from Drivers_View";
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
        public int AddDriver()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = @"
                            insert into Drivers (PersonID,CreatedDate,CreatedByUserID)
                            values(@PersonID,@CreatedDate,@CreatedByUserID);
                            Select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", this.PersonID);
            command.Parameters.AddWithValue("@CreatedDate", this.CreatedDate);
            command.Parameters.AddWithValue("@CreatedByUserID", this.CreatedByUserID);

            

            try
            {


                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    this.DriverID = InsertID;
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
            return this.DriverID;

        }
        public bool UpdateDriver()
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = @"Update  Drivers  
                            set PersonID = @PersonID,
                                CreatedByUserID = @CreatedByUserID
                                where DriverID = @DriverID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", this.DriverID);
            command.Parameters.AddWithValue("@PersonID", this.PersonID);
            command.Parameters.AddWithValue("@CreatedByUserID", this.CreatedByUserID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

    }
}
