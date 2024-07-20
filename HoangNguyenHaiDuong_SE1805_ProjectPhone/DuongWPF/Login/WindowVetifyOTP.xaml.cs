using BusinessObjects;
using System;
using System.Windows;
using System.Windows.Input;

namespace DuongWPF.Login
{
	public partial class WindowVetifyOTP : Window
	{
		private readonly string generatedOtp;
		private readonly string _username;
		private readonly LoginObject loginObject;
		private readonly CustomerObject customerObject;

		public WindowVetifyOTP(string generatedOtp, string username)
		{
			InitializeComponent();
			this.generatedOtp = generatedOtp;
			_username = username;
			loginObject = new LoginObject();
			customerObject = new CustomerObject();
		}

		private void Change_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				string enteredOtp = txtOTP.Text;
				string newPassword = PasswordBox.Password.Trim();
				string newPasswordA = PasswordBoxA.Password.Trim();
				var isUser = loginObject.FindUserByEmail(_username);
				var isCustomer = customerObject.GetCustomerByEmail(_username);

				if (string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(newPasswordA))
				{
					MessageBox.Show("Vui lòng nhập mật khẩu.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
					return;
				}

				if (newPassword != newPasswordA)
				{
					MessageBox.Show("Mật khẩu không khớp.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
					return;
				}

				if (enteredOtp != generatedOtp)
				{
					MessageBox.Show("OTP không hợp lệ.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
					return;
				}

				if (isUser != null)
				{
				
					loginObject.ChangePassword(_username, newPassword);
				}
				else
				{
					
					customerObject.ChangePassword(_username, newPassword);
				}

				MessageBox.Show("Mật khẩu đã được thay đổi thành công.");
				WindowLogin windowLogin = new WindowLogin();
				windowLogin.Show();
				this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Thay đổi mật khẩu không thành công: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
