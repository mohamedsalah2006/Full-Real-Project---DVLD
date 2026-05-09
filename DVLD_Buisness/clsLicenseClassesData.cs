using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsLicenseClassesData
    {
        public static string ConnectionString = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

        static public DataTable GetAllLicenseClasses()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select * from LicenseClasses order by LicenseClassID";
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

        static public int GetValidityLength(int LicenseClassID)
        {
            string query = @"select DefaultValidityLength from LicenseClasses
                               where LicenseClassID = @LicenseClassID";
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue(@"LicenseClassID", LicenseClassID);
            int Length = -1;

            try
            {


                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    Length = InsertID;
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
            return Length;
        }
        static public int GetClassFees(int LicenseClassID)
        {
            string query = @"select ClassFees from LicenseClasses
                               where LicenseClassID = @LicenseClassID";
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue(@"LicenseClassID", LicenseClassID);
            int Length = -1;

            try
            {


                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    Length = InsertID;
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
            return Length;
        }


        static public int GetValidityLength(string LicenseClassName)
        {
            string query = @"select DefaultValidityLength from LicenseClasses
                               where ClassName = @LicenseClassName";
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue(@"LicenseClassName", LicenseClassName);
            int Length = -1;

            try
            {


                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    Length = InsertID;
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
            return Length;
        }
        static public int GetClassFees(string LicenseClassName)
        {
            string query = @"select ClassFees from LicenseClasses
                               where ClassName = @LicenseClassName";
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@LicenseClassName", LicenseClassName);
            int ClassFees = -1;

            try
            {


                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    ClassFees = Convert.ToInt32(result);
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
            return ClassFees;
        }

    }
}
