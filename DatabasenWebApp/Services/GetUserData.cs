using DatabasenWebApp.Controllers;
using DatabasenWebApp.Models;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
//Jeg liker ost
namespace DatabasenWebApp.Services
{
    public class GetUserData
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WebApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public int GetIdFromUserName(string userName)
        {
            string sqlStatement = "SELECT Id FROM dbo.Users Where username = @username";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 40).Value = userName;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        return reader.GetInt32(0);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return -1;
        }
        public UserModel GetUserModelFromUsernameAndPassword(string username, string password)
        {   
            UserModel model = new UserModel();
            string sqlStatement = "SELECT * FROM dbo.Users Where username = @username AND password = @password";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 40).Value = username;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 40).Value = password;

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            model.Id = !reader.IsDBNull(0) ? reader.GetInt32(0) : -1;
                            model.UserName = !reader.IsDBNull(1) ? reader.GetString(1) : "";
                            model.Password = !reader.IsDBNull(2) ? reader.GetString(2) : "";
                            model.Bio = !reader.IsDBNull(3) ? reader.GetString(3) : "Write your own bio!";
                            return model;
                        }   
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return null;
        }
        public bool FuckSecurity(int id, string bio)
        {

            string sqlStatement = "UPDATE dbo.Users SET bio = @bio WHERE id = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.Add("@bio", System.Data.SqlDbType.VarChar).Value = bio;
                command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

                try
                {
                    connection.Open();
                    int UsersAffected = command.ExecuteNonQuery();
                    return UsersAffected > 0;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
