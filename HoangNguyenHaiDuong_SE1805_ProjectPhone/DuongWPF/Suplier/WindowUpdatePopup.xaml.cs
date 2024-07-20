using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DataAccess.Models;
using System.Text.RegularExpressions;

namespace DuongWPF.Suplier
{
	/// <summary>
	/// Interaction logic for WindowUpdatePopup.xaml
	/// </summary>
	public partial class WindowUpdatePopup : Window
	{
		private readonly SuplierObject suplierObject;
		private readonly DataAccess.Models.Suplier currentSuplier;
		public WindowUpdatePopup(DataAccess.Models.Suplier suplier)
		{
			InitializeComponent();
			suplierObject = new SuplierObject();
			currentSuplier = suplier;
			Load();
		}

		private void Load()
		{
			txtFullName.Text = currentSuplier.DisplayName;
			txtAddress.Text = currentSuplier.Address;
			txtEmail.Text = currentSuplier.Email;
			txtPhone.Text = currentSuplier.Phone;

			if (rbActive.IsChecked == true)
			{
				currentSuplier.Status = "1";
			}
			else
			{
				currentSuplier.Status = "0";
			}
		}
		private void btnUpdate_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				String name = txtFullName.Text;
				String address = txtAddress.Text;
				String phone = txtPhone.Text;
				String email = txtEmail.Text;

				if (String.IsNullOrWhiteSpace(name) || String.IsNullOrWhiteSpace(address) || 
					String.IsNullOrWhiteSpace(phone) || String.IsNullOrWhiteSpace(email))
				{
					MessageBox.Show("Hãy nhập hết thông tin!", "Error", MessageBoxButton.OK);
					Load();
					return;
				}

				if (suplierObject.ExistsByNameExcludingCurrent(name, currentSuplier.Id))
				{
					MessageBox.Show("Tên nhà cung cấp đã tồn tại! Vui lòng nhập tên khác.", "Error", MessageBoxButton.OK);
					Load();
					return;
				}

				// Kiểm tra định dạng số điện thoại
				if (!Regex.IsMatch(phone, @"^0\d{9}$"))
				{
					MessageBox.Show("Số điện thoại không hợp lệ! Vui lòng nhập số điện thoại bắt đầu bằng số 0 và có 10 chữ số.", "Error", MessageBoxButton.OK);
					Load();
					return;
				}

				// Kiểm tra định dạng email
				if (!Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
				{
					MessageBox.Show("Địa chỉ email không hợp lệ! Vui lòng nhập lại.", "Error", MessageBoxButton.OK);
					Load();
					return;
				}

				if (suplierObject.ExistsByEmailExcludingCurrent(email, currentSuplier.Id))
				{
					MessageBox.Show("Email này đã tồn tại", "Error", MessageBoxButton.OK);
					Load();
					return;
				}
				if (suplierObject.ExistsByPhoneExcludingCurrent(phone, currentSuplier.Id))
				{
					MessageBox.Show("Số điện thoại tồn tại", "Error", MessageBoxButton.OK);
					Load();
					return;
				}
				currentSuplier.DisplayName = name;
				currentSuplier.Address = address;
				currentSuplier.Email = email;
				currentSuplier.Phone = phone;
				currentSuplier.Status = rbActive.IsChecked == true ? "1" : "0";

				suplierObject.UpdateSuplier(currentSuplier);
				MessageBox.Show("Cập nhật thành công", "Success", MessageBoxButton.OK);
				Close();

				if (Owner is WindowSuplier suplier)
				{
					suplier.Load();
				}

			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
		}

		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
