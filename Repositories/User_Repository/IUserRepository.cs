using Hotel.Models;

namespace Hotel.Repositories.User_Repository
{
    public interface IUserRepository
	{
		List<SignUpModel> GetUsers();
		SignUpModel GetUserByEmailAndPassword(string email, string password);
		SignUpModel GetUserByEmail(string email);
		void AddUser(SignUpModel user);
		string HashPassword(string password);	

	}
}
