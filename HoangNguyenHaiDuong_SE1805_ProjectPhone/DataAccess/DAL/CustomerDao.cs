using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAL
{
	public class CustomerDao
	{
		public List<Customer> GetAll()
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				return context.Customers.ToList();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void Add(Customer customer)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				context.Customers.Add(customer);
				context.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void Delete(Customer customer)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				context.Customers.Remove(customer);
				context.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void Update(Customer customer)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				context.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				context.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new Exception($"Error updating customer: {ex.Message}");
			}
		}

		public bool ExistsByEmail(string email)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				var customer = context.Customers.FirstOrDefault(x => x.Email == email);
				return customer != null;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public bool ExistsByPhone(string phone)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				var customer = context.Customers.FirstOrDefault(x => x.Phone == phone);
				return customer != null;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public bool ExistsByPhoneInclude(string phone, int currentCustomerId)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				return context.Customers.Any(c => c.Phone == phone && c.Id != currentCustomerId);
			}
			catch (Exception ex)
			{
				throw new Exception($"Error checking existence of customer by phone: {ex.Message}");
			}
		}

		public bool ExistsByEmailInclude(string email, int currentCustomerId)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				return context.Customers.Any(c => c.Email == email && c.Id != currentCustomerId);
			}
			catch (Exception ex)
			{
				throw new Exception($"Error checking existence of customer by email: {ex.Message}");
			}
		}
		public Customer GetOutputById(int id)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				return context.Customers.FirstOrDefault(o => o.Id == id);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public Customer GetCustByEmail(string email)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				return context.Customers.FirstOrDefault(o => o.Email == email);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}

}

