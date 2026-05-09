using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsDriverLicenseData
    {


        public string FullName { get; set; }
        public string LicenseClassName { get; set; }
        public int PersonID { get; set; }
        public int LicenseID { get; set; }
        public string NationalNo { get; set; }
        public DateTime IssueDate { get; set; }
        public int IssueReason { get; set; }
        public string Notes { get; set; }
        public int IsActive { get; set; }
        public DateTime ExpirationDateD { get; set; }
        public int DriverID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gendor { get; set; }
        public string ImagePath { get; set; }


        public static string ConnectionString = "Server=.;Database=DVLD;User Id=sa;Password=123456;";
        static public bool GetDriverLicenseInfoBy_L_D_L_APP_ID(int LocalDrivingLicenseApplicationID, ref clsDriverLicenseData driverLicenseInfo)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = @"
                                select People.PersonID , FullName,LicenseClasses.ClassName,LicenseID,Drivers_View.NationalNo, IssueDate,IssueReason,Notes,IsActive,ExpirationDate,Drivers_View.DriverID,DateOfBirth,Gendor,ImagePath from 
                                Licenses  inner Join Drivers_View on Licenses.DriverID=Drivers_View.DriverID 
                                inner join People on People.PersonID = Drivers_View.PersonID 
                                inner join LicenseClasses on Licenses.LicenseClass= LicenseClasses.LicenseClassID
                                inner join LocalDrivingLicenseApplications on LocalDrivingLicenseApplications.ApplicationID = Licenses.ApplicationID
                                where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            bool IsFound = true;
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {


                    driverLicenseInfo.FullName = Convert.ToString( reader["FullName"]);
                    driverLicenseInfo.LicenseClassName = Convert.ToString( reader["ClassName"]);
                    driverLicenseInfo.PersonID = Convert.ToInt32( reader["PersonID"]);
                    driverLicenseInfo.LicenseID = Convert.ToInt32( reader["LicenseID"]);
                    driverLicenseInfo.NationalNo = Convert.ToString(reader["NationalNo"]);
                    driverLicenseInfo.IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                    driverLicenseInfo.IssueReason = Convert.ToInt32(reader["IssueReason"]);
                    driverLicenseInfo.Notes = Convert.ToString(reader["Notes"]);
                    driverLicenseInfo.IsActive = Convert.ToInt32(reader["IsActive"]);
                    driverLicenseInfo.ExpirationDateD = Convert.ToDateTime(reader["ExpirationDate"]);
                    driverLicenseInfo.DriverID = Convert.ToInt32(reader["DriverID"]);
                    driverLicenseInfo.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    driverLicenseInfo.Gendor = Convert.ToInt32(reader["Gendor"]);
                    driverLicenseInfo.ImagePath = Convert.ToString(reader["ImagePath"]);



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
        static public bool GetDriverLicenseInfo_LocalLicenseID(int LocalLicenseID, ref clsDriverLicenseData driverLicenseInfo)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = @"
                                select People.PersonID,FullName,LicenseClasses.ClassName,LicenseID,Drivers_View.NationalNo, IssueDate,IssueReason,Notes,IsActive,ExpirationDate,Drivers_View.DriverID,DateOfBirth,Gendor,ImagePath from Licenses  inner Join Drivers_View 
                                on Licenses.DriverID=Drivers_View.DriverID inner join People on People.PersonID = Drivers_View.PersonID inner join LicenseClasses on Licenses.LicenseClass= LicenseClasses.LicenseClassID
                                where LicenseID= @LocalLicenseID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalLicenseID", LocalLicenseID);

            bool IsFound = true;
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {


                    driverLicenseInfo.FullName = Convert.ToString(reader["FullName"]);
                    driverLicenseInfo.LicenseClassName = Convert.ToString(reader["ClassName"]);
                    driverLicenseInfo.LicenseID = Convert.ToInt32(reader["LicenseID"]);
                    driverLicenseInfo.PersonID = Convert.ToInt32(reader["PersonID"]);
                    driverLicenseInfo.NationalNo = Convert.ToString(reader["NationalNo"]);
                    driverLicenseInfo.IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                    driverLicenseInfo.IssueReason = Convert.ToInt32(reader["IssueReason"]);
                    driverLicenseInfo.Notes = Convert.ToString(reader["Notes"]);
                    driverLicenseInfo.IsActive = Convert.ToInt32(reader["IsActive"]);
                    driverLicenseInfo.ExpirationDateD = Convert.ToDateTime(reader["ExpirationDate"]);
                    driverLicenseInfo.DriverID = Convert.ToInt32(reader["DriverID"]);
                    driverLicenseInfo.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    driverLicenseInfo.Gendor = Convert.ToInt32(reader["Gendor"]);
                    driverLicenseInfo.ImagePath = Convert.ToString(reader["ImagePath"]);



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
