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


        public int LicenseClassID {  get; set; }
        public string LicenseClassName { get; set; }
        public string ClassDescription { get; set; }
        public int MinimumAllowedAge { get; set; }
        public int DefaultValidityLength { get; set; }
        public float ClassFees { get; set; }





        static public bool GetLicenseClassInfo(string LicenseClassName,ref clsLicenseClassesData LicenseClassInfo)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = @"""select * from LicenseClasses
                               where ClassName = @LicenseClassName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseClassName", LicenseClassName);

            bool IsFound = true;
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    LicenseClassInfo.LicenseClassID = (int)reader["LicenseClassID"];
                    LicenseClassInfo.LicenseClassName = (string)reader["ClassName"];
                    LicenseClassInfo.ClassDescription = (string)reader["ClassDescription"];
                    LicenseClassInfo.MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                    LicenseClassInfo.DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                    LicenseClassInfo.ClassFees = Convert.ToSingle(reader["ClassFees"]);
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
        static public bool GetLicenseClassInfo(int LicenseClassID, ref clsLicenseClassesData LicenseClassInfo)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = @"select * from LicenseClasses
                               where LicenseClassID = @LicenseClassID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            bool IsFound = true;
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    LicenseClassInfo.LicenseClassID = (int)reader["LicenseClassID"];
                    LicenseClassInfo.LicenseClassName = (string)reader["ClassName"];
                    LicenseClassInfo.ClassDescription = (string)reader["ClassDescription"];
                    LicenseClassInfo.MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                    LicenseClassInfo.DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                    LicenseClassInfo.ClassFees = Convert.ToSingle(reader["ClassFees"]);
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
