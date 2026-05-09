using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsTestsTypesData
    {
        public static string ConnectionString = "Server=.;Database=DVLD;User Id=sa;Password=123456;";



        public int TestTypeID {  get; set; }
        public string TestTypeTitle {  get; set; }

        public string TestDescription {  get; set; }
        public float TestFees {  get; set; }

        static public DataTable GeTAllTestsTypes()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select * from TestTypes";
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
        public static bool GetTestTypeInfoByID(int TestTypeID,ref clsTestsTypesData TestType)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(ConnectionString);

            string query = "SELECT * FROM TestTypes WHERE TestTypeID = @TestTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true;

                    TestType.TestTypeID= (int)reader["TestTypeID"];
                    TestType.TestTypeTitle = (string)reader["TestTypeTitle"];
                    TestType.TestDescription = (string)reader["TestTypeDescription"];
                    TestType.TestFees = Convert.ToSingle(reader["TestTypeFees"]);

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
        static public bool EditTestsTypes(int id, string TestTypTitle, float Fees,string TestTypeDescription)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = @"update TestTypes set
                            TestTypeTitle=@TestTypTitle,
                            TestTypeFees=@Fees,
                            TestTypeDescription=@TestTypeDescription
                              where TestTypeID=@ID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", id);
            command.Parameters.AddWithValue("@TestTypTitle", TestTypTitle);
            command.Parameters.AddWithValue("@Fees", Fees);
            command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);


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
    }
}
