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

namespace DuongWPF.OutputObject
{
	/// <summary>
	/// Interaction logic for WindowAllOuputInfo.xaml
	/// </summary>
	public partial class WindowAllOuputInfo : Window
	{
		private readonly OutObject outObject;
		private readonly CustomerObject customerObject;
		private readonly LoginObject loginObject;
		private readonly ObjectPhone objectPhone;
		public WindowAllOuputInfo()
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
				var outputList = outObject.GetAllOutputAd();
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
				var outputList = outObject.GetAllOutputAd().Where(o => o.ObjectName.ToLower().Contains(searchTerm.ToLower())).ToList();
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

		private void btnAdd_Click(object sender, RoutedEventArgs e)
		{
			WindowAddOuputPopup windowAddOuputPopup = new WindowAddOuputPopup();
			windowAddOuputPopup.Owner = this;
			windowAddOuputPopup.ShowDialog();
		}

		private void btnReturn_Click(object sender, RoutedEventArgs e)
		{
			WindowAdmin windowAdmin = new WindowAdmin();
			windowAdmin.Show();
			this.Close();
		}
	}
}
