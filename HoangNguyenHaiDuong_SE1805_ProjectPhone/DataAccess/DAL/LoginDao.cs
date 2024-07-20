using BCrypt.Net;
using DataAccess.Models;
using System;
using System.Linq;

namespace DataAccess.DAL
{
	public class LoginDao
	{
		public User FindUser(string username, string password)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				var user = context.Users.FirstOrDefault(u => u.UserName == username);
				if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password) && user.Status == "1")
				{
					return user;
				}
				return null;
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public Customer Customer(string email, string password)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				var customer = context.Customers.FirstOrDefault(u => u.Email == email);
				if (customer != null && BCrypt.Net.BCrypt.Verify(password, customer.Password) && customer.Status == "1")
				{
					return customer;
				}
				return null;
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public void InsertUser(User user)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				user.IdRole = 2;
				user.Status = "0";
				user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
				context.Users.Add(user);
				context.SaveChanges();
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}


		public void InsertCustomer(Customer customer)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				customer.Status = "1";
				customer.Password = BCrypt.Net.BCrypt.HashPassword(customer.Password);
				context.Customers.Add(customer);
				context.SaveChanges();
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void UpdateUser(User user)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				context.SaveChanges();
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public void ChangePassword(string username, string newPassword)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				var user = context.Users.FirstOrDefault(u => u.UserName == username);
				if (user != null)
				{
					user.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
					context.SaveChanges();
				}
				else
				{
					throw new Exception("User not found.");
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public bool IsUserNameExists(string username)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				return context.Users.Any(u => u.UserName == username);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public bool IsUserNameCusExists(string username)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				return context.Customers.Any(u => u.Email == username);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public User FindUserUsername(string username)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				return context.Users.FirstOrDefault(u => u.UserName == username);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public void Update(User user)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				context.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new Exception($"Error updating customer: {ex.Message}");
			}
		}
	}
}
