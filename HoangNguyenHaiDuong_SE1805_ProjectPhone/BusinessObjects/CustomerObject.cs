using DataAccess.DAL;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
	public class CustomerObject
	{
		private readonly CustomerDao customerDao;

		public CustomerObject()
		{
			customerDao = new CustomerDao();
		}

		public List<Customer> GetCustomers() => customerDao.GetAll();

		public List<Customer> Search(string character)
		{
			return GetCustomers().Where(c => c.DisplayName.ToLower().Contains(character.ToLower())).ToList();
		}

		public void AddCustomer(Customer customer)
		{
			customerDao.Add(customer);
		}

		public void UpdateCustomer(Customer customer)
		{	
				customerDao.Update(customer);
		}

		public void DeleteCustomer(Customer customer)
		{
			customerDao.Delete(customer);
		}

		public bool ExistsCustomerByEmail(string email)
		{
			return customerDao.ExistsByEmail(email);
		}

		public bool ExistsCustomerByPhone(string phone)
		{
			return customerDao.ExistsByPhone(phone);
		}

		public bool ExistsCustomerByEmailExcludingCurrent(string email, int currentCustomerId)
		{
			return customerDao.ExistsByEmailInclude(email, currentCustomerId);
		}

		public bool ExistsCustomerByPhoneExcludingCurrent(string phone, int currentCustomerId)
		{
			return customerDao.ExistsByPhoneInclude(phone, currentCustomerId);
		}	
	}
}
