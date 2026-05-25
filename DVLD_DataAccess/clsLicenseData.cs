using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{

 
    public class clsLicenseData
    {
        public int LicenseID {  get; set; }
        public int ApplicationID {  get; set; }
        public int DriverID {  get; set; }
        public int LicenseClass {  get; set; }
        public DateTime IssueDate {  get; set; }
        public DateTime ExpirationDate {  get; set; }
        public string Notes {  get; set; }
        public float PaidFees {  get; set; }
        public int IsActive {  get; set; }
        public int IssueReason {  get; set; }
        public int CreatedByUserID {  get; set; }
       



        public static string ConnectionString = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

        public bool UpdateLicense()
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(ConnectionString);

            string query = @"UPDATE Licenses
                           SET ApplicationID=@ApplicationID, DriverID = @DriverID,
                              LicenseClass = @LicenseClass,
                              IssueDate = @IssueDate,
                              ExpirationDate = @ExpirationDate,
                              Notes = @Notes,
                              PaidFees = @PaidFees,
                              IsActive = @IsActive,IssueReason=@IssueReason,
                              CreatedByUserID = @CreatedByUserID
                         WHERE LicenseID=@LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);

            if (Notes == "")
                command.Parameters.AddWithValue("@Notes", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Notes", Notes);

            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

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
        static public int AddNewLicense(clsLicenseData licenseData)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = @"insert into Licenses(ApplicationID,DriverID,LicenseClass,IssueDate,ExpirationDate,Notes,PaidFees,IsActive,IssueReason,CreatedByUserID)
                          values(@ApplicationID,@DriverID,@LicenseClass,@IssueDate,@ExpirationDate,@Notes,@PaidFees,@IsActive,@IssueReason,@CreatedByUserID)
                              update Applications
                              set ApplicationStatus = 3
                              where ApplicationID = @ApplicationID;
                            Select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", licenseData.ApplicationID);
            command.Parameters.AddWithValue("@DriverID", licenseData.DriverID);
            command.Parameters.AddWithValue("@LicenseClass", licenseData.LicenseClass);
            command.Parameters.AddWithValue("@IssueDate", licenseData.IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", licenseData.ExpirationDate);
            command.Parameters.AddWithValue("@Notes", licenseData.Notes);
            command.Parameters.AddWithValue("@PaidFees", licenseData.PaidFees);
            command.Parameters.AddWithValue("@IsActive", licenseData.IsActive);
            command.Parameters.AddWithValue("@IssueReason", licenseData.IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", licenseData.CreatedByUserID);

            int _LicenseID = -1;

            try
            {


                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    _LicenseID = InsertID;
                    licenseData.LicenseID= _LicenseID;
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
            return _LicenseID;

        }
        static public bool IsTheLicenseExpired(int LicenseID)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = @"select IsFound = 1 from Licenses
                            where LicenseID = @LicenseID and ExpirationDate < GETDATE()"; 
            
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
        static public bool IsTheLicenseActive(int LicenseID)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = @"select IsFound = 1 from Licenses
                            where LicenseID = @LicenseID and IsActive = 1";

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
        static public bool GetLicenseInfo(int LicenseID,ref clsLicenseData LicenseInfo)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = @"select * from Licenses
                            where LicenseID = @LicenseID";
            SqlCommand command = new SqlCommand(@query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            bool IsFound = true;
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    LicenseInfo.LicenseID = Convert.ToInt32(reader["LicenseID"]);
                    LicenseInfo.ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                    LicenseInfo.DriverID = Convert.ToInt32(reader["DriverID"]);
                    LicenseInfo.LicenseClass = Convert.ToInt32(reader["LicenseClass"]);
                    LicenseInfo.IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                    LicenseInfo.ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]);
                    LicenseInfo.Notes = Convert.ToString(reader["Notes"]);
                    LicenseInfo.PaidFees = Convert.ToInt32(reader["PaidFees"]);
                    LicenseInfo.IsActive = Convert.ToInt32(reader["IsActive"]);
                    LicenseInfo.IssueReason = Convert.ToInt32(reader["IssueReason"]);
                    LicenseInfo.CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);

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
        static public bool DeactivateLicense(int LicenseID)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = @"update Licenses set IsActive = 0
                                    where LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

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
        static public int GetActiveLicenseIDByPersonID(int PersonID,int LicenseClassID)
        {
            int LicenseID = -1;

            SqlConnection connection = new SqlConnection(ConnectionString);

            string query = @"SELECT        Licenses.LicenseID
                            FROM Licenses INNER JOIN
                                                     Drivers ON Licenses.DriverID = Drivers.DriverID
                            WHERE  
                             
                             Licenses.LicenseClass = @LicenseClass 
                              AND Drivers.PersonID = @PersonID
                              And IsActive=1;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClassID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    LicenseID = insertedID;
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


            return LicenseID;
        }
        public static DataTable GetPersonLocalLicense(int DriverID)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = @"SELECT     
                           Licenses.LicenseID,
                           ApplicationID,
		                   LicenseClasses.ClassName, Licenses.IssueDate, 
		                   Licenses.ExpirationDate, Licenses.IsActive
                           FROM Licenses INNER JOIN
                                LicenseClasses ON Licenses.LicenseClass = LicenseClasses.LicenseClassID
                            where DriverID=@DriverID
                            Order By IsActive Desc, ExpirationDate Desc";
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





    }
}
