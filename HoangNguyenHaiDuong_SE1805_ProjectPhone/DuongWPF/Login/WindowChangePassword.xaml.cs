using BusinessObjects;
using DataAccess.Models;
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

namespace DuongWPF.Login
{
	/// <summary>
	/// Interaction logic for WindowChangePassword.xaml
	/// </summary>
	public partial class WindowChangePassword : Window
	{
		private readonly LoginObject loginObject;
		public WindowChangePassword()
		{
			InitializeComponent();
			loginObject = new LoginObject();
		}

		private void ResetForm()
		{
			txtUserName.Text = null;
			PasswordBox.Password = null;
			PasswordBoxA.Password = null;
		}
		private void Change_Click(object sender, RoutedEventArgs e)
		{
			string username = txtUserName.Text.Trim();
			string newPassword = PasswordBox.Password.Trim();
			string newPasswordAgain = PasswordBoxA.Password.Trim();

			if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(newPasswordAgain))
			{
				MessageBox.Show("Please input all fields", "Error", MessageBoxButton.OK);
				ResetForm();
				return;
			}

			if (!newPassword.Equals(newPasswordAgain))
			{
				MessageBox.Show("Passwords do not match", "Error", MessageBoxButton.OK);
				ResetForm();
				return;
			}

			try
			{
				loginObject.ChangePassword(username, newPassword);
				MessageBox.Show("Password changed successfully!", "Success", MessageBoxButton.OK);
				WindowLogin windowLogin = new WindowLogin();
				windowLogin.Show();
				this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Password change failed: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
