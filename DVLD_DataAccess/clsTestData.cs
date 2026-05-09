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
        static public bool IsPassed(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            

            string query = @"SELECT IsFound = 1
                           FROM Tests T
                           JOIN TestAppointments A 
                               ON T.TestAppointmentID = A.TestAppointmentID
                           WHERE A.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                           AND A.TestTypeID = @TestTypeID
                           AND T.TestResult = 1";
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

    }
}
