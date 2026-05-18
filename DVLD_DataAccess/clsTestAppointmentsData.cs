using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsTestAppointmentsData
    {

        public int TestAppointmentID {  get; set; }
        public int TestTypeID {  get; set; }
        public int LocalDrivingLicenseID {  get; set; }
        public DateTime AppointmentDate {  get; set; }
        public float PaidFees {  get; set; }
        public int CreatedByUserID {  get; set; }
        public int IsLocked {  get; set; }
        public int RetakeTestApplicationID { get; set; }

        public static string ConnectionString = "Server=.;Database=DVLD;User Id=sa;Password=123456;";


        static public DataTable GetTestAppointmentsByTestTypeID(int Local_License, int TestTypeID)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = @"select TestAppointmentID,AppointmentDate,PaidFees,IsLocked from TestAppointments
                            where LocalDrivingLicenseApplicationID=@Local_License and TestTypeID=@TestTypeID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Local_License", Local_License);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
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
        static public bool GetTestAppointmentByID(int TestAppointmentID,ref clsTestAppointmentsData TestAppointment)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = @"select * from TestAppointments
                            where TestAppointmentID = @TestAppointmentID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            bool IsFound = false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
                {
                    IsFound = true;

                    TestAppointment.TestTypeID = Convert.ToInt32(reader["TestTypeID"]);
                    TestAppointment.PaidFees = Convert.ToInt32(reader["PaidFees"]);
                    TestAppointment.IsLocked = Convert.ToInt32(reader["IsLocked"]);
                    TestAppointment.AppointmentDate = (DateTime)reader["AppointmentDate"];
                    TestAppointment.LocalDrivingLicenseID = Convert.ToInt32(reader["LocalDrivingLicenseApplicationID"]);
                    TestAppointment.CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);

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
            return IsFound;

        }
        static public int AddNewTestAppointment(clsTestAppointmentsData TestData)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = @"
                            insert into TestAppointments(TestTypeID,LocalDrivingLicenseApplicationID,AppointmentDate,PaidFees,CreatedByUserID,IsLocked)
                            values(@TestTypeID,@LocalDrivingLicenseApplicationID,@AppointmentDate,@PaidFees,@CreatedByUserID,@IsLocked);
                            Select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query,connection);

            command.Parameters.AddWithValue("@TestTypeID", TestData.TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", TestData.LocalDrivingLicenseID);
            command.Parameters.AddWithValue("@AppointmentDate", TestData.AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", TestData.PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", TestData.CreatedByUserID);
            command.Parameters.AddWithValue("@IsLocked", TestData.IsLocked);



            int TestAppointmentID = -1;

            try
            {


                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    TestAppointmentID = InsertID;
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
            return TestAppointmentID;
        }
        static public bool UpdateTestAppointment(int TestAppointmentID, clsTestAppointmentsData TestAppointmentInfo)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = @"Update  TestAppointments  
                            set TestTypeID = @TestTypeID,
                                LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID,
                                AppointmentDate = @AppointmentDate,
                                PaidFees = @PaidFees,
                                CreatedByUserID = @CreatedByUserID,
                                IsLocked=@IsLocked,
                                RetakeTestApplicationID=@RetakeTestApplicationID
                                where TestAppointmentID = @TestAppointmentID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestTypeID", TestAppointmentInfo.TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", TestAppointmentInfo.LocalDrivingLicenseID);
            command.Parameters.AddWithValue("@AppointmentDate", TestAppointmentInfo.AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", TestAppointmentInfo.PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", TestAppointmentInfo.CreatedByUserID);
            command.Parameters.AddWithValue("@IsLocked", TestAppointmentInfo.IsLocked);

            if (TestAppointmentInfo.RetakeTestApplicationID == -1)

                command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);
            else
                command.Parameters.AddWithValue("@RetakeTestApplicationID", TestAppointmentInfo.RetakeTestApplicationID);



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

        static public bool IsPersonHasActiveTestAppointment(int LocalDrivingLicenseID,int TestTypeID)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = @"
                            select IsFound=1 from TestAppointments
                           WHERE        (TestTypeID = @TestTypeID) 
                AND (LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                AND(IsLocked = 0)
                order by TestAppointmentID Desc";

            SqlCommand command = new SqlCommand(@query,connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


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
        public static bool GetLastTestAppointment(
            int LocalDrivingLicenseApplicationID, int TestTypeID,ref clsTestAppointmentsData TestAppointmentInfo)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(ConnectionString);

            string query = @"SELECT       top 1 *
                FROM            TestAppointments
                WHERE        (TestTypeID = @TestTypeID) 
                AND (LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                order by TestAppointmentID Desc";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    TestAppointmentInfo.TestAppointmentID = (int)reader["TestAppointmentID"];
                    TestAppointmentInfo.AppointmentDate = (DateTime)reader["AppointmentDate"];
                    TestAppointmentInfo.PaidFees = Convert.ToSingle(reader["PaidFees"]);
                    TestAppointmentInfo.CreatedByUserID = (int)reader["CreatedByUserID"];
                    TestAppointmentInfo.IsLocked = (int)reader["IsLocked"];

                    if (reader["RetakeTestApplicationID"] == DBNull.Value)
                        TestAppointmentInfo.RetakeTestApplicationID = -1;
                    else
                        TestAppointmentInfo.RetakeTestApplicationID = (int)reader["RetakeTestApplicationID"];


                }
                else
                {
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }


        public static int GetTestID(int TestAppointmentID)
        {
            int TestID = -1;
            SqlConnection connection = new SqlConnection(ConnectionString);

            string query = @"select TestID from Tests where TestAppointmentID=@TestAppointmentID;";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    TestID = insertedID;
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


            return TestID;

        }

    }
}
