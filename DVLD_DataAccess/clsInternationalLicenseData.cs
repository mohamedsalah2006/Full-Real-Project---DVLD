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
        public int ApplicationID {  get; set; }
        public int DriverID {  get; set; }
        public int IssuedUsingLocalLicenseID {  get; set; }
        public DateTime IssueDate {  get; set; }
        public DateTime ExpirationDate {  get; set; }
        public int IsActive {  get; set; }
        public int CreatedByUserID {  get; set; }


        public static string ConnectionString = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

        static public bool IsPersonHasInternationalLicense(int LocalLicenseID)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = @"select IsFind=1 from InternationalLicenses inner join Licenses
                            on Licenses.DriverID = InternationalLicenses.DriverID
                            where LicenseID = @LicenseID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LocalLicenseID);

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
        static public int InsertInternationalLicense(clsInternationalLicenseData LicenseData)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = @"insert into InternationalLicenses(ApplicationID,DriverID,IssuedUsingLocalLicenseID,IssueDate,ExpirationDate,IsActive,CreatedByUserID)
                                                        values(@ApplicationID,@DriverID,@IssuedUsingLocalLicenseID,@IssueDate,@ExpirationDate,@IsActive,@CreatedByUserID);
                                                        Select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", LicenseData.ApplicationID);
            command.Parameters.AddWithValue("@DriverID",     LicenseData.DriverID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", LicenseData.IssuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@IssueDate", LicenseData.IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", LicenseData.ExpirationDate);
            command.Parameters.AddWithValue("@IsActive", LicenseData.IsActive);
            command.Parameters.AddWithValue("@CreatedByUserID", LicenseData.CreatedByUserID);
           


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
