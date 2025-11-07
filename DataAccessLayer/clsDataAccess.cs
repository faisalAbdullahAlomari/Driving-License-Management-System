using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class clsDataAccess
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
    }
}
