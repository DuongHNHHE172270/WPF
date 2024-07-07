using BusinessObjects;
using DataAccess.Models;
using System;
using System.Windows;
using System.Windows.Input;

namespace DuongWPF.Login
{
	public partial class WindowRegister : Window
	{
		private readonly LoginObject loginObject;
		public WindowRegister()
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

		private void Register_Click(object sender, RoutedEventArgs e)
		{
			String Name = txtName.Text.Trim();
			String userName = txtUserName.Text.Trim();
			String pass = PasswordBox.Password.Trim();
			String passA = PasswordBoxA.Password.Trim();
			if (String.IsNullOrWhiteSpace(userName) || String.IsNullOrWhiteSpace(pass) || String.IsNullOrWhiteSpace(passA) || String.IsNullOrWhiteSpace(Name))
			{
				MessageBox.Show("Please input all space", "Error", MessageBoxButton.OK);
				ResetForm();
				return;
			}
			if (loginObject.IsUserNameExists(userName))
			{
				MessageBox.Show("UserName already exists", "Error", MessageBoxButton.OK);
				ResetForm();
				return;
			}
			if (!pass.Equals(passA))
			{
				MessageBox.Show("Passwords do not match", "Error", MessageBoxButton.OK);
				ResetForm();
				return;
			}

			User newUser = new User()
			{
				DisplayName = Name,
				UserName = userName,
				Password = pass,
			};

			try
			{
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

		private void Login_Click(object sender, MouseButtonEventArgs e)
		{
			WindowLogin windowLogin = new WindowLogin();
			windowLogin.Show();
			this.Close();
		}
	}
}
