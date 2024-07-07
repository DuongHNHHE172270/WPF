using BusinessObjects;
using System;
using System.Windows;
using System.Windows.Input;

namespace DuongWPF.Login
{
	public partial class WindowLogin : Window
	{
		private readonly LoginObject loginObject;
		public WindowLogin()
		{
			InitializeComponent();
			loginObject = new LoginObject();
		}

		private void ResetFrom()
		{
			txtUserName.Text = null;
			PasswordBox.Password = null;
		}
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			String username = txtUserName.Text;
			String password = PasswordBox.Password;
			if (!String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(password))
			{
				try
				{
					bool isAuthor = loginObject.Login(username, password);

					if (isAuthor)
					{
						if(loginObject.GetUser().IdRole == 1)
						{
							WindowAdmin windowAdmin = new WindowAdmin();
							windowAdmin.Show();
							this.Close();
						}
						else
						{
							MainWindow mainWindow = new MainWindow();
							mainWindow.Show();
							this.Close();
						}
					}
					else
					{
						MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
						ResetFrom();
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
					ResetFrom();
				}
			}
			else
			{
				MessageBox.Show("Username and password cannot be empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
				ResetFrom();
			}
		}

		
		private void Register_Click(object sender, MouseButtonEventArgs e)
		{
			WindowRegister windowRegister = new WindowRegister();
			windowRegister.Show();
			this.Close();
		}

		private void ForgotPassword_Click(object sender, MouseButtonEventArgs e)
		{
			WindowChangePassword windowChangePassword = new WindowChangePassword();	
			windowChangePassword.Show();
			this.Close();
		}
	}
}
