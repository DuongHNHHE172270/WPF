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
		private void Login_Click(object sender, MouseButtonEventArgs e)
		{
			WindowLogin windowLogin = new WindowLogin();
			windowLogin.Show();
			this.Close();
		}

		private void staff_Click(object sender, RoutedEventArgs e)
		{
			WindowStaffRegister windowStaffRegister = new WindowStaffRegister();
			windowStaffRegister.Show();
			this.Close();

		}

		private void Customer_Click(object sender, RoutedEventArgs e)
		{
			WindowCustomerRegister windowCustomerRegister = new WindowCustomerRegister();	
			windowCustomerRegister.Show();
			this.Close();
		}
	}
}
