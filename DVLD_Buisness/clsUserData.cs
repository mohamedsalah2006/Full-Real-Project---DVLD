using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
   
    public class clsUserData
    {

        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int PersonID { get; set; }
        public bool IsActive { get; set; }

        public static string ConnectionString = "Server=.;Database=DVLD;User Id=sa;Password=123456;";


        public static DataTable GetAllUsers()
        {

            
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = @"select UserID,People.PersonID,FullName=People.FirstName+' '+People.SecondName+' '+People.ThirdName+' '+People.LastName,UserName,IsActive from Users 
                           inner join People on People.PersonID = Users.PersonID";
            SqlCommand command = new SqlCommand(query, connection);

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
        public  int AddNewUser()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = @"
                             Insert into Users (PersonID,UserName,Password,IsActive)
                             Values(@PersonID,@UserName,@Password,@IsActive);
                                Select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", this.UserName);
            command.Parameters.AddWithValue("@Password", this.Password);
            command.Parameters.AddWithValue("@IsActive", this.IsActive);
            command.Parameters.AddWithValue("@PersonID", this.PersonID);

            int user_id = -1;

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    user_id = InsertID;
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
            return user_id;
        }
        public bool UpdateUser(int UserID)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            string query = @"update Users set
                            UserName=@UserName,
                            Password=@Password,
                            IsActive=@IsActive

                            where UserID=@UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", this.UserName);
            command.Parameters.AddWithValue("@Password", this.Password);
            command.Parameters.AddWithValue("@IsActive", this.IsActive);

            command.Parameters.AddWithValue("@UserID", UserID);

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

        public static bool GetUserByUserID(ref clsUserData user,int UserID)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select * from Users where UserID=@ID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", UserID);

            bool IsFound = true;
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    user.UserID = Convert.ToInt32(reader["UserID"]);
                    user.UserName = (string)reader["UserName"];
                    user.Password = (string)reader["Password"];
                    user.PersonID = (int)reader["PersonID"];
                    user.IsActive = (bool)reader["IsActive"];
                    
                    

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
        public static bool GetUserByPersonID(ref clsUserData user, int PersonID)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "SELECT * FROM Users WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            bool IsFound = true;
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    user.UserID = Convert.ToInt32(reader["UserID"]);
                    user.UserName = (string)reader["UserName"];
                    user.Password = (string)reader["Password"];
                    user.PersonID = (int)reader["PersonID"];
                    user.IsActive = (bool)reader["IsActive"];



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
        public static bool GetUserInfoByUsernameAndPassword(ref clsUserData user, string UserName, string Password)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "SELECT * FROM Users WHERE Username = @Username and Password=@Password;";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Username", UserName);
            command.Parameters.AddWithValue("@Password", Password);

            bool IsFound = true;
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    user.UserID = Convert.ToInt32(reader["UserID"]);
                    user.UserName = (string)reader["UserName"];
                    user.Password = (string)reader["Password"];
                    user.PersonID = (int)reader["PersonID"];
                    user.IsActive = (bool)reader["IsActive"];



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

        public static bool DeleteUser(int UserID)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = @"delete from Users
                             where UserID = @id"; ;
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", UserID);


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
       
        public static bool ISPersonIsUser(int ID)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "Select Found=1 from Users where PersonID=@ID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);

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
        public static bool IsUserExist(int UserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(ConnectionString);

            string query = "SELECT Found=1 FROM Users WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

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
        public static bool IsUserExist(string UserName)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(ConnectionString);

            string query = "SELECT Found=1 FROM Users WHERE UserName = @UserName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

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

    }
}
