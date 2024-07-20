using BusinessObjects;
using ClosedXML.Excel;
using DuongWPF.ObjectP;
using DuongWPF.Suplier;
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

namespace DuongWPF.NewFolder
{
	/// <summary>
	/// Interaction logic for WindowObjectPhone.xaml
	/// </summary>
	public partial class WindowObjectPhone : Window
	{
		private readonly ObjectPhone objectPhone;
		public WindowObjectPhone()
		{
			InitializeComponent();
			objectPhone = new ObjectPhone();
			Loaded += WindowObjectPhone_Loaded;
		}

		private void WindowObjectPhone_Loaded(object sender, RoutedEventArgs e)
		{
			Load();
		}

		public void Load()
		{
			dgObject.ItemsSource = objectPhone.GetAllObject();
		}

		private void btnSearch_Click(object sender, RoutedEventArgs e)
		{
			string searchText = SearchTextBox.Text.Trim();
			if (!string.IsNullOrEmpty(searchText))
			{
				try
				{
					dgObject.ItemsSource = objectPhone.SearchByName(searchText);
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

		private void btnAdd_Click(object sender, RoutedEventArgs e)
		{
			WindowAddPhonePopupxaml windowAddPhonePopupxaml = new WindowAddPhonePopupxaml();
			windowAddPhonePopupxaml.Owner = this;
			windowAddPhonePopupxaml.ShowDialog();
		}

		private void btnReturn_Click(object sender, RoutedEventArgs e)
		{
			WindowAdmin windowAdmin = new WindowAdmin();
			windowAdmin.Show();
			this.Close();
		}

		private void btnUpdate_Click(object sender, RoutedEventArgs e)
		{
			if (dgObject.SelectedItem is DataAccess.Models.Object obj)
			{
				try
				{
					obj.Status = obj.Status == "1" ? "0" : "1";
					objectPhone.UpdateObj(obj);
					MessageBox.Show("Cập nhật trạng thái thành công!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
					Load();
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Lỗi khi cập nhật trạng thái: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				}

			}

		}

		private void btnDelete_Click(object sender, RoutedEventArgs e)
		{
			if (dgObject.SelectedItem is DataAccess.Models.Object selectedObject)
			{
				try
				{
					objectPhone.DeleteObject(selectedObject);

					MessageBox.Show("Xóa vật tư thành công!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
					Load();
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Lỗi khi xóa vật tư: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			else
			{
				MessageBox.Show("Vui lòng chọn vật tư cần xóa.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		private void btnDetail_Click(object sender, RoutedEventArgs e)
		{
			WindowPhoneDetail windowPhoneDetail = new WindowPhoneDetail();
			 windowPhoneDetail.Show();
			this.Close();
		}
	}
}
