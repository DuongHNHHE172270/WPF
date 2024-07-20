using DuongWPF.Login;
using DuongWPF.OutputObject;
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

namespace DuongWPF.Customer
{
	/// <summary>
	/// Interaction logic for WindowHomeCustomer.xaml
	/// </summary>
	public partial class WindowHomeCustomer : Window
	{

		public WindowHomeCustomer()
		{
			InitializeComponent();
		}

		private void Input_Click(object sender, RoutedEventArgs e)
		{
			WindowAddOutCustomer windowAddOuputPopup = new WindowAddOutCustomer();
			windowAddOuputPopup.Owner = this;
			windowAddOuputPopup.ShowDialog();
		}

		private void Profile_Click(object sender, RoutedEventArgs e)
		{
			WindowCusUpdatePopup windowCusUpdatePopup = new WindowCusUpdatePopup();
			windowCusUpdatePopup.Owner = this;
			windowCusUpdatePopup.ShowDialog();
		}

		private void history_Click(object sender, RoutedEventArgs e)
		{
			WindowHistory windowHistory = new WindowHistory();
			windowHistory.Show();
			this.Close();

		}

		private void LogOut_Click(object sender, RoutedEventArgs e)
		{
			WindowLogin windowLogin = new WindowLogin();
			windowLogin.Show();
			this.Close();
		}
	}
}
