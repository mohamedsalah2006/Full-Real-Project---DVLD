using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DataAccessLayer
{
    
    public class clsApplicationsData
    {

        public int ApplicationID {  get; set; }
        public int PersonID {  get; set; }
        public DateTime ApplicationDate {  get; set; }
        public int ApplicationType {  get; set; }
        public int ApplicationStatus {  get; set; }
        public DateTime LastStatusDate {  get; set; }
        public int PaidFees {  get; set; }
        public int CreatedByUser {  get; set; }


        public static string ConnectionString = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

        static public DataTable GeTAllApplications()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select * from Applications";
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

        public  int  AddNewApplication()
        {
            SqlConnection connection = new SqlConnection (ConnectionString);
                 
            string query = @"
                            insert into Applications (ApplicantPersonID,ApplicationDate,ApplicationTypeID,ApplicationStatus,LastStatusDate,PaidFees,CreatedByUserID)
                              values(@ApplicantPersonID,@ApplicationDate,@ApplicationTypeID,@ApplicationStatus,@LastStatusDate,@PaidFees,@CreatedByUserID);
                            Select SCOPE_IDENTITY(); ";
            SqlCommand command = new SqlCommand (query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", this.PersonID);
            command.Parameters.AddWithValue("@ApplicationDate", this.ApplicationDate);
            command.Parameters.AddWithValue("@ApplicationTypeID", this.ApplicationType);
            command.Parameters.AddWithValue("@ApplicationStatus", this.ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", this.LastStatusDate);
            command.Parameters.AddWithValue("@PaidFees", this.PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", this.CreatedByUser);


            int _ApplicationID=-1;

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    _ApplicationID = InsertID;
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
            return _ApplicationID;

        }
        public  bool UpdateApplication(int AppID)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = @"update Applications set

                             ApplicantPersonID=@ApplicantPersonID,
                               ApplicationDate=@ApplicationDate,
                                ApplicationTypeID=@ApplicationTypeID,
                                 ApplicationStatus=@ApplicationStatus,
                                  LastStatusDate=@LastStatusDate,
                                   PaidFees=@PaidFees,
                                    CreatedByUserID=@CreatedByUserID 
                                        where ApplicationID=@ID";
            SqlCommand command=new SqlCommand (query, connection);

            command.Parameters.AddWithValue("@ID", AppID);
            command.Parameters.AddWithValue("@ApplicantPersonID", this.PersonID);
            command.Parameters.AddWithValue("@ApplicationDate", this.ApplicationDate);
            command.Parameters.AddWithValue("@ApplicationTypeID", this.ApplicationType);
            command.Parameters.AddWithValue("@ApplicationStatus", this.ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", this.LastStatusDate);
            command.Parameters.AddWithValue("@PaidFees", this.PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", this.CreatedByUser);


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
        public static bool DeleteApplication(int  ApplicationID)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = @"delete from Applications
                             where ApplicationID = @id"; ;
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", ApplicationID);


            int RowsAffected = 0;


            try
            {
                connection.Open();
                RowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
            return (RowsAffected > 0);

        }
        public static bool GetApplicationInfoByID(int ApplicationID, ref clsApplicationsData AppInfo)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = @"select * from Applications 
                                where ApplicationID=@id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", ApplicationID);

            bool IsFound = true;
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    AppInfo.ApplicationDate = Convert.ToDateTime(reader["ApplicationDate"]);
                    AppInfo.ApplicationStatus = Convert.ToInt32( reader["ApplicationStatus"]);
                    AppInfo.ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                    AppInfo.ApplicationType = Convert.ToInt32( reader["ApplicationTypeID"]);
                    AppInfo.PaidFees = Convert.ToInt32(reader["PaidFees"]);
                    AppInfo.PersonID = Convert.ToInt32(reader["ApplicantPersonID"]);
                    AppInfo.CreatedByUser = Convert.ToInt32(reader["CreatedByUserID"]);
                    AppInfo.LastStatusDate = Convert.ToDateTime( reader["LastStatusDate"]);
                   

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

        public static bool IsApplicationExist(int AppID)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = @"select ISFound=1 from Applications
                                where ApplicationID= @ApplicationID";
            SqlCommand command=new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", AppID);

            bool IsFound = false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                IsFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
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
