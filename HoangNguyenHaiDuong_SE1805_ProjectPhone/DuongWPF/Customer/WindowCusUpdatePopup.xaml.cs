using DataAccess.Models;
using BusinessObjects;
using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace DuongWPF.Customer
{
	/// <summary>
	/// Interaction logic for WindowUpdatePopup.xaml
	/// </summary>
	public partial class WindowCusUpdatePopup : Window
	{
		private readonly CustomerObject customerObject;
		private readonly DataAccess.Models.Customer currentCustomer;

		public WindowCusUpdatePopup(DataAccess.Models.Customer customer)
		{
			InitializeComponent();
			customerObject = new CustomerObject();
			currentCustomer = customer;
			Load();
		}

		private void Load()
		{
			txtFullName.Text = currentCustomer.DisplayName;
			txtAddress.Text = currentCustomer.Address;
			txtEmail.Text = currentCustomer.Email;
			txtPhone.Text = currentCustomer.Phone;
		}

		private void btnUpdate_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				string name = txtFullName.Text;
				string address = txtAddress.Text;
				string phone = txtPhone.Text;
				string email = txtEmail.Text;

				if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(phone) 
					|| string.IsNullOrWhiteSpace(email))
				{
					MessageBox.Show("Hãy nhập hết thông tin!", "Error", MessageBoxButton.OK);
					Load();
					return;
				}

				if (customerObject.ExistsCustomerByEmailExcludingCurrent(email, currentCustomer.Id))
				{
					MessageBox.Show("Email này đã tồn tại! Vui lòng nhập email khác.", "Error", MessageBoxButton.OK);
					Load();
					return;
				}

				if (!Regex.IsMatch(phone, @"^0\d{9}$"))
				{
					MessageBox.Show("Số điện thoại không hợp lệ! Vui lòng nhập số điện thoại bắt đầu bằng số 0 và có 10 chữ số.", 
						"Error", MessageBoxButton.OK);
					Load();
					return;
				}

				if (!Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
				{
					MessageBox.Show("Địa chỉ email không hợp lệ! Vui lòng nhập lại.", "Error", MessageBoxButton.OK);
					Load();
					return;
				}

				if (customerObject.ExistsCustomerByPhoneExcludingCurrent(phone, currentCustomer.Id))
				{
					MessageBox.Show("Số điện thoại này đã tồn tại!", "Error", MessageBoxButton.OK);
					Load();
					return;
				}

				currentCustomer.DisplayName = name;
				currentCustomer.Address = address;
				currentCustomer.Email = email;
				currentCustomer.Phone = phone;

				customerObject.UpdateCustomer(currentCustomer);
				MessageBox.Show("Cập nhật thông tin khách hàng thành công!", "Success", MessageBoxButton.OK);
				Close();

				if (Owner is WindowCustomer customerWindow)
				{
					customerWindow.Load();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Error", MessageBoxButton.OK);
			}
		}

		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
