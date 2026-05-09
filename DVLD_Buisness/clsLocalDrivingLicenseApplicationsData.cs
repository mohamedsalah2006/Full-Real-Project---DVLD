using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsLocalDrivingLicenseAppData_View
    {
        public static string ConnectionString = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

        

        public int LD_LicenseID;
        public string ClassName;
        public string NationalNo;
        public string FullName;
        public DateTime ApplicationDate;
        public int PassedTestCount;
        public string Status;







        public static bool FindLocalLicenseApp_View(int id, ref clsLocalDrivingLicenseAppData_View AppInfo)
        {


            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = @"select * from LocalDrivingLicenseApplications_View 
                         where LocalDrivingLicenseApplicationID=@id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);

            bool IsFound = true;
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    
                    
                    AppInfo.LD_LicenseID = Convert.ToInt32(reader["LocalDrivingLicenseApplicationID"]);
                    AppInfo.ApplicationDate = (DateTime)reader["ApplicationDate"];
                    AppInfo.FullName = (string)reader["FullName"];
                    AppInfo.ClassName = (string)reader["ClassName"];
                    AppInfo.NationalNo = (string)reader["NationalNo"];
                    AppInfo.PassedTestCount = Convert.ToInt32( reader["PassedTestCount"]);
                    AppInfo.Status = (string)reader["Status"];



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
    public  class clsLocalDrivingLicenseApplicationsData
    {

        public int LocalDrivingLicenseApplicationID {  get; set; }
        public int ApplicationID { get; set; }
        public int LicenseClassID { get; set; }

        public static string ConnectionString = "Server=.;Database=DVLD;User Id=sa;Password=123456;";
        static public DataTable GetAllLocalLicense()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select * from LocalDrivingLicenseApplications_View";
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
        static public int AddNewLocalDrivingLicenseApplications(int ApplicationID,int ClassID)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = @"insert into LocalDrivingLicenseApplications (ApplicationID,LicenseClassID)
                            values(@ApplicationID,@ClassID)
                            Select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@ClassID", ClassID);

            int LocalAppID = -1;

            try
            {


                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    LocalAppID = InsertID;
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
            return LocalAppID;
        }
        static public bool IsApplicationWright(int Status,int ClassLicense,int PersonID)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = @"  
                            Select Found=1 from 
                            (
                            select Applications.ApplicantPersonID , Applications.ApplicationStatus,LocalDrivingLicenseApplications.LicenseClassID from
                            Applications inner join LocalDrivingLicenseApplications
                            on LocalDrivingLicenseApplications.ApplicationID=Applications.ApplicationID
                            where (Applications.ApplicantPersonID=@ApplicantPersonID and Applications.ApplicationStatus=@ApplicationStatus and LocalDrivingLicenseApplications.LicenseClassID=@LicenseClassID )
                            )R1";
            SqlCommand command = new SqlCommand(query,connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", PersonID);
            command.Parameters.AddWithValue("@ApplicationStatus", Status);
            command.Parameters.AddWithValue("@LicenseClassID", ClassLicense);



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
        public static bool FindLocalLicenseApp(int LocalDrivingLicenseApplicationID, ref clsLocalDrivingLicenseApplicationsData AppInfo)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = @"select * from LocalDrivingLicenseApplications 
                                where LocalDrivingLicenseApplicationID=@id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", LocalDrivingLicenseApplicationID);

            bool IsFound = true;
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    AppInfo.ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                    AppInfo.LocalDrivingLicenseApplicationID = Convert.ToInt32(reader["LocalDrivingLicenseApplicationID"]);
                    AppInfo.LicenseClassID = Convert.ToInt32(reader["LicenseClassID"]);
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
        public static DataTable GetPersonLocalLicense(string NationalNo)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = @"
                            select LicenseID,ApplicationID,ClassName,IssueDate,ExpirationDate,IsActive from Licenses inner join LicenseClasses
                            on LicenseClasses.LicenseClassID=LicenseClass inner join Drivers_View on Drivers_View.DriverID=Licenses.DriverID
                            where NationalNo = @NationalNo";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);

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
        public static bool DeleteLocalDrivingLicenseApplications(int L_D_L_ID )
        {
            SqlConnection connection= new SqlConnection(ConnectionString);
            string query = @"
                              delete  from TestAppointments 
                              where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                              delete from LocalDrivingLicenseApplications
                              where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", L_D_L_ID);


            int rowsAffected = 0;
            try
            {

                connection.Open();

                 rowsAffected = command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error " + ex.Message);

                
            }
            finally
            {
                connection.Close();
            }

            return rowsAffected != 0;
        }
    }


}
