using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
   
    public class clsPeopleData
    {
        public int PersonID {  get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gendor { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; }


        public static string ConnectionString = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

        
        public static DataTable GetAllPeople()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(ConnectionString);
            string query =
              @"SELECT People.PersonID, People.NationalNo,
              People.FirstName, People.SecondName, People.ThirdName, People.LastName,
			  People.DateOfBirth, People.Gendor,  
				  CASE
                  WHEN People.Gendor = 0 THEN 'Male'

                  ELSE 'Female'

                  END as GendorCaption ,
			  People.Address, People.Phone, People.Email, 
              People.NationalityCountryID, Countries.CountryName, People.ImagePath
              FROM            People INNER JOIN
                         Countries ON People.NationalityCountryID = Countries.CountryID
                ORDER BY People.PersonID";

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
        public  int AddNewPeople()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = @"
                             Insert into People (NationalNo,FirstName,SecondName,ThirdName,LastName,DateOfBirth,Gendor,Address,Phone,Email,NationalityCountryID,ImagePath)
                             Values(@NationalNo,@FirstName,@SecondName,@ThirdName,@LastName,@DateOfBirth,@Gendor,@Address,@Phone,@Email,@NationalityCountryID,@ImagePath);
                                Select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@NationalNo", this.NationalNo);
            command.Parameters.AddWithValue("@FirstName", this.FirstName);
            command.Parameters.AddWithValue("@SecondName", this.SecondName);
            command.Parameters.AddWithValue("@ThirdName", this.ThirdName);
            command.Parameters.AddWithValue("@LastName", this.LastName);
            command.Parameters.AddWithValue("@DateOfBirth", this.DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", this.Gendor);
            command.Parameters.AddWithValue("@Address", this.Address);
            command.Parameters.AddWithValue("@Phone", this.Phone);
            command.Parameters.AddWithValue("@Email", this.Email);
            command.Parameters.AddWithValue("@NationalityCountryID", this.NationalityCountryID);
            command.Parameters.AddWithValue("@ImagePath", this.ImagePath);

            int people_id = -1;

            try
            {


                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    people_id = InsertID;
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
            return people_id;
        }
        public static bool DeletePeople(int ID)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query= @"delete from People
                             where PersonID = @id"; ;
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", ID);


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
        public static bool UpdatePerson(int ID,clsPeopleData people)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            string query= @"update People set
                            FirstName=@FirstName,
                            SecondName=@SecondName,
                            ThirdName=@ThirdName,
                            LastName=@LastName,
                            Email=@Email,
                            NationalNo=@NationalNo,
                            Phone=@Phone,
                            Address=@Address,
                            Gendor=@Gendor,
                            DateOfBirth=@DateOfBirth,
                            NationalityCountryID=@NationalityCountryID,
                            ImagePath=@ImagePath
                            
                            where PersonID=@ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", people.NationalNo);
            command.Parameters.AddWithValue("@FirstName", people.FirstName);
            command.Parameters.AddWithValue("@SecondName", people.SecondName);
            command.Parameters.AddWithValue("@ThirdName", people.ThirdName);
            command.Parameters.AddWithValue("@LastName", people.LastName);
            command.Parameters.AddWithValue("@DateOfBirth", people.DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", people.Gendor);
            command.Parameters.AddWithValue("@Address", people.Address);
            command.Parameters.AddWithValue("@Phone", people.Phone);
            command.Parameters.AddWithValue("@Email", people.Email);
            command.Parameters.AddWithValue("@NationalityCountryID", people.NationalityCountryID);
            command.Parameters.AddWithValue("@ImagePath", people.ImagePath);
            command.Parameters.AddWithValue("@ID",ID);

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
        public static bool IsPersonExist(int ID)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "Select Found=1 from People where PersonID=@ID";
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
        public static bool IsPersonExist(string NationalNo)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "Select Found=1 from People where NationalNo=@NationalNo";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);

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

        public static bool FindPeopleByID(int ID, ref clsPeopleData people)
        {
            string query = "select * from People where PersonID=@ID";
            SqlConnection connection = new SqlConnection(ConnectionString);
            // string query = "select * from People where PersonID=@id";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);
            bool IsFound = true;
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    people.PersonID = Convert.ToInt32(reader["PersonID"]);
                    people.NationalNo = Convert.ToString(reader["NationalNo"]);
                    people.FirstName = Convert.ToString(reader["FirstName"]);
                    people.SecondName = Convert.ToString(reader["SecondName"]);
                    people.ThirdName = Convert.ToString(reader["ThirdName"]);
                    people.LastName = Convert.ToString(reader["LastName"]);
                    people.Phone = Convert.ToString(reader["Phone"]);
                    people.Email = Convert.ToString(reader["Email"]);
                    people.Address = Convert.ToString(reader["Address"]);
                    people.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    people.ImagePath = Convert.ToString(reader["ImagePath"]);
                    people.NationalityCountryID = Convert.ToInt32(reader["NationalityCountryID"]);
                    people.Gendor = Convert.ToInt32(reader["Gendor"]);
                     

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
        public static bool FindPeopleByNationalNo(string NationalNo, ref clsPeopleData people)
        {
            string query = "select * from People where NationalNo=@NationalNo";
            SqlConnection connection = new SqlConnection(ConnectionString);
            // string query = "select * from People where PersonID=@id";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            bool IsFound = true;
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    people.PersonID = Convert.ToInt32(reader["PersonID"]);
                    people.NationalNo = Convert.ToString(reader["NationalNo"]);
                    people.FirstName = Convert.ToString(reader["FirstName"]);
                    people.SecondName = Convert.ToString(reader["SecondName"]);
                    people.ThirdName = Convert.ToString(reader["ThirdName"]);
                    people.LastName = Convert.ToString(reader["LastName"]);
                    people.Phone = Convert.ToString(reader["Phone"]);
                    people.Email = Convert.ToString(reader["Email"]);
                    people.Address = Convert.ToString(reader["Address"]);
                    people.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    people.ImagePath = Convert.ToString(reader["ImagePath"]);
                    people.NationalityCountryID = Convert.ToInt32(reader["NationalityCountryID"]);
                    people.Gendor = Convert.ToInt32(reader["Gendor"]);


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


