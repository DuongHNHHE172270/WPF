using BusinessObjects;
using DataAccess.Models;
using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace DuongWPF.Customer
{
	/// <summary>
	/// Interaction logic for WindowAddPopup.xaml
	/// </summary>
	public partial class WindowAddPopup : Window
	{
		private readonly CustomerObject customerObject;

		public WindowAddPopup()
		{
			InitializeComponent();
			customerObject = new CustomerObject();
		}

		void Load()
		{
			txtAddress.Text = null;
			txtEmail.Text = null;
			txtFullName.Text = null;
			txtPhone.Text = null;
		}

		private void btnAdd_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				string fullName = txtFullName.Text;
				string address = txtAddress.Text;
				string phone = txtPhone.Text;
				string email = txtEmail.Text;

				if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(address) ||
					string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(email))
				{
					MessageBox.Show("Hãy nhập đầy đủ thông tin!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
					Load();
					return;
				}

				if (!Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
				{
					MessageBox.Show("Địa chỉ email không hợp lệ! Vui lòng nhập lại.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
					Load();
					return;
				}

				if (!Regex.IsMatch(phone, @"^0\d{9}$"))
				{
					MessageBox.Show("Số điện thoại không hợp lệ! Vui lòng nhập số điện thoại bắt đầu bằng số 0 và có 10 chữ số.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
					Load();
					return;
				}

				if (customerObject.ExistsCustomerByEmail(email))
				{
					MessageBox.Show("Email này đã tồn tại!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
					Load();
					return;
				}

				if (customerObject.ExistsCustomerByPhone(phone))
				{
					MessageBox.Show("Số điện thoại này đã tồn tại!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
					Load();
					return;
				}

				DataAccess.Models.Customer customer = new DataAccess.Models.Customer
				{
					DisplayName = fullName,
					Address = address,
					Phone = phone,
					Email = email,
				};


				customerObject.AddCustomer(customer);

				MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

				Close();

				if (Owner is WindowCustomer parentWindow)
				{
					parentWindow.Load();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
