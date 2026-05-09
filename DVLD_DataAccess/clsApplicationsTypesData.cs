using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsApplicationsTypesData
    {
        public int ID { set; get; }
        public string Title { set; get; }
        public int Fees { set; get; }


        public static string ConnectionString = "Server=.;Database=DVLD;User Id=sa;Password=123456;";
        static public DataTable GeT_All_Applications_Types()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select * from ApplicationTypes";
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
        static public bool EditApplicationsTypes(int id,string ApplicationTypTitle,int ApplicationFees)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = @"update ApplicationTypes set
                            ApplicationTypeTitle=@ApplicationTypTitle,
                            ApplicationFees=@ApplicationFees
                              where ApplicationTypeID=@ID";
            SqlCommand command = new SqlCommand(query,connection);

            command.Parameters.AddWithValue("ID", id);
            command.Parameters.AddWithValue("ApplicationTypTitle", ApplicationTypTitle);
            command.Parameters.AddWithValue("ApplicationFees", ApplicationFees);

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
        static public bool GetApplicationTypeInfoByID(int id,ref clsApplicationsTypesData ApplicationsTypeInfo)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = @"select * from ApplicationTypes
                              where ApplicationTypeID =@ID
                              ";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", id);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    ApplicationsTypeInfo.ID = Convert.ToInt32(reader["ApplicationTypeID"]);
                    ApplicationsTypeInfo.Fees = Convert.ToInt32(reader["ApplicationFees"]);
                    ApplicationsTypeInfo.Title = Convert.ToString(reader["ApplicationTypeTitle"]);

                    return true;
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
            return false;
        }
        public static int AddNewApplicationType(string Title, float Fees)
        {
            int ApplicationTypeID = -1;

            SqlConnection connection = new SqlConnection(ConnectionString);

            string query = @"Insert Into ApplicationTypes (ApplicationTypeTitle,ApplicationFees)
                            Values (@Title,@Fees)
                            
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationTypeTitle", Title);
            command.Parameters.AddWithValue("@ApplicationFees", Fees);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ApplicationTypeID = insertedID;
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


            return ApplicationTypeID;

        }

    }
}
