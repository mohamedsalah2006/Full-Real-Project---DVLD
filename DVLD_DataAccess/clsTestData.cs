using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{

   
    public class clsTestData
    {
        


        public static string ConnectionString = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

        static public int TakeTest(int TestAppointmentID, int TestResult, string Notes, int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = @"Insert into Tests(TestAppointmentID,TestResult,Notes,CreatedByUserID)
                            values(@TestAppointmentID,@TestResult,@Notes,@CreatedByUserID)
                            Select SCOPE_IDENTITY();

                            update TestAppointments set
                            IsLocked = 1
                            where TestAppointmentID = @TestAppointmentID";


            
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            command.Parameters.AddWithValue("@Notes", Notes);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            int test_ID = -1;

            try
            {


                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    test_ID = InsertID;
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
            return test_ID;



        }
        static public bool DidThePersonPassInThisTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            

            string query = @"
                                    select IsPassed = 1 from
                                    LocalDrivingLicenseApplications inner join TestAppointments 
                                    on LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
                                    inner join Tests
                                    on Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                                    Where (Tests.TestResult=1) and (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID)
                                     AND(TestAppointments.TestTypeID = @TestTypeID)
                                    ORDER BY TestAppointments.TestAppointmentID desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
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
        static public int GetPassedTestCount(int LocalDrivingLicenseAppID)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            string query = @"
                            select PassedTestCount =COUNT(TestAppointments.TestAppointmentID) from
                            TestAppointments inner join Tests 
                            on TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            where TestAppointments.LocalDrivingLicenseApplicationID =@LocalDrivingLicenseAppID  and Tests.TestResult=1";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseAppID", LocalDrivingLicenseAppID);

            int PassedTestCount = 0;

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && byte.TryParse(result.ToString(), out byte ptCount))
                {
                    PassedTestCount = ptCount;
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

            return PassedTestCount;

        }

    }
}
