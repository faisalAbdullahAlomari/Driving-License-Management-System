using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public static class clsDataAccess
    {

        public static bool FindUserByUserNameAndPassword(ref int UserID, ref int PersonID, string UserName, string Password, ref bool IsActive)
        {

            bool IsFound = false;

            string query = "SELECT * FROM Users WHERE UserName = @UserName AND Password = @Password";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString2))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        command.Parameters.Add("@UserName", SqlDbType.NVarChar, 20).Value = UserName;
                        command.Parameters.Add("@Password", SqlDbType.NVarChar, 20).Value = Password;

                        using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow))
                        {

                            if (reader.Read())
                            {
                                IsFound = true;
                                UserID = (int)reader["UserID"];
                                PersonID = (int)reader["PersonID"];
                                UserName = (string)reader["UserName"];
                                Password = (string)reader["Password"];
                                IsActive = (bool)reader["IsActive"];
                            }
                        }
                    } catch (Exception ex)
                    {
                        IsFound = false;
                        throw;
                    }

                    return IsFound;
                }
            }
        }

        public static DataTable GetAllThePeople()
        {
            string query = "SELECT * FROM People";

            DataTable dtPeople = new DataTable();

            using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString2))
            {
                using(SqlCommand command = new SqlCommand(query, connection))
                {

                    try
                    {
                        connection.Open();

                        using(SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.HasRows)
                            {

                                dtPeople.Load(reader);
                            }
                        }
                    }catch(Exception ex)
                    {
                        throw;
                    }
                }
            }

            return dtPeople;
        }

        public static int AddNewPerson(string NationalNumber, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, bool Gender, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {

            int PersonID = -1;

            string query = @"INSERT INTO People (NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gender, Address, Phone, Email)
                            Values(@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth, @Gender, @Address, @Phone, @Email);
                            SELECT SCOPE_IDENTITY();";

            using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString2))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.Add("@NationalNo", SqlDbType.NVarChar, 20).Value = NationalNumber;
                    command.Parameters.Add("@FirstName", SqlDbType.NVarChar, 20).Value = FirstName;
                    command.Parameters.Add("@SecondName", SqlDbType.NVarChar, 20).Value = SecondName;

                    if (!string.IsNullOrWhiteSpace(ThirdName))
                    {
                        command.Parameters.Add("@ThirdName", SqlDbType.NVarChar, 20).Value = ThirdName;
                    }
                    else
                    {
                        command.Parameters.Add("@ThirdName", SqlDbType.NVarChar).Value = DBNull.Value;
                    }

                    command.Parameters.Add("@LastName", SqlDbType.NVarChar, 20).Value = LastName;
                    command.Parameters.Add("@DateOfBirth", SqlDbType.DateTime).Value = DateOfBirth;
                    command.Parameters.Add("@Gender", SqlDbType.TinyInt).Value = Gender;
                    command.Parameters.Add("@Address", SqlDbType.NVarChar, 500).Value = Address;
                    command.Parameters.Add("@Phone", SqlDbType.NVarChar, 20).Value = Phone;

                    if (!string.IsNullOrWhiteSpace(Email))
                    {
                        command.Parameters.Add("@Email", SqlDbType.NVarChar, 20).Value = Email;
                    }
                    else
                    {
                        command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = DBNull.Value;
                    }

                    command.Parameters.Add("@NationalityCountryID", SqlDbType.Int).Value = NationalityCountryID;
                    if (!string.IsNullOrWhiteSpace(ImagePath))
                    {
                        command.Parameters.Add("@ImagePath", SqlDbType.NVarChar, 250);
                    }
                    else
                    {
                        command.Parameters.Add("ImagePath", SqlDbType.NVarChar).Value = DBNull.Value;
                    }

                    try
                    {
                        connection.Open();

                        object ID = command.ExecuteScalar();

                        if (ID != null && int.TryParse(ID.ToString(), out int InsertedPersonID))
                        {
                            PersonID = InsertedPersonID;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }

            return PersonID;
        }
    }
}
