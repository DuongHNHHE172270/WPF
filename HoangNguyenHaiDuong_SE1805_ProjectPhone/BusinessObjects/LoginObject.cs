using DataAccess.DAL;
using DataAccess.Models;

namespace BusinessObjects
{
	public class LoginObject
	{
		private readonly LoginDao loginDao;
		public static User? accountUser { get; set; }

		public LoginObject()
		{
			loginDao = new LoginDao();
		}

		public bool Login(string username, string password)
		{
			User user = loginDao.FindUser(username, password);

			if (user == null)
			{
				return false;
			}
			accountUser = user;
			return true;
		}

		public User GetUser()
		{
			User user = accountUser;
			return user;
		}

		public void Register(User user) => loginDao.InsertUser(user);

		public bool IsUserNameExists(string username) => loginDao.IsUserNameExists(username);

		public void ChangePassword(string username, string newPassword) => loginDao.ChangePassword(username, newPassword);
	}
}
