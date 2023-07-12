using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using Hotel.Models;

namespace Hotel.Repositories.User_Repository
{
    public class UserRepository : IUserRepository
	{

		private readonly string connectionString;


		public UserRepository(string connectionString)
		{
			this.connectionString = connectionString;
		}







		public SignUpModel GetUserByEmail(string email)
		{
			List<SignUpModel> users = GetUsers();
			SignUpModel exists = users.Find(user => user.Email == email);
			return exists;
		}








		public SignUpModel GetUserByEmailAndPassword(string email, string password)
		{
			List<SignUpModel> users = GetUsers();
			SignUpModel exists = users.Find(user => user.Email == email && user.Password == HashPassword(password));
			return exists;
		}






		public void AddUser(SignUpModel user)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				try
				{
					string query = "INSERT INTO users (fullname, email, pwd) VALUES (@fullname, @email, @pwd)";

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@fullname", SqlDbType.VarChar).Value = user.Fullname;
						command.Parameters.AddWithValue("@email", SqlDbType.VarChar).Value = user.Email;
						command.Parameters.AddWithValue("@pwd", SqlDbType.VarChar).Value = HashPassword(user.Password);

						connection.Open();
						command.ExecuteNonQuery();
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.ToString());
					// You may want to throw or handle the exception in a different way
				}
			}
		}


		



		public List<SignUpModel> GetUsers()
		{
			string query = "SELECT * FROM users";

			using (SqlConnection connection = new SqlConnection(connectionString))
			using (SqlCommand command = new SqlCommand(query, connection))
			{
				List<SignUpModel> users = new List<SignUpModel>();

				try
				{
					connection.Open();

					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							int userId = reader.GetInt32(reader.GetOrdinal("userID"));
							string fullname = reader.GetString(reader.GetOrdinal("fullname"));
							string email = reader.GetString(reader.GetOrdinal("email"));
							string pwd = reader.GetString(reader.GetOrdinal("pwd"));
							DateTime date = reader.GetDateTime(reader.GetOrdinal("dateCreation"));

							var user = new SignUpModel(userId, fullname, email, pwd, date);
							users.Add(user);
						}
					}
				}
				catch (Exception ex)
				{
					// Handle the exception or log the error
					Console.WriteLine(ex.ToString());
					throw; // Rethrow the exception or handle it in a different way
				}

				return users;
			}
		}







		public string HashPassword(string password)
		{
			using (SHA256 sha256 = SHA256.Create())
			{
				byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
				return Convert.ToBase64String(hashedBytes);
			}
		}








	}
}
