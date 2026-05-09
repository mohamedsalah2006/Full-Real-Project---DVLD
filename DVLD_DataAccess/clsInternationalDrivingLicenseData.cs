using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsInternationalDrivingLicenseData
    {
        public string FullName { get; set; }
        public int InternationalLicenseID { get; set; }
        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public string NationalNo { get; set; }
        public DateTime IssueDate { get; set; }
        public int IsActive { get; set; }
        public DateTime ExpirationDateD { get; set; }
        public int DriverID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gendor { get; set; }
        public string ImagePath { get; set; }


        public static string ConnectionString = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

        static public bool GetInternationalDrivingLicense(int IssuedUsingLocalLicenseID, ref clsInternationalDrivingLicenseData DrivingLicense)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = @"
                            select FullName,InternationalLicenseID,ApplicationID,IssuedUsingLocalLicenseID,Drivers_View.NationalNo, IssueDate,IsActive,ExpirationDate,Drivers_View.DriverID,DateOfBirth,Gendor,ImagePath from InternationalLicenses  inner Join Drivers_View 
                            on InternationalLicenses.DriverID = Drivers_View.DriverID inner join People on People.PersonID = Drivers_View.PersonID 
                            where IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);

            bool IsFound = true;
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {


                    DrivingLicense.FullName = Convert.ToString(reader["FullName"]);
                    DrivingLicense.InternationalLicenseID = Convert.ToInt32(reader["InternationalLicenseID"]);
                    DrivingLicense.LicenseID = Convert.ToInt32(reader["IssuedUsingLocalLicenseID"]);
                    DrivingLicense.NationalNo = Convert.ToString(reader["NationalNo"]);
                    DrivingLicense.ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                    DrivingLicense.IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                    DrivingLicense.IsActive = Convert.ToInt32(reader["IsActive"]);
                    DrivingLicense.ExpirationDateD = Convert.ToDateTime(reader["ExpirationDate"]);
                    DrivingLicense.DriverID = Convert.ToInt32(reader["DriverID"]);
                    DrivingLicense.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    DrivingLicense.Gendor = Convert.ToInt32(reader["Gendor"]);
                    DrivingLicense.ImagePath = Convert.ToString(reader["ImagePath"]);



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
