using DataAccess.DAL;
using DataAccess.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace BusinessObjects
{
	public class LoginObject
	{
		private readonly LoginDao loginDao;
		public static User? accountUser { get; set; }

		public static Customer? accoutCustomer { get; set; }

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

		public bool LoginCustomer(string username, string password)
		{
			Customer customer = loginDao.Customer(username, password);

			if (customer == null)
			{
				return false;
			}
			accoutCustomer = customer;
			return true;
		}

		public User GetUser()
		{
			User user = accountUser;
			return user;
		}

		public Customer GetCustomer()
		{
			Customer cus = accoutCustomer;
			return cus;
		}

		public void Register(User user) => loginDao.InsertUser(user);

		public void RegisterCus(Customer cus) => loginDao.InsertCustomer(cus);
		public bool IsUserNameExists(string username) => loginDao.IsUserNameExists(username);

		public bool IsCusNameExists(string username) => loginDao.IsUserNameCusExists(username);
		public void ChangePassword(string username, string newPassword) => loginDao.ChangePassword(username, newPassword);
		
		public User FindUserByEmail(string email) => loginDao.FindUserUsername(email);
	}
}
