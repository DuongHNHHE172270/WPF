using BusinessObjects;
using DuongWPF.NewFolder;
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

namespace DuongWPF.ObjectP
{
	/// <summary>
	/// Interaction logic for WindowPhoneDetail.xaml
	/// </summary>
	public partial class WindowPhoneDetail : Window
	{
		private readonly ObjectPhone objectPhone;
		public WindowPhoneDetail()
		{
			InitializeComponent();
			objectPhone = new ObjectPhone();
			Loaded += WindowPhoneDetail_Loaded;
		}

		private void WindowPhoneDetail_Loaded(object sender, RoutedEventArgs e)
		{
			Load();
		}

		void Load()
		{
			dgObjectDetail.ItemsSource = objectPhone.GetAllObjDetail();
		}
		private void btnSearch_Click(object sender, RoutedEventArgs e)
		{
			string searchText = SearchTextBox.Text.Trim();
			if (!string.IsNullOrEmpty(searchText))
			{
				try
				{
					dgObjectDetail.ItemsSource = objectPhone.SearchByNameDetailObj(searchText);
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Lỗi khi tìm kiếm vật tư: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			else
			{
				MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void btnLoad_Click(object sender, RoutedEventArgs e)
		{
			Load();
		}

		private void btnReturn_Click(object sender, RoutedEventArgs e)
		{
			WindowObjectPhone windowObjectPhone	= new WindowObjectPhone();
			windowObjectPhone.Show();
			this.Close();
		}
	}
}
