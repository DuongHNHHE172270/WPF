using BusinessObjects;
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
	/// Interaction logic for WindowHistory.xaml
	/// </summary>
	public partial class WindowHistory : Window
	{
		private readonly OutObject outObject;
		private readonly CustomerObject customerObject;
		private readonly LoginObject loginObject;
		private readonly ObjectPhone objectPhone;
		public WindowHistory()
		{
			InitializeComponent();
			outObject = new OutObject();
			customerObject = new CustomerObject();
			loginObject = new LoginObject();
			objectPhone = new ObjectPhone();
			LoadOutputInfos();
		}

		public void LoadOutputInfos()
		{
			try
			{
				var outputList = outObject.GetAllOutputsCus(loginObject.GetCustomer().Id);
				dgOuputInfo.ItemsSource = outputList;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
			}
		}

		private void btnSearch_Click(object sender, RoutedEventArgs e)
		{
			string searchTerm = SearchTextBox.Text.Trim();

			try
			{
				var outputList = outObject.GetAllOutputsCus(loginObject.GetCustomer().Id).Where(o => o.ObjectName.ToLower().Contains(searchTerm.ToLower())).ToList();
				dgOuputInfo.ItemsSource = outputList;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
			}
		}


		private void btnLoad_Click(object sender, RoutedEventArgs e)
		{
			LoadOutputInfos();
		}

		private void btnReturn_Click(object sender, RoutedEventArgs e)
		{
			WindowHomeCustomer windowHomeCustomer = new WindowHomeCustomer();
			windowHomeCustomer.Show();
			this.Close();
		}

	}
}
