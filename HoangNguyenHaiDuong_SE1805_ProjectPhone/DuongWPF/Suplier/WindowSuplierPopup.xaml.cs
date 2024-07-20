using BusinessObjects;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DuongWPF.Suplier
{
	/// <summary>
	/// Interaction logic for WindowSuplierPopup.xaml
	/// </summary>
	public partial class WindowSuplierPopup : Window
	{
		private readonly SuplierObject suplierObject;
		public WindowSuplierPopup()
		{
			InitializeComponent();
			suplierObject = new SuplierObject();
		}

		void ResetForm()
		{
			txtFullName.Text = null;
			txtAddress.Text = null;
			txtPhone.Text = null;
			txtEmail.Text = null;
		}

		private void btnAdd_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				String name = txtFullName.Text;
				String address = txtAddress.Text;
				String phone = txtPhone.Text;
				String email = txtEmail.Text;

				if(String.IsNullOrWhiteSpace(name) || String.IsNullOrWhiteSpace(address) || String.IsNullOrWhiteSpace(phone) || 
					String.IsNullOrWhiteSpace(email))
				{
					MessageBox.Show("Hãy nhập hết thông tin!", "Error", MessageBoxButton.OK);
					ResetForm();
					return;
				}

				if(suplierObject.ExitsNameSuplier(name))
				{
					MessageBox.Show("Đã có công ty này", "Error", MessageBoxButton.OK);
					ResetForm();
					return;
				}

				// Kiểm tra định dạng số điện thoại
				if (!Regex.IsMatch(phone, @"^0\d{9}$"))
				{
					MessageBox.Show("Số điện thoại không hợp lệ! Vui lòng nhập số điện thoại bắt đầu bằng số 0 và có 10 chữ số.", "Error", MessageBoxButton.OK);
					ResetForm();
					return;
				}

				// Kiểm tra định dạng email
				if (!Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
				{
					MessageBox.Show("Địa chỉ email không hợp lệ! Vui lòng nhập lại.", "Error", MessageBoxButton.OK);
					ResetForm();
					return;
				}

				if (suplierObject.ExitsEamailSuplier(email)) 
				{
					MessageBox.Show("Email này đã tồn tại", "Error", MessageBoxButton.OK);
					ResetForm();
					return;
				}

				if (suplierObject.ExitsPhoneSuplier(phone))
				{
					MessageBox.Show("Số điện thoại này đã tồn tại", "Error", MessageBoxButton.OK);
					ResetForm();
					return;
				}
				DataAccess.Models.Suplier suplier = new DataAccess.Models.Suplier()
				{
					DisplayName = name,
					Address = address,
					Phone = phone,
					Email = email,
					Status = "1",
				};
				
				suplierObject.AddSuplier(suplier);
				MessageBox.Show("Thêm thành công", "Success", MessageBoxButton.OK);
				Close();

				if (Owner is WindowSuplier parentWindow)
				{
					parentWindow.Load();
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
