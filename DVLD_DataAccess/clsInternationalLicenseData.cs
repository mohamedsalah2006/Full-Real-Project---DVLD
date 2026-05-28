using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsInternationalLicenseData
    {
        public int InternationalLicenseID {  get; set; }
        public int ApplicationID {  get; set; }
        public int DriverID {  get; set; }
        public int IssuedUsingLocalLicenseID {  get; set; }
        public DateTime IssueDate {  get; set; }
        public DateTime ExpirationDate {  get; set; }
        public int IsActive {  get; set; }
        public int CreatedByUserID {  get; set; }


        public static string ConnectionString = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

        static public bool GetInternationalLicenseInfoByID(int InternationalLicenseID,ref clsInternationalLicenseData InterLicenseInfo)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(ConnectionString);

            string query = "SELECT * FROM InternationalLicenses WHERE InternationalLicenseID = @InternationalLicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    InterLicenseInfo.ApplicationID = (int)reader["ApplicationID"];
                    InterLicenseInfo.InternationalLicenseID = (int)reader["InternationalLicenseID"];
                    InterLicenseInfo.DriverID = (int)reader["DriverID"];
                    InterLicenseInfo.IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                    InterLicenseInfo.IssueDate = (DateTime)reader["IssueDate"];
                    InterLicenseInfo.ExpirationDate = (DateTime)reader["ExpirationDate"];
                    InterLicenseInfo.IsActive = Convert.ToInt32( reader["IsActive"]);
                    InterLicenseInfo.CreatedByUserID = (int)reader["DriverID"];


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
        //static public bool IsPersonHasInternationalLicense(int LocalLicenseID)
        //{
        //    SqlConnection connection = new SqlConnection(ConnectionString);
        //    string query = @"select IsFind=1 from InternationalLicenses inner join Licenses
        //                    on Licenses.DriverID = InternationalLicenses.DriverID
        //                    where LicenseID = @LicenseID";
        //    SqlCommand command = new SqlCommand(query, connection);

        //    command.Parameters.AddWithValue("@LicenseID", LocalLicenseID);

        //    bool IsFound = false;
        //    try
        //    {
        //        connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();

        //        IsFound = reader.HasRows;

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //    return IsFound;
        //}
        public int AddInternationalLicense()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = @"
                               Update InternationalLicenses 
                               set IsActive=0
                               where DriverID=@DriverID;

                             INSERT INTO InternationalLicenses
                               (
                                ApplicationID,
                                DriverID,
                                IssuedUsingLocalLicenseID,
                                IssueDate,
                                ExpirationDate,
                                IsActive,
                                CreatedByUserID)
                         VALUES
                               (@ApplicationID,
                                @DriverID,
                                @IssuedUsingLocalLicenseID,
                                @IssueDate,
                                @ExpirationDate,
                                @IsActive,
                                @CreatedByUserID);
                            SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID",this.ApplicationID);
            command.Parameters.AddWithValue("@DriverID",     this.DriverID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", this.IssuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@IssueDate", this.IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", this.ExpirationDate);
            command.Parameters.AddWithValue("@IsActive", this.IsActive);
            command.Parameters.AddWithValue("@CreatedByUserID", this.CreatedByUserID);
           


            int I_LicenseID = -1;

            try
            {


                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    I_LicenseID = InsertID;
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
            return I_LicenseID;
        }
        public bool UpdateInternationalLicense()
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(ConnectionString);

            string query = @"UPDATE InternationalLicenses
                           SET 
                              ApplicationID=@ApplicationID,
                              DriverID = @DriverID,
                              IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID,
                              IssueDate = @IssueDate,
                              ExpirationDate = @ExpirationDate,
                              IsActive = @IsActive,
                              CreatedByUserID = @CreatedByUserID
                         WHERE InternationalLicenseID=@InternationalLicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@InternationalLicenseID", this.InternationalLicenseID);
            command.Parameters.AddWithValue("@ApplicationID",this. ApplicationID);
            command.Parameters.AddWithValue("@DriverID", this.DriverID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID",this. IssuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@IssueDate", this.IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", this.ExpirationDate);

            command.Parameters.AddWithValue("@IsActive", this.IsActive);
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

        public static int GetActiveInternationalLicenseIDByDriverID(int DriverID)
        {
            int InternationalLicenseID = -1;

            SqlConnection connection = new SqlConnection(ConnectionString);

            string query = @"  
                            SELECT Top 1 InternationalLicenseID
                            FROM InternationalLicenses 
                            where DriverID=@DriverID and GetDate() between IssueDate and ExpirationDate 
                            order by ExpirationDate Desc;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    InternationalLicenseID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return InternationalLicenseID;
        }

        static public DataTable GetAllInternationalLicenseToPerson(int DriverID)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = @"
                             SELECT    InternationalLicenseID, ApplicationID,
		                     IssuedUsingLocalLicenseID , IssueDate, 
                             ExpirationDate, IsActive
		                     from InternationalLicenses where DriverID=@DriverID
                             order by ExpirationDate desc";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);

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
        static public DataTable GetAllInternationalLicense()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = @"select * from InternationalLicenses ";

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
    }
}
