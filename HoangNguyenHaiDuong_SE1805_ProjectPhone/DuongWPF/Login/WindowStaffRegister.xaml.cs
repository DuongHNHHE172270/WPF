using BusinessObjects;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace DuongWPF.Login
{
	/// <summary>
	/// Interaction logic for WindowStaffRegister.xaml
	/// </summary>
	public partial class WindowStaffRegister : Window
	{
		private readonly LoginObject loginObject;
		public WindowStaffRegister()
		{
			InitializeComponent();
			loginObject = new LoginObject();
		}

		private void ResetForm()
		{
			txtName.Text = null;
			txtUserName.Text = null;
			PasswordBox.Password = null;
			PasswordBoxA.Password = null;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				string Name = txtName.Text.Trim();
				string userName = txtUserName.Text.Trim();
				string pass = PasswordBox.Password.Trim();
				string passA = PasswordBoxA.Password.Trim();
				if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(pass) || string.IsNullOrWhiteSpace(passA) || string.IsNullOrWhiteSpace(Name))
				{
					MessageBox.Show("Vui lòng nhập hết trường", "Error", MessageBoxButton.OK);
					ResetForm();
					return;
				}
				if (!Regex.IsMatch(userName, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
				{
					MessageBox.Show("Địa chỉ email không hợp lệ! Vui lòng nhập lại.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
					ResetForm();
					return;
				}
				if (loginObject.IsUserNameExists(userName))
				{
					MessageBox.Show("Email đã tồn tại", "Error", MessageBoxButton.OK);
					ResetForm();
					return;
				}
				if (loginObject.IsCusNameExists(userName))
				{
					MessageBox.Show("Email đã tồn tại", "Error", MessageBoxButton.OK);
					ResetForm();
					return;
				}
				if (!pass.Equals(passA))
				{
					MessageBox.Show("Mật khẩu không khớp", "Error", MessageBoxButton.OK);
					ResetForm();
					return;
				}

				User newUser = new User()
				{
					DisplayName = Name,
					UserName = userName,
					Password = pass,
				};


				loginObject.Register(newUser);
				MessageBox.Show("Register successful!", "Success", MessageBoxButton.OK);
				WindowLogin windowLogin = new WindowLogin();
				windowLogin.Show();
				this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Đăng ký thất bại: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
				ResetForm();
			}
		}

		private void Return_Click(object sender, MouseButtonEventArgs e)
		{
			WindowRegister windowRegister = new WindowRegister();
			windowRegister.Show();
			this.Close();
		}
	}
}
